Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraSplashScreen

Public Class frmReport_Outgoing
    Dim ObjService As ReportService
    Dim fdtl_Config As DataTable = Nothing
    Private Initializing As Boolean = False
    Sub New()
        Initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmReport_Outgoing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False, False)
        Init()
        LoadGrid()
    End Sub
    Private Sub Init()
        Grid.DataSource = Nothing
        TxtDari.EditValue = Date.Today
        TxtSampai.EditValue = Date.Today
    End Sub
    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            ObjService = New ReportService
            Dim dt As New DataTable
            dt = ObjService.GenerateDataGridOutgoing(TxtDari.EditValue, TxtSampai.EditValue)
            Grid.DataSource = dt
            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()
                GridCellFormatDatewithTime(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGrid()
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid)
            Else
                MsgBox("Grid Kosong !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtDari_EditValueChanged(sender As Object, e As EventArgs) Handles TxtDari.EditValueChanged, TxtSampai.EditValueChanged
        If Initializing Then
            Exit Sub
        End If
        Dim dateFrom As Date = TxtDari.EditValue
        Dim dateTo As Date = TxtSampai.EditValue
        If dateFrom > dateTo Then
            XtraMessageBox.Show("Tanggal Dari tidak boleh lebih besar dari tanggal sampai !")
        Else
            LoadGrid()
        End If
    End Sub

    Private Sub frmReport_Outgoing_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False
    End Sub
End Class
