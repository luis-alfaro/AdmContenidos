using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace UtilitarioEnvioData.GenerarXML
{
    public class EditarXML
    {

        public bool editarXml(ref List<string> listaArchivos, string Carpeta, string CarpetaPrincipal)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                string archivoData = CarpetaPrincipal + Carpeta + @"\data.xml";
                doc.Load(archivoData);

                XmlNode raiz = doc.GetElementsByTagName("item")[0];
                raiz.RemoveAll();
                //XmlNodeList listaNodos = raiz.ChildNodes;

                foreach (string archivo in listaArchivos)
                {
                    XmlNode nodoList = doc.CreateNode(XmlNodeType.Element, "list", "");

                    XmlNode nodoMainImage = doc.CreateNode(XmlNodeType.Element, "mainimage", "");

                    string valorNodo = archivo.Replace(CarpetaPrincipal, ".");
                    valorNodo = valorNodo.Replace(@"\", "/");

                    nodoMainImage.InnerText = valorNodo;

                    //a mainimage
                    nodoList.AppendChild(nodoMainImage);

                    //a list
                    raiz.AppendChild(nodoList);

                }
                doc.Save(archivoData);
                listaArchivos.Add(archivoData);

            }
            catch (Exception ex)
            {
                string error = ex.Message;

            }

            return true;
        }



    }
}
