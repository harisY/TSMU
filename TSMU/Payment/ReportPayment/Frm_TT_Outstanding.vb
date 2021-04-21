Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class Frm_TT_Outstanding
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fs_Split As String = "'"
    Dim _Service As TTI_Header_Models
    Dim dtGrid As DataTable
    Dim ObPayment As New Cls_Payment
    Dim table As DataTable
    Dim GridDtl As GridControl
    Dim ObjPaymentHeader As New TTI_Header_Models
    Dim ObjPaymentDetail As New TTI_Detail_Models
    Dim _Tag As TagModel

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal strCode As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)

        Me.New()

        fs_Code = strCode
        bi_GridParentRow = li_GridRow

        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Private Sub Frm_TT_Outstanding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bb_SetDisplayChangeConfirmation = False
        ''  Call LoadGrid()
        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub
    'Private Sub LoadGrid()
    '    Try

    '        dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID2()
    '        Grid.DataSource = dtGrid
    '        With GridView1
    '            .Columns(0).Visible = False
    '            .BestFitColumns()

    '        End With
    '        GridCellFormat(GridView1)

    '    Catch ex As Exception
    '        Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub

    Public Overrides Sub InitialSetForm()
        Try

            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "Frm_TT_Invoice"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
