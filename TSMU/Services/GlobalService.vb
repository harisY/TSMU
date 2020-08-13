Public Class GlobalService
    Dim ObjApprove As ApproveHistoryModel
    Public Function GetLevel(Frm As Form) As Integer
        Dim _result As Integer = 0
        Try
            Dim Sql As String = "M_Approve_GetUserLevel"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@form", SqlDbType.VarChar)
            pParam(0).Value = Frm.Name
            pParam(1) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
            pParam(1).Value = gh_Common.Username
            Dim dt As New DataTable

            dt = GetDataTableByCommand_SP(Sql, pParam)
            If dt.Rows.Count > 0 Then
                _result = Convert.ToInt32(dt.Rows(0)(0))
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Approve(Model As ApproveHistoryModel, Status As String)
        Try

            Dim Sql As String = "T_ApproveHistory_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}
            pParam(0) = New SqlClient.SqlParameter("@UserName", SqlDbType.VarChar)
            pParam(0).Value = Model.UserName
            pParam(1) = New SqlClient.SqlParameter("@MenuCode", SqlDbType.VarChar)
            pParam(1).Value = Model.MenuCode
            pParam(2) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(2).Value = Model.DeptID
            pParam(3) = New SqlClient.SqlParameter("@NoTransaksi", SqlDbType.VarChar)
            pParam(3).Value = Model.NoTransaksi
            pParam(4) = New SqlClient.SqlParameter("@LevelApprove", SqlDbType.Int)
            pParam(4).Value = Model.LevelApproved
            pParam(5) = New SqlClient.SqlParameter("@StatusApproved", SqlDbType.VarChar)
            pParam(5).Value = Status
            pParam(6) = New SqlClient.SqlParameter("@ApprovedBy", SqlDbType.VarChar)
            pParam(6).Value = gh_Common.Username
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
