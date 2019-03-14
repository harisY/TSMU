Public Class ReportAdmModels
    Public Function GetDataGrid(ByVal strStatus As String, tgl As String, tgl1 As String) As DataTable
        Try
            Dim query As String = "GetDataBarcode"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
            pParam(0).Value = strStatus
            pParam(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.VarChar)
            pParam(1).Value = tgl
            pParam(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.VarChar)
            pParam(2).Value = tgl1
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class
