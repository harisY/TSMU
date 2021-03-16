Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmHRAdministrasiKaryawan
    Dim srvHR As New HRPAService()
    Dim dtGridKaryawan As DataTable
    Dim frm_PADetail As FrmHRAdministrasiKaryawanDetail
    Dim frm_PANew As FrmHRPANewEmployee

    Private Sub FrmHRAdministrasiKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(True, False, False, True, False, False, False, False, False, False, False, False)
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_InputNewData()
        Call CallFrmNew()
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Private Sub LoadGrid()
        dtGridKaryawan = New DataTable
        dtGridKaryawan = srvHR.GetDataKaryawan()
        GridKaryawan.DataSource = dtGridKaryawan
        Dim colEmpID As GridColumn = GridViewKaryawan.Columns("EmployeeID")
        Dim colTglLahir As GridColumn = GridViewKaryawan.Columns("TglLahir")
        colTglLahir.DisplayFormat.FormatType = FormatType.DateTime
        colTglLahir.DisplayFormat.FormatString = "dd/MM/yyyy"
        colEmpID.Visible = False
        GridViewKaryawan.BestFitColumns()
    End Sub

    Private Sub gridKaryawan_DoubleClick(sender As Object, e As EventArgs) Handles GridKaryawan.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridKaryawan.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim EmpID As String = String.Empty
                Dim selectedRows() As Integer = GridViewKaryawan.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        EmpID = GridViewKaryawan.GetRowCellValue(rowHandle, "EmployeeID")
                    End If
                Next rowHandle

                If GridViewKaryawan.GetSelectedRows.Length > 0 Then
                    Call CallFrmDetail(EmpID, "")
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CallFrmDetail(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If frm_PADetail IsNot Nothing AndAlso frm_PADetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_PADetail.Close()
        End If
        frm_PADetail = New FrmHRAdministrasiKaryawanDetail(ls_Code, ls_Code2, li_Row, Me, GridKaryawan)
        frm_PADetail.MdiParent = FrmMain
        frm_PADetail.StartPosition = FormStartPosition.CenterScreen
        frm_PADetail.Show()
    End Sub

    Private Sub CallFrmNew(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If frm_PANew IsNot Nothing AndAlso frm_PANew.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_PANew.Close()
        End If
        frm_PANew = New FrmHRPANewEmployee(ls_Code, ls_Code2, li_Row, Me, GridKaryawan)
        frm_PANew.MdiParent = FrmMain
        frm_PANew.StartPosition = FormStartPosition.CenterScreen
        frm_PANew.Show()
    End Sub

End Class
