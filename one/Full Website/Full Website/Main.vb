Imports System.Data.SqlClient

Public Class Main
    Public Shared Function connect() As SqlConnection
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("connect").ConnectionString)
        con.Open()
        Return con
    End Function
    Public Shared cmd As New SqlCommand
    Public Shared Da As New SqlDataAdapter
    Public Shared Dt As New DataTable
    Public Shared dr As SqlDataReader






End Class
