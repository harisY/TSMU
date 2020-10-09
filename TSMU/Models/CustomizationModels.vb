Public Class CustomizationModels

    Public Function GetListTableParam() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_TableCustom "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetColumnParam(tableName As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    fnGetColumn(" & QVal(tableName) & ") "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataParam(tableName As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    " & tableName & ""
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertDataParam(tableName As String, columns As String, values As String)
        Try
            Dim sql As String
            sql = " INSERT  INTO " & tableName & "
                            (" & columns & ")
                    VALUES  (" & values & ") "
            ExecQuery(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataParam(tableName As String, update As String, where As String)
        Try
            Dim sql As String
            sql = " UPDATE  " & tableName & "
                    SET     " & update & "
                    WHERE   " & where & " "
            ExecQuery(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDataParam(tableName As String, where As String)
        Try
            Dim sql As String
            sql = " DELETE  FROM " & tableName & "
                    WHERE   " & where & " "
            ExecQuery(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
