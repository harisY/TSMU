Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid

Public Class FrmHRPADataIDPribadi

    Dim _isSave As Boolean
    Dim isAction As String
    Dim ID As Integer
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim openFDialog As OpenFileDialog

    Dim modelDataIDPribadi As HRPADataIDPribadiModel
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

    Private Sub FrmHRPADataIDPribadi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            Me.Text = isAction.ToUpper + " DATA ID PRIBADI"
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
                cbTipeID.Text = IIf(dataRow("TipeID") Is DBNull.Value, "", dataRow("TipeID"))
                txtDeskripsi.Text = IIf(dataRow("NoID") Is DBNull.Value, "", dataRow("NoID"))
                dtTglBerakhir.EditValue = IIf(dataRow("TglBerakhir") Is DBNull.Value, Nothing, dataRow("TglBerakhir"))
                txtOtoritas.Text = IIf(dataRow("Otoritas") Is DBNull.Value, "", dataRow("Otoritas"))
                Dim PathSave As String = String.Empty
                PathSave = srvHR.GetGeneralParam("PathID")
                FileName = IIf(dataRow("Gambar") Is DBNull.Value, "", dataRow("Gambar"))
                If FileName <> "" Then
                    Using bmb = New Bitmap(PathSave + FileName)
                        Dim ms As New MemoryStream()
                        bmb.Save(ms, ImageFormat.Bmp)
                        picGambar.Image = Image.FromStream(ms)
                    End Using
                End If
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
        cbTipeID.Enabled = False
        txtDeskripsi.Enabled = False
        dtTglBerakhir.Enabled = False
        txtOtoritas.Enabled = False
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
                    PathSave = srvHR.GetGeneralParam("PathID")

                    If isAction = "Add" OrElse isAction = "Copy" Then
                        If openFDialog IsNot Nothing Then
                            ID = srvHR.GetMaxIDDataPribadi()
                            PathFoto = openFDialog.FileName
                            extension = IO.Path.GetExtension(PathFoto)
                            FileName = "ID_" + NIK + "_" + ID.ToString() + extension
                            modelDataIDPribadi.Gambar = FileName
                        End If
                        srvHR.SaveNewDataIDPribadi(modelDataIDPribadi)
                        If openFDialog IsNot Nothing Then
                            Dim image As Image = New Bitmap(picGambar.Image)
                            image.Save(PathSave & FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Edit" Then
                        If openFDialog IsNot Nothing Then
                            PathFoto = openFDialog.FileName
                            extension = IO.Path.GetExtension(PathFoto)
                            FileName = "ID_" + NIK + "_" + ID.ToString() + extension
                            modelDataIDPribadi.Gambar = FileName
                            Dim image As Image = New Bitmap(picGambar.Image)
                            Dim fileSavePath As String = String.Empty
                            fileSavePath = IO.Path.Combine(PathSave, FileName)
                            If File.Exists(fileSavePath) Then
                                File.Delete(fileSavePath)
                            End If
                            image.Save(PathSave & FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        End If
                        srvHR.SaveEditDataIDPribadi(modelDataIDPribadi)
                        Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Delete" Then
                        If FileName <> "" Then
                            Dim fileSavePath As String = String.Empty
                            fileSavePath = IO.Path.Combine(PathSave, FileName)
                            If File.Exists(fileSavePath) Then
                                File.Delete(fileSavePath)
                            End If
                        End If
                        srvHR.SaveDeleteDataIDPribadi(modelDataIDPribadi)
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
            ElseIf cbTipeID.Text = "" Then
                Err.Raise(ErrNumber, , "Tipe ID Tidak Boleh Kosong!")
            ElseIf txtDeskripsi.Text = "" Then
                Err.Raise(ErrNumber, , "No ID Tidak Boleh Kosong!")
            End If

            modelDataIDPribadi = New HRPADataIDPribadiModel

            Dim Now As DateTime = DateTime.Now
            With modelDataIDPribadi
                .ID = ID
                .TglMulai = dtTglMulai.EditValue
                .TglSelesai = dtTglSelesai.EditValue
                .EmpID = EmpID
                .TipeID = cbTipeID.Text
                .Seq = 1
                .NoID = txtDeskripsi.Text
                .TglBerakhir = dtTglBerakhir.EditValue
                .Otoritas = txtOtoritas.Text
                .Gambar = FileName
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

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        openFDialog = New OpenFileDialog
        openFDialog.Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp"
        openFDialog.Title = "Select Image"
        openFDialog.CheckFileExists = True

        If openFDialog.ShowDialog = DialogResult.OK Then
            picGambar.Image = Image.FromFile(openFDialog.FileName)
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
                .FileName = txtDeskripsi.Text & ".jpg"
                .ValidateNames = True
                .OverwritePrompt = True
                .RestoreDirectory = True

                If .ShowDialog = DialogResult.OK Then
                    Dim pic As Image
                    pic = picGambar.Image
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
