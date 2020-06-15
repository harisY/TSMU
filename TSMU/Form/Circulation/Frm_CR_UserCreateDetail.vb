Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop


Public Class Frm_CR_UserCreateDetail

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New ClsCR_CreateUser
    Dim Description_Of_Cost As New ClsCR_Description_of_Cost
    Dim Installment As New ClsCR_Installment
    Dim Other_Dept As New ClsCR_Other_Dept
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
    Dim BG As String = ""


    Dim DtGrid_PYM As DataTable

    Dim DtTerm As DataTable





    Dim id As System.Globalization.CultureInfo '= New System.Globalization.CultureInfo("id-ID")





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

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.GetDataByID(fs_Code)

                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If

                If fc_Class.H_Status = "Create" Then

                    Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)

                Else
                    Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
                End If

                Me.Text = "CIRCULATION FORM -> " & fs_Code
            Else
                T_CRNo.Enabled = False
                T_RequirementDate.Enabled = False
                GroupBox1.Enabled = False
                T_CRType.Enabled = True
                T_Parent.Enabled = False
                T_ParentAmount.Enabled = False
                T_Reason.Enabled = False
                T_Dept.Enabled = False
                GroupBox1.Enabled = False
                'Grid1.Enabled = False
                GroupBox2.Enabled = False
                C_Term.Enabled = False

                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
                Me.Text = "CIRCULATION FORM "

            End If

            Call LoadTxtBox()
            Call LoadGridBarang(fc_Class.H_CirculationNo)
            Call LoadGridInstallment(fc_Class.H_CirculationNo)
            'Call LoadGridDetil1()

            Call FillComboOtherDept()
            Call FillComboCurrency()
            Call Sub_Dept(gh_Common.GroupID)
            Call InputBeginState(Me)

            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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
                    If .H_ChargedOf = 1 Then
                        T_Charged.EditValue = "YES"
                    Else
                        T_Charged.EditValue = "NO"
                    End If

                    T_Remark.EditValue = .H_Dies_Remark


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

                Dim dt As New DataTable
                dt = fc_Class.Get_Detail_DescriptionOfCost(CirculationNo)
                Grid.DataSource = dt
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
            Else

                Dim dt As New DataTable
                dt = fc_Class.Get_Other_DeptID
                T_Dept.Properties.DataSource = Nothing
                T_Dept.Properties.DataSource = dt
                T_Dept.Properties.ValueMember = "Value"
                T_Dept.Properties.DisplayMember = "Value"
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
            Dim dt As New DataTable
            dt = fc_Class.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Rate Tidak ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                DeptSub = (dt.Rows(0).Item("Sub"))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub



    Private Sub FillRate(Tahun As String, Bulan As String, Cur As String)
        Try

            ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
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



    Private Sub C_Currency_EditValueChanged(sender As Object, e As EventArgs)
        'Try
        '    If T_RequirementDate.EditValue = Nothing Then

        '        MessageBox.Show("Please Select Requirement Date ",
        '                       "Warning",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Exclamation,
        '                       MessageBoxDefaultButton.Button1)

        '    Else

        '        Dim Cur As String = C_Currency.EditValue
        '        Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
        '        Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
        '        Dim Bulan As String = Convert.ToString(Param.ToString("MM"))



        '        Call FillRate(Tahun, Bulan, Cur)
        '    End If

        'Catch ex As Exception
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        'End Try
    End Sub

    Private Sub C_Currency_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_RequirementDate_EditValueChanged(sender As Object, e As EventArgs) Handles T_RequirementDate.EditValueChanged

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
        DtGridBarang.Columns.AddRange(New DataColumn(11) {New DataColumn("Name Of Goods", GetType(String)),
                                                            New DataColumn("Spesification", GetType(String)),
                                                            New DataColumn("Qty", GetType(Double)),
                                                            New DataColumn("Price", GetType(Double)),
                                                            New DataColumn("Total Amount Currency", GetType(Double)),
                                                            New DataColumn("Curr", GetType(String)),
                                                            New DataColumn("Category", GetType(String)),
                                                            New DataColumn("Balance", GetType(Double)),
                                                            New DataColumn("Rate", GetType(Double)),
                                                            New DataColumn("Remaining Budget", GetType(Double)),
                                                            New DataColumn("Total IDR", GetType(Double)),
                                                            New DataColumn("Account", GetType(String))})



        Grid.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False




        DtTotal = New DataTable
        DtTotal.Columns.AddRange(New DataColumn(1) {New DataColumn("Curr", GetType(String)),
                                                           New DataColumn("Total", GetType(Double))})

        Grid3.DataSource = DtTotal
        GridView3.OptionsView.ShowAutoFilterRow = False

        'DtGrid_PYM = New DataTable
        'DtGrid_PYM.Columns.AddRange(New DataColumn(3) {New DataColumn("Term", GetType(String)),
        '                                                    New DataColumn("Date", GetType(Date)),
        '                                                    New DataColumn("%", GetType(Double)),
        '                                                    New DataColumn("Total", GetType(Double))})


        'Grid4.DataSource = DtGrid_PYM


        'GridView4.OptionsView.ShowAutoFilterRow = False

        DtTerm = New DataTable
        DtTerm.Columns.AddRange(New DataColumn(4) {New DataColumn("Term", GetType(String)),
                                                           New DataColumn("Date", GetType(Date)),
                                                           New DataColumn("%", GetType(Double)),
                                                           New DataColumn("Curr", GetType(String)),
                                                           New DataColumn("Value", GetType(Double))})




    End Sub


    Private Sub Frm_CR_UserCreateDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        'Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()






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

            'Dim Total As Double = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Total") Is DBNull.Value, 0, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Total"))
            'Dim CR As Double = CurrentCR
            ''Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
            'GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "%", (Total / CR) * 100)

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
            ElseIf GridView4.RowCount = 0 Then
                MessageBox.Show("Please Fill Term of Paymen / Installment", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty Of Description of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


                For j As Integer = 0 To GridView4.RowCount - 1
                    GridView4.MoveFirst()
                    If GridView4.GetRowCellValue(j, GridView4.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty of Term Of Payment", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


            End If

            If isUpdate = False Then
                fc_Class.GetCirculationNoAuto()
                Dim BudgetType As Integer
                If RB_Budget.Checked = True Then
                    BudgetType = 1
                ElseIf RB_NonBudget.Checked = True Then
                    BudgetType = 0
                End If

                NoSirkulasi = fc_Class.H_CirculationNo
                With fc_Class

                    .H_Budget = BudgetType
                    .H_CR_Type = T_CRType.EditValue
                    .H_Reason = T_Reason.Text
                    .H_RequirementDate = Format(T_RequirementDate.EditValue, "yyyy-MM-dd")
                    .H_Status = "Create"
                    .H_Parent_Circulation = T_Parent.EditValue
                    .H_Parent_Circulation_Amount = CDec(T_ParentAmount.EditValue)
                    .H_Dies_Sales_Type = T_DS.EditValue
                    .H_Dies_Customer_Name = T_CustomerName.EditValue
                    .H_Dies_Model = T_ModelName.EditValue
                    '.H_ChargedOf = T_Charged.EditValue
                    If T_Charged.EditValue = "YES" Then
                        .H_ChargedOf = 1
                    Else
                        .H_ChargedOf = 0
                    End If
                    .H_Dies_Remark = T_Remark.EditValue
                    .H_InvoiceNo = ""
                    .H_InvoiceStatus = 0
                    .H_Dies = 1



                End With


                'Insert To ObjDetailMaterial
                fc_Class.Collection_Description_Of_Cost.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Description_Of_Cost = New ClsCR_Description_of_Cost
                    With Description_Of_Cost

                        .D_CirculationNo = NoSirkulasi
                        .D_Name_Of_Goods = Convert.ToString(GridView1.GetRowCellValue(i, "Name Of Goods"))
                        .D_Spesification = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))
                        .D_Qty = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))
                        .D_Price = Convert.ToDouble(GridView1.GetRowCellValue(i, "Price"))
                        .D_Amount = Convert.ToInt32(GridView1.GetRowCellValue(i, "Total Amount Currency"))
                        .D_Amount_IDR = Convert.ToInt32(GridView1.GetRowCellValue(i, "Total IDR"))
                        .D_PR_No = Convert.ToString(GridView1.GetRowCellValue(i, "PR No"))
                        .D_Currency = Convert.ToString(GridView1.GetRowCellValue(i, "Curr"))
                        .D_Rate = Convert.ToString(GridView1.GetRowCellValue(i, "Rate"))
                        .D_RemainingBudget = Convert.ToString(GridView1.GetRowCellValue(i, "Remaining Budget"))
                        .D_Account = Convert.ToString(GridView1.GetRowCellValue(i, "Account"))
                        .D_Category = Convert.ToString(GridView1.GetRowCellValue(i, "Category"))

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
                            '.D_UserName = Convert.ToString(GridView1.GetRowCellValue(i, "Spesification"))
                            '.D_Name = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty"))

                        End With
                        fc_Class.Collection_Other_Dept.Add(Other_Dept)

                        'MessageBox.Show(item.ToString, "Warning",
                        '   MessageBoxButtons.OK,
                        '   MessageBoxIcon.Exclamation,
                        '   MessageBoxDefaultButton.Button1)
                    Next
                End If

#Region "Term Data Table Payment"
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
#End Region


                fc_Class.Collection_Installment.Clear()
                For j As Integer = 0 To DtTerm.Rows.Count - 1

                    Installment = New ClsCR_Installment
                    With Installment

                        .D_CirculationNo = NoSirkulasi
                        .D_Term = Convert.ToInt32(DtTerm.Rows(j).Item("Term"))
                        .D_Date = Convert.ToDateTime(DtTerm.Rows(j).Item("Date"))
                        .D_Percent = Convert.ToString(DtTerm.Rows(j).Item("%"))
                        .D_Curr = Convert.ToString(DtTerm.Rows(j).Item("Curr"))
                        .D_Value = Convert.ToDouble(DtTerm.Rows(j).Item("Value"))

                    End With
                    fc_Class.Collection_Installment.Add(Installment)

                Next




                fc_Class.Insert(NoSirkulasi)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class.Get_CRRequest(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                'KodeTrans = fc_Class.IDTrans
                'fc_Class.H_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                ''Insert To ObjDetailMaterial
                'fc_Class.ObjDetailQualityProblem.Clear()
                'For i As Integer = 0 To GridView1.RowCount - 1

                '    ObjQualityProblemDetail = New QualityProblemDetailModel
                '    With ObjQualityProblemDetail
                '        .D_IDTransaksi = KodeTrans
                '        .D_Shift = Convert.ToString(GridView1.GetRowCellValue(i, "Shift"))
                '        .D_Status = Convert.ToString(GridView1.GetRowCellValue(i, "Status"))
                '        .D_Customer = Convert.ToString(GridView1.GetRowCellValue(i, "Customer"))
                '        .D_InvtId = Convert.ToString(GridView1.GetRowCellValue(i, "InvtId"))
                '        .D_InvtName = Convert.ToString(GridView1.GetRowCellValue(i, "InvtName"))
                '        .D_Type = Convert.ToString(GridView1.GetRowCellValue(i, "Type"))
                '        .D_Qty = Convert.ToString(GridView1.GetRowCellValue(i, "Qty"))
                '        .D_Problem = Convert.ToString(GridView1.GetRowCellValue(i, "Problem"))
                '        .D_Analisis = Convert.ToString(GridView1.GetRowCellValue(i, "Analisis"))
                '        .D_CORRECTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action"))
                '        .D_PREVENTIVE_ACTION = Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action"))
                '        .D_Lot = Convert.ToString(GridView1.GetRowCellValue(i, "Lot No"))
                '        .D_Pic = Convert.ToString(GridView1.GetRowCellValue(i, "Pic"))
                '        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                '        .D_Tanggal = Format(DtTanggalLaporan.Value, "yyyy-MM-dd")
                '        .D_Gambar = Convert.ToString(GridView1.GetRowCellValue(i, "Gambar"))

                '    End With
                '    fc_Class.ObjDetailQualityProblem.Add(ObjQualityProblemDetail)

                'Next


                'fc_Class.UpdateData(fs_Code)
                'GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                'IsClosed = True
                'Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
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
            ElseIf T_DS.EditValue = "" Then
                MessageBox.Show("Please Choose Sales Type", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_CustomerName.EditValue = "" Then
                MessageBox.Show("Please fill Customer Name", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_ModelName.EditValue = "" Then
                MessageBox.Show("Please fill Model Name", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_Charged.EditValue = "" Then
                MessageBox.Show("Please Choose Charge Of Customer", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)
            ElseIf T_RequirementDate.Text = "" Then
                MessageBox.Show("Please Choose RequirementDate", "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1)

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

    Private Sub T_T1_ButtonClick(sender As Object, e As ButtonPressedEventArgs)





    End Sub

    Private Sub T_T1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub T_T2_ButtonClick(sender As Object, e As ButtonPressedEventArgs)



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


    'Private Sub C_Currency_Leave(sender As Object, e As EventArgs)
    '    Try
    '        If T_RequirementDate.EditValue = Nothing Then

    '            MessageBox.Show("Please Select Requirement Date ",
    '                           "Warning",
    '                           MessageBoxButtons.OK,
    '                           MessageBoxIcon.Exclamation,
    '                           MessageBoxDefaultButton.Button1)

    '        Else

    '            ' Dim Cur As String = C_Currency.EditValue
    '            Dim Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue.AddMonths(-1))
    '            Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
    '            Dim Bulan As String = Convert.ToString(Param.ToString("MM"))



    '            Call FillRate(Tahun, Bulan, Cur)
    '        End If

    '    Catch ex As Exception
    '        ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

    '    End Try
    'End Sub

    Private Sub T_Account_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid1_Click(sender As Object, e As EventArgs)

    End Sub



    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal Nama As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If CForm = 1 Then
            FGetMold = New Frm_CR_Get_Mold(ID, DtGridBarang, Grid4, BG)
            FGetMold.StartPosition = FormStartPosition.CenterScreen
            FGetMold.MaximizeBox = False
            FGetMold.ShowDialog()
        End If



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Dim oApp As New Outlook.Application, oMsg As Outlook.MailItem = oApp.CreateItem(Outlook.OlItemType.olMailItem)

        With oMsg
            .To = "miftah-mis@tsmu.co.id" : .Subject = "Special Order Request"
            .Body = "Test"
            .Send()
        End With




    End Sub

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
                If Val(Value2) <= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "N")
                Else
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Category", "B")
                End If

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Account", Value1)
                'T_RemainingBudget.EditValue = Value21.ToString("#,##0.00")
                Try
                    Dim ACC_Param As Date = Convert.ToDateTime(T_RequirementDate.EditValue)
                    Dim Acc_Departemen As String = gh_Common.GroupID
                    Dim Acc_Site As String = gh_Common.Site
                    Dim Acc_NoAccount As String = Value1
                    Dim Acc_Tahun As String = Convert.ToString(ACC_Param.ToString("yyyy"))
                    Dim Acc_Bulan As String = Convert.ToString(ACC_Param.ToString("MM"))

                    Call Get_Total_Sisa_Budget_Dept(DeptSub, Acc_NoAccount, Acc_Tahun, Acc_Bulan)

                    Dim dataSourceRowIndex As Integer = GridView1.FocusedRowHandle()

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


                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Remaining Budget", SisaBudget)

                    'Call Get_Total_CR_Dept(Acc_Departemen, Acc_Site, Acc_NoAccount, Acc_Tahun)


                    'T_RemainingBudget.EditValue = SisaBudget.ToString("#,##0.00")
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

            Call HitungTotal()
            Call TotalSumary()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub
    Private Sub HitungTotal()
        Try

            Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Qty"))
            Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
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

            Call HitungTotal()
            Call TotalSumary()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try



    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown

        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()

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

            Call TotalSumary()
            Call Termin()


        End If

    End Sub

    Private Sub BAddRows_Click(sender As Object, e As EventArgs) Handles BAddRows.Click

        GridView1.AddNewRow()
        GridView1.OptionsNavigation.AutoFocusNewRow = True
        GridView1.FocusedColumn = GridView1.VisibleColumns(0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Qty", 0)
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Price", 0)
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

        CForm = 1

        CallForm()

    End Sub

    Private Sub C_Term_SelectedIndexChanged(sender As Object, e As EventArgs) Handles C_Term.SelectedIndexChanged

        Call Termin()
        Call Event_Term()


    End Sub

    Private Sub Termin()

        Dim MyNewRow As DataRow
        MyNewRow = DtTotal.NewRow
        Dim Curr As String = ""
        Dim Rows As Integer = Convert.ToInt32(C_Term.EditValue)


        GridView4.Columns.Clear()

        DtGrid_PYM = New DataTable
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

        For i As Integer = 1 To Rows

            GridView4.AddNewRow()
            GridView4.OptionsNavigation.AutoFocusNewRow = True
            GridView4.FocusedColumn = GridView4.VisibleColumns(0)
            GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "Term", i.ToString)

        Next



    End Sub

    Private Sub Term_Properties()
        Try
            With GridView4

                .BestFitColumns()
                .Columns("Term").Width = 50
                .Columns("Term").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Term").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Term").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False


                '.Columns("Term").DisplayFormat.FormatString = "c2"


                .Columns("Date").Width = 100
                .Columns("Date").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Date").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Date").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                .Columns("%").Width = 100
                .Columns("%").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("%").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("%").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                For b As Integer = 0 To GridView3.RowCount - 1
                    Dim Header As String = GridView3.GetRowCellValue(b, "Curr")
                    .Columns(Header).Width = 200
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
                    'Dim Price As Single = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Price"))
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, CurrentHeader, (Percent / 100) * CR)


                    'gridView3.UpdateCurrentRow()
                    'With GridView4

                    '    For b As Integer = 0 To gridView3.RowCount - 1
                    '        Dim Header As String = gridView3.GetRowCellValue(b, "Curr")
                    '        .Columns(Header).Width = 200
                    '        .Columns(Header).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    '        .Columns(Header).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


                    '        .Columns(Header).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    '        .Columns(Header).DisplayFormat.FormatString = "0:N2"
                    '    Next
                    'End With




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
            T_Dept.SetEditValue("1MKT,1PUR,")
        Else
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
            C_Term.Enabled = True
            T_Dept.SetEditValue("1PUR,")
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


                Call HitungTotal()
                Call TotalSumary()

            End If

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)

        End Try



    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub C_Amount_Barang_EditValueChanged(sender As Object, e As EventArgs) Handles C_Amount_Barang.EditValueChanged



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


        fc_Class.GetDataByID(fs_Code)
        If fc_Class.H_UserSubmition = False Then
            Dim result As DialogResult = XtraMessageBox.Show("Are You Sure To Approve " & fs_Code & "  ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                Try
                    fc_Class = New ClsCR_CreateUser
                    With fc_Class
                        .H_UserSubmition = 1
                    End With
                    fc_Class.UpdateUserSubmit(fs_Code)
                    bs_Filter = gh_Common.Username()
                    'GridDtl.DataSource = fc_Class_Head.Get_NPP()

                    IsClosed = True
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    Me.Hide()
                Catch ex As Exception
                    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try

            End If
        Else
            XtraMessageBox.Show("NPP '" & fs_Code & "' has been Submitted  ?", "Confirmation", MessageBoxButtons.OK)
        End If


    End Sub

End Class
