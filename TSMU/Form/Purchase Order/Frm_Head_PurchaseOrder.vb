Public Class Frm_Head_PurchaseOrder

    Dim ff_Detail As Frm_Detail_PurchaseOrder
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_PR
    'Dim fc_Class As New CR_UserCreateModel
    Dim Active_Form As Int32 = 0
    Dim DeptId As String

    Private Sub Frm_Head_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub


    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If

        ff_Detail = New Frm_Detail_PurchaseOrder(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
            ff_Detail.MdiParent = FrmMain
            ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

End Class
