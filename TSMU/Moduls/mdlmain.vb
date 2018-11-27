Imports System.Data
Imports System.Data.SqlClient

Module mdlmain
    Public gh_Trans As TransactionHelper
    Public gv_UserLogin As String
    Public user1 As String
    Public dept1 As String

    Public Function GetConnString(Optional ByVal DBMS As String = "SQLServer") As String
        'Select Case DBMS
        '    Case "SQLServer"
        '        If gs_DBAuthMode = "win" Then
        '            Return "Data Source=" & gs_DBServer & ";Initial Catalog=" & gs_Database & ";Integrated Security=True"
        '        Else
        '' Return "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
        'Return "Data Source=10.10.1.47;Initial Catalog=kendaraan;User ID=sa;pwd=Tsmu2005"
        Return "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        '        End If
        '    Case Else
        'Return ""
        'End Select


    End Function

    Public Function GetConnString2(Optional ByVal DBMS As String = "SQLServer") As String

        Return "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        ''Return "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    End Function
    Public Function Num2Word(ByVal n As Double) As String 'max 2.147.483.647
        Dim satuan() As String
        satuan = New String() {"", "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan", "Sembilan", "Sepuluh", "Sebelas"}
        Select Case n
            Case 0 To 11
                Num2Word = satuan(Fix(n))
            Case 12 To 19
                Num2Word = Trim(Num2Word(n Mod 10)) + " Belas "
            Case 20 To 99
                Num2Word = Trim(Num2Word(Fix(n / 10))) + " Puluh " + Trim(Num2Word(n Mod 10))
            Case 100 To 199
                Num2Word = " Seratus " + Trim(Num2Word(n - 100))
            Case 200 To 999
                Num2Word = Trim(Num2Word(Fix(n / 100))) + " Ratus " + Trim(Num2Word(n Mod 100))
            Case 1000 To 1999
                Num2Word = " Seribu " + Trim(Num2Word(n - 1000))
            Case 2000 To 999999
                Num2Word = Trim(Num2Word(Fix(n / 1000))) + " Ribu " + Trim(Num2Word(n Mod 1000))
            Case 1000000 To 999999999
                Num2Word = Trim(Num2Word(Fix(n / 1000000))) + " Juta " + Trim(Num2Word(n Mod 1000000))
            Case Else
                Num2Word = Trim(Num2Word(Fix(n / 1000000000))) + " Milyar " + Trim(Num2Word(n Mod 1000000000))
        End Select
    End Function

    Public Function GetDataSet(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSetByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                gh_Trans.command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dsa)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSetByCommand1(ByVal pQuery As String, dt As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet1
        Dim da As SqlDataAdapter = Nothing
        Dim dsa As New DataSet1()
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                gh_Trans.command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dsa)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)

                    da.Fill(dsa, dt)
                End Using
            End If
            da = Nothing
            Return dsa
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTable(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    conn.Open()
                    da = New SqlDataAdapter(pQuery, conn)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                gh_Trans.command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataTableByCommand2(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataTable
        Dim dta As New DataTable
        Dim da As SqlDataAdapter = Nothing
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                gh_Trans.command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.command.Parameters.Add(pParam(i))
                    Next
                End If
                da = New SqlClient.SqlDataAdapter(gh_Trans.command)
                da.Fill(dta)
            Else
                Using conn As New SqlClient.SqlConnection
                    conn.ConnectionString = GetConnString2()
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = conn
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    conn.Open()
                    da = New SqlDataAdapter(cmd)
                    da.Fill(dta)
                End Using
            End If
            da = Nothing
            Return dta
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function ExecQuery(ByVal pQuery As String, Optional ByVal pTimeOut As Integer = 30) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                pRowAff = gh_Trans.command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    Conn1.ConnectionString = GetConnString()
                    Dim cmd As New SqlClient.SqlCommand(pQuery, Conn1)
                    cmd.CommandTimeout = pTimeOut
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ExecQueryByCommand(ByVal pQuery As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pConnStr As String = "", Optional ByVal pTimeOut As Integer = 30) As Integer
        Dim pRowAff As Integer = -1
        Try
            If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
                gh_Trans.command.CommandType = CommandType.Text
                gh_Trans.command.CommandText = pQuery
                gh_Trans.command.CommandTimeout = pTimeOut
                gh_Trans.command.Parameters.Clear()
                If pParam IsNot Nothing Then
                    For i As Integer = 0 To pParam.Length - 1
                        gh_Trans.command.Parameters.Add(pParam(i))
                    Next
                End If
                pRowAff = gh_Trans.command.ExecuteNonQuery()
            Else
                Using Conn1 As New SqlClient.SqlConnection
                    If pConnStr <> "" Then
                        Conn1.ConnectionString = pConnStr
                    Else
                        Conn1.ConnectionString = GetConnString()
                    End If
                    Dim cmd As New SqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = pQuery
                    cmd.CommandTimeout = pTimeOut
                    cmd.Connection = Conn1
                    If pParam IsNot Nothing Then
                        For i As Integer = 0 To pParam.Length - 1
                            cmd.Parameters.Add(pParam(i))
                        Next
                    End If
                    Conn1.Open()
                    pRowAff = cmd.ExecuteNonQuery()
                End Using
            End If
            Return pRowAff
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Class TransactionHelper
        Dim _cmd As New SqlCommand
        Public Property command() As SqlCommand
            Get
                Return _cmd

            End Get
            Set(ByVal value As SqlCommand)
                _cmd = value
            End Set
        End Property


    End Class

    Public Function executereader(pquery As String) As SqlDataReader
        Try
            Dim conn As New SqlConnection()
            conn.ConnectionString = GetConnString()
            conn.Open()

            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            cmd = New SqlCommand(pquery, conn)
            dr = cmd.ExecuteReader
            Return dr

        Catch ex As Exception
            Throw

        End Try
    End Function

    'Public Function GetDataSetByCommand1(ByVal pQuery As String, dt As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet1
    '    Dim da As SqlDataAdapter = Nothing
    '    Dim dsa As New DataSet1()
    '    Try
    '        If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
    '            gh_Trans.command.CommandType = CommandType.Text
    '            gh_Trans.command.CommandText = pQuery
    '            gh_Trans.command.CommandTimeout = pTimeOut
    '            gh_Trans.command.Parameters.Clear()
    '            If pParam IsNot Nothing Then
    '                For i As Integer = 0 To pParam.Length - 1
    '                    gh_Trans.command.Parameters.Add(pParam(i))
    '                Next
    '            End If
    '            da = New SqlClient.SqlDataAdapter(gh_Trans.command)
    '            da.Fill(dsa)
    '        Else
    '            Using conn As New SqlClient.SqlConnection
    '                conn.ConnectionString = GetConnString()
    '                Dim cmd As New SqlCommand
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = pQuery
    '                cmd.CommandTimeout = pTimeOut
    '                cmd.Connection = conn
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        cmd.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                conn.Open()
    '                da = New SqlDataAdapter(cmd)

    '                da.Fill(dsa, dt)
    '            End Using
    '        End If
    '        da = Nothing
    '        Return dsa
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function
    'Public Function GetDataSetByCommand3(ByVal pQuery As String, dt As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet3
    '    Dim da As SqlDataAdapter = Nothing
    '    Dim dsa As New DataSet3()
    '    Try
    '        If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
    '            gh_Trans.command.CommandType = CommandType.Text
    '            gh_Trans.command.CommandText = pQuery
    '            gh_Trans.command.CommandTimeout = pTimeOut
    '            gh_Trans.command.Parameters.Clear()
    '            If pParam IsNot Nothing Then
    '                For i As Integer = 0 To pParam.Length - 1
    '                    gh_Trans.command.Parameters.Add(pParam(i))
    '                Next
    '            End If
    '            da = New SqlClient.SqlDataAdapter(gh_Trans.command)
    '            da.Fill(dsa)
    '        Else
    '            Using conn As New SqlClient.SqlConnection
    '                conn.ConnectionString = GetConnString()
    '                Dim cmd As New SqlCommand
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = pQuery
    '                cmd.CommandTimeout = pTimeOut
    '                cmd.Connection = conn
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        cmd.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                conn.Open()
    '                da = New SqlDataAdapter(cmd)

    '                da.Fill(dsa, dt)
    '            End Using
    '        End If
    '        da = Nothing
    '        Return dsa
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function
    'Public Function GetDataSetByCommand2(ByVal pQuery As String, dt As String, Optional ByVal pParam() As SqlParameter = Nothing, Optional ByVal pTimeOut As Integer = 30) As DataSet2
    '    Dim da As SqlDataAdapter = Nothing
    '    Dim dsa As New DataSet2()
    '    Try
    '        If gh_Trans IsNot Nothing AndAlso gh_Trans.command IsNot Nothing Then
    '            gh_Trans.command.CommandType = CommandType.Text
    '            gh_Trans.command.CommandText = pQuery
    '            gh_Trans.command.CommandTimeout = pTimeOut
    '            gh_Trans.command.Parameters.Clear()
    '            If pParam IsNot Nothing Then
    '                For i As Integer = 0 To pParam.Length - 1
    '                    gh_Trans.command.Parameters.Add(pParam(i))
    '                Next
    '            End If
    '            da = New SqlClient.SqlDataAdapter(gh_Trans.command)
    '            da.Fill(dsa)
    '        Else
    '            Using conn As New SqlClient.SqlConnection
    '                conn.ConnectionString = GetConnString()
    '                Dim cmd As New SqlCommand
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = pQuery
    '                cmd.CommandTimeout = pTimeOut
    '                cmd.Connection = conn
    '                If pParam IsNot Nothing Then
    '                    For i As Integer = 0 To pParam.Length - 1
    '                        cmd.Parameters.Add(pParam(i))
    '                    Next
    '                End If
    '                conn.Open()
    '                da = New SqlDataAdapter(cmd)

    '                da.Fill(dsa, dt)
    '            End Using
    '        End If
    '        da = Nothing
    '        Return dsa
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Function
End Module
