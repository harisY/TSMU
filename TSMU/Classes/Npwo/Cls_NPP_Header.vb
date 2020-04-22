Public Class Cls_NPP_Header

    Public Function Get_NPP() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[NPP_Get_NPP]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)
            'pParam(0).Value = Dept
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Sub Delete(NPWO_ As String)
        Try



            Dim ls_SP As String = "DELETE FROM [NPP_Head] WHERE No_NPP = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_SP)


            Dim ls_Detail As String = "DELETE FROM [NPP_Detail]
                                     WHERE No_NPP = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail)


        Catch ex As Exception

        End Try


    End Sub


End Class
