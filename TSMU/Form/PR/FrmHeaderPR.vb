Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmHeaderPR

    Dim ff_Detail As FrmDetailPR
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_PR
    'Dim fc_Class As New CR_UserCreateModel
    Dim Active_Form As Int32 = 0
    Dim DeptId As String

    Private Sub FrmHeaderPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bb_SetDisplayChangeConfirmation = False
        DeptId = gh_Common.GroupID
        Call LoadGrid(DeptId)


        'Call Sub_Dept(gh_Common.GroupID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, True)

    End Sub

    Private Sub LoadGrid(Dept As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            'pDate2 = Date.Now.AddMonths(3)
            'pDate1 = Date.Now.AddMonths(-3)

            Dim dt As New DataTable

            dt = fc_Class.Get_PR(DeptId)
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default





        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
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

        'If Active_Form = 1 Then
        '    ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        'ElseIf Active_Form = 6 Then
        '    ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, GridPurchase, Active_Form)
        'End If

        ff_Detail = New FrmDetailPR(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)


        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick


        Try

            Active_Form = 1

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim PRNo As String = ""

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PRNo = GridView1.GetRowCellValue(rowHandle, "PR No")

                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(PRNo,
                            "",
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
End Class
