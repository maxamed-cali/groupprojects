Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class company
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getcompany()
        'End If
    End Sub

    Private Sub getcompany()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Companys"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            comp.DataSource = Dt
            comp.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtname.Text = "" Or txtaddress.Text = "" Or txtEmail.Text = "" Or txtphone.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_company"
                With cmd.Parameters
                    .AddWithValue("@id", txtid.Text)
                    .AddWithValue("@magac", txtname.Text)
                    .AddWithValue("@magalo", txtaddress.Text)
                    .AddWithValue("@email", txtEmail.Text)
                    .AddWithValue("@number", txtphone.Text)
                    .AddWithValue("@TYPE", "insert")


                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('Date Are Sucessfull insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try
            End Using

            getcompany()
        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_company"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@magac", txtname.Text)
                .AddWithValue("@magalo", txtaddress.Text)
                .AddWithValue("@email", txtEmail.Text)
                .AddWithValue("@number", txtphone.Text)
                .AddWithValue("@TYPE", "delete")


            End With
            Try
                cmd.ExecuteNonQuery()
                Response.Write("<script>alert('Date Are Sucessfull deleted') </script>")

            Catch ex As Exception
                Response.Write("<script>alert(' not Allowed To Delet') </script>")

            End Try
        End Using

        getcompany()
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_company"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@magac", txtname.Text)
                .AddWithValue("@magalo", txtaddress.Text)
                .AddWithValue("@email", txtEmail.Text)
                .AddWithValue("@number", txtphone.Text)
                .AddWithValue("@TYPE", "update")


            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('Date Are Sucessfull update') </script>")
        End Using

        getcompany()

    End Sub

    Protected Sub comp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comp.SelectedIndexChanged
        Dim row As GridViewRow = comp.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtname.Text = row.Cells(2).Text
        txtphone.Text = row.Cells(3).Text
        txtaddress.Text = row.Cells(4).Text
        txtEmail.Text = row.Cells(5).Text
    End Sub

    Protected Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtname.Text = ""
        txtphone.Text = ""
        txtEmail.Text = ""
        txtaddress.Text = ""

    End Sub
End Class