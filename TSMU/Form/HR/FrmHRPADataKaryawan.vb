Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.StyleFormatConditions
Imports System.ComponentModel.DataAnnotations

Public Class FrmHRPADataKaryawan

    Dim _isSave As Boolean
    Dim isAction As String
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim modelDataKaryawan As HRPADataKaryawanModel
    Dim srvHR As New HRPAService

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal Action As String,
                   ByVal _EmpID As String,
                   ByVal _NIK As String,
                   ByVal Rows As DataRow,
                   ByRef _Grid As GridControl,
                   ByRef lf_FormParent As Form
                   )
        ' this call is required by the windows form designer
        Me.New()
        If Action <> "Add" Then
            dataRow = Rows
        End If
        NIK = _NIK
        isAction = Action
        EmpID = _EmpID
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub

    Private Sub FrmHRPADataKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            If isAction <> "Add" Then
                Me.Text = "DATA KARYAWAN"
            Else
                Me.Text = "NEW DATA KARYAWAN"
            End If
            Call LoadTxtBox()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            ListItemsOrganisasi()
            Dim dtTreeOrg As New DataTable
            dtTreeOrg = srvHR.GetStrukturOrg()
            txtJabatan.Properties.DataSource = dtTreeOrg

            If isAction <> "Add" Then
                dtTglMulai.EditValue = dataRow("TglMulai")
                dtTglSelesai.EditValue = dataRow("TglSelesai")
                txtNIK.Text = dataRow("NIK")
                txtPerpindahan.Text = IIf(dataRow("PerpindahanKaryawan") Is DBNull.Value, "", dataRow("PerpindahanKaryawan"))
                txtAlasan.Text = IIf(dataRow("AlasanPindah") Is DBNull.Value, "", dataRow("AlasanPindah"))
                cbGolongan.Text = IIf(dataRow("Golongan") Is DBNull.Value, "", dataRow("Golongan"))
                cbStatus.Text = IIf(dataRow("StatusKaryawan") Is DBNull.Value, "", dataRow("StatusKaryawan"))
                cbTipe.Text = IIf(dataRow("TipeKaryawan") Is DBNull.Value, "", dataRow("TipeKaryawan"))
                cbTipePosisi.Text = IIf(dataRow("TipePosisiKaryawan") Is DBNull.Value, "", dataRow("TipePosisiKaryawan"))
                cbFactory.Text = IIf(dataRow("Factory") Is DBNull.Value, "", dataRow("Factory"))
                cbOrganisasi.EditValue = IIf(dataRow("Organisasi") Is DBNull.Value, "", dataRow("Organisasi"))
                txtJabatan.EditValue = IIf(dataRow("Jabatan") Is DBNull.Value, "", dataRow("Jabatan"))
                cbJob.Text = IIf(dataRow("Job") Is DBNull.Value, "", dataRow("Job"))
                dtTglEfektif.EditValue = IIf(dataRow("TglEfektif") Is DBNull.Value, Nothing, dataRow("TglEfektif"))
                dtTglBerakhir.EditValue = IIf(dataRow("TglBerakhir") Is DBNull.Value, Nothing, dataRow("TglBerakhir"))
                txtSK.Text = IIf(dataRow("SK") Is DBNull.Value, "", dataRow("SK"))
                txtKet.Text = IIf(dataRow("Ket") Is DBNull.Value, "", dataRow("Ket"))
                dtTglBuat.EditValue = dataRow("TglBuat")
                txtUserBuat.Text = dataRow("UserBuat")
                dtTglUbah.EditValue = dataRow("TglUbah")
                txtUserUbah.Text = dataRow("UserUbah")
            Else
                dtTglMulai.EditValue = Date.Today
                dtTglSelesai.EditValue = Date.Parse("9999-12-31")
                txtNIK.Text = NIK
                dtTglBuat.EditValue = DateTime.Now
                txtUserBuat.Text = gh_Common.Username
                dtTglUbah.EditValue = DateTime.Now
                txtUserUbah.Text = gh_Common.Username
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If CheckValidasi() = False Then
                _isSave = True
                srvHR.SaveDataKaryawan(modelDataKaryawan)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Function CheckValidasi() As Boolean
        Dim validasi As Boolean = False
        Try
            If txtAlasan.Text = "" Then
                Err.Raise(ErrNumber, , "Nama Lengkap Tidak Boleh Kosong!")
            Else
                modelDataKaryawan = New HRPADataKaryawanModel
                With modelDataKaryawan
                    .TglMulai = dtTglMulai.EditValue
                    .TglSelesai = dtTglSelesai.EditValue
                    .EmpID = EmpID
                    .NIK = txtNIK.Text
                    .PerpindahanKaryawan = txtPerpindahan.Text
                    .AlasanPindah = txtAlasan.Text
                    .Golongan = cbGolongan.Text
                    .StatusKaryawan = cbStatus.EditValue
                    .TipeKaryawan = cbTipe.Text
                    .TipePosisiKaryawan = cbTipePosisi.Text
                    .Factory = cbFactory.Text
                    .Organisasi = txtJabatan.EditValue
                    .Jabatan = cbOrganisasi.Text
                    .Job = cbJob.Text
                    .TglEfektif = dtTglEfektif.EditValue
                    .TglBerakhir = dtTglBerakhir.EditValue
                    .SK = txtSK.Text
                    .Ket = txtKet.Text
                    .TglBuat = dtTglBuat.EditValue
                    .UserBuat = txtUserBuat.Text
                    .TglUbah = DateTime.Now
                    .UserUbah = txtUserUbah.Text
                End With
            End If
        Catch ex As Exception
            validasi = True
            Throw ex
        End Try
        Return validasi
    End Function

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

    Private Sub ListItemsOrganisasi()
        Dim dtOrganisasi = New DataTable
        dtOrganisasi = srvHR.GetListOrganisasi()
        cbOrganisasi.Properties.DataSource = dtOrganisasi
    End Sub

End Class
