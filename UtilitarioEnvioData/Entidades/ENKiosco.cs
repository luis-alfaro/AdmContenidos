using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitarioEnvioData.Entidades
{
    public class ENKiosco
    {
        public string IpKiosco { get; set; }
        /// <summary>
        /// Ruta donde se guarda la aplicacion de RipleyMatico
        /// </summary>
        public string RutaPathArchivos { get; set; }

        public List<ENArchivo> Archivos { get; set; }
    }
}
