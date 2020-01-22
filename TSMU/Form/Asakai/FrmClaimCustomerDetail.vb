﻿Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports ExcelDataReader
Imports GemBox.Spreadsheet
Imports System.Data.OleDb
Public Class FrmClaimCustomerDetail

    Private dt As DataTable

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjClaimCustomerDetail As New ClaimCustomerDetailModel
    Dim KodeTrans As String = ""
    Dim fc_Class As New ClaimCustomerModel
    Dim GridDtl As GridControl


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub TextBoxLoad()
        TxtCustomer.Text = ""
        TxtInvtID.Text = ""
        TxtInvtName.Text = ""
        TxtProblem.Text = ""
        TxtQty.Text = "0"
        TxtPIC.Text = ""
        TxtPIC.Text = ""
        TxtDokumen.Text = ""
    End Sub

    Public Sub New(ByVal strCode As String,
                ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub FrmClaimCustomerDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = New DataTable
        dt.Columns.Add("Customer")
        dt.Columns.Add("TanggalClaim")
        dt.Columns.Add("InvtId")
        dt.Columns.Add("Invt Name")
        dt.Columns.Add("Problem")
        dt.Columns.Add("Qty")
        dt.Columns.Add("Pic")
        dt.Columns.Add("Status")
        dt.Columns.Add("Dokumen")
        dt.Columns.Add("TargetClose")
        Grid.DataSource = dt
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Problem Delivery " & fs_Code
            Else
                Me.Text = "Problem Delivery"
            End If
            Call LoadTxtBox()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmMaterialUsage"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try

            If fs_Code <> "" Then
                With fc_Class

                    DtTanggalLaporan.Value = fc_Class.H_Tanggal

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridProblem As New DataTable
                dtGridProblem = fc_Class.GetDataDetailClaimCustomer(fs_Code)
                Grid.DataSource = dtGridProblem
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If GridView1.RowCount < 1 Then

                MessageBox.Show("Belum Melakukan Inputan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            Else
                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class


                    .H_Tanggal = Format(CDate(Format(DtTanggalLaporan.Value, "yyyy-MM-dd")))

                    If isUpdate = False Then
                        .ValidateInsert()
                    End If

                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        'LoadGridDetail()
    End Sub

    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Belum Melakukan Inputan", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Pastikan Data Tidak ada yang kosong", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next
            End If

            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailClaimCustomer.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjClaimCustomerDetail = New ClaimCustomerDetailModel
                    With ObjClaimCustomerDetail
                        .D_IDTransaksi = KodeTrans
                        .D_TanggalClaim = Convert.ToDateTime(GridView1.GetRowCellValue(i, "TanggalClaim"))
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_InvtID = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "Invt Name"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_RESP = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        .D_Qty = Convert.ToInt32(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Dokumen = Convert.ToString(GridView1.GetRowCellValue(i, "Dokumen"))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_TanggalClose = Convert.ToDateTime(GridView1.GetRowCellValue(i, "TargetClose"))

                    End With
                    fc_Class.ObjDetailClaimCustomer.Add(ObjClaimCustomerDetail)

                Next

                fc_Class.InsertClaimCustomer(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fs_Code
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")

                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailClaimCustomer.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjClaimCustomerDetail = New ClaimCustomerDetailModel
                    With ObjClaimCustomerDetail
                        .D_IDTransaksi = KodeTrans
                        .D_TanggalClaim = Convert.ToDateTime(GridView1.GetRowCellValue(i, "TanggalClaim"))
                        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                        .D_InvtID = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "Invt Name"))
                        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                        .D_RESP = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                        .D_Qty = Convert.ToInt32(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Dokumen = Convert.ToString(GridView1.GetRowCellValue(i, "Dokumen"))
                        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                        .D_TanggalClose = Convert.ToDateTime(GridView1.GetRowCellValue(i, "TargetClose"))
                    End With
                    fc_Class.ObjDetailClaimCustomer.Add(ObjClaimCustomerDetail)

                Next


                fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub


    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Try
            If TxtQty.Text = "" Then
                MessageBox.Show("Qty Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtCustomer.Text = "" Then
                MessageBox.Show("Customer Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtID.Text = "" Then
                MessageBox.Show("Invt ID Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtName.Text = "" Then
                MessageBox.Show("Invt Name Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtProblem.Text = "" Then
                MessageBox.Show("Problem Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtPIC.Text = "" Then
                MessageBox.Show("Status Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtPIC.Text = "" Then
                MessageBox.Show("RESP Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtDokumen.Text = "" Then
                MessageBox.Show("Dokumen Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Else
                GridView1.AddNewRow()
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Customer, TxtCustomer.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TanggalClaim, Format(DtTanggalClaim.Value, "yyyy-MM-dd"))
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtID, TxtInvtID.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InvtName, TxtInvtName.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Problem, TxtProblem.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Qty, TxtQty.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Pic, TxtPIC.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Status, CmbStatus.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Dokumen, TxtDokumen.Text)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, TargetClose, Format(DtTargetClose.Value, "yyyy-MM-dd"))
                GridView1.UpdateCurrentRow()

                Call TextBoxLoad()

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub TxtQty_TextChanged(sender As Object, e As EventArgs) Handles TxtQty.TextChanged

    End Sub

    Private Sub TxtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtQty.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()
        End If
        If e.KeyData = Keys.Insert Then
            GridView1.AddNewRow()
        End If
    End Sub

    Private Sub CmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbStatus.SelectedIndexChanged

    End Sub

    Private Sub CmbStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbStatus.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 13) Then
            e.Handled = True
        End If
    End Sub


    Private Sub TxtCustomer_TextChanged(sender As Object, e As EventArgs) Handles TxtCustomer.TextChanged

        Dim selStart As Integer = TxtCustomer.SelectionStart
        TxtCustomer.Text = TxtCustomer.Text.ToUpper()
        TxtCustomer.SelectionStart = selStart

    End Sub


    Private Sub TxtInvtID_TextChanged(sender As Object, e As EventArgs) Handles TxtInvtID.TextChanged

        Dim selStart As Integer = TxtInvtID.SelectionStart
        TxtInvtID.Text = TxtInvtID.Text.ToUpper()
        TxtInvtID.SelectionStart = selStart

    End Sub


    Private Sub TxtInvtName_TextChanged(sender As Object, e As EventArgs) Handles TxtInvtName.TextChanged

        Dim selStart As Integer = TxtInvtName.SelectionStart
        TxtInvtName.Text = TxtInvtName.Text.ToUpper()
        TxtInvtName.SelectionStart = selStart

    End Sub

    Private Sub TxtProblem_TextChanged(sender As Object, e As EventArgs) Handles TxtProblem.TextChanged

        Dim selStart As Integer = TxtProblem.SelectionStart
        TxtProblem.Text = TxtProblem.Text.ToUpper()
        TxtProblem.SelectionStart = selStart

    End Sub


    Private Sub TxtPIC_TextChanged(sender As Object, e As EventArgs) Handles TxtPIC.TextChanged

        Dim selStart As Integer = TxtPIC.SelectionStart
        TxtPIC.Text = TxtPIC.Text.ToUpper()
        TxtPIC.SelectionStart = selStart

    End Sub




    Private Sub TxtDokumen_TextChanged(sender As Object, e As EventArgs) Handles TxtDokumen.TextChanged

        Dim selStart As Integer = TxtCustomer.SelectionStart
        TxtDokumen.Text = TxtDokumen.Text.ToUpper()
        TxtDokumen.SelectionStart = selStart

    End Sub




End Class