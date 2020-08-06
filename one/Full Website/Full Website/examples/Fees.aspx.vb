Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class Fees
    Inherits System.Web.UI.Page
    Dim stname As New Dictionary(Of String, Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getsaler()

        'End If
        drops()
    End Sub

    Private Sub drops()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "select Stname,Stid from ClientStudent"
            dr = cmd.ExecuteReader()
            While dr.Read = True
                If Not IsPostBack Then
                    txtemptys.Items.Add(dr(0))
                End If
                stname.Add(dr(0), dr(1))

            End While

        End Using
    End Sub

    Private Sub getsaler()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_paymens"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            gsal.DataSource = Dt
            gsal.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtamo.Text = "" Or txtblance.Text = "" Or txtdate.Text = "" Or txtemptys.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_payment"
                With cmd.Parameters
                    .AddWithValue("@pid", txtid.Text)
                    .AddWithValue("@Pamount", txtamo.Text)
                    .AddWithValue("@Pbalance", txtblance.Text)
                    .AddWithValue("@Pdate", txtdate.Text)
                    .AddWithValue("@Stid", stname.Item(txtemptys.Text))
                    .AddWithValue("@TYPE", "insert")


                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('date Are Sucessfull insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try
            End Using

            getsaler()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_payment"
            With cmd.Parameters
                .AddWithValue("@pid", txtid.Text)
                .AddWithValue("@Pamount", txtamo.Text)
                .AddWithValue("@Pbalance", txtblance.Text)
                .AddWithValue("@Pdate", txtdate.Text)
                .AddWithValue("@Stid", txtemptys.Text)
                .AddWithValue("@TYPE", "update")


            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('date Are Sucessfull Update') </script>")
        End Using

        getsaler()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_payment"
            With cmd.Parameters
                .AddWithValue("@pid", txtid.Text)
                .AddWithValue("@Pamount", txtamo.Text)
                .AddWithValue("@Pbalance", txtblance.Text)
                .AddWithValue("@Pdate", txtdate.Text)
                .AddWithValue("@Stid", txtemptys.Text)
                .AddWithValue("@TYPE", "Delete")


            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('date Are Sucessfull Update') </script>")
        End Using

        getsaler()
    End Sub

    Protected Sub gsal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gsal.SelectedIndexChanged
        Dim row As GridViewRow = gsal.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtamo.Text = row.Cells(2).Text
        txtblance.Text = row.Cells(3).Text
        txtdate.Text = row.Cells(4).Text
        txtemptys.Text = row.Cells(5).Text
    End Sub

    Protected Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtamo.Text = ""
        txtblance.Text = ""
        txtdate.Text = ""
        txtemptys.Text = ""
        txtid.Text = ""

    End Sub
End Class