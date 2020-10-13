Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frmSalesCheck
    Dim ObjSales As sales_model
    Private columnValues As New List(Of String)()
    Private Sub frmSalesCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False, False)
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid, "Sales Aktual", "Sales Aktual " & _txtPerpost.Text, False)
            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If _txtPerpost.Text = "" Then
                _txtPerpost.Focus()
                Throw New Exception("Harap Isi Perpost !")
            End If
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            GetDataGrid()
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub GetDataGrid()
        Try
            ObjSales = New sales_model
            Dim dt As New DataTable
            dt = ObjSales.SalesLoadDataGrid(_txtPerpost.Text)
            Grid.DataSource = dt
            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()
                GridCellFormat(GridView1)
            End If

            'Dim values =
            '    From myRow In dt.AsEnumerable()
            '    Select myRow.Field(Of String)("ShipperID")
            'columnValues = values.ToList()
            'AddHandler GridView1.RowStyle, AddressOf GridView1_RowStyle
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "ShipperID")
        'If val Is Nothing Then
        '    Return
        'End If
        'Dim svalue As String = val.ToString()
        'If columnValues.Where(Function(s) s.Equals(svalue)).ToList().Count > 1 Then
        '    e.Appearance.BackColor = Color.Salmon
        'End If
    End Sub

    Private Sub CheckDuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckDuplicateToolStripMenuItem.Click
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            'dt = GridView1.GridControl.DataSource
            'PerformBulkCopy(dt, "T_Sales_Aktual_Temp")
            ObjSales = New sales_model
            dt = ObjSales.SalesCheckDuplicate(_txtPerpost.Text.Trim)
            If _txtPerpost.Text <> "" AndAlso GridView1.RowCount > 0 Then
                SplashScreenManager.CloseForm()
                Dim Frm As FrmSystemCommonGrid
                Frm = New FrmSystemCommonGrid(dt, _txtPerpost.Text.Trim, Me)
                With Frm
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            Else
                Throw New Exception("Grid kosong, Load Sales aktual !")
            End If
            'ShowMessage(MessageEnum.SimpanBerhasil, MessageTypeEnum.NormalMessage)
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class
