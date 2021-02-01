Public Class Cls_eBudget


    Public Function GetTahun() As DataTable
        Try
            Dim query As String = "select Distinct top 2  Tahun from rekap_budget_dept order by tahun desc"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetStatus() As DataTable
        Try
            Dim query As String = "select * from BudgetSetting Where Status ='Open'"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function CekTahun(tahun As Int32) As DataTable
        Try
            Dim query As String = "select Tahun from rekap_budget_dept where tahun = '" & tahun & "'"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function CopyBudget(Tahun_Copy As String, Tahun_Create As String) As Boolean

        Dim result As Boolean = 0


        Try


            Dim query As String = "[Ebudget_CopyBudget]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@tahun_Copy", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@tahun_Update", SqlDbType.VarChar)

            pParam(0).Value = Tahun_Copy
            pParam(1).Value = Tahun_Create

            result = MainModul.ExecQueryByCommand_SP(query, pParam)

            Return result

        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Function Close_Budget() As Boolean
        Dim result As Boolean = False
        Try
            Try

                Dim query As String = "UPDATE BudgetSetting  
                                        SET Status = 'Close'"
                result = MainModul.ExecQueryByCommand(query)

            Catch ex As Exception
                Throw
            End Try
            Return result
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Open_Budget(tahun As String, semester As String, status As String) As Boolean
        Dim result As Boolean = False
        Try
            Try

                Dim query As String = "UPDATE BudgetSetting  
                                        SET [Tahun] = '" & tahun & "'
                                      ,[Semester] = '" & semester & "'
                                      ,[Status] = '" & status & "'
                                      ,[UpdateBy] = '" & gh_Common.Username & "'
                                      ,[UpdateDate] = '" & Date.Now & "'"
                result = MainModul.ExecQueryByCommand(query)

            Catch ex As Exception
                Throw
            End Try
            Return result
        Catch ex As Exception
            Throw
        End Try
    End Function


End Class
