Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class Salary
    Inherits System.Web.UI.Page
    Dim names As New Dictionary(Of String, Integer)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    Session("islogin") = False
        '        Response.Redirect("~/login.aspx")

        getsalary()

        'End If
        drops()
    End Sub

    Private Sub drops()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "Select Emname, Emid from Employees"
            dr = cmd.ExecuteReader()
            While dr.Read = True
                If Not IsPostBack Then
                    txtempty.Items.Add(dr(0))
                End If
                names.Add(dr(0), dr(1))

            End While

        End Using
    End Sub

    Private Sub getsalary()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_sale"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            smp.DataSource = Dt
            smp.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtsal.Text = "" Or txtam.Text = "" Or txtdat.Text = "" Or txtempty.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else
            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_salary"
                With cmd.Parameters
                    .AddWithValue("@Sid", txtid.Text)
                    .AddWithValue("@stype", txtsal.Text)
                    .AddWithValue("@Amount", txtam.Text)
                    .AddWithValue("@Mdate", txtdat.Text)
                    .AddWithValue("@comid", names.Item(txtempty.Text))
                    .AddWithValue("@TYPE", "insert")

                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('date Are Sucessfull insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try
            End Using

            getsalary()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_salary"
            With cmd.Parameters
                .AddWithValue("@Sid", txtid.Text)
                .AddWithValue("@stype", txtsal.Text)
                .AddWithValue("@Amount", txtam.Text)
                .AddWithValue("@Mdate", txtdat.Text)
                .AddWithValue("@comid", txtempty.Text)
                .AddWithValue("@TYPE", "UPDATE")

            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('date Are Sucessfull updated') </script>")
        End Using

        getsalary()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_salary"
            With cmd.Parameters
                .AddWithValue("@Sid", txtid.Text)
                .AddWithValue("@stype", txtsal.Text)
                .AddWithValue("@Amount", txtam.Text)
                .AddWithValue("@Mdate", txtdat.Text)
                .AddWithValue("@comid", txtempty.Text)
                .AddWithValue("@TYPE", "delete")

            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('date Are Sucessfull Delete') </script>")



        End Using

        getsalary()

    End Sub

    Protected Sub smp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles smp.SelectedIndexChanged
        Dim row As GridViewRow = smp.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtsal.Text = row.Cells(2).Text
        txtam.Text = row.Cells(3).Text
        txtdat.Text = row.Cells(4).Text
        txtempty.Text = row.Cells(5).Text
    End Sub

    Protected Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged

    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtsal.Text = ""
        txtempty.Text = ""
        txtdat.Text = ""
        txtam.Text = ""

    End Sub
End Class