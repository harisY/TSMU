﻿Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FrmViewShipperNonInvoice
    Dim dtGrid As DataTable
    Dim _Service As ClsShippernotinvoice
    Dim ObjSuspend2 As ClsShippernotinvoice



    Private Sub _BtnCust2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _BtnCust2.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsShippernotinvoice
            If sender.Name = _BtnCust2.Name Then
                dtSearch = ObjSuspend.GetCustomer2
                ls_OldKode = _BtnCust2.Text.Trim
                ls_Judul = "Customer"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _BtnCust2.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim

                    _BtnCust2.Text = Value1

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmViewShipperNonInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Grid.DataSource = Nothing
        _TxtLokasi.Text = gh_Common.Site
        'If gh_Common.Site.ToLower = "all" Then
        '    _TxtLokasi.ReadOnly = False
        'Else
        '    _TxtLokasi.ReadOnly = True
        'End If
        ''     Call LoadGrid()
        ''    Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, True)
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
    End Sub
    Private Sub LoadDataxx()
        Try
            If _TglSJFrom.Text = "" OrElse _TglSJTo.Text = "" Then
                If _TglSJFrom.Text = "" Then
                    _TglSJFrom.Focus()
                ElseIf _TglSJTo.Text = "" Then
                    _TglSJTo.Focus()
                End If
                Throw New Exception("Silahkan pilih tanggal !")
            End If
            Cursor = Cursors.WaitCursor
            ObjSuspend2 = New ClsShippernotinvoice
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = ObjSuspend2.GetShipperNotInv(IIf(_BtnCust2.Text = "", "ALL", _BtnCust2.Text), Format(_TglSJFrom.EditValue, gs_FormatSQLDate), Format(_TglSJTo.EditValue, gs_FormatSQLDate), _TxtLokasi.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
            GridView1.Columns("ShipperID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CustOrdNbr").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AlternateID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("InvtID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("PONbr").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    'Public Overrides Sub Proc_InputNewData()

    '    ''   LoadData()

    'End Sub
    Private Sub LoadGrid()
        Try
            Dim custid As String = ""
            ObjSuspend2 = New ClsShippernotinvoice
            ''         dtGrid = ObjSuspend.GetDataGrid()

            Dim dtGrid As New DataTable
            dtGrid = ObjSuspend2.GetShipperNotInv(IIf(_BtnCust2.Text = "", "ALL", _BtnCust2.Text), Format(_TglSJFrom.EditValue, gs_FormatSQLDate), Format(_TglSJTo.EditValue, gs_FormatSQLDate), _TxtLokasi.Text)

            If dtGrid.Rows.Count > 0 Then
                Grid.DataSource = dtGrid
                GridCellFormat(GridView1)
            End If

            ''  Grid.DataSource = dtGrid
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
            GridView1.Columns("ShipperID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CustOrdNbr").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AlternateID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("InvtID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("PONbr").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            'Dim colSalesDate As GridColumn = GridView1.Columns("TglSuratJalan")
            'colSalesDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            'colSalesDate.DisplayFormat.FormatString = "D"
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                Dim dt As New DataTable
                _Service = New ClsShippernotinvoice
                dt = _Service.GetDataByDate(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                Grid.DataSource = dt
            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub Proc_Excel()
        Try

            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid)
                MsgBox("Data Sudah Berhasil Di Export.")
            Else
                MsgBox("Grid Kosong!")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
        End If
    End Sub
    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadDataxx()
    End Sub
End Class
