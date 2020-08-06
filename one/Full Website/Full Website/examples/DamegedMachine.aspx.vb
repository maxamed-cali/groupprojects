Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class DamegedMachine
    Inherits System.Web.UI.Page
    Dim name1 As New Dictionary(Of String, Integer)
    Dim name2 As New Dictionary(Of String, Integer)


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getdamged()

        'End If
        drop1()
        drop2()
    End Sub

    Private Sub drop2()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "Select Stname, Stid from ClientStudent"
            dr = cmd.ExecuteReader()
            While dr.Read = True
                If Not IsPostBack Then
                    txtestid.Items.Add(dr(0))
                End If
                name1.Add(dr(0), dr(1))

            End While
        End Using
    End Sub
    Private Sub drop1()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "Select mtype,mid from machines "
            dr = cmd.ExecuteReader()
            While dr.Read = True
                If Not IsPostBack Then
                    txteemid.Items.Add(dr(0))
                End If
                name2.Add(dr(0), dr(1))

            End While
        End Using
    End Sub

    Private Sub getdamged()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_damag"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            damaged.DataSource = Dt
            damaged.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txteemid.Text = "" Or txtdate.Text = "" Or txtestid.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_damagedmachines"
                With cmd.Parameters
                    .AddWithValue("@id", txtid.Text)
                    .AddWithValue("@mdid", name2.Item(txteemid.Text))
                    .AddWithValue("@datedamage", txtdate.Text)
                    .AddWithValue("@Stid", name1.Item(txtestid.Text))
                    .AddWithValue("@TYPE", "insert")


                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('date Are Sucessfull insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try
            End Using
            getdamged()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_damagedmachines"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@mdid", txteemid.Text)
                .AddWithValue("@datedamage", txtdate.Text)
                .AddWithValue("@Stid", txtestid.Text)
                .AddWithValue("@TYPE", "update")


            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('Date Are Sucessfull deleted') </script>")
        End Using
        getdamged()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_damagedmachines"
            With cmd.Parameters
                .AddWithValue("@id", txtid.Text)
                .AddWithValue("@mdid", txteemid.Text)
                .AddWithValue("@datedamage", txtdate.Text)
                .AddWithValue("@Stid", txtestid.Text)
                .AddWithValue("@TYPE", "delete")


            End With
            Try
                cmd.ExecuteNonQuery()
                Response.Write("<script>alert('Date Are Sucessfull deleted') </script>")

            Catch ex As Exception
                Response.Write("<script>alert(' not Allowed To Delet') </script>")

            End Try
        End Using
        getdamged()
    End Sub

    Protected Sub damaged_SelectedIndexChanged(sender As Object, e As EventArgs) Handles damaged.SelectedIndexChanged
        Dim row As GridViewRow = damaged.SelectedRow
        txtid.Text = row.Cells(1).Text
        txteemid.Text = row.Cells(2).Text
        txtdate.Text = row.Cells(3).Text
        txtestid.Text = row.Cells(4).Text

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtestid.Text = ""
        txteemid.Text = ""
        txtdate.Text = ""

    End Sub
End Class