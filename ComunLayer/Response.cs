
namespace ComunLayer
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public class Response
    {
        public bool Success { get; set; }
        public bool Warning { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
