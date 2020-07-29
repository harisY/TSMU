Public Class clsCR_Accounting


    Public Function Get_Approve_Accounting() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Request_Get_ApproveAccounting]"

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Approve_Accounting2() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Request_Get_ApproveAccounting2]"

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_Cek_Purchase() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Request_Get_Cek_Purchase]"

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function



End Class
