Imports System.IO
Imports DevExpress.XtraGrid

Public Class Frm_CR_BeritaAcara_Input
    Dim fc_Class As New ClsCR_CreateUser

    Dim NoCirculation As String
    Dim NoBeritaAcara As String
    Dim Active_form As Integer
    Dim Dt As DataTable
    Dim opfImage As New OpenFileDialog
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim Extension As String = ""
    Dim fileSavePath As String = ""
    ' Dim SimpanFoto As String = "D:\@KERJA\Project\Foto\"
    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\Circulation\"
    Dim FrmViewPdf As Frm_ViewPdf


    'Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"


    Public Sub New(ByVal _NoCirculation As String,
                   ByVal _NoBeritaAcara As String,
                   ByVal _ActiveForm As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        NoCirculation = _NoCirculation
        NoBeritaAcara = _NoBeritaAcara
        Active_form = _ActiveForm

    End Sub

    Private Sub Frm_CR_BeritaAcara_Input_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dt = New DataTable
        Dt = fc_Class.GetBeritaAcara(NoCirculation)

        If Dt.Rows.Count = 0 Then
            T_Circulation.EditValue = NoCirculation
            T_TanggalBeritaAcara.EditValue = Date.Now
        Else
            T_Circulation.EditValue = NoCirculation
            T_BeritaAcara.EditValue = Dt.Rows(0).Item("NoBeritaAcara")
            T_TanggalBeritaAcara.EditValue = Dt.Rows(0).Item("TanggalBeritaAcara")
            T_AttachFile.EditValue = Dt.Rows(0).Item("Lampiran")

        End If
        If Active_form = 1 Then
            B_Save.Enabled = True
            B_Cancel.Enabled = True
            B_ViewPdf.Enabled = True
        Else
            B_Save.Enabled = False
            B_Cancel.Enabled = False
            B_ViewPdf.Enabled = True
        End If


    End Sub

    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click

        If T_Circulation.EditValue = "" Or T_BeritaAcara.EditValue = "" Then
            MessageBox.Show("Please Check Data",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
        Else
            If PathFoto <> "" And fileSavePath <> "" Then
                IO.File.Copy(PathFoto, fileSavePath, True)
            End If

            Dim dt As New DataTable
            dt = fc_Class.GetBeritaAcara(T_Circulation.EditValue)

            If dt.Rows.Count <= 0 Then
                fc_Class.H_CirculationNo = T_Circulation.EditValue
                fc_Class.H_NoBeritaAcara = T_BeritaAcara.EditValue
                fc_Class.H_FileBeritaAcara = IIf(T_AttachFile.EditValue Is Nothing, "", T_AttachFile.EditValue)
                fc_Class.H_TanggalBeritaAcara = T_TanggalBeritaAcara.EditValue
                fc_Class.Update_Berita_Acara(1)
                Timer1.Enabled = True
                MessageBox.Show("Data Das Been Saved", "Information")
                Me.Close()

            Else
                fc_Class.H_CirculationNo = T_Circulation.EditValue
                fc_Class.H_NoBeritaAcara = T_BeritaAcara.EditValue
                fc_Class.H_TanggalBeritaAcara = T_TanggalBeritaAcara.EditValue
                fc_Class.H_FileBeritaAcara = IIf(T_AttachFile.EditValue Is Nothing, "", T_AttachFile.EditValue)
                fc_Class.Update_Berita_Acara(2)
                Timer1.Enabled = True
                MessageBox.Show("Data Das Been Saved", "Information")
                Me.Close()

            End If

        End If



    End Sub

    Private Sub B_Cancel_Click(sender As Object, e As EventArgs) Handles B_Cancel.Click
        Me.Close()
    End Sub



    Private Sub T_AttachFile_EditValueChanged(sender As Object, e As EventArgs) Handles T_AttachFile.EditValueChanged

    End Sub

    Private Sub T_AttachFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles T_AttachFile.ButtonClick
        If T_BeritaAcara.Text = "" Then
            MessageBox.Show("Isi No Berita Acara",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
        Else

            opfImage.Filter = "Choose Image(*.pdf)|*.pdf"

            If opfImage.ShowDialog = DialogResult.OK Then

                PathFoto = opfImage.FileName
                'NamaFile = Path.GetFileNameWithoutExtension(PathFoto)
                'NamaFile = "NP_" + Path.GetRandomFileName() + extension
                Extension = Path.GetExtension(PathFoto)
                NamaFile = Path.GetFileNameWithoutExtension(PathFoto) + "_" + Format(DateTime.Now, "dMyyyyhmmss").ToString + Extension
                fileSavePath = Path.Combine(SimpanFoto, NamaFile)
                T_AttachFile.EditValue = NamaFile
                'IO.File.Copy(PathFoto, fileSavePath, True)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send("{ENTER}")
        Timer1.Enabled = False
    End Sub

    Private Sub B_ViewPdf_Click(sender As Object, e As EventArgs) Handles B_ViewPdf.Click

        FrmViewPdf = New Frm_ViewPdf(T_AttachFile.EditValue)

        FrmViewPdf.StartPosition = FormStartPosition.CenterScreen
        FrmViewPdf.MaximizeBox = False
        FrmViewPdf.ShowDialog()

    End Sub
End Class