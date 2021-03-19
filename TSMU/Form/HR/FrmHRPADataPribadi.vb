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

    Dim openFDialog As OpenFileDialog

    Dim modelDataPribadi As HRPADataPribadiModel
    Dim srvHR As New HRPAService
    Dim FileName As String = String.Empty

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
            Me.Text = isAction.ToUpper + " DATA PRIBADI"
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
                Dim PathSave As String = String.Empty
                PathSave = srvHR.GetGeneralParam("PathFoto")
                If dataRow("Foto") IsNot DBNull.Value Then
                    FileName = dataRow("Foto")
                    Using bmb = New Bitmap(PathSave + FileName)
                        Dim ms As New MemoryStream()
                        bmb.Save(ms, ImageFormat.Bmp)
                        pictureFoto.Image = Image.FromStream(ms)
                    End Using
                End If
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
        pictureFoto.Enabled = False
        txtReference.Enabled = False
        txtKet.Enabled = False
        If isAction = "View" Then
            btnSave.Enabled = False
        End If
        btnBrowse.Enabled = False
        btnDownload.Enabled = False
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

                    Dim PathFoto As String = String.Empty
                    Dim extension As String = String.Empty
                    Dim PathSave As String = String.Empty
                    PathSave = srvHR.GetGeneralParam("PathFoto")

                    If isAction = "Add" OrElse isAction = "Copy" Then
                        If openFDialog IsNot Nothing Then
                            ID = srvHR.GetMaxIDDataPribadi()
                            PathFoto = openFDialog.FileName
                            extension = IO.Path.GetExtension(PathFoto)
                            FileName = "Foto_" + NIK + "_" + ID.ToString() + extension
                            modelDataPribadi.Foto = FileName
                        End If
                        srvHR.SaveNewDataPribadi(modelDataPribadi)
                        If openFDialog IsNot Nothing Then
                            Dim image As Image = New Bitmap(pictureFoto.Image)
                            image.Save(PathSave & FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Edit" Then
                        If openFDialog IsNot Nothing Then
                            PathFoto = openFDialog.FileName
                            extension = IO.Path.GetExtension(PathFoto)
                            FileName = "Foto_" + NIK + "_" + ID.ToString() + extension
                            modelDataPribadi.Foto = FileName
                            Dim image As Image = New Bitmap(pictureFoto.Image)
                            Dim fileSavePath As String = String.Empty
                            fileSavePath = IO.Path.Combine(PathSave, FileName)
                            If File.Exists(fileSavePath) Then
                                File.Delete(fileSavePath)
                            End If
                            image.Save(PathSave & FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                        srvHR.SaveEditDataPribadi(modelDataPribadi)
                        Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Delete" Then
                        srvHR.SaveDeleteDataPribadi(modelDataPribadi)
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    End If
                    openFDialog.Dispose()
                    openFDialog = Nothing
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
                If isAction = "Add" OrElse isAction = "Copy" Then
                    If srvHR.CheckRangeDatePribadi(EmpID, dtTglMulai.EditValue, dtTglSelesai.EditValue) Then
                        Err.Raise(ErrNumber, , "Sudah Ada Tanggal Diperiode Ini  !")
                    End If
                ElseIf isAction = "Edit" Then
                    If srvHR.CheckRangeDateEditPribadi(ID, EmpID, dtTglMulai.EditValue, dtTglSelesai.EditValue) Then
                        Err.Raise(ErrNumber, , "Sudah Ada Tanggal Diperiode Ini  !")
                    End If
                End If
            End If

            Dim Now As DateTime = DateTime.Now
            modelDataPribadi = New HRPADataPribadiModel
            With modelDataPribadi
                .ID = ID
                .TglMulai = dtTglMulai.EditValue
                .TglSelesai = dtTglSelesai.EditValue
                .EmpID = EmpID
                .NIK = NIK
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
                .Foto = FileName
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

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        openFDialog = New OpenFileDialog
        openFDialog.Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
        openFDialog.Title = "Select Image"
        openFDialog.CheckFileExists = True

        If openFDialog.ShowDialog = DialogResult.OK Then
            pictureFoto.Image = Image.FromFile(openFDialog.FileName)
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim sfdPic As New SaveFileDialog()
        Try
            With sfdPic
                .Title = "Save Image As"
                .Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
                .AddExtension = True
                .DefaultExt = ".jpg"
                .FileName = txtNamaLengkap.Text & ".jpg"
                .ValidateNames = True
                .OverwritePrompt = True
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    Dim pic As Image
                    pic = pictureFoto.Image
                    If .FilterIndex = 1 Then
                        pic.Save(sfdPic.FileName, Imaging.ImageFormat.Jpeg)
                    ElseIf .FilterIndex = 2 Then
                        pic.Save(sfdPic.FileName, Imaging.ImageFormat.Png)
                    ElseIf .FilterIndex = 3 Then
                        pic.Save(sfdPic.FileName, Imaging.ImageFormat.Bmp)
                    End If
                Else
                    Return
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Saving Image Failed ->>" & ex.Message.ToString())
        Finally
            sfdPic.Dispose()
        End Try

    End Sub

End Class
