Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports TSMU

Public Class FrmSuspend_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim GridDtl As GridControl
    Dim f As FrmSuspend_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable

    Dim ObjSuspend As New ClsSuspend
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""

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
    End Sub
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(3) {New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double))})

        Grid.DataSource = DtScan
        GridView1.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub FrmSuspend_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        Call InitialSetForm()
        Call CreateTable()
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Suspend " & fs_Code
            Else
                Me.Text = "Suspend"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmSuspend"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    'TxtID.Text = .ID
                    'TxtDesc.Text = .Deskripsi
                    'TxtID.Enabled = False
                    'TxtDesc.Focus()
                End With
            Else
                'TxtID.Text = ""
                'TxtDesc.Text = ""
                '_TxtID.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim success As Boolean = True
            'For Each c As Control In Me.Controls
            '    If errProvider.GetError(c).Length > 0 Then
            '        success = False
            '    End If

            'Next
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            'If success Then
            '    lb_Validated = True
            'Else
            '    Err.Raise(ErrNumber, , "Please check your input field !")
            'End If

            If lb_Validated Then
                With fc_Class
                    '.ID = TxtID.Text.Trim.ToUpper
                    '.Deskripsi = TxtDesc.Text.Trim.ToUpper
                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
                        '.ValidateUpdate()
                    End If
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

        f = New FrmSuspend_Detail2(ID, Nama, IsNew, dt, Grid)
        f.StartPosition = FormStartPosition.CenterScreen
        f.MaximizeBox = False
        f.ShowDialog()

    End Sub
    Public Overrides Sub Proc_Approve()
        CallForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                fc_Class.Insert()
            Else
                fc_Class.Update(fs_Code)
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            'Dim targetString As String = _txtId.Text
            'For Each row As DataGridViewRow In Me.GridDtl.Rows
            '    If RTrim(row.Cells(0).Value.ToString) = targetString Then
            '        Me.GridDtl.ClearSelection()
            '        Me.GridDtl.Rows(row.Index).Selected = True
            '        Exit For
            '    End If
            'Next
            IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            dtSearch = ObjSuspend.GetSubAccount
            'ls_OldKode =Iff(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount") Is DBNull.Value
            ls_Judul = "SubAccount"

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
                '    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                '   Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", Value1)
                '_account.Text = Value1
                '_accountname.Text = Value2
                '  _TxtToBank.Text = Value3
                '  _TxtNoRek.Text = Value4

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles Grid.ProcessGridKey

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click
        For i As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(i, "SubAccount") Is DBNull.Value Then
                MsgBox("masih kosong")
                Exit Sub
            End If
        Next
        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
    End Sub
    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        Try
            'Dim ObjSuspend As New ClsSuspend
            'Dim ls_Judul As String = ""
            'Dim dtSearch As New DataTable
            'Dim ls_OldKode As String = ""

            dtSearch = ObjSuspend.GetAccount
            'ls_OldKode =Iff(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount") Is DBNull.Value
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
                '    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                '   Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
                '_account.Text = Value1
                '_accountname.Text = Value2
                '  _TxtToBank.Text = Value3
                '  _TxtNoRek.Text = Value4

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Try
            If e.Column.FieldName = "SubAccount" Then
                ' MsgBox("tes")
                ' MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount"))
                ' ObjSuspend.subaccount = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount")
            End If
            'ObjSuspend.subaccount = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount")
            ObjSuspend.subaccount = GridView1.GetFocusedRowCellValue("SubAccount").ToString()
            Dim dt As New DataTable
            'dt = SuratJalan.GetSJ(GridView1.GetFocusedRowCellValue("No Surat Jalan").ToString(), gh_Common.Site)
            'dt = ObjSuspend.subaccount = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount")
            '  dt = ObjSuspend.GetSubAccountbyid()
            dt = ObjSuspend.GetSubAccountbyid


            If dt.Rows.Count > 0 Then

                'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "SubAccount", dt.Rows(0)(0))
                GridView1.FocusedColumn = GridView1.VisibleColumns(0)
                GridView1.ShowEditor()
                GridView1.UpdateCurrentRow()
            Else
                MessageBox.Show("Data Tidak ditemukan !")
                'GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "SubAccount")
                'GridView1.GetFocusedRowCellValue("SubAccount").ToString()
                '  GridView1.FocusedColumn = GridView1.VisibleColumns(0)
                GridView1.FocusedRowHandle = GridView1.GetVisibleRowHandle(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class
