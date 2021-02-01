Imports System.Collections.ObjectModel

Public Class GJHeaderModel
    Public Property Currency As String
    Public Property DeptID As String
    Public Property PRNo As String
    Public Property Perpost As String
    Public Property Batch As String
    Public Property Remark As String
    Public Property Status As String
    Public Property GJHeaderID As Integer
    Public Property GJID As String
    Public Property GJID_Revers As String
    Public Property GJID_Revers2 As String
    Public Property Tgl As DateTime
    Public Property Tgld As DateTime
    Public Property Tgls As DateTime
    Public Property Tipe As String
    Public Property Total As Double
    Public Property TotalCr As Double
    Public Property ObjDetails() As New Collection(Of GJDetailModel)
    Public Property _id As String
    Public Property ceklist As String
    Public Property bl As String
    Public Property th As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM gj_header" & vbCrLf &
            "WHERE gjid = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM gj_detail " & vbCrLf &
            "WHERE gjid = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetGJPerpost(curyid As String, perpost As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "Proses_GJPerpost"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@perpost", SqlDbType.VarChar)
            pParam(0).Value = perpost
            pParam(1) = New SqlClient.SqlParameter("@curyid", SqlDbType.VarChar)
            pParam(1).Value = curyid
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListPerpost() As DataTable
        Try
            Dim sql As String
            sql = "SELECT distinct perpost FROM cashbank2 order by perpost desc"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Deletegj()
        Try
            Dim query As String = "DELETE FROM gj_header" & vbCrLf &
            "WHERE gjid = " & QVal(GJID) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM gj_detail " & vbCrLf &
            "WHERE gjid = " & QVal(GJID) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT GJHeaderID, GJID, GJID_Revers, Currency, DeptID, PRNo, Remark, Tgl, Total,TotalCr, Status 
            FROM gj_header WHERE YEAR(Tgl)=YEAR(getdate()) AND MONTH(Tgl)=MONTH(getdate()) AND DeptID='" & gh_Common.GroupID & "' AND  Tipe = 'S' and status<>'Close' Order by GJID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataByDate(Dari As String, Sampai As String, Status As String) As DataTable
        Try
            Dim Sql As String = "GLHeader_GetDataByDateY"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@Dari", SqlDbType.VarChar)
            pParam(0).Value = Dari
            pParam(1) = New SqlClient.SqlParameter("@Sampai", SqlDbType.VarChar)
            pParam(1).Value = Sampai
            pParam(2) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(2).Value = gh_Common.GroupID
            pParam(3) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
            pParam(3).Value = Status
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP_Solomon(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT gj_header.GJHeaderID
      ,gj_header.GJID
      ,gj_header.GJID_Revers
      ,gj_header.Tipe
      ,gj_header.Currency
      ,gj_header.DeptID
      ,gj_header.PRNo
      ,gj_header.Remark
      ,gj_header.Tgl
      ,gj_header.Status
      ,gj_header.Total
      ,gj_header.TotalCr
      ,gj_detail.Description
      ,gj_detail.Debit_Amount
     ,gj_detail.Credit_Amount
      ,gj_detail.AcctID
      ,gj_detail.SubAcct
  FROM gj_header left join gj_detail on gj_detail.GJID=gj_header.GJID where gj_header.GJID='" & GJID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "GL")
        Return ds

    End Function
    Public Function loadreport3() As DataSet
        Dim query As String
        query = "SELECT gj_header.GJHeaderID
      ,gj_header.GJID
      ,gj_header.Tipe
      ,gj_header.Currency
      ,gj_header.DeptID
      ,gj_header.PRNo
      ,gj_header.Remark
      ,gj_header.Tgl
      ,gj_header.Status
      ,gj_header.Total
      ,gj_header.TotalCr
      ,gj_header.pay
      ,gj_header.State
      ,gj_header.CirculationNo
      ,gj_header.AmountReq
      ,gj_header.BankID
      ,gj_header.Proses
      ,gj_detail.Description
      ,gj_detail.Debit_Amount
      ,gj_detail.Credit_Amount
      ,gj_detail.AcctID
      ,gj_detail.SubAcct
  FROM gj_header left join gj_detail on gj_detail.GJID=gj_header.GJID where gj_header.DeptID='" & DeptID & "' AND gj_header.Tgl>='" & Tgld & "' AND gj_header.Tgl<='" & Tgls & "' "

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "gj")
        Return ds

    End Function

    Public Function GetDept2() As List(Of String)
        Try
            Dim result As New List(Of String)

            Dim dt As New DataTable
            Dim sql As String =
            "select '''' + RTRIM(a.DeptID) + '''' DeptID from S_User u inner join
	            akses_approval a on u.Username = a.Username
            WHERE a.Username = " & QVal(gh_Common.Username) & ""
            dt = GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                result.Add(row("DeptID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataGrid2() As DataTable
        Try
            Dim dept As String()
            dept = GetDept2.ToArray
            Dim nilai = String.Join(",", GetDept2.ToArray)

            Dim dt As New DataTable
            Dim sql As String =
            "SELECT GJHeaderID, GJID, Currency, DeptID, PRNo, Remark, Tgl, Total,TotalCr, Status 
            FROM gj_header WHERE DeptID='" & gh_Common.GroupID & "' AND Tipe = 'S' and status<>'Open' Order by GJID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GJAutoNo() As String

        Try
            Dim query As String

            'query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
            '     "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
            '    "set @tahun = datepart(year,getdate()) " &
            '    "set @seq= (select right('0000'+cast(right(rtrim(max(GJID)),4)+1 as varchar),4) " &
            '    "from gj_header " &
            '    "where SUBSTRING(GJID,1,7) = 'GJ' + '-' + RIGHT(@tahun,4) AND SUBSTRING(GJID,9,2) = RIGHT(@bulan,2)) " &
            '    "select 'GJ' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = " & QVal(bl) & " " &
                "set @tahun = " & QVal(th) & " " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(GJID)),4)+1 as varchar),4) " &
                "from gj_header " &
                "where SUBSTRING(GJID,1,7) = 'GJ' + '-' + RIGHT(@tahun,4) AND SUBSTRING(GJID,9,2) = RIGHT(@bulan,2)) " &
                "select 'GJ' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function


    Public Function RJAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = " & QVal(bl) & " " &
                "set @tahun = " & QVal(th) & " " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(GJID)),4)+1 as varchar),4) " &
                "from gj_header " &
                "where SUBSTRING(GJID,1,7) = 'RJ' + '-' + RIGHT(@tahun,4) AND SUBSTRING(GJID,9,2) = RIGHT(@bulan,2)) " &
                "select 'RJ' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Sub GetGJById()
        Try
            Dim sql As String =
            "SELECT GJHeaderID, GJID, GJID_Revers, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total,TotalCr, ceklist
            FROM gj_header where GJHeaderID=" & QVal(GJHeaderID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                GJHeaderID = If(IsDBNull(dt.Rows(0).Item("GJHeaderID")), "", Trim(dt.Rows(0).Item("GJHeaderID").ToString()))
                GJID = If(IsDBNull(dt.Rows(0).Item("GJID")), "", Trim(dt.Rows(0).Item("GJID").ToString()))
                GJID_Revers = If(IsDBNull(dt.Rows(0).Item("GJID_Revers")), "", Trim(dt.Rows(0).Item("GJID_Revers").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                PRNo = If(IsDBNull(dt.Rows(0).Item("PRNo")), "", Trim(dt.Rows(0).Item("PRNo").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("status")), "", Trim(dt.Rows(0).Item("status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                TotalCr = If(IsDBNull(dt.Rows(0).Item("TotalCr")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalCr")))
                Currency = If(IsDBNull(dt.Rows(0).Item("Currency")), "", Convert.ToString(dt.Rows(0).Item("Currency")))
                ceklist = If(IsDBNull(dt.Rows(0).Item("ceklist")), "", Trim(dt.Rows(0).Item("ceklist").ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetDept() As DataTable
        Try
            Dim sql As String =
            "SELECT [IdDept]
                  ,[NamaDept]
              FROM [mDept]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSubAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsGJOpen(GJHeaderID As String) As Boolean
        Dim Result As Boolean = False
        Try
            Dim sql As String = "Select Top 1 * from gj_header where GJHeaderID = " & QVal(GJHeaderID) & " and Status <> 'Open' and State>=2"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                Result = True
            End If
            Return Result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function IsRJOpen(GJHeaderID As String) As Boolean
        Dim Result As Boolean = False
        Try
            Dim sql As String = "Select Top 1 * from gj_header where GJHeaderID = " & QVal(GJHeaderID) & " and Status <> 'Open' and State>=2"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                Result = True
            End If
            Return Result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_header (GJID, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total,TotalCr, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(GJID) & ", " & vbCrLf &
            "       " & QVal(Tipe) & ", " & vbCrLf &
            "       " & QVal(Currency) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PRNo) & ", " & vbCrLf &
            "       " & QVal(Remark) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Status) & ", " & vbCrLf &
            "       " & QVal(Total) & ", " & vbCrLf &
            "       " & QVal(TotalCr) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        'Try
        '    Dim ls_SP As String = "update gj_header set status='Open' WHERE rtrim(GJID)=" & QVal(_GJID.TrimEnd) & ""
        '    ExecQuery_Solomon(ls_SP)
        'Catch ex As Exception
        '    Throw
        'End Try

    End Sub
    Public Sub InsertHeaderR()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_header (GJID,GJID_Revers, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total,TotalCr, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(GJID_Revers) & ", " & vbCrLf &
            "       " & QVal(GJID) & ", " & vbCrLf &
            "       " & QVal(Tipe) & ", " & vbCrLf &
            "       " & QVal(Currency) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PRNo) & ", " & vbCrLf &
            "       " & QVal(Remark) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Status) & ", " & vbCrLf &
            "       " & QVal(Total) & ", " & vbCrLf &
            "       " & QVal(TotalCr) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)

            Dim ls_SP2 As String = " " & vbCrLf &
                        "UPDATE gj_header " & vbCrLf &
                        "SET   GJID_Revers= " & QVal(GJID_Revers) & vbCrLf &
                        "       WHERE GJID = '" & _GJID & "'"
            ExecQuery_Solomon(ls_SP2)
        Catch ex As Exception
            Throw
        End Try


    End Sub

    Public Sub InsertHeaderR2()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_header (GJID,GJID_Revers, Tipe, Currency, DeptID, PRNo, Remark, Tgl, Status, Total,TotalCr, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(GJID_Revers2) & ", " & vbCrLf &
            "       " & QVal(GJID) & ", " & vbCrLf &
            "       " & QVal(Tipe) & ", " & vbCrLf &
            "       " & QVal(Currency) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PRNo) & ", " & vbCrLf &
            "       " & QVal(Remark) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Status) & ", " & vbCrLf &
            "       " & QVal(Total) & ", " & vbCrLf &
            "       " & QVal(TotalCr) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)

            Dim ls_SP2 As String = " " & vbCrLf &
            "UPDATE gj_header " & vbCrLf &
            "SET   GJID_Revers= " & QVal(GJID_Revers2) & vbCrLf &
            "      , ceklist='True' WHERE GJID = '" & GJID & "'"
            ExecQuery_Solomon(ls_SP2)
        Catch ex As Exception
            Throw
        End Try


    End Sub
    Public Sub UpdateHeader(ByVal _GJID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE gj_header " & vbCrLf &
                                    "SET    Currency = " & QVal(Currency) & ", " & vbCrLf &
                                    "       PRNo = " & QVal(PRNo) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID) & ", " & vbCrLf &
                                    "       GJID_Revers= " & QVal(GJID_Revers) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       Status = " & QVal(Status) & ", " & vbCrLf &
                                    "       Total = " & QVal(Total) & ", " & vbCrLf &
                                    "       TotalCr = " & QVal(TotalCr) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE GJID = '" & _GJID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateHeadercek(ByVal _GJID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE gj_header " & vbCrLf &
                                    "SET    ceklist = '0', " & vbCrLf &
                                    "       GJID_Revers='' WHERE GJID = '" & _GJID_Revers & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

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
    Public Sub InsertDataR()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderR()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsR()
                            End With
                        Next

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
    Public Sub InsertDataR2()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderR2()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsR2()
                            End With
                        Next

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
    Public Sub UpdateData(_GJID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_GJID)

                        Dim ObjGJDetail As New GJDetailModel
                        ObjGJDetail.DeleteDetail(_GJID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataR(_GJID_Revers As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeaderR(_GJID_Revers)

                        Dim ObjGJDetail As New GJDetailModel
                        ObjGJDetail.DeleteDetail(_GJID_Revers)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDataR(_GJID_Revers As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        DeleteHeaderR(_GJID_Revers)

                    Catch ex As Exception

                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateHeaderR(ByVal _GJID_Revers As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE gj_header " & vbCrLf &
                                    "SET    Currency = " & QVal(Currency) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID) & ", " & vbCrLf &
                                    "       PRNo = " & QVal(PRNo) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       Status = " & QVal(Status) & ", " & vbCrLf &
                                    "       Total = " & QVal(Total) & ", " & vbCrLf &
                                    "       TotalCr = " & QVal(TotalCr) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE GJID = '" & _GJID_Revers & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteHeaderR(ByVal _GJID_Revers As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "DELETE from gj_header  WHERE GJID = '" & _GJID_Revers & "' AND LEFT(GJID,2) != 'GJ'"
            ExecQuery_Solomon(ls_SP)
            Dim ls_SP2 As String = " " & vbCrLf &
                        "DELETE from gj_detail WHERE GJID = '" & _GJID_Revers & "'  AND LEFT(GJID,2) != 'GJ'"
            ExecQuery_Solomon(ls_SP2)

            Dim ls_SP3 As String = " " & vbCrLf &
                "UPDATE gj_header " & vbCrLf &
                "SET   GJID_Revers= '', ceklist='False' WHERE GJID = '" & _GJID_Revers & "'  AND LEFT(GJID,2) = 'GJ'"
            ExecQuery_Solomon(ls_SP3)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDetailR(ByVal _GJID_Revers As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "DELETE from gj_detail WHERE GJID = '" & _GJID_Revers & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
Public Class GJDetailModel
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property Amount As Double
    Public Property Debit_Amount As Double
    Public Property Credit_Amount As Double
    Public Property DeptID As String
    Public Property Description As String
    Public Property Jenis As String
    Public Property Nama As String
    Public Property NoKwitansi As Char
    Public Property SubAcct As String
    Public Property GJDetailID As Integer
    Public Property GJID As String
    Public Property GJID_Revers As String
    Public Property GJID_Revers2 As String
    Public Property Tempat As String
    Public Property Tgl As String

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_detail (GJID, Description, Debit_Amount,Credit_Amount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(GJID) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Debit_Amount) & ", " & vbCrLf &
            "       " & QVal(Credit_Amount) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertDetailsR()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_detail (GJID, Description, Debit_Amount,Credit_Amount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(GJID_Revers) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Credit_Amount) & ", " & vbCrLf &
            "       " & QVal(Debit_Amount) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertDetailsR2()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO gj_detail (GJID, Description, Debit_Amount,Credit_Amount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(GJID_Revers2) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Credit_Amount) & ", " & vbCrLf &
            "       " & QVal(Debit_Amount) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteDetail(_gjID)
        Try
            Dim ls_SP As String = "DELETE FROM gj_detail WHERE rtrim(GJID)=" & QVal(_gjID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetSubAccountbyid() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct WHERE Consolsub = " & QVal(SubAcct) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    [Debit_Amount] Debit_Amount,
                                   [Credit_Amount] Credit_Amount
                                 FROM gj_detail WHERE GJID = " & QVal(GJID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetDataDetailByID1(_GJID As String) As DataTable
        Try
            Dim sql As String = "SELECT GETDATE() as Tgl,
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    RTRIM([Debit_Amount]) Debit_Amount,
                                    RTRIM([Credit_Amount]) Credit_Amount,
                                    convert(numeric(18,2),0) ActualAmount, 
                                    '' as PaymentType,
                                    '' as CreditCardID,
                                    '' as CreditCardNumber,
                                    '' as BankName,
                                    '' as AccountName
                                FROM gj_detail WHERE GJID = " & QVal(_GJID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function



End Class
