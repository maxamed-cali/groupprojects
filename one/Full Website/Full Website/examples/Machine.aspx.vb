Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class Machine
    Inherits System.Web.UI.Page
    Dim Alls As New Dictionary(Of String, Integer)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getmachine()

        'End If
        drop()
    End Sub

    Private Sub drop()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "select Cname, comid from Company "
            dr = cmd.ExecuteReader()
            While dr.Read = True
                If Not IsPostBack Then
                    txtemptype.Items.Add(dr(0))
                End If
                Alls.Add(dr(0), dr(1))

            End While

        End Using
    End Sub

    Private Sub getmachine()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_machinese"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            GridView1.DataSource = Dt
            GridView1.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtname.Text = "" Or txtamount.Text = "" Or txtmdate.Text = "" Or txtemptype.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_machines"
            With cmd.Parameters
                .AddWithValue("@mid", txtid.Text)
                .AddWithValue("@mtype", txtname.Text)
                .AddWithValue("@Amount", txtamount.Text)
                .AddWithValue("@Mdate", txtmdate.Text)
                    .AddWithValue("@comid", Alls.Item(txtemptype.Text))
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

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If txtid.Text = "" And txtname.Text = "" And txtamount.Text = "" And txtmdate.Text = "" And txtemptype.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_machines"
                With cmd.Parameters
                    .AddWithValue("@mid", txtid.Text)
                    .AddWithValue("@mtype", txtname.Text)
                    .AddWithValue("@Amount", txtamount.Text)
                    .AddWithValue("@Mdate", txtmdate.Text)
                    .AddWithValue("@comid", txtemptype.Text)
                    .AddWithValue("@TYPE", "UPDATE")

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
        txtname.Text = row.Cells(2).Text
        txtamount.Text = row.Cells(3).Text
        txtmdate.Text = row.Cells(4).Text
        txtemptype.Text = row.Cells(5).Text

    End Sub

    Protected Sub btndel_Click(sender As Object, e As EventArgs) Handles btndel.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_machines"
            With cmd.Parameters
                .AddWithValue("@mid", txtid.Text)
                .AddWithValue("@mtype", txtname.Text)
                .AddWithValue("@Amount", txtamount.Text)
                .AddWithValue("@Mdate", txtmdate.Text)
                .AddWithValue("@comid", txtemptype.Text)
                .AddWithValue("@TYPE", "Delete")

            End With
            cmd.ExecuteNonQuery()
        End Using

        getmachine()
    End Sub

    Protected Sub txtmdate_TextChanged(sender As Object, e As EventArgs) Handles txtmdate.TextChanged

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtamount.Text = ""
        txtemptype.Text = ""
        txtid.Text = ""
        txtmdate.Text = ""
        txtname.Text = ""
    End Sub
End Class