using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitarioEnvioData.Entidades
{
    public class EmailFile
    {
        public string url { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
        public string nombreCompleto { get; set; }
        public double tamanio { get; set; }
    }
}
