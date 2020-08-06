Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class ClientStudent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Session("islogin") = False
        '    Response.Redirect("~/login.aspx")
        'End If
        getclint()
    End Sub

    Private Sub getclint()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Client"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            GridView1.DataSource = Dt
            GridView1.DataBind()
        End Using
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtname.Text = row.Cells(2).Text
        txtphone.Text = row.Cells(3).Text
        txtEmail.Text = row.Cells(4).Text
        txtaddress.Text = row.Cells(5).Text
        txtbody.Text = row.Cells(6).Text
        txtstart.Text = row.Cells(7).Text
        txtend.Text = row.Cells(8).Text
        txth.Text = row.Cells(9).Text
        txtwe.Text = row.Cells(10).Text
        txtgen.Text = row.Cells(11).Text
        txtdate.Text = row.Cells(12).Text
    End Sub



    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtname.Text = "" Or txtphone.Text = "" Or txtEmail.Text = "" Or txtaddress.Text = "" Or txtbody.Text = "" Or txtstart.Text = "" Or txth.Text = "" Or txtwe.Text = "" Or txtgen.Text = "" Or txtdate.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else

            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_studentClient"
                With cmd.Parameters
                    .AddWithValue("@id", txtid.Text)
                    .AddWithValue("@name", txtname.Text)
                    .AddWithValue("@phone", txtphone.Text)
                    .AddWithValue("@email", txtEmail.Text)
                    .AddWithValue("@address", txtaddress.Text)
                    .AddWithValue("@podypart", txtbody.Text)
                    .AddWithValue("@startime", txtstart.Text)
                    .AddWithValue("@entime", txtend.Text)
                    .AddWithValue("@height", txth.Text)
                    .AddWithValue("@weight", txtwe.Text)
                    .AddWithValue("@gender", txtgen.Text)
                    .AddWithValue("@dateregiste", txtdate.Text)

                    .AddWithValue("@TYPE", "insert")
                End With
                Try
                        cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('date Are Sucessfull insert') </script>")

                Catch ex As Exception
                        Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                    End Try

            End Using

            getclint()
        End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_studentClient"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@name", txtname.Text)
                .AddWithValue("@phone", txtphone.Text)
                .AddWithValue("@email", txtEmail.Text)
                .AddWithValue("@address", txtaddress.Text)
                .AddWithValue("@podypart", txtbody.Text)
                .AddWithValue("@startime", txtstart.Text)
                .AddWithValue("@entime", txtend.Text)
                .AddWithValue("@height", txth.Text)
                .AddWithValue("@weight", txtwe.Text)
                .AddWithValue("@gender", txtgen.Text)
                .AddWithValue("@dateregiste", txtdate.Text)

                .AddWithValue("@TYPE", "update")

            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('Date Sucessfull updated') </script>")
        End Using

        getclint()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_studentClient"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@name", txtname.Text)
                .AddWithValue("@phone", txtphone.Text)
                .AddWithValue("@email", txtEmail.Text)
                .AddWithValue("@address", txtaddress.Text)
                .AddWithValue("@podypart", txtbody.Text)
                .AddWithValue("@startime", txtstart.Text)
                .AddWithValue("@entime", txtend.Text)
                .AddWithValue("@height", txth.Text)
                .AddWithValue("@weight", txtwe.Text)
                .AddWithValue("@gender", txtgen.Text)
                .AddWithValue("@dateregiste", txtdate.Text)

                .AddWithValue("@TYPE", "delete")

            End With
            Try
                cmd.ExecuteNonQuery()
                Response.Write("<script>alert('Date Are Sucessfull deleted') </script>")

            Catch ex As Exception
                Response.Write("<script>alert(' not Allowed To Delet') </script>")

            End Try
        End Using

        getclint()
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtname.Text = ""
        txtphone.Text = ""
        txtEmail.Text = ""
        txtaddress.Text = ""
        txtbody.Text = ""
        txtstart.Text = ""
        txtend.Text = ""
        txth.Text = ""
        txtwe.Text = ""
        txtgen.Text = ""
        txtdate.Text = ""
    End Sub
End Class