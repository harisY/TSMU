'Imports System.Drawing.Imaging
'Imports System.IO
Imports System.Web.UI.WebControls
Imports DevExpress.XtraGrid
'Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraTreeList

Public Class FrmHRPANewEmployee
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim GridKaryawan As GridControl
    Dim GridViewKaryawan As GridView
    Dim modelDataPribadi As HRPADataPribadiModel
    Dim modelDataKaryawan As HRPADataKaryawanModel
    Dim modelOrgStruktur As HROrgStrukturModel
    Dim srvHR As New HRPAService

    Dim openFDialog As OpenFileDialog

    Dim ID As Integer
    Dim EmpID As String = String.Empty
    Dim NIK As String = String.Empty
    Dim PathFoto As String = String.Empty
    Dim extension As String = String.Empty
    Dim PathSave As String = String.Empty
    Dim FileName As String = String.Empty

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal li_GridRow As Integer,
                   ByRef lf_FormParent As Form,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridKaryawan = _Grid
        'GridViewKaryawan = _GridView
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmHRAdministrasiKaryawanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "KARYAWAN DETAIL"
            Else
                Me.Text = "NEW KARYAWAN"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHRAdministrasiKaryawan"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        ListItemsPerpindahan()
        'ListItemsGolongan()

        txtAction.Text = "NEW-HIRE"
        cbStatus.Text = "AKTIF"
        cbPerpindahan.EditValue = "01"
        cbAlasan.EditValue = "11"
        cbFactory.Text = "TANGERANG"
        dtHTglMulai.EditValue = Date.Today
        dtTglMulai.EditValue = Date.Today
        dtTglSelesai.EditValue = Date.Parse("9999-12-31")
        dtDKTglMulai.EditValue = Date.Today
        dtDKTglSelesai.EditValue = Date.Parse("9999-12-31")

        ListItemsOrganisasi()
        Dim dtTreeOrg As New DataTable
        dtTreeOrg = srvHR.GetStrukturOrg(dtTglMulai.EditValue)
        txtJabatan.Properties.DataSource = dtTreeOrg
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
            If txtNamaLengkap.EditValue = "" Then
                Err.Raise(ErrNumber, , "Nama Lengkap tidak boleh kosong !")
            ElseIf cbPerpindahan.EditValue = "" Then
                Err.Raise(ErrNumber, , "Perpindahan tidak boleh kosong !")
            ElseIf cbAlasan.EditValue = "" Then
                Err.Raise(ErrNumber, , "Alasan tidak boleh kosong !")
            ElseIf cbStatus.EditValue = "" Then
                Err.Raise(ErrNumber, , "Status tidak boleh kosong !")
            ElseIf cbTipe.EditValue = "" Then
                Err.Raise(ErrNumber, , "Tipe tidak boleh kosong !")
            ElseIf cbFactory.EditValue = "" Then
                Err.Raise(ErrNumber, , "Factory tidak boleh kosong !")
            End If

            If lb_Validated Then
                EmpID = srvHR.GetAutoNumberEmpID()
                NIK = srvHR.GetAutoNumberNIK()
                txtNIK.Text = NIK
                txtDKNIK.Text = NIK
                Dim now As DateTime = DateTime.Now

                If openFDialog IsNot Nothing Then
                    PathSave = srvHR.GetGeneralParam("PathFoto")
                    ID = srvHR.GetMaxIDDataPribadi()
                    PathFoto = openFDialog.FileName
                    extension = IO.Path.GetExtension(PathFoto)
                    FileName = "Foto_" + NIK + "_" + ID.ToString() + extension
                End If

                modelDataPribadi = New HRPADataPribadiModel
                With modelDataPribadi
                    .TglMulai = dtTglMulai.EditValue
                    .TglSelesai = dtTglSelesai.EditValue
                    .EmpID = EmpID
                    .PINFinger = txtPINFinger.Text
                    .NamaLengkap = txtNamaLengkap.Text
                    .NamaPanggilan = txtNamaPanggilan.Text
                    .JenisKelamin = cbJenisKelamin.Text
                    .TempatLahir = txtTempatLahir.Text
                    .TglLahir = dtTglLahir.EditValue
                    .Tamatan = cbTamatan.Text
                    .Kewarganegaraan = cbKewarganegaraan.Text
                    .Agama = cbAgama.Text
                    .GolonganDarah = ""
                    .StatusKawin = cbStatusKawin.Text
                    .TglKawin = dtTglKawin.EditValue
                    .JumlahAnak = IIf(txtJumlahAnak.Text = "", 0, txtJumlahAnak.Text)
                    .Foto = FileName
                    .Reference = txtReference.Text
                    .Ket = txtKet.Text
                    .TglBuat = now
                    .UserBuat = gh_Common.Username
                    .TglUbah = now
                    .UserUbah = gh_Common.Username
                End With

                modelDataKaryawan = New HRPADataKaryawanModel
                With modelDataKaryawan
                    .TglMulai = dtDKTglMulai.EditValue
                    .TglSelesai = dtDKTglSelesai.EditValue
                    .EmpID = EmpID
                    .NIK = txtDKNIK.Text
                    .PerpindahanKaryawan = cbPerpindahan.EditValue
                    .AlasanPindah = cbAlasan.EditValue
                    .Golongan = cbGolongan.EditValue
                    .StatusKaryawan = cbStatus.Text
                    .TipeKaryawan = cbTipe.Text
                    .TipePosisiKaryawan = cbTipePosisi.Text
                    .Factory = cbFactory.Text
                    .Organisasi = IIf(cbOrganisasi.EditValue Is Nothing, "", cbOrganisasi.EditValue)
                    .Jabatan = txtJabatan.EditValue
                    .Job = IIf(cbJob.EditValue Is Nothing, "", cbJob.EditValue)
                    .TglEfektif = dtTglEfektif.EditValue
                    .TglBerakhir = dtTglBerakhir.EditValue
                    .SK = txtSK.Text
                    .Ket = txtKet.Text
                    .TglBuat = now
                    .UserBuat = gh_Common.Username
                    .TglUbah = now
                    .UserUbah = gh_Common.Username
                End With

                modelOrgStruktur = New HROrgStrukturModel
                With modelOrgStruktur
                    .TglMulai = dtDKTglMulai.EditValue
                    .TglSelesai = dtDKTglSelesai.EditValue
                    .OrgID = txtJabatan.EditValue
                    .OrgClass = "P"
                    .RelDir = "B"
                    .RelTipe = "03"
                    .Seq = 1
                    .RelClass = "E"
                    .RelOrg = EmpID
                    .Ket = txtKet.Text
                    .TglBuat = now
                    .UserBuat = gh_Common.Username
                    .TglUbah = now
                    .UserUbah = gh_Common.Username
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
            srvHR.SaveNewEmployee(modelDataPribadi, modelDataKaryawan, modelOrgStruktur)
            If pictureFoto IsNot Nothing Then
                If openFDialog IsNot Nothing Then
                    pictureFoto.Image.Save(PathSave & FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            End If
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            Dim dtGridKaryawan = New DataTable
            dtGridKaryawan = srvHR.GetDataKaryawan()
            GridKaryawan.DataSource = dtGridKaryawan
            'Dim colEmpID As GridColumn = GridViewKaryawan.Columns("EmployeeID")
            'colEmpID.Visible = False
            'GridViewKaryawan.BestFitColumns()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtAction.SelectedIndexChanged
        If txtAction.Text = "FROM APPLICANT" Then
            txtApplicantID.Enabled = True
        Else
            txtApplicantID.Text = ""
            txtApplicantID.Enabled = False
        End If
    End Sub

    Private Sub dtHTglMulai_EditValueChanged(sender As Object, e As EventArgs) Handles dtHTglMulai.EditValueChanged
        dtTglMulai.EditValue = dtHTglMulai.EditValue
        dtDKTglMulai.EditValue = dtHTglMulai.EditValue
    End Sub

    Private Sub ListItemsPerpindahan()
        Dim dtPerpindahan = New DataTable
        dtPerpindahan = srvHR.GetListPerpindahan()
        cbPerpindahan.Properties.DataSource = dtPerpindahan
    End Sub

    Private Sub ListItemsAlasan(perpindahan As String)
        Dim dtAlasan = New DataTable
        dtAlasan = srvHR.GetListAlasan(perpindahan)
        cbAlasan.Properties.DataSource = dtAlasan
    End Sub

    'Private Sub ListItemsGolongan()
    '    Dim dtGolongan = New DataTable
    '    dtGolongan = srvHR.GetListGolongan()
    '    cbGolongan.Properties.DataSource = dtGolongan
    'End Sub

    Private Sub ListItemsOrganisasi()
        Dim dtOrganisasi = New DataTable
        dtOrganisasi = srvHR.GetListOrganisasi()
        cbOrganisasi.Properties.DataSource = dtOrganisasi
    End Sub

    Private Sub cbPerpindahan_EditValueChanged(sender As Object, e As EventArgs) Handles cbPerpindahan.EditValueChanged
        cbAlasan.EditValue = ""
        ListItemsAlasan(cbPerpindahan.EditValue)
    End Sub

    Private Sub tlJabatan_GetStateImage(sender As Object, e As GetStateImageEventArgs) Handles tlJabatan.GetStateImage
        If e.Node.GetValue("OrgClass") = "O" Then
            e.Node.StateImageIndex = 0
        ElseIf e.Node.GetValue("OrgClass") = "P" Then
            If IIf(e.Node.GetValue("NIK") Is DBNull.Value, "", e.Node.GetValue("NIK")) = "" Then
                e.NodeImageIndex = 1
            Else
                e.NodeImageIndex = 2
            End If
        End If
    End Sub

    Private Sub tlJabatan_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles tlJabatan.RowCellClick
        Dim orgID As String = tlJabatan.FocusedNode.GetValue("OrgID")
        Dim orgClass As String = tlJabatan.FocusedNode.GetValue("OrgClass")
        Dim orgParent As String = tlJabatan.FocusedNode.GetValue("ParentID")
        Dim NIK As String = IIf(tlJabatan.FocusedNode.GetValue("NIK") Is DBNull.Value, "", tlJabatan.FocusedNode.GetValue("NIK"))
        If orgClass = "O" Then
            MsgBox("Silahkan Pilih Posisi !", MessageBoxIcon.Information, "Information")
        Else
            If NIK <> "" Then
                MsgBox("Posisi Sudah Terisi !", MessageBoxIcon.Information, "Information")
            Else
                cbOrganisasi.EditValue = orgParent
            End If
        End If
    End Sub

    Private Sub btnDeleteJab_Click(sender As Object, e As EventArgs) Handles btnDeleteJab.Click
        txtJabatan.EditValue = ""
        cbOrganisasi.EditValue = ""
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        openFDialog = New OpenFileDialog
        openFDialog.Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
        openFDialog.Title = "Select Image"
        openFDialog.CheckFileExists = True

        If openFDialog.ShowDialog = DialogResult.OK Then
            pictureFoto.Image = System.Drawing.Image.FromFile(openFDialog.FileName)
        End If
    End Sub

    Private Sub txtJumlahAnak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahAnak.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

End Class
