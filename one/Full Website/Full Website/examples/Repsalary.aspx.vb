﻿Imports System.Data.SqlClient
Imports Full_Website.Main
Public Class Repsalary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    Session("islogin") = False
        '    Response.Redirect("~/login.aspx")
        'End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using con As SqlConnection = connect()
            cmd = New SqlCommand
            cmd.Connection = con
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_salary_report"
            cmd.Parameters.AddWithValue("@Bdate", txtb.Text)
            cmd.Parameters.AddWithValue("@Edate", txted.Text)
            Da = New SqlDataAdapter(cmd)
            Dt = New DataTable
            Da.Fill(Dt)
            Repeater1.DataSource = Dt
            Repeater1.DataBind()
        End Using
    End Sub

    Protected Sub txtb_TextChanged(sender As Object, e As EventArgs) Handles txtb.TextChanged

    End Sub
End Class