Imports DevExpress.XtraGrid
Public Class Frm_Input_NpwoDetail

    Dim fc_Class As New Cls_Npwo_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Nama As String
    Dim Machine As String
    Dim CycleTime As String
    Dim Cav As String
    Dim Weight As String
    Dim QtyMold As String
    Dim Material As String
    Dim LOI As String
    Dim Inj As Boolean
    Dim Pnt As Boolean
    Dim Chrome As Boolean
    Dim Assy As Boolean
    Dim Ultrasonic As Boolean
    Dim Vibration As Boolean
    Dim StatusMold As String
    Dim OrderMonth As String
    Dim Grid As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean
    Dim DtTabale As DataTable
    Dim H_Order As String

    Private Sub Frm_Input_NpwoDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        If IsNew Then
            TPartNo.EditValue = ""
            TPartName.EditValue = ""
            TMachine.EditValue = ""
            TCT.EditValue = ""
            TCav.EditValue = ""
            TWeight.EditValue = "0"
            TQtyMold.EditValue = ""
            TMaterial.EditValue = ""
            CInjection.Checked = False
            CPainting.Checked = False
            CChrome.Checked = False
            CAssy.Checked = False
            CUltrasonic.Checked = False
            CbVibration.Checked = False
            TStatusMold.EditValue = ""
            TOrder.EditValue = "0"
        Else
            TPartNo.Enabled = False
            TPartNo.EditValue = ID
            TPartName.EditValue = Nama
            TMachine.EditValue = Machine
            TCT.EditValue = CycleTime
            TCav.EditValue = Cav
            TWeight.EditValue = Weight
            TQtyMold.EditValue = QtyMold
            TMaterial.EditValue = Material
            TStatusMold.EditValue = StatusMold
            TOrder.EditValue = OrderMonth

            CInjection.Checked = Inj
            CPainting.Checked = Pnt
            CChrome.Checked = Chrome
            CAssy.Checked = Assy
            CUltrasonic.Checked = Ultrasonic
            CbVibration.Checked = Vibration
        End If

    End Sub

    Public Sub New(ByVal _ID As String,
                   ByVal _Nama As String,
                   ByVal _Machine As String,
                   ByVal _CycleTime As String,
                   ByVal _Cav As String,
                   ByVal _Weight As String,
                   ByVal _QtyMold As String,
                   ByVal _Material As String,
                   ByVal _Inj As Boolean,
                   ByVal _Paint As Boolean,
                   ByVal _Chrome As Boolean,
                   ByVal _Assy As Boolean,
                   ByVal _Ultrasonic As Boolean,
                   ByVal _Vibration As Boolean,
                   ByVal _StatusMold As String,
                   ByVal _OrderMonth As String,
                   ByVal _Type As String,
                    ByVal _LOI As Boolean,
                  ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        ID = _ID
        Nama = _Nama
        Machine = _Machine
        CycleTime = _CycleTime
        Cav = _Cav
        Weight = _Weight
        QtyMold = _QtyMold
        Material = _Material
        StatusMold = _StatusMold
        LOI =
        Inj = _Inj
        Pnt = _Paint
        Chrome = _Chrome
        Assy = _Assy
        Ultrasonic = _Ultrasonic
        Vibration = _Vibration
        StatusMold = _StatusMold
        OrderMonth = _OrderMonth
        IsNew = _IsNew
        Grid = _grid
        DtTabale = _dt

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If IsNew = True Then

            If TPartNo.Text = "" Then
                MessageBox.Show("Please Fill Part No",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1)
            ElseIf TWeight.Text = "" Then
                MessageBox.Show("Weight Must be Number",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Exclamation,
                                      MessageBoxDefaultButton.Button1)
            ElseIf TOrder.Text = "" Then
                MessageBox.Show("Order Must be Number",
                                     "Warning",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation,
                                     MessageBoxDefaultButton.Button1)
            Else
                For i As Integer = 0 To DtTabale.Rows.Count - 1
                    If TPartNo.EditValue.Trim = DtTabale.Rows(i).Item("Part No") Then
                        MessageBox.Show("" & TPartNo.Text & " Already exists",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next

                Dim dt As New DataTable
                dt = fc_Class.Cek_PartNo_Detail_Npwo(TPartNo.EditValue)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("" & TPartNo.Text & " Already exists",
                                       "Warning",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation,
                                       MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If

                Dim MyNewRow As DataRow
                MyNewRow = DtTabale.NewRow
                With MyNewRow
                    .Item("Part No") = TPartNo.EditValue.Trim
                    .Item("Part Name") = TPartName.EditValue.Trim
                    .Item("Machine") = TMachine.EditValue.Trim
                    .Item("C/T") = TCT.EditValue.Trim
                    .Item("Cav") = TCav.EditValue.Trim
                    .Item("Weight") = TWeight.EditValue.Trim
                    .Item("Qty Mold") = TQtyMold.EditValue.Trim
                    .Item("Material") = TMaterial.EditValue.Trim
                    .Item("Inj") = CInjection.CheckState
                    .Item("Painting") = CPainting.CheckState
                    .Item("Chrome") = CChrome.CheckState
                    .Item("Assy") = CAssy.CheckState
                    .Item("Ultrasonic") = CAssy.CheckState
                    .Item("Vibration") = CbVibration.CheckState
                    .Item("Status Mold") = TStatusMold.EditValue.Trim
                    .Item("Order Month") = TOrder.EditValue.Trim
                    .Item("LOI") = TLOI.EditValue.Trim

                End With


                DtTabale.Rows.Add(MyNewRow)
                DtTabale.AcceptChanges()
                TPartNo.EditValue = ""
                TPartName.EditValue = ""
                TWeight.EditValue = "0"
                TMaterial.EditValue = ""
                TStatusMold.EditValue = ""
                CAssy.Checked = False
                CbVibration.Checked = False
                CPainting.Checked = False
                CAssy.Checked = False
                CChrome.Checked = False
                CInjection.Checked = False
                TOrder.EditValue = H_Order

            End If


        Else

            For i As Integer = 0 To DtTabale.Rows.Count - 1
                If TPartNo.EditValue.Trim = DtTabale.Rows(i).Item("Part No") Then
                    With DtTabale.Rows(i)
                        .Item("Part Name") = TPartName.EditValue.Trim
                        .Item("Machine") = TMachine.EditValue.Trim
                        .Item("C/T") = TCT.EditValue.Trim
                        .Item("Cav") = TCav.EditValue.Trim
                        .Item("Weight") = TWeight.EditValue.Trim
                        .Item("Qty Mold") = TQtyMold.EditValue.Trim
                        .Item("Material") = TMaterial.EditValue.Trim
                        .Item("Inj") = CInjection.CheckState
                        .Item("Painting") = CPainting.CheckState
                        .Item("Chrome") = CChrome.CheckState
                        .Item("Assy") = CAssy.CheckState
                        .Item("Ultrasonic") = CAssy.CheckState
                        .Item("Vibration") = CbVibration.CheckState
                        .Item("Status Mold") = TStatusMold.EditValue.Trim
                        .Item("Order Month") = TOrder.EditValue.Trim
                        .Item("LOI") = TLOI.EditValue.Trim
                    End With

                End If
            Next


        End If

    End Sub
End Class