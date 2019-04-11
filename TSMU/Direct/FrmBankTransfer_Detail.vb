Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmBankTransfer_Detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsSuspend
    Dim ObjSuspendHeader As New SuspendHeaderModel
    Dim ObjSuspendDetail As New SuspendDetailModel
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
    Dim _SuspendID As String = ""

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
    Private Sub frmCoA_detail_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call InitialSetForm()
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
                Me.Text = "Bank Transfer " & fs_Code
            Else
                Me.Text = "New Bank Transfer"
            End If

            'TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmBankTransfer"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        'Try
        '    If fs_Code <> "" Then
        '        With fc_Class
        '            TxtNoRekAsalId.Text = .AccountID
        '            _txtAccName.Text = .AccountName
        '            _cmbType.Text = .AccountType
        '            TxtNoRekAsalId.ReadOnly = True
        '            _txtAccName.Focus()
        '        End With
        '    Else
        '        TxtNoRekAsalId.Text = ""
        '        _txtAccName.Text = ""
        '        _cmbType.SelectedIndex = 0
        '        TxtNoRekAsalId.Focus()
        '    End If
        'Catch ex As Exception
        '    Throw
        'End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        'Dim lb_Validated As Boolean = False
        'Try
        '    If String.IsNullOrEmpty(TxtNoRekAsalId.Text) Then
        '        errProvider.SetError(TxtNoRekAsalId, "Value cannot be empty.")
        '    Else
        '        errProvider.SetError(TxtNoRekAsalId, "")
        '    End If

        '    If String.IsNullOrEmpty(_txtAccName.Text) Then
        '        errProvider.SetError(_txtAccName, "Value cannot be empty.")
        '    Else
        '        errProvider.SetError(_txtAccName, "")
        '    End If

        '    If String.IsNullOrEmpty(_cmbType.Text) Then
        '        errProvider.SetError(_cmbType, "Value cannot be empty.")
        '    Else
        '        errProvider.SetError(_cmbType, "")
        '    End If

        '    If lb_Validated Then
        '        With fc_Class
        '            .AccountID = TxtNoRekAsalId.Text.Trim
        '            .AccountName = _txtAccName.Text.Trim
        '            If _cmbType.SelectedIndex = 1 Then
        '                .AccountType = "A"
        '            ElseIf _cmbType.SelectedIndex = 2 Then
        '                .AccountType = "D"
        '            End If


        '            If isUpdate = False Then
        '                .ValidateInsert()
        '            Else
        '                '.ValidateUpdate()
        '            End If
        '        End With

        '    End If
        'Catch ex As Exception
        '    lb_Validated = False
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        'End Try
        'Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        'Try
        '    If isUpdate = False Then
        '        fc_Class.Insert()
        '    Else
        '        fc_Class.Update()
        '    End If

        '    GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
        '    Dim targetString As String = TxtNoRekAsalId.Text
        '    For Each row As DataGridViewRow In Me.GridDtl.Rows
        '        If RTrim(row.Cells(0).Value.ToString) = targetString Then
        '            Me.GridDtl.ClearSelection()
        '            Me.GridDtl.Rows(row.Index).Selected = True
        '            Exit For
        '        End If
        '    Next
        '    IsClosed = True
        '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    Me.Hide()
        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        'End Try
    End Sub

    Private Sub TxtNoRekAsal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoRekAsal.EditValueChanged

    End Sub

    Private Sub TxtNoRekAsal_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRekAsal.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtNoRekAsal.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = TxtNoRekAsal.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = TxtNoRekAsal.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    TxtNoRekAsal.Text = Value1
                    TxtNoRekAsalname.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtNoRekTujuan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoRekTujuan.EditValueChanged

    End Sub

    Private Sub TxtNoRekTujuan_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNoRekTujuan.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = TxtNoRekTujuan.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = TxtNoRekTujuan.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = TxtNoRekTujuan.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    TxtNoRekTujuan.Text = Value1
                    TxtNoRekTujuanname.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
End Class
