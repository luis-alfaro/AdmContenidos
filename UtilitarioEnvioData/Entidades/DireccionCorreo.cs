using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitarioEnvioData.Entidades
{
    public class DireccionCorreo
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public int Puerto { get; set; }
        public bool Remitente { get; set; }
    }
}
