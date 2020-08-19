Public Class frmAdvanceSearch

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Property TglDari() As String
    Public Property TglSampai() As String
    Public Property Status() As String


    Private Sub frmAdvanceSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTglDari.EditValue = Date.Today
        TxtTglSampai.EditValue = Date.Today
        CmbStatus.SelectedIndex = 0
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        Try
            TglDari = Format(TxtTglDari.EditValue, gs_FormatSQLDate)
            TglSampai = Format(TxtTglSampai.EditValue, gs_FormatSQLDate)
            Select Case CmbStatus.Text.ToLower
                Case "all"
                    Status = "ALL"
                Case "created"
                    Status = "0"
                Case "submited"
                    Status = "1"
                Case "checked"
                    Status = "2"
                Case "completed"
                    Status = "3"
            End Select
            Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class