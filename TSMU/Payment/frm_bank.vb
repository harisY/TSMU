Imports System.Data
Imports System.Data.SqlClient

Public Class frm_bank

    Dim fp As Cls_Payment = New Cls_Payment()
    Dim pay As Cls_report = New Cls_report()
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim z As Integer
    Dim i As Integer
    Private strConn As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    ' Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection

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

    Private Sub tampilbank()
        Try
          
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampildata()

        Try
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatabank()
            _gridshipper2.DataSource = dtgrid
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "No. Voucher"
                _gridshipper2.Columns(0).Width = 120

                _gridshipper2.Columns(1).HeaderText = "Supplier"
                _gridshipper2.Columns(1).Width = 250

                _gridshipper2.Columns(2).HeaderText = "Total Invoice"
                _gridshipper2.Columns(2).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(2).Width = 170
                _gridshipper2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(3).HeaderText = "PPN"
                _gridshipper2.Columns(3).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(3).Width = 80
                _gridshipper2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(4).HeaderText = "PPh"
                _gridshipper2.Columns(4).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(4).Width = 80
                _gridshipper2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(5).HeaderText = "Transfer Charge"
                _gridshipper2.Columns(5).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(5).Width = 60
                _gridshipper2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(6).HeaderText = "Total Transfer"
                _gridshipper2.Columns(6).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(6).Width = 140
                _gridshipper2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampildata()
    End Sub




    Sub tampilalldata()

        Try
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatabankdg()
            _gridshipper2.DataSource = dtgrid
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "No. Voucher"
                _gridshipper2.Columns(0).Width = 120

                _gridshipper2.Columns(1).HeaderText = "Supplier"
                _gridshipper2.Columns(1).Width = 250

                _gridshipper2.Columns(2).HeaderText = "Total Invoice"
                _gridshipper2.Columns(2).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(2).Width = 170
                _gridshipper2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(3).HeaderText = "PPN"
                _gridshipper2.Columns(3).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(3).Width = 80
                _gridshipper2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(4).HeaderText = "PPh"
                _gridshipper2.Columns(4).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(4).Width = 80
                _gridshipper2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(5).HeaderText = "Transfer Charge"
                _gridshipper2.Columns(5).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(5).Width = 60
                _gridshipper2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                _gridshipper2.Columns(6).HeaderText = "Total Transfer"
                _gridshipper2.Columns(6).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(6).Width = 140
                _gridshipper2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tampilalldata()
    End Sub


    Private Sub klikgrid()

        Frm_Payment.Show()

        Try
            If _gridshipper2.Rows.Count > 0 Then

                With Frm_Payment
                    ._VocNo.Text = _gridshipper2.SelectedRows(0).Cells(0).Value.ToString()
                    ._Tgl_fp.Text = _gridshipper2.SelectedRows(0).Cells(1).Value.ToString()
                    ._BankID.Text = _gridshipper2.SelectedRows(0).Cells(2).Value.ToString()
                    ._BankName.Text = _gridshipper2.SelectedRows(0).Cells(3).Value.ToString()
                    ._VendID.Text = _gridshipper2.SelectedRows(0).Cells(4).Value.ToString()
                    ._Vend_Name.Text = _gridshipper2.SelectedRows(0).Cells(5).Value.ToString()
                    ._jenis_jasa.Text = _gridshipper2.SelectedRows(0).Cells(6).Value.ToString()
                    ._Tot_Dpp_Invoice.Text = _gridshipper2.SelectedRows(0).Cells(7).Value.ToString()
                    ._Tot_Ppn.Text = _gridshipper2.SelectedRows(0).Cells(8).Value.ToString()
                    ._Tot_Voucher.Text = _gridshipper2.SelectedRows(0).Cells(9).Value.ToString()
                    ._Tot_Pph.Text = _gridshipper2.SelectedRows(0).Cells(10).Value.ToString()
                    ._Biaya_Transfer.Text = _gridshipper2.SelectedRows(0).Cells(11).Value.ToString()
                    ._tot_cndn.Text = _gridshipper2.SelectedRows(0).Cells(12).Value.ToString()
                    ._curyid.Text = _gridshipper2.SelectedRows(0).Cells(13).Value.ToString()
                    ._debit_bank.Text = _gridshipper2.SelectedRows(0).Cells(9).Value.ToString() - _gridshipper2.SelectedRows(0).Cells(11).Value.ToString()
                    .Button2.Enabled = True


                End With
            End If
        Catch ex As Exception
            ' Return
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _gridshipper2.CellContentClick
        If e.ColumnIndex = 0 Then
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 5 Then
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If e.ColumnIndex = 4 Then
            If _gridshipper2.SelectedRows(0).Cells(4).Value = True Then
                _gridshipper2.SelectedRows(0).Cells(4).Value = False
                Try
                    klikgrid()
                    'Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                _gridshipper2.SelectedRows(0).Cells(4).Value = True
            End If
        End If
        ''Me.Close()
    End Sub

    Private Sub frm_bank_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class