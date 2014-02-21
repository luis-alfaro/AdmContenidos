using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UtilitarioEnvioData.Entidades;
using UtilitarioEnvioData.GenerarXML;
using System.Configuration;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using AccessLayer;
namespace UtilitarioEnvioData.EnvioData
{
    public class EnvioData : Singleton<EnvioData>
    {

        //criteriosBusqueda[1] = "*.png";
        // Declare the logon types as constants
        //const long LOGON32_LOGON_INTERACTIVE = 2;
        const long LOGON32_LOGON_NETWORK = 3;

        // Declare the logon providers as constants
        //const long LOGON32_PROVIDER_DEFAULT = 0;
        const long LOGON32_PROVIDER_WINNT50 = 3;
        const long LOGON32_PROVIDER_WINNT40 = 2;
        const long LOGON32_PROVIDER_WINNT35 = 1;

        //Import Needed DLL
        [DllImport("advapi32.dll", EntryPoint = "LogonUser")]
        private static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        public bool GenerarArchivos(List<ENKiosco> kioscos, List<string> ArchivosEnviar, string Directorio, string DirectorioPrincipal)
        {
            try
            {
                string[] archivosGuardados = buscarArchivosEnDirectorio(DirectorioPrincipal + Directorio);

                foreach (string archivoGuardado in archivosGuardados)
                {
                    if (buscarEnLista(archivoGuardado, ArchivosEnviar, DirectorioPrincipal + Directorio) == false)
                    {
                        File.Delete(archivoGuardado);
                    }
                }
                EditarXML objXml = new EditarXML();
                objXml.editarXml(ArchivosEnviar, Directorio, DirectorioPrincipal);
                return true;
            }
            catch (Exception)
            {

            }
            return true;
        }

        public bool EnviarUnArchivo(ENKiosco kiosco, string archivo, string DirectorioLocal, string usuario, string dominio, string password)
        {

            string rutaLog = ConfigurationManager.AppSettings["RutaLogErrores"].ToString();

            StreamWriter sw = new StreamWriter(rutaLog, true);

            bool error = true;
            try
            {

                //IntPtr admin_token = IntPtr.Zero;
                //WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
                //WindowsIdentity wid_admin = null;
                //WindowsImpersonationContext wic = null;

                //wid_admin = new WindowsIdentity(admin_token);
                //wic = wid_admin.Impersonate();	    	

                string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + @"\" + archivo;
                if (impersonateValidUser(usuario, dominio, password))
                {
                    File.Copy(DirectorioLocal + @"\" + archivo, destino, true);
                }
                else
                {
                    sw.WriteLine(DateTime.Now.ToString() + " el usuario " + usuario + " no es valido");
                    error = false;
                }

            }
            catch (Exception ex)
            {

                try
                {


                    sw.WriteLine(DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + archivo + " " + ex.Message);
                    error = false;

                }
                catch (IOException) { }

            }


            sw.Close();

            if (error == false)
                return false;
            else
                return true;

        }

        public const int LOGON32_LOGON_INTERACTIVE = 2; public const int LOGON32_PROVIDER_DEFAULT = 0; WindowsImpersonationContext impersonationContext;
        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);


        private bool impersonateValidUser(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity; IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            if (RevertToSelf())
            {
                if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                {
                    if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                    {
                        tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                        impersonationContext = tempWindowsIdentity.Impersonate();
                        if (impersonationContext != null)
                        {
                            CloseHandle(token);
                            CloseHandle(tokenDuplicate);
                            return true;
                        }
                    }
                }
            }
            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);
            return false;
        }

        private void undoImpersonation()
        {
            impersonationContext.Undo();
        }
        
        public bool EnviarArchivos(ENKiosco kiosco, string Directorio, string DirectorioPrincipal, string usuario, string password, string dominio)
        {

            string rutaLog = ConfigurationManager.AppSettings["RutaLogErrores"].ToString();

            string[] todosLosArchivos = Directory.GetFiles(DirectorioPrincipal + Directorio);

            StreamWriter sw = new StreamWriter(rutaLog, true);

            bool error = true;

            foreach (string item in todosLosArchivos)
            {

                try
                {
                    string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + item.Replace(DirectorioPrincipal, "");
                    if (impersonateValidUser(usuario, dominio, password))
                    {
                        File.Copy(item, destino, true);
                    }
                    else
                    {//usuario incorrecto 
                        sw.WriteLine(DateTime.Now.ToString() + " el usuario " + usuario + " no es valido");
                        error = false;
                    }
                }
                catch (Exception ex)
                {
                    //no se pudo copiar
                    try
                    {


                        sw.WriteLine(DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + item.Replace(DirectorioPrincipal, " " + ex.Message));

                        error = false;

                    }
                    catch (IOException) { }

                }
            }

            sw.Close();

            if (error == false)
                return false;
            else
                return true;

        }
        
        public bool hacerLinea(string nomLinea)
        {

            try
            {
                string rutaLog = ConfigurationManager.AppSettings["RutaLogErrores"].ToString();
                StreamWriter sw = new StreamWriter(rutaLog, true);
                sw.WriteLine("----------------------" + nomLinea + "----------------------");
                sw.Close();
            }
            catch (IOException) { }

            return true;
        }
        
        private bool buscarEnLista(string cadena, List<string> listaBusqueda, string carpetaXML)
        {
            //listaBusqueda.Add(carpetaXML+@"\data.xml");

            foreach (string item in listaBusqueda)
            {
                if (item == cadena)
                    return true;
            }
            return false;

        }

        private string[] buscarArchivosEnDirectorio(string DirectorioBuscar)
        {
            string[] archivosJPG = Directory.GetFiles(DirectorioBuscar, "*.jpg");
            string[] archivosPNG = Directory.GetFiles(DirectorioBuscar, "*.png");

            List<string> ListaArchivos = new List<string>();

            foreach (string item in archivosJPG)
            {
                ListaArchivos.Add(item);
            }
            foreach (string item in archivosPNG)
            {
                ListaArchivos.Add(item);
            }

            return ListaArchivos.ToArray();
        }


        #region FLASH
        public bool hacerLineaLogPantalla(string nomLinea)
        {

            try
            {
                string rutaLog = ConfigurationManager.AppSettings["RutaLogPantalla"].ToString();
                StreamWriter sw = new StreamWriter(rutaLog, true);
                sw.WriteLine(nomLinea);
                sw.Close();
            }
            catch (IOException) { }

            return true;
        }
        public bool GenerarArchivosFlash(List<ENKiosco> kioscos, List<string> ArchivosEnviar, string Directorio, string DirectorioPrincipal)
        {
            try
            {
                string[] archivosGuardados = buscarArchivosFlashEnDirectorio(DirectorioPrincipal + Directorio);

                foreach (string archivoGuardado in archivosGuardados)
                {
                    if (buscarEnLista(archivoGuardado, ArchivosEnviar, "") == false)
                    {
                        File.Delete(archivoGuardado);
                    }
                }
                return true;
            }

            catch (Exception)
            {

            }
            return true;
        }

        private string[] buscarArchivosFlashEnDirectorio(string DirectorioBuscar)
        {
            string[] archivosSWF = Directory.GetFiles(DirectorioBuscar, "*.swf");

            List<string> ListaArchivos = new List<string>();

            foreach (string item in archivosSWF)
            {
                ListaArchivos.Add(item);
            }

            return ListaArchivos.ToArray();
        }

        public bool EnviarArchivosFlash(ENKiosco kiosco, string Directorio, string DirectorioPrincipal, string usuario, string password, string dominio,ref string textoLog,List<string> listaArchivos,string identificador)
        {             
            string slog = "";
            bool error = true;
            if (impersonateValidUser(usuario, dominio, password))
            {
                foreach (string item in listaArchivos)
                {
                    try
                    {
                        //string nombreTemp = string.Format("{0}{1}",Path.GetFileNameWithoutExtension(item),".temp");
                        string archivo = Path.GetFileName(item);

                        //string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + item.Replace(DirectorioPrincipal, "");
                        string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos+ @"\" + archivo;

                        File.Copy(item, destino, true);

                        textoLog = "    -Se ha copiado el archivo " + archivo + " a " + kiosco.IpKiosco;
                        EscribirLog(identificador, textoLog);
                        
                    }
                    catch (Exception ex)
                    {
                        //no se pudo copiar
                        try
                        {
                            slog = DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + Path.GetFileName(item) + " " + ex.Message;                            
                            EscribirLog(identificador, slog);
                            error = false;
                        }
                        catch (IOException) { }
                    }
                }
            }
            else
            {//usuario incorrecto 
                slog = DateTime.Now.ToString() + " el usuario " + usuario + " no es valido";                
                EscribirLog(identificador, slog);
                error = false;
            }

            if (error == false)
                return false;
            else
                return true;

        }

        public void EscribirLog(string identificador,string descripcion)
        {
            DataAccess.Instancia.Insert_LogRipleymatico(identificador, descripcion);
            hacerLineaLogPantalla(descripcion);
        }

        public List<string> ConsultarLog(string identificador, DateTime fecha)
        {
            try
            {
                return DataAccess.Instancia.Get_LogRipleymatico(identificador, fecha);
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
        #endregion
    }
}
