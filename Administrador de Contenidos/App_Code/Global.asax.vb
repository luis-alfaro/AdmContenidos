Imports System

Imports System.Data

Imports System.Configuration

Imports System.Linq

Imports System.Web

Imports System.Web.Security

Imports System.Web.UI

Imports System.Web.UI.HtmlControls

Imports System.Web.UI.WebControls

Imports System.Web.UI.WebControls.WebParts

Imports System.Web.Routing

Imports System.Xml.Linq


Public Class _Global
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta al iniciarse la aplicación
        'Register the default hubs route: ~/signalr
        RouteTable.Routes.MapHubs()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta durante el cierre de aplicaciones
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta al producirse un error no controlado
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta cuando se inicia una nueva sesión
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Código que se ejecuta cuando finaliza una sesión. 
        ' Nota: El evento Session_End se desencadena sólo con el modo sessionstate
        ' se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
        ' o SQLServer, el evento no se genera.
    End Sub
End Class
