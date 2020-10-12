Public Class ClsMktUploadPrice
    Public Function GetListTemplate() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_MktTemplateUploadPrice "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
