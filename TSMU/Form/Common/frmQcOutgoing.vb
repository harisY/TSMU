Imports DevExpress.XtraSplashScreen

Public Class frmQcOutgoing
    Dim dtGrid As DataTable
    Dim Service As New QcOutgoingService
    Dim Obj As New QcOutgoingModel

    Private Sub frmQcOutgoing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = Service.GetDataGrid()

            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_Excel()
        Dim _Table As New DataTable
        Dim Filename As String = String.Empty
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim Dial As New OpenFileDialog
            Dial.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = Dial.ShowDialog()
            If result = System.Windows.Forms.DialogResult.OK Then
                _Table = ExcelReader.ExcelToDataTable(Dial.FileName)
            End If

            If _Table.Rows.Count > 0 Then
                Service.ObjCollections.Clear()
                For Each row As DataRow In _Table.Rows
                    Obj = New QcOutgoingModel
                    With Obj
                        .PartNo = row(0).ToString().AsString()
                        .InvtId = row(1).ToString().AsString()
                        .PathFile = row(2).ToString().AsString()
                        .PathFile1 = row(3).ToString().AsString()
                    End With
                    Service.ObjCollections.Add(Obj)
                Next
                Service.InsertTransactions()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class