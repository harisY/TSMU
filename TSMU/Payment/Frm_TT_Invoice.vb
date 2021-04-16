Imports System.Configuration
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports DevExpress.LookAndFeel

Public Class Frm_TT_Invoice
    Dim _Service As TTI_Header_Models
    Dim dtGrid As DataTable
    Dim dtGrid2 As DataTable
    Dim dtGrid3 As DataTable
    Dim ObPayment As New Cls_Payment
    Dim table As DataTable
    Dim tableDetail As DataTable
    Dim ff_Detail As Frm_TT_Invoice_Detail
    Dim ObjPaymentHeader As New TTI_Header_Models
    Dim ff_Detail2 As Frm_TT_Invoice_Detail

    Private Sub frm_AR2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid2 As New DataTable
        dtGrid2 = GridControl1.DataSource
        Call Proc_EnableButtons(True, False, True, True, False, False, False, True, False, False, False, True)
    End Sub
    Dim PrintTool As ReportPrintTool
    Public Overrides Sub Proc_Print()
        Try
            _Service = New TTI_Header_Models
            Dim ds As DataSet = New DataSet
            ds = _Service.PrintReport(NoVoucher)

            If CustID = "DNP" Then
                Dim Laporan As New DXReportTTI2()
                With Laporan
                    .DataSource = ds.Tables("TTI")
                End With
                PrintTool = New ReportPrintTool(Laporan)
            ElseIf CustID = "ETI" Then
                Dim Laporan As New DXReportTTI3()
                With Laporan
                    .DataSource = ds.Tables("TTI")

                End With
                PrintTool = New ReportPrintTool(Laporan)
            ElseIf CustID = "FSI" Then
                Dim Laporan As New DXReportTTI4()
                With Laporan
                    .DataSource = ds.Tables("TTI")
                End With
                PrintTool = New ReportPrintTool(Laporan)
            Else
                Dim Laporan As New DXReportTTI()
                With Laporan
                    .DataSource = ds.Tables("TTI")
                End With
                PrintTool = New ReportPrintTool(Laporan)
            End If





            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            'PrintTool.ShowPreviewDialog()
            PrintTool.ShowPreview(UserLookAndFeel.Default)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadGrid()
        Try

            dtGrid2 = ObjPaymentHeader.GetDataGrid2()
            GridControl1.DataSource = dtGrid2
            With GridView2
                .Columns(0).Visible = False
                .BestFitColumns()
                ''     .FixedLineWidth = 2
                ''     .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End With
            GridCellFormat(GridView2)

            'dtGrid2 = ObjPaymentHeader.GetDataGrid2()
            'GridControl1.DataSource = dtGrid2
            'With GridView2
            '    .Columns(0).Visible = False
            '    .BestFitColumns()
            '    .FixedLineWidth = 2
            '    .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'End With
            'GridCellFormat(GridView2)



        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""

        Call LoadGrid()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal ls_Code4 As String = "", Optional ByVal ls_Code5 As String = "", Optional ByVal ls_Code6 As Double = 0, Optional ByVal sts_screen As Byte = 0, Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New Frm_TT_Invoice_Detail(ls_Code, ls_Code2, ls_Code3, ls_Code4, ls_Code5, ls_Code6, sts_screen, Me, li_Row, GridControl1)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub


    Private Sub CallFrm2(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal sts_screen As Byte = 0, Optional ByVal li_Row As Integer = 0)
        If ff_Detail2 IsNot Nothing AndAlso ff_Detail2.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail2.Close()
        End If
        ff_Detail2 = New Frm_TT_Invoice_Detail(ls_Code, ls_Code2, sts_screen, Me, li_Row, GridControl1)
        ff_Detail2.MdiParent = FrmMain
        ff_Detail2.StartPosition = FormStartPosition.CenterScreen
        ff_Detail2.Show()
    End Sub
    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridControl1.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                id = String.Empty
                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView2.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView2.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView2.GetSelectedRows.Length > 0 Then
                    Call CallFrm2(id,
                             NoVoucher, 1,
                             GridView2.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub



    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty
        Dim VRNO As String = String.Empty
        Try
            Dim selectedRows() As Integer = GridView2.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView2.GetRowCellValue(rowHandle, "id")
                    VRNO = GridView2.GetRowCellValue(rowHandle, "vrno")
                End If
            Next rowHandle
            ObjPaymentHeader.id = ID
            ObjPaymentHeader.id = ID
            ObjPaymentHeader.vrno = VRNO
            ObjPaymentHeader.DeleteHeaderR(VRNO)


            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView2_Click(sender As Object, e As EventArgs) Handles GridView2.Click
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridControl1.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                id = String.Empty
                NoVoucher = String.Empty
                CustID = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView2.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView2.GetRowCellValue(rowHandle, "vrno")
                        CustID = GridView2.GetRowCellValue(rowHandle, "CustID")
                    End If
                Next rowHandle

            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim NoVoucher, id, NoBukti As String
    Dim CustID, Customer, AcctID_tujuan, Descr_tujuan, CurryID As String


    Dim Jumlah As Double

    Private editor As BaseEdit
End Class
