Imports DevExpress.XtraSplashScreen

Public Class frmSales_ForecastPrice
    Dim ff_Detail As frmSales_ForecastPrice_details
    Dim dtGrid As DataTable
    Dim ObjForecast As New forecast_price_models
    Private Sub frmSales_ForecastPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
        'AturGrid(Grid, Me)
        'ProgressBar1.Location = New Point(500, 500)
        'CenterControl()
        'ProgressBar1.Visible = False
    End Sub

    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            dtGrid = ObjForecast.GetAllDataGrid(bs_Filter)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If

            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
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
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Forecast/Price"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcel1
        frmExcel = New FrmSystemExcel1(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        If frmExcel.tab = 0 Then
            strTahun = frmExcel.Tahun
            strCustomer = frmExcel.Customer
            Bulan = frmExcel.Bulan

            Try
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                If strCustomer <> "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "' AND [Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer = "" AndAlso strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "'"
                    dtFilter = dv.ToTable
                ElseIf strCustomer <> "" AndAlso strTahun = "" Then
                    dv.RowFilter = "[Cust ID] = '" & strCustomer & "'"
                    dtFilter = dv.ToTable
                Else
                    dtFilter = dv.ToTable
                End If

                If dtFilter.Rows.Count > 0 Then
                    'If strCustomer <> "" AndAlso strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun, strCustomer)
                    'End If
                    'If strCustomer = "" AndAlso strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun)
                    'End If

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    For i As Integer = 0 To dtFilter.Rows.Count - 1
                        Try
                            With ObjForecast
                                If dtFilter.Rows(i)("Tahun") Is DBNull.Value OrElse dtFilter.Rows(i)("Tahun").ToString = "" Then
                                    .Tahun = ""
                                Else
                                    .Tahun = dtFilter.Rows(i)("Tahun").ToString
                                End If
                                If dtFilter.Rows(i)("Cust ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Cust ID").ToString = "" Then
                                    .CustID = ""
                                Else
                                    .CustID = dtFilter.Rows(i)("Cust ID").ToString
                                End If
                                If dtFilter.Rows(i)("Customer") Is DBNull.Value OrElse dtFilter.Rows(i)("Customer").ToString = "" Then
                                    .Customer = ""
                                Else
                                    .Customer = dtFilter.Rows(i)("Customer").ToString
                                End If
                                If dtFilter.Rows(i)("Invt ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Invt ID").ToString = "" Then
                                    .InvtID = ""
                                Else
                                    .InvtID = dtFilter.Rows(i)("Invt ID").ToString
                                End If

                                If dtFilter.Rows(i)("Description") Is DBNull.Value OrElse dtFilter.Rows(i)("Description").ToString = "" Then
                                    .Description = ""
                                Else
                                    .Description = dtFilter.Rows(i)("Description").ToString
                                End If
                                If dtFilter.Rows(i)("Part No") Is DBNull.Value OrElse dtFilter.Rows(i)("Part No").ToString = "" Then
                                    .PartNo = ""
                                Else
                                    .PartNo = dtFilter.Rows(i)("Part No").ToString
                                End If
                                If dtFilter.Rows(i)("Model") Is DBNull.Value OrElse dtFilter.Rows(i)("Model").ToString = "" Then
                                    .Model = ""
                                Else
                                    .Model = dtFilter.Rows(i)("Model").ToString
                                End If
                                If dtFilter.Rows(i)("Oe/Pe") Is DBNull.Value OrElse dtFilter.Rows(i)("Oe/Pe").ToString = "" Then
                                    .OePe = ""
                                Else
                                    .OePe = dtFilter.Rows(i)("Oe/Pe").ToString
                                End If

                                If dtFilter.Rows(i)("IN/SUB") Is DBNull.Value OrElse dtFilter.Rows(i)("IN/SUB").ToString = "" Then
                                    .INSub = ""
                                Else
                                    .INSub = dtFilter.Rows(i)("IN/SUB").ToString
                                End If
                                If dtFilter.Rows(i)("Site") Is DBNull.Value OrElse dtFilter.Rows(i)("Site").ToString = "" Then
                                    .Site = ""
                                Else
                                    .Site = dtFilter.Rows(i)("Site").ToString
                                End If
                                '=====================FORECAST - PO==============
                                '===================== Januari ==================
                                If dtFilter.Rows(i)("Jan Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty1") Is DBNull.Value Then
                                    .JanQty1 = 0
                                Else
                                    .JanQty1 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty1").ToString)
                                End If

                                If dtFilter.Rows(i)("Jan Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty2") Is DBNull.Value Then
                                    .JanQty2 = 0
                                Else
                                    .JanQty2 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Jan Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty3") Is DBNull.Value Then
                                    .JanQty3 = 0
                                Else
                                    .JanQty3 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan PO1").ToString = "" OrElse dtFilter.Rows(i)("Jan PO1") Is DBNull.Value Then
                                    .Jan_PO1 = 0
                                Else
                                    .Jan_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jan PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan PO2").ToString = "" OrElse dtFilter.Rows(i)("Jan PO2") Is DBNull.Value Then
                                    .Jan_PO2 = 0
                                Else
                                    .Jan_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jan PO2").ToString)
                                End If

                                '===================== Februari ==================
                                If dtFilter.Rows(i)("Feb Qty1").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty1") Is DBNull.Value Then
                                    .FebQty1 = 0
                                Else
                                    .FebQty1 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Qty2").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty2") Is DBNull.Value Then
                                    .FebQty2 = 0
                                Else
                                    .FebQty2 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Feb Qty3").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty3") Is DBNull.Value Then
                                    .FebQty3 = 0
                                Else
                                    .FebQty3 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb PO1").ToString = "" OrElse dtFilter.Rows(i)("Feb PO1") Is DBNull.Value Then
                                    .Feb_PO1 = 0
                                Else
                                    .Feb_PO1 = Decimal.Parse(dtFilter.Rows(i)("Feb PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb PO2").ToString = "" OrElse dtFilter.Rows(i)("Feb PO2") Is DBNull.Value Then
                                    .Feb_PO2 = 0
                                Else
                                    .Feb_PO2 = Decimal.Parse(dtFilter.Rows(i)("Feb PO2").ToString)
                                End If

                                '===================== Maret ==================
                                If dtFilter.Rows(i)("Mar Qty1").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty1") Is DBNull.Value Then
                                    .MarQty1 = 0
                                Else
                                    .MarQty1 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Qty2").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty2") Is DBNull.Value Then
                                    .MarQty2 = 0
                                Else
                                    .MarQty2 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Qty3").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty3") Is DBNull.Value Then
                                    .MarQty3 = 0
                                Else
                                    .MarQty3 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar PO1").ToString = "" OrElse dtFilter.Rows(i)("Mar PO1") Is DBNull.Value Then
                                    .Mar_PO1 = 0
                                Else
                                    .Mar_PO1 = Decimal.Parse(dtFilter.Rows(i)("Mar PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar PO2").ToString = "" OrElse dtFilter.Rows(i)("Mar PO2") Is DBNull.Value Then
                                    .Mar_PO2 = 0
                                Else
                                    .Mar_PO2 = Decimal.Parse(dtFilter.Rows(i)("Mar PO2").ToString)
                                End If

                                '===================== April ==================
                                If dtFilter.Rows(i)("Apr Qty1").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty1") Is DBNull.Value Then
                                    .AprQty1 = 0
                                Else
                                    .AprQty1 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Qty2").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty2") Is DBNull.Value Then
                                    .AprQty2 = 0
                                Else
                                    .AprQty2 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Qty3").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty3") Is DBNull.Value Then
                                    .AprQty3 = 0
                                Else
                                    .AprQty3 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr PO1").ToString = "" OrElse dtFilter.Rows(i)("Apr PO1") Is DBNull.Value Then
                                    .Apr_PO1 = 0
                                Else
                                    .Apr_PO1 = Decimal.Parse(dtFilter.Rows(i)("Apr PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr PO2").ToString = "" OrElse dtFilter.Rows(i)("Apr PO2") Is DBNull.Value Then
                                    .Apr_PO2 = 0
                                Else
                                    .Apr_PO2 = Decimal.Parse(dtFilter.Rows(i)("Apr PO2").ToString)
                                End If

                                '===================== Mei ==================
                                If dtFilter.Rows(i)("Mei Qty1").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty1") Is DBNull.Value Then
                                    .MeiQty1 = 0
                                Else
                                    .MeiQty1 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Qty2").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty2") Is DBNull.Value Then
                                    .MeiQty2 = 0
                                Else
                                    .MeiQty2 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Qty3").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty3") Is DBNull.Value Then
                                    .MeiQty3 = 0
                                Else
                                    .MeiQty3 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei PO1").ToString = "" OrElse dtFilter.Rows(i)("Mei PO1") Is DBNull.Value Then
                                    .Mei_PO1 = 0
                                Else
                                    .Mei_PO1 = Decimal.Parse(dtFilter.Rows(i)("Mei PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei PO2").ToString = "" OrElse dtFilter.Rows(i)("Mei PO2") Is DBNull.Value Then
                                    .Mei_PO2 = 0
                                Else
                                    .Mei_PO2 = Decimal.Parse(dtFilter.Rows(i)("Mei PO2").ToString)
                                End If

                                '===================== Juni ==================
                                If dtFilter.Rows(i)("Jun Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty1") Is DBNull.Value Then
                                    .JunQty1 = 0
                                Else
                                    .JunQty1 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty2") Is DBNull.Value Then
                                    .JunQty2 = 0
                                Else
                                    .JunQty2 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Jun Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty3") Is DBNull.Value Then
                                    .JunQty3 = 0
                                Else
                                    .JunQty3 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun PO1").ToString = "" OrElse dtFilter.Rows(i)("Jun PO1") Is DBNull.Value Then
                                    .Jun_PO1 = 0
                                Else
                                    .Jun_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jun PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun PO2").ToString = "" OrElse dtFilter.Rows(i)("Jun PO2") Is DBNull.Value Then
                                    .Jun_PO2 = 0
                                Else
                                    .Jun_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jun PO2").ToString)
                                End If

                                '===================== Juli ==================
                                If dtFilter.Rows(i)("Jul Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty1") Is DBNull.Value Then
                                    .JulQty1 = 0
                                Else
                                    .JulQty1 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty2") Is DBNull.Value Then
                                    .JulQty2 = 0
                                Else
                                    .JulQty2 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty3") Is DBNull.Value Then
                                    .JulQty3 = 0
                                Else
                                    .JulQty3 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul PO1").ToString = "" OrElse dtFilter.Rows(i)("Jul PO1") Is DBNull.Value Then
                                    .Jul_PO1 = 0
                                Else
                                    .Jul_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jul PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul PO2").ToString = "" OrElse dtFilter.Rows(i)("Jul PO2") Is DBNull.Value Then
                                    .Jul_PO2 = 0
                                Else
                                    .Jul_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jul PO2").ToString)
                                End If

                                '===================== Agustus ==================
                                If dtFilter.Rows(i)("Agt Qty1").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty1") Is DBNull.Value Then
                                    .AgtQty1 = 0
                                Else
                                    .AgtQty1 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Qty2").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty2") Is DBNull.Value Then
                                    .AgtQty2 = 0
                                Else
                                    .AgtQty2 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Qty3").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty3") Is DBNull.Value Then
                                    .AgtQty3 = 0
                                Else
                                    .AgtQty3 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt PO1").ToString = "" OrElse dtFilter.Rows(i)("Agt PO1") Is DBNull.Value Then
                                    .Agt_PO1 = 0
                                Else
                                    .Agt_PO1 = Decimal.Parse(dtFilter.Rows(i)("Agt PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt PO2").ToString = "" OrElse dtFilter.Rows(i)("Agt PO2") Is DBNull.Value Then
                                    .Agt_PO2 = 0
                                Else
                                    .Agt_PO2 = Decimal.Parse(dtFilter.Rows(i)("Agt PO2").ToString)
                                End If

                                '===================== September ==================
                                If dtFilter.Rows(i)("Sep Qty1").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty1") Is DBNull.Value Then
                                    .SepQty1 = 0
                                Else
                                    .SepQty1 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Qty2").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty2") Is DBNull.Value Then
                                    .SepQty2 = 0
                                Else
                                    .SepQty2 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Qty3").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty3") Is DBNull.Value Then
                                    .SepQty3 = 0
                                Else
                                    .SepQty3 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep PO1").ToString = "" OrElse dtFilter.Rows(i)("Sep PO1") Is DBNull.Value Then
                                    .Sep_PO1 = 0
                                Else
                                    .Sep_PO1 = Decimal.Parse(dtFilter.Rows(i)("Sep PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep PO2").ToString = "" OrElse dtFilter.Rows(i)("Sep PO2") Is DBNull.Value Then
                                    .Sep_PO2 = 0
                                Else
                                    .Sep_PO2 = Decimal.Parse(dtFilter.Rows(i)("Sep PO2").ToString)
                                End If

                                '===================== Oktober ==================
                                If dtFilter.Rows(i)("Okt Qty1").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty1") Is DBNull.Value Then
                                    .OktQty1 = 0
                                Else
                                    .OktQty1 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Qty2").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty2") Is DBNull.Value Then
                                    .OktQty2 = 0
                                Else
                                    .OktQty2 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Qty3").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty3") Is DBNull.Value Then
                                    .OktQty3 = 0
                                Else
                                    .OktQty3 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt PO1").ToString = "" OrElse dtFilter.Rows(i)("Okt PO1") Is DBNull.Value Then
                                    .Okt_PO1 = 0
                                Else
                                    .Okt_PO1 = Decimal.Parse(dtFilter.Rows(i)("Okt PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt PO2").ToString = "" OrElse dtFilter.Rows(i)("Okt PO2") Is DBNull.Value Then
                                    .Okt_PO2 = 0
                                Else
                                    .Okt_PO2 = Decimal.Parse(dtFilter.Rows(i)("Okt PO2").ToString)
                                End If
                                '===================== November ==================
                                If dtFilter.Rows(i)("Nov Qty1").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty1") Is DBNull.Value Then
                                    .NovQty1 = 0
                                Else
                                    .NovQty1 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Qty2").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty2") Is DBNull.Value Then
                                    .NovQty2 = 0
                                Else
                                    .NovQty2 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Qty3").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty3") Is DBNull.Value Then
                                    .NovQty3 = 0
                                Else
                                    .NovQty3 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov PO1").ToString = "" OrElse dtFilter.Rows(i)("Nov PO1") Is DBNull.Value Then
                                    .Nov_PO1 = 0
                                Else
                                    .Nov_PO1 = Decimal.Parse(dtFilter.Rows(i)("Nov PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov PO2").ToString = "" OrElse dtFilter.Rows(i)("Nov PO2") Is DBNull.Value Then
                                    .Nov_PO2 = 0
                                Else
                                    .Nov_PO2 = Decimal.Parse(dtFilter.Rows(i)("Nov PO2").ToString)
                                End If

                                '===================== Desember ==================
                                If dtFilter.Rows(i)("Des Qty1").ToString = "" OrElse dtFilter.Rows(i)("Des Qty1") Is DBNull.Value Then
                                    .DesQty1 = 0
                                Else
                                    .DesQty1 = Decimal.Parse(dtFilter.Rows(i)("Des Qty1").ToString)
                                End If

                                If dtFilter.Rows(i)("Des Qty2").ToString = "" OrElse dtFilter.Rows(i)("Des Qty2") Is DBNull.Value Then
                                    .DesQty2 = 0
                                Else
                                    .DesQty2 = Decimal.Parse(dtFilter.Rows(i)("Des Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Des Qty3").ToString = "" OrElse dtFilter.Rows(i)("Des Qty3") Is DBNull.Value Then
                                    .DesQty3 = 0
                                Else
                                    .DesQty3 = Decimal.Parse(dtFilter.Rows(i)("Des Qty3").ToString)
                                End If

                                If dtFilter.Rows(i)("Des PO1").ToString = "" OrElse dtFilter.Rows(i)("Des PO1") Is DBNull.Value Then
                                    .Des_PO1 = 0
                                Else
                                    .Des_PO1 = Decimal.Parse(dtFilter.Rows(i)("Des PO1").ToString)
                                End If

                                If dtFilter.Rows(i)("Des PO2").ToString = "" OrElse dtFilter.Rows(i)("Des PO2") Is DBNull.Value Then
                                    .Des_PO2 = 0
                                Else
                                    .Des_PO2 = Decimal.Parse(dtFilter.Rows(i)("Des PO2").ToString)
                                End If

                                '===========================PRICE==================================
                                If dtFilter.Rows(i)("Jan Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga1") Is DBNull.Value Then
                                    .JanHarga1 = 0
                                Else
                                    .JanHarga1 = Double.Parse(dtFilter.Rows(i)("Jan Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga2") Is DBNull.Value Then
                                    .JanHarga2 = 0
                                Else
                                    .JanHarga2 = Double.Parse(dtFilter.Rows(i)("Jan Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga3") Is DBNull.Value Then
                                    .JanHarga3 = 0
                                Else
                                    .JanHarga3 = Double.Parse(dtFilter.Rows(i)("Jan Harga3").ToString)
                                End If

                                'Februari
                                If dtFilter.Rows(i)("Feb Harga1").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga1") Is DBNull.Value Then
                                    .FebHarga1 = 0
                                Else
                                    .FebHarga1 = Double.Parse(dtFilter.Rows(i)("Feb Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Harga2").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga2") Is DBNull.Value Then
                                    .FebHarga2 = 0
                                Else
                                    .FebHarga2 = Double.Parse(dtFilter.Rows(i)("Feb Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Harga3").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga3") Is DBNull.Value Then
                                    .FebHarga3 = 0
                                Else
                                    .FebHarga3 = Double.Parse(dtFilter.Rows(i)("Feb Harga3").ToString)
                                End If

                                'Maret

                                If dtFilter.Rows(i)("Mar Harga1").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga1") Is DBNull.Value Then
                                    .MarHarga1 = 0
                                Else
                                    .MarHarga1 = Double.Parse(dtFilter.Rows(i)("Mar Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Harga2").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga2") Is DBNull.Value Then
                                    .MarHarga2 = 0
                                Else
                                    .MarHarga2 = Double.Parse(dtFilter.Rows(i)("Mar Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Harga3").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga3") Is DBNull.Value Then
                                    .MarHarga3 = 0
                                Else
                                    .MarHarga3 = Double.Parse(dtFilter.Rows(i)("Mar Harga3").ToString)
                                End If


                                'April

                                If dtFilter.Rows(i)("Apr Harga1").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga1") Is DBNull.Value Then
                                    .AprHarga1 = 0
                                Else
                                    .AprHarga1 = Double.Parse(dtFilter.Rows(i)("Apr Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Harga2").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga2") Is DBNull.Value Then
                                    .AprHarga2 = 0
                                Else
                                    .AprHarga2 = Double.Parse(dtFilter.Rows(i)("Apr Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Harga3").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga3") Is DBNull.Value Then
                                    .AprHarga3 = 0
                                Else
                                    .AprHarga3 = Double.Parse(dtFilter.Rows(i)("Apr Harga3").ToString)
                                End If

                                'Mei
                                If dtFilter.Rows(i)("Mei Harga1").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga1") Is DBNull.Value Then
                                    .MeiHarga1 = 0
                                Else
                                    .MeiHarga1 = Double.Parse(dtFilter.Rows(i)("Mei Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Harga2").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga2") Is DBNull.Value Then
                                    .MeiHarga2 = 0
                                Else
                                    .MeiHarga2 = Double.Parse(dtFilter.Rows(i)("Mei Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Harga3").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga3") Is DBNull.Value Then
                                    .MeiHarga3 = 0
                                Else
                                    .MeiHarga3 = Double.Parse(dtFilter.Rows(i)("Mei Harga3").ToString)
                                End If

                                'Juni

                                If dtFilter.Rows(i)("Jun Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga1") Is DBNull.Value Then
                                    .JunHarga1 = 0
                                Else
                                    .JunHarga1 = Double.Parse(dtFilter.Rows(i)("Jun Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga2") Is DBNull.Value Then
                                    .JunHarga2 = 0
                                Else
                                    .JunHarga2 = Double.Parse(dtFilter.Rows(i)("Jun Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga3") Is DBNull.Value Then
                                    .JunHarga3 = 0
                                Else
                                    .JunHarga3 = Double.Parse(dtFilter.Rows(i)("Jun Harga3").ToString)
                                End If

                                'Juli

                                If dtFilter.Rows(i)("Jul Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga1") Is DBNull.Value Then
                                    .JulHarga1 = 0
                                Else
                                    .JulHarga1 = Double.Parse(dtFilter.Rows(i)("Jul Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga2") Is DBNull.Value Then
                                    .JulHarga2 = 0
                                Else
                                    .JulHarga2 = Double.Parse(dtFilter.Rows(i)("Jul Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga3") Is DBNull.Value Then
                                    .JulHarga3 = 0
                                Else
                                    .JulHarga3 = Double.Parse(dtFilter.Rows(i)("Jul Harga3").ToString)
                                End If

                                'Agustus
                                If dtFilter.Rows(i)("Agt Harga1").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga1") Is DBNull.Value Then
                                    .AgtHarga1 = 0
                                Else
                                    .AgtHarga1 = Double.Parse(dtFilter.Rows(i)("Agt Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Harga2").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga2") Is DBNull.Value Then
                                    .AgtHarga2 = 0
                                Else
                                    .AgtHarga2 = Double.Parse(dtFilter.Rows(i)("Agt Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Harga3").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga3") Is DBNull.Value Then
                                    .AgtHarga3 = 0
                                Else
                                    .AgtHarga3 = Double.Parse(dtFilter.Rows(i)("Agt Harga3").ToString)
                                End If

                                'September
                                If dtFilter.Rows(i)("Sep Harga1").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga1") Is DBNull.Value Then
                                    .SepHarga1 = 0
                                Else
                                    .SepHarga1 = Double.Parse(dtFilter.Rows(i)("Sep Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Harga2").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga2") Is DBNull.Value Then
                                    .SepHarga2 = 0
                                Else
                                    .SepHarga2 = Double.Parse(dtFilter.Rows(i)("Sep Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Harga3").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga3") Is DBNull.Value Then
                                    .SepHarga3 = 0
                                Else
                                    .SepHarga3 = Double.Parse(dtFilter.Rows(i)("Sep Harga3").ToString)
                                End If

                                'Okoteber
                                If dtFilter.Rows(i)("Okt Harga1").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga1") Is DBNull.Value Then
                                    .OktHarga1 = 0
                                Else
                                    .OktHarga1 = Double.Parse(dtFilter.Rows(i)("Okt Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Harga2").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga2") Is DBNull.Value Then
                                    .OktHarga2 = 0
                                Else
                                    .OktHarga2 = Double.Parse(dtFilter.Rows(i)("Okt Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Harga3").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga3") Is DBNull.Value Then
                                    .OktHarga3 = 0
                                Else
                                    .OktHarga3 = Double.Parse(dtFilter.Rows(i)("Okt Harga3").ToString)
                                End If

                                'November 
                                If dtFilter.Rows(i)("Nov Harga1").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga1") Is DBNull.Value Then
                                    .NovHarga1 = 0
                                Else
                                    .NovHarga1 = Double.Parse(dtFilter.Rows(i)("Nov Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Harga2").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga2") Is DBNull.Value Then
                                    .NovHarga2 = 0
                                Else
                                    .NovHarga2 = Double.Parse(dtFilter.Rows(i)("Nov Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Harga3").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga3") Is DBNull.Value Then
                                    .NovHarga3 = 0
                                Else
                                    .NovHarga3 = Double.Parse(dtFilter.Rows(i)("Nov Harga3").ToString)
                                End If

                                'Desember
                                If dtFilter.Rows(i)("Des Harga1").ToString = "" OrElse dtFilter.Rows(i)("Des Harga1") Is DBNull.Value Then
                                    .DesHarga1 = 0
                                Else
                                    .DesHarga1 = Double.Parse(dtFilter.Rows(i)("Des Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Des Harga2").ToString = "" OrElse dtFilter.Rows(i)("Des Harga2") Is DBNull.Value Then
                                    .DesHarga2 = 0
                                Else
                                    .DesHarga2 = Double.Parse(dtFilter.Rows(i)("Des Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Des Harga3").ToString = "" OrElse dtFilter.Rows(i)("Des Harga3") Is DBNull.Value Then
                                    .DesHarga3 = 0
                                Else
                                    .DesHarga3 = Double.Parse(dtFilter.Rows(i)("Des Harga3").ToString)
                                End If

                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username
                                Dim IsExist = .IsDataExist
                                If IsExist Then
                                    .UpdateDataByBulan(Bulan)
                                Else
                                    .InsertData()
                                    '.UpdateDataByBulan(Bulan)
                                End If
                            End With

                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, i, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    'ProgressBar1.Visible = False
                    'Cursor = Cursors.Default
                    LoadGrid()
                End If
            Catch ex As Exception
                Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
        Else
            strTahun = frmExcel.Tahun1

            Try
                Dim dv As DataView = New DataView(table)
                Dim dtFilter As New DataTable

                If strTahun <> "" Then
                    dv.RowFilter = "Tahun = '" & strTahun & "'"
                    dtFilter = dv.ToTable
                Else
                    dtFilter = dv.ToTable
                End If

                If dtFilter.Rows.Count > 0 Then
                    If strTahun <> "" Then
                        ObjForecast.DeleteByTahun(strTahun)
                    End If

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    For i As Integer = 0 To dtFilter.Rows.Count - 1
                        Try
                            With ObjForecast
                                If dtFilter.Rows(i)("Tahun") Is DBNull.Value OrElse dtFilter.Rows(i)("Tahun").ToString = "" Then
                                    .Tahun = ""
                                Else
                                    .Tahun = dtFilter.Rows(i)("Tahun").ToString
                                End If
                                If dtFilter.Rows(i)("Cust ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Cust ID").ToString = "" Then
                                    .CustID = ""
                                Else
                                    .CustID = dtFilter.Rows(i)("Cust ID").ToString
                                End If
                                If dtFilter.Rows(i)("Customer") Is DBNull.Value OrElse dtFilter.Rows(i)("Customer").ToString = "" Then
                                    .Customer = ""
                                Else
                                    .Customer = dtFilter.Rows(i)("Customer").ToString
                                End If
                                If dtFilter.Rows(i)("Invt ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Invt ID").ToString = "" Then
                                    .InvtID = ""
                                Else
                                    .InvtID = dtFilter.Rows(i)("Invt ID").ToString
                                End If

                                If dtFilter.Rows(i)("Description") Is DBNull.Value OrElse dtFilter.Rows(i)("Description").ToString = "" Then
                                    .Description = ""
                                Else
                                    .Description = dtFilter.Rows(i)("Description").ToString
                                End If
                                If dtFilter.Rows(i)("Part No") Is DBNull.Value OrElse dtFilter.Rows(i)("Part No").ToString = "" Then
                                    .PartNo = ""
                                Else
                                    .PartNo = dtFilter.Rows(i)("Part No").ToString
                                End If
                                If dtFilter.Rows(i)("Model") Is DBNull.Value OrElse dtFilter.Rows(i)("Model").ToString = "" Then
                                    .Model = ""
                                Else
                                    .Model = dtFilter.Rows(i)("Model").ToString
                                End If
                                If dtFilter.Rows(i)("Oe/Pe") Is DBNull.Value OrElse dtFilter.Rows(i)("Oe/Pe").ToString = "" Then
                                    .OePe = ""
                                Else
                                    .OePe = dtFilter.Rows(i)("Oe/Pe").ToString
                                End If

                                If dtFilter.Rows(i)("IN/SUB") Is DBNull.Value OrElse dtFilter.Rows(i)("IN/SUB").ToString = "" Then
                                    .INSub = ""
                                Else
                                    .INSub = dtFilter.Rows(i)("IN/SUB").ToString
                                End If
                                If dtFilter.Rows(i)("Site") Is DBNull.Value OrElse dtFilter.Rows(i)("Site").ToString = "" Then
                                    .Site = ""
                                Else
                                    .Site = dtFilter.Rows(i)("Site").ToString
                                End If
                                '=====================FORECAST - PO==============
                                '===================== Januari ==================
                                If dtFilter.Rows(i)("Jan Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty1") Is DBNull.Value Then
                                    .JanQty1 = 0
                                Else
                                    .JanQty1 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty1").ToString)
                                End If

                                If dtFilter.Rows(i)("Jan Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty2") Is DBNull.Value Then
                                    .JanQty2 = 0
                                Else
                                    .JanQty2 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Jan Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jan Qty3") Is DBNull.Value Then
                                    .JanQty3 = 0
                                Else
                                    .JanQty3 = Decimal.Parse(dtFilter.Rows(i)("Jan Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan PO1").ToString = "" OrElse dtFilter.Rows(i)("Jan PO1") Is DBNull.Value Then
                                    .Jan_PO1 = 0
                                Else
                                    .Jan_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jan PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan PO2").ToString = "" OrElse dtFilter.Rows(i)("Jan PO2") Is DBNull.Value Then
                                    .Jan_PO2 = 0
                                Else
                                    .Jan_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jan PO2").ToString)
                                End If

                                '===================== Februari ==================
                                If dtFilter.Rows(i)("Feb Qty1").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty1") Is DBNull.Value Then
                                    .FebQty1 = 0
                                Else
                                    .FebQty1 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Qty2").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty2") Is DBNull.Value Then
                                    .FebQty2 = 0
                                Else
                                    .FebQty2 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Feb Qty3").ToString = "" OrElse dtFilter.Rows(i)("Feb Qty3") Is DBNull.Value Then
                                    .FebQty3 = 0
                                Else
                                    .FebQty3 = Decimal.Parse(dtFilter.Rows(i)("Feb Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb PO1").ToString = "" OrElse dtFilter.Rows(i)("Feb PO1") Is DBNull.Value Then
                                    .Feb_PO1 = 0
                                Else
                                    .Feb_PO1 = Decimal.Parse(dtFilter.Rows(i)("Feb PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb PO2").ToString = "" OrElse dtFilter.Rows(i)("Feb PO2") Is DBNull.Value Then
                                    .Feb_PO2 = 0
                                Else
                                    .Feb_PO2 = Decimal.Parse(dtFilter.Rows(i)("Feb PO2").ToString)
                                End If

                                '===================== Maret ==================
                                If dtFilter.Rows(i)("Mar Qty1").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty1") Is DBNull.Value Then
                                    .MarQty1 = 0
                                Else
                                    .MarQty1 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Qty2").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty2") Is DBNull.Value Then
                                    .MarQty2 = 0
                                Else
                                    .MarQty2 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Qty3").ToString = "" OrElse dtFilter.Rows(i)("Mar Qty3") Is DBNull.Value Then
                                    .MarQty3 = 0
                                Else
                                    .MarQty3 = Decimal.Parse(dtFilter.Rows(i)("Mar Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar PO1").ToString = "" OrElse dtFilter.Rows(i)("Mar PO1") Is DBNull.Value Then
                                    .Mar_PO1 = 0
                                Else
                                    .Mar_PO1 = Decimal.Parse(dtFilter.Rows(i)("Mar PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar PO2").ToString = "" OrElse dtFilter.Rows(i)("Mar PO2") Is DBNull.Value Then
                                    .Mar_PO2 = 0
                                Else
                                    .Mar_PO2 = Decimal.Parse(dtFilter.Rows(i)("Mar PO2").ToString)
                                End If

                                '===================== April ==================
                                If dtFilter.Rows(i)("Apr Qty1").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty1") Is DBNull.Value Then
                                    .AprQty1 = 0
                                Else
                                    .AprQty1 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Qty2").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty2") Is DBNull.Value Then
                                    .AprQty2 = 0
                                Else
                                    .AprQty2 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Qty3").ToString = "" OrElse dtFilter.Rows(i)("Apr Qty3") Is DBNull.Value Then
                                    .AprQty3 = 0
                                Else
                                    .AprQty3 = Decimal.Parse(dtFilter.Rows(i)("Apr Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr PO1").ToString = "" OrElse dtFilter.Rows(i)("Apr PO1") Is DBNull.Value Then
                                    .Apr_PO1 = 0
                                Else
                                    .Apr_PO1 = Decimal.Parse(dtFilter.Rows(i)("Apr PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr PO2").ToString = "" OrElse dtFilter.Rows(i)("Apr PO2") Is DBNull.Value Then
                                    .Apr_PO2 = 0
                                Else
                                    .Apr_PO2 = Decimal.Parse(dtFilter.Rows(i)("Apr PO2").ToString)
                                End If

                                '===================== Mei ==================
                                If dtFilter.Rows(i)("Mei Qty1").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty1") Is DBNull.Value Then
                                    .MeiQty1 = 0
                                Else
                                    .MeiQty1 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Qty2").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty2") Is DBNull.Value Then
                                    .MeiQty2 = 0
                                Else
                                    .MeiQty2 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Qty3").ToString = "" OrElse dtFilter.Rows(i)("Mei Qty3") Is DBNull.Value Then
                                    .MeiQty3 = 0
                                Else
                                    .MeiQty3 = Decimal.Parse(dtFilter.Rows(i)("Mei Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei PO1").ToString = "" OrElse dtFilter.Rows(i)("Mei PO1") Is DBNull.Value Then
                                    .Mei_PO1 = 0
                                Else
                                    .Mei_PO1 = Decimal.Parse(dtFilter.Rows(i)("Mei PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei PO2").ToString = "" OrElse dtFilter.Rows(i)("Mei PO2") Is DBNull.Value Then
                                    .Mei_PO2 = 0
                                Else
                                    .Mei_PO2 = Decimal.Parse(dtFilter.Rows(i)("Mei PO2").ToString)
                                End If

                                '===================== Juni ==================
                                If dtFilter.Rows(i)("Jun Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty1") Is DBNull.Value Then
                                    .JunQty1 = 0
                                Else
                                    .JunQty1 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty2") Is DBNull.Value Then
                                    .JunQty2 = 0
                                Else
                                    .JunQty2 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Jun Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jun Qty3") Is DBNull.Value Then
                                    .JunQty3 = 0
                                Else
                                    .JunQty3 = Decimal.Parse(dtFilter.Rows(i)("Jun Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun PO1").ToString = "" OrElse dtFilter.Rows(i)("Jun PO1") Is DBNull.Value Then
                                    .Jun_PO1 = 0
                                Else
                                    .Jun_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jun PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun PO2").ToString = "" OrElse dtFilter.Rows(i)("Jun PO2") Is DBNull.Value Then
                                    .Jun_PO2 = 0
                                Else
                                    .Jun_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jun PO2").ToString)
                                End If

                                '===================== Juli ==================
                                If dtFilter.Rows(i)("Jul Qty1").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty1") Is DBNull.Value Then
                                    .JulQty1 = 0
                                Else
                                    .JulQty1 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Qty2").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty2") Is DBNull.Value Then
                                    .JulQty2 = 0
                                Else
                                    .JulQty2 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Qty3").ToString = "" OrElse dtFilter.Rows(i)("Jul Qty3") Is DBNull.Value Then
                                    .JulQty3 = 0
                                Else
                                    .JulQty3 = Decimal.Parse(dtFilter.Rows(i)("Jul Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul PO1").ToString = "" OrElse dtFilter.Rows(i)("Jul PO1") Is DBNull.Value Then
                                    .Jul_PO1 = 0
                                Else
                                    .Jul_PO1 = Decimal.Parse(dtFilter.Rows(i)("Jul PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul PO2").ToString = "" OrElse dtFilter.Rows(i)("Jul PO2") Is DBNull.Value Then
                                    .Jul_PO2 = 0
                                Else
                                    .Jul_PO2 = Decimal.Parse(dtFilter.Rows(i)("Jul PO2").ToString)
                                End If

                                '===================== Agustus ==================
                                If dtFilter.Rows(i)("Agt Qty1").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty1") Is DBNull.Value Then
                                    .AgtQty1 = 0
                                Else
                                    .AgtQty1 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Qty2").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty2") Is DBNull.Value Then
                                    .AgtQty2 = 0
                                Else
                                    .AgtQty2 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Qty3").ToString = "" OrElse dtFilter.Rows(i)("Agt Qty3") Is DBNull.Value Then
                                    .AgtQty3 = 0
                                Else
                                    .AgtQty3 = Decimal.Parse(dtFilter.Rows(i)("Agt Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt PO1").ToString = "" OrElse dtFilter.Rows(i)("Agt PO1") Is DBNull.Value Then
                                    .Agt_PO1 = 0
                                Else
                                    .Agt_PO1 = Decimal.Parse(dtFilter.Rows(i)("Agt PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt PO2").ToString = "" OrElse dtFilter.Rows(i)("Agt PO2") Is DBNull.Value Then
                                    .Agt_PO2 = 0
                                Else
                                    .Agt_PO2 = Decimal.Parse(dtFilter.Rows(i)("Agt PO2").ToString)
                                End If

                                '===================== September ==================
                                If dtFilter.Rows(i)("Sep Qty1").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty1") Is DBNull.Value Then
                                    .SepQty1 = 0
                                Else
                                    .SepQty1 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Qty2").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty2") Is DBNull.Value Then
                                    .SepQty2 = 0
                                Else
                                    .SepQty2 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Qty3").ToString = "" OrElse dtFilter.Rows(i)("Sep Qty3") Is DBNull.Value Then
                                    .SepQty3 = 0
                                Else
                                    .SepQty3 = Decimal.Parse(dtFilter.Rows(i)("Sep Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep PO1").ToString = "" OrElse dtFilter.Rows(i)("Sep PO1") Is DBNull.Value Then
                                    .Sep_PO1 = 0
                                Else
                                    .Sep_PO1 = Decimal.Parse(dtFilter.Rows(i)("Sep PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep PO2").ToString = "" OrElse dtFilter.Rows(i)("Sep PO2") Is DBNull.Value Then
                                    .Sep_PO2 = 0
                                Else
                                    .Sep_PO2 = Decimal.Parse(dtFilter.Rows(i)("Sep PO2").ToString)
                                End If

                                '===================== Oktober ==================
                                If dtFilter.Rows(i)("Okt Qty1").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty1") Is DBNull.Value Then
                                    .OktQty1 = 0
                                Else
                                    .OktQty1 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Qty2").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty2") Is DBNull.Value Then
                                    .OktQty2 = 0
                                Else
                                    .OktQty2 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Qty3").ToString = "" OrElse dtFilter.Rows(i)("Okt Qty3") Is DBNull.Value Then
                                    .OktQty3 = 0
                                Else
                                    .OktQty3 = Decimal.Parse(dtFilter.Rows(i)("Okt Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt PO1").ToString = "" OrElse dtFilter.Rows(i)("Okt PO1") Is DBNull.Value Then
                                    .Okt_PO1 = 0
                                Else
                                    .Okt_PO1 = Decimal.Parse(dtFilter.Rows(i)("Okt PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt PO2").ToString = "" OrElse dtFilter.Rows(i)("Okt PO2") Is DBNull.Value Then
                                    .Okt_PO2 = 0
                                Else
                                    .Okt_PO2 = Decimal.Parse(dtFilter.Rows(i)("Okt PO2").ToString)
                                End If
                                '===================== November ==================
                                If dtFilter.Rows(i)("Nov Qty1").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty1") Is DBNull.Value Then
                                    .NovQty1 = 0
                                Else
                                    .NovQty1 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Qty2").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty2") Is DBNull.Value Then
                                    .NovQty2 = 0
                                Else
                                    .NovQty2 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty2").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Qty3").ToString = "" OrElse dtFilter.Rows(i)("Nov Qty3") Is DBNull.Value Then
                                    .NovQty3 = 0
                                Else
                                    .NovQty3 = Decimal.Parse(dtFilter.Rows(i)("Nov Qty3").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov PO1").ToString = "" OrElse dtFilter.Rows(i)("Nov PO1") Is DBNull.Value Then
                                    .Nov_PO1 = 0
                                Else
                                    .Nov_PO1 = Decimal.Parse(dtFilter.Rows(i)("Nov PO1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov PO2").ToString = "" OrElse dtFilter.Rows(i)("Nov PO2") Is DBNull.Value Then
                                    .Nov_PO2 = 0
                                Else
                                    .Nov_PO2 = Decimal.Parse(dtFilter.Rows(i)("Nov PO2").ToString)
                                End If

                                '===================== Desember ==================
                                If dtFilter.Rows(i)("Des Qty1").ToString = "" OrElse dtFilter.Rows(i)("Des Qty1") Is DBNull.Value Then
                                    .DesQty1 = 0
                                Else
                                    .DesQty1 = Decimal.Parse(dtFilter.Rows(i)("Des Qty1").ToString)
                                End If

                                If dtFilter.Rows(i)("Des Qty2").ToString = "" OrElse dtFilter.Rows(i)("Des Qty2") Is DBNull.Value Then
                                    .DesQty2 = 0
                                Else
                                    .DesQty2 = Decimal.Parse(dtFilter.Rows(i)("Des Qty2").ToString)
                                End If

                                If dtFilter.Rows(i)("Des Qty3").ToString = "" OrElse dtFilter.Rows(i)("Des Qty3") Is DBNull.Value Then
                                    .DesQty3 = 0
                                Else
                                    .DesQty3 = Decimal.Parse(dtFilter.Rows(i)("Des Qty3").ToString)
                                End If

                                If dtFilter.Rows(i)("Des PO1").ToString = "" OrElse dtFilter.Rows(i)("Des PO1") Is DBNull.Value Then
                                    .Des_PO1 = 0
                                Else
                                    .Des_PO1 = Decimal.Parse(dtFilter.Rows(i)("Des PO1").ToString)
                                End If

                                If dtFilter.Rows(i)("Des PO2").ToString = "" OrElse dtFilter.Rows(i)("Des PO2") Is DBNull.Value Then
                                    .Des_PO2 = 0
                                Else
                                    .Des_PO2 = Decimal.Parse(dtFilter.Rows(i)("Des PO2").ToString)
                                End If

                                '===========================PRICE==================================
                                If dtFilter.Rows(i)("Jan Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga1") Is DBNull.Value Then
                                    .JanHarga1 = 0
                                Else
                                    .JanHarga1 = Double.Parse(dtFilter.Rows(i)("Jan Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga2") Is DBNull.Value Then
                                    .JanHarga2 = 0
                                Else
                                    .JanHarga2 = Double.Parse(dtFilter.Rows(i)("Jan Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jan Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jan Harga3") Is DBNull.Value Then
                                    .JanHarga3 = 0
                                Else
                                    .JanHarga3 = Double.Parse(dtFilter.Rows(i)("Jan Harga3").ToString)
                                End If

                                'Februari
                                If dtFilter.Rows(i)("Feb Harga1").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga1") Is DBNull.Value Then
                                    .FebHarga1 = 0
                                Else
                                    .FebHarga1 = Double.Parse(dtFilter.Rows(i)("Feb Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Harga2").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga2") Is DBNull.Value Then
                                    .FebHarga2 = 0
                                Else
                                    .FebHarga2 = Double.Parse(dtFilter.Rows(i)("Feb Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Feb Harga3").ToString = "" OrElse dtFilter.Rows(i)("Feb Harga3") Is DBNull.Value Then
                                    .FebHarga3 = 0
                                Else
                                    .FebHarga3 = Double.Parse(dtFilter.Rows(i)("Feb Harga3").ToString)
                                End If

                                'Maret

                                If dtFilter.Rows(i)("Mar Harga1").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga1") Is DBNull.Value Then
                                    .MarHarga1 = 0
                                Else
                                    .MarHarga1 = Double.Parse(dtFilter.Rows(i)("Mar Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Harga2").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga2") Is DBNull.Value Then
                                    .MarHarga2 = 0
                                Else
                                    .MarHarga2 = Double.Parse(dtFilter.Rows(i)("Mar Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mar Harga3").ToString = "" OrElse dtFilter.Rows(i)("Mar Harga3") Is DBNull.Value Then
                                    .MarHarga3 = 0
                                Else
                                    .MarHarga3 = Double.Parse(dtFilter.Rows(i)("Mar Harga3").ToString)
                                End If


                                'April

                                If dtFilter.Rows(i)("Apr Harga1").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga1") Is DBNull.Value Then
                                    .AprHarga1 = 0
                                Else
                                    .AprHarga1 = Double.Parse(dtFilter.Rows(i)("Apr Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Harga2").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga2") Is DBNull.Value Then
                                    .AprHarga2 = 0
                                Else
                                    .AprHarga2 = Double.Parse(dtFilter.Rows(i)("Apr Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Apr Harga3").ToString = "" OrElse dtFilter.Rows(i)("Apr Harga3") Is DBNull.Value Then
                                    .AprHarga3 = 0
                                Else
                                    .AprHarga3 = Double.Parse(dtFilter.Rows(i)("Apr Harga3").ToString)
                                End If

                                'Mei
                                If dtFilter.Rows(i)("Mei Harga1").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga1") Is DBNull.Value Then
                                    .MeiHarga1 = 0
                                Else
                                    .MeiHarga1 = Double.Parse(dtFilter.Rows(i)("Mei Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Harga2").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga2") Is DBNull.Value Then
                                    .MeiHarga2 = 0
                                Else
                                    .MeiHarga2 = Double.Parse(dtFilter.Rows(i)("Mei Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Mei Harga3").ToString = "" OrElse dtFilter.Rows(i)("Mei Harga3") Is DBNull.Value Then
                                    .MeiHarga3 = 0
                                Else
                                    .MeiHarga3 = Double.Parse(dtFilter.Rows(i)("Mei Harga3").ToString)
                                End If

                                'Juni

                                If dtFilter.Rows(i)("Jun Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga1") Is DBNull.Value Then
                                    .JunHarga1 = 0
                                Else
                                    .JunHarga1 = Double.Parse(dtFilter.Rows(i)("Jun Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga2") Is DBNull.Value Then
                                    .JunHarga2 = 0
                                Else
                                    .JunHarga2 = Double.Parse(dtFilter.Rows(i)("Jun Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jun Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jun Harga3") Is DBNull.Value Then
                                    .JunHarga3 = 0
                                Else
                                    .JunHarga3 = Double.Parse(dtFilter.Rows(i)("Jun Harga3").ToString)
                                End If

                                'Juli

                                If dtFilter.Rows(i)("Jul Harga1").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga1") Is DBNull.Value Then
                                    .JulHarga1 = 0
                                Else
                                    .JulHarga1 = Double.Parse(dtFilter.Rows(i)("Jul Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Harga2").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga2") Is DBNull.Value Then
                                    .JulHarga2 = 0
                                Else
                                    .JulHarga2 = Double.Parse(dtFilter.Rows(i)("Jul Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Jul Harga3").ToString = "" OrElse dtFilter.Rows(i)("Jul Harga3") Is DBNull.Value Then
                                    .JulHarga3 = 0
                                Else
                                    .JulHarga3 = Double.Parse(dtFilter.Rows(i)("Jul Harga3").ToString)
                                End If

                                'Agustus
                                If dtFilter.Rows(i)("Agt Harga1").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga1") Is DBNull.Value Then
                                    .AgtHarga1 = 0
                                Else
                                    .AgtHarga1 = Double.Parse(dtFilter.Rows(i)("Agt Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Harga2").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga2") Is DBNull.Value Then
                                    .AgtHarga2 = 0
                                Else
                                    .AgtHarga2 = Double.Parse(dtFilter.Rows(i)("Agt Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Agt Harga3").ToString = "" OrElse dtFilter.Rows(i)("Agt Harga3") Is DBNull.Value Then
                                    .AgtHarga3 = 0
                                Else
                                    .AgtHarga3 = Double.Parse(dtFilter.Rows(i)("Agt Harga3").ToString)
                                End If

                                'September
                                If dtFilter.Rows(i)("Sep Harga1").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga1") Is DBNull.Value Then
                                    .SepHarga1 = 0
                                Else
                                    .SepHarga1 = Double.Parse(dtFilter.Rows(i)("Sep Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Harga2").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga2") Is DBNull.Value Then
                                    .SepHarga2 = 0
                                Else
                                    .SepHarga2 = Double.Parse(dtFilter.Rows(i)("Sep Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Sep Harga3").ToString = "" OrElse dtFilter.Rows(i)("Sep Harga3") Is DBNull.Value Then
                                    .SepHarga3 = 0
                                Else
                                    .SepHarga3 = Double.Parse(dtFilter.Rows(i)("Sep Harga3").ToString)
                                End If

                                'Okoteber
                                If dtFilter.Rows(i)("Okt Harga1").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga1") Is DBNull.Value Then
                                    .OktHarga1 = 0
                                Else
                                    .OktHarga1 = Double.Parse(dtFilter.Rows(i)("Okt Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Harga2").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga2") Is DBNull.Value Then
                                    .OktHarga2 = 0
                                Else
                                    .OktHarga2 = Double.Parse(dtFilter.Rows(i)("Okt Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Okt Harga3").ToString = "" OrElse dtFilter.Rows(i)("Okt Harga3") Is DBNull.Value Then
                                    .OktHarga3 = 0
                                Else
                                    .OktHarga3 = Double.Parse(dtFilter.Rows(i)("Okt Harga3").ToString)
                                End If

                                'November 
                                If dtFilter.Rows(i)("Nov Harga1").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga1") Is DBNull.Value Then
                                    .NovHarga1 = 0
                                Else
                                    .NovHarga1 = Double.Parse(dtFilter.Rows(i)("Nov Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Harga2").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga2") Is DBNull.Value Then
                                    .NovHarga2 = 0
                                Else
                                    .NovHarga2 = Double.Parse(dtFilter.Rows(i)("Nov Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Nov Harga3").ToString = "" OrElse dtFilter.Rows(i)("Nov Harga3") Is DBNull.Value Then
                                    .NovHarga3 = 0
                                Else
                                    .NovHarga3 = Double.Parse(dtFilter.Rows(i)("Nov Harga3").ToString)
                                End If

                                'Desember
                                If dtFilter.Rows(i)("Des Harga1").ToString = "" OrElse dtFilter.Rows(i)("Des Harga1") Is DBNull.Value Then
                                    .DesHarga1 = 0
                                Else
                                    .DesHarga1 = Double.Parse(dtFilter.Rows(i)("Des Harga1").ToString)
                                End If
                                If dtFilter.Rows(i)("Des Harga2").ToString = "" OrElse dtFilter.Rows(i)("Des Harga2") Is DBNull.Value Then
                                    .DesHarga2 = 0
                                Else
                                    .DesHarga2 = Double.Parse(dtFilter.Rows(i)("Des Harga2").ToString)
                                End If
                                If dtFilter.Rows(i)("Des Harga3").ToString = "" OrElse dtFilter.Rows(i)("Des Harga3") Is DBNull.Value Then
                                    .DesHarga3 = 0
                                Else
                                    .DesHarga3 = Double.Parse(dtFilter.Rows(i)("Des Harga3").ToString)
                                End If

                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username
                                .InsertData()

                            End With

                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, i, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    'ProgressBar1.Visible = False
                    'Cursor = Cursors.Default
                    LoadGrid()
                End If
            Catch ex As Exception
                Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End Try
        End If

    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Forecast"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            'Grid.all = False
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmSales_ForecastPrice_details(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = MenuUtamaForm
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle
            ObjForecast.Id = ID
            ObjForecast.Delete()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim InvtID As String
    Dim ID As Integer
    Private Sub frmSales_ForecastPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                InvtID = String.Empty
                ID = 0
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        InvtID = GridView1.GetRowCellValue(rowHandle, "InvtID")
                        ID = GridView1.GetRowCellValue(rowHandle, "Id")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             InvtID,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            InvtID = String.Empty
            ID = 0
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    InvtID = GridView1.GetRowCellValue(rowHandle, "InvtID")
                    ID = GridView1.GetRowCellValue(rowHandle, "Id")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(ID,
                         InvtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
