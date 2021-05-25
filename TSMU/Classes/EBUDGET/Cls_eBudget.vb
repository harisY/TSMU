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

    Public Function GetTahunApprove() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Ebudget_GetTahunApprove]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            'pParam(0).Value = CirculationNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetAccountApprove() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Ebudget_GetAccountApprove]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            'pParam(0).Value = CirculationNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetSiteApprove() As DataTable
        Try
            Dim query As String = "select Distinct  SiteID from rekap_budget_dept "
            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDeptApprove() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Ebudget_GetDeptApprove]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            'pParam(0).Value = CirculationNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
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

    'Public Function CopyBudget(Tahun_Copy As String, Tahun_Create As String) As Boolean

    '    Dim result As Boolean = 0


    '    Try


    '        Dim query As String = "[Ebudget_CopyBudget]"
    '        Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
    '        pParam(0) = New SqlClient.SqlParameter("@tahun_Copy", SqlDbType.VarChar)
    '        pParam(1) = New SqlClient.SqlParameter("@tahun_Update", SqlDbType.VarChar)

    '        pParam(0).Value = Tahun_Copy
    '        pParam(1).Value = Tahun_Create

    '        result = MainModul.ExecQueryByCommand_SP(query, pParam)

    '        Return result

    '    Catch ex As Exception
    '        Throw
    '    End Try

    'End Function


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

    Public Function CekBackup(tahun As String) As Boolean
        Dim result As Boolean = False
        Try
            Try
                Dim dt = New DataTable
                Dim query As String = "select * from rekap_budget_dept_s1 where tahun = '" & tahun & "'"
                dt = MainModul.GetDataTableByCommand(query)
                If dt.Rows.Count > 0 Then
                    result = True
                Else
                    result = False
                End If
            Catch ex As Exception
                Throw
            End Try
            Return result
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub BackupSemester1(Tahun As String)

        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Dim result As Boolean = 0

                    Try

                        Dim query As String = "delete from rekap_budget_dept_s1 where tahun ='" & Tahun & "' "
                        MainModul.ExecQuery(query)

                        Dim querysp As String = "[Ebudget_CopyBudget_s1]"
                        Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
                        pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.VarChar)

                        pParam(0).Value = Tahun
                        ExecQueryByCommand_SP(querysp, pParam)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub CopyBudget(Tahun_Copy As String, Tahun_Create As String)

        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1


                    Dim result As Boolean = 0


                    Try

                        Dim query As String = "[Ebudget_CopyBudget]"
                        Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
                        pParam(0) = New SqlClient.SqlParameter("@tahun_Copy", SqlDbType.VarChar)
                        pParam(1) = New SqlClient.SqlParameter("@tahun_Update", SqlDbType.VarChar)

                        pParam(0).Value = Tahun_Copy
                        pParam(1).Value = Tahun_Create

                        ExecQueryByCommand_SP(query, pParam)


                        Dim queryBOD As String = "[Ebudget_Copy_BOD_Approve]"
                        Dim pParamBOD() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
                        pParamBOD(0) = New SqlClient.SqlParameter("@tahun_Copy", SqlDbType.VarChar)
                        pParamBOD(1) = New SqlClient.SqlParameter("@tahun_Create", SqlDbType.VarChar)

                        pParamBOD(0).Value = Tahun_Copy
                        pParamBOD(1).Value = Tahun_Create

                        ExecQueryByCommand_SP(queryBOD, pParamBOD)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ApproveBOD(Tahun As String, semester As String, Dept As String, AcctiD As String, Site As String, Persen As Double)

        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Dim result As Boolean = 0

                    Try
                        Dim querysp As String = "[Ebudget_ApproveBOD]"
                        Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
                        pParam(0) = New SqlClient.SqlParameter("@tahun", SqlDbType.VarChar)
                        pParam(1) = New SqlClient.SqlParameter("@semester", SqlDbType.VarChar)
                        pParam(2) = New SqlClient.SqlParameter("@dept", SqlDbType.VarChar)
                        pParam(3) = New SqlClient.SqlParameter("@acctid", SqlDbType.VarChar)
                        pParam(4) = New SqlClient.SqlParameter("@site", SqlDbType.VarChar)
                        pParam(5) = New SqlClient.SqlParameter("@persen", SqlDbType.Float)



                        pParam(0).Value = Tahun
                        pParam(1).Value = semester
                        pParam(2).Value = Dept
                        pParam(3).Value = AcctiD
                        pParam(4).Value = Site
                        pParam(5).Value = Persen

                        ExecQueryByCommand_SP(querysp, pParam)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
