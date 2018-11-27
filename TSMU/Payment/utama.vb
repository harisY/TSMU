Imports System.Data
Imports System.Data.SqlClient
Public Class utama

    Dim fp As Cls_FP = New Cls_FP()

    Private Sub utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _Tot_Ppn.Enabled = False
        _Tot_Pph.Enabled = False
        _Tot_Dpp_Invoice.Enabled = False
        _Tot_Voucher.Enabled = False
    End Sub

    Sub CekInv()
        DataGridView1.ColumnCount = 2
        DataGridView1.Columns(0).Name = "No. Invoice"
        DataGridView1.Columns(1).Name = "Amount"

        Dim row As String() = New String() {"0025896474", "Rp. 125.115.660"}
        DataGridView1.Rows.Add(row)
        row = New String() {"000123978", "Rp. 90.230.523"}
        DataGridView1.Rows.Add(row)

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView1.Columns.Add(chk)
        chk.HeaderText = "Pilih"
        chk.Name = "chk"
        DataGridView1.Rows(1).Cells(2).Value = True

        Dim btn As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn)
        btn.HeaderText = "PPN"
        btn.Text = "PPN"
        btn.Name = "ppn"
        btn.UseColumnTextForButtonValue = True

        Dim btn2 As New DataGridViewButtonColumn()
        DataGridView1.Columns.Add(btn2)
        btn2.HeaderText = "PPh"
        btn2.Text = "PPh"
        btn2.Name = "pph"
        btn2.UseColumnTextForButtonValue = True
    End Sub

    Sub DupInv()
        For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            For j As Integer = i + 1 To Me.DataGridView1.RowCount - 2
                If DataGridView1.Rows(i).Cells(0).Value = DataGridView1.Rows(j).Cells(0).Value Then
                    MessageBox.Show("DUPLICATE VALUE!!! INVOICE NO. " & DataGridView1.Rows(i).Cells(0).Value)
                    DataGridView1.Rows.RemoveAt(i)
                    DataGridView1.Rows.RemoveAt(j)
                End If
            Next
        Next
    End Sub

    Sub DupInv2()
        For intI As Integer = DataGridView1.Rows.Count - 1 To 0 Step -1
            For intJ As Integer = DataGridView1.Rows.Count - 1 To intI + 1 Step -1
                If DataGridView1.Rows(intI).Cells(0).Value = DataGridView1.Rows(intJ).Cells(0).Value Then
                    MessageBox.Show("DUPLICATE VALUE!!! INVOICE NO. " & DataGridView1.Rows(intI).Cells(0).Value)
                    DataGridView1.Rows.RemoveAt(intJ)
                End If
            Next intJ
        Next intI
    End Sub

    Private Sub cek_Click(sender As Object, e As EventArgs) Handles cek.Click
        CekInv()
        DupInv2()
    End Sub




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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 3 Then
            Frm_ScanFP.StartPosition = FormStartPosition.CenterScreen
            Frm_ScanFP.ShowDialog()
        End If
        If e.ColumnIndex = 4 Then
            Frm_PPH.StartPosition = FormStartPosition.CenterScreen
            Frm_PPH.ShowDialog()
        End If
    End Sub

    Private Sub _VendID_DropDown(sender As Object, e As EventArgs) Handles _VendID.DropDown
        supplier()
    End Sub

    Private Sub _VendID_LostFocus(sender As Object, e As EventArgs) Handles _VendID.LostFocus
        If _VendID.Text = "" Then
        Else
            fp.VendID = _VendID.Text
            _Vend_Name.Text = fp.supplierbyid
        End If

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
        If _Vend_Name.Text = "" Then
        Else
            fp.Vend_Name = _Vend_Name.Text
            _VendID.Text = fp.supplierbyname
        End If
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

    Private Sub _BankID_DropDown(sender As Object, e As EventArgs) Handles _BankID.DropDown
        bank()

    End Sub

    Private Sub _BankID_LostFocus(sender As Object, e As EventArgs) Handles _BankID.LostFocus
        If _BankID.Text = "" Then
        Else
            fp.BankID = _BankID.Text
            _BankName.Text = fp.bankbyid
        End If
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
        If _BankName.Text = "" Then
        Else
            fp.BankName = _BankName.Text
            _BankID.Text = fp.bankbyname
        End If
    End Sub



End Class
