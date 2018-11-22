Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_Payment
    Dim query As String = String.Empty
    Dim query1 As String = String.Empty
    Dim query2 As String = String.Empty
    Dim query3 As String = String.Empty

    Dim chek1 As String = String.Empty
    Dim chek2 As String = String.Empty
    Dim chek3 As String = String.Empty
    Dim chek4 As String = String.Empty
    ''Dim prosespay As String = String.Empty

    Private _txtcari As String
    Public Property txtcari() As String
        Get
            Return _txtcari
        End Get
        Set(ByVal value As String)
            _txtcari = value
        End Set
    End Property

    Private _cmbcari As String
    Public Property cmbcari() As String
        Get
            Return _cmbcari
        End Get
        Set(ByVal value As String)
            _cmbcari = value
        End Set
    End Property

    Private _Fp As String
    Public Property Fp() As String
        Get
            Return _Fp
        End Get
        Set(ByVal value As String)
            _Fp = value
        End Set
    End Property

    Private _VendID As String
    Public Property VendID() As String
        Get
            Return _VendID
        End Get
        Set(ByVal value As String)
            _VendID = value
        End Set
    End Property

    Private _tahun As String
    Public Property tahun() As String
        Get
            Return _tahun
        End Get
        Set(ByVal value As String)
            _tahun = value
        End Set
    End Property

    Private _bulan As String
    Public Property bulan() As String
        Get
            Return _bulan
        End Get
        Set(ByVal value As String)
            _bulan = value
        End Set
    End Property

    Private _voucno As String
    Public Property voucno() As String
        Get
            Return _voucno
        End Get
        Set(ByVal value As String)
            _voucno = value
        End Set
    End Property
    Private _invcnbr As String
    Public Property invcnbr() As String
        Get
            Return _invcnbr
        End Get
        Set(ByVal value As String)
            _invcnbr = value
        End Set
    End Property
    Private _tgl_fp As String
    Public Property tgl_fp() As DateTime
        Get
            Return _tgl_fp
        End Get
        Set(ByVal value As DateTime)
            _tgl_fp = value
        End Set
    End Property

    Private _Vend_Name As String
    Public Property Vend_Name() As String
        Get
            Return _Vend_Name
        End Get
        Set(ByVal value As String)
            _Vend_Name = value
        End Set
    End Property

    Private _jenis_jasa As String
    Public Property jenis_jasa() As String
        Get
            Return _jenis_jasa
        End Get
        Set(ByVal value As String)
            _jenis_jasa = value
        End Set
    End Property

    Private _BankID As String
    Public Property BankID() As String
        Get
            Return _BankID
        End Get
        Set(ByVal value As String)
            _BankID = value
        End Set
    End Property
    Private _CuryID As String
    Public Property CuryID() As String
        Get
            Return _CuryID
        End Get
        Set(ByVal value As String)
            _CuryID = value
        End Set
    End Property

    Private _npwp As String
    Public Property npwp() As String
        Get
            Return _npwp
        End Get
        Set(ByVal value As String)
            _npwp = value
        End Set
    End Property

    Private _nama_vendor As String
    Public Property nama_vendor() As String
        Get
            Return _nama_vendor
        End Get
        Set(ByVal value As String)
            _nama_vendor = value
        End Set
    End Property

    Private _BankName As String
    Public Property BankName() As String
        Get
            Return _BankName
        End Get
        Set(ByVal value As String)
            _BankName = value
        End Set
    End Property
    Private _pph As String
    Public Property pph() As String
        Get
            Return _pph
        End Get
        Set(ByVal value As String)
            _pph = value
        End Set
    End Property
    Private _tarif As String
    Public Property tarif() As String
        Get
            Return _tarif
        End Get
        Set(ByVal value As String)
            _tarif = value
        End Set
    End Property

    Private _Tot_Dpp_Invoice As String
    Public Property Tot_Dpp_Invoice() As String
        Get
            Return _Tot_Dpp_Invoice
        End Get
        Set(ByVal value As String)
            _Tot_Dpp_Invoice = value
        End Set
    End Property

    Private _Tot_ppn As String
    Public Property Tot_ppn() As String
        Get
            Return _Tot_ppn
        End Get
        Set(ByVal value As String)
            _Tot_ppn = value
        End Set
    End Property

    Private _Tot_voucher As String
    Public Property Tot_voucher() As String
        Get
            Return _Tot_voucher
        End Get
        Set(ByVal value As String)
            _Tot_voucher = value
        End Set
    End Property

    Private _Tot_pph As String
    Public Property Tot_pph() As String
        Get
            Return _Tot_pph
        End Get
        Set(ByVal value As String)
            _Tot_pph = value
        End Set
    End Property

    Private _status As String
    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _ket_pph As String
    Public Property ket_pph() As String
        Get
            Return _ket_pph
        End Get
        Set(ByVal value As String)
            _ket_pph = value
        End Set
    End Property

    Private _lokasi As String
    Public Property lokasi() As String
        Get
            Return _lokasi
        End Get
        Set(ByVal value As String)
            _lokasi = value
        End Set
    End Property
    Private _pphid As String
    Public Property pphid() As String
        Get
            Return _pphid
        End Get
        Set(ByVal value As String)
            _pphid = value
        End Set
    End Property
    Private _No_Bukti_Potong As String
    Public Property No_Bukti_Potong() As String
        Get
            Return _No_Bukti_Potong
        End Get
        Set(ByVal value As String)
            _No_Bukti_Potong = value
        End Set
    End Property


    Private _invtid As String
    Public Property invtid() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property

    Private _descr As String
    Public Property descr() As String
        Get
            Return _descr
        End Get
        Set(ByVal value As String)
            _descr = value
        End Set
    End Property

    Private _dpp As String
    Public Property dpp() As String
        Get
            Return _dpp
        End Get
        Set(ByVal value As String)
            _dpp = value
        End Set
    End Property
    Private _ket_dpp As String
    Public Property ket_dpp() As String
        Get
            Return _ket_dpp
        End Get
        Set(ByVal value As String)
            _ket_dpp = value
        End Set
    End Property
    Private _No_Faktur As String
    Public Property No_Faktur() As String
        Get
            Return _No_Faktur
        End Get
        Set(ByVal value As String)
            _No_Faktur = value
        End Set
    End Property
    Private _Biaya_Transfer As String
    Public Property Biaya_Transfer() As String
        Get
            Return _Biaya_Transfer
        End Get
        Set(ByVal value As String)
            _Biaya_Transfer = value
        End Set
    End Property
    Private _cm_dm As String
    Public Property cm_dm() As String
        Get
            Return _cm_dm
        End Get
        Set(ByVal value As String)
            _cm_dm = value
        End Set
    End Property

    Private _tglawal As Date
    Public Property tglawal() As Date
        Get
            Return _tglawal
        End Get
        Set(ByVal value As Date)
            _tglawal = value
        End Set
    End Property

    Private _tglakhir As Date
    Public Property tglakhir() As Date
        Get
            Return _tglakhir
        End Get
        Set(ByVal value As Date)
            _tglakhir = value
        End Set
    End Property
    Private _prosespay As String
    Public Property prosespay() As String
        Get
            Return _prosespay
        End Get
        Set(ByVal value As String)
            _prosespay = value
        End Set
    End Property
    Private _vrno As String
    Public Property vrno() As String
        Get
            Return _vrno
        End Get
        Set(ByVal value As String)
            _vrno = value
        End Set
    End Property

    Public Function supplier() As DataTable

        Try
            query = "Select VendID, Name FROM Vendor"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyid() As String
        Try
            Dim VendID1 As String
            query = "Select remitname,taxregnbr,user1 FROM Vendor where VendID='" & _VendID & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            VendID1 = dt.Rows(0).Item(0).ToString
            Return VendID1

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyid2() As DataTable
        Try

            query = "Select name,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where VendID='" & _VendID & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function supplierbyname2() As DataTable
        Try

            query = "Select VendID,taxregnbr,user1,ltrim(rtrim(remitname)) as remitname FROM Vendor where Name='" & _Vend_Name & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function supplierbyname() As String
        Try
            Dim VendID2 As String
            query = "Select VendID,taxregnbr,user1 FROM Vendor where Name='" & _Vend_Name & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            VendID2 = dt.Rows(0).Item(0).ToString
            Return VendID2

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function bank() As DataTable

        Try
            query = "select BankAcct,CashAcctName from cashacct"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function bankbyname2() As DataTable
        Try

            query = "Select BankAcct,CashAcctName from cashacct where CashAcctName='" & _BankName & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function bankbyid2() As DataTable
        Try

            query = "Select CashAcctName from cashacct where BankAcct='" & _BankID & "'"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt


        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function autonopv() As String
        Try
            Dim auto As String
            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " & _
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " & _
                "set @tahun = datepart(year,getdate()) " & _
                "set @seq= (select right('0000'+cast(right(rtrim(max(vrno)),4)+1 as varchar),4) " & _
                "from Payment_Header1 " & _
                "where SUBSTRING(vrno,4,4) = RIGHT(@tahun,4) AND SUBSTRING(vrno,9,2) = RIGHT(@bulan,2)) " & _
                "select 'AP' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldataap2() As DataTable
        Try

            query2 = "SELECT InvcNbr,	InvcDate,		sum(Amount) as Amount,	CuryId,	sum(Ppn) as Ppn,	sum(Amount_before) as DPP,sum(Pph) AS PPH,fp FROM FP_temp2 where VendId='" & _VendID & "'" & _
                     "group by  InvcNbr,	InvcDate,	CuryId, fp   order by InvcNbr"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query2)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub insertdata()

        Tot_Dpp_Invoice = Tot_Dpp_Invoice.Replace(",", "")

        Tot_pph = Tot_pph.Replace(",", "")

        Tot_ppn = Tot_ppn.Replace(",", "")

        Tot_voucher = Tot_voucher.Replace(",", "")

        Try

            query = "delete from Payment_Header1 where vrno = '" & voucno & "'"
            mdlmain.ExecQueryByCommand(query)
            If user1 = "putik" Then
                chek1 = "1"
                chek2 = "0"
                chek3 = "0"
                chek4 = "0"
            ElseIf user1 = "maria" Then
                chek1 = "1"
                chek2 = "1"
                chek3 = "0"
                chek4 = "0"
            ElseIf user1 = "yamada" Then
                chek1 = "1"
                chek2 = "1"
                chek3 = "1"
                chek4 = "0"
            Else
                chek1 = "1"
                chek2 = "1"
                chek3 = "1"
                chek4 = "1"
            End If
            query = "INSERT INTO Payment_Header1 (vrno,tgl,BankID,BankName,VendID,VendorName,Descr,CuryID,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,cek1,cek2,cek3,cek4) " & _
                    "VALUES ('" & voucno & "'" & _
                       ",'" & tgl_fp & "'" & _
                       ",'" & BankID & "'" & _
                       ",'" & BankName & "'" & _
                       ",'" & VendID & "'" & _
                       ",'" & Vend_Name & "'" & _
                       ",'" & descr & "'" & _
                       ",'" & CuryID & "'" & _
                       ",'" & Tot_Dpp_Invoice & "'" & _
                       ",'" & Tot_ppn & "'" & _
                       ",'" & Tot_voucher & "'" & _
                       ",'" & Tot_pph & "'" & _
                       ",'" & Biaya_Transfer & "'" & _
                       ",'" & cm_dm & "'" & _
                       ",'" & chek1 & "'" & _
                       ",'" & chek2 & "'" & _
                       ",'" & chek3 & "'" & _
                       ",'" & chek4 & "') "
            mdlmain.ExecQueryByCommand(query)

            '' query = "update apdoc set user3=1 where InvcNbr in (select no_invoice from fp_detail) "
            ''  mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub
    Public Sub deletedatacek()
        Try
            query = "delete from Payment_Header1 where vrno='" & voucno & "'"
            mdlmain.ExecQueryByCommand(query)
            query = "delete from Payment_Detail1 where vrno='" & voucno & "'"
            mdlmain.ExecQueryByCommand(query)

        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub updatedatasolomon()

        Try

            query = "update apdoc set user4=1 where InvcNbr in (select no_invoice from Payment_detail1) "
            mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub

    Public Sub updatedataheader()

        Try
            query = "UPDATE t1 SET t1.tot_dpp = t2.dpp,t1.tot_ppn = t2.ppn,t1.pph = t2.pph,t1.total_dpp_ppn =t2.dpp+t2.ppn-t1.pph " & _
                    "FROM Payment_Header1 as t1 " & _
                    "INNER JOIN (select vrno, SUM(dpp) AS dpp,SUM(ppn) AS ppn,SUM(pph) AS pph " & _
                    "From Payment_Detail1 where cek1=1 group by vrno) as t2 on t2.vrno=t1.vrno "

            mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub
    Public Sub updatedatasolomon2()

        Try

            query = "update apdoc set user4=0 where InvcNbr in (select no_invoice from Payment_detail1) "
            mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub
    Public Function getalldata3() As DataTable

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If user1 = "putik" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,(Total_DPP_PPN+PPh)-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='0' and cek2='0' and cek3='0' and cek4='0' order by vendorname, no_voucher"
            ElseIf user1 = "maria" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,(Total_DPP_PPN+PPh)-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='0' and cek3='0' and cek4='0' order by vendorname, no_voucher"
            ElseIf user1 = "yamada" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,(Total_DPP_PPN+PPh)-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' order by vendorname, no_voucher"
            Else
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,(Total_DPP_PPN-pph)-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' order by vendorname, no_voucher"
            End If

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function updatepph() As DataTable

        Try
            query = "UPDATE t1 SET t1.tot_dpp = t2.dpp,t1.tot_ppn = t2.ppn,t1.pph = t2.pph,t1.total_dpp_ppn =t2.dpp+t2.ppn+t2.pph-t2.pph " & _
                    "FROM Payment_Header1 as t1 " & _
                    "INNER JOIN (select vrno, SUM(dpp) AS dpp,SUM(ppn) AS ppn,SUM(pph) AS pph " & _
                    "From Payment_Detail1 where cek1=1 group by vrno) as t2 on t2.vrno=t1.vrno "

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldata3b() As DataTable
        tglawal = Frm_Filter_payment.dt1.Text + " 00:00:00"
        tglakhir = Frm_Filter_payment.dt2.Text + " 00:00:00"

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If user1 = "putik" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='0' and cek2='0' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' order by vendorname, no_voucher"
            ElseIf user1 = "maria" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='0' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' order by vendorname, no_voucher"
            ElseIf user1 = "yamada" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' order by vendorname, no_voucher"
            Else
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' order by vendorname, no_voucher"
            End If

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldatatglandsupplier() As DataTable
        tglawal = Frm_Filter_payment.dt1a.Text + " 00:00:00"
        tglakhir = Frm_Filter_payment.dt2a.Text + " 00:00:00"
        Vend_Name = Frm_Filter_payment._Vend_Name1.Text

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If user1 = "putik" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='0' and cek2='0' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            ElseIf user1 = "maria" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='0' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            ElseIf user1 = "yamada" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            ElseIf Vend_Name = "ALL" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' order by vendorname, no_voucher"
            Else
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-cm_dm-Biaya_Transfer as Amount, cek1 as Putik, cek2 as Maria, cek3 as Yamada, cek4 as Suratno from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' and tgl >= '" & tglawal & "' AND Payment_Header1.tgl <= '" & tglakhir & "' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"



            End If

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldatavrno() As DataTable

        voucno = Frm_Filter_payment._vrno.Text

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If user1 = "putik" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='0' and cek2='0' and cek3='0' and cek4='0' and vrno like '" & voucno & "' order by vendorname, no_voucher"
            ElseIf user1 = "maria" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='0' and cek3='0' and cek4='0' and vrno like '" & voucno & "' order by vendorname, no_voucher"
            ElseIf user1 = "yamada" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' and vrno like '" & voucno & "' order by vendorname, no_voucher"
            Else
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' and vrno like '" & voucno & "' order by vendorname, no_voucher"
            End If

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldatasupplier() As DataTable

        Vend_Name = Frm_Filter_payment._Vend_Name.Text

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"
            If user1 = "putik" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='0' and cek2='0' and cek3='0' and cek4='0' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            ElseIf user1 = "maria" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='0' and cek3='0' and cek4='0' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            ElseIf user1 = "yamada" Then
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            Else
                query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh-pph-Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 where cek1='1' and cek2='1' and cek3='1' and cek4='0' and vendorname like '" & Vend_Name & "' order by vendorname, no_voucher"
            End If

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getalldata3a() As DataTable

        Try
            '' query = "Select vrno as No_Voucher,VendorName as Supplier,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek3 as Check1, cek4 as Check2 from payment_header1"

            query = "Select vrno  as No_Voucher,tgl,BankID,BankName,VendID,VendorName as Supplier,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,Total_DPP_PPN+PPh+Biaya_Transfer as Amount, cek1 as Check1, cek2 as Check2, cek3 as Check3, cek4 as Direktur from payment_header1 order by no_voucher, vendorname"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function getalldataap_det2() As DataTable
        Try

            query = "Select APTran.InvtID,APTran.TranDesc,SUM(APTran.CuryTranAmt) AS Amount from APTran inner join APDoc on APDoc.BatNbr=APTran.BatNbr " & _
        "WHERE DocType='VO' and APTran.LineType='R' AND APTran.RefNbr=APDoc.RefNbr AND  APDoc.Invcnbr='" & invcnbr & "' " & _
        "GROUP BY APTran.InvtID,APTran.TranDesc"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Sub insertdata2()

        Tot_Dpp_Invoice = Tot_Dpp_Invoice.Replace(",", "")

        Tot_pph = Tot_pph.Replace(",", "")

        Tot_ppn = Tot_ppn.Replace(",", "")

        Tot_voucher = Tot_voucher.Replace(",", "")

        Try

            query = "delete from Payment_Header1 where vrno = '" & voucno & "'"
            mdlmain.ExecQueryByCommand(query)

            chek1 = "0"
            chek2 = "0"
            chek3 = "0"
            chek4 = "0"

            query = "INSERT INTO Payment_Header1 (vrno,tgl,BankID,BankName,VendID,VendorName,Descr,CuryID,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,cek1,cek2,cek3,cek4) " & _
                    "VALUES ('" & voucno & "'" & _
                       ",'" & tgl_fp & "'" & _
                       ",'" & BankID & "'" & _
                       ",'" & BankName & "'" & _
                       ",'" & VendID & "'" & _
                       ",'" & Vend_Name & "'" & _
                       ",'" & descr & "'" & _
                       ",'" & CuryID & "'" & _
                       ",'" & Tot_Dpp_Invoice & "'" & _
                       ",'" & Tot_ppn & "'" & _
                       ",'" & Tot_voucher & "'" & _
                       ",'" & Tot_pph & "'" & _
                       ",'" & Biaya_Transfer & "'" & _
                       ",'" & cm_dm & "'" & _
                       ",'" & chek1 & "'" & _
                       ",'" & chek2 & "'" & _
                       ",'" & chek3 & "'" & _
                       ",'" & chek4 & "') "
            mdlmain.ExecQueryByCommand(query)

            '' query = "update apdoc set user3=1 where InvcNbr in (select no_invoice from fp_detail) "
            ''  mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw

        End Try
    End Sub
    Public Function getalldataap_det3() As DataTable

        Try

            query = "select no_invoice as NoinvcNbr, tgl_invoice as InvcDate,Jml_invoice as Amount,CuryID,PPN,DPP,PPh,No_Faktur as 'No. Bukti Potong',cek1 as cek from payment_detail1 " & _
                   "WHERE vrno='" & voucno & "' "

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub updatealluploadgrid()

        Dim query As String

        'Dim idList(5)
        'For Each selectedItem As DataGridViewRow In FormRptUpload1.DataGridView1.SelectedRows
        '    'show ids of multiple selected rows
        '    id = selectedItem.Cells(7).Value

        '    idList(i) = id
        '    If FormRptUpload1.DataGridView1.SelectedRows(i).Cells(7).Value = True Then
        '        FormRptUpload1.DataGridView1.SelectedRows(i).Cells(7).Value = False
        '    Else
        '        FormRptUpload1.DataGridView1.SelectedRows(i).Cells(7).Value = True
        '    End If
        'Dim TotalRecords As Integer = FormRptUpload1.DataGridView1.RowCount - 1
        'For i As Integer = 0 To TotalRecords
        '    If FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = False Then
        '        FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = True
        '    Else
        '        FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = True
        '    End If
        '    prosespay = FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value
        '    vrno = FormRptUpload1.DataGridView1.Rows(i).Cells(0).Value
        'Next i
        
        'For i As Integer = 0 To FormRptUpload1.DataGridView1.Rows.Count
        '    If FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = False Then
        '        FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = True
        '    Else
        '        FormRptUpload1.DataGridView1.Rows(i).Cells(7).Value = True
        '    End If

        '    i += 1
        Dim i As Integer
        prosespay = FormRptUpload1.DataGridView1.SelectedRows(i).Cells(7).Value.ToString
        voucno = FormRptUpload1.DataGridView1.SelectedRows(i).Cells(0).Value.ToString

        Try
            query = "update payment_header1 set prosespay='" & prosespay & "' " & _
                    "where vrno='" & voucno & "'"
            mdlmain.ExecQueryByCommand(query)
        Catch ex As Exception
            Throw
        End Try

    End Sub
End Class
