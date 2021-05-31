Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class Frmgl_Detail
    Private tbl As DataTable
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim ObjGJHeader As New GJHeaderModel
    Dim ObjGJDetail As New GJDetailModel
    Dim GridDtl As GridControl
    '' Dim f As Frmgl_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable


    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _GJID As String = ""
    Dim _GJID_Revers As String = ""
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
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(4) {New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Debit_Amount", GetType(Double)),
                                                             New DataColumn("Credit_Amount", GetType(Double))})

        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub Frmgl_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, False)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        'Call CreateTable()
        Call InitialSetForm()

        'Dim dtGrid As New DataTable
        'Grid.DataSource = dtGrid
        'If dtGrid.Rows.Count > 0 Then
        '    TxtAmountReq.Enabled = False
        'End If
    End Sub
    Private Sub AddRow(ByVal data As String)
        If data = String.Empty Then Return
        Dim rowData As String() = data.Split(New Char() {vbCr, vbTab})
        Dim newRow As DataRow = dtGrid.NewRow()

        For i As Integer = 0 To rowData.Length - 1
            If i >= dtGrid.Columns.Count Then Exit For
            newRow(i) = rowData(i)
        Next

        dtGrid.Rows.Add(newRow)
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim data As String() = ClipboardData.Split(vbLf)
            If data.Length < 1 Then Return

            For Each row As String In data
                AddRow(row)
            Next
        End If
        Dim DBTotal As Double = 0
        Dim CRTotal As Double = 0
        Dim Total As Double = 0

        For i As Integer = 0 To GridView1.RowCount - 1
            If Not GridView1.GetRowCellValue(i, "Credit_Amount") Is DBNull.Value Then
                CRTotal = CRTotal + GridView1.GetRowCellValue(i, "Credit_Amount")
            End If
            If Not GridView1.GetRowCellValue(i, "Debit_Amount") Is DBNull.Value Then
                DBTotal = DBTotal + GridView1.GetRowCellValue(i, "Debit_Amount")
            End If
            Total = DBTotal - CRTotal
        Next
        TxtTotalDb.Text = Format(DBTotal, gs_FormatDecimal)
        TxtTotalCr.Text = Format(CRTotal, gs_FormatDecimal)
    End Sub
    Private Property ClipboardData As String
        Get
            Dim iData As IDataObject = Clipboard.GetDataObject()
            If iData Is Nothing Then Return ""
            If iData.GetDataPresent(DataFormats.Text) Then Return CStr(iData.GetData(DataFormats.Text))
            Return ""
        End Get
        Set(ByVal value As String)
            Clipboard.SetDataObject(value)
        End Set
    End Property
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjGJHeader.GJHeaderID = fs_Code
                ObjGJHeader.GetGJById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "General Journal " & fs_Code
            Else
                Me.Text = "General Journal"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "Frmgl"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    'Dim dtGrid As New DataTable
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then

                ObjGJDetail.GJID = TxtNoGJ.Text
                dtGrid = ObjGJDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView1)
                End If
            Else
                'Dim dtGrid As New DataTable
                ObjGJDetail.GJID = ""
                dtGrid = ObjGJDetail.GetDataDetailByID()
                Grid.DataSource = dtGrid
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjGJHeader
                    TxtNoGJ.Text = .GJID
                    TxtNoRJ.Text = .GJID_Revers
                    TxtPrNo.Text = .PRNo

                    TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtRemark.Text = .Remark
                    TxtStatus.Text = .Status
                    TxtBatch.Text = .Batch
                    TxtTgl.EditValue = .Tgl
                    TxtPerpost.EditValue = Format(.Tgl, "yyyy-MM")
                    TxtTotalDb.Text = Format(.Total, gs_FormatDecimal)
                    TxtTotalCr.Text = Format(.TotalCr, gs_FormatDecimal)
                    If TxtNoRJ.Text = "" Or Microsoft.VisualBasic.Left(TxtNoRJ.Text, 2) <> "RJ" Then
                        ChkRevers.Checked = False
                    Else
                        ChkRevers.Checked = True
                    End If
                End With
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
            Else
                TxtNoGJ.Text = ""
                TxtNoRJ.Text = ""
                TxtPrNo.Text = ""
                TxtBatch.Text = ""
                TxtCurrency.SelectedIndex = 0
                TxtDep.Text = gh_Common.GroupID
                TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
                TxtRemark.Text = ""
                TxtStatus.Text = "Open"
                TxtTgl.EditValue = DateTime.Today
                '' TxtTgl.EditValue = Now.AddDays((Now.Day - 1) * -1).AddMonths(1)



                TxtTotalDb.Text = "0"
                TxtTotalCr.Text = "0"
                TxtPrNo.Focus()
                GridView1.AddNewRow()
                GridView1.OptionsNavigation.AutoFocusNewRow = True
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
        Total = 0
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If
            Dim bl As String
            Dim th As String
            bl = Microsoft.VisualBasic.Right(TxtPerpost.Text, 2)
            th = Year(TxtTgl.EditValue)
            If lb_Validated Then
                With ObjGJHeader
                    .bl = bl
                    .th = th
                    .Currency = TxtCurrency.Text
                    .DeptID = TxtDep.Text
                    .PRNo = TxtPrNo.Text
                    .Remark = TxtRemark.Text
                    .Status = TxtStatus.Text
                    .Batch = TxtBatch.Text
                    .Perpost = TxtPerpost.Text
                    .GJID = .GJAutoNo
                    _GJID = .GJAutoNo
                    .GJID_Revers = .RJAutoNo
                    _GJID_Revers = .RJAutoNo
                    ''    TxtTgl.EditValue = TxtTgl.EditValue.AddDays((TxtTgl.EditValue.Day - 1) * -1).AddMonths(1)
                    .Tgl = TxtTgl.EditValue
                    .Tipe = "S"
                    .Total = TxtTotalDb.Text
                    .TotalCr = TxtTotalCr.Text
                    'If isUpdate = False Then
                    '    .ValidateInsert()
                    'Else
                    '    .ValidateUpdate()
                    'End If
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Sub CallForm(Optional ByVal ID As String = "", Optional ByVal Nama As String = "", Optional ByVal IsNew As Boolean = True)

        'f = New Frmgl_Detail2(ID, Nama, IsNew, dt, Grid)
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.MaximizeBox = False
        'f.ShowDialog()

    End Sub
    Public Overrides Sub Proc_Approve()
        CallForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()
                If GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString = "" OrElse
                   GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString = "" Then
                    IsEmpty = True
                    GridView1.DeleteRow(i)
                End If
            Next
            'If IsEmpty Then
            '    Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
            'End If

            If isUpdate = False Then
                ObjGJHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjGJDetail = New GJDetailModel
                        With ObjGJDetail
                            .GJID = _GJID
                            .GJID_Revers = _GJID_Revers
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd

                            If GridView1.GetRowCellValue(i, "Debit_Amount") Is DBNull.Value Then
                                .Debit_Amount = 0
                            Else
                                .Debit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Debit_Amount"))
                            End If
                            If GridView1.GetRowCellValue(i, "Credit_Amount") Is DBNull.Value Then
                                .Credit_Amount = 0
                            Else
                                .Credit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Credit_Amount"))
                            End If
                            '.Debit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Debit_Amount"))
                            '.Credit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Credit_Amount"))
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                        End With
                        ObjGJHeader.ObjDetails.Add(ObjGJDetail)
                    End If
                Next

                ObjGJHeader.InsertData()
                If ChkRevers.Checked = True Then
                    Dim tglr As Date

                    tglr = TxtTgl.EditValue.AddDays((TxtTgl.EditValue.Day - 1) * -1).AddMonths(1)
                    ObjGJHeader.Tgl = tglr
                    ObjGJHeader.InsertDataR()
                End If
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjGJHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Account") <> "" Then
                        ObjGJDetail = New GJDetailModel
                        With ObjGJDetail
                            .GJID = TxtNoGJ.Text
                            .GJID_Revers = TxtNoRJ.Text
                            .GJID_Revers2 = _GJID_Revers
                            .AcctID = GridView1.GetRowCellValue(i, "Account").ToString().TrimEnd

                            If GridView1.GetRowCellValue(i, "Debit_Amount") Is DBNull.Value Then
                                .Debit_Amount = 0
                            Else
                                .Debit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Debit_Amount"))
                            End If
                            If GridView1.GetRowCellValue(i, "Credit_Amount") Is DBNull.Value Then
                                .Credit_Amount = 0
                            Else
                                .Credit_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Credit_Amount"))
                            End If
                            .Description = GridView1.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView1.GetRowCellValue(i, "SubAccount")
                        End With
                        ObjGJHeader.ObjDetails.Add(ObjGJDetail)
                    End If
                Next

                Dim Result As Boolean = ObjGJHeader.IsGJOpen(fs_Code)
                If Result Then
                    Throw New Exception("GJ ID '" & fs_Code2 & "' tidak bisa di edit !")
                End If
                ObjGJHeader.GJID = TxtNoGJ.Text
                ObjGJHeader.GJID_Revers = TxtNoRJ.Text
                ObjGJHeader.Deletegj()
                ObjGJHeader.DeleteDataR(TxtNoRJ.Text)
                ObjGJHeader.UpdateHeadercek(TxtNoGJ.Text)
                ''  ObjGJHeader.GJID = ObjGJHeader.GJAutoNo
                ''  ObjGJHeader.GJID_Revers = ObjGJHeader.RJAutoNo
                ObjGJHeader.InsertData()
                ObjGJDetail.GJID_Revers2 = ObjGJDetail.GJID_Revers2
                ObjGJHeader.GJID_Revers2 = ObjGJDetail.GJID_Revers2
                If ChkRevers.Checked = True Then
                    'ObjGJDetail.GJID_Revers = ObjGJDetail.GJID_Revers2
                    Dim tglr As Date
                    tglr = TxtTgl.EditValue.AddDays((TxtTgl.EditValue.Day - 1) * -1).AddMonths(1)
                    ObjGJHeader.Tgl = tglr
                    ObjGJHeader.InsertDataR2()
                End If

                '  ObjGJHeader.UpdateData(TxtNoGJ.Text)
                'If ChkRevers.Checked = True Then
                '    ObjGJHeader.UpdateDataR(TxtNoRJ.Text)
                'Else
                '    ObjGJHeader.DeleteDataR(TxtNoRJ.Text)
                'End If

                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjGJHeader.GetDataGrid()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid.ProcessGridKey
        Try
            Dim grid As GridControl = TryCast(sender, GridControl)
            Dim view As GridView = TryCast(grid.FocusedView, GridView)

            If e.KeyData = Keys.Delete Then
                view.DeleteSelectedRows()
                Dim _totDb As Decimal = 0
                _totDb = GetTotDb()
                Dim _totCr As Decimal = 0
                _totCr = GetTotCr()
                TxtTotalDb.Text = Format(_totDb, gs_FormatDecimal)
                TxtTotalCr.Text = Format(_totCr, gs_FormatDecimal)
                e.Handled = True
            End If
            If e.KeyData = Keys.Enter Then

                ObjGJDetail = New GJDetailModel
                If GridView1.FocusedColumn.FieldName = "SubAccount" Then
                    ObjGJDetail.SubAcct = GridView1.GetFocusedRowCellValue("SubAccount").ToString()
                    Dim dt As New DataTable
                    dt = ObjGJDetail.GetSubAccountbyid
                    If dt.Rows.Count > 0 Then
                        GridView1.FocusedColumn = GridView1.VisibleColumns(1)
                        GridView1.ShowEditor()
                        GridView1.UpdateCurrentRow()
                    Else
                        MessageBox.Show("Data Tidak ditemukan !")
                        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            ObjGJHeader = New GJHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjGJHeader.GetAccount
            ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account"))
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
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Function GetTot() As Decimal
        Dim _dbtotal As Decimal = 0
        Dim _crtotal As Decimal = 0
        Dim _total As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Debit_Amount")) Then
                    _dbtotal = _dbtotal + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Debit_Amount"))
                End If
                If Not IsDBNull(GridView1.GetRowCellValue(i, "Credit_Amount")) Then
                    _crtotal = _crtotal + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Credit_Amount"))
                End If
                _total = _dbtotal - _crtotal
            Next
            Return _total
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetTotDb() As Decimal
        Dim _dbtotal As Decimal = 0
        Dim _totalDb As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                _dbtotal = _dbtotal + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Debit_Amount"))
                _totalDb = _dbtotal
            Next
            Return _totalDb
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function GetTotCr() As Decimal
        Dim _crtotal As Decimal = 0
        Dim _totalCr As Decimal = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1

                _crtotal = _crtotal + Convert.ToDecimal(GridView1.GetRowCellValue(i, "Credit_Amount"))

                _totalCr = _crtotal
            Next
            Return _totalCr
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub GSubAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GSubAccount.ButtonClick
        Try
            ObjGJHeader = New GJHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            dtSearch = ObjGJHeader.GetSubAccount
            ls_OldKode = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount") Is DBNull.Value, "", GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount"))
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
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            ObjGJHeader = New GJHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjGJHeader.GetDept
            ls_OldKode = TxtDep.Text
            ls_Judul = "Departemen"


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
                TxtDep.Text = Value1
            End If
            lF_SearchData.Close()
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

    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs) Handles GAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        'Grid.FocusedView.PostEditor()
    End Sub

    Private Sub CRAmount_EditValueChanged(sender As Object, e As EventArgs) Handles CRAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        'Grid.FocusedView.PostEditor()
    End Sub
    Private Sub CRAmount2_EditValueChanged(sender As Object, e As EventArgs) Handles CRAmount2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        'Grid.FocusedView.PostEditor()
    End Sub
    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtPrNo.DoValidate()
        TxtDep.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtPrNo) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDep) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub
    Dim Total As Double = 0
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim DBTotal As Double = 0
        Dim CRTotal As Double = 0
        Dim Total As Double = 0

        For i As Integer = 0 To GridView1.RowCount - 1
            If Not GridView1.GetRowCellValue(i, "Credit_Amount") Is DBNull.Value Then
                CRTotal = CRTotal + GridView1.GetRowCellValue(i, "Credit_Amount")
            End If
            If Not GridView1.GetRowCellValue(i, "Debit_Amount") Is DBNull.Value Then
                DBTotal = DBTotal + GridView1.GetRowCellValue(i, "Debit_Amount")
            End If
            Total = DBTotal - CRTotal
        Next
        TxtTotalDb.Text = Format(DBTotal, gs_FormatDecimal)
        TxtTotalCr.Text = Format(CRTotal, gs_FormatDecimal)
    End Sub

    Private Sub Frmgl_Detail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView1.AddNewRow()
            GridView1.OptionsNavigation.AutoFocusNewRow = True
            GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        End If
    End Sub

    Private Sub btnAddDetail_Click(sender As Object, e As EventArgs) Handles btnAddDetail.Click
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
    End Sub
    Public Overrides Sub Proc_print()
        FrmReportgl.StartPosition = FormStartPosition.CenterScreen
        FrmReportgl.TxtNoGJ.Text = TxtNoGJ.Text
        FrmReportgl.Show()
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
    End Sub


End Class
