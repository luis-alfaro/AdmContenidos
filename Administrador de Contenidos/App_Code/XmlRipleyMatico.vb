Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.IO

Public Class XmlRipleyMatico



    Public Function CargarXML() As List(Of String)
        Dim docXml As New XmlDocument()
        docXml.LoadXml("\ahora_nunca\data.xml")

        Dim listaImagenes As New List(Of String)

        For Each item As XmlNode In docXml.ChildNodes

            listaImagenes.Add(item.Value.ToString())

        Next

        Return listaImagenes
    End Function

    Public Function GenerarXML(ByVal listaImages As List(Of String)) As Boolean

        Dim docXml As New XmlDocument()
        docXml.LoadXml("E:\ahora_nunca\data.xml")


        For Each item As String In listaImages

            Dim itemXML As XmlElement
            itemXML = docXml.CreateElement("mainimage")
            itemXML.Value = item

        Next

        Return True
    End Function

End Class
