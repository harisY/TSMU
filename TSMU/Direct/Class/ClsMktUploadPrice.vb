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

    Public Function GetMappingColumn(ByVal templateID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_MktMappingUploadPrice
                    WHERE   TemplateID = " & QVal(templateID) & " "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckInventoryID(ByVal invtID As String, ByVal price As Double) As DataTable
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
