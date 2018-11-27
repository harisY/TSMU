Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_Payment_putik
    Dim fp As Cls_Payment = New Cls_Payment()
    Dim cm As Cls_cmdm = New Cls_cmdm()

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim z As Integer
    Dim i As Integer
    Private strConn As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    ' Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection
    Dim total As String = 0
    Dim totalppn As String = 0
    Dim totalpph As String = 0
    Dim totaldpp As String = 0
    Dim totaldebit As String = 0
    Dim totalcmdm As String = 0
    Dim totalchk As Integer = 0
    Dim DataTable1 As New DataTable()
    Dim totalchk1 As String = 0

    Private Sub supplier()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplier()
            _VendID.DataSource = dtgrid
            _VendID.ValueMember = "VendID"
            _VendID.DisplayMember = "VendID"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub uploadbank()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadbank()
            _banknorek.DataSource = dtgrid
            _banknorek.ValueMember = "bank"
            _banknorek.DisplayMember = "bank"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub uploadnorek()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadbank()
            _norek.DataSource = dtgrid
            _norek.ValueMember = "norek"
            _norek.DisplayMember = "norek"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub banknorek()
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.detsupbybank()
    '        _banknorek.DataSource = dtgrid
    '        _banknorek.ValueMember = "banknorek"
    '        _banknorek.DisplayMember = "banknorek"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub norek()
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.detsupbynorek()
    '        _norek.DataSource = dtgrid
    '        _norek.ValueMember = "norek"
    '        _norek.DisplayMember = "norek"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub _Vend_Name_DropDown(sender As Object, e As EventArgs) Handles _Vend_Name.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplier()
            _Vend_Name.DataSource = dtgrid
            _Vend_Name.ValueMember = "Name"
            _Vend_Name.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _VendID_DropDown(sender As Object, e As EventArgs) Handles _VendID.DropDown
        supplier()
    End Sub

    Private Sub _VendID_LostFocus(sender As Object, e As EventArgs) Handles _VendID.LostFocus
        fp.VendID = _VendID.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyid2()
            _Vend_Name.Text = dtgrid.Rows(0).Item(0).ToString
            ''.Text = dtgrid.Rows(0).Item(1).ToString
            '' _jenis_jasa.Text = dtgrid.Rows(0).Item(1).ToString
            ''.Text = dtgrid.Rows(0).Item(3).ToString
            '_banknorek.Text = dtgrid.Rows(0).Item(2).ToString
            '_norek.Text = dtgrid.Rows(0).Item(1).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub _Vend_Name_LostFocus(sender As Object, e As EventArgs) Handles _Vend_Name.LostFocus
        fp.Vend_Name = _Vend_Name.Text
        fp.anorek = _norek.Text
        fp.abanknorek = _banknorek.Text
        fp.adetsupplier = _detsupplier.Text

        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyname2()
            _VendID.Text = dtgrid.Rows(0).Item(0).ToString
            '' _detsupplier.Text = _Vend_Name.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.detsupbynorek()
            _norek.Text = dtgrid.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.detsupbybank()
            _banknorek.Text = dtgrid.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub bank()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.bank()
            _BankID.DataSource = dtgrid
            _BankID.ValueMember = "BankAcct"
            _BankID.DisplayMember = "BankAcct"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub _BankName_DropDown(sender As Object, e As EventArgs) Handles _BankName.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.bank()
            _BankName.DataSource = dtgrid
            _BankName.ValueMember = "CashAcctName"
            _BankName.DisplayMember = "CashAcctName"
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _BankName_LostFocus(sender As Object, e As EventArgs) Handles _BankName.LostFocus
        fp.BankName = _BankName.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.bankbyname2()
            _BankID.Text = dtgrid.Rows(0).Item(0).ToString
            det()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _BankID_DropDown(sender As Object, e As EventArgs) Handles _BankID.DropDown
        bank()
    End Sub

    Private Sub _BankID_LostFocus(sender As Object, e As EventArgs) Handles _BankID.LostFocus
        fp.BankID = _BankID.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.bankbyid2()
            _BankName.Text = dtgrid.Rows(0).Item(0).ToString
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub det()
        fp.VendID = _VendID.Text
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)
            Dim sqlComm As New SqlCommand
            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "PROSES_VOUCHER_APNOTPAYYMENT"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlCon.Open()
            sqlComm.ExecuteNonQuery()
        End Using
        tampildata()
    End Sub


    Private Sub Frm_FP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _VocNo.Text = fp.autonopv
        perpost.Text = fp.autoperpost
        Me.Text = "PAYMENT - " & user1
        total = Format(Val(_Tot_Voucher.Text), "#,#.##")
        totalppn = Format(Val(_Tot_Ppn.Text), "#,#.##")
        totaldpp = Format(Val(_Tot_Dpp_Invoice.Text), "#,#.##")
        totalpph = Format(Val(_Tot_Pph.Text), "#,#.##")
        totalchk = Format(Val(_tot_chk.Text))

        _Tgl_fp.Text = Format(DateTime.Now)

        _Tot_Voucher.Text = Format(Val(_Tot_Voucher.Text), "#,#.##")
        _Tot_Ppn.Text = Format(Val(_Tot_Ppn.Text), "#,#.##")
        _Tot_Dpp_Invoice.Text = Format(Val(_Tot_Dpp_Invoice.Text), "#,#.##")
        _Tot_Pph.Text = Format(Val(_Tot_Pph.Text), "#,#.##")

        ''_detsupplier.Text = _Vend_Name.Text

        cleartext()
    End Sub

    Sub tampildata()
        '' DataGridView1.Columns.Remove(7)
        ' DataGridView1.Refresh()

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap2()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "InvcNbr"
                DataGridView1.Columns(0).Width = 90

                DataGridView1.Columns(1).HeaderText = "InvcDate"
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView1.Columns(2).HeaderText = "Amount"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "CuryId"
                DataGridView1.Columns(3).Width = 40

                DataGridView1.Columns(4).HeaderText = "PPN"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "DPP"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 80
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "PPh"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(7).HeaderText = "No.Bukti Potong"
                DataGridView1.Columns(7).Width = 140
                'Dim tax As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(tax)
                'tax.HeaderText = "TAX"
                'tax.Name = "tax"
                'tax.Width = 40
                'For j As Integer = 0 To DataGridView1.Rows.Count() - 1
                '    Dim b As Boolean
                '    b = DataGridView1.Rows(j).Cells(8).Value = True
                '    If DataGridView1.Rows(j).Cells(6).Value > 0 Then
                '        DataGridView1.Rows(j).Cells(8).Value = True
                '        tax.Selected = True
                '        tax.ReadOnly = True
                '    End If
                'Next

                'Dim rel As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(rel)
                'rel.HeaderText = "RELEASER"
                'rel.Name = "rel"
                'rel.Width = 80

                'For i As Integer = 0 To DataGridView1.Rows.Count() - 1
                '    Dim c As Boolean
                '    c = DataGridView1.Rows(i).Cells(9).Value = True
                '    DataGridView1.Rows(i).Cells(9).Value = True
                '    rel.Selected = True
                '    rel.ReadOnly = True
                'Next

                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                chk.HeaderText = "CHECK 1"
                chk.Name = "chk"
                chk.Width = 80


                'Dim chk2 As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(chk2)
                'chk2.HeaderText = "CHECK 2"
                'chk2.Name = "chk2"
                'chk2.Width = 80

                'Dim paid As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(paid)
                'paid.HeaderText = "PAID"
                'paid.Name = "paid"
                'paid.Width = 50



            End If

            'ButtonUpdate.Dock = DockStyle.Bottom
            'ButtonUpdate.Text = "Update"
            'AddHandler ButtonUpdate.Click, AddressOf cek_Click
            'Me.Controls.Add(ButtonUpdate)
            'DataGridView1.Dock = DockStyle.Fill
            'Me.Controls.Add(DataGridView1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub dt2()
        Try
            DataGridView2.Refresh()
            DataGridView2.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = cm.datadt2()
            DataGridView2.DataSource = dtgrid
            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView2.Rows.Count >= 0 Then
                'DataGridView2.Columns(0).HeaderText = "No. Voucher"
                'DataGridView2.Columns(0).Width = 120

                'DataGridView2.Columns(1).HeaderText = "Bank Name"
                'DataGridView1.Columns(1).Width = 250

                'DataGridView2.Columns(2).HeaderText = "Supplier"
                'DataGridView2.Columns(2).Width = 170

                DataGridView2.Columns(0).HeaderText = "Date"
                DataGridView2.Columns(0).Width = 80
                DataGridView2.Columns(0).DefaultCellStyle.Format = "dd-MM-yyyy"

                'DataGridView2.Columns(1).HeaderText = "Keterangan"
                'DataGridView2.Columns(1).Width = 170

                DataGridView2.Columns(1).HeaderText = "Cury ID"
                DataGridView2.Columns(1).Width = 80

                DataGridView2.Columns(2).HeaderText = "Batch"
                DataGridView2.Columns(2).Width = 80
                DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView2.Columns(3).HeaderText = "No. Invoice"
                DataGridView2.Columns(3).Width = 100
                DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView2.Columns(4).HeaderText = "Total CMDM"
                DataGridView2.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView2.Columns(4).Width = 150
                DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView2.Columns.Add(chk)
                '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                chk.HeaderText = "PILIH"
                chk.Name = "chk"
                chk.Width = 80
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cek_Click(sender As Object, e As EventArgs) Handles cek.Click
        fp.VendID = _VendID.Text
        _tot_chk.Text = 0
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)
            Dim sqlComm As New SqlCommand
            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "PROSES_VOUCHER_APNOTPAYYMENT1"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlCon.Open()
            sqlComm.ExecuteNonQuery()
        End Using

        tampildata()
        dt2()
    End Sub

    Sub cleartext()
        _VocNo.Text = fp.autonopv
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"

        _jenis_jasa.Text = ""
        _detsupplier.Text = ""
        _banknorek.Text = ""
        _norek.Text = ""
        _penerima.Text = ""

        total = 0
        totalppn = 0
        totaldpp = 0
        totalpph = 0
        _Tot_Voucher.Text = 0
        _tot_cndn.Text = 0
        _Tot_Ppn.Text = 0
        _Tot_Dpp_Invoice.Text = 0
        _Tot_Pph.Text = 0
        _debit_bank.Text = 0
        _tot_chk.Text = 0

        '     DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
        DataGridView2.Columns.Clear()
        DataGridView2.Refresh()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        _VocNo.Text = fp.autonopv2
        ''_VocNo.Text = fp.autonopv
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"

        _jenis_jasa.Text = ""

        _banknorek.Text = ""
        _norek.Text = ""
        _detsupplier.Text = ""
        _penerima.Text = ""

        total = 0
        totalppn = 0
        totaldpp = 0
        totalpph = 0
        _Tot_Voucher.Text = 0
        _tot_cndn.Text = 0
        _Tot_Ppn.Text = 0
        _Tot_Dpp_Invoice.Text = 0
        _Tot_Pph.Text = 0
        _debit_bank.Text = 0
        _tot_chk.Text = 0
        ''countchk()

        '     DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
        DataGridView2.Columns.Clear()
        DataGridView2.Refresh()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 Then
            Frm_invoice.StartPosition = FormStartPosition.CenterScreen
            Frm_invoice._invcnbr.Text = DataGridView1.SelectedRows(0).Cells(0).Value
            Frm_invoice.ShowDialog()

        End If
        If e.ColumnIndex = 8 Then

            If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
                DataGridView1.SelectedRows(0).Cells(8).Value = False
            Else
                DataGridView1.SelectedRows(0).Cells(8).Value = True
            End If



            If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
                total = total + DataGridView1.SelectedRows(0).Cells(2).Value
                totalppn = totalppn + DataGridView1.SelectedRows(0).Cells(4).Value
                totaldpp = totaldpp + DataGridView1.SelectedRows(0).Cells(5).Value
                totalpph = totalpph + DataGridView1.SelectedRows(0).Cells(6).Value
                totaldebit = totaldebit - totalcmdm
                ''totalchk = totalchk - DataGridView1.SelectedRows(0).Cells(8).Value
                totalchk = _tot_chk.Text - DataGridView1.SelectedRows(0).Cells(8).Value
            Else
                total = total - DataGridView1.SelectedRows(0).Cells(2).Value
                totalppn = totalppn - DataGridView1.SelectedRows(0).Cells(4).Value
                totaldpp = totaldpp - DataGridView1.SelectedRows(0).Cells(5).Value
                totalpph = totalpph - DataGridView1.SelectedRows(0).Cells(6).Value
                totaldebit = totaldebit + totalcmdm
                totalchk = _tot_chk.Text - 1

            End If



            _Tot_Voucher.Text = Format(Val(total), "#,#.##")
            _Tot_Ppn.Text = Format(Val(totalppn), "#,#.##")
            _Tot_Dpp_Invoice.Text = Format(Val(totaldpp), "#,#.##")
            _Tot_Pph.Text = Format(Val(totalpph), "#,#.##")
            _tot_cndn.Text = totalcmdm
            _debit_bank.Text = Format(Val(total - _Biaya_Transfer.Text - totalcmdm), "#,#.##")
            _tot_chk.Text = totalchk

            'Dim chkok As Integer = 0
            'If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
            '    chkok += 1
            'End If
        End If
    End Sub

    Sub usergetobject()
        fp.voucno = _VocNo.Text
        fp.tgl_fp = _Tgl_fp.Text
        fp.BankID = _BankID.Text
        fp.BankName = _BankName.Text
        fp.VendID = _VendID.Text
        fp.Vend_Name = _Vend_Name.Text
        fp.jenis_jasa = _jenis_jasa.Text

        fp.CuryID = _curyid.Text
        fp.Tot_Dpp_Invoice = _Tot_Dpp_Invoice.Text
        fp.Tot_ppn = _Tot_Ppn.Text
        fp.Tot_voucher = _Tot_Voucher.Text
        fp.Tot_pph = _Tot_Pph.Text
        fp.Biaya_Transfer = _Biaya_Transfer.Text
        fp.cm_dm = _tot_cndn.Text
        fp.adetsupplier = _detsupplier.Text
        fp.abanknorek = _banknorek.Text
        fp.anorek = _norek.Text
        fp.acuryid = _curyid.Text
        fp.apenerima = _penerima.Text
        ''cm.batch = DataGridView2.SelectedRows(0).Cells(2).Value.ToString
    End Sub

    Sub updatedt2()
        Try
            Dim dtGrid As DataTable = New DataTable
            dtGrid = cm.updatedt2()
            DataGridView1.DataSource = dtGrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            MsgBox(ex.Message)
            If ex.InnerException IsNot Nothing Then
                MsgBox(ex.InnerException)
            End If
        End Try
    End Sub

    Sub update1()
        Try
            Dim dtGrid As DataTable = New DataTable
            dtGrid = cm.update1()
            DataGridView1.DataSource = dtGrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            MsgBox(ex.Message)
            If ex.InnerException IsNot Nothing Then
                MsgBox(ex.InnerException)
            End If
        End Try
    End Sub

    'Sub update2()
    '    Try
    '        Dim dtGrid As DataTable = New DataTable
    '        dtGrid = cm.update2()
    '        DataGridView1.DataSource = dtGrid
    '        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        If ex.InnerException IsNot Nothing Then
    '            MsgBox(ex.InnerException)
    '        End If
    '    End Try
    'End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        'Try
        '    If DataGridView1.Rows.Count > 0 Then
        '        For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '            If DataGridView1.Rows(i).Cells(8).Value = -1 Then
        '                '' z = 0 - DataGridView1.Rows(i).Cells(8).Value
        '                '' MsgBox(z)
        '                z = z + 1
        '            End If
        '        Next i

        '    End If
        'Catch ex As Exception

        'End Try

        ''z = 0 - z
        ''MsgBox(z)
        If user1 <> "putik" Then
            If z <> DataGridView1.Rows.Count Then
                usergetobject()
                fp.updatedatasolomon2()
                fp.deletedatacek()
                fp.insertdata2()
            Else
                usergetobject()
                fp.updatedatasolomon2()
                fp.deletedatacek()
                fp.insertdata()
            End If
        Else
            usergetobject()

            fp.updatedatasolomon2()
            fp.deletedatacek()
            fp.insertdata()
        End If
        ''For Each row As DataGridViewRow In DataGridView1.Rows

        Dim constring As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        ''Dim constring As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
        Using con As New SqlConnection(constring)

            '               Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)", con)
            'Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur)", con)

            con.Open()
            Try
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(8).Value = True Then
                        Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1)", con)
                            cmd.Parameters.AddWithValue("@No_Invoice", DataGridView1.Rows(i).Cells(0).Value)
                            cmd.Parameters.AddWithValue("@Tgl_Invoice", DataGridView1.Rows(i).Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Jml_Invoice", DataGridView1.Rows(i).Cells(2).Value)
                            cmd.Parameters.AddWithValue("@CuryID", DataGridView1.Rows(i).Cells(3).Value)
                            cmd.Parameters.AddWithValue("@Ppn1", DataGridView1.Rows(i).Cells(4).Value)
                            cmd.Parameters.AddWithValue("@Dpp", DataGridView1.Rows(i).Cells(5).Value)
                            cmd.Parameters.AddWithValue("@Pph1", DataGridView1.Rows(i).Cells(6).Value)
                            cmd.Parameters.AddWithValue("@No_Faktur", RTrim(DataGridView1.Rows(i).Cells(7).Value))
                            'cmd.Parameters.AddWithValue("@tax1", row.Cells(8).Value)
                            'cmd.Parameters.AddWithValue("@releaser", row.Cells(9).Value)
                            cmd.Parameters.AddWithValue("@cek1", DataGridView1.Rows(i).Cells(8).Value)
                            'cmd.Parameters.AddWithValue("@cek2", row.Cells(9).Value)
                            ' con.Open()
                            ' MsgBox("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)")
                            cmd.ExecuteNonQuery()
                        End Using

                        'ElseIf DataGridView1.Rows(i).Cells(8).Value = False Then
                        '    Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1)", con)
                        '        cmd.Parameters.AddWithValue("@No_Invoice", DataGridView1.Rows(i).Cells(0).Value)
                        '        cmd.Parameters.AddWithValue("@Tgl_Invoice", DataGridView1.Rows(i).Cells(1).Value)
                        '        cmd.Parameters.AddWithValue("@Jml_Invoice", DataGridView1.Rows(i).Cells(2).Value)
                        '        cmd.Parameters.AddWithValue("@CuryID", DataGridView1.Rows(i).Cells(3).Value)
                        '        cmd.Parameters.AddWithValue("@Ppn1", DataGridView1.Rows(i).Cells(4).Value)
                        '        cmd.Parameters.AddWithValue("@Dpp", DataGridView1.Rows(i).Cells(5).Value)
                        '        cmd.Parameters.AddWithValue("@Pph1", DataGridView1.Rows(i).Cells(6).Value)
                        '        cmd.Parameters.AddWithValue("@No_Faktur", RTrim(DataGridView1.Rows(i).Cells(7).Value))
                        '        'cmd.Parameters.AddWithValue("@tax1", row.Cells(8).Value)
                        '        'cmd.Parameters.AddWithValue("@releaser", row.Cells(9).Value)
                        '        cmd.Parameters.AddWithValue("@cek1", DataGridView1.Rows(i).Cells(8).Value)
                        '        'cmd.Parameters.AddWithValue("@cek2", row.Cells(9).Value)
                        '        ' con.Open()
                        '        ' MsgBox("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)")
                        '        cmd.ExecuteNonQuery()
                        '    End Using


                    End If

   
    ' con.Close()

                Next i

    ' transaction.Commit()
    '' MessageBox.Show("Data Berhasil Disimpan")
            Catch ex As Exception
    'MsgBox(ex.Message)
        End Try
        End Using
    ''Next

    ''Dim constring As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    'Using con As New SqlConnection(constring)

    '    con.Open()
    '    Try
    '        Dim query As String
    '        Dim invcnbr As String
    '        For i As Integer = 0 To Me.DataGridView1.Rows.Count
    '            invcnbr = Me.DataGridView1.Rows(i).Cells(0).Value.ToString
    '            query = "update apdoc set user4=1 where invcnbr='" & invcnbr & "' and cek1='" & invcnbr & "' "
    '            mdlmain.ExecQueryByCommand(query)

    '            'Dim bit As String
    '            'bit = DataGridView1.SelectedCells(7).Value

    '        Next
    '    Catch ex As Exception
    '        ''Throw
    '    End Try
2:
    'End Using

        MessageBox.Show("Records inserted.")
    ''fp.deletedatacek()
        If _Tot_Voucher.Text = _Tot_Voucher.Text Then
            fp.updatedatasolomon()
        End If
        fp.updatedataheader()
        fp.updatepropay()
        fp.updateup()
        If DataGridView2.Rows.Count > 0 Then
            update1()
        End If
        cleartext()
        _VocNo.Text = fp.autonopv2
        _tot_chk.Text = 0
    End Sub



   



    Sub tampildata12()

        Try

            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap_det3()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then

                DataGridView1.Columns(0).HeaderText = "InvcNbr"
                DataGridView1.Columns(0).Width = 90

                DataGridView1.Columns(1).HeaderText = "InvcDate"
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView1.Columns(2).HeaderText = "Amount"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "CuryId"
                DataGridView1.Columns(3).Width = 40

                DataGridView1.Columns(4).HeaderText = "PPN"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "DPP"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 80
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "PPh"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(7).HeaderText = "No. Bukti Potong"
                DataGridView1.Columns(7).Width = 140


                'Dim chk3 As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(chk3)

                'chk3.HeaderText = "CHECK 1"
                'chk3.Name = "chk3"
                'chk3.Width = 80

                'If user1 = "maria" Then
                '    For i As Integer = 0 To DataGridView1.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = DataGridView1.Rows(i).Cells(8).Value = True
                '        DataGridView1.Rows(i).Cells(8).Value = True
                '        chk3.Selected = True
                '    Next
                'End If

                'Dim chk2 As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(chk2)
                'chk2.HeaderText = "CHECK 2"
                'chk2.Name = "chk2"
                'chk2.Width = 80

                'Dim tax As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(tax)
                'tax.HeaderText = "TAX"
                'tax.Name = "tax"
                'tax.Width = 40

                'Dim rel As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(rel)

                'rel.HeaderText = "RELEASER"
                'rel.Name = "rel"
                'rel.Width = 80

                'For i As Integer = 0 To DataGridView1.Rows.Count() - 1
                '    Dim c As Boolean
                '    c = DataGridView1.Rows(i).Cells(9).Value = True
                '    DataGridView1.Rows(i).Cells(9).Value = True
                '    rel.Selected = True
                '    rel.ReadOnly = True
                'Next

                'Dim chk3 As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(chk3)

                'chk3.HeaderText = "CHECK 1"
                'chk3.Name = "chk"
                'chk3.Width = 80

                'Dim chk2 As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(chk2)
                'chk2.HeaderText = "CHECK 2"
                'chk2.Name = "chk2"
                'chk2.Width = 80

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub tampildt2()
        Try
            DataGridView2.Refresh()
            DataGridView2.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = cm.dt2()
            DataGridView2.DataSource = dtgrid
            DataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView2.Rows.Count > 0 Then
                'DataGridView2.Columns(0).HeaderText = "No. Voucher"
                'DataGridView2.Columns(0).Width = 120

                'DataGridView2.Columns(1).HeaderText = "Bank Name"
                'DataGridView1.Columns(1).Width = 250

                'DataGridView2.Columns(2).HeaderText = "Supplier"
                'DataGridView2.Columns(2).Width = 170

                DataGridView2.Columns(0).HeaderText = "Date"
                DataGridView2.Columns(0).Width = 80
                DataGridView2.Columns(0).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView2.Columns(1).HeaderText = "Keterangan"
                DataGridView2.Columns(1).Width = 170

                DataGridView2.Columns(2).HeaderText = "Cury ID"
                DataGridView2.Columns(2).Width = 80

                DataGridView2.Columns(3).HeaderText = "Batch"
                DataGridView2.Columns(3).Width = 80
                DataGridView2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView2.Columns(4).HeaderText = "No. Invoice"
                DataGridView2.Columns(4).Width = 100
                DataGridView2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView2.Columns(5).HeaderText = "Total CMDM"
                DataGridView2.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView2.Columns(5).Width = 140
                DataGridView2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView2.Columns.Add(chk)
                '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                chk.HeaderText = "PILIH"
                chk.Name = "chk"
                chk.Width = 80
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub _VocNo_TextChanged(sender As Object, e As EventArgs) Handles _VocNo.TextChanged
        fp.voucno = _VocNo.Text
        tampildata12()
        dt2()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Frm_filter_payment2.StartPosition = FormStartPosition.CenterScreen
        Frm_filter_payment2.ShowDialog()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.ColumnIndex = 5 Then

            If DataGridView2.SelectedRows(0).Cells(5).Value = True Then
                DataGridView2.SelectedRows(0).Cells(5).Value = False
            Else
                DataGridView2.SelectedRows(0).Cells(5).Value = True
            End If

            If DataGridView2.SelectedRows(0).Cells(5).Value = True Then
                ''totalcmdm = DataGridView2.SelectedRows(0).Cells(5).Value
                totalcmdm = totalcmdm + DataGridView2.SelectedRows(0).Cells(4).Value
                totaldebit = totaldebit - totalcmdm
            Else
                ''totalcmdm = DataGridView2.SelectedRows(0).Cells(5).Value
                totalcmdm = totalcmdm - DataGridView2.SelectedRows(0).Cells(4).Value
                totaldebit = totaldebit + totalcmdm
            End If

            'If DataGridView2.SelectedRows(0).Cells(7).Value = True Then
            '    totalcmdm = DataGridView2.SelectedRows(0).Cells(6).Value
            'Else
            '    totalcmdm = DataGridView2.SelectedRows(0).Cells(7).Value = False
            'End If

            _tot_cndn.Text = totalcmdm
            ''_debit_bank.Text = Format(Val(totaldebit), "#,#.##")
            _debit_bank.Text = Format(Val(total - _Biaya_Transfer.Text - totalcmdm), "#,#.##")

        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        '    If DataGridView1.Rows.Count > 0 Then
        '        For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '            If DataGridView1.Rows(i).Cells(8).Value = -1 Then
        '                '' z = 0 - DataGridView1.Rows(i).Cells(8).Value
        '                '' MsgBox(z)
        '                z = z + 1
        '            End If
        '        Next i

        '    End If
        'Catch ex As Exception

        'End Try

        ''z = 0 - z
        ''MsgBox(z)
        If user1 = "putik" Then
            If z = DataGridView1.Rows.Count Then
                usergetobject()
                fp.updatedatasolomon2()
                fp.deletedatacek()
                fp.insertdata2()
            Else
                usergetobject()
                fp.updatedatasolomon2()
                fp.deletedatacek()
                fp.insertdata()
            End If
        Else
            usergetobject()
            fp.updatedatasolomon2()
            fp.deletedatacek()
            fp.insertdata()
        End If
        ''For Each row As DataGridViewRow In DataGridView1.Rows

        Dim constring As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        ''Dim constring As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
        Using con As New SqlConnection(constring)

            '               Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)", con)
            'Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur)", con)

            con.Open()
            Try
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(i).Cells(8).Value = True Then
                        Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1)", con)
                            cmd.Parameters.AddWithValue("@No_Invoice", DataGridView1.Rows(i).Cells(0).Value)
                            cmd.Parameters.AddWithValue("@Tgl_Invoice", DataGridView1.Rows(i).Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Jml_Invoice", DataGridView1.Rows(i).Cells(2).Value)
                            cmd.Parameters.AddWithValue("@CuryID", DataGridView1.Rows(i).Cells(3).Value)
                            cmd.Parameters.AddWithValue("@Ppn1", DataGridView1.Rows(i).Cells(4).Value)
                            cmd.Parameters.AddWithValue("@Dpp", DataGridView1.Rows(i).Cells(5).Value)
                            cmd.Parameters.AddWithValue("@Pph1", DataGridView1.Rows(i).Cells(6).Value)
                            cmd.Parameters.AddWithValue("@No_Faktur", DataGridView1.Rows(i).Cells(7).Value)
                            'cmd.Parameters.AddWithValue("@tax1", row.Cells(8).Value)
                            'cmd.Parameters.AddWithValue("@releaser", row.Cells(9).Value)
                            cmd.Parameters.AddWithValue("@cek1", DataGridView1.Rows(i).Cells(8).Value)
                            'cmd.Parameters.AddWithValue("@cek2", row.Cells(9).Value)
                            ' con.Open()
                            ' MsgBox("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)")
                            cmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' con.Close()

                Next i

                ' transaction.Commit()
                '' MessageBox.Show("Data Berhasil Disimpan")
            Catch ex As Exception
            End Try
        End Using
        ''Next
        MessageBox.Show("Records inserted.")
        ''fp.deletedatacek()
        fp.updatedatasolomon()
        fp.updatedataheader()
        If DataGridView2.Rows.Count > 0 Then
            update1()
        End If
        cleartext()
        _VocNo.Text = fp.autonopv2
        _tot_chk.Text = 0
    End Sub



    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub perpost_TextChanged(sender As Object, e As EventArgs) Handles perpost.TextChanged
        fp.perpost = perpost.Text
        _VocNo.Text = fp.autonopv2
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles _tot_chk.TextChanged
        ''countchk()
    End Sub

    Sub countchk()
        'If DataGridView1.Rows.Count > 0 Then
        '    Dim intcheckboxesChecked As Integer = 0
        '    For Each chk As Windows.Forms.Control In Me.Controls
        '        If TypeOf chk Is System.Windows.Forms.CheckBox Then
        '            Dim ck As System.Windows.Forms.CheckBox = chk
        '            If ck.Checked Then
        '                intcheckboxesChecked += 1
        '            End If
        '        End If
        '    Next
        'End If
        Dim chkok As Integer = 0
        If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
            chkok = +1
        End If
    End Sub

    Private Sub _norek_DropDown(sender As Object, e As EventArgs) Handles _norek.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadnorek()
            _norek.DataSource = dtgrid
            _norek.ValueMember = "norek"
            _norek.DisplayMember = "norek"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _banknorek_DropDown(sender As Object, e As EventArgs) Handles _banknorek.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadbank()
            _banknorek.DataSource = dtgrid
            _banknorek.ValueMember = "bank"
            _banknorek.DisplayMember = "bank"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _norek_LostFocus(sender As Object, e As EventArgs) Handles _norek.LostFocus
        fp.anorek = _norek.Text
        fp.Vend_Name = _Vend_Name.Text
        ''_detsupplier.Text = _Vend_Name.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.norek()
            _detsupplier.Text = dtgrid.Rows(0).Item(0).ToString
            _banknorek.Text = dtgrid.Rows(0).Item(2).ToString
            _penerima.Text = dtgrid.Rows(0).Item(3).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _banknorek_LostFocus(sender As Object, e As EventArgs) Handles _banknorek.LostFocus
        fp.abanknorek = _banknorek.Text
        fp.Vend_Name = _Vend_Name.Text
        '_detsupplier.Text = _Vend_Name.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.banknorek()
            _detsupplier.Text = dtgrid.Rows(0).Item(0).ToString
            _norek.Text = dtgrid.Rows(0).Item(1).ToString
            _penerima.Text = dtgrid.Rows(0).Item(3).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _detsupplier_DropDown(sender As Object, e As EventArgs) Handles _detsupplier.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.nameforbank1()
            _detsupplier.DataSource = dtgrid
            _detsupplier.ValueMember = "namedetail"
            _detsupplier.DisplayMember = "namedetail"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _detsupplier_LostFocus(sender As Object, e As EventArgs) Handles _detsupplier.LostFocus
        fp.adetsupplier = _detsupplier.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadbank()
            _norek.Text = dtgrid.Rows(0).Item(1).ToString
            _banknorek.Text = dtgrid.Rows(0).Item(2).ToString
            _penerima.Text = dtgrid.Rows(0).Item(3).ToString
            '_detsupplier.Text = _Vend_Name.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _penerima_DropDown(sender As Object, e As EventArgs) Handles _penerima.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.uploadbank()
            _penerima.DataSource = dtgrid
            _penerima.ValueMember = "name1"
            _penerima.DisplayMember = "name1"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _penerima_LostFocus(sender As Object, e As EventArgs) Handles _penerima.LostFocus
        fp.anorek = _norek.Text
        fp.Vend_Name = _Vend_Name.Text
        ''_detsupplier.Text = _Vend_Name.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.penerima()
            _detsupplier.Text = dtgrid.Rows(0).Item(0).ToString
            _banknorek.Text = dtgrid.Rows(0).Item(2).ToString
            _norek.Text = dtgrid.Rows(0).Item(1).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


End Class