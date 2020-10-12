Imports DevExpress.LookAndFeel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmHarigami
    Dim dtGrid As DataTable
    Dim Obj As New HarigamiModels
    Dim ObjDet As New HarigamiDetailsModels
    Private Sub frmHarigami_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try

            dtGrid = Obj.GetAllDataGridCKR()

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
        Dim Dial As New OpenFileDialog
        Dial.Filter = "Excel Files|*.xls;*.xlsx"
        Dim result As DialogResult = Dial.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            _Table = ExcelToDatatable(Dial.FileName, "Sheet1")
        End If
        Try
            If _Table.Rows.Count > 0 Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                Obj.ObjDetails.Clear()
                For Each row As DataRow In _Table.Rows
                    ObjDet = New HarigamiDetailsModels
                    With ObjDet
                        .FileNo = If(row("File No") Is DBNull.Value, "", row("File No").ToString())
                        .FilePath = If(row("File Path") Is DBNull.Value, "", row("File Path").ToString())
                        .Type = If(row("Type") Is DBNull.Value, "", row("Type").ToString())
                        .InvtId = If(row("InvtId") Is DBNull.Value, "", row("InvtId").ToString())
                    End With
                    Obj.ObjDetails.Add(ObjDet)
                Next
                Obj.InsertData()
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
