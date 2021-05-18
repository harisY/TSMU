Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_Head_PurchaseOrder


    Dim ff_Detail As Frm_Detail_PurchaseOrder
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_PO
    'Dim fc_Class As New CR_UserCreateModel
    Dim Active_Form As Int32 = 0
    Dim DeptId As String
    Dim PONumber As String = ""

    Private Sub Frm_Head_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call LoadGrid()
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, True)

    End Sub
    Private Sub LoadGrid()
        Try
            Cursor.Current = Cursors.WaitCursor

            'pDate2 = Date.Now.AddMonths(3)
            'pDate1 = Date.Now.AddMonths(-3)

            Dim dt As New DataTable

            dt = fc_Class.Get_POHeader()
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

        ff_Detail = New Frm_Detail_PurchaseOrder(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Try

            ' Active_Form = 1

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            PONumber = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
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


    Public Overrides Sub Proc_DeleteData()
        Dim IDTrans As String = ""

        Try
            'fc_Class.ObjDetails.Clear()
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            'ObjMaterialUsageDetail = New MaterialUsageDetailModel

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        'ObjMaterialUsageDetail.IDMaterialUsage = GridView1.GetRowCellValue(rowHandle, "IDMaterialUsage")
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "PO Number")
                    End If
                Next rowHandle

                Try

                    ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
                    Dim dt As New DataTable
                    dt = fc_Class.Get_Delete(IDTrans)

                    If dt.Rows.Count = 0 Then

                        MessageBox.Show("PO '" & IDTrans & "' Cannot Delete",
                                                     "Warning",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                        fc_Class.Delete(IDTrans)
                        Call LoadGrid()
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)



                        Exit Sub

                    End If
                Catch ex As Exception
                    Throw
                End Try
            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

End Class
