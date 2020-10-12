Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class FrmCCSettlement
    Dim cls_Accrued As ClsCCAccrued
    Dim clsGlobal As GlobalService
    Dim dtGrid As New DataTable
    Dim dtGridAccrued As New DataTable
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String
    Dim _Tag As TagModel
    Dim ff_Detail81 As FrmSuspendSettleDetailDirect

    Sub New(SuspendID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = SuspendID

        ''   GridDtl = _Grid
        '' FrmParent = lf_FormParent
        _Tag = New TagModel
        ''  _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Sub New(SuspendID As String, ByRef lf_FormParent As Form)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = SuspendID

        ''   GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        ''  _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Private Sub FrmCCSettlement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
        LoadGridAccruedAll()
    End Sub
    Private Sub CallFrm4(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal ls_Code4 As String = "", Optional ByVal sts_skreen As Byte = 1, Optional ByVal li_Row As Integer = 0)
        If ff_Detail81 IsNot Nothing AndAlso ff_Detail81.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail81.Close()
        End If
        ff_Detail81 = New FrmSuspendSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, GridAccruedAll)
        ff_Detail81.MdiParent = FrmMain
        ff_Detail81.StartPosition = FormStartPosition.CenterScreen
        ff_Detail81.Show()
    End Sub
    Public Overrides Sub Proc_Refresh()

        LoadGridAccruedAll()

    End Sub

    Private Sub LoadGridAccruedAll()
        Try
            'cls_Accrued = New ClsCCAccrued
            'dtGrid = cls_Accrued.GetDataCostCCAll(_NoBukti)
            'GridAccruedAll.DataSource = dtGrid
            'GridViewAccruedAll.Columns("ID").Visible = False
            'GridViewAccruedAll.Columns("Seq").Visible = False
            'GridViewAccruedAll.Columns("Pay").Visible = False
            'GridViewAccruedAll.BestFitColumns()
            'GridCellFormat(GridViewAccruedAll)


            Dim dtGrid As New DataTable
            'ObjCashBank.Perpost = _txtperpost.Text
            'ObjCashBank.AcctID = _txtaccount.Text
            dtGrid = ObjCashBank.GetGridDetailSettleByAccountID03CC(_NoBukti)
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.Columns("ID").Visible = False
            GridViewAccruedAll.Columns("Seq").Visible = False
            GridViewAccruedAll.Columns("Pay").Visible = False
            GridViewAccruedAll.BestFitColumns()
            GridCellFormat(GridViewAccruedAll)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridAccruedAll_DoubleClick(sender As Object, e As EventArgs) Handles GridAccruedAll.DoubleClick

        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridAccruedAll.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                Dim id As String = String.Empty
                Dim idx As String = String.Empty

                Dim selectedRows() As Integer = GridViewAccruedAll.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ''                        idx = GridViewAccruedAll.GetRowCellValue(rowHandle, "NoTransaksi").ToString().TrimEnd
                        idx = GridViewAccruedAll.GetRowCellValue(rowHandle, "NoAccrued").ToString().TrimEnd
                    End If
                Next rowHandle

                Call CallFrm4(idx, "bank",
                GridViewAccruedAll.RowCount)


            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
