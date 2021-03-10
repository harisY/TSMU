Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid

Public Class FrmHRPADataPribadi

    Dim _isSave As Boolean
    Dim isAction As String
    Dim ID As Integer
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim modelDataPribadi As HRPADataPribadiModel
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

    Private Sub FrmHRPADataPribadi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            If isAction <> "Add" Then
                Me.Text = isAction.ToUpper + " DATA PRIBADI"
            Else
                Me.Text = "ADD DATA PRIBADI"
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
                txtPINFinger.Text = IIf(dataRow("PINFinger") Is DBNull.Value, "", dataRow("PINFinger"))
                txtNamaLengkap.Text = dataRow("NamaLengkap")
                txtNamaPanggilan.Text = IIf(dataRow("NamaPanggilan") Is DBNull.Value, Nothing, dataRow("NamaPanggilan"))
                cbJenisKelamin.Text = IIf(dataRow("JenisKelamin") Is DBNull.Value, "", dataRow("JenisKelamin"))
                txtGolonganDarah.Text = IIf(dataRow("GolonganDarah") Is DBNull.Value, "", dataRow("GolonganDarah"))
                txtTempatLahir.Text = IIf(dataRow("TempatLahir") Is DBNull.Value, "", dataRow("TempatLahir"))
                dtTglLahir.EditValue = IIf(dataRow("TglLahir") Is DBNull.Value, Nothing, dataRow("TglLahir"))
                cbTamatan.Text = IIf(dataRow("Tamatan") Is DBNull.Value, "", dataRow("Tamatan"))
                cbKewarganegaraan.Text = IIf(dataRow("Kewarganegaraan") Is DBNull.Value, "", dataRow("Kewarganegaraan"))
                cbAgama.Text = IIf(dataRow("Agama") Is DBNull.Value, "", dataRow("Agama"))
                cbStatusKawin.Text = IIf(dataRow("StatusKawin") Is DBNull.Value, "", dataRow("StatusKawin"))
                dtTglKawin.EditValue = IIf(dataRow("TglKawin") Is DBNull.Value, Nothing, dataRow("TglKawin"))
                txtJumlahAnak.Text = IIf(dataRow("JumlahAnak") Is DBNull.Value, 0, dataRow("JumlahAnak"))
                Dim tmpData As Byte()
                tmpData = CType(dataRow("Gambar"), Byte())
                Dim ms As New MemoryStream(tmpData)
                txtFoto.Image = Image.FromStream(ms)
                txtReference.Text = IIf(dataRow("Reference") Is DBNull.Value, "", dataRow("Reference"))
                txtKet.Text = IIf(dataRow("Ket") Is DBNull.Value, "", dataRow("Ket"))
                dtTglBuat.EditValue = dataRow("TglBuat")
                txtUserBuat.Text = dataRow("UserBuat")
                dtTglUbah.EditValue = dataRow("TglUbah")
                txtUserUbah.Text = dataRow("UserUbah")
            Else
                dtTglMulai.EditValue = Date.Today
                dtTglSelesai.EditValue = Date.Parse("9999-12-31")
                txtNIK.Text = NIK
                txtGolonganDarah.Text = "NONE"
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
        txtPINFinger.Enabled = False
        txtNamaLengkap.Enabled = False
        txtNamaPanggilan.Enabled = False
        cbJenisKelamin.Enabled = False
        txtTempatLahir.Enabled = False
        dtTglLahir.Enabled = False
        cbTamatan.Enabled = False
        cbKewarganegaraan.Enabled = False
        cbAgama.Enabled = False
        txtGolonganDarah.Enabled = False
        cbStatusKawin.Enabled = False
        dtTglKawin.Enabled = False
        txtJumlahAnak.Enabled = False
        txtReference.Enabled = False
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
                    If isAction <> "Edit" Then
                        srvHR.SaveNewDataPribadi(modelDataPribadi)
                    Else
                        srvHR.SaveEditDataPribadi(modelDataPribadi)
                    End If
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
            ElseIf txtNamaLengkap.Text = "" Then
                Err.Raise(ErrNumber, , "Nama Lengkap Tidak Boleh Kosong!")
            ElseIf cbJenisKelamin.Text = "" Then
                Err.Raise(ErrNumber, , "Jenis Kelamin Tidak Boleh Kosong!")
            ElseIf cbStatusKawin.Text = "MENIKAH" And dtTglKawin.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Tanggal Kawin Tidak Boleh Kosong !")
            Else
                If isAction <> "Edit" Then
                    If srvHR.CheckRangeDatePribadi(EmpID, dtTglMulai.EditValue, dtTglSelesai.EditValue) Then
                        Err.Raise(ErrNumber, , "Sudah Ada Tanggal Diperiode Ini  !")
                    End If
                Else
                    If srvHR.CheckRangeDateEditPribadi(ID, EmpID, dtTglMulai.EditValue, dtTglSelesai.EditValue) Then
                        Err.Raise(ErrNumber, , "Sudah Ada Tanggal Diperiode Ini  !")
                    End If
                End If
            End If

            modelDataPribadi = New HRPADataPribadiModel
            Dim tmpData As Byte()
            Using ms As New MemoryStream()
                txtFoto.Image.Save(ms, ImageFormat.Jpeg)
                tmpData = ms.ToArray
            End Using

            Dim Now As DateTime = DateTime.Now
            With modelDataPribadi
                .ID = ID
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
                .GolonganDarah = txtGolonganDarah.Text
                .StatusKawin = cbStatusKawin.Text
                .TglKawin = dtTglKawin.EditValue
                .JumlahAnak = txtJumlahAnak.Text
                .Gambar = tmpData
                .Reference = txtReference.Text
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

    Private Sub txtJumlahAnak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahAnak.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

End Class
