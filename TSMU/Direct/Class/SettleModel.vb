Imports System.Collections.ObjectModel

Public Class SettleHeader
    Public Property CuryID As String
    Public Property DeptID As String
    Public Property ID As Integer
    Public Property pay As Short
    Public Property Remark As String
    Public Property SettleID As String
    Public Property Status As String
    Public Property SuspendID As String
    Public Property Tgl As DateTime
    Public Property Total As Double
    Public Property TotalSuspend As Double
    Public Property ObjDetails() As New Collection(Of SettleDetail)

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where settle_header.SuspendID not like '%EN%' or settle_header.SuspendID is null
group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID not like '%EN%' or settle_header.SuspendID is null"
            '"SELECT ID, SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Total, pay
            'FROM settle_header"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
"SELECT settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,
            sum(settle_detail.suspendAmount)suspendAmount
            ,sum(settle_detail.SettleAmount)SettleAmount
            , settle_header.pay
FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
where settle_header.SuspendID like '%EN%' or settle_header.SuspendID is null
group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            '"SELECT settle_header.ID, settle_header.SettleID, settle_header.SuspendID, 
            'settle_header.DeptID, Remark, settle_header.Tgl, settle_header.CuryID, settle_header.Total,
            'settle_detail.suspendAmount,settle_detail.SettleAmount, settle_header.pay
            'FROM settle_header inner join settle_detail on settle_header.settleID=settle_detail.settleID 
            'where settle_header.SuspendID like '%EN%'"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub GetSettleById()
        Try
            Dim sql As String =
            "SELECT t.ID, t.SettleID, t.SuspendID, t.DeptID, t.Remark, t.Tgl, t.CuryID, t.Status, t.Total, t.pay, s.Total TotSuspend
            FROM settle_header t Inner join suspend_header s on t.SuspendID = s.SuspendID 
            where t.ID=" & QVal(ID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                ID = If(IsDBNull(dt.Rows(0).Item("ID")), "", Trim(dt.Rows(0).Item("ID").ToString()))
                SettleID = If(IsDBNull(dt.Rows(0).Item("SettleID")), "", Trim(dt.Rows(0).Item("SettleID").ToString()))
                SuspendID = If(IsDBNull(dt.Rows(0).Item("SuspendID")), "", Trim(dt.Rows(0).Item("SuspendID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("Status")), "", Trim(dt.Rows(0).Item("Status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                TotalSuspend = If(IsDBNull(dt.Rows(0).Item("TotSuspend")), 0, Convert.ToDouble(dt.Rows(0).Item("TotSuspend")))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Convert.ToString(dt.Rows(0).Item("CuryID")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetSettleByIdEnt()
        Try
            Dim sql As String =
            "SELECT t.ID, t.SettleID, t.SuspendID, t.DeptID, t.Remark, t.Tgl, t.CuryID, t.Status, t.Total, t.pay, s.Total TotSuspend
            FROM settle_header t Inner join suspend_header s on t.SuspendID = s.SuspendID 
            where t.ID=" & QVal(ID) & " and t.suspendid like '%EN%'"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                ID = If(IsDBNull(dt.Rows(0).Item("ID")), "", Trim(dt.Rows(0).Item("ID").ToString()))
                SettleID = If(IsDBNull(dt.Rows(0).Item("SettleID")), "", Trim(dt.Rows(0).Item("SettleID").ToString()))
                SuspendID = If(IsDBNull(dt.Rows(0).Item("SuspendID")), "", Trim(dt.Rows(0).Item("SuspendID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Remark = If(IsDBNull(dt.Rows(0).Item("Remark")), "", Trim(dt.Rows(0).Item("Remark").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Status = If(IsDBNull(dt.Rows(0).Item("Status")), "", Trim(dt.Rows(0).Item("Status").ToString()))
                Total = If(IsDBNull(dt.Rows(0).Item("Total")), 0, Convert.ToDouble(dt.Rows(0).Item("Total")))
                TotalSuspend = If(IsDBNull(dt.Rows(0).Item("TotSuspend")), 0, Convert.ToDouble(dt.Rows(0).Item("TotSuspend")))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Convert.ToString(dt.Rows(0).Item("CuryID")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetListSuspend() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID ID, SuspendID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE Tipe = 'S' AND Pay=1 AND Status ='Approved' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListSettleEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT SuspendHeaderID ID, SuspendID, PRNo, Remark, Tgl, Total
            FROM suspend_header WHERE Tipe = 'E' AND Pay=1 AND Status='Approved' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SettleAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(settleid)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(settleid,4,4) = RIGHT(@tahun,4) AND SUBSTRING(settleid,9,2) = RIGHT(@bulan,2)) " &
                "select 'ST' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

        Try
            Dim ls_SP As String = "update suspend_header set status='Close' WHERE rtrim(SuspendID)=" & QVal(_SuspendID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub InsertHeaderDirectSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, DeptID, Remark, Tgl, CuryID, Status, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try

    End Sub
    Public Sub UpdateHeader(ByVal _SettleID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE settle_header " & vbCrLf &
                                    "SET    SuspendID = " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       CuryID = " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
                                    "       Status = 'Close', " & vbCrLf &
                                    "       Total = " & QVal(Total) & " WHERE SettleID = '" & _SettleID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertData1()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderDirectSettle()

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

    Public Sub UpdateData(_SettleID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(_SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(_SettleID)

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
End Class
Public Class SettleDetail
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property SuspendAmount As Double
    Public Property SettleAmount As Double
    Public Property Description As String
    Public Property ID As Integer
    Public Property Jenis As String
    Public Property JenisRelasi As String
    Public Property Nama As String
    Public Property NamaRelasi As String
    Public Property Nota As String
    Public Property Posisi As String
    Public Property proses As Boolean
    Public Property Relasi As String
    Public Property SettleID As String
    Public Property SubAcct As String
    Public Property Tempat As String
    Public Property Tgl As DateTime

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Description, Tgl, SuspendAmount, SettleAmount, AcctID, SubAcct) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteDetail(_SettleID As String)
        Try
            Dim ls_SP As String = "DELETE FROM settle_detail WHERE rtrim(SettleID)=" & QVal(_SettleID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    'Public Function GetDataDetailByID(_SettleID As String) As DataTable
    '    Try
    '        Dim sql As String = "
    '        SELECT
    '         settle.Tgl,
    '         settle.SubAcct SubAccount,
    '         settle.AcctID Account,
    '         settle.Description,
    '         suspend.Amount,
    '         settle.ActulAmount
    '        FROM
    '        (
    '        SELECT 
    '         sth.SuspendID,
    '         std.Tgl,
    '         std.SubAcct,
    '         std.AcctID,
    '         std.Description,
    '         std.Amount ActulAmount
    '        FROM dbo.settle_header sth INNER JOIN 
    '        dbo.settle_detail std on sth.SettleID = std.SettleID WHERE sth.SettleID = " & QVal(_SettleID) & ") settle Inner JOIN
    '        (
    '        SELECT 
    '         sph.SuspendID,
    '         spd.Amount
    '        FROM dbo.suspend_header sph INNER JOIN 
    '        dbo.suspend_detail spd on spd.SuspendID = spd.SuspendID
    '        WHERE sph.Tipe ='s'
    '        ) [suspend] on settle.SuspendID = suspend.SuspendID"
    '        Dim dt As New DataTable
    '        dt = GetDataTable_Solomon(sql)
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetDataDetailByID(_SettleID As String) As DataTable
        Try
            Dim sql As String = "
            SELECT 
	            Tgl,
	            SubAcct SubAccount,
	            AcctID Account,
	            Description,
                SettleAmount ActualAmount
            FROM settle_detail WHERE SettleID = " & QVal(_SettleID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
