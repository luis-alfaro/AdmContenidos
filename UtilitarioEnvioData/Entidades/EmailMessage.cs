using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilitarioEnvioData.Entidades
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<EmailFile> FileAttach { get; set; }
    }
}
