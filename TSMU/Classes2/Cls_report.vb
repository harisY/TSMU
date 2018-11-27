Imports System.Data
Imports System.Data.SqlClient
Public Class Cls_report
    Dim query As String = String.Empty

    Private tglawal As Date
    Public Property TanggalAwal() As Date
        Get
            Return tglawal
        End Get
        Set(ByVal value As Date)
            tglawal = value
        End Set
    End Property

    Private tglakhir As Date
    Public Property TanggalAkhir() As Date
        Get
            Return tglakhir
        End Get
        Set(ByVal value As Date)
            tglakhir = value
        End Set
    End Property


    Private tglawal1 As Date
    Public Property TanggalAwal1() As Date
        Get
            Return tglawal1
        End Get
        Set(ByVal value As Date)
            tglawal1 = value
        End Set
    End Property

    Private tglakhir1 As Date
    Public Property TanggalAkhir1() As Date
        Get
            Return tglakhir1
        End Get
        Set(ByVal value As Date)
            tglakhir1 = value
        End Set
    End Property


    Private _bankname As String
    Public Property BankName() As String
        Get
            Return _bankname
        End Get
        Set(ByVal value As String)
            _bankname = value
        End Set
    End Property

    Private _supplier As String
    Public Property supplier() As String
        Get
            Return _supplier
        End Get
        Set(ByVal value As String)
            _supplier = value
        End Set
    End Property

    Public Function FilterBydate() As DataTable
        Try
            TanggalAwal = Frm_Lap_Pajak.dt1.Text + " 00:00:00"
            TanggalAkhir = Frm_Lap_Pajak.dt2.Text + " 00:00:00"


            '' query = "SELECT kdJenisTransaksi,fgPengganti,nomorFaktur,tanggalFaktur,npwpPenjual,namaPenjual,alamatPenjual ,jumlahDpp,jumlahPpn,jumlahPpnBm,masapajak,tahunpajak,ling  FROM barcode_fp where CONVERT(datetime,RIGHT([tanggalFaktur],4)+SUBSTRING([tanggalFaktur],4,2)+LEFT([tanggalFaktur],2))  >= '" & TanggalAwal & "' AND CONVERT(datetime,RIGHT([tanggalFaktur],4)+SUBSTRING([tanggalFaktur],4,2)+LEFT([tanggalFaktur],2))  <= '" & TanggalAkhir & "'  "
            query = "select 'FM' as FM,kdJenisTransaksi,fgPengganti,nomorFaktur,tanggalFaktur,npwpPenjual,namaPenjual,alamatPenjual ,jumlahDpp,jumlahPpn,jumlahPpnBm,masapajak,tahunpajak from Fp_Header inner join Fp_detail on Fp_Header.fpno=Fp_detail.fpno inner join barcode_fp on REPLACE(REPLACE(substring(Fp_detail.No_Faktur,4,16),'-',''),'.','')=substring(barcode_fp.nomorFaktur,1,13)  where Fp_Header.Tgl_fp  >= '" & TanggalAwal & "' AND Fp_Header.Tgl_fp  <= '" & TanggalAkhir & "'  "

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function tampilpayment() As DataSet
        Dim query As String
        query = "select " & _
                  "Payment_Header1.VendorName VendorName, " & _
                  "Payment_Detail1.No_Invoice No_Invoice, " & _
                  "Payment_Detail1.DPP DPP, " & _
                  "payment_Detail1.PPN PPN, " & _
                  "(Payment_Detail1.DPP + payment_Detail1.PPN) as Total, " & _
                  "payment_Detail1.pph, " & _
                  "(Payment_Detail1.DPP + payment_Detail1.PPN + payment_Detail1.pph) as Grand_Total, " & _
                  "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                  "(Payment_Detail1.DPP + payment_Detail1.PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar, " & _
                  "payment_header1.vrno vrno " & _
                  "from Payment_Header1 inner join Payment_Detail1 on Payment_Header1.vrno=Payment_detail1.vrno "
        

        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "pay")
        Return ds
    End Function

    Public Function tampilpaytgl() As DataSet
        Dim query As String
        '   TanggalAwal = Frm_RptPayment.dt1.Text + " 00:00:00"
        '  TanggalAkhir = Frm_RptPayment.dt2.Text + " 00:00:00"

        query = "select " & _
                  "Payment_Header1.VendorName VendorName, " & _
                  "Payment_Header1.tgl tgl, " & _
                  "Payment_Detail1.No_Invoice No_Invoice, " & _
                  "Payment_Detail1.DPP DPP, " & _
                  "payment_Detail1.PPN PPN, " & _
                  "(Payment_Detail1.DPP + payment_Detail1.PPN) as Total, " & _
                  "payment_Detail1.pph, " & _
                  "(Payment_Detail1.Jml_Invoice - payment_header1.pph)  as Grand_Total, " & _
                  "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                  "(Payment_Detail1.Jml_Invoice - payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar, " & _
                  "payment_header1.vrno vrno " & _
                  "from Payment_Header1 inner join Payment_Detail1 on Payment_Header1.vrno=Payment_detail1.vrno " & _
                  "where Payment_Header1.tgl >= '" & TanggalAwal & "' AND Payment_Header1.tgl <= '" & TanggalAkhir & "' order by Payment_Header1.VendorName,payment_header1.vrno"

        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "pay")
        Return ds
    End Function

    Public Function mizuhotgl() As DataSet
        Dim query As String
        '  TanggalAwal1 = Frm_Report_UploadMizuho.dt1.Text + " 00:00:00"
        '  TanggalAkhir1 = Frm_Report_UploadMizuho.dt2.Text + " 00:00:00"

        query = "select " & _
                  "uploadmizuho1.ref_no_sup ref_no_sup, " & _
                  "uploadmizuho1.takagi_acct takagi_acct, " & _
                  "uploadmizuho1.rek_pt rek_pt, " & _
                  "uploadmizuho1.payment_method payment_method, " & _
                  "uploadmizuho1.curyid curyid, " & _
                  "(Payment_Header1.Total_DPP_PPN-Payment_Header1.pph-Payment_Header1.CM_DM-Payment_Header1.Biaya_Transfer) as trans_amount, " & _
                  "Payment_Header1.tgl as value_date, " & _
                  "uploadmizuho1.bankname bankname, " & _
                  "uploadmizuho1.branch branch, " & _
                  "uploadmizuho1.address address, " & _
                  "uploadmizuho1.address2 address2, " & _
                  "uploadmizuho1.pt pt, " & _
                  "uploadmizuho1.pt2 pt2, " & _
                  "uploadmizuho1.address_pt address_pt , " & _
                  "uploadmizuho1.address_pt2 address_pt2, " & _
                  "uploadmizuho1.space_kosong space_kosong, " & _
                  "uploadmizuho1.bank_charges bank_charges, " & _
                  "uploadmizuho1.applicant_acct applicant_acct, " & _
                  "uploadmizuho1.space_kosong2 space_kosong2, " & _
                  "uploadmizuho1.other other, " & _
                  "uploadmizuho1.other1 other1, " & _
                  "uploadmizuho1.other2 other2, " & _
                  "uploadmizuho1.other3 other3 " & _
                  "FROM uploadmizuho1 inner join payment_header1 on uploadmizuho1.ref_no_sup = Payment_Header1.detsupplier  " & _
                  "where Payment_Header1.tgl >='" & TanggalAwal1 & "' AND Payment_Header1.tgl <='" & TanggalAkhir1 & "' order by uploadmizuho1.ref_no_sup "

        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "mizuho")
        Return ds
    End Function



    Public Function tampilpaytglheader() As DataSet
        Dim query As String
        '  TanggalAwal = Frm_RptPayment.dta.Text + " 00:00:00"
        '  TanggalAkhir = Frm_RptPayment.dtb.Text + " 00:00:00"

        query = "select vrno, tgl, vendorname, tot_DPP, tot_PPN, " & _
                "(Tot_DPP + Tot_PPN + pph) as Total, pph, ((Tot_DPP + Tot_PPN + pph) - pph)  as Grand_Total, " & _
                "biaya_transfer, (((Tot_DPP + Tot_PPN + pph) - pph)- cm_dm - Biaya_Transfer) as Total_Bayar " & _
                "from Payment_Header1 " & _
                 "where tgl >= '" & TanggalAwal & "' AND tgl <= '" & TanggalAkhir & "'  order by VendorName,vrno"

        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "payheader")
        Return ds
    End Function

    Public Function tampilpayheadercari() As DataSet
        Dim query As String
        'TanggalAwal = Frm_RptPayment.dtcari1.Text + " 00:00:00"
        ' TanggalAkhir = Frm_RptPayment.dtcari2.Text + " 00:00:00"
        ' supplier = Frm_RptPayment._Vend_Name.Text

        query = "select vrno, tgl, vendorname, tot_DPP, tot_PPN, " & _
                 "(Tot_DPP + Tot_PPN + pph) as Total, pph, ((Tot_DPP + Tot_PPN + pph) - pph)  as Grand_Total, " & _
                 "biaya_transfer, (((Tot_DPP + Tot_PPN + pph) - pph) - cm_dm - Biaya_Transfer) as Total_Bayar " & _
                 "from Payment_Header1 " & _
                  "where tgl >= '" & TanggalAwal & "' AND tgl <= '" & TanggalAkhir & "' and VendorName='" & supplier & "'  order by Payment_Header1.VendorName,payment_header1.vrno"

        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "payheader")
        Return ds
    End Function

    Public Function getalldatabank() As DataTable
        'TanggalAwal = Frm_periode.DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        TanggalAwal = frm_bank._TglPay.Text
        BankName = frm_bank._BankName.Text
        Try
            'query = "select " & _
            '      "payment_header1.vrno vrno, " & _
            '      "Payment_Header1.VendorName VendorName, " & _
            '      "Payment_Detail1.No_Invoice No_Invoice, " & _
            '      "payment_Detail1.PPN PPN, " & _
            '      "payment_Detail1.pph pph, " & _
            '      "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
            '      "(Payment_Detail1.DPP + payment_Detail1.PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
            '      "from Payment_Header1 inner join Payment_Detail1 on Payment_Header1.vrno=Payment_detail1.vrno " & _
            '      "where Payment_Header1.tgl ='" & TanggalAwal & "' and BankName='" & BankName & "' order by payment_header1.vendorname,paymnt_header1.vrno"

            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "((Payment_Header1.Total_DPP_PPN + payment_header1.pph)- pph - cm_dm - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
                 "from Payment_Header1 " & _
                 "where Payment_Header1.tgl ='" & TanggalAwal & "' and BankName='" & BankName & "' and cek1='1' and cek2='1' order by payment_header1.vendorname,payment_header1.vrno"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function getalldatabankdg() As DataTable
        'TanggalAwal = Frm_periode.DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        TanggalAwal = frm_bank._TglPay.Text
        BankName = frm_bank._BankName.Text
        Try
            'query = "select " & _
            '      "payment_header1.vrno vrno, " & _
            '      "Payment_Header1.VendorName VendorName, " & _
            '      "Payment_Detail1.No_Invoice No_Invoice, " & _
            '      "payment_Detail1.PPN PPN, " & _
            '      "payment_Detail1.pph pph, " & _
            '      "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
            '      "(Payment_Detail1.DPP + payment_Detail1.PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
            '      "from Payment_Header1 inner join Payment_Detail1 on Payment_Header1.vrno=Payment_detail1.vrno " & _
            '      "where Payment_Header1.tgl ='" & TanggalAwal & "' and BankName='" & BankName & "' order by payment_header1.vendorname,paymnt_header1.vrno"

            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "(Payment_Header1.Total_DPP_PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
                 "from Payment_Header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' " & _
                 "order by payment_header1.vendorname,payment_header1.vrno"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function getalldatabank1() As DataSet
        ''TanggalAwal = Frm_periode.DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        '  TanggalAwal = Frm_RptBank._TglPay.Text
        ' BankName = Frm_RptBank._BankName.Text

        Try
            '    query = "select " & _
            '          "payment_header1.vrno vrno, " & _
            '          "Payment_Header1.VendorName VendorName, " & _
            '          "Payment_Detail1.No_Invoice No_Invoice, " & _
            '          "payment_Detail1.PPN PPN, " & _
            '          "payment_Detail1.pph pph, " & _
            '          "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
            '          "(Payment_Detail1.DPP + payment_Detail1.PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
            '          "from Payment_Header1 inner join Payment_Detail1 on Payment_Header1.vrno=Payment_detail1.vrno " & _
            '          "where Payment_Header1.tgl ='" & TanggalAwal & "'  and BankName='" & BankName & "' order by payment_header1.vendorname,paymnt_header1.vrno"

            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "((Payment_Header1.Total_DPP_PPN + payment_header1.pph) - pph - cm_dm - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
                 "from Payment_Header1 " & _
                 "where Payment_Header1.tgl ='" & TanggalAwal & "' and BankName='" & BankName & "' and cek1='1' and cek2='1' order by payment_header1.vendorname,payment_header1.vrno"

            Dim ds As New DataSet1
            ds = GetDataSetByCommand1(query, "bank")
            Return ds
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getalldatabankcrall() As DataSet
        ''TanggalAwal = Frm_periode.DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        ' TanggalAwal = Frm_RptBank._TglPay.Text
        ' BankName = Frm_RptBank._BankName.Text

        Try
            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "(Payment_Header1.Total_DPP_PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar " & _
                 "from Payment_Header1 where cek1='1' and cek2='1' and cek3='0' and cek4='0' " & _
                 "order by payment_header1.vendorname,payment_header1.vrno"

            Dim ds As New DataSet1
            ds = GetDataSetByCommand1(query, "bank")
            Return ds
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getalldataperiodebank() As DataTable
        TanggalAwal = Frm_periode._TglPay1.Text + " 00:00:00"
        TanggalAkhir = Frm_periode._TglPay2.Text + " 00:00:00"
        ''BankName = Frm_periode._BankName.Text

        Try
            query = "select distinct bankid,bankname,tgl from payment_header1 " & _
                  "where tgl >='" & TanggalAwal & "' AND tgl <= '" & TanggalAkhir & "' order by tgl"


            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function


    
    Public Function getalldataupload() As DataSet
        Dim query As String

        query = "SELECT    perpost, docbal, BankID, cashsub, refnbr1, vrno, tgl, VendId, origdocamt, RefNbr, curydocbal FROM dataupload " & _
                "where prosespay='1' order by vrno,vendid"
        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "dataupload")
        Return ds
    End Function

    Public Function getalldatasuspend() As DataSet
        Dim query As String

        query = "SELECT    perpost, docbal, BankID, cashsub, refnbr1, vrno, tgl, VendId, origdocamt, RefNbr, curydocbal FROM dataupload " & _
                "where prosespay='1' order by vrno,vendid"
        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "dataupload")
        Return ds
    End Function

    Public Function getalldatauploadbytgl() As DataSet
        Dim query As String
        '   TanggalAwal = Frm_RptUpload.dt1.Text + " 00:00:00"
        '   TanggalAkhir = Frm_RptUpload.dt2.Text + " 00:00:00"

        query = "SELECT     CONVERT(VARCHAR(6), tgl, 112) AS tgl1, docbal, BankID, cashsub, refnbr1, vrno, tgl, VendId, origdocamt, RefNbr, curydocbal FROM dataupload " & _
                "where tgl >='" & TanggalAwal & "' AND tgl <='" & TanggalAkhir & "' and prosespay='1' and cek1='1' order by vrno,vendid"
        Dim ds As New DataSet1
        ds = GetDataSetByCommand1(query, "dataupload")
        Return ds
    End Function


    Public Function getalldatauploadgrid() As DataTable
        Dim query As String
        Try
            'query = "SELECT    vrno,vendorname,perpost, docbal, BankID, cashsub, refnbr1, RefNbr, tgl, origdocamt, curydocbal, prosespay  FROM dataupload " & _
            ' "order by vendorname,vrno"
            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "(Payment_Header1.Total_DPP_PPN + payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar, " & _
                  "Payment_Header1.prosespay prosespay " & _
                 "from Payment_Header1 where cek1='1' and cek2='1' and prosespay='0' and prosespay='' " & _
                 "order by payment_header1.vendorname,payment_header1.vrno"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getalldatauploadgridbytgl() As DataTable
        Dim query As String
        TanggalAwal = FormRptUpload1.dt1.Text + " 00:00:00"
        TanggalAkhir = FormRptUpload1.dt2.Text + " 00:00:00"
        Try
            'query = "SELECT    vrno,vendorname,perpost, docbal, BankID, cashsub, refnbr1, RefNbr, tgl, origdocamt, curydocbal, prosespay  FROM dataupload " & _
            '"where tgl >='" & TanggalAwal & "' AND tgl <='" & TanggalAkhir & "' " & _
            '"order by vendorname,vrno"

            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "(Payment_Header1.Total_DPP_PPN + payment_header1.pph - payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar, " & _
                 "Payment_Header1.prosespay prosespay " & _
                 "from Payment_Header1 where cek1='1' and cek2='1' " & _
                 "and tgl >='" & TanggalAwal & "' AND tgl <='" & TanggalAkhir & "'  and prosespay='0' and prosespay='' " & _
                 "order by payment_header1.vendorname,payment_header1.vrno"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function getalldatauploadgridbytglsdhpilih() As DataTable
        Dim query As String
        TanggalAwal = FormRptUpload1.dt1a.Text + " 00:00:00"
        TanggalAkhir = FormRptUpload1.dt2b.Text + " 00:00:00"
        Try
            'query = "SELECT    vrno,vendorname,perpost, docbal, BankID, cashsub, refnbr1, RefNbr, tgl, origdocamt, curydocbal, prosespay  FROM dataupload " & _
            '"where tgl >='" & TanggalAwal & "' AND tgl <='" & TanggalAkhir & "' " & _
            '"order by vendorname,vrno"

            query = "select " & _
             "payment_header1.vrno vrno, " & _
                 "Payment_Header1.VendorName VendorName, " & _
                 "Payment_Header1.Total_DPP_PPN, " & _
                 "payment_Header1.Tot_PPN Tot_PPN, " & _
                 "payment_Header1.pph pph, " & _
                 "Payment_Header1.Biaya_Transfer Biaya_Transfer, " & _
                 "(Payment_Header1.Total_DPP_PPN + payment_header1.pph - payment_header1.pph - Payment_Header1.Biaya_Transfer) as Total_Bayar, " & _
                 "Payment_Header1.prosespay prosespay " & _
                 "from Payment_Header1 where cek1='1' and cek2='1' " & _
                 "and tgl >='" & TanggalAwal & "' AND tgl <='" & TanggalAkhir & "'  and prosespay='1' " & _
                 "order by payment_header1.vendorname,payment_header1.vrno"

            Dim dt As DataTable = New DataTable
            dt = mdlmain.GetDataTableByCommand(query)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function


End Class
