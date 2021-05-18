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


Public Class Frm_CR_UserCreateDetail

    Dim GService As GlobalService
    Dim FrmReport As FrmReportCirculation
    Dim FrmAccounting As Frm_CR_Accounting
    Dim Active_Form As Integer = 0
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim Model_Level As level_Model
    Dim fc_Class As New ClsCR_CreateUser
    Dim fc_Model As New CR_UserCreateModel
    Dim fc_Model_ApproveHistoryModel As New ApproveHistoryModel
    Dim fc_Class_ApproveDeptHead As New clsCR_ApproveDeptHead
    Dim fc_Class_ApproveDivHead As New clsCR_ApproveDivHead
    Dim fc_Class_OtherDept As New ClsCR_Other_Dept
    Dim Description_Of_Cost As New ClsCR_Description_of_Cost
    Dim Installment As New ClsCR_Installment
    Dim Other_Dept As New ClsCR_Other_Dept
    Dim fc_Class_Accounting As New clsCR_Accounting
    Dim Approvel As New ClsCR_Approve
    Dim GridDtl As GridControl
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Dept As String
    Dim DeptSub As String = ""
    Dim DtGridBarang As DataTable
    Dim DtGridPayment As DataTable
    Dim DtTotal As DataTable
    Dim TotalBudget As Double = 0
    Dim TotalCR As Double = 0
    Dim SisaBudget As Double = 0
    Dim CR As Double = 0
    Dim Balance As Double = 0
    Dim NoSirkulasi As String = ""
    Dim CForm As Integer = 0
    Dim FGetMold As Frm_CR_Get_Mold
    Dim FGetBeritaAcara As Frm_CR_BeritaAcara_Input
    Dim BG As String = ""
    Dim DtGrid_PYM As DataTable
    Dim DtTerm As DataTable
    Dim Dt_OtherDept As DataTable
    Dim _Tag As TagModel
    Dim dtApprove As DataTable
    Dim Division As Integer
    Dim Director As Integer
    Dim pDate2 As Date
    Dim pDate1 As Date
    Dim _level As Integer = 0
    Dim DeptGroup As Integer

    Dim PrintTool As ReportPrintTool
    Dim PrintToolDOC As ReportPrintTool

    Private subreport As New XRSubreport() With {.BoundsF = New RectangleF(0, 100, 550, 25)}


    Dim id As System.Globalization.CultureInfo '= New System.Globalization.CultureInfo("id-ID")


    'Dim OlSecurityManager As AddinExpress.Outlook.SecurityManager

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
        NoSirkulasi = strCode
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.GetDataByID(fs_Code)
                If gh_Common.AdminStatus = True Then
                    Call LoadTxtBox()
                    Call LoadGridBarang(fs_Code)
                    Call LoadGridInstallment(fs_Code)
                    Call LoadGrid_OtherDept(fs_Code)
                    Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
                    Call No_Edit_TextBox()
                ElseIf gh_Common.GroupID = "1BOD" Then

                    If fc_Class.H_Current_Level <= 3 Then
                        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
                    Else
                        Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, True)
                    End If

                    Call LoadTxtBox()
                    Call LoadGridBarang(fs_Code)
                    Call LoadGridInstallment(fs_Code)
                    Call LoadGrid_OtherDept(fs_Code)
                    Call Sub_Dept(fc_Class.H_DeptID)
                    T_CRNo.Enabled = False

                    If ls_Error <> "" Then
                        Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                        isCancel = True
                        Me.Hide()
                        Exit Sub
                    Else
                        isUpdate = True
                    End If
                    Me.Text = "CIRCULATION FORM -> " & fs_Code

                Else

                    Call LoadTxtBox()
                    Call LoadGridBarang(fs_Code)
                    Call LoadGridInstallment(fs_Code)
                    Call LoadGrid_OtherDept(fs_Code)

                    If T_CRType.EditValue = "Mold" Then
                        With GridView1
                            .Columns("Model").Visible = True
                            .Columns("Sales Type").Visible = True
                            .Columns("Remark").Visible = True
                        End With
                    Else
                        With GridView1
                            .Columns("Model").Visible = False
                            .Columns("Sales Type").Visible = False
                            .Columns("Remark").Visible = False
                        End With

                    End If


                    If ls_Error <> "" Then
                        Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                        isCancel = True
                        Me.Hide()
                        Exit Sub
                    Else
                        isUpdate = True
                    End If
                    Me.Text = "CIRCULATION FORM -> " & fs_Code

                    'Active_Form 1 = User
                    If Active_Form = 1 Then

                        BPrint.Visible = False

                        With GridView1
                            .Columns("Note").Visible = True
                        End With

                        Grid4.Enabled = False
                        If T_CRType.Text = "Mold" Then
                            GroupBox2.Enabled = True
                        Else
                            GroupBox2.Enabled = False
                        End If
                        C_Term.Visible = False
                        If fc_Class.H_Status = "Create" Or fc_Class.H_Status = "Submit" Or fc_Class.H_Status = "Revise" Then
                            GridView1.OptionsBehavior.Editable = True
                            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
                            T_CRNo.Enabled = False
                        ElseIf fc_Class.H_Status = "Set Installment" Or fc_Class.H_Status = "BA" Then
                            GridView1.OptionsBehavior.Editable = True
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, True, False, False, False)
                            BBeritaAcara.Enabled = True
                            BAddRows.Enabled = False
                            T_CRNo.Enabled = False
                        Else
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, True, False, False, False)
                            Call No_Edit_TextBox()
                            BAddRows.Enabled = False
                            BMold.Enabled = False
                        End If
                        'Active_Form 2 = DeptHead
                        Grid4.Visible = False
                        C_Term.Visible = False

                    ElseIf Active_Form = 2 Then

                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = False

                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView1.OptionsBehavior.Editable = True
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        Call No_Edit_TextBox()

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = False
                            .Columns("Price").OptionsColumn.AllowEdit = False
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = False
                            '.Columns("Check").Visible = True
                            '.Columns("Check").OptionsColumn.AllowEdit = True
                            .Columns("Note").Visible = True
                            .Columns("Note").OptionsColumn.AllowEdit = True

                        End With

                        If fc_Class.H_Status = "Submit" Or fc_Class.H_Status = "Approve 1" Or fc_Class.H_Status = "Other Dept" Then
                            Call Proc_EnableButtons(False, False, True, False, False, False, False, False, False, False, True)
                        Else
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
                            GridView1.OptionsBehavior.Editable = False
                        End If
                        'Active_Form 3 = DIVtHead
                    ElseIf Active_Form = 3 Then
                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = False
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView1.OptionsBehavior.Editable = True
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        Call No_Edit_TextBox()

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = False
                            .Columns("Price").OptionsColumn.AllowEdit = False
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = False
                            '.Columns("Check").Visible = True
                            '.Columns("Check").OptionsColumn.AllowEdit = True
                            .Columns("Note").Visible = True
                            .Columns("Note").OptionsColumn.AllowEdit = True

                        End With

                        If fc_Class.H_Status = "Approve 1" Or fc_Class.H_Status = "Approve 2" Or fc_Class.H_Status = "Other Dept" Then
                            Call Proc_EnableButtons(False, False, True, False, False, False, False, False, False, False, True)
                        Else
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
                            GridView1.OptionsBehavior.Editable = False
                        End If


                    ElseIf Active_Form = 4 Then   'Other Dept

                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = False
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView5.OptionsBehavior.Editable = True
                        GridView1.OptionsBehavior.Editable = False
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        Call No_Edit_TextBox()

                        If gh_Common.GroupID = "1MKT" Then
                            GridView1.OptionsBehavior.Editable = True
                            With GridView1
                                .Columns("Sales Type").Visible = True
                                .Columns("Sales Type").OptionsColumn.AllowEdit = True
                                .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                                .Columns("Spesification").OptionsColumn.AllowEdit = False
                                .Columns("Qty").OptionsColumn.AllowEdit = False
                                .Columns("Price").OptionsColumn.AllowEdit = False
                                .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                                .Columns("Curr").OptionsColumn.AllowEdit = False
                                .Columns("Category").OptionsColumn.AllowEdit = False
                                .Columns("Balance").OptionsColumn.AllowEdit = False
                                .Columns("Rate").OptionsColumn.AllowEdit = False
                                .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                                .Columns("Total IDR").OptionsColumn.AllowEdit = False
                                .Columns("Account").OptionsColumn.AllowEdit = False

                            End With
                        ElseIf gh_Common.GroupID = "1FAC" Then

                            T_CRType.Enabled = True
                            GroupBox1.Enabled = True
                            GridView1.OptionsBehavior.Editable = True
                            With GridView1

                                .Columns("Sales Type").OptionsColumn.AllowEdit = False
                                .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                                .Columns("Spesification").OptionsColumn.AllowEdit = False
                                .Columns("Qty").OptionsColumn.AllowEdit = False
                                .Columns("Price").OptionsColumn.AllowEdit = False
                                .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                                .Columns("Curr").OptionsColumn.AllowEdit = False
                                .Columns("Category").OptionsColumn.AllowEdit = False
                                .Columns("Balance").OptionsColumn.AllowEdit = False
                                .Columns("Rate").OptionsColumn.AllowEdit = False
                                .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                                .Columns("Total IDR").OptionsColumn.AllowEdit = False
                                .Columns("Account").OptionsColumn.AllowEdit = True

                            End With
                        End If

                        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)
                    ElseIf Active_Form = 5 Then  'Active_Form 5 = Accounting
                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = False
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView5.OptionsBehavior.Editable = False
                        GridView1.OptionsBehavior.Editable = True
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        Call Edit_TextBox()
                        T_Dept.Enabled = False
                        T_CRNo.Enabled = False
                        T_RequirementDate.Enabled=False

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = True
                            .Columns("Price").OptionsColumn.AllowEdit = True
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = True
                            '.Columns("Check").Visible = True
                            .Columns("Note").Visible = True
                        End With

                        If fc_Class.H_Status = "Other Dept" Then
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)
                        ElseIf fc_Class.H_Status = "Set Installment" Or fc_Class.H_Status = "Approve BOD" Then
                            'ElseIf fc_Class.H_Status = "BA" Then
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)
                            BBeritaAcara.Visible = True
                            BBeritaAcara.Text = "No Berita Acara"
                        Else
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
                        End If

                    ElseIf Active_Form = 6 Then  'Active_Form 6 = Purchase Monitor
                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = True
                        Call LoadGridInstallment(fc_Class.H_CirculationNo)
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = True
                        GridView5.OptionsBehavior.Editable = True
                        GridView1.OptionsBehavior.Editable = False
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        Call No_Edit_TextBox()
                        C_Term.Enabled = True

                        If fc_Class.H_Status = "Approve BOD" Or fc_Class.H_Status = "Set Installment" Then
                            T_PO.Enabled = True
                            T_PR.Enabled = True
                        End If

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = False
                            .Columns("Price").OptionsColumn.AllowEdit = False
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = False
                            '.Columns("Check").Visible = True
                            .Columns("Note").Visible = True
                        End With
                        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)

                        'Active_Form 7 = Purchase Termin
                    ElseIf Active_Form = 7 Then

                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = True
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView5.OptionsBehavior.Editable = True
                        GridView1.OptionsBehavior.Editable = False
                        BAddRows.Enabled = False
                        BMold.Enabled = False

                        Call No_Edit_TextBox()

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = False
                            .Columns("Price").OptionsColumn.AllowEdit = False
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = False
                            '.Columns("Check").Visible = True
                            .Columns("Note").Visible = True
                        End With
                        If fc_Class.H_Status = "BA" Or fc_Class.H_Status = "Approve BOD" Or fc_Class.H_Status = "Set Installment" Then
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True, False)
                            BBeritaAcara.Enabled = True
                        Else
                            Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
                        End If


                    ElseIf Active_Form = 8 Then
                        Grid5.Visible = True
                        Grid4.Visible = False
                        C_Term.Visible = False
                        GridView3.OptionsBehavior.Editable = False
                        GridView4.OptionsBehavior.Editable = False
                        GridView5.OptionsBehavior.Editable = False
                        GridView1.OptionsBehavior.Editable = False
                        BAddRows.Enabled = False
                        BMold.Enabled = False
                        BBeritaAcara.Visible = True
                        Call No_Edit_TextBox()

                        With GridView1
                            .Columns("Name Of Goods").OptionsColumn.AllowEdit = False
                            .Columns("Spesification").OptionsColumn.AllowEdit = False
                            .Columns("Qty").OptionsColumn.AllowEdit = False
                            .Columns("Price").OptionsColumn.AllowEdit = False
                            .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                            .Columns("Curr").OptionsColumn.AllowEdit = False
                            .Columns("Category").OptionsColumn.AllowEdit = False
                            .Columns("Balance").OptionsColumn.AllowEdit = False
                            .Columns("Rate").OptionsColumn.AllowEdit = False
                            .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                            .Columns("Total IDR").OptionsColumn.AllowEdit = False
                            .Columns("Account").OptionsColumn.AllowEdit = False
                            '.Columns("Check").Visible = True
                            .Columns("Note").Visible = True
                        End With
                        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
                    End If
                    Call Sub_Dept(fc_Class.H_DeptID)

                End If


            Else


                Call No_Edit_TextBox()
                BAddRows.Enabled = False
                BMold.Enabled = False
                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
                Me.Text = "CIRCULATION FORM "
                T_CRType.Enabled = True
                Grid4.Enabled = True
                GroupBox2.Enabled = False
                C_Term.Enabled = False
                T_RequirementDate.EditValue = Date.Now
                Call Sub_Dept(gh_Common.GroupID)

            End If


            Call Row_Other_Dept_Active()
            Call FillComboOtherDept()
            Call FillComboCurrency()
            Call InputBeginState(Me)

            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()

            If T_CRType.EditValue = "Mold" Then
                With GridView1
                    .Columns("Model").Visible = True
                    .Columns("Sales Type").Visible = True
                    .Columns("Remark").Visible = True
                End With
            Else
                With GridView1
                    .Columns("Model").Visible = False
                    .Columns("Sales Type").Visible = False
                    .Columns("Remark").Visible = False
                End With

            End If



        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub No_Edit_Grid()

        GridView1.OptionsBehavior.Editable = False
        GridView3.OptionsBehavior.Editable = False
        GridView4.OptionsBehavior.Editable = False
        'GridView5.OptionsBehavior.Editable = False

    End Sub
    Private Sub Edit_Grid()

        GridView1.OptionsBehavior.Editable = True
        GridView3.OptionsBehavior.Editable = True
        GridView4.OptionsBehavior.Editable = True
        'GridView5.OptionsBehavior.Editable = True

    End Sub

    Private Sub No_Edit_TextBox()

        T_CRNo.Enabled = False
        T_RequirementDate.Enabled = False
        GroupBox1.Enabled = False
        T_CRType.Enabled = False
        T_Parent.Enabled = False
        T_ParentAmount.Enabled = False
        T_Reason.Enabled = False
        T_Dept.Enabled = False
        GroupBox1.Enabled = False
        'Grid1.Enabled = False
        GroupBox2.Enabled = False
        C_Term.Enabled = False
        T_NameItem.Enabled = False
        T_Spesification.Enabled = False
        GroupBox3.Enabled = False
        TCustomer.Enabled = False
        TBudget.Enabled = False

    End Sub

    Private Sub Edit_TextBox()

        T_CRNo.Enabled = True
        T_RequirementDate.Enabled = True
        GroupBox1.Enabled = True
        T_CRType.Enabled = True
        T_Parent.Enabled = True
        T_ParentAmount.Enabled = True
        T_Reason.Enabled = True
        T_Dept.Enabled = True
        GroupBox1.Enabled = True
        'Grid1.Enabled = False
        GroupBox2.Enabled = True
        C_Term.Enabled = True

    End Sub

    Private Sub LoadTxtBox()

        Try
            If fs_Code <> "" Then

                With fc_Class

                    T_CRNo.EditValue = .H_CirculationNo
                    T_RequirementDate.EditValue = .H_RequirementDate
                    T_CRType.EditValue = .H_CR_Type
                    T_Reason.Text = .H_Reason
                    T_Parent.EditValue = .H_Parent_Circulation
                    T_ParentAmount.EditValue = .H_Parent_Circulation_Amount
                    T_DS.EditValue = .H_Dies_Sales_Type
                    T_CustomerName.EditValue = .H_Dies_Customer_Name
                    T_ModelName.EditValue = .H_Dies_Model
                    T_NameItem.EditValue = .H_NameItem
                    T_Spesification.EditValue = .H_Spesification
                    TCustomer.EditValue = .H_Customer
                    TBudget.EditValue = .H_Budget_text


                    If .H_PO = True Then
                        RBPO.Checked = True
                        RBNonPO.Checked = False
                    ElseIf .H_PO = False Then
                        RBPO.Checked = False
                        RBNonPO.Checked = True
                    End If

                    If .H_ChargedOf = 1 Then
                        T_Charged.EditValue = "YES"
                    Else
                        T_Charged.EditValue = "NO"
                    End If


                    T_Remark.EditValue = .H_Dies_Remark

                    If .H_Budget = 1 Then
                        RB_Budget.Checked = True
                        RB_NonBudget.Checked = False
                    Else
                        RB_Budget.Checked = False
                        RB_NonBudget.Checked = True
                    End If

                    T_PO.Text = .H_No_PO
                    T_PR.Text = .H_PR

                End With
            Else
                T_RequirementDate.EditValue = DateTime.Now
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub LoadGridBarang(CirculationNo As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                'Dim dt As New DataTable
                DtGridBarang = New DataTable
                DtGridBarang = fc_Class.Get_Detail_DescriptionOfCost(CirculationNo)
                Grid.DataSource = DtGridBarang
                Cursor.Current = Cursors.Default
                Call TotalSumary()
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Sub LoadGridInstallment(CirculationNo As String)
        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                Dim dt As New DataTable

                dt = fc_Class.Get_Detail_Installment(CirculationNo)
                Grid4.DataSource = dt
                Cursor.Current = Cursors.Default
                Call Term_Properties()
                Call Event_Term()
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadGrid_OtherDept(CirculationNo As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                Dim dt As New DataTable
                'Dt_OtherDept = New DataTable
                dt = fc_Class.Get_Detail_OtherDept(CirculationNo)
                Grid5.DataSource = dt
                Cursor.Current = Cursors.Default
                'Call TotalSumary()
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub FillComboOtherDept()
        Try
            If fs_Code <> "" Then

                Dim A As ArrayList = New ArrayList
                Dim dt1 As New DataTable
                dt1 = fc_Class.Get_Other_DeptID_Filter(fs_Code)

                For i As Integer = 0 To dt1.Rows.Count - 1
                    A.Add(dt1.Rows(i).Item("DeptID"))
                Next

                Dim s As String = ""
                Dim dt As New DataTable
                dt = fc_Class.Get_Other_DeptID
                T_Dept.Properties.DataSource = Nothing
                T_Dept.Properties.DataSource = dt
                T_Dept.Properties.ValueMember = "Value"
                T_Dept.Properties.DisplayMember = "Value"

                For b As Integer = 0 To A.Count - 1
                    s = s & A.Item(b) & ","
                Next
                T_Dept.SetEditValue(s)

                If T_CRType.EditValue = "Mold" Then

                    T_Dept.Properties.Items("1MKT").Enabled = False
                    T_Dept.Properties.Items("1FAC").Enabled = False
                Else
                    T_Dept.Properties.Items("1FAC").Enabled = False
                End If

                'T_Dept.SetEditValue("1FAC")
                'T_Dept.Properties.Items("1FAC").Enabled = False
                'If T_CRType.EditValue = "Mold" Then
                '    T_Dept.SetEditValue("1MKT,1FAC")
                '    T_Dept.Properties.Items("1MKT").Enabled = False

                'End If
            Else

                Dim dt As New DataTable
                dt = fc_Class.Get_Other_DeptID
                T_Dept.Properties.DataSource = Nothing
                T_Dept.Properties.DataSource = dt
                T_Dept.Properties.ValueMember = "Value"
                T_Dept.Properties.DisplayMember = "Value"
                T_Dept.SetEditValue("1FAC")
                T_Dept.Properties.Items("1FAC").Enabled = False

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            Dim dt As New DataTable
            dt = fc_Class.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Departemen Tidak Ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                DeptSub = Trim((dt.Rows(0).Item("Sub")))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub FillRate(Tahun As String, Bulan As String, Cur As String)
        Try

            Dim dt As New DataTable
            dt = fc_Class.Rate(Tahun, Bulan, Cur)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Rate Tidak ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                ' T_Rate.EditValue = "1"
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Curr", "IDR")
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", "1")
                Exit Sub
            Else
                Dim rate As Double = (dt.Rows(0).Item("Rate"))

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", rate)

                'T_Rate.EditValue = rate.ToString("#,##0.00")
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub T_Account_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_CRType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_CRType.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub C_Currency_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_RequirementDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_RequirementDate.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CreateTableBarang()

        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(18) {New DataColumn("Name Of Goods", GetType(String)),
                                                            New DataColumn("Spesification", GetType(String)),
                                                            New DataColumn("Model", GetType(String)),
                                                            New DataColumn("Sales Type", GetType(String)),
                                                            New DataColumn("Remark", GetType(String)),
                                                            New DataColumn("Qty", GetType(Double)),
                                                            New DataColumn("Price", GetType(Double)),
                                                            New DataColumn("Total Amount Currency", GetType(Double)),
                                                            New DataColumn("Curr", GetType(String)),
                                                            New DataColumn("Category", GetType(String)),
                                                            New DataColumn("Balance", GetType(Double)),
                                                            New DataColumn("Rate", GetType(Double)),
                                                            New DataColumn("Remaining Budget", GetType(Double)),
                                                            New DataColumn("Total IDR", GetType(Double)),
                                                            New DataColumn("Check", GetType(String)),
                                                            New DataColumn("Note", GetType(String)),
                                                            New DataColumn("Id", GetType(Integer)),
                                                            New DataColumn("Account Name", GetType(String)),
                                                            New DataColumn("Account", GetType(String))})



        Grid.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False




        DtTotal = New DataTable
        DtTotal.Columns.AddRange(New DataColumn(1) {New DataColumn("Curr", GetType(String)),
                                                           New DataColumn("Total", GetType(Double))})

        Grid3.DataSource = DtTotal
        GridView3.OptionsView.ShowAutoFilterRow = False

        DtTerm = New DataTable
        DtTerm.Columns.AddRange(New DataColumn(4) {New DataColumn("Term", GetType(String)),
                                                           New DataColumn("Date", GetType(Date)),
                                                           New DataColumn("%", GetType(Double)),
                                                           New DataColumn("Curr", GetType(String)),
                                                           New DataColumn("Value", GetType(Double))})

        Dt_OtherDept = New DataTable
        Dt_OtherDept.Columns.AddRange(New DataColumn(3) {New DataColumn("Dept", GetType(String)),
                                                           New DataColumn("Date", GetType(Date)),
                                                           New DataColumn("Name", GetType(String)),
                                                           New DataColumn("Opinion", GetType(String))})

    End Sub

    Private Sub Frm_CR_UserCreateDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim itemValues As String() = New String() {"Circle", "Rectangle",
        '    "Ellipse", "Triangle", "Square"}
        'For Each value As String In itemValues
        '    T_Dept.Properties.Items.Add(value, CheckState.Unchecked, True)
        'Next value

        With GridView1
            .Columns("Model").Visible = False
            .Columns("Sales Type").Visible = False
            .Columns("Remark").Visible = False
        End With

        GService = New GlobalService
        _level = GService.GetLevel_str("CIRCULATION")
        DeptGroup = GService.GetDept_Group(RTrim(LTrim((gh_Common.GroupID))))

        Dim dtRoot As DataTable
        dtRoot = fc_Class_ApproveDeptHead.Get_Root_Approve_ByDept(gh_Common.GroupID)

        If dtRoot.Rows.Count > 0 Then
            Division = dtRoot.Rows(0).Item("div_Id")
            Director = dtRoot.Rows(0).Item("director_Id")
        End If

        pDate2 = Date.Now
        pDate1 = pDate2.AddMonths(-2)

        Call CreateTableBarang()
        Call InitialSetForm()

        If gh_Common.GroupID = "3NPD" Or gh_Common.GroupID = "1FAC" Then
            T_CRType.Properties.Items.Add("Fixed Aset")
            T_CRType.Properties.Items.Add("Expense")
            T_CRType.Properties.Items.Add("Mold")
            T_CRType.Properties.Items.Add("Disposal")
        Else
            T_CRType.Properties.Items.Add("Fixed Aset")
            T_CRType.Properties.Items.Add("Expense")
            T_CRType.Properties.Items.Add("Disposal")
        End If


    End Sub

    Private Sub FillComboCurrency()
        Try
            Dim dt As New DataTable
            dt = fc_Class.getWC

            For a As Integer = 0 To dt.Rows.Count - 1
                CurrRepository.Items.Add(dt.Rows(a).Item(0))
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub C_Total__EditValueChanged(sender As Object, e As EventArgs)

        Dim CurrentCR As Double = "0"

        Dim Total1 As Double = Convert.ToDouble((GridView1.Columns("Total Amount Currency").SummaryItem.SummaryValue))

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()


        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub C_Term_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_RemainingBudget_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_CurrentCirculation_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_Balance_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_Rate_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Get_Total_Sisa_Budget_Dept(Dept_Sub As String, NoAccount As String, Tahun As String, Bulan As String)

        Try
            Dim dt As New DataTable
            dt = fc_Class.Get_Total_Sisa_Budget_Dept(Dept_Sub, NoAccount, Tahun, Bulan)
            If dt.Rows.Count <= 0 Then
                'MessageBox.Show("Data Tidak ditemukan",
                '               "Warning",
                '               MessageBoxButtons.OK,
                '               MessageBoxIcon.Exclamation,
                '               MessageBoxDefaultButton.Button1)
                TotalBudget = 0
            Else
                SisaBudget = Convert.ToDouble(dt.Rows(0).Item("SisaBudget"))
                'Dim Buget As Double = Convert.ToDouble(dt.Rows(0).Item("Total"))
                'TextEdit_Buget_TSC.EditValue = Buget.ToString("#,##0.00")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Get_Total_CR_Dept(Dept As String, Site As String, NoAccount As String, Tahun As String)

        Try
            Dim dt As New DataTable
            dt = fc_Class.Get_Total_CR_Dept(Dept, Site, NoAccount, Tahun)
            If dt.Rows.Count <= 0 Then
                'MessageBox.Show("Data Tidak ditemukan",
                '               "Warning",
                '               MessageBoxButtons.OK,
                '               MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                TotalCR = 0
                'TextEdit_CR_dept.EditValue = TotalCR.ToString("#,##0.00")
            Else
                TotalCR = Convert.ToDouble(dt.Rows(0).Item("Total"))
                Dim Buget As Double = Convert.ToDouble(dt.Rows(0).Item("Total"))
                'TextEdit_CR_dept.EditValue = Buget.ToString("#,##0.00")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Please Fill Description Of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub

            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Please Check Description of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


            End If

            If isUpdate = False Then
                ''''''''''''''''''''''''' Insert''''''''''''''''''''''''''
                fc_Class.GetCirculationNoAuto(DeptSub)
                Dim BudgetType As Integer
                If RB_Budget.Checked = True Then
                    BudgetType = 1
                ElseIf RB_NonBudget.Checked = True Then
                    BudgetType = 0
                End If

                If RBPO.Checked = True Then
                    fc_Class.H_PO = True
                ElseIf RBNonPO.Checked = True Then
                    fc_Class.H_PO = False
                End If

                NoSirkulasi = fc_Class.H_CirculationNo
                With fc_Class
                    .H_Div_id = Division
                    .H_Director_id = Director
                    .H_CR_Type = T_CRType.EditValue
                    .H_RequirementDate = Format(T_RequirementDate.EditValue, "yyyy-MM-dd")
                    .H_Budget = BudgetType
                    .H_Reason = T_Reason.Text
                    .H_Customer = IIf(TCustomer.EditValue Is Nothing, "", TCustomer.EditValue)
                    .H_Spesification = T_Spesification.EditValue
                    .H_NameItem = T_NameItem.EditValue
                    .H_Status = "Create"
                    .H_Parent_Circulation = IIf(IsNothing(T_Parent.EditValue), "", T_Parent.EditValue)
                    .H_Parent_Circulation_Amount = CDec(T_ParentAmount.EditValue)
                    .H_InvoiceNo = ""
                    .H_InvoiceStatus = 0
                    .H_Dies = 1
                    .TA_Username = gh_Common.Username
                    .TA_MenuCode = "CIRCULATION"
                    .TA_DeptID = gh_Common.GroupID
                    .TA_NoTransaksi = fs_Code
                    .TA_LevelApprove = 0
                    .TA_StatusApprove = "Create"
                    .TA_ApproveBy = gh_Common.Username
                    .TA_ApproveDAte = Date.Now
                    .TA_IsActive = 1
                    .H_Current_Level = 0
                    .H_Budget_text = IIf(TBudget.EditValue Is Nothing, 0, TBudget.EditValue)

                End With

                'Insert To ObjDetailMaterial
                fc_Class.Collection_Description_Of_Cost.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Description_Of_Cost = New ClsCR_Description_of_Cost
                    With Description_Of_Cost

                        Dim A, B, C As Boolean

                        A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                        B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                        C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                        If A = True Then
                            .D_Check = 1
                        ElseIf B = True Then
                            .D_Check = 2
                        ElseIf C = True Then
                            .D_Check = 3
                        Else
                            .D_Check = 0
                        End If

                        .D_CirculationNo = NoSirkulasi
                        .D_Name_Of_Goods = Convert.ToString(GridView1.GetRowCellValue(i, "Name Of Goods"))
                        .D_Spesification = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))

                        .D_Model = IIf(GridView1.GetRowCellValue(i, "Model") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Model")))
                        .D_SalesType = IIf(GridView1.GetRowCellValue(i, "Sales Type") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Sales Type")))
                        .D_Remark = IIf(GridView1.GetRowCellValue(i, "Remark") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Remark")))

                        .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Price = Convert.ToDouble(GridView1.GetRowCellValue(i, "Price"))
                        .D_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total Amount Currency"))
                        .D_Amount_IDR = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total IDR"))
                        .D_PR_No = Convert.ToString(GridView1.GetRowCellValue(i, "PR No"))
                        .D_Currency = Convert.ToString(GridView1.GetRowCellValue(i, "Curr"))
                        .D_Rate = Convert.ToString(GridView1.GetRowCellValue(i, "Rate"))
                        .D_RemainingBudget = Convert.ToString(GridView1.GetRowCellValue(i, "Remaining Budget"))
                        .D_Account = Convert.ToString(GridView1.GetRowCellValue(i, "Account"))
                        .D_Category = Convert.ToString(GridView1.GetRowCellValue(i, "Category"))
                        .D_Note = Convert.ToString(GridView1.GetRowCellValue(i, "Note"))

                    End With
                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                Next

                fc_Class.Collection_Other_Dept.Clear()

                Dim checked As New List(Of String)
                Dim checkedString As String = CType(T_Dept.Properties.GetCheckedItems(), String)
                If (checkedString.Length > 0) Then
                    checked.AddRange(checkedString.Split(New Char() {","c}))
                    For Each item In checked

                        Other_Dept = New ClsCR_Other_Dept
                        With Other_Dept

                            .D_CirculationNo = NoSirkulasi
                            .D_Dept = Trim(item).ToString
                            .D_UserName = "UserName"
                            .D_Name = "test"
                            .D_Approve = False


                        End With
                        fc_Class.Collection_Other_Dept.Add(Other_Dept)
                    Next
                End If

#Region "Term Data Table Payment"
                Try
                    DtTerm.Clear()
                    GridView4.FocusedRowHandle = True
                    For a As Integer = 0 To GridView4.RowCount - 1
                        For x As Integer = 0 To GridView3.RowCount - 1
                            Dim NamaCurr As String = Convert.ToString(GridView4.GetRowCellValue(x, "Curr"))
                            Dim dr As DataRow = DtTerm.NewRow
                            dr("Term") = GridView4.GetRowCellValue(a, "Term")
                            dr("Date") = GridView4.GetRowCellValue(a, "Date")
                            dr("%") = GridView4.GetRowCellValue(a, "%")
                            dr("Curr") = GridView3.GetRowCellValue(x, "Curr")
                            dr("Value") = GridView4.GetRowCellValue(a, GridView3.GetRowCellValue(x, "Curr"))
                            DtTerm.Rows.Add(dr)
                        Next
                    Next

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try
#End Region

#Region "Installment"
                fc_Class.Collection_Installment.Clear()
                For j As Integer = 0 To DtTerm.Rows.Count - 1

                    Installment = New ClsCR_Installment
                    With Installment

                        .D_CirculationNo = NoSirkulasi
                        Dim a As Object = DtTerm.Rows(j).Item("Date")
                        If DtTerm.Rows(j).Item("Date") Is DBNull.Value Then
                            .D_Date = Nothing
                            'ElseIf DtTerm.Rows(j).Item("Date") = "" Then
                            '    .D_Date = Nothing
                        Else
                            .D_Date = DtTerm.Rows(j).Item("Date")
                        End If
                        '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))                        '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))
                        'D_Date = IIf((DtTerm.Rows(j).Item("Date")) Is DBNull.Value, Nothing, Convert.ToDateTime(DtTerm.Rows(j).Item("Date")))
                        .D_Percent = Convert.ToString(DtTerm.Rows(j).Item("%"))
                        .D_Term = Convert.ToString(DtTerm.Rows(j).Item("Term"))
                        .D_Curr = Convert.ToString(DtTerm.Rows(j).Item("Curr"))
                        .D_Value = Convert.ToDouble(DtTerm.Rows(j).Item("Value"))

                    End With
                    fc_Class.Collection_Installment.Add(Installment)

                Next

                fc_Class.Collection_Approve.Clear()
                dtApprove = New DataTable
                Dim Total As Double = Convert.ToDouble(GridView1.Columns("Total IDR").SummaryText)

                'If Total > 10000001 And Total <= 50000000 Then
                '    dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 3)
                'ElseIf Total >= 50000001 And Total <= 100000000 Then
                '    dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 5)
                'ElseIf Total >= 100000001 Then
                '    dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 5)
                'End If

                If gh_Common.GroupID = "1BOD" Then

                    If Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 4)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If


                ElseIf gh_Common.GroupID = "1PUR" Or gh_Common.GroupID = "1MKT" Or gh_Common.GroupID = "3NPD" Then
                    If Total > 10000001 And Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 2)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If
                Else
                    If Total > 10000001 And Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 3)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If
                End If


                For A As Integer = 0 To dtApprove.Rows.Count - 1

                    Approvel = New ClsCR_Approve
                    With Approvel

                        .D_Circulation = NoSirkulasi
                        .D_No = Convert.ToInt16(dtApprove.Rows(A).Item("No"))
                        .D_ApproveBy = IIf(dtApprove.Rows(A).Item("ApproveBy") Is DBNull.Value, "", dtApprove.Rows(A).Item("ApproveBy"))
                        .D_ApproveName = IIf(dtApprove.Rows(A).Item("ApproveName") Is DBNull.Value, "", dtApprove.Rows(A).Item("ApproveName"))

                    End With
                    fc_Class.Collection_Approve.Add(Approvel)

                Next

#End Region

                fc_Class.Insert(NoSirkulasi)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Model.Get_CRRequest(gh_Common.GroupID, pDate1, pDate2)
                IsClosed = True
                Timer1.Enabled = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''' End Insert
            Else
                '''''''''''''''''''''''''''''''''''''''''''''''''''''' Update

                Dim BudgetType As Integer
                If RB_Budget.Checked = True Then
                    BudgetType = 1
                ElseIf RB_NonBudget.Checked = True Then
                    BudgetType = 0
                End If

                If RBPO.Checked = True Then
                    fc_Class.H_PO = True
                ElseIf RBNonPO.Checked = True Then
                    fc_Class.H_PO = False
                End If


                With fc_Class
                    .H_CirculationNo = NoSirkulasi
                    .H_Budget = BudgetType
                    .H_CR_Type = T_CRType.EditValue
                    .H_Reason = T_Reason.Text
                    .H_Customer = TCustomer.EditValue
                    .H_RequirementDate = Format(T_RequirementDate.EditValue, "yyyy-MM-dd")
                    .H_Status = "Submit"
                    .H_Parent_Circulation = IIf(IsNothing(T_Parent.EditValue), "", T_Parent.EditValue)
                    .H_Parent_Circulation_Amount = CDec(T_ParentAmount.EditValue)
                    .H_Dies_Sales_Type = T_DS.EditValue
                    .H_Dies_Customer_Name = T_CustomerName.EditValue
                    .H_Dies_Model = T_ModelName.EditValue
                    .H_NameItem = T_NameItem.EditValue
                    .H_Spesification = T_Spesification.EditValue
                    If T_Charged.EditValue = "YES" Then
                        .H_ChargedOf = 1
                    Else
                        .H_ChargedOf = 0
                    End If
                    .H_Dies_Remark = T_Remark.EditValue
                    .H_InvoiceNo = ""
                    .H_InvoiceStatus = 0
                    .H_Dies = 1
                    .H_Budget_text = IIf(TBudget.EditValue Is Nothing, 0, TBudget.EditValue)

                End With


                'Insert To ObjDetailMaterial
                fc_Class.Collection_Description_Of_Cost.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Description_Of_Cost = New ClsCR_Description_of_Cost
                    With Description_Of_Cost

                        .D_CirculationNo = NoSirkulasi
                        .D_Name_Of_Goods = Convert.ToString(GridView1.GetRowCellValue(i, "Name Of Goods"))
                        .D_Spesification = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))

                        .D_Model = IIf(GridView1.GetRowCellValue(i, "Model") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Model")))
                        .D_SalesType = IIf(GridView1.GetRowCellValue(i, "Sales Type") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Sales Type")))
                        .D_Remark = IIf(GridView1.GetRowCellValue(i, "Remark") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Remark")))

                        .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Price = Convert.ToDouble(GridView1.GetRowCellValue(i, "Price"))
                        .D_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total Amount Currency"))
                        .D_Amount_IDR = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total IDR"))
                        .D_PR_No = Convert.ToString(GridView1.GetRowCellValue(i, "PR No"))
                        .D_Currency = Convert.ToString(GridView1.GetRowCellValue(i, "Curr"))
                        .D_Rate = Convert.ToString(GridView1.GetRowCellValue(i, "Rate"))
                        .D_RemainingBudget = Convert.ToString(GridView1.GetRowCellValue(i, "Remaining Budget"))
                        .D_Account = Convert.ToString(GridView1.GetRowCellValue(i, "Account"))
                        .D_Category = Convert.ToString(GridView1.GetRowCellValue(i, "Category"))
                        '.D_Check = Convert.ToString(GridView1.GetRowCellValue(i, "Check"))
                        .D_Note = Convert.ToString(GridView1.GetRowCellValue(i, "Note"))

                    End With
                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                Next

                fc_Class.Collection_Other_Dept.Clear()

                Dim checked As New List(Of String)
                Dim checkedString As String = CType(T_Dept.Properties.GetCheckedItems(), String)
                If (checkedString.Length > 0) Then
                    checked.AddRange(checkedString.Split(New Char() {","c}))
                    For Each item In checked

                        Other_Dept = New ClsCR_Other_Dept
                        With Other_Dept

                            .D_CirculationNo = NoSirkulasi
                            .D_Dept = Trim(item).ToString
                            .D_UserName = ""
                            .D_Name = ""
                        End With
                        fc_Class.Collection_Other_Dept.Add(Other_Dept)

                    Next
                End If


#Region "Term Data Table Payment"
                Try
                    DtTerm.Clear()
                    GridView4.FocusedRowHandle = True
                    For a As Integer = 0 To GridView4.RowCount - 1
                        For x As Integer = 0 To GridView3.RowCount - 1
                            Dim NamaCurr As String = Convert.ToString(GridView4.GetRowCellValue(x, "Curr"))
                            Dim dr As DataRow = DtTerm.NewRow
                            dr("Term") = GridView4.GetRowCellValue(a, "Term")
                            dr("Date") = GridView4.GetRowCellValue(a, "Date")
                            dr("%") = GridView4.GetRowCellValue(a, "%")
                            dr("Curr") = GridView3.GetRowCellValue(x, "Curr")
                            dr("Value") = GridView4.GetRowCellValue(a, GridView3.GetRowCellValue(x, "Curr"))
                            DtTerm.Rows.Add(dr)
                        Next
                    Next

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try
#End Region

#Region "Installment"
                fc_Class.Collection_Installment.Clear()
                For j As Integer = 0 To DtTerm.Rows.Count - 1

                    Installment = New ClsCR_Installment
                    With Installment

                        .D_CirculationNo = NoSirkulasi
                        Dim a As Object = DtTerm.Rows(j).Item("Date")
                        If DtTerm.Rows(j).Item("Date") Is DBNull.Value Then
                            .D_Date = Nothing
                            'ElseIf DtTerm.Rows(j).Item("Date") = "" Then
                            '    .D_Date = Nothing
                        Else
                            .D_Date = DtTerm.Rows(j).Item("Date")
                        End If
                        '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))                        '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))
                        'D_Date = IIf((DtTerm.Rows(j).Item("Date")) Is DBNull.Value, Nothing, Convert.ToDateTime(DtTerm.Rows(j).Item("Date")))
                        .D_Percent = Convert.ToString(DtTerm.Rows(j).Item("%"))
                        .D_Term = Convert.ToString(DtTerm.Rows(j).Item("Term"))
                        .D_Curr = Convert.ToString(DtTerm.Rows(j).Item("Curr"))
                        .D_Value = Convert.ToDouble(DtTerm.Rows(j).Item("Value"))

                    End With
                    fc_Class.Collection_Installment.Add(Installment)

                Next

                fc_Class.Collection_Approve.Clear()
                dtApprove = New DataTable
                Dim Total As Double = Convert.ToDouble(GridView1.Columns("Total IDR").SummaryText)

                'If gh_Common.GroupID = "1BOD" Then

                '    If Total <= 50000000 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 4)
                '    ElseIf Total >= 50000001 And Total <= 100000000 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 5)
                '    ElseIf Total >= 100000001 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 5)
                '    End If

                'Else
                '    If Total > 10000001 And Total <= 50000000 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 3)
                '    ElseIf Total >= 50000001 And Total <= 100000000 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 5)
                '    ElseIf Total >= 100000001 Then
                '        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 5)
                '    End If
                'End If


                If gh_Common.GroupID = "1BOD" Then

                    If Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 4)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If


                ElseIf gh_Common.GroupID = "1PUR" Or gh_Common.GroupID = "1MKT" Or gh_Common.GroupID = "3NPD" Then
                    If Total > 10000001 And Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 2)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If
                Else
                    If Total > 10000001 And Total <= 50000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 3, 3)
                    ElseIf Total >= 50000001 And Total <= 100000000 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 2, 4)
                    ElseIf Total >= 100000001 Then
                        dtApprove = fc_Class.Get_ApproveBOD(gh_Common.GroupID, 1, 4)
                    End If
                End If



                For A As Integer = 0 To dtApprove.Rows.Count - 1

                    Approvel = New ClsCR_Approve
                    With Approvel

                        .D_Circulation = NoSirkulasi
                        .D_No = Convert.ToInt16(dtApprove.Rows(A).Item("No"))
                        .D_ApproveBy = IIf(dtApprove.Rows(A).Item("ApproveBy") Is DBNull.Value, "", dtApprove.Rows(A).Item("ApproveBy"))
                        .D_ApproveName = IIf(dtApprove.Rows(A).Item("ApproveName") Is DBNull.Value, "", dtApprove.Rows(A).Item("ApproveName"))

                    End With
                    fc_Class.Collection_Approve.Add(Approvel)

                Next
#End Region



                fc_Class.Update(NoSirkulasi)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Model.Get_CRRequest(gh_Common.GroupID, pDate1, pDate2)
                IsClosed = True
                Timer1.Enabled = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If RB_Budget.Checked = False And RB_NonBudget.Checked = False Then
                MessageBox.Show("Please Choose a Budget Type", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf RBPO.Checked = False And RBNonPO.Checked = False Then
                MessageBox.Show("Please Choose a PO Type", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            ElseIf T_Dept.EditValue = "" Then
                MessageBox.Show("Please Choose Other Dept", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            ElseIf T_CRType.EditValue = "" Then
                MessageBox.Show("Please fill type of Circulation", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            ElseIf T_Reason.Text = "" Then
                MessageBox.Show("Please fill Reason Of Description", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_RequirementDate.Text = "" Then
                MessageBox.Show("Please Choose RequirementDate", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf RB_Budget.Checked = True Then
                If TBudget.Text = "" Or TBudget.Text = "0" Then
                    MessageBox.Show("Please fill Budget", "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1)
                Else
                    lb_Validated = True
                End If

            ElseIf T_CRType.Text = "Mold" Then

                If TCustomer.EditValue = "" Then
                    MessageBox.Show("Please Choose Customer", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)

                    'ElseIf T_DS.EditValue = "" Then
                    '    MessageBox.Show("Please Choose Sales Type", "Warning",
                    '            MessageBoxButtons.OK,
                    '            MessageBoxIcon.Exclamation,
                    '            MessageBoxDefaultButton.Button1)

                    'ElseIf T_CustomerName.EditValue = "" Then
                    '    MessageBox.Show("Please fill Customer Name", "Warning",
                    '            MessageBoxButtons.OK,
                    '            MessageBoxIcon.Exclamation,
                    '            MessageBoxDefaultButton.Button1)
                    'ElseIf T_ModelName.EditValue = "" Then
                    '    MessageBox.Show("Please fill Model Name", "Warning",
                    '            MessageBoxButtons.OK,
                    '            MessageBoxIcon.Exclamation,
                    '            MessageBoxDefaultButton.Button1)
                    'ElseIf T_Charged.EditValue = "" Then
                    '    MessageBox.Show("Please Choose Charge Of Customer", "Warning",
                    '            MessageBoxButtons.OK,
                    '            MessageBoxIcon.Exclamation,
                    '            MessageBoxDefaultButton.Button1)
                Else
                    lb_Validated = True
                End If

            Else

                lb_Validated = True
            End If

            If lb_Validated Then
                With fc_Class
                    If isUpdate = False Then
                        .ValidateInsert()
                    End If
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Private Sub T_Parent_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_Parent.ButtonClick
        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

            dtSearch = fc_Class.GetParent_Circulation(Dept, Tahun, Bulan)
            ls_OldKode = T_Parent.EditValue
            ls_Judul = "Parent Cisrculation"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As Double = 0

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = Convert.ToDouble(lF_SearchData.Values.Item(1).ToString.Trim)
                T_Parent.EditValue = Value1
                T_ParentAmount.EditValue = Value2.ToString("#,##0.00")
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_Parent_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_Parent.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_ParentAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ParentAmount.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub
    Private Sub T_PRNumber_ButtonClick(sender As Object, e As ButtonPressedEventArgs)

        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As Double = Convert.ToDouble(Param.ToString("MM"))

            dtSearch = fc_Class.GetPR(DeptSub, Tahun, Bulan)
            'ls_OldKode = T_Account.Text
            ls_Judul = "Budget No"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Sub CallForm(Optional ByVal Model As String = "",
                        Optional ByVal Customer As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If CForm = 1 Then

            Model = T_ModelName.Text
            FGetMold = New Frm_CR_Get_Mold(Model, DtGridBarang, Grid4, BG)
            FGetMold.StartPosition = FormStartPosition.CenterScreen
            FGetMold.MaximizeBox = False
            FGetMold.ShowDialog()
            'T_ModelName.Text = Model
            T_ModelName.Text = FGetMold.Values_Model
            T_CustomerName.Text = FGetMold.Values_Customer

        ElseIf CForm = 5 Then
            If fc_Class.H_PO = True Then
                If fc_Class.H_No_PO <> "" Then
                    FGetBeritaAcara = New Frm_CR_BeritaAcara_Input(T_CRNo.EditValue, "", Active_Form)
                    FGetBeritaAcara.StartPosition = FormStartPosition.CenterScreen
                    FGetBeritaAcara.MaximizeBox = False
                    FGetBeritaAcara.ShowDialog()
                Else
                    MessageBox.Show("Pleases Check PO Number", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1)
                End If
            Else
                FGetBeritaAcara = New Frm_CR_BeritaAcara_Input(T_CRNo.EditValue, "", Active_Form)
                    FGetBeritaAcara.StartPosition = FormStartPosition.CenterScreen
                    FGetBeritaAcara.MaximizeBox = False
                    FGetBeritaAcara.ShowDialog()
                End If


        End If



    End Sub

    Private Function cdoSendPassword() As Object
        Throw New NotImplementedException()
    End Function

    Private Function cdoSMTPServer() As Object
        Throw New NotImplementedException()
    End Function

    Private Function cdoSendUserName() As Object
        Throw New NotImplementedException()
    End Function

    Private Function cdoSMTPServerPort() As Object
        Throw New NotImplementedException()
    End Function

    Private Function cdoSendUsingPort() As Object
        Throw New NotImplementedException()
    End Function

    Private Function cdoSendUsingMethod() As Object
        Throw New NotImplementedException()
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BAccount_Click(sender As Object, e As EventArgs) Handles BAccount.Click

        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dept = gh_Common.GroupID
            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

            dtSearch = fc_Class.GetBudget(DeptSub, Tahun, Bulan)
            'ls_OldKode = T_Account.Text
            ls_Judul = "Budget No"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                'Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                'Dim Value21 As Double = Convert.ToDouble(Value2)
                'T_Account.Text = Value1
                If Val(Value1) <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "N")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account Name", Value2)
                'T_RemainingBudget.EditValue = Value21.ToString("#,##0.00")
                Try
                    Dim ACC_Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
                    Dim Acc_Departemen As String = gh_Common.GroupID
                    Dim Acc_Site As String = gh_Common.Site
                    Dim Acc_NoAccount As String = Value1
                    Dim Acc_Tahun As String = Convert.ToString(ACC_Param.ToString("yyyy"))
                    Dim Acc_Bulan As String = Convert.ToString(ACC_Param.ToString("MM"))

                    Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)

                    Dim baseEdit = TryCast(sender, BaseEdit)
                    Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
                    gridView.PostEditor()
                    gridView.UpdateCurrentRow()

                    Dim dataSourceRowIndex As Integer = GridView1.FocusedRowHandle

                    If dataSourceRowIndex = 0 Then
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)
                    Else
                        Dim Sisa As Double = 0


                        Dim Pemakaian As Double = 0

                        For i As Integer = 0 To dataSourceRowIndex - 1
                            If Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns("Account"))) = Value1 Then
                                Pemakaian = Pemakaian + Convert.ToDouble(GridView1.GetRowCellValue(i, GridView1.Columns("Total IDR")))
                            End If
                        Next

                        Sisa = SisaBudget - Pemakaian
                        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", Sisa)


                    End If
                    CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Total IDR") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Total IDR"))
                    Balance = SisaBudget - CR
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)

                    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Category") <> "N" Then
                        If Balance <= 0 Then
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "O")
                        Else
                            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                        End If
                    End If

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub C_Qty_EditValueChanged(sender As Object, e As EventArgs) Handles C_Qty.EditValueChanged

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim Acc_NoAccount As String = ""

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Acc_NoAccount = GridView1.GetRowCellValue(rowHandle, "Account")
                End If
            Next rowHandle

            Call HitungTotal()
            Call TotalSumary()
            Call RefreshRemaining_Edit(Acc_NoAccount)

            'Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView3 = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView3.PostEditor()
            gridView3.UpdateCurrentRow()

            Dim gridView4 = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView4.PostEditor()
            gridView.UpdateCurrentRow()

            Call Termin(1)
            Call Termin_Default(1)




        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub
    Private Sub HitungTotal()
        Try

            Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty"))
            Dim Price As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            Dim Rate As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Rate"))
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Total Amount Currency", Qty * Price)
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Total IDR", Qty * Rate * Price)

            CR = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Total IDR") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Total IDR"))
            SisaBudget = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget"))

            Balance = SisaBudget - CR
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Balance", Balance)

            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Category") <> "N" Then
                If Balance <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "O")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If
            End If

            Dim Total As Double = Convert.ToDouble((GridView1.Columns("Total IDR").SummaryItem.SummaryValue))

            'For r As Integer = 1 To GridView2.RowCount
            '    GridView2.SelectRow(r)
            '    GridView2.DeleteSelectedRows()
            'Next

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TotalSumary()

        For o As Integer = 1 To GridView3.RowCount
            GridView3.SelectRow(0)
            GridView3.DeleteSelectedRows()
        Next
        GridView3.UpdateCurrentRow()
        GridView1.UpdateCurrentRow()

        For j As Integer = 0 To GridView1.RowCount - 1

            If j = 0 Then
                GridView3.AddNewRow()
                GridView3.OptionsNavigation.AutoFocusNewRow = True
                GridView3.FocusedColumn = GridView3.VisibleColumns(0)
                Dim cekCurr As String = GridView1.GetRowCellValue(j, "Curr")
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Curr", GridView1.GetRowCellValue(j, "Curr"))
                GridView3.UpdateCurrentRow()
            Else
                Dim Cek1 As Boolean
                Cek1 = New Boolean
                Cek1 = False
                Dim Cek2 As Boolean
                Cek2 = New Boolean
                Cek2 = False
                Dim c As String = GridView1.GetRowCellValue(j, "Curr")
                For k As Integer = 0 To GridView3.RowCount - 1
                    Dim C1 As String = Convert.ToString(GridView3.GetRowCellValue(k, "Curr"))
                    If C1 <> c Then
                        Cek2 = Cek2 Or False
                    Else
                        Cek2 = Cek2 Or True
                    End If
                Next
                Dim CekFinish As Boolean
                CekFinish = New Boolean
                CekFinish = False

                CekFinish = (Cek1 Or Cek2)

                If CekFinish = False Then
                    GridView3.AddNewRow()
                    GridView3.OptionsNavigation.AutoFocusNewRow = True
                    GridView3.FocusedColumn = GridView3.VisibleColumns(0)
                    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Curr", GridView1.GetRowCellValue(j, "Curr"))
                    GridView3.UpdateCurrentRow()
                End If

            End If
        Next

        GridView1.UpdateCurrentRow()
        GridView3.UpdateCurrentRow()

        For L As Integer = 0 To GridView3.RowCount - 1
            Dim Curr1 As String = Convert.ToString(GridView3.GetRowCellValue(L, "Curr"))
            Dim Tot As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Total") Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Total"))
            For M As Integer = 0 To GridView1.RowCount - 1

                Dim Curr2 As String = Convert.ToString(GridView1.GetRowCellValue(M, "Curr"))
                If Curr1 = Curr2 Then
                    Tot = Tot + Convert.ToDouble(GridView1.GetRowCellValue(M, "Total Amount Currency"))
                End If
            Next
            GridView3.SetRowCellValue(L, "Total", Tot)
        Next

    End Sub

    Private Sub C_Price_EditValueChanged(sender As Object, e As EventArgs) Handles C_Price.EditValueChanged

        Try
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim Acc_NoAccount As String = ""

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Acc_NoAccount = GridView1.GetRowCellValue(rowHandle, "Account")
                End If
            Next rowHandle

            Call HitungTotal()
            Call TotalSumary()
            Call RefreshRemaining_Edit(Acc_NoAccount)
            Call Termin(1)
            Call Termin_Default(1)


        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try




        'Try
        '    Dim baseEdit = TryCast(sender, BaseEdit)
        '    Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        '    gridView.PostEditor()
        '    gridView.UpdateCurrentRow()

        '    Call HitungTotal()
        '    Call TotalSumary()

        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try



    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown

        If Active_Form = 1 Or Active_Form = 5 Then
            If e.KeyData = Keys.Delete Then
                GridView1.DeleteRow(GridView1.FocusedRowHandle)
                GridView1.RefreshData()
                Call RefreshRemaining()
                Call TotalSumary()

            End If
        End If


    End Sub

    Private Sub RefreshRemaining()

        Dim Acc_NoAccount As String = ""

        Dim ACC_Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
        Dim Acc_Departemen As String = gh_Common.GroupID
        Dim Acc_Site As String = gh_Common.Site
        Dim Acc_Tahun As String = Convert.ToString(ACC_Param.ToString("yyyy"))
        Dim Acc_Bulan As String = Convert.ToString(ACC_Param.ToString("MM"))

        For i As Integer = 0 To GridView1.RowCount - 1
            If i = 0 Then
                Acc_NoAccount = GridView1.GetRowCellValue(i, GridView1.Columns("Account"))
                Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)
            Else
                'Dim dataSourceRowIndex As Integer = GridView1.FocusedRowHandle()
                Acc_NoAccount = GridView1.GetRowCellValue(i, GridView1.Columns("Account"))
                Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)

                Dim Sisa As Double = 0
                Dim Pemakaian As Double = 0

                For j As Integer = 0 To i - 1
                    If Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Account"))) = GridView1.GetRowCellValue(i, GridView1.Columns("Account")) Then
                        Pemakaian = Pemakaian + Convert.ToDouble(GridView1.GetRowCellValue(j, GridView1.Columns("Total IDR")))
                    End If
                Next

                Sisa = SisaBudget - Pemakaian
                GridView1.SetRowCellValue(i, "Remaining Budget", Sisa)

            End If
        Next

        'Call TotalSumary()
        'Call Termin()

    End Sub

    Private Sub RefreshRemaining_Edit(Account As String)

        Dim ACC_Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
        Dim Acc_Departemen As String = gh_Common.GroupID
        Dim Acc_Site As String = gh_Common.Site
        Dim Acc_Tahun As String = Convert.ToString(ACC_Param.ToString("yyyy"))
        Dim Acc_Bulan As String = Convert.ToString(ACC_Param.ToString("MM"))

        Dim Acc_NoAccount As String = Account
        Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)
        Dim Sisa_Budget As Double = SisaBudget
        Dim _Pemakaian As Double = 0



        For i As Integer = 0 To GridView1.RowCount - 1

            If GridView1.GetRowCellValue(i, GridView1.Columns("Account")) = Acc_NoAccount Then

                GridView1.SetRowCellValue(i, "Remaining Budget", Sisa_Budget)
                _Pemakaian = GridView1.GetRowCellValue(i, GridView1.Columns("Total IDR"))
                Sisa_Budget = Sisa_Budget - _Pemakaian

            End If

            'If i = 0 Then
            '    Acc_NoAccount = GridView1.GetRowCellValue(i, GridView1.Columns("Account"))
            '    Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)
            '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)
            'Else
            '    'Dim dataSourceRowIndex As Integer = GridView1.FocusedRowHandle()
            '    Acc_NoAccount = GridView1.GetRowCellValue(i, GridView1.Columns("Account"))
            '    Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)
            '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)

            '    Dim Sisa As Double = 0
            '    Dim Pemakaian As Double = 0

            '    For j As Integer = 0 To i - 1
            '        If Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Account"))) = GridView1.GetRowCellValue(i, GridView1.Columns("Account")) Then
            '            Pemakaian = Pemakaian + Convert.ToDouble(GridView1.GetRowCellValue(j, GridView1.Columns("Total IDR")))
            '        End If
            '    Next

            '    Sisa = SisaBudget - Pemakaian
            '    GridView1.SetRowCellValue(i, "Remaining Budget", Sisa)

            'End If
        Next

        'Call TotalSumary()
        'Call Termin()

    End Sub

    Private Sub BAddRows_Click(sender As Object, e As EventArgs) Handles BAddRows.Click

        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Qty", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", 1)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Price", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Curr", "IDR")
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Total Amount Currency", 0)

        'For r As Integer = 1 To GridView2.RowCount
        '    GridView2.SelectRow(r)
        '    GridView2.DeleteSelectedRows()
        'Next

    End Sub

    Private Sub BMold_Click(sender As Object, e As EventArgs) Handles BMold.Click

        If RB_Budget.Checked = True And RB_NonBudget.Checked = False Then
            BG = "B"
        ElseIf RB_Budget.Checked = False And RB_NonBudget.Checked = True Then
            BG = "N"
        Else
            MessageBox.Show("Please Select Budget",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If T_RequirementDate.Text = "" Then
            MessageBox.Show("Please Select Requirement Date",
                              "Warning",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation,
                              MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        CForm = 1

        CallForm()

    End Sub

    Private Sub Termin(baris As Integer)

        Dim MyNewRow As DataRow
        MyNewRow = DtTotal.NewRow
        Dim Curr As String = ""
        Dim Rows As Integer = Convert.ToInt32(baris)


        GridView4.Columns.Clear()
        DtGrid_PYM = New DataTable
        For a As Integer = 1 To DtGrid_PYM.Columns.Count
            DtGrid_PYM.Columns.RemoveAt(a)
        Next
        DtGrid_PYM.Columns.AddRange(New DataColumn(2) {New DataColumn("Term", GetType(String)),
                                                            New DataColumn("Date", GetType(Date)),
                                                            New DataColumn("%", GetType(Double))})

        For b As Integer = 0 To GridView3.RowCount - 1
            Dim Header As String = GridView3.GetRowCellValue(b, "Curr")
            DtGrid_PYM.Columns.Add(Header, Type.GetType("System.Double"))
        Next

        Grid4.DataSource = DtGrid_PYM
        GridView4.OptionsView.ShowAutoFilterRow = False

        Call Term_Properties()

        If Active_Form = 6 Then
            For i As Integer = 1 To Rows

                GridView4.AddNewRow()
                GridView4.OptionsNavigation.AutoFocusNewRow = True
                GridView4.FocusedColumn = GridView4.VisibleColumns(0)
                GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "Term", i.ToString)

            Next
        End If



        Call Event_Term()

    End Sub
    Private Sub Termin_Default(baris As Integer)
        Try
            DtGrid_PYM.Clear()
            Grid4.DataSource = DtGrid_PYM

            Dim Rows As Integer = Convert.ToInt32(baris)
            For i As Integer = 1 To Rows

                DtGrid_PYM.Rows.Add()
                DtGrid_PYM.Rows(0).Item("Term") = "1"
                DtGrid_PYM.Rows(0).Item("%") = "100"

            Next




            Dim CurrentCR As Double = 0
            Dim CurrentHeader As String = ""

            For A As Integer = 0 To GridView3.RowCount - 1
                CurrentHeader = Convert.ToString(GridView3.GetRowCellValue(A, "Curr"))
                CurrentCR = Convert.ToDouble(GridView3.GetRowCellValue(A, "Total"))

                Try
                    'Dim Percent As Double = IIf(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "%") Is DBNull.Value, 0, GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "%"))
                    Dim Percent As Double = IIf(DtGrid_PYM.Rows(0).Item("%") Is DBNull.Value, 0, DtGrid_PYM.Rows(0).Item("%"))
                    Dim CR As Double = CurrentCR
                    DtGrid_PYM.Rows(0).Item(CurrentHeader) = (Percent / 100) * CR

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try


            Next
            Grid4.DataSource = DtGrid_PYM

            Call Event_Term()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub Termin2()


        If GridView4.RowCount > 0 Then

            Dim MyNewRow As DataRow
            MyNewRow = DtTotal.NewRow
            Dim Curr As String = ""
            Dim Rows As Integer = Convert.ToInt32(C_Term.EditValue)

            DtGrid_PYM = New DataTable

            'Dim dt As New DataTable()
            For Each column As GridColumn In GridView4.VisibleColumns
                DtGrid_PYM.Columns.Add(column.FieldName, column.ColumnType)
            Next column
            For i As Integer = 0 To GridView4.DataRowCount - 1
                Dim row As DataRow = DtGrid_PYM.NewRow()
                For Each column As GridColumn In GridView4.VisibleColumns
                    row(column.FieldName) = GridView4.GetRowCellValue(i, column)
                Next column
                DtGrid_PYM.Rows.Add(row)
            Next i

            For a As Integer = 0 To DtGrid_PYM.Columns.Count - 1

                If a > 2 Then
                    DtGrid_PYM.Columns.RemoveAt(3)
                End If
            Next

            For b As Integer = 0 To GridView3.RowCount - 1
                Dim Header As String = GridView3.GetRowCellValue(b, "Curr")
                DtGrid_PYM.Columns.Add(Header, Type.GetType("System.Double"))
            Next

            Grid4.DataSource = DtGrid_PYM
            GridView4.OptionsView.ShowAutoFilterRow = False

        End If


    End Sub

    Private Sub Term_Properties()
        Try
            With GridView4

                '.BestFitColumns()
                .Columns("Term").Width = 2
                .Columns("Term").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Term").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Term").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False


                '.Columns("Term").DisplayFormat.FormatString = "c2"


                .Columns("Date").Width = 20
                .Columns("Date").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Date").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Date").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                .Columns("%").Width = 2
                .Columns("%").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("%").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("%").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("%").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("%").SummaryItem.DisplayFormat = "{0:N2}"


                For b As Integer = 0 To GridView3.RowCount - 1
                    Dim Header As String = GridView3.GetRowCellValue(b, "Curr")
                    .Columns(Header).Width = 200 / GridView3.RowCount
                    .Columns(Header).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns(Header).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default


                    .Columns(Header).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns(Header).DisplayFormat.FormatString = "N2"
                    .Columns(Header).OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                    .Columns(Header).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    .Columns(Header).SummaryItem.DisplayFormat = "{0:N2}"
                Next

                '.OptionsView.ShowFooter = True
                '.OptionsBehavior.Editable = False
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextEdit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try
            Dim JumlahRows As Integer = GridView4.RowCount - 1
            Dim PIndex As Integer = GridView4.FocusedRowHandle

            If Active_Form = 6 Then
                If JumlahRows = PIndex Then
                    GridView4.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom

                    ' GridView4.AddNewRow()
                    'GridView4.OptionsNavigation.AutoFocusNewRow = False
                    'GridView4.FocusedColumn = GridView4.VisibleColumns(0)
                    'GridView4.SetRowCellValue(GridView1.FocusedRowHandle, "Term", PIndex + 1)
                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rate", 1)
                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Price", 0)
                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Curr", "IDR")
                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Total Amount Currency", 0)
                End If

            End If



            Dim CurrentCR As Double = 0
            Dim CurrentHeader As String = ""

            For A As Integer = 0 To GridView3.RowCount - 1
                CurrentHeader = Convert.ToString(GridView3.GetRowCellValue(A, "Curr"))
                CurrentCR = Convert.ToDouble(GridView3.GetRowCellValue(A, "Total"))

                Try
                    Dim baseEdit = TryCast(sender, BaseEdit)
                    Dim gridView3 = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
                    gridView3.PostEditor()
                    gridView3.UpdateCurrentRow()

                    Dim Percent As Double = IIf(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "%") Is DBNull.Value, 0, GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "%"))
                    Dim CR As Double = CurrentCR
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, CurrentHeader, (Percent / 100) * CR)

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T_CRType_SelectedValueChanged(sender As Object, e As EventArgs) Handles T_CRType.SelectedValueChanged
        If Active_Form = 1 Then
            If T_CRType.EditValue = "Mold" Then
                T_RequirementDate.Enabled = True
                GroupBox1.Enabled = True
                T_CRType.Enabled = True
                T_Parent.Enabled = True
                T_ParentAmount.Enabled = True
                T_Reason.Enabled = True
                T_Dept.Enabled = True
                GroupBox1.Enabled = True
                'Grid1.Enabled = True
                GroupBox2.Enabled = True
                C_Term.Enabled = True
                'T_Dept.SetEditValue("")
                C_Term.Enabled = False
                T_NameItem.Enabled = True
                T_Spesification.Enabled = True
                GroupBox3.Enabled = True
                TCustomer.Enabled = True

                Call Edit_Grid()
                With GridView1

                    .Columns("Name Of Goods").OptionsColumn.AllowEdit = True
                    .Columns("Spesification").OptionsColumn.AllowEdit = True
                    .Columns("Model").Visible = True
                    .Columns("Sales Type").Visible = True
                    .Columns("Remark").Visible = True
                    .Columns("Model").VisibleIndex = 2
                    .Columns("Sales Type").VisibleIndex = 3
                    .Columns("Remark").VisibleIndex = 4
                    .Columns("Qty").OptionsColumn.AllowEdit = True
                    .Columns("Price").OptionsColumn.AllowEdit = True
                    .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                    .Columns("Curr").OptionsColumn.AllowEdit = True
                    .Columns("Category").OptionsColumn.AllowEdit = False
                    .Columns("Balance").OptionsColumn.AllowEdit = False
                    .Columns("Rate").OptionsColumn.AllowEdit = False
                    .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                    .Columns("Total IDR").OptionsColumn.AllowEdit = False
                    .Columns("Account").OptionsColumn.AllowEdit = True
                    .Columns("Note").Visible = False

                End With

                GridView5.OptionsBehavior.Editable = True
                BAddRows.Enabled = True
                BMold.Enabled = True
                T_Dept.SetEditValue("1FAC,1MKT")
                T_Dept.Properties.Items("1FAC").Enabled = False
                T_Dept.Properties.Items("1MKT").Enabled = False
            Else
                T_Dept.SetEditValue("1FAC")
                T_Dept.Properties.Items("1MKT").Enabled = True
                TCustomer.Enabled = False
                T_RequirementDate.Enabled = True
                GroupBox1.Enabled = True
                T_CRType.Enabled = True
                T_Parent.Enabled = True
                T_ParentAmount.Enabled = True
                T_Reason.Enabled = True
                T_Dept.Enabled = True
                GroupBox1.Enabled = True
                'Grid1.Enabled = True
                GroupBox2.Enabled = False
                GroupBox2.Enabled = False
                C_Term.Enabled = True
                'T_Dept.SetEditValue("1PUR,")
                GroupBox2.Enabled = False
                BMold.Enabled = False
                C_Term.Enabled = False
                T_NameItem.Enabled = True
                T_Spesification.Enabled = True
                GroupBox3.Enabled = True

                GridView1.OptionsBehavior.Editable = True
                GridView3.OptionsBehavior.Editable = False
                GridView4.OptionsBehavior.Editable = False

                With GridView1
                    .Columns("Name Of Goods").OptionsColumn.AllowEdit = True
                    .Columns("Spesification").OptionsColumn.AllowEdit = True
                    .Columns("Model").Visible = False
                    .Columns("Sales Type").Visible = False
                    .Columns("Remark").Visible = False
                    .Columns("Qty").OptionsColumn.AllowEdit = True
                    .Columns("Price").OptionsColumn.AllowEdit = True
                    .Columns("Total Amount Currency").OptionsColumn.AllowEdit = False
                    .Columns("Curr").OptionsColumn.AllowEdit = True
                    .Columns("Category").OptionsColumn.AllowEdit = False
                    .Columns("Balance").OptionsColumn.AllowEdit = False
                    .Columns("Rate").OptionsColumn.AllowEdit = False
                    .Columns("Remaining Budget").OptionsColumn.AllowEdit = False
                    .Columns("Total IDR").OptionsColumn.AllowEdit = False
                    .Columns("Account").OptionsColumn.AllowEdit = True
                    '.Columns("Check").Visible = False
                    .Columns("Note").Visible = False


                End With

                GridView5.OptionsBehavior.Editable = True
                BAddRows.Enabled = True
                BMold.Enabled = False

            End If
        End If


    End Sub

    Private Sub CurrRepository_EditValueChanged(sender As Object, e As EventArgs) Handles CurrRepository.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Try
            If T_RequirementDate.EditValue = Nothing Then

                MessageBox.Show("Please Select Requirement Date ",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

            Else

                Dim Cur As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Curr")
                Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
                Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
                Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

                Call FillRate(Tahun, Bulan, Cur)


                'Call HitungTotal()
                'Call TotalSumary()

                Try


                    Dim provider As CultureInfo = CultureInfo.InvariantCulture
                    Dim Acc_NoAccount As String = ""

                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            Acc_NoAccount = GridView1.GetRowCellValue(rowHandle, "Account")
                        End If
                    Next rowHandle

                    Call HitungTotal()
                    Call TotalSumary()
                    Call RefreshRemaining_Edit(Acc_NoAccount)
                    Call Termin(1)
                    Call Termin_Default(1)

                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try


            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        End Try


    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Try
            DtTerm.Clear()

            For a As Integer = 0 To GridView4.RowCount - 1
                For x As Integer = 0 To GridView3.RowCount - 1
                    Dim NamaCurr As String = Convert.ToString(GridView4.GetRowCellValue(x, "Curr"))
                    Dim dr As DataRow = DtTerm.NewRow
                    dr("Term") = GridView4.GetRowCellValue(a, "Term")
                    dr("Date") = GridView4.GetRowCellValue(a, "Date")
                    dr("%") = GridView4.GetRowCellValue(a, "%")
                    dr("Curr") = GridView3.GetRowCellValue(x, "Curr")
                    dr("Value") = GridView4.GetRowCellValue(a, GridView3.GetRowCellValue(x, "Curr"))
                    DtTerm.Rows.Add(dr)
                Next
            Next

        Catch ex As Exception

        End Try


    End Sub


    Private Sub Event_Term()

        Dim cmbCustID As RepositoryItemTextEdit = New RepositoryItemTextEdit()
        AddHandler cmbCustID.EditValueChanged, AddressOf TextEdit_EditValueChanged

        With GridView4
            .Columns("%").ColumnEdit = cmbCustID
        End With
        With Grid4.RepositoryItems
            .Add(cmbCustID)
        End With

    End Sub


    Public Overrides Sub Proc_Approve()

        Dim DeptEmail As String = ""

        GService = New GlobalService
        _level = GService.GetLevel_str("CIRCULATION")

        Dim dtRoot As DataTable
        dtRoot = fc_Class_ApproveDeptHead.Get_Root_Approve_ByDept(gh_Common.GroupID)

        If dtRoot.Rows.Count > 0 Then
            Division = dtRoot.Rows(0).Item("div_Id")
            Director = dtRoot.Rows(0).Item("director_Id")
        End If
#Region "ElseIf Active_Form = 1"
        If Active_Form = 1 Then
            fc_Class.GetDataByID(fs_Code)
            DeptEmail = fc_Class.H_DeptID
            If fc_Class.H_Status = "Create" Or fc_Class.H_Status = "Revise" Then

                Dim result As DialogResult = MessageBox.Show("Are You Want to Submit '" & fs_Code & "'?",
                                                        "CIRCULATION",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2)
                If result = System.Windows.Forms.DialogResult.OK Then
                    Try
                        fc_Class = New ClsCR_CreateUser
                        With fc_Class

                            If gh_Common.GroupID = "1BOD" Then
                                .H_DeptID = "miftah-mis@tsmu.co.id"
                                .H_UserSubmition = 1
                                .H_Status = "Approve 2"
                                .H_Current_Level = 3
                            Else
                                .H_DeptID = DeptEmail
                                .H_UserSubmition = 1
                                .H_Status = "Submit"
                                .H_Current_Level = Active_Form

                            End If

                            '.H_DeptID = DeptEmail
                            '.H_UserSubmition = 1
                            '.H_Status = "Submit"
                            '.H_Current_Level = Active_Form
                            .TA_Username = gh_Common.Username
                            .TA_MenuCode = "CIRCULATION"
                            .TA_DeptID = gh_Common.GroupID
                            .TA_NoTransaksi = fs_Code
                            .TA_LevelApprove = Active_Form
                            .TA_StatusApprove = "Submit"
                            .TA_ApproveBy = gh_Common.Username
                            .TA_ApproveDAte = Date.Now
                            .TA_IsActive = 1
                        End With
                        fc_Class.UpdateAprove_Requester(fs_Code, Active_Form)
                        bs_Filter = gh_Common.Username()

                        IsClosed = True
                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        GridDtl.DataSource = fc_Model.Get_CRRequest(gh_Common.GroupID, pDate1, pDate2)

                        Me.Hide()
                    Catch ex As Exception
                        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    End Try

                End If
            Else
                XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' has been Submitted  ?", "Confirmation", MessageBoxButtons.OK)
            End If
#End Region


#Region "ElseIf Active_Form = 2"

        ElseIf Active_Form = 2 Then

            Dim _ok, _rev, _del, _isrows As Boolean
            Dim _isCol As Boolean = True
            For J As Integer = 0 To GridView1.RowCount - 1
                _ok = IIf(GridView1.GetRowCellValue(J, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "OK")))
                _rev = IIf(GridView1.GetRowCellValue(J, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "Rev")))
                _del = IIf(GridView1.GetRowCellValue(J, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "Del")))
                _isrows = _ok Or _rev Or _del
                _isCol = _isCol And _isrows
            Next
            If _isCol = True Then
                Dim _Check1 As Boolean = True
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim _Check As Boolean = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                    _Check1 = _Check1 And _Check
                Next

                Dim _Msg As String = ""
                If _Check1 = True Then
                    _Msg = "Approve"
                Else
                    _Msg = "Reject"
                End If

                fc_Class.GetDataByID(fs_Code)
                DeptEmail = fc_Class.H_DeptID
                If fc_Class.H_Status = "Submit" Then
                    Dim result As DialogResult = MessageBox.Show("Are You Want to  '" & _Msg & "'  '" & fs_Code & "'?",
                                                        "CIRCULATION",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2)
                    If result = System.Windows.Forms.DialogResult.OK Then
                        Try
                            fc_Class.H_DeptID = DeptEmail
                            If _Check1 = True Then

                                fc_Class.H_Status = "Approve 1"
                                fc_Class.H_Current_Level = Active_Form
                                'ApproveHistoryModel
                                fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                                With fc_Model_ApproveHistoryModel

                                    .UserName = gh_Common.Username
                                    .MenuCode = "CIRCULATION"
                                    .DeptID = gh_Common.GroupID
                                    .NoTransaksi = fs_Code
                                    .LevelApproved = Active_Form
                                    .StatusApproved = "Approve"
                                    .ApprovedBy = gh_Common.Username
                                    .ApprovedDate = Date.Now
                                    .IsActive = 1

                                End With

                                'Insert To ObjDetailMaterial
                                fc_Class.Collection_Description_Of_Cost.Clear()
                                For i As Integer = 0 To GridView1.RowCount - 1

                                    Description_Of_Cost = New ClsCR_Description_of_Cost
                                    With Description_Of_Cost

                                        .D_CirculationNo = NoSirkulasi
                                        .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                        '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                        .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))


                                        Dim A, B, C As Boolean

                                        A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                        B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                        C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                        If A = True Then
                                            .D_Check = 1
                                        ElseIf B = True Then
                                            .D_Check = 2
                                        ElseIf C = True Then
                                            .D_Check = 3
                                        Else
                                            .D_Check = 0
                                        End If


                                    End With
                                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)
                                Next

                                fc_Class.UpdateAprove(T_CRNo.EditValue, Active_Form, gh_Common.Username, fc_Model_ApproveHistoryModel)
                                bs_Filter = gh_Common.Username()
                                IsClosed = True

                                Timer1.Enabled = True
                                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                                GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                                Me.Hide()
                            Else

                                With fc_Class
                                    .H_CirculationNo = T_CRNo.EditValue
                                    .H_Status = "Revise"
                                    fc_Class.H_Current_Level = 0
                                End With

                                fc_Class.Collection_Description_Of_Cost.Clear()
                                For i As Integer = 0 To GridView1.RowCount - 1

                                    Description_Of_Cost = New ClsCR_Description_of_Cost
                                    With Description_Of_Cost

                                        .D_CirculationNo = NoSirkulasi
                                        .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                        '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                        .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))

                                        Dim A, B, C As Boolean

                                        A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                        B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                        C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                        If A = True Then
                                            .D_Check = 1
                                        ElseIf B = True Then
                                            .D_Check = 2
                                        ElseIf C = True Then
                                            .D_Check = 3
                                        Else
                                            .D_Check = 0
                                        End If


                                    End With
                                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)
                                Next

                                fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                                With fc_Model_ApproveHistoryModel

                                    .UserName = gh_Common.Username
                                    .MenuCode = "CIRCULATION"
                                    .DeptID = gh_Common.GroupID
                                    .NoTransaksi = fs_Code
                                    .LevelApproved = 0
                                    .StatusApproved = "Reject"
                                    .ApprovedBy = gh_Common.Username
                                    .ApprovedDate = Date.Now
                                    .IsActive = 1

                                End With

                                fc_Class.Reject_Approve(T_CRNo.EditValue, Active_Form, fc_Model_ApproveHistoryModel)
                                IsClosed = True

                                Timer1.Enabled = True
                                Call ShowMessage(GetMessage(MessageEnum.RejectBerhasil), MessageTypeEnum.NormalMessage)
                                GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                                Me.Hide()

                            End If

                        Catch ex As Exception
                            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        End Try

                    End If
                ElseIf fc_Class.H_Status = "Approve 1" Then

                    If _Check1 = True Then
                        XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' Canot be Submit   ?", "Confirmation", MessageBoxButtons.OK)
                        Exit Sub
                    Else
                        With fc_Class
                            .H_CirculationNo = T_CRNo.EditValue
                            .H_Status = "Revise"
                            .H_Current_Level = 0
                        End With
                        fc_Class.Collection_Description_Of_Cost.Clear()
                        For i As Integer = 0 To GridView1.RowCount - 1

                            Description_Of_Cost = New ClsCR_Description_of_Cost
                            With Description_Of_Cost

                                .D_CirculationNo = NoSirkulasi
                                .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))

                                Dim A, B, C As Boolean

                                A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                If A = True Then
                                    .D_Check = 1
                                ElseIf B = True Then
                                    .D_Check = 2
                                ElseIf C = True Then
                                    .D_Check = 3
                                Else
                                    .D_Check = 0
                                End If

                            End With
                            fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                        Next

                        fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                        With fc_Model_ApproveHistoryModel

                            .UserName = gh_Common.Username
                            .MenuCode = "CIRCULATION"
                            .DeptID = gh_Common.GroupID
                            .NoTransaksi = fs_Code
                            .LevelApproved = 0
                            .StatusApproved = "Reject"
                            .ApprovedBy = gh_Common.Username
                            .ApprovedDate = Date.Now
                            .IsActive = 1

                        End With
                        fc_Class.Reject_Approve(T_CRNo.EditValue, Active_Form, fc_Model_ApproveHistoryModel)
                        IsClosed = True

                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.RejectBerhasil), MessageTypeEnum.NormalMessage)

                        GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                        Me.Hide()
                    End If

                Else

                    XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' Canot be Submit   ?", "Confirmation", MessageBoxButtons.OK)
                End If
            Else
                XtraMessageBox.Show("Please Check Approve Detail ", "Confirmation", MessageBoxButtons.OK)
            End If
#End Region

#Region "ElseIf Active_Form = 3"

        ElseIf Active_Form = 3 Then

            Dim _ok, _rev, _del, _isrows As Boolean
            Dim _isCol As Boolean = True
            For J As Integer = 0 To GridView1.RowCount - 1
                _ok = IIf(GridView1.GetRowCellValue(J, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "OK")))
                _rev = IIf(GridView1.GetRowCellValue(J, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "Rev")))
                _del = IIf(GridView1.GetRowCellValue(J, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(J, "Del")))
                _isrows = _ok Or _rev Or _del
                _isCol = _isCol And _isrows
            Next

            If _isCol = True Then
                Dim _Check1 As Boolean = True
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim _Check As Boolean = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                    _Check1 = _Check1 And _Check
                Next

                Dim _Msg As String = ""
                If _Check1 = True Then
                    _Msg = "Approve"
                Else
                    _Msg = "Reject"
                End If

                fc_Class.GetDataByID(fs_Code)
                DeptEmail = fc_Class.H_DeptID
                If fc_Class.H_Status = "Approve 1" Then
                    Dim result As DialogResult = MessageBox.Show("Are You Want to  '" & _Msg & "'  '" & fs_Code & "'?",
                                                        "CIRCULATION",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2)
                    If result = System.Windows.Forms.DialogResult.OK Then
                        Try
                            fc_Class.H_DeptID = DeptEmail
                            If _Check1 = True Then

                                fc_Class.H_Status = "Approve 2"
                                fc_Class.H_Current_Level = Active_Form
                                'ApproveHistoryModel
                                fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                                With fc_Model_ApproveHistoryModel

                                    .UserName = gh_Common.Username
                                    .MenuCode = "CIRCULATION"
                                    .DeptID = gh_Common.GroupID
                                    .NoTransaksi = fs_Code
                                    .LevelApproved = Active_Form
                                    .StatusApproved = "Approve"
                                    .ApprovedBy = gh_Common.Username
                                    .ApprovedDate = Date.Now
                                    .IsActive = 1

                                End With

                                'Insert To ObjDetailMaterial
                                fc_Class.Collection_Description_Of_Cost.Clear()
                                For i As Integer = 0 To GridView1.RowCount - 1

                                    Description_Of_Cost = New ClsCR_Description_of_Cost
                                    With Description_Of_Cost

                                        .D_CirculationNo = NoSirkulasi
                                        .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                        '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                        .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))

                                        Dim A, B, C As Boolean

                                        A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                        B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                        C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                        If A = True Then
                                            .D_Check = 1
                                        ElseIf B = True Then
                                            .D_Check = 2
                                        ElseIf C = True Then
                                            .D_Check = 3
                                        Else
                                            .D_Check = 0
                                        End If


                                    End With
                                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)
                                Next

                                fc_Class.UpdateAprove(T_CRNo.EditValue, Active_Form, gh_Common.Username, fc_Model_ApproveHistoryModel)
                                bs_Filter = gh_Common.Username()
                                IsClosed = True
                                Timer1.Enabled = True
                                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

                                GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                                Me.Hide()

                            Else

                                With fc_Class
                                    .H_CirculationNo = T_CRNo.EditValue
                                    .H_Status = "Revise"
                                    .H_Current_Level = 0
                                End With

                                fc_Class.Collection_Description_Of_Cost.Clear()
                                For i As Integer = 0 To GridView1.RowCount - 1

                                    Description_Of_Cost = New ClsCR_Description_of_Cost
                                    With Description_Of_Cost

                                        .D_CirculationNo = NoSirkulasi
                                        .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                        '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                        .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))
                                        Dim A, B, C As Boolean

                                        A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                        B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                        C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                        If A = True Then
                                            .D_Check = 1
                                        ElseIf B = True Then
                                            .D_Check = 2
                                        ElseIf C = True Then
                                            .D_Check = 3
                                        Else
                                            .D_Check = 0
                                        End If


                                    End With
                                    fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                                Next

                                fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                                With fc_Model_ApproveHistoryModel

                                    .UserName = gh_Common.Username
                                    .MenuCode = "CIRCULATION"
                                    .DeptID = gh_Common.GroupID
                                    .NoTransaksi = fs_Code
                                    .LevelApproved = 0
                                    .StatusApproved = "Reject"
                                    .ApprovedBy = gh_Common.Username
                                    .ApprovedDate = Date.Now
                                    .IsActive = 1

                                End With

                                fc_Class.Reject_Approve(T_CRNo.EditValue, Active_Form, fc_Model_ApproveHistoryModel)
                                IsClosed = True
                                Timer1.Enabled = True
                                Call ShowMessage(GetMessage(MessageEnum.RejectBerhasil), MessageTypeEnum.NormalMessage)
                                GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                                Me.Hide()

                            End If

                        Catch ex As Exception
                            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        End Try

                    End If

                ElseIf fc_Class.H_Status = "Approve 2" Or fc_Class.H_Status = "Other Dept" Then
                    If _Check1 = True Then
                        XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' Has been Approved   ?", "Confirmation", MessageBoxButtons.OK)
                        Exit Sub
                    Else
                        With fc_Class
                            .H_CirculationNo = T_CRNo.EditValue
                            .H_Status = "Revise"
                            .H_Current_Level = 0
                        End With
                        fc_Class.Collection_Description_Of_Cost.Clear()
                        For i As Integer = 0 To GridView1.RowCount - 1

                            Description_Of_Cost = New ClsCR_Description_of_Cost
                            With Description_Of_Cost

                                .D_CirculationNo = NoSirkulasi
                                .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                '.D_Check = IIf(GridView1.GetRowCellValue(i, "Check") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Check"))
                                .D_Note = IIf(GridView1.GetRowCellValue(i, "Note") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Note"))

                                Dim A, B, C As Boolean

                                A = IIf(GridView1.GetRowCellValue(i, "OK") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "OK")))
                                B = IIf(GridView1.GetRowCellValue(i, "Rev") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Rev")))
                                C = IIf(GridView1.GetRowCellValue(i, "Del") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Del")))

                                If A = True Then
                                    .D_Check = 1
                                ElseIf B = True Then
                                    .D_Check = 2
                                ElseIf C = True Then
                                    .D_Check = 3
                                Else
                                    .D_Check = 0
                                End If


                            End With
                            fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                        Next

                        fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                        With fc_Model_ApproveHistoryModel

                            .UserName = gh_Common.Username
                            .MenuCode = "CIRCULATION"
                            .DeptID = gh_Common.GroupID
                            .NoTransaksi = fs_Code
                            .LevelApproved = 0
                            .StatusApproved = "Reject"
                            .ApprovedBy = gh_Common.Username
                            .ApprovedDate = Date.Now
                            .IsActive = 1

                        End With
                        fc_Class.Reject_Approve(T_CRNo.EditValue, Active_Form, fc_Model_ApproveHistoryModel)
                        IsClosed = True
                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.RejectBerhasil), MessageTypeEnum.NormalMessage)
                        GridDtl.DataSource = fc_Class_ApproveDeptHead.Get_Approve(gh_Common.GroupID.ToString, _level, Division, Director)
                        Me.Hide()
                    End If

                Else

                    XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' Canot Submit   ?", "Confirmation", MessageBoxButtons.OK)
                End If
            Else
                XtraMessageBox.Show("Please Check Approve Detail", "Confirmation", MessageBoxButtons.OK)
            End If
#End Region

#Region "ElseIf Active_Form = 4  Other Dept"

        ElseIf Active_Form = 4 Then   ' (Other Dept)
            'Dim a As New DataTable
            'a = fc_Class_ApproveDivHead.Get_Other_Dept_Cek(gh_Common.GroupID, fs_Code)
            fc_Class.GetDataByID(fs_Code)

            'Dim Dept_Approve As Boolean = IIf(a.Rows(0).Item("Dept Approve") Is DBNull.Value, False, a.Rows(0).Item("Dept Approve"))
            'If Dept_Approve = True Then
            If fc_Class.H_Status <> "Approve 2" Then
                Dim result As DialogResult = MessageBox.Show("Circulation No : '" & fs_Code & "' has been submitted",
                                                    "CIRCULATION",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button2)
                Exit Sub
            Else

                Dim result As DialogResult = MessageBox.Show("Are You Want to Submit '" & fs_Code & "'?",
                                                    "CIRCULATION",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2)
                If result = System.Windows.Forms.DialogResult.OK Then
                    Try

                        'Dim Cek As String = gh_Common.GroupID
                        'For i As Integer = 0 To GridView5.RowCount - 1

                        '    If Cek = GridView5.GetRowCellValue(i, "Dept") Then
                        '        fc_Class_OtherDept = New ClsCR_Other_Dept
                        '        With fc_Class_OtherDept
                        '            .D_Opinion = GridView5.GetRowCellValue(i, "Opinion")
                        '            .D_Approve = 1
                        '        End With
                        '    End If
                        'Next

                        If gh_Common.GroupID = "1MKT" Or gh_Common.GroupID = "1FAC" Then

                            With fc_Class
                                .H_CirculationNo = fs_Code
                                If RB_Budget.Checked = True Then
                                    .H_Budget = 1
                                ElseIf RB_NonBudget.Checked = True Then
                                    .H_Budget = 0
                                End If
                                .H_CirculationNo = T_CRNo.EditValue
                                .H_CR_Type = T_CRType.EditValue
                            End With

                            fc_Class.Collection_Description_Of_Cost.Clear()
                            For i As Integer = 0 To GridView1.RowCount - 1

                                Description_Of_Cost = New ClsCR_Description_of_Cost
                                With Description_Of_Cost

                                    .D_CirculationNo = T_CRNo.EditValue
                                    .D_Id = Convert.ToString(GridView1.GetRowCellValue(i, "Id"))
                                    .D_SalesType = IIf(GridView1.GetRowCellValue(i, "Sales Type") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Sales Type"))
                                    .D_Account = IIf(GridView1.GetRowCellValue(i, "Account") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Account"))
                                End With
                                fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)
                            Next

                            fc_Class.UpdateMKTFAC(T_CRNo.EditValue)

                        End If



                        fc_Class.Collection_Other_Dept.Clear()
                        For I As Integer = 0 To GridView5.RowCount - 1

                            Dim userid As String = IIf(GridView5.GetRowCellValue(I, "User_id") Is DBNull.Value, "", GridView5.GetRowCellValue(I, "User_id"))
                            Dim Dept_ID As String = IIf(GridView5.GetRowCellValue(I, "Dept") Is DBNull.Value, "", GridView5.GetRowCellValue(I, "Dept"))
                            Dim Group As String = IIf(GridView5.GetRowCellValue(I, "Group") Is DBNull.Value, "", GridView5.GetRowCellValue(I, "Group"))

                            If userid = gh_Common.Username Or Dept_ID = gh_Common.GroupID Or Group = DeptGroup Then
                                Other_Dept = New ClsCR_Other_Dept
                                With Other_Dept
                                    .D_CirculationNo = fs_Code
                                    .D_Dept = IIf(GridView5.GetRowCellValue(I, "Dept") Is DBNull.Value, "", GridView5.GetRowCellValue(I, "Dept"))
                                    .D_Opinion = IIf(GridView5.GetRowCellValue(I, "Opinion") Is DBNull.Value, "", GridView5.GetRowCellValue(I, "Opinion"))
                                    .D_Approve = 1
                                End With
                                fc_Class.Collection_Other_Dept.Add(Other_Dept)
                            End If

                        Next

                        fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                        With fc_Model_ApproveHistoryModel

                            .UserName = gh_Common.Username
                            .MenuCode = "CIRCULATION"
                            .DeptID = gh_Common.GroupID
                            .NoTransaksi = fs_Code
                            .LevelApproved = Active_Form
                            .StatusApproved = "Approve"
                            .ApprovedBy = gh_Common.Username
                            .ApprovedDate = Date.Now
                            .IsActive = 1

                        End With

                        fc_Class.UpdateOtherDept(fs_Code, gh_Common.GroupID, fc_Model_ApproveHistoryModel)
                        bs_Filter = gh_Common.Username()

                        IsClosed = True
                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        fc_Class = New ClsCR_CreateUser
                        GridDtl.DataSource = fc_Class_ApproveDivHead.Get_Other_Dept(gh_Common.GroupID, gh_Common.Username, DeptGroup)
                        Me.Hide()
                    Catch ex As Exception
                        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    End Try
                End If

            End If
#End Region

#Region "ElseIf Active_Form = 5"
        ElseIf Active_Form = 5 Then   '(Accounting)
            If fc_Class.H_Status = "Other Dept" Or fc_Class.H_Status = "Approve BOD" Or fc_Class.H_Status = "Set Installment" Then
                Dim result As DialogResult = XtraMessageBox.Show("Are You Sure To Approve " & fs_Code & "  ?", "Confirmation", MessageBoxButtons.YesNo)
                If result = System.Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim Status As String = fc_Class.H_Status
                        Dim BudgetType As Integer
                        If RB_Budget.Checked = True Then
                            BudgetType = 1
                        ElseIf RB_NonBudget.Checked = True Then
                            BudgetType = 0
                        End If

                        If RBPO.Checked = True Then
                            fc_Class.H_PO = True
                        ElseIf RBNonPO.Checked = True Then
                            fc_Class.H_PO = False
                        End If


                        With fc_Class

                            If Status = "Other Dept" Then
                                .H_Status = "Approve BOD"
                            ElseIf Status = "Set Installment" Or Status = "Approve BOD" Then
                                .H_Status = "Close"
                                Active_Form = 7
                            End If

                            .H_Current_Level = Active_Form
                            .H_CirculationNo = fs_Code
                            .H_Budget = BudgetType
                            .H_CR_Type = T_CRType.EditValue
                            .H_Reason = T_Reason.Text
                            .H_Customer = TCustomer.EditValue
                            .H_RequirementDate = Format(T_RequirementDate.EditValue, "yyyy-MM-dd")
                            .H_Parent_Circulation = IIf(IsNothing(T_Parent.EditValue), "", T_Parent.EditValue)
                            .H_Parent_Circulation_Amount = CDec(T_ParentAmount.EditValue)
                            .H_Dies_Sales_Type = T_DS.EditValue
                            .H_Dies_Customer_Name = T_CustomerName.EditValue
                            .H_Dies_Model = T_ModelName.EditValue
                            .H_NameItem = T_NameItem.EditValue
                            .H_Spesification = T_Spesification.EditValue
                            If T_Charged.EditValue = "YES" Then
                                .H_ChargedOf = 1
                            Else
                                .H_ChargedOf = 0
                            End If
                            .H_Dies_Remark = T_Remark.EditValue
                            .H_InvoiceNo = ""
                            .H_InvoiceStatus = 0
                            .H_Dies = 1
                            .H_Budget_text = IIf(TBudget.EditValue Is Nothing, 0, TBudget.EditValue)

                        End With

                        fc_Class.Collection_Description_Of_Cost.Clear()
                        For i As Integer = 0 To GridView1.RowCount - 1

                            Description_Of_Cost = New ClsCR_Description_of_Cost
                            With Description_Of_Cost

                                .D_CirculationNo = NoSirkulasi
                                .D_Name_Of_Goods = Convert.ToString(GridView1.GetRowCellValue(i, "Name Of Goods"))
                                .D_Spesification = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))

                                .D_Model = IIf(GridView1.GetRowCellValue(i, "Model") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Model")))
                                .D_SalesType = IIf(GridView1.GetRowCellValue(i, "Sales Type") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Sales Type")))
                                .D_Remark = IIf(GridView1.GetRowCellValue(i, "Remark") Is DBNull.Value, "", Convert.ToString(GridView1.GetRowCellValue(i, "Remark")))

                                .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))
                                .D_Price = Convert.ToDouble(GridView1.GetRowCellValue(i, "Price"))
                                .D_Amount = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total Amount Currency"))
                                .D_Amount_IDR = Convert.ToDouble(GridView1.GetRowCellValue(i, "Total IDR"))
                                .D_PR_No = Convert.ToString(GridView1.GetRowCellValue(i, "PR No"))
                                .D_Currency = Convert.ToString(GridView1.GetRowCellValue(i, "Curr"))
                                .D_Rate = Convert.ToString(GridView1.GetRowCellValue(i, "Rate"))
                                .D_RemainingBudget = Convert.ToString(GridView1.GetRowCellValue(i, "Remaining Budget"))
                                .D_Account = Convert.ToString(GridView1.GetRowCellValue(i, "Account"))
                                .D_Category = Convert.ToString(GridView1.GetRowCellValue(i, "Category"))
                                '.D_Check = Convert.ToString(GridView1.GetRowCellValue(i, "Check"))
                                .D_Note = Convert.ToString(GridView1.GetRowCellValue(i, "Note"))

                            End With
                            fc_Class.Collection_Description_Of_Cost.Add(Description_Of_Cost)

                        Next


                        fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                        With fc_Model_ApproveHistoryModel

                            .UserName = gh_Common.Username
                            .MenuCode = "CIRCULATION"
                            .DeptID = gh_Common.GroupID
                            .NoTransaksi = fs_Code
                            .LevelApproved = Active_Form

                            .ApprovedBy = gh_Common.Username
                            .ApprovedDate = Date.Now
                            .IsActive = 1

                            If Status = "Other Dept" Then
                                .StatusApproved = "Approve"
                            ElseIf Status = "Set Installment" Or fc_Class.H_Status = "Approve BOD" Then
                                .StatusApproved = "Close"
                            End If

                        End With





                        fc_Class.Update_Approve_BOD(fs_Code, fc_Model_ApproveHistoryModel)
                        bs_Filter = gh_Common.Username()
                        GridDtl.DataSource = fc_Class_Accounting.Get_Approve_Accounting()
                        FrmAccounting = New Frm_CR_Accounting
                        'FrmAccounting.Grid2.DataSource = fc_Class_Accounting.Get_Approve_Accounting2()
                        Me.FrmAccounting.LoadGrid()
                        IsClosed = True
                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        Me.Hide()
                    Catch ex As Exception
                        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    End Try

                End If
            End If
#End Region


        ElseIf Active_Form = 6 Then  '(Purchase)

#Region "Term Data Table Payment"

            With fc_Class
                .H_Status = "Set Installment"
                .H_No_PO = IIf(T_PO.Text Is DBNull.Value, "", T_PO.Text)
                .H_No_PR = IIf(T_PR.Text Is DBNull.Value, "", T_PR.Text)
                .H_Current_Level = Active_Form
            End With

            Try
                DtTerm.Clear()
                GridView4.FocusedRowHandle = True
                For a As Integer = 0 To GridView4.RowCount - 1
                    For x As Integer = 0 To GridView3.RowCount - 1
                        Dim NamaCurr As String = Convert.ToString(GridView4.GetRowCellValue(x, "Curr"))
                        Dim dr As DataRow = DtTerm.NewRow
                        dr("Term") = GridView4.GetRowCellValue(a, "Term")
                        dr("Date") = GridView4.GetRowCellValue(a, "Date")
                        dr("%") = GridView4.GetRowCellValue(a, "%")
                        dr("Curr") = GridView3.GetRowCellValue(x, "Curr")
                        dr("Value") = GridView4.GetRowCellValue(a, GridView3.GetRowCellValue(x, "Curr"))
                        DtTerm.Rows.Add(dr)
                    Next
                Next

                fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                With fc_Model_ApproveHistoryModel

                    .UserName = gh_Common.Username
                    .MenuCode = "CIRCULATION"
                    .DeptID = gh_Common.GroupID
                    .NoTransaksi = fs_Code
                    .LevelApproved = Active_Form
                    .StatusApproved = "Approve"
                    .ApprovedBy = gh_Common.Username
                    .ApprovedDate = Date.Now
                    .IsActive = 1

                End With

            Catch ex As Exception
                ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
#End Region

#Region "Installment"
            fc_Class.Collection_Installment.Clear()
            For j As Integer = 0 To DtTerm.Rows.Count - 1

                Installment = New ClsCR_Installment
                With Installment

                    .D_CirculationNo = NoSirkulasi
                    Dim a As Object = DtTerm.Rows(j).Item("Date")
                    If DtTerm.Rows(j).Item("Date") Is DBNull.Value Then
                        .D_Date = Nothing
                        'ElseIf DtTerm.Rows(j).Item("Date") = "" Then
                        '    .D_Date = Nothing
                    Else
                        .D_Date = DtTerm.Rows(j).Item("Date")
                    End If
                    '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))                        '.D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))
                    'D_Date = IIf((DtTerm.Rows(j).Item("Date")) Is DBNull.Value, Nothing, Convert.ToDateTime(DtTerm.Rows(j).Item("Date")))
                    .D_Percent = Convert.ToString(DtTerm.Rows(j).Item("%"))
                    .D_Term = Convert.ToString(DtTerm.Rows(j).Item("Term"))
                    .D_Curr = Convert.ToString(DtTerm.Rows(j).Item("Curr"))
                    .D_Value = Convert.ToDouble(DtTerm.Rows(j).Item("Value"))

                End With
                fc_Class.Collection_Installment.Add(Installment)

            Next
#End Region

            fc_Class.UpdateInstallMent(fc_Class.H_CirculationNo, fc_Model_ApproveHistoryModel)
            IsClosed = True
            Timer1.Enabled = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            GridDtl.DataSource = fc_Class_Accounting.Get_Cek_Purchase
            Me.Hide()

        ElseIf Active_Form = 7 Then   ' (CR Close)
            If fc_Class.H_Status = "BA" Or fc_Class.H_Status = "Approve BOD" Or fc_Class.H_Status = "Set Installment" Then
                Dim result As DialogResult = MessageBox.Show("Are You Want to  Close CR '" & fs_Code & "'?",
                                                    "CIRCULATION",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2)
                If result = System.Windows.Forms.DialogResult.OK Then
                    Try
                        fc_Class.H_Status = "Close"
                        fc_Class.H_Current_Level = Active_Form
                        fc_Model_ApproveHistoryModel = New ApproveHistoryModel
                        With fc_Model_ApproveHistoryModel
                            .UserName = gh_Common.Username
                            .MenuCode = "CIRCULATION"
                            .DeptID = gh_Common.GroupID
                            .NoTransaksi = fs_Code
                            .LevelApproved = Active_Form
                            .StatusApproved = "Close"
                            .ApprovedBy = gh_Common.Username
                            .ApprovedDate = Date.Now
                            .IsActive = 1
                        End With

                        fc_Class.CloseCR(T_CRNo.EditValue, Active_Form, gh_Common.Username, fc_Model_ApproveHistoryModel)
                        bs_Filter = gh_Common.Username()
                        IsClosed = True
                        Timer1.Enabled = True
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        GridDtl.DataSource = fc_Class_Accounting.Get_CRClose()
                        Me.Hide()
                    Catch ex As Exception
                        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    End Try

                End If



            End If
        End If

    End Sub

    Private Sub C_Term_SelectedIndexChanged(sender As Object, e As EventArgs) Handles C_Term.SelectedIndexChanged
        Call Termin(C_Term.EditValue)
        Call Event_Term()
    End Sub

    Private Sub T_DS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles T_DS.SelectedIndexChanged

    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        'If Active_Form = 1 Then
        '    GridView4.Columns.Clear()
        'End If
        GridView4.FocusedRowHandle = True
        'Call Termin_Default(1)

    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridView1.RowUpdated
        'GridView4.Columns.Clear()
    End Sub

    Private Sub GridView1_RowCountChanged(sender As Object, e As EventArgs) Handles GridView1.RowCountChanged
        'GridView4.Columns.Clear()
    End Sub

    Private Sub GridView3_RowCountChanged(sender As Object, e As EventArgs) Handles GridView3.RowCountChanged
        'Call Termin2()

        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView4 = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        GridView4.PostEditor()
        GridView4.UpdateCurrentRow()
        GridView4.RefreshData()



    End Sub

    Private Sub Row_Other_Dept_Active()


        'For i As Integer = 0 To GridView5.RowCount - 1
        '    Dim Header As String = GridView5.GetRowCellValue(i, "Dept")
        '    If Header = gh_Common.GroupID Then
        '        For j As Integer = 0 To GridView5.Columns.Count - 1
        '            GridView5.Columns(j).OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False
        '        Next
        '    End If
        'Next

    End Sub

    Private Sub Grid_Leave(sender As Object, e As EventArgs) Handles Grid.Leave

    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle

        'Dim View As GridView = sender
        'If (e.RowHandle >= 0) Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Check"))
        '    If category = "REVISE" Then
        '        e.Appearance.BackColor = Color.Yellow
        '        'e.Appearance.BackColor2 = Color.Yellow
        '        e.HighPriority = True
        '    ElseIf category = "DELETE" Then
        '        e.Appearance.BackColor = Color.OrangeRed
        '        'e.Appearance.BackColor2 = Color.Yellow
        '        e.HighPriority = True
        '    End If
        'End If

    End Sub

    Private Sub GridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor

        'Dim VGrid As GridView = sender
        'Dim CellValue As String = VGrid.getcell(VGrid.Rows("rowTrademark"), VGrid.CurrentRecord)
        'If CellValue = "BMW" Then
        'End If

    End Sub

    Private Sub GridView5_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView5.FocusedRowChanged


        Try
            Dim Dept_ = String.Empty
            Dim User_ = String.Empty
            Dim DeptGroupT = String.Empty
            Dim selectedRows() As Integer = GridView5.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Dept_ = GridView5.GetRowCellValue(rowHandle, "Dept")
                    User_ = GridView5.GetRowCellValue(rowHandle, "User_id")
                    DeptGroupT = GridView5.GetRowCellValue(rowHandle, "Group")
                End If
            Next rowHandle

            If User_ = gh_Common.Username Or Dept_ = gh_Common.GroupID Or DeptGroupT = DeptGroup Then
                GridView5.Columns("Dept").OptionsColumn.AllowEdit = False
                GridView5.Columns("Name").OptionsColumn.AllowEdit = False
                GridView5.Columns("Date").OptionsColumn.AllowEdit = False
                GridView5.Columns("Opinion").OptionsColumn.AllowEdit = True
                'ElseIf (Dept_ = "1INJ" Or Dept_ = "12PP") And (gh_Common.GroupID = "1INJ" Or gh_Common.GroupID = "12PP") Then
                '    GridView5.Columns("Dept").OptionsColumn.AllowEdit = False
                '    GridView5.Columns("Name").OptionsColumn.AllowEdit = False
                '    GridView5.Columns("Date").OptionsColumn.AllowEdit = False
                '    GridView5.Columns("Opinion").OptionsColumn.AllowEdit = True
            Else
                GridView5.Columns("Dept").OptionsColumn.AllowEdit = False
                GridView5.Columns("Name").OptionsColumn.AllowEdit = False
                GridView5.Columns("Date").OptionsColumn.AllowEdit = False
                GridView5.Columns("Opinion").OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    'Private Sub Send_Email_OtherDept(NoSirkulasi As String)

    '    Try
    '        Dim MyMailMessage As New MailMessage
    '        Dim A As ArrayList = New ArrayList
    '        Dim dtEmail As New DataTable
    '        dtEmail = fc_Class.Get_Email_Dept(NoSirkulasi)
    '        MyMailMessage.From = New MailAddress("miftah-mis@tsmu.co.id")

    '        For i As Integer = 0 To dtEmail.Rows.Count - 1

    '            Dim Cek As String = dtEmail.Rows(i).Item(0).ToString

    '            If Cek <> "" Then
    '                MyMailMessage.To.Add(dtEmail.Rows(i).Item(0))
    '            End If
    '        Next

    '        MyMailMessage.CC.Add("log@tsmu.co.id")
    '        MyMailMessage.Subject = "Test"
    '        MyMailMessage.Body = "Body"
    '        Dim SMTP As New SmtpClient("mail.tsmu.co.id")
    '        SMTP.Port = 25
    '        SMTP.EnableSsl = False
    '        SMTP.Credentials = New System.Net.NetworkCredential("miftah-mis@tsmu.co.id", "W[QIWbV~$ZZQ")
    '        SMTP.Send(MyMailMessage)
    '        MsgBox("Mail was sent", MsgBoxStyle.Information)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public Overrides Sub Proc_Print()


        Dim _Status As String
        Dim dtRpt As DataTable
        dtRpt = New DataTable
        dtRpt = fc_Class.Cek_CR_Report(T_CRNo.EditValue)

        If dtRpt.Rows.Count > 0 Then

            If gh_Common.GroupID = "1BOD" Then

                Dim ds As New DataSet
                Dim dsOtherDept As New DataSet
                Dim dsApprove As New DataSet
                Dim dsTotal As New DataSet

                ds = fc_Class.RptCirculation_BOD(T_CRNo.EditValue)

                dsOtherDept = fc_Class.RptCirculation_OtherDept_BOD(T_CRNo.EditValue)
                dsApprove = fc_Class.RptCirculation_Approve(T_CRNo.EditValue)

                Dim Laporan As New DevCirculationTemp4()
                Dim LaporanDOC As New DevCirculationReportDOCTemp()

                Dim LaporanOther As New DevCirculationReportOther()

                Laporan.DataSource = ds.Tables("CirculationHead")
                LaporanDOC.DataSource = ds.Tables("CirculationHead")
                LaporanOther.DataSource = dsOtherDept.Tables("CirculationOtherDept")


                Dim subReport As XRSubreport = CType(Laporan.FindControl("XrSubreport1", True), XRSubreport)
                subReport.ReportSource.DataSource = ds.Tables("CirculationHead")

                Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
                subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

                Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
                subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")


                PrintTool = New ReportPrintTool(Laporan)
                TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                PrintTool.ShowPreview(UserLookAndFeel.Default)

            Else
                _Status = dtRpt.Rows(0).Item("status")
                If _Status = "Other Dept" Or _Status = "Approve BOD" Or _Status = "Set Installment" Or _Status = "Close" Or _Status = "BA" Then
#Region "Backup"
                    'Dim ds As New DataSet
                    'Dim dsOtherDept As New DataSet
                    'Dim dsApprove As New DataSet
                    'Dim dsTotal As New DataSet

                    'ds = fc_Class.RptCirculation(T_CRNo.EditValue)
                    ''dsTotal = Report.RptCirculationTotalDOC(Circulation)

                    ''Laporan.SetDataSource(ds)

                    'dsOtherDept = fc_Class.RptCirculation_OtherDept(T_CRNo.EditValue)
                    'dsApprove = fc_Class.RptCirculation_Approve(T_CRNo.EditValue)
                    'dsTotal = fc_Class.RptCirculationTotalDOC(T_CRNo.EditValue)
                    ''dsTotal = Report.RptCirculationTotalDOC(Circulation)

                    ''Laporan.Subreports("RptCirculation_OtherDept.rpt").SetDataSource(dsOtherDept)
                    ''Laporan.Subreports("RptCirculationApprove.rpt").SetDataSource(dsApprove)
                    ''Laporan.Subreports("RptCirculationTotal.rpt").SetDataSource(dsTotal)

                    'Dim Laporan As New DevCirculationReport()
                    'Dim LaporanDOC As New DevCirculationReportDOC()
                    'Dim LaporanOther As New DevCirculationReportOther()
                    'Dim LaporanBOD As New DevCirculationReportBOD()
                    'Dim LaporanTotal As New DevCirculationReportTotal()

                    'Laporan.DataSource = ds.Tables("CirculationHead")
                    'LaporanDOC.DataSource = ds.Tables("CirculationHead")
                    'LaporanOther.DataSource = dsOtherDept.Tables("CirculationOtherDept")
                    'LaporanBOD.DataSource = dsApprove.Tables("CirculationApprove")
                    'LaporanTotal.DataSource = dsTotal.Tables("CirculationTotalDOC")


                    'Dim subReport As XRSubreport = CType(Laporan.FindControl("XrSubreport1", True), XRSubreport)
                    'subReport.ReportSource.DataSource = ds.Tables("CirculationHead")

                    'Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
                    'subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

                    'Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
                    'subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")

                    'Dim subReportTotal As XRSubreport = CType(Laporan.FindControl("XrSubreport4", True), XRSubreport)
                    'subReportTotal.ReportSource.DataSource = dsTotal.Tables("CirculationTotalDOC")


                    'PrintTool = New ReportPrintTool(Laporan)
                    'TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                    'PrintTool.ShowPreview(UserLookAndFeel.Default)
#End Region
                    Dim ds As New DataSet
                    Dim dsOtherDept As New DataSet
                    Dim dsApprove As New DataSet
                    Dim dsTotal As New DataSet

                    ds = fc_Class.RptCirculation_Temp(T_CRNo.EditValue)

                    dsOtherDept = fc_Class.RptCirculation_OtherDept(T_CRNo.EditValue)
                    dsApprove = fc_Class.RptCirculation_Approve(T_CRNo.EditValue)
                    'dsTotal = fc_Class.RptCirculationTotalDOC(T_CRNo.EditValue)

                    Dim Laporan As New DevCirculationTemp4()
                    Dim LaporanDOC As New DevCirculationReportDOCTemp()

                    Dim LaporanOther As New DevCirculationReportOther()
                    'Dim LaporanBOD As New DevCirculationReportBOD()
                    'Dim LaporanTotal As New DevCirculationReportTotal()

                    Laporan.DataSource = ds.Tables("CirculationHead")
                    LaporanDOC.DataSource = ds.Tables("CirculationHead")
                    LaporanOther.DataSource = dsOtherDept.Tables("CirculationOtherDept")
                    'LaporanBOD.DataSource = dsApprove.Tables("CirculationApprove")
                    'LaporanTotal.DataSource = dsTotal.Tables("CirculationTotalDOC")


                    Dim subReport As XRSubreport = CType(Laporan.FindControl("XrSubreport1", True), XRSubreport)
                    subReport.ReportSource.DataSource = ds.Tables("CirculationHead")

                    Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
                    subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

                    Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
                    subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")

                    'Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
                    'subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

                    'Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
                    'subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")

                    'Dim subReportTotal As XRSubreport = CType(Laporan.FindControl("XrSubreport4", True), XRSubreport)
                    'subReportTotal.ReportSource.DataSource = dsTotal.Tables("CirculationTotalDOC")

                    PrintTool = New ReportPrintTool(Laporan)
                    TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                    PrintTool.ShowPreview(UserLookAndFeel.Default)
                Else
                    MessageBox.Show("Circulation can not be printed",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

            End If

        End If



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BBeritaAcara_Click(sender As Object, e As EventArgs) Handles BBeritaAcara.Click

        CForm = 5
        CallForm()

        'End If
    End Sub

    Private Sub Opinion_EditValueChanged(sender As Object, e As EventArgs) Handles Opinion.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim GroupSelect As String = ""
        Dim Opini As String = ""
        Dim selectedRows() As Integer = GridView5.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            ' If rowHandle >= 0 Then
            GroupSelect = GridView5.GetRowCellValue(rowHandle, "User_id")
            Opini = GridView5.GetRowCellValue(rowHandle, "Opinion")
            ' End If
        Next rowHandle

        For I As Integer = 0 To GridView5.RowCount - 1
            Dim GroupCek As String = GridView5.GetRowCellValue(I, GridView5.Columns("User_id")).ToString
            If GroupCek = GroupSelect Then
                GridView5.SetRowCellValue(I, "Opinion", Opini)
            End If
        Next

    End Sub

    Public Overrides Sub Proc_DeleteData()

        Try
            If Active_Form = 2 Or Active_Form = 3 Then
                If fc_Class.H_Status = "Submit" Or fc_Class.H_Status = "Approve 1" Or fc_Class.H_Status = "Approve 2" Or fc_Class.H_Status = "Other Dept" Then
                    Dim result As DialogResult = MessageBox.Show("Are You Want to Submit '" & fs_Code & "'?",
                                                            "CIRCULATION",
                                                            MessageBoxButtons.OKCancel,
                                                            MessageBoxIcon.Question,
                                                            MessageBoxDefaultButton.Button2)
                    If result = System.Windows.Forms.DialogResult.OK Then

                        fc_Class = New ClsCR_CreateUser
                        With fc_Class
                            .H_UserSubmition = 1
                            .H_Status = "CANCEL"
                            .TA_Username = gh_Common.Username
                            .TA_MenuCode = "CIRCULATION"
                            .TA_DeptID = gh_Common.GroupID
                            .TA_NoTransaksi = fs_Code
                            .TA_LevelApprove = 10
                            .TA_StatusApprove = "CANCEL"
                            .TA_ApproveBy = gh_Common.Username
                            .TA_ApproveDAte = Date.Now
                            .TA_IsActive = 1
                        End With
                        fc_Class.Reject_CRF(fs_Code, Active_Form, 10)
                        bs_Filter = gh_Common.Username()

                        IsClosed = True
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        GridDtl.DataSource = fc_Model.Get_CRRequest(gh_Common.GroupID, pDate1, pDate2)
                        Me.Hide()
                    End If
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Check_OK_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OK.CheckedChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rev", 0)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Del", 0)

            End If
        Next rowHandle

    End Sub

    Private Sub Check_Rev_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Rev.CheckedChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "OK", 0)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Del", 0)

            End If
        Next rowHandle
    End Sub

    Private Sub Check_Del_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Del.CheckedChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim provider As CultureInfo = CultureInfo.InvariantCulture
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Rev", 0)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "OK", 0)

            End If
        Next rowHandle
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send("{ENTER}")
        Timer1.Enabled = False
    End Sub

    Private Sub TCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TCustomer.ButtonClick
        Try
            fc_Class = New ClsCR_CreateUser
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.GetCustomer()
            ls_Judul = "CUSTOMER"
            ls_OldKode = T_CustomerName.EditValue

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                TCustomer.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click

        Dim ds As New DataSet
        Dim dsOtherDept As New DataSet
        Dim dsApprove As New DataSet
        Dim dsTotal As New DataSet

        ds = fc_Class.RptCirculation_Temp(T_CRNo.EditValue)

        dsOtherDept = fc_Class.RptCirculation_OtherDept(T_CRNo.EditValue)
        dsApprove = fc_Class.RptCirculation_Approve(T_CRNo.EditValue)
        'dsTotal = fc_Class.RptCirculationTotalDOC(T_CRNo.EditValue)

        Dim Laporan As New DevCirculationTemp4()
        Dim LaporanDOC As New DevCirculationReportDOCTemp()

        Dim LaporanOther As New DevCirculationReportOther()
        'Dim LaporanBOD As New DevCirculationReportBOD()
        'Dim LaporanTotal As New DevCirculationReportTotal()

        Laporan.DataSource = ds.Tables("CirculationHead")
        LaporanDOC.DataSource = ds.Tables("CirculationHead")
        LaporanOther.DataSource = dsOtherDept.Tables("CirculationOtherDept")
        'LaporanBOD.DataSource = dsApprove.Tables("CirculationApprove")
        'LaporanTotal.DataSource = dsTotal.Tables("CirculationTotalDOC")


        Dim subReport As XRSubreport = CType(Laporan.FindControl("XrSubreport1", True), XRSubreport)
        subReport.ReportSource.DataSource = ds.Tables("CirculationHead")

        Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
        subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

        Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
        subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")

        'Dim subReportOther As XRSubreport = CType(Laporan.FindControl("XrSubreport2", True), XRSubreport)
        'subReportOther.ReportSource.DataSource = dsOtherDept.Tables("CirculationOtherDept")

        'Dim subReportBOD As XRSubreport = CType(Laporan.FindControl("XrSubreport3", True), XRSubreport)
        'subReportBOD.ReportSource.DataSource = dsApprove.Tables("CirculationApprove")

        'Dim subReportTotal As XRSubreport = CType(Laporan.FindControl("XrSubreport4", True), XRSubreport)
        'subReportTotal.ReportSource.DataSource = dsTotal.Tables("CirculationTotalDOC")

        PrintTool = New ReportPrintTool(Laporan)
        TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
        PrintTool.ShowPreview(UserLookAndFeel.Default)


    End Sub

    Private Sub Grid5_Click(sender As Object, e As EventArgs) Handles Grid5.Click

    End Sub

    Private Sub Frm_CR_UserCreateDetail_Validated(sender As Object, e As EventArgs) Handles Me.Validated

    End Sub

    Private Sub RB_Budget_Click(sender As Object, e As EventArgs) Handles RB_Budget.Click
        TBudget.Enabled = True
    End Sub

    Private Sub RB_NonBudget_Click(sender As Object, e As EventArgs) Handles RB_NonBudget.Click
        TBudget.Enabled = False
        TBudget.Text = 0
    End Sub
End Class
