Imports DevExpress.XtraGrid

Public Class FrmPPICLayoutGedungDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim srvPPIC As New PPICService
    Dim modelHeader As PPICLayoutGedungModel
    Dim dtGridDetail As DataTable
    Dim GridDtl As GridControl

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

    Private Sub FrmPPICLayoutGedungDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelHeader = srvPPIC.GetDataLayoutGedungByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "LAYOUT GEDUNG DETAIL"
            Else
                Me.Text = "NEW LAYOUT GEDUNG"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmPPICLayoutGedung"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With modelHeader
                    txtUserCode.Text = .UserCode
                    txtGroup.Text = .Group
                    txtSeqUser.Text = .SeqUser
                    txtSeq.Text = .Seq
                    txtPF.Text = .PF
                    txtGedung.Text = .Gedung
                    txtLokasi.Text = .Lokasi
                    txtUserCode.Enabled = False
                    txtSeq.Enabled = False
                End With
            Else
                txtUserCode.Text = ""
                txtGroup.Text = 0
                txtSeqUser.Text = 0
                txtSeq.Text = 0
                txtPF.Text = ""
                txtGedung.Text = 0
                txtLokasi.Text = ""
                txtUserCode.Focus()
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

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If txtUserCode.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "User Code Tidak Boleh Kosong!")
            ElseIf txtSeq.EditValue = 0 Then
                Err.Raise(ErrNumber, , "Seq Tidak Boleh 0!")
            ElseIf txtSeqUser.EditValue = 0 Then
                Err.Raise(ErrNumber, , "Seq User Tidak Boleh 0!")
            ElseIf txtPF.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "P/f Tidak Boleh Kosong!")
            ElseIf txtLokasi.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Lokasi Tidak Boleh Kosong!")
            End If

            If lb_Validated Then
                Dim Now As DateTime = DateTime.Now
                modelHeader = New PPICLayoutGedungModel
                With modelHeader
                    If isUpdate = False Then
                        srvPPIC.CheckDuplicateLayoutGedung(modelHeader)
                    Else
                        .ID = fs_Code
                    End If
                    .UserCode = txtUserCode.Text
                    .Group = txtGroup.EditValue
                    .Seq = txtSeq.EditValue
                    .SeqUser = txtSeqUser.Text
                    .PF = txtPF.Text
                    .Gedung = txtGedung.EditValue
                    .Lokasi = txtLokasi.Text
                    .CreateBy = gh_Common.Username
                    .CreateDate = Now
                    .UpdateBy = gh_Common.Username
                    .UpdateDate = Now
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
                srvPPIC.InsertDataLayoutGedung(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                srvPPIC.UpdateDataLayoutGedung(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If

            GridDtl.DataSource = srvPPIC.GetDataLayoutGedung()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        txtGedung.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(txtGedung) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

End Class
