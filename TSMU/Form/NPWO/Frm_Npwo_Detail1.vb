Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Frm_Npwo_Detail1

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New Cls_Npwo_Detail
    Dim fc_Class_Head As New Cls_Npwo_Header
    Dim Fc_Clas_Col_Detail As Col_Cls_Npwo_Detail_NPWO
    Dim Fc_Clas_Col_Detail_1 As Col_Cls_Npwo_Detail_1_NPWO

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim dtGrid As New DataTable
    Dim dt As New DataTable
    Dim dtDetail As New DataTable

    Dim dtHeader As New DataTable
    Dim dtBayangan As New DataTable

    Dim frmInput As Frm_Get_Npp_Detail
    Dim frmInput1 As Frm_Input_NpwoDetail
    Dim frmInput2 As Frm_Input_NPPDetail

    Dim FormDetail As Integer = 0
    Dim dataSet As New DataSet



    'Dim DtGridNPWO As DataTable

    Private Sub Frm_Npw_Detail1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        Call FillComboNPP()
        'Call FillComboCategory()



        'Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub

    Private Sub FillComboNPP()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetNoNpp
            TNoNpp.Properties.DataSource = Nothing
            TNoNpp.Properties.DataSource = dt
            TNoNpp.Properties.ValueMember = "Value"
            TNoNpp.Properties.DisplayMember = "Value"
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CreateTableBarang()

        dt = New DataTable
        dt.Columns.AddRange(New DataColumn(17) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("IDB", GetType(String)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("C/T", GetType(Double)),
                                                           New DataColumn("Cav", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Qty Mold", GetType(Int32)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("Forecast", GetType(String)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Order Month", GetType(Int32))})





        dtDetail = New DataTable
        dtDetail.Columns.AddRange(New DataColumn(18) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("IDB1", GetType(String)),
                                                           New DataColumn("ID", GetType(String)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Machine", GetType(String)),
                                                           New DataColumn("C/T", GetType(Double)),
                                                           New DataColumn("Cav", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Qty Mold", GetType(Int32)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("Forecast", GetType(String)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Order Month", GetType(Int32))})


        dt.TableName = "Master"
        dtDetail.TableName = "Detail"
        dataSet.Tables.Add(dt)
        dataSet.Tables.Add(dtDetail)
        dataSet.Relations.Add("NPWO", dt.Columns("IDB"), dtDetail.Columns("IDB1"))

        'Grid.DataSource = dt
        Grid.DataSource = dataSet
        Grid.DataMember = "Master"
        GridView1.OptionsView.ShowAutoFilterRow = False



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

                Call Proc_EnableButtons(False, True, False, True, False, False, False, True, False, False, True)
                'TNpwo_No.Enabled = False
                'TCustomer.Enabled = False
                'TModel.Enabled = False
                Me.Text = "NPWO FORM -> " & fs_Code
            Else
                Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)

                Me.Text = "NPWO FORM "
            End If

            Call LoadTxtBox()
            Call LoadGrid(fc_Class.H_No_Npwo)

            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    TNpwo_No.EditValue = .H_No_Npwo
                    TNoNpp.EditValue = .H_No_NPP
                    TModelDesc.EditValue = .H_Model_Desc
                    TCustomer.EditValue = .H_Customer_Name
                    TModel.EditValue = .H_Model_Name
                    'TModelDesc.EditValue = .H_Model_Desc
                    TOrderMonth.EditValue = .H_Order_Month
                    TOrderMaxMonth.EditValue = .H_Order_Max_Month
                    TMp.EditValue = .H_MP
                    CBCad.Checked = .H_CAD_Data
                    CBDrawing.Checked = .H_Drawing
                    CBSample.Checked = .H_Sample
                    CBStr.Checked = .H_Special_Technical_Requires
                    CBTng.Checked = .H_Factory_Tsc_TNG
                    CBCkr.Checked = .H_Factory_Tsc_CKR
                    TCategory.EditValue = .H_Category_Class
                    'TTargetDr.EditValue = .H_TargetDRR
                    'TTargetQuot.EditValue = .H_TargetQuot
                End With

                If fc_Class.H_Approve = True Then
                    TRevisi.EditValue = fc_Class.H_Rev + 1
                Else
                    TRevisi.EditValue = fc_Class.H_Rev
                End If
                ' TRevisiInformasi.EditValue = ""
            Else
                TRevisi.EditValue = "0"
                TRevisi.EditValue = "New Model"
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub LoadGrid(NPwo_ As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                'Dim DtGridNPWO As New DataTable
                dt = fc_Class.Get_Detail_Npwo(NPwo_)
                Grid.DataSource = dt

                'dtBayangan = fc_Class.Get_Detail1_Npwo(NPwo_)
                'GridBayangan.DataSource = dtBayangan

                Cursor.Current = Cursors.Default
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub TNoNpp_EditValueChanged(sender As Object, e As EventArgs) Handles TNoNpp.EditValueChanged
        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dtHeader = fc_Class.GetNppByID(TNoNpp.EditValue)
            If dtHeader.Rows.Count > 0 Then
                TCustomer.EditValue = dtHeader.Rows(0).Item("Customer_Name")
                TModel.EditValue = dtHeader.Rows(0).Item("Model_Name")
                TModelDesc.EditValue = dtHeader.Rows(0).Item("Model_Desc")
                TOrderMonth.EditValue = dtHeader.Rows(0).Item("Order_Month")
                TOrderMaxMonth.EditValue = dtHeader.Rows(0).Item("Order_Max_Month")
                TCategory.EditValue = dtHeader.Rows(0).Item("Category_Class")
                CBDrawing.Checked = dtHeader.Rows(0).Item("Drawing")
                CBCad.Checked = dtHeader.Rows(0).Item("CAD_Data")
                CBSample.Checked = dtHeader.Rows(0).Item("Sample")
                CBStr.Checked = dtHeader.Rows(0).Item("Special_Technical_Requires")
                CBCkr.Checked = dtHeader.Rows(0).Item("Factory_Tsc_CKR")
                CBTng.Checked = dtHeader.Rows(0).Item("Factory_Tsc_TNG")
                TMp.EditValue = dtHeader.Rows(0).Item("MP")
                TTargetDr.EditValue = dtHeader.Rows(0).Item("TargetDRR")
                TTargetQuot.EditValue = dtHeader.Rows(0).Item("TargetQuot")

                If isUpdate = False Then
                    Call fc_Class.GetNpwoNoAuto(dtHeader.Rows(0).Item("Customer_Name"), dtHeader.Rows(0).Item("Model_Name"))
                    TNpwo_No.EditValue = fc_Class.H_No_Npwo
                End If


            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BDetail_Click(sender As Object, e As EventArgs) Handles BDetail.Click

        FormDetail = 1
        CallForm(TNoNpp.EditValue, "")


    End Sub
    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal Nama As String = "",
                        Optional ByVal Machine As String = "",
                        Optional ByVal cycleTime As String = "",
                        Optional ByVal Cav As String = "",
                        Optional ByVal Weight As String = "",
                        Optional ByVal QtyMold As String = "",
                        Optional ByVal Material As String = "",
                        Optional ByVal Inj As Boolean = False,
                        Optional ByVal Paint As Boolean = False,
                        Optional ByVal Chrome As Boolean = False,
                        Optional ByVal Assy As Boolean = False,
                        Optional ByVal Ultrasonic As Boolean = False,
                        Optional ByVal Vibration As Boolean = False,
                        Optional ByVal StatusMold As String = "",
                        Optional ByVal OrderMonth As String = "",
                        Optional ByVal LOI As String = "",
                        Optional ByVal Type As String = "",
                        Optional ByVal IsNew As Boolean = True)

        If FormDetail = 1 Then
            frmInput = New Frm_Get_Npp_Detail(ID, Nama, Material, Weight, Inj, Paint, Chrome, Assy, Ultrasonic, StatusMold, OrderMonth, IsNew, dt, Grid, dtDetail, Grid)
            frmInput.StartPosition = FormStartPosition.CenterScreen
            frmInput.MaximizeBox = False
            frmInput.ShowDialog()

        ElseIf FormDetail = 2 Then

            frmInput1 = New Frm_Input_NpwoDetail(ID, Nama, Machine, cycleTime, Cav, Weight, QtyMold, Material, Inj, Paint, Chrome, Assy, Ultrasonic, Vibration, StatusMold, OrderMonth, Type, LOI, IsNew, dt, Grid)
            frmInput1.StartPosition = FormStartPosition.CenterScreen
            frmInput1.MaximizeBox = False
            frmInput1.ShowDialog()

        End If

    End Sub

    Private Sub TPartNo_EditValueChanged(sender As Object, e As EventArgs) Handles TPartNo.EditValueChanged
        Try
            'Part No
            Dim Kode As String = (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "IDB")).ToString
            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()

            'For i As Integer = 0 To GridView2.RowCount - 1
            '    Dim kodeDetail As String = GridView2.GetRowCellValue(i, GridView2.Columns("IDB1")).ToString
            '    If Kode = kodeDetail Then
            '        GridView2.SetRowCellValue(i, GridView2.Columns("ID"), (GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Part No")).ToString)
            '    End If
            'Next
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

                MessageBox.Show("Please Fill Grid 1 ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub

                'ElseIf GridView2.RowCount = 0 Then

                '    MessageBox.Show("Please Fill Grid 2 ", "Warning",
                '                MessageBoxButtons.OK,
                '                MessageBoxIcon.Exclamation,
                '                MessageBoxDefaultButton.Button1)
                '    Exit Sub

            Else

                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Ensure that nothing is empty Of Description of Cost ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next


            End If

            If isUpdate = False Then

#Region "Insert"
                With fc_Class

                    .H_No_Npwo = TNpwo_No.EditValue
                    .H_No_NPP = TNoNpp.EditValue
                    .H_Model_Name = TModel.EditValue
                    .H_Model_Desc = TModelDesc.EditValue
                    .H_Customer_Name = TCustomer.EditValue
                    .H_Order_Month = TOrderMonth.EditValue
                    .H_Order_Max_Month = TOrderMaxMonth.EditValue
                    .H_MP = TMp.EditValue
                    .H_Drawing = CBDrawing.CheckState
                    .H_CAD_Data = CBCad.CheckState
                    .H_Sample = CBSample.CheckState
                    .H_Special_Technical_Requires = CBStr.CheckState
                    .H_Category_Class = TCategory.EditValue
                    .H_Factory_Tsc_TNG = CBTng.CheckState
                    .H_Factory_Tsc_CKR = CBCkr.CheckState
                    .H_Rev = 0
                    .H_Rev_Info = TRevInfo.EditValue

                End With
                'Colletion Detail
                fc_Class.Collection_Detail.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Fc_Clas_Col_Detail = New Col_Cls_Npwo_Detail_NPWO
                    With Fc_Clas_Col_Detail
                        .Join = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))

                        .No_Npwo = TNpwo_No.EditValue
                        .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                        .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                        .Cycle_Time = Convert.ToDouble(GridView1.GetRowCellValue(i, "C/T"))
                        .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                        .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                        .Qty_Mold = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty Mold"))
                        .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                        .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                        .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                        .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                        .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                        .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                        .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                        .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                        .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                        .LOI_Number = Convert.ToString(GridView1.GetRowCellValue(i, "LOI"))
                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail.Add(Fc_Clas_Col_Detail)

                Next

                'Colletion Detail_1

                fc_Class.Collection_Detail_1.Clear()
                'For i As Integer = 0 To GridView2.RowCount - 1

                '    Fc_Clas_Col_Detail_1 = New Col_Cls_Npwo_Detail_1_NPWO
                '    With Fc_Clas_Col_Detail_1

                '        .Join = Convert.ToString(GridView2.GetRowCellValue(i, "ID"))

                '        .No_Npwo = TNpwo_No.EditValue
                '        .ID = Convert.ToString(GridView2.GetRowCellValue(i, "ID"))
                '        .Part_No = Convert.ToString(GridView2.GetRowCellValue(i, "Part No"))
                '        .Part_Name = Convert.ToString(GridView2.GetRowCellValue(i, "Part Name"))
                '        .Machine = Convert.ToString(GridView2.GetRowCellValue(i, "Machine"))
                '        .Cycle_Time = Convert.ToDouble(GridView2.GetRowCellValue(i, "C/T"))
                '        .Cavity = Convert.ToString(GridView2.GetRowCellValue(i, "Cav"))
                '        .Weight = Convert.ToDouble(GridView2.GetRowCellValue(i, "Weight"))
                '        .Qty_Mold = Convert.ToDouble(GridView2.GetRowCellValue(i, "Qty Mold"))
                '        .Material_Resin = Convert.ToString(GridView2.GetRowCellValue(i, "Material"))
                '        .Injection = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Inj"))
                '        .Painting = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Painting"))
                '        .Chrome = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Chrome"))
                '        .Vibration = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Vibration"))
                '        .Assy = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Assy"))
                '        .Ultrasonic = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Ultrasonic"))
                '        .StatusMold = Convert.ToString(GridView2.GetRowCellValue(i, "Status Mold"))
                '        .OrderMonth = Convert.ToInt32(GridView2.GetRowCellValue(i, "Order Month"))
                '        .LOI_Number = Convert.ToString(GridView2.GetRowCellValue(i, "LOI"))
                '        .Rev = 0

                '    End With
                '    fc_Class.Collection_Detail_1.Add(Fc_Clas_Col_Detail_1)

                'Next

                fc_Class.Insert(TNpwo_No.EditValue)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class_Head.Get_NPWO()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
#End Region



#Region "Update"

            Else
                With fc_Class

                    .H_No_Npwo = TNpwo_No.EditValue
                    .H_No_NPP = TNoNpp.EditValue
                    .H_Model_Name = TModel.EditValue
                    .H_Model_Desc = TModelDesc.EditValue
                    .H_Customer_Name = TCustomer.EditValue
                    .H_Order_Month = TOrderMonth.EditValue
                    .H_Order_Max_Month = TOrderMaxMonth.EditValue
                    .H_MP = TMp.EditValue
                    .H_Drawing = CBDrawing.CheckState
                    .H_CAD_Data = CBCad.CheckState
                    .H_Sample = CBSample.CheckState
                    .H_Special_Technical_Requires = CBStr.CheckState
                    .H_Category_Class = TCategory.EditValue
                    .H_Factory_Tsc_TNG = CBTng.CheckState
                    .H_Factory_Tsc_CKR = CBCkr.CheckState
                    .H_Rev = 0
                    .H_Rev_Info = TRevInfo.EditValue

                End With
                'Colletion Detail
                fc_Class.Collection_Detail.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    Fc_Clas_Col_Detail = New Col_Cls_Npwo_Detail_NPWO
                    With Fc_Clas_Col_Detail
                        .Join = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))

                        .No_Npwo = TNpwo_No.EditValue
                        .Part_No = Convert.ToString(GridView1.GetRowCellValue(i, "Part No"))
                        .Part_Name = Convert.ToString(GridView1.GetRowCellValue(i, "Part Name"))
                        .Machine = Convert.ToString(GridView1.GetRowCellValue(i, "Machine"))
                        .Cycle_Time = Convert.ToDouble(GridView1.GetRowCellValue(i, "C/T"))
                        .Cavity = Convert.ToString(GridView1.GetRowCellValue(i, "Cav"))
                        .Weight = Convert.ToDouble(GridView1.GetRowCellValue(i, "Weight"))
                        .Qty_Mold = Convert.ToDouble(GridView1.GetRowCellValue(i, "Qty Mold"))
                        .Material_Resin = Convert.ToString(GridView1.GetRowCellValue(i, "Material"))
                        .Injection = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Inj"))
                        .Painting = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Painting"))
                        .Chrome = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Chrome"))
                        .Vibration = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Vibration"))
                        .Assy = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Assy"))
                        .Ultrasonic = Convert.ToBoolean(GridView1.GetRowCellValue(i, "Ultrasonic"))
                        .StatusMold = Convert.ToString(GridView1.GetRowCellValue(i, "Status Mold"))
                        .OrderMonth = Convert.ToInt32(GridView1.GetRowCellValue(i, "Order Month"))
                        .LOI_Number = Convert.ToString(GridView1.GetRowCellValue(i, "LOI"))
                        .Rev = 0

                    End With
                    fc_Class.Collection_Detail.Add(Fc_Clas_Col_Detail)

                Next

                'Colletion Detail_1

                fc_Class.Collection_Detail_1.Clear()
                'For i As Integer = 0 To GridView2.RowCount - 1

                '    Fc_Clas_Col_Detail_1 = New Col_Cls_Npwo_Detail_1_NPWO
                '    With Fc_Clas_Col_Detail_1

                '        .Join = Convert.ToString(GridView2.GetRowCellValue(i, "ID"))

                '        .No_Npwo = TNpwo_No.EditValue
                '        .ID = Convert.ToString(GridView2.GetRowCellValue(i, "ID"))
                '        .Part_No = Convert.ToString(GridView2.GetRowCellValue(i, "Part No"))
                '        .Part_Name = Convert.ToString(GridView2.GetRowCellValue(i, "Part Name"))
                '        .Machine = Convert.ToString(GridView2.GetRowCellValue(i, "Machine"))
                '        .Cycle_Time = Convert.ToDouble(GridView2.GetRowCellValue(i, "C/T"))
                '        .Cavity = Convert.ToString(GridView2.GetRowCellValue(i, "Cav"))
                '        .Weight = Convert.ToDouble(GridView2.GetRowCellValue(i, "Weight"))
                '        .Qty_Mold = Convert.ToDouble(GridView2.GetRowCellValue(i, "Qty Mold"))
                '        .Material_Resin = Convert.ToString(GridView2.GetRowCellValue(i, "Material"))
                '        .Injection = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Inj"))
                '        .Painting = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Painting"))
                '        .Chrome = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Chrome"))
                '        .Vibration = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Vibration"))
                '        .Assy = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Assy"))
                '        .Ultrasonic = Convert.ToBoolean(GridView2.GetRowCellValue(i, "Ultrasonic"))
                '        .StatusMold = Convert.ToString(GridView2.GetRowCellValue(i, "Status Mold"))
                '        .OrderMonth = Convert.ToInt32(GridView2.GetRowCellValue(i, "Order Month"))
                '        .LOI_Number = Convert.ToString(GridView2.GetRowCellValue(i, "LOI"))
                '        .Rev = 0

                '    End With
                '    fc_Class.Collection_Detail_1.Add(Fc_Clas_Col_Detail_1)

                'Next

                fc_Class.Update(TNpwo_No.EditValue)
                bs_Filter = gh_Common.GroupID
                GridDtl.DataSource = fc_Class_Head.Get_NPWO()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
#End Region


            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Grid_KeyDown(sender As Object, e As KeyEventArgs) Handles Grid.KeyDown
        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.RefreshData()

        End If
    End Sub

    Private Sub GridBayangan_KeyDown(sender As Object, e As KeyEventArgs)

        'If e.KeyData = Keys.Delete Then
        '    GridView2.DeleteRow(GridView2.FocusedRowHandle)
        '    GridView2.RefreshData()

        'End If

    End Sub

    Private Sub B_AddRows_Click(sender As Object, e As EventArgs) Handles B_AddRows.Click


        FormDetail = 2
        CallForm()

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Try


            FormDetail = 2

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim PartNo As String = ""
            Dim PartName As String = ""
            Dim Machine As String = ""
            Dim CycleTime As String = ""
            Dim Cav As String = ""
            Dim Weight As String = ""
            Dim QtyMold As String = ""
            Dim Material As String = ""
            Dim StatusMold As String = ""
            Dim Order As String = ""
            Dim LOI As String = ""
            Dim Inj As Boolean = True
            Dim Painting As Boolean = True
            Dim Chrome As Boolean = True
            Dim Assy As Boolean = True
            Dim Ultrasonic As Boolean = True
            Dim Vibration As Boolean = True



            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PartNo = GridView1.GetRowCellValue(rowHandle, "Part No")
                    PartName = GridView1.GetRowCellValue(rowHandle, "Part Name")
                    Machine = GridView1.GetRowCellValue(rowHandle, "Machine")
                    CycleTime = GridView1.GetRowCellValue(rowHandle, "C/T")
                    Cav = GridView1.GetRowCellValue(rowHandle, "Cav")
                    Weight = GridView1.GetRowCellValue(rowHandle, "Weight")
                    QtyMold = GridView1.GetRowCellValue(rowHandle, "Qty Mold")
                    Material = GridView1.GetRowCellValue(rowHandle, "Material")
                    Order = GridView1.GetRowCellValue(rowHandle, "Order Month")
                    LOI = GridView1.GetRowCellValue(rowHandle, "LOI")
                    Inj = GridView1.GetRowCellValue(rowHandle, "Inj")
                    Painting = GridView1.GetRowCellValue(rowHandle, "Painting")
                    Chrome = GridView1.GetRowCellValue(rowHandle, "Chrome")
                    Assy = GridView1.GetRowCellValue(rowHandle, "Assy")
                    Ultrasonic = GridView1.GetRowCellValue(rowHandle, "Ultrasonic")
                    Vibration = GridView1.GetRowCellValue(rowHandle, "Vibration")

                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallForm(PartNo, PartName, Machine, CycleTime, Cav, Weight, QtyMold, Material, Inj, Painting, Chrome, Assy, Ultrasonic, Vibration, StatusMold, Order, "", LOI, False)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub
End Class
