Imports System.Collections.ObjectModel
Public Class cashbank_models
    Public Property AcctID As String
    Public Property Keluar As Double
    Public Property Keterangan As String
    Public Property Masuk As Double
    Public Property NoBukti As String
    Public Property Noref As String
    Public Property Perpost As String
    Public Property Saldo As Double
    Public Property Saldo_Awal As Double
    Public Property SuspendAmount As Double
    Public Property SettleAmount As Double
    Public Property Tgl As DateTime
    Public Property Transaksi As String
    Public Property SuspendID As String
    Public Property SettleID As String

    Public Property account() As String
    Public Sub InsertToTable()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
           ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(Keterangan) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Noref) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTable2()
        Try

            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[Keterangan]
            ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Noref]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(Keterangan) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Noref) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateSuspend()

        Try

            Dim Query = "update suspend_header set pay=1,BankID=" & QVal(AcctID) & " where suspendid=" & QVal(SuspendID) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettle()

        Try

            Dim Query = "update settle_header set pay=1 where settleid=" & QVal(SettleID) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetGridDetailCashBankByAccountID() As DataTable
        Try
            Dim sql As String = "Select Tgl,NoBukti,Transaksi,Keterangan,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo FROM cashbank WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " order by nobukti"

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function autononb() As String
        Try
            Dim auto2 As String
            Dim sql As String = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(nobukti)),4)+1 as varchar),4) " &
                "from cashbank " &
                "where SUBSTRING(nobukti,4,4) = RIGHT(@tahun,4) AND SUBSTRING(nobukti,9,2) = RIGHT(@bulan,2)) " &
                "select 'VC' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            auto2 = dt.Rows(0).Item(0).ToString
            Return auto2

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetNamaAccountbyid() As String
        Try
            Dim namaaccount As String
            Dim sql As String = "SELECT 
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account WHERE Acct = " & QVal(account) & ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            namaaccount = dt.Rows(0).Item(0).ToString
            Return namaaccount

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function saldo2() As Double
        Try
            Dim saldo As Single

            Dim sql As String = "Select saldo from saldo_awal where acctid=" & QVal(account) & " and perpost=" & QVal(Perpost) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                saldo = Convert.ToDouble(dt.Rows(0).Item(0))
            Else
                saldo = 0
            End If

            Return saldo


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetGridDetailSuspendByAccountID() As DataTable
        Try
            'Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Description, suspend_detail.Amount, suspend_detail.AcctID,suspend_detail.Proses from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_header.tipe = 'S'"
            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, Proses from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S'"

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailSettleByAccountID() As DataTable
        Try
            Dim sql As String = "select settle_header.Tgl, settle_detail.SettleID, settle_header.SuspendID, settle_detail.Description,suspend_header.Total, settle_detail.SettleAmount, settle_detail.AcctID,suspend_header.BankID,settle_detail.proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailEntertaintByAccountID() As DataTable
        Try
            '  Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Nama, suspend_detail.DeptID, suspend_detail.Tempat, suspend_detail.ALamat, suspend_detail.Jenis, suspend_detail.Amount, suspend_detail.AcctID, suspend_detail.Proses from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_header.tipe = 'E'"

            Dim sql As String = "select  suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark as Description, suspend_header.DeptID, '' as Tempat, '' as ALamat, '' as Jenis, total as Amount, '' as AcctID,Proses from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'E'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
