Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraGrid

Public Class FrmHRPADataKesehatan

    Dim _isSave As Boolean
    Dim isAction As String
    Dim ID As Integer
    Dim NIK As String
    Dim EmpID As String
    Dim dataRow As DataRow
    Dim GridDtl As GridControl
    Dim FrmParent As Form

    Dim modelDataKesehatan As HRPADataKesehatanModel
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

    Private Sub FrmHRPADataKesehatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            Me.Text = isAction.ToUpper + " DATA KESEHATAN"
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
                txtTinggiBadan.Text = IIf(dataRow("TinggiBadan") Is DBNull.Value, "", dataRow("TinggiBadan"))
                txtBeratBadan.Text = IIf(dataRow("BeratBadan") Is DBNull.Value, "", dataRow("BeratBadan"))
                txtVaksinasi.Text = IIf(dataRow("Vaksinasi") Is DBNull.Value, "", dataRow("Vaksinasi"))
                txtRiwayatSakit.Text = IIf(dataRow("RiwayatSakit") Is DBNull.Value, "", dataRow("RiwayatSakit"))
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
        txtTinggiBadan.Enabled = False
        txtBeratBadan.Enabled = False
        txtVaksinasi.Enabled = False
        txtRiwayatSakit.Enabled = False
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
                        srvHR.SaveNewDataKesehatan(modelDataKesehatan)
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Edit" Then
                        srvHR.SaveEditDataKesehatan(modelDataKesehatan)
                        Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                    ElseIf isAction = "Delete" Then
                        srvHR.SaveDeleteDataKesehatan(modelDataKesehatan)
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
            End If

            modelDataKesehatan = New HRPADataKesehatanModel

            Dim Now As DateTime = DateTime.Now
            With modelDataKesehatan
                .ID = ID
                .TglMulai = dtTglMulai.EditValue
                .TglSelesai = dtTglSelesai.EditValue
                .EmpID = EmpID
                .Seq = 1
                .TinggiBadan = txtTinggiBadan.Text
                .BeratBadan = txtBeratBadan.Text
                .Vaksinasi = txtVaksinasi.Text
                .RiwayatSakit = txtRiwayatSakit.Text
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
