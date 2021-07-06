Imports DevExpress.XtraBars.ToastNotifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop
Imports System.Globalization
'Imports AddinExpress.Outlook.SecurityManager
Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Public Class Frm_POCompare_Detail

    Dim fc_Class As New Cls_PO
    Dim fc_Class_Detail As New Cls_PO_Detail
    Dim GridDtl As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Integer = 0
    Dim PONumber As String = ""
    Dim DtGridBarang As DataTable
    Dim dtBarang As DataTable
    Public IsClosed As Boolean = False
    Dim frmInput As Frm_GetPRDetail
    Dim isUpdate As Boolean = False



    Private Sub Frm_POCompare_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialSetForm()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl,
                   ByRef _Active_Form As Integer)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If

        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
        Active_Form = _Active_Form
        PONumber = strCode

    End Sub


    Public Overrides Sub InitialSetForm()

        If fs_Code <> "" Then
            isUpdate = True
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
            'Call LoadText(fs_Code)
            Call LoadPoDetail(fs_Code)

        Else
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        End If

        Me.Text = "PO DETAIL"
        bb_IsUpdate = isUpdate
        bs_MainFormName = FrmParent.Name.ToString()

    End Sub
    Private Sub LoadPoDetail(PONumber As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                'Dim dt As New DataTable
                DtGridBarang = New DataTable
                DtGridBarang = fc_Class.Get_PODetailCompare(PONumber)
                Grid.DataSource = DtGridBarang
                Cursor.Current = Cursors.Default

            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub


End Class
