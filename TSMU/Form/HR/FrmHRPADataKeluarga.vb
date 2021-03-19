Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid

Public Class FrmHRPADataKeluarga

    Dim _isSave As Boolean
    Dim isAction As String
    Dim ID As Integer
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim modelDataKeluarga As HRPADataKeluargaModel
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

    Private Sub FrmHRPADataKeluarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            If isAction <> "Add" Then
                Me.Text = isAction.ToUpper + " DATA KELUARGA"
            Else
                Me.Text = "ADD DATA KELUARGA"
            End If
            Call LoadTxtBox()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If isAction <> "Add" Then
                ID = dataRow("ID")
                dtTglMulai.EditValue = dataRow("TglMulai")
                dtTglSelesai.EditValue = dataRow("TglSelesai")
                txtNIK.Text = NIK
                cbHubungan.Text = IIf(dataRow("Hubungan") Is DBNull.Value, "", dataRow("Hubungan"))
                txtNama.Text = IIf(dataRow("Nama") Is DBNull.Value, "", dataRow("Nama"))
                cbJenisKelamin.Text = IIf(dataRow("JenisKelamin") Is DBNull.Value, "", dataRow("JenisKelamin"))
                txtTempatLahir.Text = IIf(dataRow("TempatLahir") Is DBNull.Value, "", dataRow("TempatLahir"))
                dtTglLahir.EditValue = IIf(dataRow("TglLahir") Is DBNull.Value, Nothing, dataRow("TglLahir"))
                dtTglKematian.EditValue = IIf(dataRow("TglKematian") Is DBNull.Value, Nothing, dataRow("TglKematian"))
                cbAgama.Text = IIf(dataRow("Agama") Is DBNull.Value, "", dataRow("Agama"))
                cbTamatan.Text = IIf(dataRow("Tamatan") Is DBNull.Value, "", dataRow("Tamatan"))
                txtAlamat.Text = IIf(dataRow("Alamat") Is DBNull.Value, "", dataRow("Alamat"))
                txtNoTelpon.Text = IIf(dataRow("NoTelpon") Is DBNull.Value, "", dataRow("NoTelpon"))
                txtPekerjaan.Text = IIf(dataRow("Pekerjaan") Is DBNull.Value, "", dataRow("Pekerjaan"))
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

            If isAction = "View" Then
                Call CondView()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CondView()
        dtTglMulai.Enabled = False
        dtTglSelesai.Enabled = False
        cbHubungan.Enabled = False
        txtNama.Enabled = False
        cbJenisKelamin.Enabled = False
        txtTempatLahir.Enabled = False
        dtTglLahir.Enabled = False
        dtTglKematian.Enabled = False
        cbAgama.Enabled = False
        cbTamatan.Enabled = False
        txtAlamat.Enabled = False
        txtNoTelpon.Enabled = False
        txtPekerjaan.Enabled = False
        txtKet.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Apakah Yakin Ingin Save Data", "Konfirmasi",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question)
            If (result = DialogResult.Yes) Then
                If CheckValidasi() = False Then
                    _isSave = True
                    'If isAction <> "Edit" Then
                    '    srvHR.SaveNewDataPribadi(modelDataPribadi)
                    'Else
                    '    srvHR.SaveEditDataPribadi(modelDataPribadi)
                    'End If
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    Me.Hide()
                End If
            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Function CheckValidasi() As Boolean
        Dim validasi As Boolean = False
        Try
            If dtTglMulai.EditValue > dtTglSelesai.EditValue Then
                Err.Raise(ErrNumber, , "Tanggal Mulai Tidak Boleh Lebih Besar Dari Tanggal Selesai !")
            ElseIf cbHubungan.Text = "" Then
                Err.Raise(ErrNumber, , "Hubungan Tidak Boleh Kosong!")
            ElseIf txtNama.Text = "" Then
                Err.Raise(ErrNumber, , "Nama Tidak Boleh Kosong!")
            End If

            modelDataKeluarga = New HRPADataKeluargaModel

            Dim Now As DateTime = DateTime.Now
            With modelDataKeluarga
                .ID = ID
                .TglMulai = dtTglMulai.EditValue
                .TglSelesai = dtTglSelesai.EditValue
                .EmpID = EmpID
                .Hubungan = cbHubungan.Text
                .Seq = 1
                .Nama = txtNama.Text
                .JenisKelamin = cbJenisKelamin.Text
                .TempatLahir = txtTempatLahir.Text
                .TglLahir = dtTglLahir.EditValue
                .TglKematian = dtTglKematian.EditValue
                .Agama = cbAgama.Text
                .Tamatan = cbTamatan.Text
                .Alamat = txtAlamat.Text
                .NoTelpon = txtNoTelpon.Text
                .Pekerjaan = txtPekerjaan.Text
                .Ket = txtKet.Text
                If isAction <> "Edit" Then
                    .TglBuat = Now
                    .UserBuat = gh_Common.Username
                Else
                    .TglBuat = dtTglBuat.EditValue
                    .UserBuat = txtUserBuat.Text
                End If
                .TglUbah = Now
                .UserUbah = gh_Common.Username
            End With
        Catch ex As Exception
            validasi = True
            Throw ex
        End Try
        Return validasi
    End Function

End Class
