Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class frmReport_SalesPrice
    Dim dtGrid As DataTable
    Dim service As clsReport
    Private Initializing As Boolean = False
    Sub New()
        Initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmReport_SalesPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        FillComboTahun()
        _CmbTahun.SelectedIndex = 1
        Call Proc_EnableButtons(False, False, False, True, False, False, True, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            service = New clsReport
            dtGrid = New DataTable
            dtGrid = service.Sales_ForecastPrice_report_New(_CmbTahun.Text)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .OptionsView.ShowFooter = True
                .OptionsBehavior.Editable = False
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Data Kosong !")
        End If
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid.MouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    ContextMenuStrip1.Show(e.Location)
        'End If
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As Integer = {Date.Today.Year - 1, Date.Today.Year, Date.Today.Year + 1}
        _CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            _CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub _CmbTahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _CmbTahun.SelectedIndexChanged
        Try
            If Initializing Then
                Exit Sub
            End If
            LoadGrid()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmReport_SalesPrice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False
        Call LoadGrid()
    End Sub
End Class
