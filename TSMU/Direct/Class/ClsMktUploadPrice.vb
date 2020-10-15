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

    'Public Function SimulateUpload(ByVal data As DataTable, clmName As String) As DataTable
    '    Dim dtResult As New DataTable
    '    Try
    '        Using Conn1 As New SqlClient.SqlConnection(GetConnString)
    '            Conn1.Open()
    '            Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
    '                gh_Trans = New InstanceVariables.TransactionHelper
    '                gh_Trans.Command.Connection = Conn1
    '                gh_Trans.Command.Transaction = Trans1

    '                Try
    '                    For Each rows As DataRow In data.Rows
    '                        CheckInventoryID(rows(clmName))
    '                    Next

    '                    Trans1.Commit()
    '                Catch ex As Exception
    '                    Trans1.Rollback()
    '                    Throw
    '                Finally
    '                    gh_Trans = Nothing
    '                End Try
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw
    '    End Try
    '    Return dtResult
    'End Function

    Public Function CheckInventoryID(ByVal invtID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  RTRIM(inv.InvtID) AS InvtID ,
                            price.DiscPrice
                    FROM    Inventory AS inv
                            INNER JOIN ItemXRef AS ixr ON ixr.InvtID = inv.InvtID
                            LEFT JOIN ( SELECT  sp.InvtID ,
                                                spd.DiscPrice
                                        FROM    dbo.SlsPrc AS sp
                                                INNER JOIN dbo.SlsPrcDet AS spd ON sp.SlsPrcID = spd.SlsPrcID
                                      ) AS price ON price.InvtID = ixr.InvtID
                    WHERE   ixr.AltIDType = 'C'
                            AND REPLACE(ixr.AlternateID, '-', '') = REPLACE(" & QVal(invtID) & ", '-', '') "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
