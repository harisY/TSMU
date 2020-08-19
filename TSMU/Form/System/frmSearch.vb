Public Class frmSearch

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Property TglDari() As String
    Public Property TglSampai() As String


    Private Sub frmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTglDari.EditValue = Date.Today
        TxtTglSampai.EditValue = Date.Today
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Try
            TglDari = Format(TxtTglDari.EditValue, gs_FormatSQLDate)
            TglSampai = Format(TxtTglSampai.EditValue, gs_FormatSQLDate)
            Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class