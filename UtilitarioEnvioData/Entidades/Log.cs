using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UtilitarioEnvioData.Entidades
{
    public static class Log
    {
        public static void EscribirLog(string texto)
        {
            try
            {
                string directorio = AppDomain.CurrentDomain.BaseDirectory + "Log";
                string archivo = directorio + "\\Log.txt";

                if (!Directory.Exists(directorio))
                    Directory.CreateDirectory(directorio);

                StreamWriter streamWriter = new StreamWriter(archivo, true);
                streamWriter.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " " + texto);
                streamWriter.Close();

            }
            catch (Exception ex)
            {

                EscribirLog(texto);
            }
        }
    }
}
