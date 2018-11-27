Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_login
    Dim query As String = String.Empty

    Private _user_id As String
    Public Property user_id() As String
        Get
            Return _user_id
        End Get
        Set(ByVal value As String)
            _user_id = value
        End Set
    End Property

    Private _user_name As String
    Public Property user_name() As String
        Get
            Return _user_name
        End Get
        Set(ByVal value As String)
            _user_name = value
        End Set
    End Property

    Public Function getalldata() As DataTable
        Try
            query = "SELECT user_id,user_name, user_password,dept FROM m_user WHERE user_id = '" & user_id & "' AND user_password = '" & user_name & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            dept1 = dt.Rows(0).Item(3).ToString

            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
End Class
