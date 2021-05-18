Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmPPICKapOEM
    Dim srvPPIC As New PPICService()
    Dim dtGridKapOEM As DataTable
    Dim frmDetail As FrmPPICKapOEMDetail

    Private Sub GridBuildup_Load(sender As Object, e As EventArgs) Handles GridKapOEM.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGridKapOEM = srvPPIC.GetDataKapOEM()
            GridKapOEM.DataSource = dtGridKapOEM

            Dim colID As GridColumn = GridViewKapOEM.Columns("ID")
            colID.Visible = False

            Dim colTglBuat As GridColumn = GridViewKapOEM.Columns("CreateDate")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewKapOEM.Columns("UpdateDate")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewKapOEM.BestFitColumns()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrmDetail()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim ID As Integer
            Dim PartNo As String = String.Empty
            Dim InventoryID As String = String.Empty
            Dim selectedRows() As Integer = GridViewKapOEM.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridViewKapOEM.GetRowCellValue(rowHandle, "ID")
                    PartNo = GridViewKapOEM.GetRowCellValue(rowHandle, "PartNo")
                    InventoryID = GridViewKapOEM.GetRowCellValue(rowHandle, "InventoryID")
                End If
            Next rowHandle

            srvPPIC.DeleteDataKapOEM(ID)
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Private Sub CallFrmDetail(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If frmDetail IsNot Nothing AndAlso frmDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frmDetail.Close()
        End If
        frmDetail = New FrmPPICKapOEMDetail(ls_Code, ls_Code2, Me, li_Row, GridKapOEM)
        frmDetail.MdiParent = FrmMain
        frmDetail.StartPosition = FormStartPosition.CenterScreen
        frmDetail.Show()
    End Sub

    Private Sub GridBuildup_DoubleClick(sender As Object, e As EventArgs) Handles GridKapOEM.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridKapOEM.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim ID As Integer
                Dim PartNo As String = String.Empty
                Dim InventoryID As String = String.Empty
                Dim selectedRows() As Integer = GridViewKapOEM.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridViewKapOEM.GetRowCellValue(rowHandle, "ID")
                        PartNo = GridViewKapOEM.GetRowCellValue(rowHandle, "PartNo")
                        InventoryID = GridViewKapOEM.GetRowCellValue(rowHandle, "InventoryID")
                    End If
                Next rowHandle

                If GridViewKapOEM.GetSelectedRows.Length > 0 Then
                    Call CallFrmDetail(ID, PartNo)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class
