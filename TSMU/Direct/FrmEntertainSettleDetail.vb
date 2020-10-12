Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmEntertainSettleDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjEntertainHeader As New EntertainHeaderModel
    Dim ObjEntertainDetail As New EntertainDetailModel
    Dim ObjSettle As New SettleHeader
    Dim ObjSettleDetail As New SettleDetail
    Dim clsSettleRelasi As New SettleRelasi

    Dim GridDtl As GridControl
    Dim dtDetail As DataTable
    Dim dtRelasi As DataTable
    Dim _SettleID As String = ""
    Dim _Tag As TagModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmEntertainSettleDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjSettle.ID = fs_Code
                ObjSettle.GetSettleByIdEnt()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Entertainment " & fs_Code2
            Else
                Me.Text = "Entertainment"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmEntertainSettle" ''FrmParent.Name.ToString
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CreateTable()
        dtDetail = New DataTable
        dtDetail.Columns.AddRange(New DataColumn(10) {New DataColumn("HeaderSeq", GetType(Integer)),
                                                    New DataColumn("Tgl", GetType(String)),
                                                    New DataColumn("SubAccount", GetType(String)),
                                                    New DataColumn("Account", GetType(String)),
                                                    New DataColumn("Description", GetType(String)),
                                                    New DataColumn("Nama", GetType(String)),
                                                    New DataColumn("Tempat", GetType(String)),
                                                    New DataColumn("Alamat", GetType(String)),
                                                    New DataColumn("Jenis", GetType(String)),
                                                    New DataColumn("SuspendAmount", GetType(String)),
                                                    New DataColumn("ActualAmount", GetType(Double))})
        GridDetail.DataSource = dtDetail
        GridViewDetail.OptionsView.ShowAutoFilterRow = False

        dtRelasi = New DataTable
        dtRelasi.Columns.AddRange(New DataColumn(5) {New DataColumn("HeaderSeq", GetType(Integer)),
                                                    New DataColumn("Nama", GetType(String)),
                                                    New DataColumn("Posisi", GetType(String)),
                                                    New DataColumn("Perusahaan", GetType(String)),
                                                    New DataColumn("JenisUsaha", GetType(String)),
                                                    New DataColumn("Remark", GetType(String))})
        GridRelasi.DataSource = dtRelasi
        GridViewRelasi.OptionsView.ShowAutoFilterRow = False
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code2 <> "" Then
                ObjSettle.SettleID = fs_Code2
                dtDetail = ObjSettleDetail.GetDataDetailByID(fs_Code2)
                GridDetail.DataSource = dtDetail

                dtRelasi = ObjSettleDetail.GetDataDetailRelasiByID(fs_Code2)
                GridRelasi.DataSource = dtRelasi
            Else
                CreateTable()
            End If

            ListItemsJenis()
            ListItemsPosisi()
            ListItemsJenisUsaha()
            ListItemsRemark()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
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

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjSettle
                    TxtNoSuspend.Text = .SuspendID
                    TxtCurrency.Text = .CuryID
                    TxtNoSettlement.Text = .SettleID
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTgl.EditValue = .Tgl
                    TxtTotal.EditValue = .TotalSuspend
                    TxtTotExpense.EditValue = .Total
                    txtNoPR.Text = .noPR
                End With
            Else
                TxtNoSuspend.Text = ""
                TxtCurrency.Text = ""
                TxtDep.Text = ""
                TxtRemark.Text = ""
                TxtStatus.Text = ""
                TxtTgl.EditValue = Date.Today
                TxtTotal.EditValue = 0
                TxtTotExpense.EditValue = 0
                txtNoPR.Text = ""
                TxtNoSuspend.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If isUpdate Then
                If ObjSettle.pay = 1 Then
                    Err.Raise(ErrNumber, , "No Entertainment " & TxtNoSettlement.Text & " sudah dilakukan proses Payment !")
                ElseIf ObjSettle.CheckSettleAccrued(TxtNoSettlement.Text) Then
                    Err.Raise(ErrNumber, , "No Entertainment " & TxtNoSettlement.Text & " sudah dilakukan proses Accrued !")
                End If
            End If

            If GridViewDetail.RowCount = 0 Then
                Err.Raise(ErrNumber, , "Detail tidak boleh kosong ! !")
            End If

            If lb_Validated Then
                If isUpdate = False Then
                    _SettleID = ObjSettle.SettleAutoNoEnt
                    getDataGrid()
                    TxtNoSettlement.Text = _SettleID
                Else
                    _SettleID = TxtNoSettlement.Text
                    getDataGrid()
                End If
                With ObjSettle
                    .SettleID = TxtNoSettlement.Text
                    .CuryID = TxtCurrency.Text
                    .DeptID = TxtDep.Text
                    .PRNo = txtNoPR.Text
                    .Remark = TxtRemark.Text
                    .Status = TxtStatus.Text
                    .PaymentType = "FINANCE"
                    .SuspendID = TxtNoSuspend.Text
                    .Tgl = TxtTgl.EditValue
                    .Total = TxtTotExpense.EditValue
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Private Sub getDataGrid()
        ObjSettle.ObjDetails.Clear()
        For i As Integer = 0 To GridViewDetail.RowCount - 1
            ObjSettleDetail = New SettleDetail
            With ObjSettleDetail
                .SettleID = _SettleID
                .HeaderSeq = IIf(GridViewDetail.GetRowCellValue(i, "HeaderSeq") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "HeaderSeq"))
                If String.IsNullOrEmpty(IIf(GridViewDetail.GetRowCellValue(i, "Tgl") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Tgl"))) Then
                    Err.Raise(ErrNumber, , "Tanggal detail tidak boleh kosong")
                End If
                .Tgl = IIf(GridViewDetail.GetRowCellValue(i, "Tgl") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "Tgl"))
                .SubAcct = IIf(GridViewDetail.GetRowCellValue(i, "SubAccount") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "SubAccount"))
                If String.IsNullOrEmpty(.SubAcct) Then
                    Err.Raise(ErrNumber, , "Sub Account detail tidak boleh kosong !")
                End If
                .AcctID = IIf(GridViewDetail.GetRowCellValue(i, "Account") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Account"))
                If String.IsNullOrEmpty(.AcctID) Then
                    Err.Raise(ErrNumber, , "Account detail tidak boleh kosong !")
                End If
                .Description = IIf(GridViewDetail.GetRowCellValue(i, "Description") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Description"))
                If String.IsNullOrEmpty(.Description) Then
                    Err.Raise(ErrNumber, , "Description detail tidak boleh kosong !")
                End If
                .Nama = IIf(GridViewDetail.GetRowCellValue(i, "Nama") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Nama"))
                If String.IsNullOrEmpty(.Nama) Then
                    Err.Raise(ErrNumber, , "Nama detail tidak boleh kosong !")
                End If
                .Tempat = IIf(GridViewDetail.GetRowCellValue(i, "Tempat") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Tempat"))
                If String.IsNullOrEmpty(.Tempat) Then
                    Err.Raise(ErrNumber, , "Tempat detail tidak boleh kosong !")
                End If
                .Alamat = IIf(GridViewDetail.GetRowCellValue(i, "Alamat") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Alamat"))
                If String.IsNullOrEmpty(.Alamat) Then
                    Err.Raise(ErrNumber, , "Alamat detail tidak boleh kosong !")
                End If
                .Jenis = IIf(GridViewDetail.GetRowCellValue(i, "Jenis") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Jenis"))
                If String.IsNullOrEmpty(.Jenis) Then
                    Err.Raise(ErrNumber, , "Jenis detail tidak boleh kosong !")
                End If
                .SuspendAmount = IIf(GridViewDetail.GetRowCellValue(i, "SuspendAmount") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SuspendAmount"))
                .SettleAmount = IIf(GridViewDetail.GetRowCellValue(i, "ActualAmount") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "ActualAmount"))
                If .SettleAmount = 0 Then
                    Err.Raise(ErrNumber, , "Actual Amount detail tidak boleh 0 !")
                End If
            End With
            ObjSettle.ObjDetails.Add(ObjSettleDetail)
        Next

        GridViewRelasi.ClearColumnsFilter()
        ObjSettle.ObjRelasi.Clear()
        For i As Integer = 0 To GridViewRelasi.RowCount - 1
            clsSettleRelasi = New SettleRelasi
            With clsSettleRelasi
                .SettleID = _SettleID
                .HeaderSeq = IIf(GridViewRelasi.GetRowCellValue(i, "HeaderSeq") Is DBNull.Value, 0, GridViewRelasi.GetRowCellValue(i, "HeaderSeq"))
                .NamaRelasi = IIf(GridViewRelasi.GetRowCellValue(i, "Nama") Is DBNull.Value, "", GridViewRelasi.GetRowCellValue(i, "Nama"))
                If String.IsNullOrEmpty(.NamaRelasi) Then
                    Err.Raise(ErrNumber, , "Nama Relasi tidak boleh kosong !")
                End If
                .Posisi = IIf(GridViewRelasi.GetRowCellValue(i, "Posisi") Is DBNull.Value, "", GridViewRelasi.GetRowCellValue(i, "Posisi"))
                If String.IsNullOrEmpty(.Posisi) Then
                    Err.Raise(ErrNumber, , "Posisi Relasi tidak boleh kosong !")
                End If
                .Relasi = IIf(GridViewRelasi.GetRowCellValue(i, "Perusahaan") Is DBNull.Value, "", GridViewRelasi.GetRowCellValue(i, "Perusahaan"))
                If String.IsNullOrEmpty(.Relasi) Then
                    Err.Raise(ErrNumber, , "Perusahaan Relasi tidak boleh kosong !")
                End If
                .JenisRelasi = IIf(GridViewRelasi.GetRowCellValue(i, "JenisUsaha") Is DBNull.Value, "", GridViewRelasi.GetRowCellValue(i, "JenisUsaha"))
                If String.IsNullOrEmpty(.JenisRelasi) Then
                    Err.Raise(ErrNumber, , "Jenis Usaha Relasi tidak boleh kosong !")
                End If
                .Nota = IIf(GridViewRelasi.GetRowCellValue(i, "Remark") Is DBNull.Value, "", GridViewRelasi.GetRowCellValue(i, "Remark"))
                If String.IsNullOrEmpty(.Nota) Then
                    Err.Raise(ErrNumber, , "Remark Relasi tidak boleh kosong !")
                End If
            End With
            ObjSettle.ObjRelasi.Add(clsSettleRelasi)
        Next
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                ObjSettle.InsertDataEntSettle()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjSettle.UpdateDataEntSettleDetail(TxtNoSettlement.Text)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjSettle.GetDataGridEnt()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtDep.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtNoSuspend) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub TxtNoSuspend_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoSuspend.ButtonClick
        Try
            ObjSettle = New SettleHeader
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjSettle.GetListSettleEnt
            ls_OldKode = TxtNoSuspend.Text
            ls_Judul = "Suspend"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(1).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                TxtNoSuspend.Text = Value2

                Dim dt As New DataTable
                ObjEntertainHeader = New EntertainHeaderModel
                ObjEntertainHeader.SuspendHeaderID = Value1
                ObjEntertainHeader.GetSuspenById()
                With ObjEntertainHeader
                    TxtNoSuspend.Text = .SuspendID
                    TxtCurrency.Text = .Currency
                    txtNoPR.Text = .PRNo
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtTotal.EditValue = .Total
                    TxtTotExpense.EditValue = 0
                End With

                dtDetail = ObjEntertainDetail.GetDataDetailByID1Ent(Value2)
                GridDetail.DataSource = dtDetail
                GridViewDetail.MoveFirst()

                dtRelasi = ObjEntertainDetail.GetDataRelasiByID(Value2)
                GridRelasi.DataSource = dtRelasi
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub hitungTotal()
        Try
            Dim _total As Decimal = 0
            For i As Integer = 0 To GridViewDetail.RowCount - 1
                If Not IsDBNull(GridViewDetail.GetRowCellValue(i, "ActualAmount")) Then
                    _total = _total + Convert.ToDecimal(GridViewDetail.GetRowCellValue(i, "ActualAmount"))
                End If
            Next
            TxtTotExpense.EditValue = _total
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ListItemsJenis()
        ObjEntertainHeader = New EntertainHeaderModel
        Dim dt = New DataTable
        dt = ObjEntertainHeader.GetListJenis()
        Dim itemsCollection As ComboBoxItemCollection = CJenisDetail.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(1))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub ListItemsPosisi()
        ObjEntertainHeader = New EntertainHeaderModel
        Dim dt = New DataTable
        dt = ObjEntertainHeader.GetListPosisi()
        Dim itemsCollection As ComboBoxItemCollection = CPosisiRelasi.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(1))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub ListItemsJenisUsaha()
        ObjEntertainHeader = New EntertainHeaderModel
        Dim dt = New DataTable
        dt = ObjEntertainHeader.GetListJenisUsaha()
        Dim itemsCollection As ComboBoxItemCollection = CJenisUsahaRelasi.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(1))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub ListItemsRemark()
        ObjEntertainHeader = New EntertainHeaderModel
        Dim dt = New DataTable
        dt = ObjEntertainHeader.GetListRemark()
        Dim itemsCollection As ComboBoxItemCollection = CRemarkRelasi.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(1))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub filterRelasi(ByVal _HeaderSeq As Integer)
        GridViewRelasi.Columns("HeaderSeq").FilterInfo = New ColumnFilterInfo("[HeaderSeq] = " & _HeaderSeq & "")
    End Sub

#Region "Event grid detail"
    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridDetail.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Enter OrElse e.KeyData = Keys.Tab Then
                ObjEntertainDetail = New EntertainDetailModel
                If GridViewDetail.FocusedColumn.FieldName = "SubAccount" Then
                    ObjEntertainDetail.SubAcct = GridViewDetail.GetFocusedRowCellValue("SubAccount").ToString()
                    Dim dt As New DataTable
                    dt = ObjEntertainDetail.GetSubAccountbyid
                    If dt.Rows.Count > 0 Then
                        GridViewDetail.FocusedColumn = GridViewDetail.VisibleColumns(1)
                        GridViewDetail.ShowEditor()
                        GridViewDetail.UpdateCurrentRow()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                        GridViewDetail.FocusedColumn = GridViewDetail.VisibleColumns(0)
                    End If
                ElseIf GridViewDetail.FocusedColumn.FieldName = "ActualAmount" Then
                    GridViewDetail.MoveNext()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridViewDetail_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewDetail.CellValueChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        If view.UpdateCurrentRow() Then
        End If
    End Sub

    Private Sub GridDetail_DoubleClick(sender As Object, e As EventArgs) Handles GridDetail.DoubleClick
        Dim headerSeq As Integer = 1
        Dim maxValue As Integer
        maxValue = IIf(dtDetail.Compute("Max(HeaderSeq)", "") Is DBNull.Value, 0, dtDetail.Compute("Max(HeaderSeq)", ""))
        If maxValue >= headerSeq Then
            headerSeq = maxValue + 1
        End If

        GridViewDetail.AddNewRow()
        GridViewDetail.OptionsNavigation.AutoFocusNewRow = True
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "SettleID", TxtNoSettlement.Text)
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "SuspendAmount", 0)
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "ActualAmount", 0)
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq", headerSeq)
        GridViewDetail.RefreshData()
        GridViewRelasi.ClearColumnsFilter()
        GridViewRelasi.AddNewRow()
        GridViewRelasi.OptionsNavigation.AutoFocusNewRow = True
        GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", TxtNoSettlement.Text)
        GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "HeaderSeq", headerSeq)
        GridViewRelasi.RefreshData()
        filterRelasi(headerSeq)
    End Sub

    Private Sub GridDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles GridDetail.KeyDown
        Try
            If e.KeyCode = Keys.F1 AndAlso Not String.IsNullOrEmpty(TxtNoSuspend.Text) Then
                GridDetail_DoubleClick(sender, e)
            ElseIf e.KeyCode = Keys.Delete Then
                Dim indexRemove As Integer = GridViewDetail.FocusedRowHandle
                Dim headerSeqRemove As Integer = IIf(GridViewDetail.GetRowCellValue(indexRemove, "HeaderSeq") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(indexRemove, "HeaderSeq"))
                GridViewDetail.DeleteRow(indexRemove)
                GridViewDetail.RefreshData()
                hitungTotal()

                Dim RowsTOdelete As DataRow()
                RowsTOdelete = dtRelasi.Select("HeaderSeq=" & headerSeqRemove & "")
                For Each dr As DataRow In RowsTOdelete
                    dtRelasi.Rows.Remove(dr)
                Next
                GridViewRelasi.RefreshData()

                Dim headerSeq As Integer = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq"))
                filterRelasi(headerSeq)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub ReposDate_EditValueChanged(sender As Object, e As EventArgs) Handles ReposDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GridViewDetail_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridViewDetail.FocusedRowChanged
        Dim headerSeq As Integer
        headerSeq = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq"))
        filterRelasi(headerSeq)
    End Sub

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            ObjEntertainHeader = New EntertainHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjEntertainHeader.GetAccount
            ls_OldKode = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Account"))
            ls_Judul = "Account"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Account", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GSubAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GSubAccount.ButtonClick
        Try
            ObjEntertainHeader = New EntertainHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjEntertainHeader.GetSubAccount
            ls_OldKode = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "SubAccount") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "SubAccount"))
            ls_Judul = "Sub Account"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "SubAccount", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ReposActual_EditValueChanged(sender As Object, e As EventArgs) Handles ReposActual.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        hitungTotal()
    End Sub

    Private Sub CDescription_EditValueChanged(sender As Object, e As EventArgs) Handles CDescription.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CNamaDetail_EditValueChanged(sender As Object, e As EventArgs) Handles CNamaDetail.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CTempat_EditValueChanged(sender As Object, e As EventArgs) Handles CTempat.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CAlamat_EditValueChanged(sender As Object, e As EventArgs) Handles CAlamat.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CJenisDetail_EditValueChanged(sender As Object, e As EventArgs) Handles CJenisDetail.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

#End Region

#Region "Event grid relasi"
    Private Sub GridViewRelasi_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewRelasi.CellValueChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        'view.CloseEditor()
        If view.UpdateCurrentRow() Then
        End If
    End Sub

    Private Sub GridRelasi_DoubleClick(sender As Object, e As EventArgs) Handles GridRelasi.DoubleClick
        Dim headerSeq As Integer
        Dim indexDetail As Integer = GridViewDetail.FocusedRowHandle
        If indexDetail < 0 Then
            MessageBox.Show("Select detailnya dulu!", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
        Else
            headerSeq = GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "HeaderSeq")
            GridViewRelasi.ClearColumnsFilter()
            GridViewRelasi.AddNewRow()
            GridViewRelasi.OptionsNavigation.AutoFocusNewRow = True
            GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", TxtNoSettlement.Text)
            GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "HeaderSeq", headerSeq)
            filterRelasi(headerSeq)
        End If
    End Sub

    Private Sub GridRelasi_KeyDown(sender As Object, e As KeyEventArgs) Handles GridRelasi.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                GridRelasi_DoubleClick(sender, e)
            ElseIf e.KeyCode = Keys.Delete Then
                Dim headerSeq As Integer = GridViewRelasi.GetRowCellValue(GridViewRelasi.FocusedRowHandle, "HeaderSeq")
                Dim rowDetail As Integer
                Dim rowRelasi As Integer
                rowDetail = dtDetail.Select("HeaderSeq = '" & headerSeq & "'").Count
                rowRelasi = dtRelasi.Select("HeaderSeq = '" & headerSeq & "'").Count
                If rowRelasi <= 1 AndAlso rowDetail <> 0 Then
                    Err.Raise(ErrNumber, , "Data relasi tidak boleh kosong !")
                End If
                GridViewRelasi.DeleteRow(GridViewRelasi.FocusedRowHandle)
                GridViewRelasi.RefreshData()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CNamaRelasi_EditValueChanged(sender As Object, e As EventArgs) Handles CNamaRelasi.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CPosisiRelasi_EditValueChanged(sender As Object, e As EventArgs) Handles CPosisiRelasi.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CPerusahaan_EditValueChanged(sender As Object, e As EventArgs) Handles CPerusahaan.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CJenisUsahaRelasi_EditValueChanged(sender As Object, e As EventArgs) Handles CJenisUsahaRelasi.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CRemarkRelasi_EditValueChanged(sender As Object, e As EventArgs) Handles CRemarkRelasi.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

#End Region

End Class
