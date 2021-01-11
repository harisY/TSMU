Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmMonitoringDelivery
    Dim dtGrid As DataTable
    Dim Obj As New KanbanInternalTng

    Dim PrintTool As ReportPrintTool

    Dim ds As DataSet
    Dim dt As DataTable
    Dim dt2 As DataTable
    Private Sub frmMonitoringDelivery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = New DataTable
            dtGrid = Obj.GetKanbansDelivery(1)
            Grid.DataSource = dtGrid

            dt = New DataTable
            dt = Obj.GetKanbansDelivery(0)
            Grid1.DataSource = dt

            With GridView1
                .BestFitColumns()
            End With
            With GridView2
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            If GridView2.RowCount > 0 Then
                GridCellFormat(GridView2)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        If GridView1.RowCount > 0 Then
            Dim save As New SaveFileDialog
            save.Filter = "Excel File|*.xlsx"
            save.Title = "Save an Excel File"
            If save.ShowDialog = DialogResult.OK Then
                _Grid.ExportToXlsx(save.FileName)
            End If
        Else
            ShowMessage("Data Kosong !", MessageTypeEnum.ErrorMessage)
        End If
    End Sub


    Private Sub frmMonitoringDelivery_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadGrid()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Dim view As GridView = TryCast(sender, GridView)
        'If view.GetRowCellValue(e.RowHandle, "Status") = True Then
        '    e.Appearance.BackColor = Color.LightSalmon
        '    e.HighPriority = True
        'End If

    End Sub
End Class
