Imports System.Collections.ObjectModel

Public Class SettleHeader
    Public Property CuryID As String
    Public Property DeptID As String
    Public Property ID As Integer
    Public Property pay As Short
    Public Property Remark As String
    Public Property SettleID As String
    Public Property Status As String
    Public Property PRNo As String
    Public Property SuspendID As String
    Public Property Tgl As Date
    Public Property Total As Double
    Public Property TotalSuspend As Double
    Public Property Tgl1 As Date
    Public Property Tgl2 As Date
    Public Property Jenis As String
    Public Property noPR As String
    Public Property Date1 As Date
    Public Property Date2 As Date
    Public Property perpost As String
    Public Property ObjDetails() As New Collection(Of SettleDetail)
    Public Property ObjRelasi() As New Collection(Of SettleRelasi)
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String

    Dim strQuery As String


    Public Function GetDataReportPaymentSolomon() As DataSet
        Dim query As String

        query = "SELECT        A.VendId, C.Name, A.BatNbr, A.PerPost, B.Status, A.RefNbr, A.User5, A.CuryPmtAmt, B.CuryCrTot, A.DocDate, A.Acct, A.CuryId, A.DocType, A.LUpd_Prog
                 FROM          dbo.APDoc AS A INNER JOIN dbo.Batch AS B ON A.BatNbr = B.BatNbr AND B.Module = 'AP' 
                                              INNER JOIN dbo.Vendor AS C ON A.VendId = C.VendId
                 WHERE        A.CuryId='IDR' and (A.LUpd_Prog IN ('03030', '03400')) AND (A.DocType = 'HC') and a.perpost='" & perpost & "'
                 ORDER BY C.Name,A.CuryId"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "PaymentSolomon")
        Return ds

    End Function
    Public Function GetCreditCard() As DataTable
        Try
            strQuery = " SELECT  CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName
                        FROM    dbo.TravelCreditCard "
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataByDate(Dari As String, Sampai As String, Status As String) As DataTable
        Try
            Dim Sql As String = "SETTHeader_GetDataByDateY"
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

    Public Function SubReport() As DataSet
        Dim query As String
        query = "SELECT [SettleRelasiID]
                      ,[SettleID]
                      ,[Nama]
                      ,[Posisi]
                      ,[Perusahaan]
                      ,[JenisUsaha]
                      ,[Remark]
                  FROM [SettleRelasi] Where [SettleID] = '" & SettleID & "'"
        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "SettleRelasi")
        Return ds

    End Function

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            'sql = " SELECT  settle_header.ID ,
            '                settle_header.SettleID ,
            '                settle_header.SuspendID ,
            '                settle_header.DeptID ,
            '                Remark ,
            '                settle_header.Tgl ,
            '                settle_header.CuryID ,
            '                settle_header.Total ,
            '                SUM(settle_detail.SuspendAmount) suspendAmount ,
            '                SUM(settle_detail.SettleAmount) SettleAmount ,
            '                settle_header.pay
            '        FROM    settle_header
            '                LEFT JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
            '        WHERE   settle_header.DeptID = '" & gh_Common.GroupID & "'
            '                AND pay = 0
            '                AND ( settle_header.SuspendID NOT LIKE '%ET%'
            '                      OR settle_header.SuspendID IS NULL
            '                    )
            '        GROUP BY settle_header.ID ,
            '                settle_header.SettleID ,
            '                settle_header.SuspendID ,
            '                settle_header.DeptID ,
            '                Remark ,
            '                settle_header.Tgl ,
            '                settle_header.CuryID ,
            '                settle_header.Total ,
            '                settle_header.pay "

            sql = "  DECLARE @firstDate DATE;
                    DECLARE @lastDate DATE;
                    SET @lastDate = DATEADD(MONTH, 1 + DATEDIFF(MONTH, 0, GETDATE()), -1);
                    SET @firstDate = DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0); 
                    
                    SELECT settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        SUM(settle_detail.SuspendAmount) suspendAmount ,
                        SUM(settle_detail.SettleAmount) SettleAmount ,
                        settle_header.pay
                    FROM   settle_header
                        INNER JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
                    WHERE  DeptID = '" & gh_Common.GroupID & "'
                        AND settle_header.SettleID NOT LIKE '%ET%'
                        AND pay = 0
                        AND ( settle_header.Tgl >= @firstDate
                                AND settle_header.Tgl <= @lastDate
                            )
                    GROUP BY settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        settle_header.pay;  "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridRpt() As DataTable

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
where pay=0 and settle_header.SuspendID like '" & Jenis & " %' and settle_header.Tgl>='" & Tgl1 & "' and settle_header.Tgl<='" & Tgl2 & "' and  group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"

            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT settle_detail.SettleID
                    ,settle_header.suspendid
                    ,settle_detail.Description
                    ,settle_detail.Tgl as Tgl2
                    ,suspend_header.Total as SuspendAmount
                    ,settle_detail.SettleAmount
                    ,settle_detail.AcctID
                    ,settle_detail.SubAcct
                    ,settle_detail.Nama
                    ,settle_detail.Tempat
                    ,settle_detail.Alamat
                    ,settle_detail.Jenis
                    ,settle_detail.NamaRelasi
                    ,settle_detail.Posisi
                    ,settle_detail.Relasi
                    ,settle_detail.JenisRelasi
                    ,settle_detail.Nota
                    ,settle_header.Tgl
                    ,settle_header.DeptID
                    ,settle_header.Remark
                    ,settle_header.CuryID
                    ,settle_header.Status
                    ,settle_header.Total
                    ,settle_header.pay
                    ,settle_header.Proses
                     ,settle_header.PRNo
                      FROM settle_header left join settle_detail on settle_detail.SettleID=settle_header.SettleID left join suspend_header on suspend_header.SuspendID=settle_header.SuspendID where settle_header.SettleID='" & SettleID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "settle")
        Return ds

    End Function

    Public Function loadreportAPSolomon() As DataSet
        Dim query As String

        query = "SELECT     CONVERT(VARCHAR(6), tgl, 112) AS tgl1, docbal, BankID, cashsub, refnbr1, vrno, tgl,
VendId, origdocamt, RefNbr, curydocbal FROM dataupload
where cek1=1 and prosespay=1 and uploaded=0 or 
uploaded Is null and tgl >='" & Date1 & "' And Tgl <='" & Date2 & "' order by vrno"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "dataupload")
        Return ds

    End Function

    Public Function loadreport2a() As DataSet
        Dim query As String
        query = "SELECT settle_detail.SettleID
                    ,settle_detail.Description
                    ,settle_detail.Tgl as Tgl2
                    ,settle_detail.SettleAmount
                    ,settle_detail.AcctID
                    ,settle_detail.SubAcct
                    ,settle_detail.Nama
                    ,settle_detail.Tempat
                    ,settle_detail.Alamat
                    ,settle_detail.Jenis
                    ,settle_detail.NamaRelasi
                    ,settle_detail.Posisi
                    ,settle_detail.Relasi
                    ,settle_detail.JenisRelasi
                    ,settle_detail.Nota
                    ,settle_header.Tgl
                    ,settle_header.DeptID
                    ,settle_header.Remark
                    ,settle_header.CuryID
                    ,settle_header.Status
                    ,settle_header.Total
                    ,settle_header.pay
                    ,settle_header.Proses
                    ,settle_header.PRNo
                      FROM settle_header left join settle_detail on settle_detail.SettleID=settle_header.SettleID where settle_header.SettleID='" & SettleID & "'"

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "settle")
        Return ds

    End Function

    Public Function GetDataGrid2() As DataTable
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
where pay=1 and settle_header.SuspendID not like '%EN%' group by settle_header.ID
	, settle_header.SettleID
	, settle_header.SuspendID, 
            settle_header.DeptID
            , Remark, settle_header.Tgl
            , settle_header.CuryID
            , settle_header.Total,settle_header.pay
"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " DECLARE @firstDate DATE;
                    DECLARE @lastDate DATE;
                    SET @lastDate = DATEADD(MONTH, 1 + DATEDIFF(MONTH, 0, GETDATE()), -1);
                    SET @firstDate = DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0); 
                    
                    SELECT settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        SUM(settle_detail.SuspendAmount) suspendAmount ,
                        SUM(settle_detail.SettleAmount) SettleAmount ,
                        settle_header.pay
                    FROM   settle_header
                        INNER JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
                    WHERE  DeptID = '" & gh_Common.GroupID & "'
                        AND settle_header.SettleID LIKE '%ET%'
                        AND pay = 0
                        AND ( settle_header.Tgl >= @firstDate
                                AND settle_header.Tgl <= @lastDate
                            )
                    GROUP BY settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        settle_header.pay;  "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEntSearch(ByVal dateFrom As Date, ByVal dateTo As Date) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " SELECT settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        SUM(settle_detail.SuspendAmount) suspendAmount ,
                        SUM(settle_detail.SettleAmount) SettleAmount ,
                        settle_header.pay
                    FROM   settle_header
                        INNER JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
                    WHERE  DeptID = '" & gh_Common.GroupID & "'
                        AND settle_header.SettleID LIKE '%ET%'
                        AND pay = 0
                        AND ( settle_header.Tgl >= '" & dateFrom & "'
                                AND settle_header.Tgl <= '" & dateTo & "'
                            )
                    GROUP BY settle_header.ID ,
                        settle_header.SettleID ,
                        settle_header.SuspendID ,
                        settle_header.DeptID ,
                        Remark ,
                        settle_header.Tgl ,
                        settle_header.CuryID ,
                        settle_header.Total ,
                        settle_header.pay;  "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEntPaid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " DECLARE @firstDate DATE;
                    DECLARE @lastDate DATE;
                    SET @lastDate = DATEADD(MONTH, 1 + DATEDIFF(MONTH, 0, GETDATE()), -1);
                    SET @firstDate = DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0);

                    SELECT  settle_header.ID ,
                            settle_header.SettleID ,
                            settle_header.SuspendID ,
                            settle_header.DeptID ,
                            Remark ,
                            settle_header.Tgl ,
                            settle_header.CuryID ,
                            settle_header.Total ,
                            SUM(settle_detail.SuspendAmount) suspendAmount ,
                            SUM(settle_detail.SettleAmount) SettleAmount ,
                            settle_header.pay
                    FROM    settle_header
                            INNER JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
                    WHERE   DeptID = '" & gh_Common.GroupID & "'
                            --AND ( settle_header.SuspendID LIKE '%EN%'
                            --      AND settle_header.SuspendID IS NULL
                            --    )
                            AND settle_header.SettleID LIKE '%ET%'
                            AND Status = 'Close'
                            AND pay = '1'
                            AND ( settle_header.Tgl >= @firstDate
                                  AND settle_header.Tgl <= @lastDate
                                )
                    GROUP BY settle_header.ID ,
                            settle_header.SettleID ,
                            settle_header.SuspendID ,
                            settle_header.DeptID ,
                            Remark ,
                            settle_header.Tgl ,
                            settle_header.CuryID ,
                            settle_header.Total ,
                            settle_header.pay; "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridEntPaidSearch(ByVal dateFrom As Date, ByVal dateTo As Date) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " SELECT  settle_header.ID ,
                            settle_header.SettleID ,
                            settle_header.SuspendID ,
                            settle_header.DeptID ,
                            Remark ,
                            settle_header.Tgl ,
                            settle_header.CuryID ,
                            settle_header.Total ,
                            SUM(settle_detail.SuspendAmount) suspendAmount ,
                            SUM(settle_detail.SettleAmount) SettleAmount ,
                            settle_header.pay
                    FROM    settle_header
                            INNER JOIN settle_detail ON settle_header.SettleID = settle_detail.SettleID
                    WHERE   DeptID = '" & gh_Common.GroupID & "'
                            --AND ( settle_header.SuspendID LIKE '%EN%'
                            --      AND settle_header.SuspendID IS NULL
                            --    )
                            AND settle_header.SettleID LIKE '%ET%'
                            AND Status = 'Close'
                            AND pay = '1'
                            AND ( settle_header.Tgl >= '" & dateFrom & "'
                                  AND settle_header.Tgl <= '" & dateTo & "'
                                )
                    GROUP BY settle_header.ID ,
                            settle_header.SettleID ,
                            settle_header.SuspendID ,
                            settle_header.DeptID ,
                            Remark ,
                            settle_header.Tgl ,
                            settle_header.CuryID ,
                            settle_header.Total ,
                            settle_header.pay; "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetSettleById()
        Try
            Dim sql As String =
            "SELECT t.ID, t.SettleID, t.SuspendID, t.DeptID, t.Remark, t.Tgl, t.CuryID, t.Status, t.Total, t.pay, s.Total TotSuspend,t.PRNo,ISNULL(t.PaymentType, 'CASH') AS	PaymentType,t.CreditCardID,t.CreditCardNumber,t.AccountName
            FROM settle_header t left join suspend_header s on t.SuspendID = s.SuspendID 
            where t.SettleID=" & QVal(SettleID) & ""
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
                pay = If(IsDBNull(dt.Rows(0).Item("Pay")), 0, dt.Rows(0).Item("Pay"))
                TotalSuspend = If(IsDBNull(dt.Rows(0).Item("TotSuspend")), 0, Convert.ToDouble(dt.Rows(0).Item("TotSuspend")))
                CuryID = If(IsDBNull(dt.Rows(0).Item("CuryID")), "", Convert.ToString(dt.Rows(0).Item("CuryID")))
                PRNo = If(IsDBNull(dt.Rows(0).Item("PRNo")), "", Convert.ToString(dt.Rows(0).Item("PRNo")))
                PaymentType = If(IsDBNull(dt.Rows(0).Item("PaymentType")), "", Convert.ToString(dt.Rows(0).Item("PaymentType")))
                CreditCardID = If(IsDBNull(dt.Rows(0).Item("CreditCardID")), "", Convert.ToString(dt.Rows(0).Item("CreditCardID")))
                CreditCardNumber = If(IsDBNull(dt.Rows(0).Item("CreditCardNumber")), "", Convert.ToString(dt.Rows(0).Item("CreditCardNumber")))
                AccountName = If(IsDBNull(dt.Rows(0).Item("AccountName")), "", Convert.ToString(dt.Rows(0).Item("AccountName")))
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
                pay = If(IsDBNull(dt.Rows(0).Item("Pay")), 0, dt.Rows(0).Item("Pay"))
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
            FROM suspend_header WHERE DeptID='" & gh_Common.GroupID & "' AND Tipe = 'S' AND Pay=1 AND Status ='Approved' Order by SuspendID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListSettleEnt() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " SELECT  SuspendHeaderID ID ,
                            SuspendID ,
                            PRNo ,
                            Remark ,
                            Tgl ,
                            Total
                    FROM    suspend_header
                    WHERE   Tipe = 'E'
                            AND pay = 1
                            AND Status = 'Approved'
                            AND DeptID = " & QVal(gh_Common.GroupID) & "
                    ORDER BY SuspendID; "
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
                "where SUBSTRING(settleid,1,2) = 'ST' and SUBSTRING(settleid,4,4) = RIGHT(@tahun,4) AND SUBSTRING(settleid,9,2) = RIGHT(@bulan,2)) " &
                "select 'ST' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function SettleAutoNoEnt() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(settleid)),4)+1 as varchar),4) " &
                "from settle_Header " &
                "where SUBSTRING(settleid,1,2)='ET' AND SUBSTRING(settleid,4,4) = RIGHT(@tahun,4) AND SUBSTRING(settleid,9,2) = RIGHT(@bulan,2)) " &
                "select 'ET' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

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

    Public Sub InsertHeaderEntSettle()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, SuspendID, DeptID, Remark, Tgl, CuryID, Status, PaymentType, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeaderEntSettleDirect()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "INSERT INTO settle_header (SettleID, DeptID, Remark, Tgl, CuryID, Status, PaymentType, CreditCardID, CreditCardNumber, AccountName, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(CreditCardID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(CreditCardNumber.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AccountName.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertHeaderDirectSettle()
        Try
            Dim ls_SP As String = String.Empty
            'ls_SP = "INSERT INTO settle_header (SettleID, DeptID,PRNo, Remark, Tgl, CuryID, Status,PaymentType, Total) " & vbCrLf &
            '"Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            '"       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            '"       " & QVal(PRNo.TrimEnd) & ", " & vbCrLf &
            '"       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            '"       " & QVal(Tgl) & ", " & vbCrLf &
            '"       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            '"       'Close', " & vbCrLf &
            '"       " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
            '"       " & QVal(Total) & ")"

            ls_SP = "INSERT INTO settle_header (SettleID, DeptID, Remark, Tgl, CuryID, Status, PaymentType, CreditCardID, CreditCardNumber, AccountName, Total) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
            "       'Close', " & vbCrLf &
            "       " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(CreditCardID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(CreditCardNumber.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AccountName.TrimEnd) & ", " & vbCrLf &
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
                                    "       PRNo = " & QVal(PRNo.TrimEnd) & ", " & vbCrLf &
                                    "       Remark = " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       CuryID = " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
                                    "       Status = 'Close', " & vbCrLf &
                                    "       PaymentType = " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
                                    "       CreditCardID = " & QVal(CreditCardID.TrimEnd) & ", " & vbCrLf &
                                    "       CreditCardNumber = " & QVal(CreditCardNumber.TrimEnd) & ", " & vbCrLf &
                                    "       AccountName = " & QVal(AccountName.TrimEnd) & ", " & vbCrLf &
                                    "       Total = " & QVal(Total) & " WHERE SettleID = '" & _SettleID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateHeaderEntSettleDetail(ByVal _SettleID As String)
        Try
            Dim ls_SP As String
            ls_SP = "UPDATE  dbo.settle_header
                    SET     SuspendID = " & QVal(SuspendID.TrimEnd) & " ,
                            DeptID = " & QVal(DeptID.TrimEnd) & " ,
                            PRNo = " & QVal(PRNo.TrimEnd) & " ,
                            Remark = " & QVal(Remark.TrimEnd) & " ,
                            Tgl = " & QVal(Tgl) & " ,
                            CuryID = " & QVal(CuryID.TrimEnd) & " ,
                            Status = 'Close' ,
                            Total = " & Total & "
                    WHERE   SettleID = '" & _SettleID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateSettleTravelCost(ByVal EntertainID As String)
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Entertain_Update_TravelSettleCost"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(7) {}
            pParam(0) = New SqlClient.SqlParameter("@EntertainID", SqlDbType.VarChar)
            pParam(0).Value = SettleID
            pParam(1) = New SqlClient.SqlParameter("@Description", SqlDbType.VarChar)
            pParam(1).Value = Remark
            pParam(2) = New SqlClient.SqlParameter("@PaymentType", SqlDbType.VarChar)
            pParam(2).Value = PaymentType
            pParam(3) = New SqlClient.SqlParameter("@CreditCardID", SqlDbType.VarChar)
            pParam(3).Value = CreditCardID
            pParam(4) = New SqlClient.SqlParameter("@CreditCardNumber", SqlDbType.VarChar)
            pParam(4).Value = CreditCardNumber
            pParam(5) = New SqlClient.SqlParameter("@AccountName", SqlDbType.VarChar)
            pParam(5).Value = AccountName
            pParam(6) = New SqlClient.SqlParameter("@CurryID", SqlDbType.VarChar)
            pParam(6).Value = CuryID
            pParam(7) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
            pParam(7).Value = Total

            ExecQueryByCommand_SP_Solomon(SP_Name, pParam)

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

    Public Sub InsertDataEntSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderEntSettle()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettle1()
                            End With
                        Next

                        For i As Integer = 0 To ObjRelasi.Count - 1
                            With ObjRelasi(i)
                                .InsertRelasi()
                            End With
                        Next

                        UpdateStatusSuspend("Close")

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

    Public Sub InsertDataEntSettleDirect()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeaderEntSettleDirect()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettleDirect()
                            End With
                        Next

                        For i As Integer = 0 To ObjRelasi.Count - 1
                            With ObjRelasi(i)
                                .InsertRelasi()
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

    Public Sub UpdateDataEntSettleDetail(_SettleID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        UpdateHeaderEntSettleDetail(_SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(_SettleID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettle1()
                            End With
                        Next

                        Dim clsEntertainRelasi As New SettleRelasi
                        clsEntertainRelasi.DeleteRelasi(_SettleID)

                        For i As Integer = 0 To ObjRelasi.Count - 1
                            With ObjRelasi(i)
                                .InsertRelasi()
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

                        UpdateSettleTravelCost(_SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(_SettleID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetailsEntSettleDirect()
                            End With
                        Next

                        Dim clsEntertainRelasi As New SettleRelasi
                        clsEntertainRelasi.DeleteRelasi(_SettleID)

                        For i As Integer = 0 To ObjRelasi.Count - 1
                            With ObjRelasi(i)
                                .InsertRelasi()
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

    Public Function CheckSettleAccrued(ByVal NoTransaksi As String) As Boolean
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  CAST(COUNT(NoAccrued) AS BIT)
                        FROM    dbo.T_CCAccrued
                        WHERE   NoTransaksi = " & QVal(NoTransaksi) & ""
            dt = GetDataTable(strQuery)

            Dim validasi As Boolean
            validasi = dt.Rows(0).Item(0)

            Return validasi
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteHeader(SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(SettleID)

                        Dim clsEntertainRelasi As New SettleRelasi
                        clsEntertainRelasi.DeleteRelasi(SettleID)

                        DeleteTravelCost(SettleID)

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

    Public Sub DeleteDataWithSuspend()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteHeader(SettleID)

                        Dim ObjSettleDetail As New SettleDetail
                        ObjSettleDetail.DeleteDetail(SettleID)

                        Dim clsEntertainRelasi As New SettleRelasi
                        clsEntertainRelasi.DeleteRelasi(SettleID)

                        UpdateStatusSuspend("Approved")

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

    Public Sub DeleteHeader(_SettleID As String)
        Try
            Dim ls_SP As String
            ls_SP = "DELETE
                     FROM    dbo.settle_header
                     WHERE   RTRIM(SettleID) = " & QVal(_SettleID) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteTravelCost(_SettleID As String)
        Try
            Dim ls_SP As String
            ls_SP = "DELETE
                     FROM    New_BOM.dbo.TravelSettleCost
                     WHERE   EntertainID = " & QVal(_SettleID) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateStatusSuspend(ByVal _status As String)
        Try
            Dim sql As String
            sql = " UPDATE  dbo.suspend_header
                    SET     Status = '" & _status & "'
                    WHERE   SuspendID = '" & SuspendID & "' "
            ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

Public Class SettleDetail
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property SuspendAmount As Long
    Public Property SettleAmount As Long
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
    Public Property HeaderSeq As Integer

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

    Public Sub InsertDetailsEnt()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Description, Tgl, SuspendAmount, SettleAmount, AcctID, SubAcct,Nama,Tempat,Alamat,Jenis,NamaRelasi,Posisi,Relasi,JenisRelasi,Nota) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Posisi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Relasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nota.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEntSettle()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SettleAmount,NamaRelasi,Posisi,Relasi,JenisRelasi,Nota ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Posisi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Relasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nota.TrimEnd) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEntSettle1()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SuspendAmount,SettleAmount,HeaderSeq ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SuspendAmount) & ", " & vbCrLf &
            "       " & SettleAmount & ", " & vbCrLf &
            "       " & HeaderSeq & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetailsEntSettleDirect()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama,Tempat,Alamat,Jenis,SettleAmount,HeaderSeq ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(HeaderSeq) & ")"
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

    Public Function GetDataDetailByID(SettleID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  ISNULL(HeaderSeq, 0) AS HeaderSeq ,
                            Tgl ,
                            RTRIM(SubAcct) AS SubAccount ,
                            RTRIM(AcctID) AS Account ,
                            RTRIM(Description) AS [Description] ,
                            RTRIM(Nama) AS Nama ,
                            RTRIM(Tempat) AS Tempat ,
                            RTRIM(Alamat) AS Alamat ,
                            RTRIM(Jenis) AS Jenis ,
                            SuspendAmount ,
                            SettleAmount AS ActualAmount
                    FROM    settle_detail
                    WHERE   SettleID = " & QVal(SettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailRelasiByID(_SettleID As String) As DataTable
        Try
            Dim sql = "SELECT ISNULL([HeaderSeq], 0) AS [HeaderSeq]
                      ,[SettleRelasiID]
                      ,[SettleID]
                      ,[Nama]
                      ,[Posisi]
                      ,[Perusahaan]
                      ,[JenisUsaha]
                      ,[Remark]
                  FROM [SettleRelasi] Where [SettleID] = " & QVal(_SettleID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

'Add Midi For Insert & Delete Relasi Entertainment Direct
Public Class SettleRelasi
    Public Property SettleID As String
    Public Property NamaRelasi As String
    Public Property Posisi As String
    Public Property Relasi As String
    Public Property JenisRelasi As String
    Public Property Nota As String
    Public Property HeaderSeq As Integer

    Dim strQuery As String

    Public Sub InsertRelasi()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO dbo.settlerelasi (SettleID, Nama, Posisi, Perusahaan, JenisUsaha, Remark, HeaderSeq ) " & vbCrLf &
            "Values(" & QVal(SettleID) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Relasi) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi) & ", " & vbCrLf &
            "       " & QVal(Nota) & ", " & vbCrLf &
            "       " & QVal(HeaderSeq) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteRelasi(SettleID_ As String)
        Try
            strQuery = "DELETE  FROM dbo.SettleRelasi
                        WHERE   SettleID = " & QVal(SettleID_) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

