﻿Imports System.Data.SqlClient

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection
        con.ConnectionString = "Data Source=CRUNCHER;Initial Catalog=Pract24;User ID=sa;Password=123456"
        con.Open()

        Dim ad As New SqlDataAdapter("select * from Auth where UserID='" & TextBox1.Text & "'", con)
        Dim ds As New DataSet
        ad.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Dim sql As String = "select Pass from Auth where UserID = '" & TextBox1.Text & "'"
            Dim cmd As New SqlCommand(sql, con)
            Dim DB_Pass As String = Convert.ToString(cmd.ExecuteScalar)
            If TextBox2.Text.Equals(DB_Pass) Then
                'Code If Password is corrent
                If CheckBox1.Checked = True Then
                    'Code If Remember Me is selected
                    'Creating Cookie
                    Response.Cookies("LoggedInUser").Value = TextBox1.Text
                Else
                    'Code If Remember Me is not selected
                    Response.Cookies("LoggedInUser").Expires = DateTime.Now
                    Session("LoggedInUser") = TextBox1.Text
                End If
                Response.Redirect("Blogs.aspx")
            Else
                'Code If Password is incorrect
                MsgBox("Invalid ID or Password. Please try again")
            End If
        Else
            MsgBox("User Not Found")
        End If
        con.Close()
    End Sub
End Class