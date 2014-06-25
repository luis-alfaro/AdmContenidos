using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
        const string ActualizacionFlash = "F";
        const string ActualizacionImagenes = "I";
        const string ActualizacionPrograma = "P";
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

        public bool GenerarArchivos(List<ENKiosco> kioscos,ref  List<string> ArchivosEnviar, string Directorio, string DirectorioPrincipal)
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
                objXml.editarXml(ref ArchivosEnviar, Directorio, DirectorioPrincipal);
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

        public bool EnviarArchivos(ENKiosco kiosco, string Directorio, string DirectorioPrincipal, string usuario, string password, string dominio, ref string textoLog, List<string> listaArchivos, string identificador)
        {
            string slog = "";
            bool error = true;
            List<string> listaReintento = new List<string>();
            if (impersonateValidUser(usuario, dominio, password))
            {
                foreach (string item in listaArchivos)
                {
                    try
                    {

                        string archivo = Path.GetFileName(item);

                        string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + item.Replace(DirectorioPrincipal, "");
                        //string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + @"\" + archivo;

                        File.Copy(item, destino, true);

                        textoLog = "    -Se ha copiado el archivo " + archivo + " a " + kiosco.IpKiosco;
                        EscribirLog(identificador, textoLog, ActualizacionImagenes);

                    }
                    catch (Exception ex)
                    {
                        //no se pudo copiar
                        try
                        {
                            listaReintento.Add(item);
                            slog = DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + Path.GetFileName(item) + " " + ex.Message;
                            EscribirLog(identificador, slog, ActualizacionImagenes);
                            error = false;
                        }
                        catch (IOException) { }
                    }
                }
            }
            else
            {//usuario incorrecto 
                slog = DateTime.Now.ToString() + " el usuario " + usuario + " no es valido";
                EscribirLog(identificador, slog, ActualizacionImagenes);
                error = false;
            }

            if (error == false)
            {
                error = ReintentarEnvio(kiosco, Directorio, DirectorioPrincipal, usuario, password, dominio, textoLog, listaReintento, identificador, ActualizacionImagenes);                
                return error;
            }
            else
                return true;

        }

        public bool ReintentarEnvio(ENKiosco kiosco, string Directorio, string DirectorioPrincipal, string usuario, string password, string dominio, string textoLog, List<string> listaReintento, string identificador,string actualizacion)
        {
            string slog = "";
            int count = listaReintento.Count;
            if (impersonateValidUser(usuario, dominio, password))
            {
                if (listaReintento.Count > 0)
                {
                    foreach (string item in listaReintento)
                    {
                        try
                        {

                            string archivo = Path.GetFileName(item);

                            string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + item.Replace(DirectorioPrincipal, "");
                            //string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + @"\" + archivo;

                            File.Copy(item, destino, true);

                            textoLog = "    -Reintento exitoso - se ha copiado el archivo " + archivo + " a " + kiosco.IpKiosco;
                            EscribirLog(identificador, textoLog, actualizacion);
                            count--;
                        }
                        catch (Exception ex)
                        {
                            //no se pudo copiar
                            try
                            {
                                listaReintento.Add(item);
                                slog = DateTime.Now.ToString() + " Reintento fallido - " + kiosco.IpKiosco + " " + Path.GetFileName(item) + " " + ex.Message;
                                EscribirLog(identificador, slog, actualizacion);
                            }
                            catch (IOException) { }
                        }
                    }
                }
            }
            else {
                return false;
            }
            if (count == 0)
                return true;
            else
                return false;
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

            List<string> listaReintento = new List<string>();
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
                        EscribirLog(identificador, textoLog,ActualizacionFlash);
                        
                    }
                    catch (Exception ex)
                    {
                        //no se pudo copiar
                        try
                        {
                            listaReintento.Add(item);
                            slog = DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + Path.GetFileName(item) + " " + ex.Message;                            
                            EscribirLog(identificador, slog,ActualizacionFlash);
                            error = false;
                        }
                        catch (IOException) { }
                    }
                }
            }
            else
            {//usuario incorrecto 
                slog = DateTime.Now.ToString() + " el usuario " + usuario + " no es valido";                
                EscribirLog(identificador, slog,ActualizacionFlash);
                error = false;
            }

            if (error == false)
            {
                error = ReintentarEnvio(kiosco, Directorio, DirectorioPrincipal, usuario, password, dominio, textoLog, listaReintento, identificador, ActualizacionFlash);
                return error;
            }
            else
                return true;

        }
        
        #endregion

        public bool hacerLineaLogPantalla(string nomLinea,string tipo)
        {
            try
            {
                string rutaLog = "";
                switch (tipo)
                {
                    case ActualizacionFlash:
                        rutaLog = ConfigurationManager.AppSettings["RutaLogPantalla"].ToString();
                        break;
                    case ActualizacionImagenes:
                        rutaLog = ConfigurationManager.AppSettings["RutaLogErrores"].ToString();
                        break;
                    case "P":
                        return true;                        
                    default:
                        break;
                }
                StreamWriter sw = new StreamWriter(rutaLog, true);
                sw.WriteLine(nomLinea);
                sw.Close();
            }
            catch (IOException) { }

            return true;
        }

        public void EscribirLog(string identificador,string descripcion,string tipo)
        {
            try
            {
                DataAccess.Instancia.Insert_LogRipleymatico(identificador, descripcion,tipo);
                hacerLineaLogPantalla(descripcion,tipo);
            }
            catch (Exception ex)
            {
                hacerLineaLogPantalla(ex.Message + " " + descripcion+" _ " + ex.InnerException.Message, tipo);
                
            }
            
        }

        public List<string> ConsultarLog(string identificador, string tipo)
        {
            try
            {
                return DataAccess.Instancia.Get_LogRipleymatico(identificador, tipo);
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        #region Programa
        private bool buscarEnListaPrograma(string cadena, List<string> listaBusqueda, string carpetaXML)
        {
            //listaBusqueda.Add(carpetaXML+@"\data.xml");

            foreach (string item in listaBusqueda)
            {
                if (Path.GetFileName(item) == Path.GetFileName(cadena))
                    return true;
            }
            return false;

        }
        private List<string> buscarArchivosProgramaEnDirectorio(string DirectorioBuscar)
        {
            string[] archivos = Directory.GetFiles(DirectorioBuscar);

            List<string> ListaArchivos = new List<string>();

            foreach (string item in archivos)
            {
                ListaArchivos.Add(item);
            }

            return ListaArchivos;
        }

        public Int32 GenerarArchivosPrograma(List<ENKiosco> kioscos, string ruta, string Directorio, string DirectorioPrincipal)
        {
            try
            {
                List<string> lista = buscarArchivosProgramaEnDirectorio(ruta);


                List<string> archivosGuardados = buscarArchivosProgramaEnDirectorio(DirectorioPrincipal + Directorio);

                foreach (string archivoGuardado in archivosGuardados)
                {
                    if (buscarEnListaPrograma(archivoGuardado, lista, "") == false)
                    {
                        File.Delete(archivoGuardado);
                    }
                }
                return lista.Count;
            }

            catch (Exception)
            {
                return 0;
            }
        }

        public bool EnviarArchivosPrograma(ENKiosco kiosco, string Directorio, string DirectorioPrincipal, string usuario, string password, string dominio, ref string textoLog, string ruta, string identificador)
        {
            string slog = "";
            bool error = true;
            List<String> listaArchivos = buscarArchivosProgramaEnDirectorio(ruta);
            List<String> listaReintento = new List<String>();
            string carpetaDestino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos;
            if (!Directory.Exists(carpetaDestino))
            {
                Directory.CreateDirectory(carpetaDestino);
            }

            if (impersonateValidUser(usuario, dominio, password))
            {
                foreach (string item in listaArchivos)
                {
                    try
                    {
                        //string nombreTemp = string.Format("{0}{1}",Path.GetFileNameWithoutExtension(item),".temp");
                        string archivo = Path.GetFileName(item);

                        //string destino = @"\\" + kiosco.IpKiosco + kiosco.RutaPathArchivos + item.Replace(DirectorioPrincipal, "");
                        string destino = carpetaDestino + @"\" + archivo;

                        File.Copy(item, destino, true);

                        textoLog = "    -Se ha copiado el archivo " + archivo + " a " + kiosco.IpKiosco;
                        EscribirLog(identificador, textoLog, ActualizacionPrograma);

                    }
                    catch (Exception ex)
                    {
                        //no se pudo copiar
                        try
                        {
                            listaReintento.Add(item);
                            slog = DateTime.Now.ToString() + " " + kiosco.IpKiosco + " " + Path.GetFileName(item) + " " + ex.Message;
                            EscribirLog(identificador, slog, ActualizacionPrograma);
                            error = false;
                        }
                        catch (IOException) { }
                    }
                }
            }
            else
            {//usuario incorrecto 
                slog = DateTime.Now.ToString() + " el usuario " + usuario + " no es valido";
                EscribirLog(identificador, slog, ActualizacionPrograma);
                error = false;
            }

            if (error == false)
            {
                error = ReintentarEnvio(kiosco, Directorio, DirectorioPrincipal, usuario, password, dominio, textoLog, listaReintento, identificador, ActualizacionPrograma);
                return error;
            }
            else
                return true;

        }

        public DataSet GET_ESTADISTICA_ACEPTACION_SEF(string fini, string ffin,string tipo)
        {
            DataSet ds = new DataSet();
            string titulo1 = "";
            try
            {
                DataTable dt = new DataTable("consulta");
                

                var lista = DataAccess.Instancia.GET_ESTADISTICA_ACEPTACION_SEF(fini, ffin);

                if (tipo == "1")//Por Fecha
                { 
                    titulo1 = "Fecha"; 
                }
                else 
                { 
                    titulo1 = "Mes"; 
                }

                dt.Columns.Add(new DataColumn(titulo1, typeof(string)));
                dt.Columns.Add(new DataColumn("Cant.", typeof(int)));//C
                dt.Columns.Add(new DataColumn("Monto Ofrecido", typeof(decimal)));//C
                dt.Columns.Add(new DataColumn("Monto Desemb.", typeof(decimal)));//C

                dt.Columns.Add(new DataColumn("Cant. ", typeof(int)));//R
                dt.Columns.Add(new DataColumn("Monto Ofrecido ", typeof(decimal)));//R
                dt.Columns.Add(new DataColumn("Monto Desemb. ", typeof(decimal)));//R

                dt.Columns.Add(new DataColumn("Cant.  ", typeof(int)));//OTRO
                dt.Columns.Add(new DataColumn("Monto Ofrecido  ", typeof(decimal)));//OTRO
                dt.Columns.Add(new DataColumn("Monto Desemb.  ", typeof(decimal)));//OTRO

                dt.Columns.Add(new DataColumn(" Cant. ", typeof(int)));//total
                dt.Columns.Add(new DataColumn(" Monto Ofrecido ", typeof(decimal)));//total
                dt.Columns.Add(new DataColumn(" Monto Desemb. ", typeof(decimal)));//total

                if (tipo == "1")//Por Fecha
                {
                    
                    var distinct = lista.Select(m => m.O_FEC_CLIE_FIN).Distinct().ToList();

                    var otralista = (from extracted in (from p in distinct
                                                    select new {item = p,  
                                                        p = DateTime.Parse(p)}) 
                                 orderby extracted.p 
                                     select extracted.item).ToList();

                    foreach (var item in otralista)
                    {
                        var valor1 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").ToList().Count;
                        var valor2 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").Sum(m => m.O_DATO_NUM2);
                        var valor3 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").Sum(m => m.O_DATO_NUM6);
                        var valor4 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").ToList().Count;
                        var valor5 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").Sum(m => m.O_DATO_NUM2);
                        var valor6 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").Sum(m => m.O_DATO_NUM6);
                        var valor7 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).ToList().Count;
                        var valor8 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).Sum(m => m.O_DATO_NUM2);
                        var valor9 = lista.Where(m => m.O_FEC_CLIE_FIN == item && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).Sum(m => m.O_DATO_NUM6);

                        DataRow dr = dt.NewRow();
                        dr["Fecha"] = item;
                        dr["Cant."] = valor1;
                        dr["Monto Ofrecido"] = valor2;
                        dr["Monto Desemb."] = valor3;

                        dr["Cant. "] = valor4;
                        dr["Monto Ofrecido "] = valor5;
                        dr["Monto Desemb. "] = valor6;

                        dr["Cant.  "] = valor7;
                        dr["Monto Ofrecido  "] = valor8;
                        dr["Monto Desemb.  "] = valor9;

                        dr[" Cant. "] = valor1 + valor4 + valor7;
                        dr[" Monto Ofrecido "] = valor2 + valor5 + valor8;
                        dr[" Monto Desemb. "] = valor3 + valor6 + valor9;
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);
                }
                else //Por Mes
                {
                    
                    var distincto = lista.Select(m => new { m.O_MONTH, m.O_YEAR,m.O_FEC_CLIE_FIN,m.O_MES}).Distinct().ToList();
                    var otralista = (from extracted in
                                     (from p in distincto
                                      select new
                                      {
                                          item = p,
                                          p = DateTime.Parse(p.O_FEC_CLIE_FIN)
                                      }) 
                                 orderby extracted.item.O_YEAR,extracted.item.O_MONTH
                                 select extracted.item).ToList();

                    foreach (var item in otralista)
                    {
                        var valor1 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").ToList().Count;
                        var valor2 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").Sum(m => m.O_DATO_NUM2);
                        var valor3 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "C").Sum(m => m.O_DATO_NUM6);
                        var valor4 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").ToList().Count;
                        var valor5 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").Sum(m => m.O_DATO_NUM2);
                        var valor6 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && m.O_TIP_IMP_TCK == "R").Sum(m => m.O_DATO_NUM6);
                        var valor7 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).ToList().Count;
                        var valor8 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).Sum(m => m.O_DATO_NUM2);
                        var valor9 = lista.Where(m => m.O_MONTH == item.O_MONTH && m.O_YEAR == item.O_YEAR && m.O_ESTADO == "D" && string.IsNullOrEmpty(m.O_TIP_IMP_TCK)).Sum(m => m.O_DATO_NUM6);

                        DataRow dr = dt.NewRow();
                        dr["Mes"] = item.O_MES + "-" + item.O_YEAR.ToString();
                        dr["Cant."] = valor1;
                        dr["Monto Ofrecido"] = valor2;
                        dr["Monto Desemb."] = valor3;

                        dr["Cant. "] = valor4;
                        dr["Monto Ofrecido "] = valor5;
                        dr["Monto Desemb. "] = valor6;

                        dr["Cant.  "] = valor7;
                        dr["Monto Ofrecido  "] = valor8;
                        dr["Monto Desemb.  "] = valor9;

                        dr[" Cant. "] = valor1 + valor4 + valor7;
                        dr[" Monto Ofrecido "] = valor2 + valor5 + valor8;
                        dr[" Monto Desemb. "] = valor3 + valor6 + valor9;
                        dt.Rows.Add(dr);
                    }
                    ds.Tables.Add(dt);

                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return ds;
        }

        public string PRUEBA_CONEXION_ORA()
        {
            try
            {
                return DataAccess.Instancia.PRUEBA_CONEXION_ORA();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        #endregion
    }
}
