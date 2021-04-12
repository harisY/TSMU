Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid

Public Class FrmHRPADataAlamat

    Dim _isSave As Boolean
    Dim isAction As String
    Dim ID As Integer
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim modelDataAlamat As HRPADataAlamatModel
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

    Private Sub FrmHRPADataAlamat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            Me.Text = isAction.ToUpper + " DATA ALAMAT"
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
                cbTipeAlamat.Text = IIf(dataRow("TipeAlamat") Is DBNull.Value, "", dataRow("TipeAlamat"))
                txtAlamat.Text = IIf(dataRow("Alamat") Is DBNull.Value, "", dataRow("Alamat"))
                txtRT.Text = IIf(dataRow("RT") Is DBNull.Value, Nothing, dataRow("RT"))
                txtRW.Text = IIf(dataRow("RW") Is DBNull.Value, "", dataRow("RW"))
                cbNegara.Text = IIf(dataRow("Negara") Is DBNull.Value, "", dataRow("Negara"))
                cbProvinsi.Text = IIf(dataRow("Provinsi") Is DBNull.Value, "", dataRow("Provinsi"))
                txtKota.Text = IIf(dataRow("KotaKab") Is DBNull.Value, "", dataRow("KotaKab"))
                cbKecamatan.Text = IIf(dataRow("Kecamatan") Is DBNull.Value, "", dataRow("Kecamatan"))
                txtKelurahan.Text = IIf(dataRow("Kelurahan") Is DBNull.Value, 0, dataRow("Kelurahan"))
                txtKodepos.Text = IIf(dataRow("KodePos") Is DBNull.Value, "", dataRow("KodePos"))
                txtNoTelp.Text = IIf(dataRow("NoTelpon") Is DBNull.Value, "", dataRow("NoTelpon"))
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

            If isAction = "View" OrElse isAction = "Delete" Then
                Call CondView()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CondView()
        dtTglMulai.Enabled = False
        dtTglSelesai.Enabled = False
        cbTipeAlamat.Enabled = False
        txtAlamat.Enabled = False
        txtRT.Enabled = False
        txtRW.Enabled = False
        cbNegara.Enabled = False
        cbProvinsi.Enabled = False
        txtKota.Enabled = False
        cbKecamatan.Enabled = False
        txtKelurahan.Enabled = False
        txtKodepos.Enabled = False
        txtNoTelp.Enabled = False
        txtKet.Enabled = False
        If isAction = "View" Then
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Apakah Yakin Ingin " & isAction & " Data", "Konfirmasi",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question)
            If (result = DialogResult.Yes) Then
                If CheckValidasi() = False Then
                    _isSave = True
                    If isAction = "Add" OrElse isAction = "Copy" Then
                        srvHR.SaveNewDataAlamat(modelDataAlamat)
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Edit" Then
                        srvHR.SaveEditDataAlamat(modelDataAlamat)
                        Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Delete" Then
                        srvHR.SaveDeleteDataAlamat(modelDataAlamat)
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    End If
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
            If dtTglMulai.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Tanggal Mulai Tidak Boleh Kosong!")
            ElseIf dtTglSelesai.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Tanggal Selesai Tidak Boleh Kosong!")
            ElseIf dtTglMulai.EditValue > dtTglSelesai.EditValue Then
                Err.Raise(ErrNumber, , "Tanggal Mulai Tidak Boleh Lebih Besar Dari Tanggal Selesai !")
            ElseIf txtAlamat.Text = "" Then
                Err.Raise(ErrNumber, , "Alamat Tidak Boleh Kosong!")
            ElseIf cbTipeAlamat.Text = "" Then
                Err.Raise(ErrNumber, , "Tipe Alamat Tidak Boleh Kosong!")
            End If

            modelDataAlamat = New HRPADataAlamatModel
            Dim Now As DateTime = DateTime.Now
            With modelDataAlamat
                .ID = ID
                .TglMulai = dtTglMulai.EditValue
                .TglSelesai = dtTglSelesai.EditValue
                .EmpID = EmpID
                .TipeAlamat = cbTipeAlamat.Text
                .Seq = 1
                .Alamat = txtAlamat.Text
                .RT = txtRT.Text
                .RW = txtRW.Text
                .Negara = cbNegara.Text
                .Provinsi = cbProvinsi.Text
                .KotaKab = txtKota.Text
                .Kecamatan = cbKecamatan.Text
                .Kelurahan = txtKelurahan.Text
                .KodePos = txtKodepos.Text
                .NoTelpon = txtNoTelp.Text
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

    Private Sub txtKodepos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodepos.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRT.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRW_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRW.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

End Class
