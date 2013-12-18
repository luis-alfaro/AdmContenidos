using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UtilitarioEnvioData.EnvioData
{
    public class UtilitarioVideos
    {

        public string[] Get_videos(string RutaVideos) 
        {
            if (!Directory.Exists(RutaVideos))
                return null;

            string[] videos = Directory.GetFiles(RutaVideos);

            return videos;
        }

        public bool Delete_video(string RutaArchivo) 
        {
            if (!File.Exists(RutaArchivo))
                return false;

            File.Delete(RutaArchivo);
            return true;
        }
    }
}
