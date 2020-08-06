Imports System.Data.SqlClient
Imports Full_Website.Main

Public Class Employee

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Session("islogin") = False
        '    Response.Redirect("~/login.aspx")

        getemplo()
        'End If
    End Sub

    Private Sub getemplo()
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Employee"
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            emp.DataSource = Dt
            emp.DataBind()
        End Using
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtid.Text = "" Or txtname.Text = "" Or txtaddrs.Text = "" Or txtphone.Text = "" Or txtegender.Text = "" Or txtdayofwork.Text = "" Or txthour.Text = "" Or txtemptype.Text = "" Then


            Response.Write("<script>alert(' All filds Are required') </script>")

        Else

            Using con As SqlConnection = connect()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_Employees"
                With cmd.Parameters
                    .AddWithValue("@Emid", txtid.Text)
                    .AddWithValue("@Emname", txtname.Text)
                    .AddWithValue("@EmEmail", TxtEmail.Text)
                    .AddWithValue("@Eaddress", txtaddrs.Text)
                    .AddWithValue("@Empphone", txtphone.Text)
                    .AddWithValue("@Empgender", txtegender.Text)
                    .AddWithValue("@Edaysofwork", txtdayofwork.Text)
                    .AddWithValue("@Hoursworked", txthour.Text)
                    .AddWithValue("@Emtype", txtemptype.Text)
                    .AddWithValue("@TYPE", "insert")

                End With
                Try
                    cmd.ExecuteNonQuery()
                    Response.Write("<script>alert('Data Are Sucessfull insert') </script>")

                Catch ex As Exception
                    Response.Write("<script>alert('Dublicte are not Allowed') </script>")

                End Try
            End Using

            getemplo()
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Employees"
            With cmd.Parameters
                .AddWithValue("@Emid", txtid.Text)
                .AddWithValue("@Emname", txtname.Text)
                .AddWithValue("@EmEmail", TxtEmail.Text)
                .AddWithValue("@Eaddress", txtaddrs.Text)
                .AddWithValue("@Empphone", txtphone.Text)
                .AddWithValue("@Empgender", txtegender.Text)
                .AddWithValue("@Edaysofwork", txtdayofwork.Text)
                .AddWithValue("@Hoursworked", txthour.Text)
                .AddWithValue("@Emtype", txtemptype.Text)
                .AddWithValue("@TYPE", "update")

            End With
            cmd.ExecuteNonQuery()
            Response.Write("<script>alert('Data Are Sucessfull update') </script>")
        End Using

        getemplo()

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using con As SqlConnection = connect()
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Employees"
            With cmd.Parameters
                .AddWithValue("@Emid", txtid.Text)
                .AddWithValue("@Emname", txtname.Text)
                .AddWithValue("@EmEmail", TxtEmail.Text)
                .AddWithValue("@Eaddress", txtaddrs.Text)
                .AddWithValue("@Empphone", txtphone.Text)
                .AddWithValue("@Empgender", txtegender.Text)
                .AddWithValue("@Edaysofwork", txtdayofwork.Text)
                .AddWithValue("@Hoursworked", txthour.Text)
                .AddWithValue("@Emtype", txtemptype.Text)
                .AddWithValue("@TYPE", "delete")

            End With
            Try
                cmd.ExecuteNonQuery()
                Response.Write("<script>alert('Data Are Sucessfull Delete') </script>")

            Catch ex As Exception
                Response.Write("<script>alert(' not Allowed To delete ') </script>")

            End Try
        End Using

        getemplo()

    End Sub
    Protected Sub emp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles emp.SelectedIndexChanged
        Dim row As GridViewRow = emp.SelectedRow
        txtid.Text = row.Cells(1).Text
        txtname.Text = row.Cells(2).Text
        TxtEmail.Text = row.Cells(3).Text
        txtaddrs.Text = row.Cells(4).Text
        txtphone.Text = row.Cells(5).Text
        txtegender.Text = row.Cells(6).Text
        txtdayofwork.Text = row.Cells(7).Text
        txthour.Text = row.Cells(8).Text
        txtemptype.Text = row.Cells(9).Text
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        txtid.Text = ""
        txtname.Text = ""
        txtphone.Text = ""
        txthour.Text = ""
        txtemptype.Text = ""
        TxtEmail.Text = ""
        txtegender.Text = ""
        txtdayofwork.Text = ""
        txtaddrs.Text = ""
    End Sub
End Class