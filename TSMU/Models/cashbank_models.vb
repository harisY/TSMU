﻿Imports System.Collections.ObjectModel
Public Class cashbank_models
    Public Property AcctID As String
    Public Property Keluar As Double
    Public Property Keterangan As String
    Public Property Masuk As Double
    Public Property NoBukti As String
    Public Property CostType As String

    Public Property Noref As String
    Public Property Perpost As String
    Public Property Saldo As Double
    Public Property Saldo_Awal As Double
    Public Property SuspendAmount As Double
    Public Property SettleAmount As Double
    Public Property Tgl As DateTime
    Public Property Transaksi As String
    Public Property SuspendID As String
    Public Property NoVoucher As String
    Public Property SettleID As String
    Public Property curyid As String
    Public Property account() As String
    Public Property _id As String
    Public Property cek As Boolean
    Public Property recon As Boolean
    Public Property saldo3 As Double
    Public Property NoRequest As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Public Function GetUsernameLevel() As Integer
        Dim result As Integer = 0
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT top 1 Kol
            FROM akses_approval where Username = " & QVal(gh_Common.Username) & ""
            dt = GetDataTable(sql)
            result = Convert.ToInt32(dt.Rows(0)(0))
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub GetDirekPaymentById(_NoBukti As String)
        Try
            Dim sql As String =
            "Select Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,Perpost,Account.curyid,AcctID FROM cashbank2  inner join  Account on Account.Acct=cashbank2.AcctID WHERE  NoBukti=" & QVal(_NoBukti) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                NoBukti = If(IsDBNull(dt.Rows(0).Item("NoBukti")), "", Trim(dt.Rows(0).Item("NoBukti").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Transaksi = If(IsDBNull(dt.Rows(0).Item("Transaksi")), "", Trim(dt.Rows(0).Item("Transaksi").ToString()))
                SettleAmount = If(IsDBNull(dt.Rows(0).Item("SettleAmount")), 0, Convert.ToDouble(dt.Rows(0).Item("SettleAmount")))
                SuspendAmount = If(IsDBNull(dt.Rows(0).Item("SuspendAmount")), 0, Convert.ToDouble(dt.Rows(0).Item("SuspendAmount")))
                Masuk = If(IsDBNull(dt.Rows(0).Item("Masuk")), 0, Convert.ToDouble(dt.Rows(0).Item("Masuk")))
                Keluar = If(IsDBNull(dt.Rows(0).Item("Keluar")), 0, Convert.ToDouble(dt.Rows(0).Item("Keluar")))
                Perpost = If(IsDBNull(dt.Rows(0).Item("Perpost")), "", Trim(dt.Rows(0).Item("Perpost").ToString()))
                AcctID = If(IsDBNull(dt.Rows(0).Item("AcctID")), "", Convert.ToString(dt.Rows(0).Item("AcctID")))
                curyid = If(IsDBNull(dt.Rows(0).Item("curyid")), "", Convert.ToString(dt.Rows(0).Item("curyid")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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

    Public Sub InsertToTable02()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank2]
           ([Tgl]
           ,[NoBukti]
           ,[Transaksi]
           ,[SuspendAmount]
           ,[SettleAmount]
           ,[Masuk]
           ,[Keluar]
           ,[Saldo]
           ,[Perpost]
           ,[AcctID]
           ,[Saldo_Awal])
     VALUES
           (" & QVal(Tgl) & "
           ," & QVal(NoBukti) & "
           ," & QVal(Transaksi) & "
           ," & QVal(SuspendAmount) & "
          ," & QVal(SettleAmount) & "
           ," & QVal(Masuk) & "
           ," & QVal(Keluar) & "
           ," & QVal(Saldo) & "
           ," & QVal(Perpost) & "
           ," & QVal(AcctID) & "
           ," & QVal(Saldo_Awal) & ")"
            MainModul.ExecQuery_Solomon(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertToTableB()
        Try
            Dim chek As Integer
            'If Checked Then
            '    chek = 1
            'Else
            '    chek = 0
            'End If
            Dim sql As String =
            "INSERT INTO [cashbank2]
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
           ,[flag]
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
           ,'1'
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
    Public Sub UpdateSuspendTravel()
        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "ProsesUSD"
            Else
                prs = "ProsesYEN"
            End If

            Dim Query = "update TravelRequestCost set " & prs & " =1 where NoRequest=" & QVal(SuspendID) & " AND CostType=" & QVal(CostType) & ""
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Sub UpdateSettleTravel2()
        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "ProsesUSD"
            Else
                prs = "ProsesYEN"
            End If

            Dim Query = "update TravelRequestCost set " & prs & " =1 where NoRequest=" & QVal(SettleID) & "   AND CostType!='C03'"
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettleTravel31()
        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "ProsesUSD"
            Else
                prs = "ProsesYEN"
            End If

            Dim Query = "update TravelSettleCost set pay=1 where curryid=" & QVal(curyid) & " AND TravelSettleID=" & QVal(NoVoucher) & " "
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Sub UpdateSettleTravel3()
        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "SettleIDR"
            ElseIf curyid = "USD" Then
                prs = "SettleUSD"
            Else
                prs = "SettleYEN"
            End If

            Dim Query = "update TravelRequestCost set " & prs & " =1 where NoRequest=" & QVal(SettleID) & "   AND CostType='C03'"
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Public Sub UpdateSettleTravel4()
        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "ProsesUSD"
            Else
                prs = "ProsesYEN"
            End If

            Dim Query = "update TravelSettleDetail set " & prs & " =1 where NoRequest=" & QVal(SettleID) & ""
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateVoucher()

        Try

            Dim Query = "update cashbank set AcctID=" & QVal(AcctID) & " where NoBukti=" & QVal(NoBukti) & ""
            MainModul.ExecQuery_Solomon(Query)


            Dim Query2 = "update cashbank2 set AcctID=" & QVal(AcctID) & " where NoBukti=" & QVal(NoBukti) & ""
            MainModul.ExecQuery_Solomon(Query2)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSuspend_hapus()

        Try
            Dim Query = "update suspend_header set pay=0 from suspend_header inner join cashbank on suspend_header.SuspendID = right(replace(cashbank.noref,' ',''),15) where cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery_Solomon(Query)
            Dim Query2 = "update TravelRequestHeader set ProsesIDR=0,ProsesUSD=0,ProsesYEN=0 from TravelRequestHeader inner join  TSC16Application.dbo.cashbank on TravelRequestHeader.NoRequest = right(replace( TSC16Application.dbo.cashbank.noref,' ',''),15) where  TSC16Application.dbo.cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery(Query2)
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
    Public Sub UpdateSettleCC()

        Try

            Dim Query = "update TSC16Application.dbo.settle_header set TSC16Application.dbo.settle_header.pay=1 FROM T_CCAccrued inner join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi where T_CCAccrued.NoAccrued=" & QVal(SettleID) & ""
            MainModul.ExecQuery(Query)
            Dim Query2 = "update T_CCAccrued set pay=1,DatePaid= " & QVal(Tgl) & " where NoAccrued=" & QVal(SettleID) & ""
            MainModul.ExecQuery(Query2)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettleTravel()

        Try

            Dim Query = "update TravelTicket set pay=1 where NoVoucher=" & QVal(SettleID) & ""
            MainModul.ExecQuery(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetGridDetailSettleByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "SELECT Tgl,RTRIM([SubAcct]) SubAccount, RTRIM([AcctID]) Account,RTRIM(Description) Description,[SuspendAmount] SuspendAmount, [SettleAmount] SettleAmount FROM settle_detail WHERE SettleID=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountID03CC(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "SELECT  ID ,
                                NoAccrued ,
                                Tanggal ,
                                TanggalTrans AS TanggalTransaksi ,
                                NoTransaksi ,
                                Seq ,
                                JenisTransaksi ,
                                Description ,
                                CurryID ,
                                Amount ,
                                Rate ,
                                AmountIDR ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName ,
                                Pay
                        FROM    dbo.T_CCAccrued
                        WHERE   NoAccrued=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateSettle_hapus()

        Try
            Dim Query = "update settle_header set pay=0 from settle_header inner join cashbank on settle_header.settleID = right(replace(cashbank.noref,' ',''),15) where cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery_Solomon(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettleTravel_hapus()

        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "TravelRequestCost.ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "TravelRequestCost.ProsesUSD"
            Else
                prs = "TravelRequestCost.ProsesYEN"
            End If
            Dim Query = "update TravelRequestCost set " & prs & "=0 from TravelRequestCost inner join TSC16Application.dbo.cashbank on TravelRequestCost.NoRequest = right(replace(TSC16Application.dbo.cashbank.noref,' ',''),15) where  TravelRequestCost.CostType!='C03' AND  TSC16Application.dbo.cashbank.NoBukti=" & QVal(Me._id) & ""

            ''          Dim Query = "update TravelRequestCost set " & prs & " =1 where NoRequest=" & QVal(SettleID) & "  AND CostType!='C03'"
            MainModul.ExecQuery(Query)

            Dim Query2 = "update TravelTicket set pay=0 from TravelTicket inner join TSC16Application.dbo.cashbank on TravelTicket.NoVoucher = right(replace(TSC16Application.dbo.cashbank.noref,' ',''),15) where TSC16Application.dbo.cashbank.NoBukti=" & QVal(Me._id) & ""
            MainModul.ExecQuery(Query2)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateAdvanceTravel_hapus()

        Dim prs As String = ""
        Try
            If curyid = "IDR" Then
                prs = "TravelRequestCost.ProsesIDR"
            ElseIf curyid = "USD" Then
                prs = "TravelRequestCost.ProsesUSD"
            Else
                prs = "TravelRequestCost.ProsesYEN"
            End If
            Dim Query = "update TravelRequestCost set " & prs & "=0 from TravelRequestCost inner join TSC16Application.dbo.cashbank on TravelRequestCost.NoRequest = right(replace(TSC16Application.dbo.cashbank.noref,' ',''),15) where  TravelRequestCost.CostType='C03' AND  TSC16Application.dbo.cashbank.NoBukti=" & QVal(Me._id) & ""

            ''          Dim Query = "update TravelRequestCost set " & prs & " =1 where NoRequest=" & QVal(SettleID) & "  AND CostType!='C03'"
            MainModul.ExecQuery(Query)

        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateSettleCC_hapus()

        Try
            Dim Query = "update TSC16Application.dbo.settle_header set TSC16Application.dbo.settle_header.pay=0 FROM T_CCAccrued inner join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi where T_CCAccrued.NoAccrued=" & QVal(Noref) & ""
            MainModul.ExecQuery(Query)
            Dim Query2 = "update T_CCAccrued set pay=0 where NoAccrued=" & QVal(Noref) & ""
            MainModul.ExecQuery(Query2)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateTransfer_hapus()

        Try

            'Dim query2 As String = "DELETE FROM banktransfer " & vbCrLf &
            '"WHERE NoBukti=" & QVal(Noref.TrimEnd) & ""
            'Dim li_Row2 = MainModul.ExecQuery_Solomon(query2)
            Dim query2 As String = "DELETE banktransfer  FROM banktransfer inner join cashbank on  banktransfer.nobukti=right(replace(cashbank.noref,' ',''),15) " & vbCrLf &
" WHERE cashbank.NoBukti= " & QVal(Me._id) & " "
            Dim li_Row2 = MainModul.ExecQuery_Solomon(query2)
            Dim query As String = "DELETE cashbank2 from cashbank2 inner join (select Noref from cashbank2 where nobukti=" & QVal(Me._id) & ") as norep on norep.noref=cashbank2.Noref "

            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE cashbank  FROM cashbank inner join (select Noref from cashbank where nobukti=" & QVal(Me._id) & ")  as norep on norep.noref=cashbank.Noref "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateReceipt_hapus()

        Try


            Dim query2 As String = "DELETE bankreceipt  FROM bankreceipt inner join cashbank on  bankreceipt.nobukti=right(replace(cashbank.noref,' ',''),15) " & vbCrLf &
            " WHERE cashbank.NoBukti= " & QVal(Me._id) & " "
            Dim li_Row2 = MainModul.ExecQuery_Solomon(query2)

            Dim query As String = "DELETE FROM cashbank2 " & vbCrLf &
"WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            'Dim query1 As String = "DELETE FROM cashbank " & vbCrLf &
            '"WHERE Noref=" & QVal(Noref.TrimEnd) & ""
            'Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)

            Dim query1 As String = "DELETE FROM cashbank " & vbCrLf &
            "WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetGridDetailCashBankByAccountID() As DataTable
        Try
            Dim sql As String = "Select Tgl,NoBukti,Transaksi,Keterangan,Noref,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo FROM cashbank WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " order by nobukti"

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGridDetailSuspendByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "SELECT RTRIM([SubAcct]) SubAccount, RTRIM([AcctID]) Account,RTRIM(Description) Description,[Amount] Amount FROM suspend_detail WHERE SuspendID=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailCashBankByAccountID03(_NoBukti As String) As DataTable
        Try
            Dim sql As String = "Select Tgl,NoBukti,Transaksi,Keterangan,Noref,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,Masuk+Keluar as Amount FROM cashbank WHERE  NoBukti=" & QVal(_NoBukti) & " "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailCashBankByAccountID02() As DataTable
        Try
            '' Dim sql As String = "Select 0 as ID,Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,AcctID,cek as cek,recon  FROM cashbank2 WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " union select ID, Tgl,vrno as NoBukti, VendorName as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,cek5 as cek,'' as recon from Payment_Header1 where cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""
            ''    Dim sql As String = "Select 0 as ID,cashbank2.Tgl,cashbank2.NoBukti,cashbank2.Transaksi,cashbank2.SuspendAmount,cashbank2.SettleAmount,cashbank2.Masuk,cashbank2.Keluar,cashbank2.Saldo,cashbank2.AcctID,cashbank2.cek as cek,cashbank2.recon,cashbank.Keterangan,cashbank.Noref FROM cashbank2 cross apply (select top 1 cashbank.* from cashbank  where cashbank.NoBukti=cashbank2.NoBukti) as cashbank WHERE  cashbank2.perpost=" & QVal(Perpost) & " And cashbank2.acctid=" & QVal(AcctID) & " union select ID, Tgl,vrno as NoBukti, 'AP' as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-cm_dm-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,'1' as cek,'1' as recon,VendorName as Keterangan,'' as Noref from Payment_Header1 where cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""
            Dim sql As String = "Select 0 as ID,cashbank2.Tgl,cashbank2.NoBukti,cashbank2.Transaksi,cashbank2.SuspendAmount,cashbank2.SettleAmount,cashbank2.Masuk,cashbank2.Keluar,cashbank2.Saldo,cashbank2.AcctID,cashbank2.cek as cek,cashbank2.recon,RTRIM(cashbank.Keterangan) AS Keterangan,cashbank.Noref FROM cashbank2 cross apply (select top 1 cashbank.* from cashbank  where cashbank.NoBukti=cashbank2.NoBukti) as cashbank WHERE (cashbank2.Masuk!=cashbank2.Keluar) and cashbank2.Tgl<= GETDATE() AND cashbank2.perpost=" & QVal(Perpost) & " And cashbank2.acctid=" & QVal(AcctID) & " union select ID, Tgl,vrno as NoBukti, 'AP' as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-cm_dm-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,'1' as cek,'1' as recon,RTRIM(VendorName) as Keterangan,'' as Noref from Payment_Header1 where Tgl<= GETDATE() AND cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailCashBankReconsal() As DataTable
        Try
            '' Dim sql As String = "Select 0 as ID,Tgl,NoBukti,Transaksi,SuspendAmount,SettleAmount,Masuk,Keluar,Saldo,AcctID,cek as cek,recon  FROM cashbank2 WHERE  perpost=" & QVal(Perpost) & " And acctid=" & QVal(AcctID) & " union select ID, Tgl,vrno as NoBukti, VendorName as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,cek5 as cek,'' as recon from Payment_Header1 where cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""
            Dim sql As String = "Select 0 as ID,cashbank2.Tgl,cashbank2.NoBukti,cashbank2.Transaksi,cashbank2.SuspendAmount,cashbank2.SettleAmount,cashbank2.Masuk,cashbank2.Keluar,cashbank2.Saldo,cashbank2.AcctID,cashbank2.cek as cek,cashbank2.recon,cashbank.Keterangan FROM cashbank2 LEFT JOIN cashbank ON cashbank.NoBukti=cashbank2.NoBukti WHERE  cashbank2.perpost=" & QVal(Perpost) & " And cashbank2.acctid=" & QVal(AcctID) & " And cashbank2.recon=1 union select ID, Tgl,vrno as NoBukti, 'AP' as Transaksi,0 as SuspendAmount,0 as SettleAmount, 0 as Masuk,(total_dpp_ppn)-pph-Biaya_Transfer as Keluar, 0 as Saldo,bankid as AcctID,cek5 as cek,'' as recon,VendorName as Keterangan from Payment_Header1 where cek4=1 and substring(vrno,4,7)=" & QVal(Perpost) & " And bankid=" & QVal(AcctID) & ""
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
                "from cashbank2 " &
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
    Public Function autononbx() As String
        Try
            Dim bl As String
            Dim th As String
            th = Microsoft.VisualBasic.Left(Perpost, 4)
            bl = Microsoft.VisualBasic.Right(Perpost, 2)

            Dim auto2 As String
            Dim sql As String = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = " & QVal(bl) &
                "set @tahun =  " & QVal(th) &
                "set @seq= (select right('0000'+cast(right(rtrim(max(nobukti)),4)+1 as varchar),4) " &
                "from cashbank2 " &
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
    Public Function GetcuryAccountbyid() As String
        Try
            Dim curyaccount As String

            Dim sql As String = "SELECT 
	                                RTRIM(CuryId) CuryId FROM dbo.Account WHERE Acct = " & QVal(account) & ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)

            curyaccount = dt.Rows(0).Item(0).ToString

            Return curyaccount

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function saldo2() As Double
        Try
            Dim saldo As Double

            Dim sql As String = "Select isnull(saldo,0) as saldo from saldo_awal where acctid=" & QVal(account) & " and perpost=" & QVal(Perpost) & ""
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
    Public Function GetGridDetailTravelByAccountID() As DataTable
        Try

            ''            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S' AND suspend_header.Status='Approved' AND suspend_header.Currency=" & QVal(curyid) & ""
            Dim sql As String = "SELECT * FROM View_AdvTravel WHERE Amount>0"
            ''  Dim sql As String = "SELECT * FROM View_settTravel WHERE SettleAmount>0"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailTravelSETTByAccountID() As DataTable
        Try

            Dim sql As String = "SELECT * FROM View_settTravel WHERE Amount>0"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSuspendByAccountID() As DataTable
        Try

            ''            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S' AND suspend_header.Status='Approved' AND suspend_header.Currency=" & QVal(curyid) & ""
            Dim sql As String = "Select suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark As Description, suspend_header.total As Amount, '' as AcctID, suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'S' AND suspend_header.Status='Approved' "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountID() As DataTable
        Try
            ' Dim sql As String = "select settle_header.Tgl, settle_detail.SettleID, settle_header.SuspendID, settle_detail.Description,suspend_header.Total, settle_detail.SettleAmount, settle_detail.AcctID,suspend_header.BankID,settle_detail.Proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            Dim sql As String = "Select  settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark As Description,suspend_header.Total, sum(settle_detail.SettleAmount) As SettleAmount , '' as AcctID,suspend_header.BankID,settle_header.Proses, settle_header.CuryID from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0 AND settle_header.PaymentType='FINANCE' group by settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark,suspend_header.Total,suspend_header.BankID,settle_header.Proses, settle_header.CuryID"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountIDCC() As DataTable
        Try
            ' Dim sql As String = "select settle_header.Tgl, settle_detail.SettleID, settle_header.SuspendID, settle_detail.Description,suspend_header.Total, settle_detail.SettleAmount, settle_detail.AcctID,suspend_header.BankID,settle_detail.Proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            Dim sql As String = "Select  settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark As Description,suspend_header.Total, sum(settle_detail.SettleAmount) As SettleAmount , '' as AcctID,suspend_header.BankID,settle_header.Proses, settle_header.CuryID from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0 AND settle_header.PaymentType!='FINANCE' group by settle_header.Tgl, settle_header.SettleID, settle_header.SuspendID, settle_header.remark,suspend_header.Total,suspend_header.BankID,settle_header.Proses, settle_header.CuryID"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountIDCC2() As DataTable
        Try
            ' Dim sql As String = "select settle_header.Tgl, settle_detail.SettleID, settle_header.SuspendID, settle_detail.Description,suspend_header.Total, settle_detail.SettleAmount, settle_detail.AcctID,suspend_header.BankID,settle_detail.Proses from settle_header inner join  settle_detail on settle_detail.settleid=settle_header.settleid left join suspend_header on  settle_header.suspendid=suspend_header.suspendid  where settle_header.pay=0"
            '  Dim sql As String = "select NoAccrued , Tanggal, CreditCardNumber ,SUM(AmountIDR) as AmountIDR,'IDR' AS CuryID  from T_CCAccrued group by NoAccrued , Tanggal, CreditCardNumber"
            ''            Dim sql As String = "select T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CreditCardNumber,SUM(T_CCAccrued.AmountIDR) as AmountIDR,'IDR' AS CuryID,TSC16Application.dbo.settle_header.Proses from T_CCAccrued  inner join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi where TSC16Application.dbo.settle_header.pay=0 group by T_CCAccrued.NoAccrued, T_CCAccrued.CreditCardNumber, T_CCAccrued.Tanggal,TSC16Application.dbo.settle_header.Proses"
            '' Dim sql As String = "Select T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster As CreditCardNumber,SUM(T_CCAccrued.AmountIDR) As AmountIDR,'IDR' AS CuryID,TSC16Application.dbo.settle_header.Proses from T_CCAccrued  inner join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi where TSC16Application.dbo.settle_header.pay=0 group by T_CCAccrued.NoAccrued, T_CCAccrued.CCNumberMaster, T_CCAccrued.Tanggal,TSC16Application.dbo.settle_header.Proses"

            '            Dim sql As String = " Select T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster As CreditCardNumber,SUM(T_CCAccrued.AmountIDR) As AmountIDR,'IDR' AS CuryID,TSC16Application.dbo.settle_header.Proses into #cc
            'From T_CCAccrued  inner Join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi 
            'Where TSC16Application.dbo.settle_header.pay = 0
            'Group By T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster, TSC16Application.dbo.settle_header.Proses

            'Select #cc.NoAccrued, #cc.Tanggal, T_CCAccrued.CCNumberMaster As CreditCardNumber,sum(T_CCAccrued.AmountIDR) as AmountIDR,#cc.CuryID,#cc.Proses 
            'from #cc  inner join T_CCAccrued on T_CCAccrued.NoAccrued=#cc.NoAccrued
            'Group by #cc.NoAccrued,  #cc.Tanggal, T_CCAccrued.CCNumberMaster,#cc.CuryID, Proses"

            Dim sql As String = " CREATE TABLE #cc(
	NoAccrued char(50),
	Tanggal date NULL,
	CreditCardNumber char(50),
	AmountIDR float NULL,
	CuryID char(4) NULL,
Proses bit
);
            Select T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster As CreditCardNumber,SUM(T_CCAccrued.AmountIDR) As AmountIDR,'IDR' AS CuryID,TSC16Application.dbo.settle_header.Proses into #ck
From T_CCAccrued  inner Join TSC16Application.dbo.settle_header on TSC16Application.dbo.settle_header.SettleID=T_CCAccrued.NoTransaksi 
Where  T_CCAccrued.pay = 0
Group By T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster, TSC16Application.dbo.settle_header.Proses
Select T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster As CreditCardNumber,SUM(T_CCAccrued.AmountIDR) As AmountIDR,'IDR' AS CuryID,TravelSettleHeader.Pay as Proses into #cz
From T_CCAccrued  inner Join TravelSettleHeader On TravelSettleHeader.TravelSettleID=T_CCAccrued.NoTransaksi 
Where  T_CCAccrued.pay = 0
Group By T_CCAccrued.NoAccrued, T_CCAccrued.Tanggal, T_CCAccrued.CCNumberMaster, TravelSettleHeader.Pay
insert into #cc (NoAccrued, Tanggal, CreditCardNumber, AmountIDR, curyid, Proses)
Select * from #ck union Select * from #cz 
Select * from #cc "



            Dim dt As New DataTable
            dt = MainModul.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailSettleByAccountID4() As DataTable
        Try
            '' Dim sql As String = "Select  TravelTicket.Tanggal as Tgl, TravelTicket.NoVoucher, TravelTicket.vendor As Description, TravelTicket.TotAmount As SettleAmount ,TravelTicket.CuryID, '' as AcctID,TravelTicket.BankID,isnull(TravelTicket.Proses,0) as Proses from TravelTicket where isnull(TravelTicket.pay,0)=0 UNION SELECT * FROM View_SettTravel  WHERE Settleamount>0"
            Dim sql As String = "Select * From SETTLETRAVEL "
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Getsettle(NoRequest As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "settle2"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NoRequest", SqlDbType.VarChar)
            pParam(0).Value = ""


            dt = MainModul.GetDataTableByCommand_SP(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailEntertaintByAccountID() As DataTable
        Try
            '  Dim sql As String = "select  suspend_header.Tgl, suspend_detail.SuspendID, suspend_detail.Nama, suspend_detail.DeptID, suspend_detail.Tempat, suspend_detail.ALamat, suspend_detail.Jenis, suspend_detail.Amount, suspend_detail.AcctID, suspend_detail.Proses from suspend_header inner join  suspend_detail on suspend_detail.suspendid=suspend_header.suspendid where suspend_header.pay=0 and suspend_header.tipe = 'E'"

            '            Dim sql As String = "select  suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark as Description, suspend_header.DeptID, '' as Tempat, '' as ALamat, '' as Jenis, total as Amount, '' as AcctID,suspend_header.Proses from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'E' AND suspend_header.Status='Approved' AND suspend_header.Currency=" & QVal(curyid) & ""
            Dim sql As String = "select  suspend_header.Tgl, suspend_header.SuspendID, suspend_header.remark as Description, suspend_header.DeptID, '' as Tempat, '' as ALamat, '' as Jenis, total as Amount, '' as AcctID,suspend_header.Proses,suspend_header.Currency from suspend_header where suspend_header.pay=0 and suspend_header.tipe = 'E' AND suspend_header.Status='Approved' "

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Delete()
        Try
            Dim query As String = "DELETE FROM cashbank2 " & vbCrLf &
            "WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM cashbank " & vbCrLf &
            "WHERE NoBukti = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateCek()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE cashbank2 SET cek= " & QVal(cek) & " WHERE NoBukti=" & QVal(NoBukti.TrimEnd) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateCek2()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE cashbank2 SET cek= " & QVal(cek) & " WHERE Noref=" & QVal(Noref.TrimEnd) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Updatesaldo()
        Try
            '' Dim saldo2 As Double

            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE Saldo_Awal SET saldo= " & QVal(saldo3) & " WHERE acctid=" & QVal(account) & " and perpost=" & QVal(Perpost) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateRecon()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE cashbank2 SET recon= " & QVal(recon) & " WHERE NoBukti=" & QVal(NoBukti.TrimEnd) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
