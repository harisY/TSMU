Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_POCompare_Header


    Dim ff_Detail As Frm_POCompare_Detail
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_PO
    'Dim fc_Class As New CR_UserCreateModel
    Dim Active_Form As Int32 = 0
    Dim DeptId As String
    Dim PONumber As String = ""

    Private Sub Frm_POCompare_Header_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadGrid()
    End Sub

    Private Sub LoadGrid()

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim dt As New DataTable
            dt = fc_Class.Get_POHeaderCompare()
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If

        ff_Detail = New Frm_POCompare_Detail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            PONumber = String.Empty

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PONumber = GridView1.GetRowCellValue(rowHandle, "PO Number")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(PONumber)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
