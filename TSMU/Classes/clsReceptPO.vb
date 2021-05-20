Public Class clsReceptPO
    Public Function GetReceiptPO(dari As String, sampai As String, vendid As String, site As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String = "Rekap_Receipt"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@dari", SqlDbType.VarChar)
            pParam(0).Value = dari
            pParam(1) = New SqlClient.SqlParameter("@sampai", SqlDbType.VarChar)
            pParam(1).Value = sampai
            pParam(2) = New SqlClient.SqlParameter("@vendor", SqlDbType.VarChar)
            pParam(2).Value = vendid
            pParam(3) = New SqlClient.SqlParameter("@site", SqlDbType.VarChar)
            pParam(3).Value = site
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetVendor() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                VendID [Vendor ID],
                                    name [Suppllier Name]
                                FROM vendor order by name"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
