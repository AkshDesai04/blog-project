﻿Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Response.Cookies("LoggedInUser").Value.Length > 0 Then
                Response.Redirect("Blogs.aspx")
            End If
        Catch ex As Exception
            'MsgBox("Lol I caught it as: " + ex.ToString)
        End Try
    End Sub
    Protected Sub login_Click1(sender As Object, e As EventArgs) Handles login.Click
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub signup_Click(sender As Object, e As EventArgs) Handles signup.Click
        Response.Redirect("signup.aspx")
    End Sub
End Class