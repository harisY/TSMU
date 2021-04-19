Public Class frmProblem
    Dim Service As New ProblemService
    Dim Model As ProblemModel
    Dim ff_Detail As frmProbleDetail

    Private Sub frmFrmProblem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, False)
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Try
            Dim dt As New DataTable
            dt = Service.GetData()

            Grid.DataSource = dt
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_InputNewData()
        'GridView1.AddNewRow()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_DeleteData()
        If GridView1.RowCount = 0 Then
            Return
        End If
        Dim Id As Integer = 0
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Id = GridView1.GetRowCellValue(rowHandle, "Id")
                End If
            Next rowHandle
            Service.DeleteData(Id)
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As Integer = 0, Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmProbleDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        'ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.ShowDialog()
    End Sub

    Private Sub PassDataToDetail()
        Dim Id As Integer
        Try
            Id = 0
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Id = GridView1.GetRowCellValue(rowHandle, "Id")
                End If
            Next rowHandle
            Dim n As Integer = 0
            If GridView1.GetSelectedRows.Length > 0 Then
                For i As Integer = 0 To GridView1.FocusedRowHandle - 1
                    n += 1
                Next
                'Dim objGrid As DataGridView = sender
                Call CallFrm(Id, n)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub frmFrmProblem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            PassDataToDetail()
        End If
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        PassDataToDetail()
    End Sub

End Class