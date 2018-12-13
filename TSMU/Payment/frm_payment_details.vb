Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class frm_payment_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsBoM
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"

    Dim ObjFP As New Cls_FP
    Dim ObjPayment As New Cls_Payment
    Dim ObjCM As New Cls_cmdm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub frm_payment_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Payment " & fs_Code
            Else
                Me.Text = "Payment New Data"
            End If
            Call LoadTxtBox()
            LoadBank()
            LoadSupplier()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_payment"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class

                End With
            Else
                _TxtEVoucher.Text = ObjPayment.autonopv()
                _TxtPerpost.Text = ObjPayment.autoperpost()

                _TxtPaymentDate.EditValue = DateTime.Today
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub

    Public Sub LoadGridDetil()
        Try
            Dim dtGrid As New DataTable
            dtGrid = ObjPayment.getalldataap2()

            If dtGrid.Rows.Count > 0 Then
                GridInvoice.DataSource = dtGrid
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridCM()
        Try
            Dim dtGrid As New DataTable
            dtGrid = ObjCM.datadt2()

            If dtGrid.Rows.Count > 0 Then
                GridcCm.DataSource = dtGrid
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try


        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadBank()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = ObjPayment.bank()
            _TxtBank.Properties.DataSource = dtgrid
            _TxtBank.Properties.ValueMember = "BankAcct"
            _TxtBank.Properties.DisplayMember = "CashAcctName"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadSupplier()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = ObjPayment.supplier()
            _TxtSupplier.Properties.DataSource = dtgrid
            _TxtSupplier.Properties.ValueMember = "VendID"
            _TxtSupplier.Properties.DisplayMember = "Name"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub _TxtSupplier_Validated(sender As Object, e As EventArgs) Handles _TxtSupplier.Validated
        Try
            ObjPayment.VendID = _TxtSupplier.EditValue
            ObjPayment.ProsesVoucher()
            LoadGridDetil()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _TxtBank_Validated(sender As Object, e As EventArgs) Handles _TxtBank.Validated
        Try
            'ObjPayment.VendID = _TxtSupplier.EditValue
            'ObjPayment.ProsesVoucher()
            'LoadGridDetil()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
