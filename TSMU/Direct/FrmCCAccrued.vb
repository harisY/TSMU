﻿Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmCCAccrued
    Dim cls_Accrued As ClsCCAccrued
    Dim dtGrid As New DataTable
    Dim dtGridAccrued As New DataTable
    Dim TabPage As String

    Private Sub FrmCCAccrued_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
        XtraTabControl1.SelectedTabPage = TabPageProses
        TabPage = XtraTabControl1.SelectedTabPage.Name
        LoadGridAccrued()
    End Sub

    Public Overrides Sub Proc_Refresh()
        txtCCNumber.Text = ""
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageProses" Then
            LoadGridAccrued()
        ElseIf TabPage = "TabPageCancel" Then
            LoadGridAccruedAll()
        ElseIf TabPage = "TabPagePaid" Then
            LoadGridAccruedPaid()
        End If
    End Sub

    Private Sub LoadGridAccrued()
        Try
            cls_Accrued = New ClsCCAccrued
            cls_Accrued.CreditCardNumber = txtCCNumber.Text
            dtGridAccrued = cls_Accrued.GetDataCostCC()
            GridAccrued.DataSource = dtGridAccrued
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedAll()
        Try
            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataCostCCAll(0)
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.Columns("ID").Visible = False
            GridViewAccruedAll.Columns("Seq").Visible = False
            GridViewAccruedAll.Columns("Pay").Visible = False
            GridViewAccruedAll.BestFitColumns()
            GridCellFormat(GridViewAccruedAll)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedPaid()
        Try
            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataCostCCAll(1)
            GridAccruedPaid.DataSource = dtGrid
            GridViewAccruedPaid.Columns("ID").Visible = False
            GridViewAccruedPaid.Columns("Seq").Visible = False
            GridViewAccruedPaid.Columns("Pay").Visible = False
            GridViewAccruedPaid.BestFitColumns()
            GridCellFormat(GridViewAccruedPaid)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageProses" Then
            LoadGridAccrued()
        ElseIf TabPage = "TabPageCancel" Then
            LoadGridAccruedAll()
        ElseIf TabPage = "TabPagePaid" Then
            LoadGridAccruedPaid()
        End If
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Try
            If GridViewAccrued.SelectedRowsCount > 0 Then
                Dim noAccrued As String
                noAccrued = cls_Accrued.GetAutoNumber(Me)
                Dim Rows As New ArrayList()
                For i As Integer = 0 To GridViewAccrued.SelectedRowsCount() - 1
                    If (GridViewAccrued.GetSelectedRows()(i) >= 0) Then
                        Rows.Add(GridViewAccrued.GetDataRow(GridViewAccrued.GetSelectedRows()(i)))
                    End If
                Next
                cls_Accrued.InsertData(Me, noAccrued, Rows)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()
            Else
                MessageBox.Show("Tidak ada data yang dipilih", "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If GridViewAccruedAll.SelectedRowsCount > 0 Then
                Dim Rows As New ArrayList()
                For i As Integer = 0 To GridViewAccruedAll.SelectedRowsCount() - 1
                    If (GridViewAccruedAll.GetSelectedRows()(i) >= 0) Then
                        Rows.Add(GridViewAccruedAll.GetDataRow(GridViewAccruedAll.GetSelectedRows()(i)))
                    End If
                    Dim Row As DataRow = CType(Rows(0), DataRow)
                    If Row("Pay") = 1 Then
                        MessageBox.Show("Data sudah dilakukan pembayaran", "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next
                cls_Accrued.DeleteData(Rows)
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()
            Else
                MessageBox.Show("Tidak ada data yang dipilih", "Warning",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtCCNumber_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCCNumber.ButtonClick
        Dim ls_Judul As String = ""
        Dim dtSearch As New DataTable

        dtSearch = cls_Accrued.GetCreditCard
        ls_Judul = "CREDIT CARD"

        Dim lF_SearchData As FrmSystem_LookupGrid
        lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        lF_SearchData.Text = "Select Data " & ls_Judul
        lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        lF_SearchData.ShowDialog()

        If lF_SearchData.Values IsNot Nothing Then
            txtCCNumber.Text = lF_SearchData.Values.Item(1).ToString.Trim
        End If

        lF_SearchData.Close()
        LoadGridAccrued()
    End Sub

    Private Sub CAmountIDR_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountIDR.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim amount As Double
        Dim rate As Double
        Dim amountIDR As Double
        amount = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "Amount")
        amountIDR = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "AmountIDR")
        rate = amountIDR / amount

        GridViewAccrued.SetRowCellValue(GridViewAccrued.FocusedRowHandle, "Rate", rate)
    End Sub

    Private Sub GridViewAccrued_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridViewAccrued.FocusedRowChanged
        Try
            Dim curryID = String.Empty
            Dim selectedRows As Integer = GridViewAccrued.FocusedRowHandle
            curryID = GridViewAccrued.GetRowCellValue(selectedRows, "CurryID")
            If curryID = "IDR" Then
                GridViewAccrued.OptionsBehavior.Editable = False
            Else
                GridViewAccrued.OptionsBehavior.Editable = True
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
