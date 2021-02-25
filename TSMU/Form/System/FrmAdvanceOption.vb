Public Class frmAdvanceOption
    Dim _item As New List(Of String)
    Public Sub New(ItemChild__ As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()
        _item = ItemChild__
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property ItemChild() As String

    Private Sub frmAdvanceApprove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtItemChild.Properties.Items.Clear()
        txtItemChild.Properties.Items.AddRange(_item)
        txtItemChild.SelectedIndex = 0
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            ItemChild = txtItemChild.Text
            Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub
End Class