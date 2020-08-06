Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Session("islogin") = False
        'End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Using con As SqlConnection = connect()
        '    If txtuser.Text = "" Then
        '        Response.Write("<script>alert('please Enter UserName')</script>")
        '    ElseIf txtpass.Text = "" Then
        '        Response.Write("<script>alert('please Enter password')</script>")
        '    Else
        '        cmd.Connection = con
        '        cmd = New SqlCommand("Select * from Users where UserName=@UserName and Passowrd=@Password", con)
        '        cmd.Parameters.AddWithValue("@UserName", txtuser.Text)
        '        cmd.Parameters.AddWithValue("@Password", txtpass.Text)
        '        Dim dr As SqlDataReader = cmd.ExecuteReader
        '        If dr.Read Then
        '            Session("islogin") = True
        '            Response.Redirect("~\examples\dashboard.aspx")
        '        Else
        '            Response.Write("<script>alert('Username  OR password Are inncuret')</script>")
        '        End If

        '    End If







        'End Using


    End Sub
End Class