Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_periode

    Public Event EditingControlShowing As DataGridViewEditingControlShowingEventHandler

    Dim fp As Cls_Payment = New Cls_Payment()
    Dim pay As Cls_report = New Cls_report()

    'Dim laporan As New Rpt_Payment
    Dim Report As New Cls_report

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




    'Private Sub bank()
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.bank()
    '        _BankID.DataSource = dtgrid
    '        _BankID.ValueMember = "BankAcct"
    '        _BankID.DisplayMember = "BankAcct"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub _BankName_DropDown(sender As Object, e As EventArgs)
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.bank()
    '        _BankName.DataSource = dtgrid
    '        _BankName.ValueMember = "CashAcctName"
    '        _BankName.DisplayMember = "CashAcctName"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub _BankName_LostFocus(sender As Object, e As EventArgs)
    '    fp.BankName = _BankName.Text
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.bankbyname2()
    '        _BankID.Text = dtgrid.Rows(0).Item(0).ToString
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub _BankID_DropDown(sender As Object, e As EventArgs)
    '    bank()
    'End Sub

    'Private Sub _BankID_LostFocus(sender As Object, e As EventArgs)
    '    fp.BankID = _BankID.Text
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = fp.bankbyid2()
    '        _BankName.Text = dtgrid.Rows(0).Item(0).ToString
    '    Catch ex As Exception

    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub tampilbank()
    '    Try

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Sub tampil()
    '    Dim ds As New DataSet
    '    ds = Report.getalldatabank1
    '    laporan.SetDataSource(ds)

    '    With CrystalReportViewer1
    '        .ReportSource = laporan
    '        .Refresh()
    '    End With
    'End Sub

    Private Sub klikgrid()
        frm_bank.Show()
        'Try
        '    If frm_bank.DataGridView1.Rows.Count > 0 Then

        '        With frm_bank
        '            ._BankID.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
        '            ._BankName.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        '            ._TglPay.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
        '        End With
        '    End If
        'Catch ex As Exception
        '     Return
        '    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        'End Try




        Try
            frm_bank._gridshipper2.Refresh()
            frm_bank._gridshipper2.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatabank()
            frm_bank._gridshipper2.DataSource = dtgrid
            frm_bank._gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If frm_bank._gridshipper2.Rows.Count > 0 Then
                frm_bank._gridshipper2.Columns(0).HeaderText = "No. Voucher"
                frm_bank._gridshipper2.Columns(0).Width = 120

                frm_bank._gridshipper2.Columns(1).HeaderText = "Supplier"
                frm_bank._gridshipper2.Columns(1).Width = 250

                frm_bank._gridshipper2.Columns(2).HeaderText = "No Invoice"
                frm_bank._gridshipper2.Columns(2).Width = 170

                frm_bank._gridshipper2.Columns(3).HeaderText = "PPN"
                frm_bank._gridshipper2.Columns(3).DefaultCellStyle.Format = "##,0"
                frm_bank._gridshipper2.Columns(3).Width = 80
                frm_bank._gridshipper2.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frm_bank._gridshipper2.Columns(4).HeaderText = "PPh"
                frm_bank._gridshipper2.Columns(4).DefaultCellStyle.Format = "##,0"
                frm_bank._gridshipper2.Columns(4).Width = 80
                frm_bank._gridshipper2.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frm_bank._gridshipper2.Columns(5).HeaderText = "Transfer Charge"
                frm_bank._gridshipper2.Columns(5).DefaultCellStyle.Format = "##,0"
                frm_bank._gridshipper2.Columns(5).Width = 60
                frm_bank._gridshipper2.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                frm_bank._gridshipper2.Columns(6).HeaderText = "Total Transfer"
                frm_bank._gridshipper2.Columns(6).DefaultCellStyle.Format = "##,0"
                frm_bank._gridshipper2.Columns(6).Width = 140
                frm_bank._gridshipper2.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub tampildata()
        DataGridView1.AllowUserToAddRows = False
        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldataperiodebank()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "Bank ID"
                DataGridView1.Columns(0).Width = 120

                DataGridView1.Columns(1).HeaderText = "Bank Name"
                DataGridView1.Columns(1).Width = 250

                DataGridView1.Columns(2).HeaderText = "Payment Date"
                DataGridView1.Columns(2).Width = 170
                DataGridView1.Columns(2).DefaultCellStyle.Format = "dd-MM-yyyy"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampildata()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 0 Then
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 6 Then
            MsgBox("aaa")
        End If
        If e.ColumnIndex = 2 Then
            If DataGridView1.SelectedRows(0).Cells(2).Value = True Then
                DataGridView1.SelectedRows(0).Cells(2).Value = False
                MsgBox("aaa")
            Else
                DataGridView1.SelectedRows(0).Cells(3).Value = True
            End If
        End If
    End Sub

    Private Sub Frm_periode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class