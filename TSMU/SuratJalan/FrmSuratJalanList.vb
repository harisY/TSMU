﻿Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class FrmSuratJalanList
    Dim SuratJalan As New ClsSJ
    Dim dtGrid As DataTable
    Dim No As String
    Private Sub FrmSuratJalanList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_TglSJFrom.Properties.MinValue = DateTime.Parse("2018/08/01")
        '_TglSJTo.Properties.MinValue = DateTime.Parse("2018/08/01")

        _TxtTglKirimFrom.Text = DateTime.Now
        _TglKirimTo.Text = DateTime.Now

        _TglSJFrom.Text = DateTime.Today
        _TglSJTo.Text = DateTime.Today
        'LoadSiteByIp()
        '_cmSite.Text = Site2
        _TxtLokasi.Text = gh_Common.Site
        _TxtLokasi.ReadOnly = True
        XtraTabControl1.SelectedTabPageIndex = 0
        LayoutControlItem5.Enabled = False
        LayoutControlItem6.Enabled = False
        Call Proc_EnableButtons(True, True, False, True, True, False, True, True, False, False)
    End Sub

    Private Sub LoadData()
        Try
            Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            'dt = SuratJalan.GetdataGrid(IIf(_txtCust.Text = "", "ALL", _txtCust.Text), _dtTgl1.Value.ToString("MM-dd-yyyy"), _dtTgl2.Value.ToString("MM-dd-yyyy"), Site2)
            dt = SuratJalan.GetdataGrid(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), _TglSJFrom.Text, _TglSJTo.Text, _TxtLokasi.Text)
            _Grid.DataSource = dt
            Cursor = Cursors.Default

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadDataEdit()
        Try
            Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            'dt = SuratJalan.GetdataGridEdit(IIf(_txtCust.Text = "", "ALL", _txtCust.Text), _dtTgl1.Value.ToString("MM-dd-yyyy"), _dtTgl2.Value.ToString("MM-dd-yyyy"), Site2)
            dt = SuratJalan.GetdataGridEdit(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), _TglSJFrom.Text, _TglSJTo.Text, _TxtLokasi.Text, _TxtTglKirimFrom.Text, _TglKirimTo.Text)
            _Grid1.DataSource = dt
            'btnFilter.Enabled = True
            Cursor = Cursors.Default
            '_Grid.Columns(2).ValueType = calenderCol
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Proc_Excel()
        Try
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                If GridView1.RowCount > 0 Then
                    Dim save As New SaveFileDialog With {
                        .Filter = "Excel File|*.xls",
                        .Title = "Save an Excel File"
                    }
                    If save.ShowDialog = DialogResult.OK Then
                        _Grid.ExportToXls(save.FileName)
                    End If
                Else
                    Throw New Exception("Tidak ada Data yg di export")
                End If
            Else
                If GridView2.RowCount > 0 Then
                    Dim save As New SaveFileDialog With {
                        .Filter = "Excel File|*.xls",
                        .Title = "Save an Excel File"
                    }
                    If save.ShowDialog = DialogResult.OK Then
                        _Grid1.ExportToXls(save.FileName)
                    End If
                Else
                    Throw New Exception("Tidak ada Data yg di export")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            LoadData()
        Else
            LoadDataEdit()
        End If
    End Sub
    Public Overrides Sub Proc_Refresh()
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            _Grid.DataSource = Nothing
        Else
            _Grid1.DataSource = Nothing
        End If
    End Sub

    Public Function GetAutoNo() As String
        Dim Nomor As String = String.Empty
        Try
            Dim bulan As String = String.Empty
            Dim tahun As String = String.Empty
            Dim urut As String = String.Empty
            Dim prefix As String = String.Empty
            Dim NoTerima As String = String.Empty
            'SuratJalan.UpdateNo(tahun,bulan,)
            Dim dt As New DataTable
            dt = SuratJalan.GetNo(_TxtLokasi.Text)
            If dt.Rows.Count > 0 Then
                prefix = dt.Rows(0)(1).ToString
                tahun = dt.Rows(0)(2).ToString
                bulan = dt.Rows(0)(3).ToString
                urut = dt.Rows(0)(4).ToString
            End If
            If tahun = DateTime.Today.Year Then
                If bulan = DateTime.Today.Month Then
                    If Len(urut) = 1 Then
                        NoTerima = prefix & "/" & tahun & "-" & bulan & "/" & "000" & urut
                    ElseIf Len(urut) = 2 Then
                        NoTerima = prefix & "/" & tahun & "-" & bulan & "/" & "00" & urut
                    ElseIf Len(urut) = 3 Then
                        NoTerima = prefix & "/" & tahun & "-" & bulan & "/" & "0" & urut
                    ElseIf Len(urut) = 4 Then
                        NoTerima = prefix & "/" & tahun & "-" & bulan & "/" & urut
                    End If
                    Nomor = NoTerima
                Else
                    SuratJalan.UpdateNoToZero(tahun, bulan, 1, _TxtLokasi.Text)
                    GetAutoNo()
                End If
            End If
        Catch ex As Exception
            Nomor = ""
            MsgBox(ex.Message)
        End Try
        Return Nomor
    End Function
    Public Overrides Sub Proc_PrintPreview()
        Try
            If XtraTabControl1.SelectedTabPageIndex = 1 Then
                If GridView2.RowCount = 0 Then
                    Throw New Exception("Tidak ada data yang di akan print.")
                End If
                Dim IsNoTranEmpty As Boolean = False
                Dim ValidateNotran As Boolean = True
                For i As Integer = 0 To GridView2.RowCount - 1
                    IsNoTranEmpty = SuratJalan.CheckNoTran(GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan")))
                    If IsNoTranEmpty Then
                        ValidateNotran = False
                        Exit For
                    End If
                Next

                No = GetAutoNo()

                If ValidateNotran Then
                    SuratJalan.NoTran = No

                    For i As Integer = 0 To GridView2.RowCount - 1
                        SuratJalan.ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                        SuratJalan.UpdateNoTran()
                    Next

                Else
                    MsgBox("No Trans sudah ada.")
                    Exit Sub
                End If

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = New DataTable
                ds = SuratJalan.PrintPO(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), _TglSJFrom.Text, _TglSJTo.Text, _TxtLokasi.Text, _TxtTglKirimFrom.Text, _TglKirimTo.Text)

                dt = ds.Tables("PrintPO")

                Dim Laporan As PrintPO = New PrintPO
                With Laporan
                    .param1 = No
                    .param2 = No
                    .DataSource = dt
                    '.DataMember = ds.Tables("PrintPO").TableName
                End With

                Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                    PrintTool.ShowPreviewDialog()
                    PrintTool.ShowPreview(UserLookAndFeel.Default)
                End Using
                SuratJalan.UpdateNo(DateTime.Now.Year, DateTime.Now.Month, 1, _TxtLokasi.Text)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Print()
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = SuratJalan.GetNoTranPrint
            ls_OldKode = No
            ls_Judul = "Surat Jalan"

            Dim lF_SearchData As FrmSystem_FilterDev
            lF_SearchData = New FrmSystem_FilterDev(dtSearch) With {
                .Text = "Select Data " & ls_Judul,
                .StartPosition = FormStartPosition.CenterScreen
            }
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                'ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    No = ls_Kode
                End If
            End If
            lF_SearchData.Close()

            SuratJalan.NoTran = No
            Dim ds As DataSet = New DataSet
            Dim dt As DataTable = New DataTable
            ds = SuratJalan.ReprintPrintPO()
            dt = ds.Tables("PrintPO")
            Dim Laporan As PrintPO = New PrintPO
            With Laporan
                .param1 = No
                .param2 = No
                .DataSource = dt
                '.DataMember = ds.Tables("PrintPO").TableName
            End With

            Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                PrintTool.ShowPreviewDialog()
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                If GridView1.RowCount = 0 Then
                    MsgBox("Tidak ada data yang akan di simpan.")
                    Exit Sub
                End If

                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim Checked As Boolean = False
                    Dim ShipperID, NoRec As String
                    Dim RelDate, RecDate, TglKirim As DateTime

                    ShipperID = GridView1.GetRowCellValue(i, GridView1.Columns("No Surat Jalan"))
                    RelDate = DateTime.ParseExact(GridView1.GetRowCellValue(i.ToString, GridView1.Columns("Tanggal SJ")), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    RecDate = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Tanggal Terima")) Is DBNull.Value, DateTime.Now, (GridView1.GetRowCellValue(i, GridView1.Columns("Tanggal Terima"))))
                    TglKirim = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Tanggal Kirim")) Is DBNull.Value, DateTime.Now, (GridView1.GetRowCellValue(i, GridView1.Columns("Tanggal Kirim"))))
                    Checked = GridView1.GetRowCellValue(i, "Check")
                    NoRec = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("NoRec")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("NoRec")))
                    If Checked Then
                        Dim IsShipperExist As Boolean
                        With SuratJalan
                            .UpdateUser6(ShipperID, Checked)
                            .ShipperID = ShipperID
                            .RelDate = RelDate
                            .RecDate = RecDate
                            .TglKirim = TglKirim
                            .NoRec = NoRec
                            .CreatedBy = gh_Common.Username
                            .Checked = Checked
                            Try
                                IsShipperExist = .IsShipperIDExist
                                If IsShipperExist Then
                                    .UpdateToTableNew()
                                Else
                                    .InsertToTable()
                                End If

                            Catch ex As Exception

                                MsgBox(ex.Message)
                                Continue For
                                'Throw ex
                            End Try

                        End With
                    End If
                Next
                MsgBox("Done !", MsgBoxResult.No)

                LoadData()
            Else
                If GridView2.RowCount = 0 Then
                    MsgBox("Tidak ada data yang akan di simpan.")
                    Exit Sub
                End If

                For i As Integer = 0 To GridView2.RowCount - 1
                    Dim Checked As Boolean = False
                    Dim CheckedFin As Boolean = False
                    Dim ShipperID, NoRec As String
                    Dim RelDate, RecDate, TglKirim As DateTime

                    ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                    RelDate = DateTime.ParseExact(GridView2.GetRowCellValue(i.ToString, GridView2.Columns("Tanggal SJ")), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    RecDate = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Terima")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Terima"))))
                    TglKirim = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Kirim")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tanggal Kirim"))))
                    Checked = GridView2.GetRowCellValue(i, "Check")
                    CheckedFin = GridView2.GetRowCellValue(i, "Check Fin")
                    NoRec = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("NoRec")) Is DBNull.Value, "", GridView2.GetRowCellValue(i, GridView2.Columns("NoRec")))
                    If Not Checked Then
                        Try
                            If CheckedFin Then
                                Throw New Exception("Shipper ID " & ShipperID & " Sudah di checklist oleh finance tidak bisa di edit.")
                            End If
                            Dim IsShipperExist As Boolean
                            With SuratJalan
                                .UpdateUser6(ShipperID, False)
                                .ShipperID = ShipperID
                                .RelDate = RelDate
                                .RecDate = RecDate
                                .TglKirim = TglKirim
                                .NoRec = NoRec
                                .CreatedBy = gh_Common.Username
                                .Checked = Checked
                                IsShipperExist = .IsShipperIDExist
                                If IsShipperExist Then
                                    .UpdateToTable()
                                Else
                                    .InsertToTable()
                                End If

                            End With
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Continue For
                        End Try

                    End If
                Next
                MsgBox("Done !", MsgBoxResult.No)
                LoadDataEdit()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        _Grid.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub
    Private Sub RepositoryItemDateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit2.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit4.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemTextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit2.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.EditValueChanged
        _Grid.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit3.EditValueChanged
        _Grid.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemTextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit3.EditValueChanged
        _Grid.FocusedView.PostEditor()
    End Sub

    Private Sub _BtnCust_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _BtnCust.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = SuratJalan.GetCustomer
            ls_OldKode = _BtnCust.Text.Trim
            ls_Judul = "Customer"

            Dim lF_SearchData As FrmSystem_Filter
            lF_SearchData = New FrmSystem_Filter(dtSearch) With {
                .Text = "Select Data " & ls_Judul,
                .StartPosition = FormStartPosition.CenterScreen
            }
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                If sender.Name = _BtnCust.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    _BtnCust.Text = ls_Kode
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub XtraTabControl1_Click(sender As Object, e As EventArgs) Handles XtraTabControl1.Click
        If XtraTabControl1.SelectedTabPageIndex = 1 Then
            LayoutControlItem5.Enabled = True
            LayoutControlItem6.Enabled = True
            tsBtn_preview.Enabled = True
            tsBtn_print.Enabled = True
            'MsgBox(XtraTabControl1.SelectedTabPageIndex.ToString)
        Else
            LayoutControlItem5.Enabled = False
            LayoutControlItem6.Enabled = False
            tsBtn_preview.Enabled = True
            tsBtn_print.Enabled = True
            'MsgBox(XtraTabControl1.SelectedTabPageIndex.ToString)
        End If
    End Sub
End Class
