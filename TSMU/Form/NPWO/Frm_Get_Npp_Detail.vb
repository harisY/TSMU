Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Public Class Frm_Get_Npp_Detail

    Dim fc_Class As New Cls_Npwo_Detail
    Dim fc_ClassNpp As New Cls_NPP_Detail

    Dim DtGridNPWO As DataTable

    Dim ID As String
    Dim Nama As String
    Dim Material As String
    Dim Weight As String
    Dim Inj As Boolean
    Dim Pnt As Boolean
    Dim Chrome As Boolean
    Dim Assy As Boolean
    Dim Ultrasonic As Boolean
    Dim StatusMold As String
    Dim OrderMonth As String
    Dim Grid1 As GridControl
    Dim Grid_V As DataGridView
    Dim IsNew As Boolean

    Dim GridBayangan As GridControl
    Dim dtBayangan As DataTable

    Dim DtTabale As DataTable
    Dim dt As DataTable
    Dim dtNpwoDetail As DataTable

    Public Sub New(ByVal _ID As String,
                   ByVal _Nama As String,
                   ByVal _Material As String,
                   ByVal _Weight As String,
                   ByVal _Inj As Boolean,
                   ByVal _Paint As Boolean,
                   ByVal _Chrome As Boolean,
                   ByVal _Assy As Boolean,
                   ByVal _Ultrasonic As Boolean,
                   ByVal _StatusMold As String,
                   ByVal _OrderMonth As String,
                   ByVal _IsNew As Boolean,
                   ByRef _dt As DataTable,
                   ByRef _grid As GridControl,
                   ByRef _dtBayangan As DataTable,
                   ByRef _gridBayangan As GridControl)

        ' This call is required by the designer.
        InitializeComponent()

        ID = _ID
        Nama = _Nama
        Material = _Material
        Weight = _Weight
        Inj = _Inj
        Pnt = _Paint
        Chrome = _Chrome
        Assy = _Assy
        Ultrasonic = _Ultrasonic
        StatusMold = _StatusMold
        OrderMonth = _OrderMonth
        IsNew = _IsNew
        Grid1 = _grid
        DtTabale = _dt

        GridBayangan = _gridBayangan

        dtBayangan = _dtBayangan


    End Sub

    Private Sub Frm_Get_Npp_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'RBSingle.Checked = True

        CreateTableBarang()

        If ID <> "" Then
            Call LoadGrid(ID)
        End If

    End Sub

    Private Sub LoadGrid(NPP_ As String)

        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dt = fc_ClassNpp.Get_Detail_NPP(NPP_)
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub CreateTableBarang()

        dt = New DataTable


        dt.Columns.AddRange(New DataColumn(15) {New DataColumn("Part No", GetType(String)),
                                                           New DataColumn("Check", GetType(Boolean)),
                                                           New DataColumn("Part Name", GetType(String)),
                                                           New DataColumn("Weight", GetType(Double)),
                                                           New DataColumn("Material", GetType(String)),
                                                           New DataColumn("Inj", GetType(Boolean)),
                                                           New DataColumn("Painting", GetType(Boolean)),
                                                           New DataColumn("Chrome", GetType(Boolean)),
                                                           New DataColumn("Assy", GetType(Boolean)),
                                                           New DataColumn("Status Mold", GetType(String)),
                                                           New DataColumn("Ultrasonic", GetType(Boolean)),
                                                           New DataColumn("Vibration", GetType(Boolean)),
                                                           New DataColumn("Mold No", GetType(String)),
                                                           New DataColumn("Npp No", GetType(String)),
                                                           New DataColumn("Group ID", GetType(String)),
                                                           New DataColumn("Order Month", GetType(Int32))})
        Grid.DataSource = dt
        GridView1.OptionsView.ShowAutoFilterRow = True

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click



#Region "Rubah"

        '        Dim MyNewRow As DataRow

        '        dtNpwoDetail = fc_Class.GetNoNpp
        '        If IsNew = True Then

        '            Dim K As Integer = 0
        '            Dim q As Integer = GridView1.RowCount

        '            While K < q
        '                Dim chkSelect As Boolean = False
        '                chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(K, GridView1.Columns("Check")))

        '                If chkSelect = True Then
        '                    For j As Integer = 0 To dt.Rows.Count - 1
        '                        If dt.Rows.Count > 0 Then

        '                        End If


        '                        Dim b As String = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                        Dim c As String = dt.Rows(j).Item("Part No")

        '                        If Trim(b).ToString = Trim(c).ToString Then
        '                            GoTo Lanjut1
        '                        End If


        '                    Next

        '                    MyNewRow = dt.NewRow
        '                    With MyNewRow
        '                        .Item("IDB1") = ID.ToString
        '                        .Item("ID") = ID.ToString
        '                        .Item("Part No") = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                        .Item("Part Name") = GridView1.GetRowCellValue(K, GridView1.Columns("Part Name")).ToString
        '                        .Item("Weight") = GridView1.GetRowCellValue(K, GridView1.Columns("Weight")).ToString
        '                        .Item("Material") = GridView1.GetRowCellValue(K, GridView1.Columns("Material")).ToString
        '                        .Item("Inj") = GridView1.GetRowCellValue(K, GridView1.Columns("Inj"))
        '                        .Item("Painting") = GridView1.GetRowCellValue(K, GridView1.Columns("Painting")).ToString
        '                        .Item("Chrome") = GridView1.GetRowCellValue(K, GridView1.Columns("Chrome")).ToString
        '                        .Item("Assy") = GridView1.GetRowCellValue(K, GridView1.Columns("Assy")).ToString

        '                        .Item("Ultrasonic") = GridView1.GetRowCellValue(K, GridView1.Columns("Ultrasonic"))
        '                        .Item("Vibration") = GridView1.GetRowCellValue(K, GridView1.Columns("Vibration"))
        '                        .Item("Order Month") = GridView1.GetRowCellValue(K, GridView1.Columns("Order Month"))
        '                        .Item("C/T") = "0"
        '                        .Item("Weight") = "0"
        '                        .Item("Qty Mold") = "0"
        '                    End With

        '                    dt.Rows.Add(MyNewRow)
        '                    dt.AcceptChanges()


        '                End If
        'Lanjut1:
        '                K = K + 1
        '            End While

        '        End If

#End Region



#Region "Before"

        '        Dim MyNewRow As DataRow
        '        Dim MyNewRowBayangan As DataRow

        '        If IsNew = True Then


        '            If RBGroup.Checked = False And RBSingle.Checked = False Then
        '                MessageBox.Show("Please Select Input Type",
        '                            "Warning",
        '                            MessageBoxButtons.OK,
        '                            MessageBoxIcon.Exclamation,
        '                            MessageBoxDefaultButton.Button1)
        '                Exit Sub
        '            ElseIf RBGroup.Checked = True And RBSingle.Checked = False Then
        '                If DtTabale.Rows.Count <= 0 Then

        '                    Dim ID As String = ""
        '                    Dim Inj As Boolean = False
        '                    Dim paint As Boolean = False
        '                    Dim chrome As Boolean = False
        '                    Dim assy As Boolean = False
        '                    Dim ultra As Boolean = False
        '                    Dim vibra As Boolean = False

        '                    MyNewRow = DtTabale.NewRow
        '                    MyNewRowBayangan = dtBayangan.NewRow

        '                    Dim count As Integer = 0

        '                    For i As Integer = 0 To GridView1.RowCount - 1
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Check")))
        '                        If chkSelect = True Then

        '                            With MyNewRow
        '                                .Item("IDB") = .Item("Part No") & GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString & "-"
        '                                .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString & "-"
        '                                .Item("Part Name") = GridView1.GetRowCellValue(i, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(i, GridView1.Columns("Material"))
        '                                Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Inj")))
        '                                paint = paint Or GridView1.GetRowCellValue(i, GridView1.Columns("Painting"))
        '                                chrome = chrome Or GridView1.GetRowCellValue(i, GridView1.Columns("Chrome"))
        '                                assy = assy Or GridView1.GetRowCellValue(i, GridView1.Columns("Assy"))

        '                                ultra = ultra Or GridView1.GetRowCellValue(i, GridView1.Columns("Ultrasonic"))
        '                                vibra = vibra Or GridView1.GetRowCellValue(i, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(i, GridView1.Columns("Order Month"))

        '                                .Item("Inj") = Inj
        '                                .Item("Painting") = paint
        '                                .Item("Chrome") = chrome
        '                                .Item("Assy") = assy
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                                .Item("Ultrasonic") = ultra
        '                                .Item("Vibration") = vibra

        '                            End With

        '                            count = count + 1

        '                        End If
        '                    Next

        '                    If count > 0 Then
        '                        DtTabale.Rows.Add(MyNewRow)
        '                        DtTabale.AcceptChanges()
        '                        ID = MyNewRow.Item("Part No")
        '                    End If


        '                    For k As Integer = 0 To GridView1.RowCount - 1
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(k, GridView1.Columns("Check")))
        '                        If chkSelect = True Then
        '                            MyNewRowBayangan = dtBayangan.NewRow
        '                            With MyNewRowBayangan
        '                                .Item("IDB1") = ID.ToString
        '                                .Item("ID") = ID.ToString
        '                                .Item("Part No") = GridView1.GetRowCellValue(k, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(k, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(k, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(k, GridView1.Columns("Material")).ToString
        '                                .Item("Inj") = GridView1.GetRowCellValue(k, GridView1.Columns("Inj"))
        '                                .Item("Painting") = GridView1.GetRowCellValue(k, GridView1.Columns("Painting")).ToString
        '                                .Item("Chrome") = GridView1.GetRowCellValue(k, GridView1.Columns("Chrome")).ToString
        '                                .Item("Assy") = GridView1.GetRowCellValue(k, GridView1.Columns("Assy")).ToString
        '                                .Item("Ultrasonic") = GridView1.GetRowCellValue(k, GridView1.Columns("Ultrasonic"))
        '                                .Item("Vibration") = GridView1.GetRowCellValue(k, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(k, GridView1.Columns("Order Month"))
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                            End With
        '                            dtBayangan.Rows.Add(MyNewRowBayangan)
        '                            dtBayangan.AcceptChanges()
        '                        End If
        '                    Next


        '                Else

        '                    Dim ID As String = ""

        '                    Dim Inj As Boolean = False
        '                    Dim paint As Boolean = False
        '                    Dim chrome As Boolean = False
        '                    Dim assy As Boolean = False
        '                    Dim ultra As Boolean = False
        '                    Dim vibra As Boolean = False

        '                    MyNewRow = DtTabale.NewRow


        '                    Dim Count1 As New Integer
        '                    Count1 = 0
        '                    Dim L As Integer = 0
        '                    Dim a As Integer = GridView1.RowCount

        '                    While L < a
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(L, GridView1.Columns("Check")))

        '                        If chkSelect = True Then
        '                            For j As Integer = 0 To dtBayangan.Rows.Count - 1

        '                                Dim b As String = GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString
        '                                Dim c As String = dtBayangan.Rows(j).Item("Part No")

        '                                If Trim(b).ToString = Trim(c).ToString Then
        '                                    GoTo Lanjut
        '                                End If
        '                            Next


        '                            With MyNewRow
        '                                .Item("IDB") = .Item("Part No") & GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString & "-"
        '                                .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString & "-"
        '                                .Item("Part Name") = GridView1.GetRowCellValue(L, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(L, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(L, GridView1.Columns("Material")).ToString
        '                                Inj = Inj Or GridView1.GetRowCellValue(L, GridView1.Columns("Inj"))
        '                                paint = paint Or GridView1.GetRowCellValue(L, GridView1.Columns("Painting")).ToString
        '                                chrome = chrome Or GridView1.GetRowCellValue(L, GridView1.Columns("Chrome")).ToString
        '                                assy = assy Or GridView1.GetRowCellValue(L, GridView1.Columns("Assy")).ToString

        '                                ultra = ultra Or GridView1.GetRowCellValue(L, GridView1.Columns("Ultrasonic"))
        '                                vibra = vibra Or GridView1.GetRowCellValue(L, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(L, GridView1.Columns("Order Month"))

        '                                .Item("Inj") = Inj
        '                                .Item("Painting") = paint
        '                                .Item("Chrome") = chrome
        '                                .Item("Assy") = assy
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                                .Item("Ultrasonic") = ultra
        '                                .Item("Vibration") = vibra
        '                                Count1 = Count1 + 1
        '                            End With
        '                        End If
        'Lanjut:
        '                        L = L + 1
        '                    End While

        '                    If Count1 > 0 Then
        '                        DtTabale.Rows.Add(MyNewRow)
        '                        DtTabale.AcceptChanges()
        '                        ID = MyNewRow.Item("Part No")
        '                        Count1 = 0
        '                    End If


        '                    Dim K As Integer = 0
        '                    Dim q As Integer = GridView1.RowCount

        '                    While K < q
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(K, GridView1.Columns("Check")))

        '                        If chkSelect = True Then
        '                            For j As Integer = 0 To dtBayangan.Rows.Count - 1

        '                                Dim b As String = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                Dim c As String = dtBayangan.Rows(j).Item("Part No")

        '                                If Trim(b).ToString = Trim(c).ToString Then
        '                                    GoTo Lanjut1
        '                                End If
        '                            Next

        '                            MyNewRowBayangan = dtBayangan.NewRow
        '                            With MyNewRowBayangan
        '                                .Item("IDB1") = ID.ToString
        '                                .Item("ID") = ID.ToString
        '                                .Item("Part No") = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(K, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(K, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(K, GridView1.Columns("Material")).ToString
        '                                .Item("Inj") = GridView1.GetRowCellValue(K, GridView1.Columns("Inj"))
        '                                .Item("Painting") = GridView1.GetRowCellValue(K, GridView1.Columns("Painting")).ToString
        '                                .Item("Chrome") = GridView1.GetRowCellValue(K, GridView1.Columns("Chrome")).ToString
        '                                .Item("Assy") = GridView1.GetRowCellValue(K, GridView1.Columns("Assy")).ToString

        '                                .Item("Ultrasonic") = GridView1.GetRowCellValue(K, GridView1.Columns("Ultrasonic"))
        '                                .Item("Vibration") = GridView1.GetRowCellValue(K, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(K, GridView1.Columns("Order Month"))
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                            End With
        '                            dtBayangan.Rows.Add(MyNewRowBayangan)
        '                            dtBayangan.AcceptChanges()


        '                        End If
        'Lanjut1:
        '                        K = K + 1
        '                    End While

        '                End If

        '            ElseIf RBGroup.Checked = False And RBSingle.Checked = True Then
        '                If DtTabale.Rows.Count <= 0 Then

        '                    Dim ID As String = ""
        '                    Dim Inj As Boolean = False
        '                    Dim paint As Boolean = False
        '                    Dim chrome As Boolean = False
        '                    Dim assy As Boolean = False
        '                    Dim ultra As Boolean = False
        '                    Dim vibra As Boolean = False

        '                    MyNewRow = DtTabale.NewRow
        '                    MyNewRowBayangan = dtBayangan.NewRow

        '                    Dim count As Integer = 0

        '                    For i As Integer = 0 To GridView1.RowCount - 1
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Check")))
        '                        If chkSelect = True Then
        '                            MyNewRow = DtTabale.NewRow
        '                            With MyNewRow
        '                                .Item("IDB") = GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString
        '                                .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(i, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(i, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(i, GridView1.Columns("Material"))
        '                                Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Inj")))
        '                                paint = paint Or GridView1.GetRowCellValue(i, GridView1.Columns("Painting"))
        '                                chrome = chrome Or GridView1.GetRowCellValue(i, GridView1.Columns("Chrome"))
        '                                assy = assy Or GridView1.GetRowCellValue(i, GridView1.Columns("Assy"))

        '                                ultra = ultra Or GridView1.GetRowCellValue(i, GridView1.Columns("Ultrasonic"))
        '                                vibra = vibra Or GridView1.GetRowCellValue(i, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(i, GridView1.Columns("Order Month"))

        '                                .Item("Inj") = Inj
        '                                .Item("Painting") = paint
        '                                .Item("Chrome") = chrome
        '                                .Item("Assy") = assy
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                                .Item("Ultrasonic") = ultra
        '                                .Item("Vibration") = vibra

        '                            End With

        '                            count = count + 1
        '                            If count > 0 Then
        '                                DtTabale.Rows.Add(MyNewRow)
        '                                DtTabale.AcceptChanges()
        '                                ID = MyNewRow.Item("Part No")
        '                            End If

        '                        End If
        '                    Next

        '                    For k As Integer = 0 To GridView1.RowCount - 1
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(k, GridView1.Columns("Check")))
        '                        If chkSelect = True Then
        '                            MyNewRowBayangan = dtBayangan.NewRow
        '                            With MyNewRowBayangan
        '                                .Item("IDB1") = GridView1.GetRowCellValue(k, GridView1.Columns("Part No")).ToString
        '                                .Item("ID") = GridView1.GetRowCellValue(k, GridView1.Columns("Part No")).ToString
        '                                .Item("Part No") = GridView1.GetRowCellValue(k, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(k, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(k, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(k, GridView1.Columns("Material")).ToString
        '                                .Item("Inj") = GridView1.GetRowCellValue(k, GridView1.Columns("Inj"))
        '                                .Item("Painting") = GridView1.GetRowCellValue(k, GridView1.Columns("Painting")).ToString
        '                                .Item("Chrome") = GridView1.GetRowCellValue(k, GridView1.Columns("Chrome")).ToString
        '                                .Item("Assy") = GridView1.GetRowCellValue(k, GridView1.Columns("Assy")).ToString
        '                                .Item("Ultrasonic") = GridView1.GetRowCellValue(k, GridView1.Columns("Ultrasonic"))
        '                                .Item("Vibration") = GridView1.GetRowCellValue(k, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(k, GridView1.Columns("Order Month"))
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                            End With
        '                            dtBayangan.Rows.Add(MyNewRowBayangan)
        '                            dtBayangan.AcceptChanges()
        '                        End If
        '                    Next


        '                Else

        '                    Dim ID As String = ""

        '                    Dim Inj As Boolean = False
        '                    Dim paint As Boolean = False
        '                    Dim chrome As Boolean = False
        '                    Dim assy As Boolean = False
        '                    Dim ultra As Boolean = False
        '                    Dim vibra As Boolean = False

        '                    MyNewRow = DtTabale.NewRow


        '                    Dim Count1 As New Integer
        '                    Count1 = 0
        '                    Dim L As Integer = 0
        '                    Dim a As Integer = GridView1.RowCount

        '                    While L < a
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(L, GridView1.Columns("Check")))

        '                        If chkSelect = True Then
        '                            For j As Integer = 0 To dtBayangan.Rows.Count - 1

        '                                Dim b As String = GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString
        '                                Dim c As String = dtBayangan.Rows(j).Item("Part No")

        '                                If Trim(b).ToString = Trim(c).ToString Then
        '                                    GoTo Lanjut2
        '                                End If
        '                            Next

        '                            MyNewRow = DtTabale.NewRow
        '                            With MyNewRow
        '                                .Item("IDB") = .Item("Part No") & GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString
        '                                .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(L, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(L, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(L, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(L, GridView1.Columns("Material")).ToString
        '                                Inj = Inj Or GridView1.GetRowCellValue(L, GridView1.Columns("Inj"))
        '                                paint = paint Or GridView1.GetRowCellValue(L, GridView1.Columns("Painting")).ToString
        '                                chrome = chrome Or GridView1.GetRowCellValue(L, GridView1.Columns("Chrome")).ToString
        '                                assy = assy Or GridView1.GetRowCellValue(L, GridView1.Columns("Assy")).ToString

        '                                ultra = ultra Or GridView1.GetRowCellValue(L, GridView1.Columns("Ultrasonic"))
        '                                vibra = vibra Or GridView1.GetRowCellValue(L, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(L, GridView1.Columns("Order Month"))

        '                                .Item("Inj") = Inj
        '                                .Item("Painting") = paint
        '                                .Item("Chrome") = chrome
        '                                .Item("Assy") = assy
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                                .Item("Ultrasonic") = ultra
        '                                .Item("Vibration") = vibra
        '                                Count1 = Count1 + 1
        '                            End With

        '                            If Count1 > 0 Then
        '                                DtTabale.Rows.Add(MyNewRow)
        '                                DtTabale.AcceptChanges()
        '                                ID = MyNewRow.Item("Part No")
        '                                Count1 = 0
        '                            End If
        '                        End If
        'Lanjut2:
        '                        L = L + 1
        '                    End While




        '                    Dim K As Integer = 0
        '                    Dim q As Integer = GridView1.RowCount

        '                    While K < q
        '                        Dim chkSelect As Boolean = False
        '                        chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(K, GridView1.Columns("Check")))

        '                        If chkSelect = True Then
        '                            For j As Integer = 0 To dtBayangan.Rows.Count - 1

        '                                Dim b As String = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                Dim c As String = dtBayangan.Rows(j).Item("Part No")

        '                                If Trim(b).ToString = Trim(c).ToString Then
        '                                    GoTo Lanjut3
        '                                End If
        '                            Next

        '                            MyNewRowBayangan = dtBayangan.NewRow
        '                            With MyNewRowBayangan
        '                                .Item("IDB1") = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                .Item("ID") = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                .Item("Part No") = GridView1.GetRowCellValue(K, GridView1.Columns("Part No")).ToString
        '                                .Item("Part Name") = GridView1.GetRowCellValue(K, GridView1.Columns("Part Name")).ToString
        '                                .Item("Weight") = GridView1.GetRowCellValue(K, GridView1.Columns("Weight")).ToString
        '                                .Item("Material") = GridView1.GetRowCellValue(K, GridView1.Columns("Material")).ToString
        '                                .Item("Inj") = GridView1.GetRowCellValue(K, GridView1.Columns("Inj"))
        '                                .Item("Painting") = GridView1.GetRowCellValue(K, GridView1.Columns("Painting")).ToString
        '                                .Item("Chrome") = GridView1.GetRowCellValue(K, GridView1.Columns("Chrome")).ToString
        '                                .Item("Assy") = GridView1.GetRowCellValue(K, GridView1.Columns("Assy")).ToString

        '                                .Item("Ultrasonic") = GridView1.GetRowCellValue(K, GridView1.Columns("Ultrasonic"))
        '                                .Item("Vibration") = GridView1.GetRowCellValue(K, GridView1.Columns("Vibration"))
        '                                .Item("Order Month") = GridView1.GetRowCellValue(K, GridView1.Columns("Order Month"))
        '                                .Item("C/T") = "0"
        '                                .Item("Weight") = "0"
        '                                .Item("Qty Mold") = "0"
        '                            End With
        '                            dtBayangan.Rows.Add(MyNewRowBayangan)
        '                            dtBayangan.AcceptChanges()


        '                        End If
        'Lanjut3:
        '                        K = K + 1
        '                    End While

        '                End If

        '            End If
        '        End If

#End Region


        Dim MyNewRow As DataRow
        Dim MyNewRowBayangan As DataRow

        If IsNew = True Then

            Dim ID As String = ""
            Dim Inj As Boolean = False
            Dim paint As Boolean = False
            Dim chrome As Boolean = False
            Dim assy As Boolean = False
            Dim ultra As Boolean = False
            Dim vibra As Boolean = False

            MyNewRow = DtTabale.NewRow
            MyNewRowBayangan = dtBayangan.NewRow

            Dim count As Integer = 0

            Dim CekPartNo As String = ""
            Dim Group As String = ""
            Dim chkSelect As Boolean
            Dim Group2 As String = ""
            Dim chkSelect2 As Boolean

            For i As Integer = 0 To GridView1.RowCount - 1
                chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Check")))
                Group = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns("Group ID")))
                CekPartNo = Convert.ToString(GridView1.GetRowCellValue(i, GridView1.Columns("Part No")))

                If chkSelect = True Then

                    If DtTabale.Rows.Count <= 0 Then
                        MyNewRow = DtTabale.NewRow

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    With MyNewRow
                                        .Item("IDB") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                        Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                        paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                        chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                        assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))

                                        ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))

                                        .Item("Inj") = Inj
                                        .Item("Painting") = paint
                                        .Item("Chrome") = chrome
                                        .Item("Assy") = assy
                                        .Item("C/T") = "0"
                                        .Item("Weight") = "0"
                                        .Item("Qty Mold") = "0"
                                        .Item("Ultrasonic") = ultra
                                        .Item("Vibration") = vibra

                                    End With

                                    'MyNewRowBayangan = dtBayangan.NewRow
                                    'With MyNewRowBayangan
                                    '    .Item("IDB1") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                    '    .Item("ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                    '    .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                    '    .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                    '    .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                    '    .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                    '    .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                    '    .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                    '    .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                    '    .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                    '    .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                    '    .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                    '    .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                    '    .Item("C/T") = "0"
                                    '    .Item("Weight") = "0"
                                    '    .Item("Qty Mold") = "0"

                                    'End With
                                    'dtBayangan.Rows.Add(MyNewRowBayangan)
                                    'dtBayangan.AcceptChanges()
                                End If
                            End If
                        Next
                        DtTabale.Rows.Add(MyNewRow)
                        DtTabale.AcceptChanges()
                        ID = MyNewRow.Item("Part No")

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    'With MyNewRow
                                    '    .Item("IDB") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                    '    .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                    '    .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                    '    .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                    '    .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                    '    Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                    '    paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                    '    chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                    '    assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))

                                    '    ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                    '    vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                    '    .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))

                                    '    .Item("Inj") = Inj
                                    '    .Item("Painting") = paint
                                    '    .Item("Chrome") = chrome
                                    '    .Item("Assy") = assy
                                    '    .Item("C/T") = "0"
                                    '    .Item("Weight") = "0"
                                    '    .Item("Qty Mold") = "0"
                                    '    .Item("Ultrasonic") = ultra
                                    '    .Item("Vibration") = vibra

                                    'End With

                                    MyNewRowBayangan = dtBayangan.NewRow
                                    With MyNewRowBayangan
                                        .Item("IDB1") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                        .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                        .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                        .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                        .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                        .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("C/T") = "0"
                                        .Item("Weight") = "0"
                                        .Item("Qty Mold") = "0"

                                    End With
                                    dtBayangan.Rows.Add(MyNewRowBayangan)
                                    dtBayangan.AcceptChanges()
                                End If
                            End If
                        Next




                    Else
                        Dim CekPartNo2 As String = ""
                        For k As Integer = 0 To dtBayangan.Rows.Count - 1
                            CekPartNo2 = dtBayangan.Rows(k).Item("Part No")
                            If CekPartNo = CekPartNo2 Then
                                GoTo Lanjut
                            End If
                        Next

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    MyNewRow = DtTabale.NewRow
                                    With MyNewRow
                                        .Item("IDB") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                        Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                        paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                        chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                        assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))
                                        ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("Inj") = Inj
                                        .Item("Painting") = paint
                                        .Item("Chrome") = chrome
                                        .Item("Assy") = assy
                                        .Item("C/T") = "0"
                                        .Item("Weight") = "0"
                                        .Item("Qty Mold") = "0"
                                        .Item("Ultrasonic") = ultra
                                        .Item("Vibration") = vibra
                                    End With

                                    'MyNewRowBayangan = dtBayangan.NewRow
                                    'With MyNewRowBayangan
                                    '    .Item("IDB1") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                    '    .Item("ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                    '    .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                    '    .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                    '    .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                    '    .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                    '    .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                    '    .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                    '    .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                    '    .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                    '    .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                    '    .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                    '    .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                    '    .Item("C/T") = "0"
                                    '    .Item("Weight") = "0"
                                    '    .Item("Qty Mold") = "0"

                                    'End With
                                    'dtBayangan.Rows.Add(MyNewRowBayangan)
                                    'dtBayangan.AcceptChanges()

                                End If
                            End If
                        Next
                        DtTabale.Rows.Add(MyNewRow)
                        DtTabale.AcceptChanges()
                        ID = MyNewRow.Item("Part No")

                        For j As Integer = 0 To GridView1.RowCount - 1
                            chkSelect2 = Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Check")))
                            Group2 = Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")))
                            If chkSelect2 = True Then
                                If Group2 = Group Then
                                    'MyNewRow = DtTabale.NewRow
                                    'With MyNewRow
                                    '    .Item("IDB") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                    '    .Item("Part No") = .Item("Part No") & GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString & " - "
                                    '    .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                    '    .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                    '    .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material"))
                                    '    Inj = Inj Or Convert.ToBoolean(GridView1.GetRowCellValue(j, GridView1.Columns("Inj")))
                                    '    paint = paint Or GridView1.GetRowCellValue(j, GridView1.Columns("Painting"))
                                    '    chrome = chrome Or GridView1.GetRowCellValue(j, GridView1.Columns("Chrome"))
                                    '    assy = assy Or GridView1.GetRowCellValue(j, GridView1.Columns("Assy"))
                                    '    ultra = ultra Or GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                    '    vibra = vibra Or GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                    '    .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                    '    .Item("Inj") = Inj
                                    '    .Item("Painting") = paint
                                    '    .Item("Chrome") = chrome
                                    '    .Item("Assy") = assy
                                    '    .Item("C/T") = "0"
                                    '    .Item("Weight") = "0"
                                    '    .Item("Qty Mold") = "0"
                                    '    .Item("Ultrasonic") = ultra
                                    '    .Item("Vibration") = vibra
                                    'End With

                                    MyNewRowBayangan = dtBayangan.NewRow
                                    With MyNewRowBayangan
                                        .Item("IDB1") = GridView1.GetRowCellValue(j, GridView1.Columns("Group ID")).ToString
                                        .Item("ID") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part No") = GridView1.GetRowCellValue(j, GridView1.Columns("Part No")).ToString
                                        .Item("Part Name") = GridView1.GetRowCellValue(j, GridView1.Columns("Part Name")).ToString
                                        .Item("Weight") = GridView1.GetRowCellValue(j, GridView1.Columns("Weight")).ToString
                                        .Item("Material") = GridView1.GetRowCellValue(j, GridView1.Columns("Material")).ToString
                                        .Item("Inj") = GridView1.GetRowCellValue(j, GridView1.Columns("Inj"))
                                        .Item("Painting") = GridView1.GetRowCellValue(j, GridView1.Columns("Painting")).ToString
                                        .Item("Chrome") = GridView1.GetRowCellValue(j, GridView1.Columns("Chrome")).ToString
                                        .Item("Assy") = GridView1.GetRowCellValue(j, GridView1.Columns("Assy")).ToString
                                        .Item("Ultrasonic") = GridView1.GetRowCellValue(j, GridView1.Columns("Ultrasonic"))
                                        .Item("Vibration") = GridView1.GetRowCellValue(j, GridView1.Columns("Vibration"))
                                        .Item("Order Month") = GridView1.GetRowCellValue(j, GridView1.Columns("Order Month"))
                                        .Item("C/T") = "0"
                                        .Item("Weight") = "0"
                                        .Item("Qty Mold") = "0"

                                    End With
                                    dtBayangan.Rows.Add(MyNewRowBayangan)
                                    dtBayangan.AcceptChanges()

                                End If
                            End If
                        Next

                    End If
                End If
Lanjut:
            Next
        Else
        End If
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub
End Class