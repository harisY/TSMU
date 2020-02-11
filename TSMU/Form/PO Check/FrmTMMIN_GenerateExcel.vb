Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class FrmTMMIN_GenerateExcel
    Dim tmmin As TMMINmodel
    Private Sub FrmTMMIN_GenerateExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, True, False, False, False, False, False, False)
        TxtEtd.EditValue = DateTime.Today

    End Sub

    Public Overrides Sub Proc_Excel()
        SaveToExcel(Grid)
        Try
            For i = 0 To GridView1.RowCount - 1
                Dim tmmin = New TMMINmodel
                Dim KanbanID As String = GridView1.GetRowCellValue(i, "Kanban ID")
                Try
                    tmmin.UpdateFlag(KanbanID)
                Catch ex As Exception
                    Continue For
                End Try
            Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadToGrid(flag As Integer)
        tmmin = New TMMINmodel
        Dim dt As New DataTable

        dt = tmmin.GetKanban(Format(TxtEtd.EditValue, "yyyy-MM-dd"), flag)
        Grid.DataSource = dt
        If dt.Rows.Count > 1 Then

            GridView1.BestFitColumns()
            GridCellFormat(GridView1)
        End If

    End Sub

    Public Overrides Sub Refresh()
        LoadToGrid(0)
    End Sub
    Private Sub TxtEtd_EditValueChanged(sender As Object, e As EventArgs) Handles TxtEtd.EditValueChanged
        Try

            If RadioGroup1.SelectedIndex = 0 Then
                LoadToGrid(0)
            Else
                LoadToGrid(1)
            End If
        Catch ex As Exception

            XtraMessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Try

            If RadioGroup1.SelectedIndex = 0 Then
                LoadToGrid(0)
            Else
                LoadToGrid(1)

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub


End Class
