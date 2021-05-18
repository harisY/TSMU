Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class FrmReceipt_PO
    Dim ObjPaymentDetail As New clsReceptPO
    Dim Objgl As clsReceptPO
    Private Sub FrmReceipt_PO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub _TxtVendorID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _TxtVendorID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = _TxtVendorID.Name Then
                dtSearch = ObjPaymentDetail.GetVendor
                ls_OldKode = _TxtVendorID.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _TxtVendorID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    ''     Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    _TxtVendorID.Text = Value1
                    _TxtVendorName.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'If _TxtDari.EditValue = "" Then

            '    Throw New Exception("Silahkan pilih From Date!")
            'End If
            'If _TxtSampai.EditValue = "" Then

            '    Throw New Exception("Silahkan pilih To Date!")
            'End If

            Cursor = Cursors.WaitCursor
            Objgl = New clsReceptPO
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = Objgl.GetReceiptPO(_TxtDari.Text, _TxtSampai.Text, _TxtVendorID.Text, _TxtSiteID.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            'With GridView1
            '    .Columns(0).Visible = False
            'End With
            GridCellFormat(GridView1)


            GridView1.Columns("Vendor").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("VendId").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("RcptDate").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("TranDesc").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("InvtId").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath


            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
