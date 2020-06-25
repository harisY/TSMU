﻿Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmTravelEntertainDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjEntertainDetail As New EntertainDetailModel
    Dim ObjSettle As New SettleHeader
    Dim ObjSettleDetail As New SettleDetail
    Dim DtScan As DataTable
    Dim DtScan1 As DataTable
    Dim _SettleID As String = ""
    Dim row As Integer
    Dim _Tag As TagModel

    Dim header As New DataTable
    Dim entertain As New DataTable
    Dim relasi As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
        End If
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    ReadOnly Property dtHeader() As DataTable
        Get
            Return header
        End Get
    End Property

    ReadOnly Property dtEntertain() As DataTable
        Get
            Return entertain
        End Get
    End Property

    ReadOnly Property dtRelasi() As DataTable
        Get
            Return relasi
        End Get
    End Property

    Private Sub FrmTravelEntertainDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)
        CreateTable()
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjSettle.ID = fs_Code
                ObjSettle.GetSettleById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "NEW ENTERTAINMENT"
            Else
                Me.Text = "ENTERTAINMENT"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjSettle
                    TxtCurrency.Text = .CuryID
                    TxtNoSettlement.Text = .SettleID
                    TxtDep.Text = gh_Common.GroupID
                    TxtRemark.Text = .Remark
                    TxtTgl.EditValue = .Tgl
                    TxtTotExpense.Text = Format(.Total, gs_FormatBulat)
                    TxtPrNo.Text = .PRNo
                End With
            Else
                TxtCurrency.Text = "IDR"
                TxtDep.Text = ""
                TxtRemark.Text = ""
                TxtTgl.EditValue = DateTime.Today
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code = "" Then
                Dim dtGrid As New DataTable
                ObjEntertainDetail.SuspendID = ""
                dtGrid = ObjEntertainDetail.GetDataDetailByID()
                GridEntertain.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridViewEntertain)
                End If
                Dim dtGrid2 As New DataTable
                ObjEntertainDetail.SuspendID = ""
                dtGrid2 = ObjEntertainDetail.GetDataDetailByID()
                GridRelasi.DataSource = dtGrid2
                If dtGrid2.Rows.Count > 0 Then
                    GridCellFormat(GridViewRelasi)
                End If
            Else
                Dim dtGrid As New DataTable
                dtGrid = ObjSettleDetail.GetDataDetailByID(fs_Code2)
                GridEntertain.DataSource = dtGrid
                Dim dtGrid2 As New DataTable
                dtGrid2 = ObjSettleDetail.GetDataDetailByID(fs_Code2)
                GridRelasi.DataSource = dtGrid2
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CreateTable()
        entertain = New DataTable
        entertain.Columns.AddRange(New DataColumn(8) {New DataColumn("Tgl", GetType(Date)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Nama", GetType(String)),
                                                            New DataColumn("Tempat", GetType(String)),
                                                            New DataColumn("Alamat", GetType(String)),
                                                            New DataColumn("Jenis", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})
        GridEntertain.DataSource = entertain

        relasi = New DataTable
        relasi.Columns.AddRange(New DataColumn(4) {New DataColumn("Nama", GetType(String)),
                                                           New DataColumn("Posisi", GetType(String)),
                                                           New DataColumn("Perusahaan", GetType(String)),
                                                           New DataColumn("JenisUsaha", GetType(String)),
                                                           New DataColumn("Remark", GetType(String))})
        GridRelasi.DataSource = relasi
    End Sub

    Public Overrides Sub Proc_print()
        Try
            Dim newform As New FrmReportSettleEntertain(TxtNoSettlement.Text)
            newform.StartPosition = FormStartPosition.CenterScreen
            newform.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadTxtBox()
        LoadGridDetail()
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                With ObjSettle
                    .CuryID = TxtCurrency.Text
                    .DeptID = TxtDep.Text
                    .Remark = TxtRemark.Text
                    '.SettleID = .SettleAutoNoEnt
                    '_SettleID = ObjSettle.SettleAutoNoEnt
                    .Tgl = TxtTgl.EditValue
                    .Total = TxtTotExpense.Text
                    .PRNo = TxtPrNo.Text
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        getdataview1()
        getdataview2()
    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridViewEntertain.RowCount - 1
                GridViewEntertain.MoveFirst()
                If GridViewEntertain.GetRowCellValue(i, GridViewEntertain.Columns("Account")).ToString = "" OrElse
                   GridViewEntertain.GetRowCellValue(i, GridViewEntertain.Columns("SubAccount")).ToString = "" OrElse
                   GridViewEntertain.GetRowCellValue(i, GridViewEntertain.Columns("Amount")).ToString = "" Then
                    IsEmpty = True
                    GridViewEntertain.DeleteRow(i)
                End If
            Next

            If isUpdate = False Then
                ObjSettle.ObjDetails.Clear()
                For i As Integer = 0 To GridViewEntertain.RowCount - 1
                    If GridViewEntertain.GetRowCellValue(i, "Amount").ToString <> "" Then
                        ObjSettleDetail = New SettleDetail
                        With ObjSettleDetail
                            .SettleID = _SettleID
                            .Tgl = CDate(GridViewEntertain.GetRowCellValue(i, "Tgl"))
                            .SubAcct = GridViewEntertain.GetRowCellValue(i, "SubAccount")
                            .AcctID = GridViewEntertain.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Description = GridViewEntertain.GetRowCellValue(i, "Description").ToString()
                            .Nama = GridViewEntertain.GetRowCellValue(i, "Nama")
                            .Tempat = GridViewEntertain.GetRowCellValue(i, "Tempat")
                            .Alamat = GridViewEntertain.GetRowCellValue(i, "Alamat")
                            .Jenis = GridViewEntertain.GetRowCellValue(i, "Jenis")
                            .SettleAmount = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "Amount"))
                        End With
                        ObjSettle.ObjDetails.Add(ObjSettleDetail)
                    End If
                Next

                ObjSettle.InsertDataEntSettleDirect()
            Else
                ObjSettle.ObjDetails.Clear()
                For i As Integer = 0 To GridViewEntertain.RowCount - 1
                    If GridViewEntertain.GetRowCellValue(i, "Amount").ToString <> "" Then
                        ObjSettleDetail = New SettleDetail
                        With ObjSettleDetail
                            .SettleID = TxtNoSettlement.Text
                            .AcctID = GridViewEntertain.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .SuspendAmount = If(GridViewEntertain.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "Amount")))
                            .SettleAmount = Convert.ToDouble(GridViewEntertain.GetRowCellValue(i, "Amount"))
                            .Description = GridViewEntertain.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridViewEntertain.GetRowCellValue(i, "SubAccount")
                            .Tgl = CDate(GridViewEntertain.GetRowCellValue(i, "Tgl"))
                            .Nama = GridViewEntertain.GetRowCellValue(i, "Nama")
                            .Tempat = GridViewEntertain.GetRowCellValue(i, "Tempat")
                            .Alamat = GridViewEntertain.GetRowCellValue(i, "Alamat")
                            .Jenis = GridViewEntertain.GetRowCellValue(i, "Jenis")
                        End With
                        ObjSettle.ObjDetails.Add(ObjSettleDetail)
                    End If
                Next

                ObjSettle.UpdateData(TxtNoSettlement.Text)
            End If

            'If GridDtl.Name <> "GridEntertain" Then
            '    GridDtl.DataSource = ObjSettle.GetDataGrid()
            'Else
            'End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub getdataview2()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridViewRelasi.RowCount - 1
                GridViewRelasi.MoveFirst()
                If GridViewRelasi.GetRowCellValue(i, GridViewRelasi.Columns("Nama")).ToString = "" OrElse
                    GridViewRelasi.GetRowCellValue(i, GridViewRelasi.Columns("Posisi")).ToString = "" OrElse
                    GridViewRelasi.GetRowCellValue(i, GridViewRelasi.Columns("Perusahaan")).ToString = "" OrElse
                    GridViewRelasi.GetRowCellValue(i, GridViewRelasi.Columns("JenisUsaha")).ToString = "" OrElse
                    GridViewRelasi.GetRowCellValue(i, GridViewRelasi.Columns("Remark")).ToString = "" Then
                    IsEmpty = True
                    GridViewRelasi.DeleteRow(i)
                End If
            Next

            If isUpdate = False Then
                'ObjEntertainHeader.ObjDetails.Clear()
                'For i As Integer = 0 To GridView2.RowCount - 1
                '    If GridView2.GetRowCellValue(i, "Nama") <> "" Then
                '        ObjEntertainDetail = New EntertainDetailModel
                '        With ObjEntertainDetail
                '            .SettleID = _SettleID
                '            .NamaRelasi = GridView2.GetRowCellValue(i, "Nama")
                '            .Posisi = GridView2.GetRowCellValue(i, "Posisi")
                '            .Relasi = GridView2.GetRowCellValue(i, "Perusahaan").ToString().TrimEnd
                '            .JenisRelasi = GridView2.GetRowCellValue(i, "JenisUsaha").ToString()
                '            .Nota = GridView2.GetRowCellValue(i, "Remark").ToString()

                '        End With
                '        ObjEntertainHeader.ObjDetails.Add(ObjEntertainDetail)
                '    End If
                'Next
                'ObjEntertainHeader.InsertDataRelasiSettle()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else


                'ObjEntertainHeader.ObjDetails.Clear()
                'For i As Integer = 0 To GridView2.RowCount - 1
                '    If GridView2.GetRowCellValue(i, "Nama") <> "" Then
                '        ObjEntertainDetail = New EntertainDetailModel
                '        With ObjEntertainDetail
                '            .SettleID = _SettleID
                '            .NamaRelasi = GridView2.GetRowCellValue(i, "Nama")
                '            .Posisi = GridView2.GetRowCellValue(i, "Posisi")
                '            .Relasi = GridView2.GetRowCellValue(i, "Perusahaan").ToString().TrimEnd
                '            .JenisRelasi = GridView2.GetRowCellValue(i, "JenisUsaha").ToString()
                '            .Nota = GridView2.GetRowCellValue(i, "Remark").ToString()
                '        End With
                '        ObjEntertainHeader.ObjDetails.Add(ObjEntertainDetail)
                '    End If
                'Next
                'ObjEntertainHeader.UpdateDataRelasi()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            'If GridDtl.Name = "GridEntertain" Then
            '    Dim dtTable As DataTable = GridDtl.DataSource
            '    dtTable.Rows(row)("EntertainID") = _SettleID
            '    dtTable.Rows(row)("Description") = TxtRemark.Text
            '    dtTable.Rows(row)("CurryID") = TxtCurrency.Text
            '    dtTable.Rows(row)("Amount") = TxtTotExpense.Text
            'Else
            '    'GridDtl.DataSource = ObjEntertainHeader.GetDataGrid()
            'End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridEntertain.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _tot As Decimal = 0
                _tot = GetTot()
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter OrElse e.KeyData = Keys.Tab Then

                ObjEntertainDetail = New EntertainDetailModel
                If GridViewEntertain.FocusedColumn.FieldName = "SubAccount" Then
                    ObjEntertainDetail.SubAcct = GridViewEntertain.GetFocusedRowCellValue("SubAccount").ToString()
                    Dim dt As New DataTable
                    dt = ObjEntertainDetail.GetSubAccountbyid
                    If dt.Rows.Count > 0 Then
                        GridViewEntertain.FocusedColumn = GridViewEntertain.VisibleColumns(1)
                        GridViewEntertain.ShowEditor()
                        GridViewEntertain.UpdateCurrentRow()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                        GridViewEntertain.FocusedColumn = GridViewEntertain.VisibleColumns(0)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            'ObjEntertainHeader = New EntertainHeaderModel
            'Dim ls_Judul As String = ""
            'Dim dtSearch As New DataTable
            'Dim ls_OldKode As String = ""

            'dtSearch = ObjEntertainHeader.GetAccount
            'ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account"))
            'ls_Judul = "Account"

            'Dim lF_SearchData As FrmSystem_LookupGrid
            'lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            'lF_SearchData.Text = "Select Data " & ls_Judul
            'lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            'lF_SearchData.ShowDialog()
            'Dim Value1 As String = ""
            'Dim Value2 As String = ""

            'If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
            '    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
            '    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
            '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
            'End If
            'lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Function GetTot() As Decimal
        Dim _total As Decimal = 0

        Try
            For i As Integer = 0 To GridViewEntertain.RowCount - 1
                If Not IsDBNull(GridViewEntertain.GetRowCellValue(i, "Amount")) Then
                    _total = _total + Convert.ToDecimal(GridViewEntertain.GetRowCellValue(i, "Amount"))
                End If
            Next
            Return _total
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GSubAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GSubAccount.ButtonClick
        Try
            'ObjEntertainHeader = New EntertainHeaderModel
            'Dim ls_Judul As String = ""
            'Dim dtSearch As New DataTable
            'Dim ls_OldKode As String = ""


            'dtSearch = ObjEntertainHeader.GetSubAccount
            'ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount"))
            'ls_Judul = "Sub Account"


            'Dim lF_SearchData As FrmSystem_LookupGrid
            'lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            'lF_SearchData.Text = "Select Data " & ls_Judul
            'lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            'lF_SearchData.ShowDialog()
            'Dim Value1 As String = ""
            'Dim Value2 As String = ""

            'If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
            '    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
            '    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
            '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", Value1)
            'End If
            'lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GSubAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GSubAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtCurrency.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtCurrency) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub ReposActual_EditValueChanged(sender As Object, e As EventArgs) Handles ReposActual.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub FrmTravelEntertainDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridViewEntertain.AddNewRow()
            GridViewEntertain.OptionsNavigation.AutoFocusNewRow = True
            GridViewEntertain.FocusedColumn = GridViewEntertain.VisibleColumns(0)
            GridViewRelasi.AddNewRow()
            GridViewRelasi.OptionsNavigation.AutoFocusNewRow = True
            GridViewRelasi.FocusedColumn = GridViewRelasi.VisibleColumns(0)
        End If
    End Sub

    Private Sub ReposDate_EditValueChanged(sender As Object, e As EventArgs) Handles ReposDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GridViewEntertain_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewEntertain.CellValueChanged
        Dim Total As Double = 0
        For i As Integer = 0 To GridViewEntertain.RowCount - 1
            If Not GridViewEntertain.GetRowCellValue(i, "Amount") Is DBNull.Value Then
                Total = Total + GridViewEntertain.GetRowCellValue(i, "Amount")
            End If
        Next
        TxtTotExpense.Text = Format(Total, gs_FormatBulat)
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            'ObjEntertainHeader = New EntertainHeaderModel
            'Dim ls_Judul As String = ""
            'Dim dtSearch As New DataTable
            'Dim ls_OldKode As String = ""

            'dtSearch = ObjEntertainHeader.GetDept
            'ls_OldKode = TxtDep.Text
            'ls_Judul = "Departemen"


            'Dim lF_SearchData As FrmSystem_LookupGrid
            'lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            'lF_SearchData.Text = "Select Data " & ls_Judul
            'lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            'lF_SearchData.ShowDialog()
            'Dim Value1 As String = ""
            'Dim Value2 As String = ""

            'If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
            '    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
            '    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
            '    TxtDep.Text = Value1
            'End If
            'lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridViewRelasi_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewRelasi.CellValueChanged
        GridViewRelasi.ShowEditor()
        GridViewRelasi.UpdateCurrentRow()
    End Sub

End Class