Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class User
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getmachine()

        'End If
    End Sub

    Private Sub getmachine()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Users"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            GridView1.DataSource = Dt
            GridView1.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or txtusertype.Text = "" Or txtstu.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_User"
                With cmd.Parameters
                    .AddWithValue("@id", txtid.Text)
                    .AddWithValue("@magac", txtuser.Text)
                    .AddWithValue("@sirt", txtpass.Text)
                    .AddWithValue("@nuuca", txtusertype.Text)
                    .AddWithValue("@xalada", txtstu.Text)
                    .AddWithValue("@TYPE", "insert")

                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('That Are insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try

            End Using
            getmachine()

        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtuser.Text = row.Cells(2).Text
        txtpass.Text = row.Cells(3).Text
        txtusertype.Text = row.Cells(4).Text
        txtstu.Text = row.Cells(5).Text
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtid.Text = "" Or txtuser.Text = "" Or txtpass.Text = "" Or txtusertype.Text = "" Or txtstu.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_User"
                With cmd.Parameters
                    .AddWithValue("@id", txtid.Text)
                    .AddWithValue("@magac", txtuser.Text)
                    .AddWithValue("@sirt", txtpass.Text)
                    .AddWithValue("@nuuca", txtusertype.Text)
                    .AddWithValue("@xalada", txtstu.Text)
                    .AddWithValue("@TYPE", "update")

                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('That Are updated') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try

            End Using
            getmachine()

        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_User"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@magac", txtuser.Text)
                .AddWithValue("@sirt", txtpass.Text)
                .AddWithValue("@nuuca", txtusertype.Text)
                .AddWithValue("@xalada", txtstu.Text)
                .AddWithValue("@TYPE", "delete")

            End With
            Try
                cmd.ExecuteNonQuery()
                Response.Write("<script>alert('Date Are Sucessfull deleted') </script>")

            Catch ex As Exception
                Response.Write("<script>alert(' not Allowed To Delet') </script>")


            End Try
            getmachine()
        End Using


    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtpass.Text = ""
        txtstu.Text = ""
        txtuser.Text = ""
        txtusertype.Text = ""
    End Sub
End Class