Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmPPICLayoutGedung
    Dim srvPPIC As New PPICService()
    Dim dtGridUser As DataTable
    'Dim frmDetail As FrmPPICLayoutGedungDetail

    Private Sub GridBuildup_Load(sender As Object, e As EventArgs) Handles GridLayoutGedung.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGridUser = srvPPIC.GetDataLayoutGedung()
            GridLayoutGedung.DataSource = dtGridUser

            Dim colID As GridColumn = GridViewLayoutGedung.Columns("ID")
            colID.Visible = False

            Dim colTglBuat As GridColumn = GridViewLayoutGedung.Columns("CreateDate")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewLayoutGedung.Columns("UpdateDate")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewLayoutGedung.BestFitColumns()
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
            Dim UserCode As String = String.Empty
            Dim selectedRows() As Integer = GridViewLayoutGedung.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridViewLayoutGedung.GetRowCellValue(rowHandle, "ID")
                    UserCode = GridViewLayoutGedung.GetRowCellValue(rowHandle, "UserCode")
                End If
            Next rowHandle

            srvPPIC.DeleteDataLayoutGedung(ID)
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
        'If frmDetail IsNot Nothing AndAlso frmDetail.Visible Then
        '    If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
        '        Exit Sub
        '    End If
        '    frmDetail.Close()
        'End If
        'frmDetail = New FrmPPICLayoutGedungDetail(ls_Code, ls_Code2, Me, li_Row, GridBuildup)
        'frmDetail.MdiParent = FrmMain
        'frmDetail.StartPosition = FormStartPosition.CenterScreen
        'frmDetail.Show()
    End Sub

    Private Sub GridLayoutGedung_DoubleClick(sender As Object, e As EventArgs) Handles GridLayoutGedung.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridLayoutGedung.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim ID As Integer
                Dim UserCode As String = String.Empty
                Dim selectedRows() As Integer = GridViewLayoutGedung.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridViewLayoutGedung.GetRowCellValue(rowHandle, "ID")
                        UserCode = GridViewLayoutGedung.GetRowCellValue(rowHandle, "UserCode")
                    End If
                Next rowHandle

                If GridViewLayoutGedung.GetSelectedRows.Length > 0 Then
                    Call CallFrmDetail(ID, UserCode)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class
