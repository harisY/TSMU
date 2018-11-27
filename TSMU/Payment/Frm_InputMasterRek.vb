Imports System.Data
Imports System.Data.SqlClient


Public Class Frm_InputMasterRek
    Dim payment As Cls_Payment = New Cls_Payment()
    Dim fp As Cls_Payment = New Cls_Payment()

    'Dim fp As Cls_Payment = New Cls_Payment()
    'Dim pay As Cls_report = New Cls_report()


    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim z As Integer
    Dim i As Integer
    Private strConn As String = "Data Source=1.1.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    ' Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection

    Private Sub Frm_InputMasterRek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "INPUT MASTER REKENING - " & user1
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

    Private Sub _VendID_DropDown(sender As Object, e As EventArgs) Handles _VendID.DropDown
        supplier()
    End Sub

    Private Sub _VendID_LostFocus(sender As Object, e As EventArgs) Handles _VendID.LostFocus
        fp.VendID = _VendID.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyid2()
            _Vend_Name.Text = dtgrid.Rows(0).Item(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub msgbox1()
        Dim result As Integer = MessageBox.Show("message", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("No pressed")
        ElseIf result = DialogResult.Yes Then
            MessageBox.Show("Yes pressed")
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim result As Integer = MessageBox.Show("VendID : " + _VendID.Text + "" & vbCrLf & "Supplier Name : " + _Vend_Name.Text + "" & vbCrLf & "Detail Supplier : " + _detsup.Text + " " & vbCrLf & "Bank Name : " + _bank.Text + " " & vbCrLf & "No. Rekening : " + _norek.Text + " " & vbCrLf & "CuryID : " + _curyid.Text + " " & vbCrLf & "", "Apakah Yakin Ingin Membuat Master Rekening Baru Dibawah?", MessageBoxButtons.YesNo)
        'If result = DialogResult.Cancel Then
        '    MessageBox.Show("Cancel pressed")
        'ElseIf result = DialogResult.No Then
        '    MessageBox.Show("No")
        If result = DialogResult.Yes Then
            Try
                usergetobject()
                fp.insertdatarek()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MessageBox.Show("Records Inserted.")
            cleartext()
            Frm_MasterRekening.DataGridView1.Refresh()
        End If
    End Sub

    Sub usergetobject()
        fp.vendidrek = _VendID.Text
        fp.namerek = _Vend_Name.Text
        fp.namedetailrek = _detsup.Text
        fp.bankrekening = _bank.Text
        fp.norekrek = _norek.Text
        fp.curyidrek = _curyid.Text
    End Sub


    Sub cleartext()
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"
        _detsup.Text = ""
        _bank.Text = ""
        _norek.Text = ""
        _curyid.Text = "IDR"
    End Sub

End Class