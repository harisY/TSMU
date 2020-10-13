Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Columns

Public Class FrmViewShipperNonInvoice
    Dim dtGrid As DataTable
    Dim _Service As ClsShippernotinvoice
    Dim ObjSuspend As ClsShippernotinvoice
    Private Sub FrmViewShipperNonInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Grid.DataSource = Nothing
        Call LoadGrid()
        ''    Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, True)
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            ObjSuspend = New ClsShippernotinvoice
            dtGrid = ObjSuspend.GetDataGrid()
            Grid.DataSource = dtGrid
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
            GridView1.Columns("ShipperID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CustOrdNbr").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AlternateID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("InvtID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath

            'Dim colSalesDate As GridColumn = GridView1.Columns("TglSuratJalan")
            'colSalesDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            'colSalesDate.DisplayFormat.FormatString = "D"
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                Dim dt As New DataTable
                _Service = New ClsShippernotinvoice
                dt = _Service.GetDataByDate(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                Grid.DataSource = dt
            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub Proc_Excel()
        Try

            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid)
                MsgBox("Data Sudah Berhasil Di Export.")
            Else
                MsgBox("Grid Kosong!")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
        End If
    End Sub
    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub
End Class
