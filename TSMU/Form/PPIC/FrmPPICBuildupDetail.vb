Imports DevExpress.XtraGrid

Public Class FrmPPICBuildupDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim srvHR As New PPICService
    Dim modelHeader As PPICBuildupModel
    Dim dtGridDetail As DataTable
    Dim GridDtl As GridControl
    Dim dataRow As DataRow

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

    Private Sub FrmPPICBuildupDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelHeader = srvHR.GetDataBuildupByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "KAPASITAS MOBIL DETAIL"
            Else
                Me.Text = "NEW KAPASITAS MOBIL"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmPPICBuildup"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With modelHeader
                    txtJenisPacking.Text = .JenisPacking
                    txtPanjang.EditValue = .Panjang
                    txtLebar.EditValue = .Lebar
                    txtTinggi.EditValue = .Tinggi
                    txtQtyPallet.EditValue = .QtyPallet
                    txtStandarQty.EditValue = .StandarQty
                    txtKapasitasMuat.EditValue = .KapasitasMuat
                    txtPersentase.EditValue = .Persentase
                    txtTipe.Text = .Tipe
                    txtKeterangan.Text = .Keterangan
                    txtUsedForCustomer.Text = .UsedForCustomer
                    txtJenisPacking.Enabled = False
                End With
            Else
                txtJenisPacking.Text = ""
                txtPanjang.EditValue = 0
                txtLebar.EditValue = 0
                txtTinggi.EditValue = 0
                txtQtyPallet.EditValue = 0
                txtStandarQty.EditValue = 0
                txtKapasitasMuat.EditValue = 0
                txtPersentase.EditValue = 0
                txtTipe.Text = ""
                txtKeterangan.Text = ""
                txtUsedForCustomer.Text = ""
                txtJenisPacking.Focus()
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

            If txtJenisPacking.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Jenis Packing Tidak Boleh Kosong!")
            End If

            If lb_Validated Then
                Dim Now As DateTime = DateTime.Now
                modelHeader = New PPICBuildupModel
                With modelHeader
                    .ID = fs_Code
                    .JenisPacking = txtJenisPacking.Text
                    .Panjang = txtPanjang.EditValue
                    .Lebar = txtLebar.EditValue
                    .Tinggi = txtTinggi.EditValue
                    .QtyPallet = txtQtyPallet.EditValue
                    .StandarQty = txtStandarQty.EditValue
                    .KapasitasMuat = txtKapasitasMuat.EditValue
                    .Persentase = txtPersentase.EditValue
                    .Tipe = txtTipe.Text
                    .Keterangan = txtKeterangan.Text
                    .UsedForCustomer = txtUsedForCustomer.Text
                    .CreateBy = gh_Common.Username
                    .CreateDate = Now
                    .UpdateBy = gh_Common.Username
                    .UpdateDate = Now
                    If isUpdate = False Then
                        srvHR.CheckDuplicateBuildup(modelHeader)
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
                srvHR.InsertDataBuildup(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                srvHR.UpdateDataBuildup(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If

            GridDtl.DataSource = srvHR.GetDataBuildup()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        txtJenisPacking.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(txtJenisPacking) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

End Class
