
Partial Class aspx_logout
    Inherits System.Web.UI.Page

    Protected Sub btniniciar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btniniciar.Click

        With Response
            .ExpiresAbsolute = DateAdd("yyyy", -1, DateTime.Now)
            .CacheControl = "Private"
            .Expires = 0
        End With

        'Redirect to unathorised user page
        Session.Abandon()

        With Response
            .Buffer = True
            .Clear()
            Response.Redirect("../default.aspx")
            .End()
        End With

    End Sub
End Class
