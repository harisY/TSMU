Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_cmdm
    Dim fp As Cls_Payment = New Cls_Payment()
    Dim cm As Cls_cmdm = New Cls_cmdm()

    Dim perintah As Integer = 0
    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim z As Integer
    Dim i As Integer
    Private strConn As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    Private sqlCon As SqlConnection

    Sub usergetobject()
        cm.vrno = _vrno.Text
        cm.bankid = _BankID.Text
        cm.bankname = _BankName.Text
        cm.VendID = _VendID.Text
        cm.vendname = _Vend_Name.Text
        cm.tgl = _Tgl.Text
        cm.ket = _ket.Text

        cm.curyid = _curyid.Text
        cm.batch = _batch.Text
        cm.noinvoice = _no_invoice.Text
        cm.totalcmdm = _total_cmdm.Text
    End Sub

    Private Function IsControlEmpty() As Boolean
        Try
            If _batch.Text = "" And
               _no_invoice.Text = "" And _total_cmdm.Text = "" Then
                _batch.Focus()
                Throw New Exception("Data Harus Di Isi Lengkap!")
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Return True
        End Try
    End Function

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
            _ket.Text = dtgrid.Rows(0).Item(2).ToString
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

    Sub ClearText()
        For Each ctl As Control In Panel1.Controls
            If TypeOf ctl Is TextBox Then
                ctl.Text = ""
            End If
        Next
    End Sub

    Sub Save()
        Try
            usergetobject()
            TampilData()
            tampilgrid()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
        'MessageBox.Show("Records inserted.")
        ClearText()
    End Sub

    Sub TampilData()
        Try
            Dim dtGrid As DataTable = New DataTable
            dtGrid = cm.Insertdata2()
            DataGridView1.DataSource = dtGrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            MsgBox(ex.Message)
            If ex.InnerException IsNot Nothing Then
                MsgBox(ex.InnerException)
            End If
        End Try
    End Sub

    Sub tampilgrid()
        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = cm.getalldatacmdm()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "No. Voucher"
                DataGridView1.Columns(0).Width = 120

                DataGridView1.Columns(1).HeaderText = "Bank Name"
                DataGridView1.Columns(1).Width = 250

                DataGridView1.Columns(2).HeaderText = "Supplier"
                DataGridView1.Columns(2).Width = 170

                DataGridView1.Columns(3).HeaderText = "Date"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(3).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView1.Columns(4).HeaderText = "Keterangan"
                DataGridView1.Columns(4).Width = 170

                DataGridView1.Columns(5).HeaderText = "Cury ID"
                DataGridView1.Columns(5).Width = 80

                DataGridView1.Columns(6).HeaderText = "Batch"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(7).HeaderText = "No. Invoice"
                DataGridView1.Columns(7).Width = 80
                DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(8).HeaderText = "Total CMDM"
                DataGridView1.Columns(8).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(8).Width = 140
                DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _batch.Text = "" And
               _no_invoice.Text = "" And _total_cmdm.Text = "" Then
            _ket.Focus()
            MessageBox.Show("Data Harus Di Isi Lengkap!")
        Else
            Save()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        _vrno.Text = ""
        _BankID.Text = "11240"
        _BankName.Text = "MIZUHO IDR"
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"
        _Tgl.Text = ""
        _ket.Text = ""
        _curyid.Text = "IDR"
        _batch.Text = ""
        _no_invoice.Text = ""
        _total_cmdm.Text = ""
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub Frm_cmdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class