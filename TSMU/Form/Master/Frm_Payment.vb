Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_Payment
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
    Dim DataTable1 As New DataTable()

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
            _jenis_jasa.Text = dtgrid.Rows(0).Item(2).ToString
            ''.Text = dtgrid.Rows(0).Item(3).ToString

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

    Private Sub _Vend_Name_LostFocus(sender As Object, e As EventArgs) Handles _Vend_Name.LostFocus

        fp.Vend_Name = _Vend_Name.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyname2()
            _VendID.Text = dtgrid.Rows(0).Item(0).ToString

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Frm_FP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _VocNo.Text = fp.autonopv
        Me.Text = "PAYMENT - " & user1
        total = Format(Val(_Tot_Voucher.Text), "#,#.##")
        totalppn = Format(Val(_Tot_Ppn.Text), "#,#.##")
        totaldpp = Format(Val(_Tot_Dpp_Invoice.Text), "#,#.##")
        totalpph = Format(Val(_Tot_Pph.Text), "#,#.##")
        _Tgl_fp.Text = Format(DateTime.Now)

        _Tot_Voucher.Text = Format(Val(_Tot_Voucher.Text), "#,#.##")
        _Tot_Ppn.Text = Format(Val(_Tot_Ppn.Text), "#,#.##")
        _Tot_Dpp_Invoice.Text = Format(Val(_Tot_Dpp_Invoice.Text), "#,#.##")
        _Tot_Pph.Text = Format(Val(_Tot_Pph.Text), "#,#.##")

        cleartext()
        MdiParent = MenuUtamaForm
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

    Sub cleartext()
        _VocNo.Text = fp.autonopv
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"

        _jenis_jasa.Text = ""

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

        '     DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
        DataGridView2.Columns.Clear()
        DataGridView2.Refresh()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        _VocNo.Text = fp.autonopv
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"

        _jenis_jasa.Text = ""

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
            Else
                total = total - DataGridView1.SelectedRows(0).Cells(2).Value
                totalppn = totalppn - DataGridView1.SelectedRows(0).Cells(4).Value
                totaldpp = totaldpp - DataGridView1.SelectedRows(0).Cells(5).Value
                totalpph = totalpph - DataGridView1.SelectedRows(0).Cells(6).Value
                totaldebit = totaldebit + totalcmdm

            End If

            _Tot_Voucher.Text = Format(Val(total), "#,#.##")
            _Tot_Ppn.Text = Format(Val(totalppn), "#,#.##")
            _Tot_Dpp_Invoice.Text = Format(Val(totaldpp), "#,#.##")
            _Tot_Pph.Text = Format(Val(totalpph), "#,#.##")
            _tot_cndn.Text = totalcmdm
            _debit_bank.Text = Format(Val(total - _Biaya_Transfer.Text - totalcmdm), "#,#.##")
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

        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
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

                    ElseIf DataGridView1.Rows(i).Cells(8).Value = False Then
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

        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        ''Dim constring As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
        Using con As New SqlConnection(constring)

            '               Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek2) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur,@cek1,@cek2)", con)
            'Using cmd As New SqlCommand("INSERT INTO Payment_Detail1 (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur) VALUES ('" & _VocNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn1,@Dpp,@Pph1,@No_Faktur)", con)

            con.Open()
            Try
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
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
    End Sub

    
    Private Sub _Vend_Name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _Vend_Name.SelectedIndexChanged

    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class