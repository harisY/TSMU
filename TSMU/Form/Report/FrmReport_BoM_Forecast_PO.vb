﻿Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class FrmReport_BoM_Forecast_PO
    Dim ObjReportMatome As ClsReportMatome

    Public Sub New()
        ObjReportMatome = New ClsReportMatome
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmReport_BoM_Forecast_PO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tahun As String = String.Empty
        Tahun = Date.Today.Year().ToString
        _txtTahun.Text = Tahun
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
        'LoadGrid(Tahun)
    End Sub
    Private Sub LoadGrid(Tahun As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            dt = ObjReportMatome.Generate_Report_BoM_PO_ForecastCalculate(Tahun, txtInvtId.EditValue)
            Grid.DataSource = dt
            AdvBandedGridView1.BestFitColumns()
            'If AdvBandedGridView1.RowCount > 0 Then
            '    FormatGridBadgeView(AdvBandedGridView1)
            'End If

            Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False)
            Cursor.Current = Cursors.Default
            SplashScreenManager.CloseForm()
            'XtraMessageBox.Show("Proses selesai !")
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            SplashScreenManager.CloseForm()
            XtraMessageBox.Show(ex.Message)
        End Try

        'With AdvBandedGridView1
        '    .BestFitColumns()
        '    .FixedLineWidth = 2
        '    .Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        '    .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        'End With
    End Sub
    Public Overrides Sub Proc_Refresh()
        If _txtTahun.Text = "" Then
            XtraMessageBox.Show("Silahkan isi tahun !")
            _txtTahun.Focus()
        ElseIf txtInvtId.Text = "" Then
            XtraMessageBox.Show("Inventory ID harus di isi !")
            txtInvtId.Focus()
        Else
            LoadGrid(_txtTahun.Text)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If AdvBandedGridView1.RowCount > 0 Then
                SaveToExcel(Grid, "BoM vs PO/Forecast", "", False)
                'getPath()
                '    Dim Filename As String = path & "\Forecast_.xls"
                '    'Dim FileName As String = "D:\Grid.xls"
                '    Grid.ExportToXls(Filename)

            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub _txtTahun_KeyDown(sender As Object, e As KeyEventArgs) Handles _txtTahun.KeyDown
        If e.KeyCode = Keys.Enter Then
            tsBtn_refresh.PerformClick()
        Else
            e.Handled = True

        End If
    End Sub
    Dim ObjReport As clsReport
    Private Sub txtInvtId_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtInvtId.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            ObjReport = New clsReport
            dtSearch = ObjReport.getInvtItem
            ls_OldKode = txtInvtId.Text.Trim
            ls_Judul = "Invetory ID"


            '   dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            dtSearch.Rows(0).Item(0) = "ALL"
            dtSearch.Rows(0).Item(1) = "ALL"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                txtInvtId.Text = ls_Kode
            End If
            txtInvtId.Focus()
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtInvtId_EditValueChanged(sender As Object, e As EventArgs) Handles txtInvtId.EditValueChanged
        Try
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
