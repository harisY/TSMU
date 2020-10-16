Imports DevExpress.XtraSplashScreen

Public Class FrmMktUploadPrice
    Private Sub FrmMktUploadPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        'Try
        '    Obj = New KanbanYIMModel
        '    dtGrid = Obj.GetAllDataGrid()
        '    Grid.DataSource = dtGrid

        '    If GridView1.RowCount > 0 Then
        '        With GridView1
        '            .BestFitColumns()
        '            .Columns(0).Visible = False
        '            .FixedLineWidth = 2
        '            .Columns(16).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(17).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        '        End With
        '        GridCellFormat(GridView1)
        '    End If
        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable

        Dim frmExcelPrice As FrmMktExcelPrice
        frmExcelPrice = New FrmMktExcelPrice(table)
        frmExcelPrice.StartPosition = FormStartPosition.CenterScreen
        frmExcelPrice.ShowDialog()

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable
            GridPrice.DataSource = dtFilter
            GridViewPrice.BestFitColumns()
            'If dtFilter.Rows.Count > 0 Then

            '    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            '    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            '    SplashScreenManager.CloseForm()
            '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            '    LoadGrid()
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
