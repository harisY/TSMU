Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Public Class FrmTravelerDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsTraveller
    Dim GridDtl As GridControl
    Dim ObjTraveler As New ClsTraveller
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable

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
    Private Sub FrmTravelerDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
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
                Me.Text = "Master Traveller " & fs_Code
            Else
                Me.Text = "Master New Traveller"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmTraveler"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TxtNIK.Text = .NIK
                    TxtNama.Text = .Nama
                    TxtDeptID.Text = .DeptID
                    TxtVisaNo.Text = .VisaNo
                    TxtVisaExpDate.EditValue = .VisaExpDate
                    TxtPassNo.Text = .PassNo
                    TxtPassExpDate.EditValue = .PassExpDate
                    ' TxtNIK.Enabled = False
                    ' TxtNama.Focus()
                End With
            Else
                TxtNIK.Text = ""
                TxtNama.Text = ""
                TxtDeptID.Text = ""
                TxtVisaNo.Text = ""
                TxtVisaExpDate.EditValue = DateTime.Today
                TxtPassNo.Text = ""
                TxtPassExpDate.EditValue = DateTime.Today
                TxtNIK.Focus()
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
                    .NIK = TxtNIK.Text.Trim.ToUpper
                    .Nama = TxtNama.Text.Trim.ToUpper
                    .DeptID = TxtDeptID.Text.Trim.ToUpper
                    .VisaNo = TxtVisaNo.Text.Trim.ToUpper
                    .PassNo = TxtPassNo.Text.Trim.ToUpper
                    .VisaExpDate = TxtVisaExpDate.EditValue
                    .PassExpDate = TxtPassExpDate.EditValue
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
    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                fc_Class.Insert()
            Else
                fc_Class.Update(fs_Code)
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            'Dim targetString As String = _TxtNIK.Text
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
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtNIK.DoValidate()
        TxtNama.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtNIK) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtNama) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub TxtDeptID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDeptID.ButtonClick
        Try
            ObjTraveler = New ClsTraveller
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTraveler.GetDept
            ls_OldKode = TxtDeptID.Text
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
                TxtDeptID.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
