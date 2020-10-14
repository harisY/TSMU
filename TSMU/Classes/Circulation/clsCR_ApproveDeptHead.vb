Public Class clsCR_ApproveDeptHead
    Public Property H_CirculationNo As String
    Public Property H_RequirementDate As DateTime
    Public Property H_DeptID As String
    Public Property H_SiteID As String
    Public Property H_Budget As Integer
    Public Property H_Account As String
    Public Property H_CR_Type As String
    Public Property H_Currency As String
    Public Property H_Rate As Double
    Public Property H_Reason As String
    Public Property H_RemainingBudget As Double
    Public Property H_CurrentCR As Double
    Public Property H_Balance As Double
    Public Property H_ChargeOfCustomer As String
    Public Property H_InvoiceNo As String
    Public Property H_UserSubmition As String
    Public Property H_DeptHead_ID As String
    Public Property H_DeptHead_Name As String
    Public Property H_DeptHead_Opinion As String
    Public Property H_DeptHead_Approve As String
    Public Property H_DeptHead_Approve_Date As Date
    Public Property H_DivHead_ID As String
    Public Property H_DivHead_Name As String
    Public Property H_DivHead_Opinion As String
    Public Property H_DivHead_Approve As String
    Public Property H_DivHead_Approve_Date As Date
    Public Property H_Status As String
    Public Property H_Parent_Circulation As String
    Public Property H_Parent_Circulation_Amount As Double

    Public Property H_div_Id As Int32
    Public Property H_director_Id As Int32



    Public Function Get_Approve_Search(Dept_ As String, Level As Int32, division As Int32, director As Int32, pDate1 As Date, pDate2 As Date) As DataTable
        Try
            Dim query As String = "[CR_Get_Approve_Search]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

            pParam(0) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@pDate1", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@pDate2", SqlDbType.Date)
            pParam(3) = New SqlClient.SqlParameter("@Level", SqlDbType.Int)
            pParam(4) = New SqlClient.SqlParameter("@div_id", SqlDbType.Int)
            pParam(5) = New SqlClient.SqlParameter("@director_id", SqlDbType.Int)
            pParam(6) = New SqlClient.SqlParameter("@User", SqlDbType.VarChar)

            pParam(0).Value = Dept_
            pParam(1).Value = pDate1
            pParam(2).Value = pDate2
            pParam(3).Value = Level
            pParam(4).Value = division
            pParam(5).Value = director
            pParam(6).Value = gh_Common.Username
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Function Get_Approve(Dept_ As String, Level As Int32, division As Int32, director As Int32) As DataTable
        Try

            Dim pField As String = ""
            Dim P1 As String = "Submit"
            Dim P2 As String = "Approve 1"
            Dim P3 As String = "Approve 2"
            Dim P4 As String = "Other Dept"

            Dim query As String = "[CR_Get_Approve]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}
            pParam(0) = New SqlClient.SqlParameter("@User", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@P1", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@P2", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Level", SqlDbType.Int)
            pParam(4) = New SqlClient.SqlParameter("@div_id", SqlDbType.VarChar)
            pParam(5) = New SqlClient.SqlParameter("@director_id", SqlDbType.VarChar)
            pParam(6) = New SqlClient.SqlParameter("@P3", SqlDbType.VarChar)
            pParam(7) = New SqlClient.SqlParameter("@P4", SqlDbType.VarChar)

            pParam(0).Value = gh_Common.Username
            pParam(1).Value = P1
            pParam(2).Value = P2
            pParam(3).Value = Level
            pParam(4).Value = division.ToString
            pParam(5).Value = director.ToString
            pParam(6).Value = P3
            pParam(7).Value = P4
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Root_Approve(User_ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Get_Root_Approve]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)
            pParam(0).Value = User_
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_Root_Approve_ByDept(Dept_ As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[Get_Root_Approve_ByDept]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Dept_", SqlDbType.VarChar)
            pParam(0).Value = Dept_
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_ApproveDeptHead(DeptHeadID As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Request_Get_ApproveDeptHead]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@DeptHead_ID", SqlDbType.VarChar)
            pParam(0).Value = DeptHeadID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_ApproveDeptHead2(DeptHeadID As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Request_Get_ApproveDeptHead2]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@DeptHead_ID", SqlDbType.VarChar)
            pParam(0).Value = DeptHeadID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


End Class
