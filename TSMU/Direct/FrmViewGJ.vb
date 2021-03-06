﻿Imports Excel = Microsoft.Office.Interop.Excel
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
Public Class FrmViewGJ
    Dim dtGrid As DataTable
    Dim _Service As GJHeaderModel
    Dim Objgl As GJHeaderModel
    Dim ff_Detail As FrmDetailPaymentDirect1
    Dim ff_Detail2 As FrmDetailPaymentSuspend
    Dim ff_Detail3 As FrmDetailPaymentSettle
    Dim ff_Detail4 As FrmDetailPaymentSuspend
    Dim ff_Detail5 As FrmEditDirectPayment
    Dim ff_Detail6 As FrmBankPaid
    Dim ff_Detail6z As FrmBankPaid
    Dim ff_Detail7 As frm_payment_aprrove_details
    Dim ff_Detail8 As FrmBankReceipt_Detail
    Dim ff_Detail81 As FrmBankTransfer_Detail
    Dim ff_Detail9 As FrmDetailPaymentDirect1
    Dim ff_Detail31 As FrmCCSettlement
    Dim ff_Detailx As FrmSuspendSettleDetail
    Dim ff_Detail1x As FrmSuspendSettleDetailDirect
    Dim ff_Detaild As FrmSuspend_Detail
    Dim TotAmount As Double
    Private Sub FrmViewGJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' GridView1.OptionsBehavior.Editable = False
        ' Prevent the focused cell from being highlighted.
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        ' Draw a dotted focus rectangle around the entire row.
        GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
    End Sub
    Private Sub ListItemsPerpost()
        Objgl = New GJHeaderModel
        Dim dt = New DataTable

        dt = Objgl.GetListPerpost()
        Dim itemsCollection As ComboBoxItemCollection = _TxtPerpost.Properties.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub
    Public Overrides Sub Proc_SaveData()
        If _TxtTransaksi.Text = "Cash Transaction" Then
            simpan_ca()


        ElseIf _TxtTransaksi.Text = "Cash Transfer" Then
            simpan_tr()
        ElseIf _TxtTransaksi.Text = "General Journal" Then
            simpan_gj()


        End If
    End Sub
    Private Sub simpan_ca()
        Try
            Dim query As String
            Dim cek_upload As Boolean
            Dim NoBukti2 As String
            Dim a As Boolean
            For i As Integer = 0 To GridView1.RowCount - 1
                NoBukti2 = GridView1.GetRowCellValue(i, "NoBukti2")
                a = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                If a = True Then
                    a = True
                Else
                    a = False
                End If
                cek_upload = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                NoBukti2 = GridView1.GetRowCellValue(i, "NoBukti2")
                query = "update cashbank2 set cek_upload='" & a & "' where NoBukti='" & NoBukti2 & "' "
                MainModul.ExecQueryByCommandSolomon(query)

            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView1.Columns.Clear()
        GridView1.RefreshData()

        LoadDataxx()
    End Sub
    Private Sub simpan_tr()
        Try
            Dim query As String
            Dim cek_upload As Boolean
            Dim NoBukti2 As String
            Dim a As Boolean
            For i As Integer = 0 To GridView1.RowCount - 1
                NoBukti2 = GridView1.GetRowCellValue(i, "NoBukti2")
                a = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                If a = True Then
                    a = True
                Else
                    a = False
                End If
                cek_upload = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                NoBukti2 = GridView1.GetRowCellValue(i, "NoBukti2")
                query = "update banktransfer set Proses='" & a & "' where NoBukti='" & NoBukti2 & "' "
                MainModul.ExecQueryByCommandSolomon(query)

            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView1.Columns.Clear()
        GridView1.RefreshData()

        LoadDataTr()
    End Sub
    Private Sub simpan_gj()
        Try
            Dim query As String
            Dim cek_upload As Boolean
            Dim GJID2 As String
            Dim a As Boolean
            For i As Integer = 0 To GridView1.RowCount - 1
                GJID2 = GridView1.GetRowCellValue(i, "GJID2")
                a = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                If a = True Then
                    a = True
                Else
                    a = False
                End If
                cek_upload = If(GridView1.GetRowCellValue(i, "Pilih") Is DBNull.Value, False, Convert.ToDouble(GridView1.GetRowCellValue(i, "Pilih")))
                GJID2 = GridView1.GetRowCellValue(i, "GJID2")
                query = "update gj_header set Proses='" & a & "' where GJID='" & GJID2 & "' "
                MainModul.ExecQueryByCommandSolomon(query)

            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView1.Columns.Clear()
        GridView1.RefreshData()

        LoadDataGJ()
    End Sub
    Private Sub LoadDataxx()
        Try
            If _TxtPerpost.Text = "" Then

                Throw New Exception("Silahkan pilih perpost!")
            End If
            Cursor = Cursors.WaitCursor
            Objgl = New GJHeaderModel
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = Objgl.GetGJPerpost(IIf(_TxtCuryID.Text = "", "ALL", _TxtCuryID.Text), _TxtPerpost.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)


            GridView1.Columns("Perpost").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("NoBukti").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AcctID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Keterangan").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CuryID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Transaksi").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataTr()
        Try
            If _TxtPerpost.Text = "" Then

                Throw New Exception("Silahkan pilih perpost!")
            End If
            Cursor = Cursors.WaitCursor
            Objgl = New GJHeaderModel
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = Objgl.GetTRPerpost(IIf(_TxtCuryID.Text = "", "ALL", _TxtCuryID.Text), _TxtPerpost.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)


            GridView1.Columns("Perpost").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("NoBukti").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AcctID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Keterangan").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CuryID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Transaksi").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadDataGJ()
        Try
            If _TxtPerpost.Text = "" Then

                Throw New Exception("Silahkan pilih perpost!")
            End If
            Cursor = Cursors.WaitCursor
            Objgl = New GJHeaderModel
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = Objgl.GetGLPerpost(IIf(_TxtCuryID.Text = "", "ALL", _TxtCuryID.Text), _TxtPerpost.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
            GridView1.Columns("cek_upload").Visible = False

            GridView1.Columns("Perpost").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("GJID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AcctID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Keterangan").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Currency").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            ''   GridView1.Columns("Transaksi").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If _TxtTransaksi.Text = "Cash Transaction" Then
            LoadDataxx()

        ElseIf _TxtTransaksi.Text = "Cash Transfer" Then
            LoadDataTr()
        ElseIf _TxtTransaksi.Text = "General Journal" Then
            LoadDataGJ()

        End If

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
    Private Sub _TxtPerpost_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _TxtPerpost.SelectedIndexChanged

    End Sub

    Private Sub _TxtPerpost_Click(sender As Object, e As EventArgs) Handles _TxtPerpost.Click
        ListItemsPerpost()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmReportUploadGL.StartPosition = FormStartPosition.CenterScreen
        FrmReportUploadGL.TxtPerpost.Text = _TxtPerpost.Text
        FrmReportUploadGL.TxtCuryID.Text = _TxtCuryID.Text
        FrmReportUploadGL.TxtTransaksi.Text = _TxtTransaksi.Text
        FrmReportUploadGL.Show()
    End Sub

    Private Sub grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = Grid.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                Dim id As String = String.Empty
                Dim id2 As String = String.Empty
                Dim id3 As String = String.Empty
                Dim ket As String = String.Empty
                Dim suspendid As String = String.Empty
                Dim suspend1 As String = String.Empty
                Dim transaksi As String = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView1.GetRowCellValue(rowHandle, "NoBukti2")
                        ket = Mid(GridView1.GetRowCellValue(rowHandle, "NoBukti2"), 1, 2)
                        id2 = GridView1.GetRowCellValue(rowHandle, "ID")
                        id3 = GridView1.GetRowCellValue(rowHandle, "Noref").ToString().TrimEnd
                        transaksi = GridView1.GetRowCellValue(rowHandle, "Transaksi").ToString().TrimEnd
                        suspendid = GridView1.GetRowCellValue(rowHandle, "Noref").ToString().TrimEnd
                        suspend1 = IIf(GridView1.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridView1.GetRowCellValue(rowHandle, "SuspendID")))

                    End If
                Next rowHandle

                If transaksi = "AP" Then
                    Call CallFrm(id2, id,
                         GridView1.RowCount)
                ElseIf transaksi = "Receipt" Then
                    Call CallFrm2(id3, "bank",
                    GridView1.RowCount)
                ElseIf transaksi = "Transfer" Then
                    Call CallFrm4(id3, "bank",
                    GridView1.RowCount)
                ElseIf transaksi = "SettleCC" Then
                    Call CallFrm5(id3)
                ElseIf transaksi = "Advance" Then
                    Call CallFrmd(id3,
                             id3,
                             GridView1.RowCount)
                ElseIf transaksi = "Settle" Then

                    If suspend1 = "" Then
                        'Dim objGrid As DataGridView = sender
                        Call CallFrmDirect(id, suspendid,
                         GridView1.RowCount)
                    Else
                        'Dim objGrid As DataGridView = sender
                        Call CallFrmx(id,
                             suspendid,
                             GridView1.RowCount)
                    End If
                End If

            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Detail7 IsNot Nothing AndAlso ff_Detail7.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail7.Close()
        End If
        ff_Detail7 = New frm_payment_aprrove_details(ls_Code, ls_Code2, Me, li_Row, Grid, IsNew)
        ff_Detail7.MdiParent = FrmMain
        ff_Detail7.StartPosition = FormStartPosition.CenterScreen
        ff_Detail7.Show()
    End Sub
    Private Sub CallFrm2(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal ls_Code4 As String = "", Optional ByVal sts_skreen As Byte = 1, Optional ByVal li_Row As Integer = 0)
        If ff_Detail8 IsNot Nothing AndAlso ff_Detail8.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail8.Close()
        End If
        ff_Detail8 = New FrmBankReceipt_Detail(ls_Code, ls_Code2, ls_Code3, ls_Code4, sts_skreen, Me, li_Row, Grid)
        ff_Detail8.MdiParent = FrmMain
        ff_Detail8.StartPosition = FormStartPosition.CenterScreen
        ff_Detail8.Show()
    End Sub
    Private Sub CallFrm4(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal ls_Code4 As String = "", Optional ByVal sts_skreen As Byte = 1, Optional ByVal li_Row As Integer = 0)
        If ff_Detail81 IsNot Nothing AndAlso ff_Detail8.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail81.Close()
        End If
        ff_Detail81 = New FrmBankTransfer_Detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail81.MdiParent = FrmMain
        ff_Detail81.StartPosition = FormStartPosition.CenterScreen
        ff_Detail81.Show()
    End Sub
    Private Sub CallFrm5(Optional ByVal ls_Code As String = "")
        If ff_Detail31 IsNot Nothing AndAlso ff_Detail31.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail31.Close()
        End If
        ff_Detail31 = New FrmCCSettlement(ls_Code, Me)
        ff_Detail31.MdiParent = FrmMain
        ff_Detail31.StartPosition = FormStartPosition.CenterScreen
        ff_Detail31.Show()
    End Sub
    Private Sub CallFrm3(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Detail9 IsNot Nothing AndAlso ff_Detail9.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail9.Close()
        End If
        ff_Detail9 = New FrmDetailPaymentDirect1(ls_Code, ls_Code2, Me, li_Row, Grid, IsNew)
        ff_Detail9.MdiParent = FrmMain
        ff_Detail9.StartPosition = FormStartPosition.CenterScreen
        ff_Detail9.Show()
    End Sub

    Private Sub CallFrmDirect(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail1x IsNot Nothing AndAlso ff_Detail1x.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail1x.Close()
        End If
        ff_Detail1x = New FrmSuspendSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail1x.MdiParent = FrmMain
        ff_Detail1x.StartPosition = FormStartPosition.CenterScreen
        ff_Detail1x.Show()
    End Sub

    Private Sub CallFrmx(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detailx IsNot Nothing AndAlso ff_Detailx.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detailx.Close()
        End If
        ff_Detailx = New FrmSuspendSettleDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detailx.MdiParent = FrmMain
        ff_Detailx.StartPosition = FormStartPosition.CenterScreen
        ff_Detailx.Show()
    End Sub
    Private Sub CallFrmd(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detaild IsNot Nothing AndAlso ff_Detaild.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detaild.Close()
        End If
        ff_Detaild = New FrmSuspend_Detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detaild.MdiParent = FrmMain
        ff_Detaild.StartPosition = FormStartPosition.CenterScreen
        ff_Detaild.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
End Class
