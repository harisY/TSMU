Imports System.Collections.ObjectModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class frmSales_ForecastPrice
    Dim ff_Detail As frmSales_ForecastPrice_details
    Dim dtGrid As DataTable
    Dim ObjForecast As New forecast_price_models
    Dim ObjHeader As New forecast_price_models_header

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
                    ObjHeader.ObjForecastCollection.Clear()
                    For i As Integer = 0 To dtFilter.Rows.Count - 1
                        Try
                            ObjForecast = New forecast_price_models
                            'Dim ObjCollection As New forecast_price_models
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
                                'Dim IsExist = .IsDataExist
                                'If IsExist Then
                                '    .UpdateDataByBulan(Bulan)
                                'Else
                                '    .InsertData()
                                '    '.UpdateDataByBulan(Bulan)
                                'End If
                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, i, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    With ObjHeader
                        .Tahun = strTahun
                        .CustID = strCustomer
                        .Bulan = Bulan
                        .InsertData1()
                    End With

                    SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    'ProgressBar1.Visible = False
                    'Cursor = Cursors.Default
                    LoadGrid()
                    If strCustomer.ToLower = "adm" Then
                        Dim result As DialogResult = XtraMessageBox.Show("Jumlahkan Qty Forecast ADM Sunter dan Karawang ?", "Confirmation", MessageBoxButtons.YesNoCancel)
                        If result = System.Windows.Forms.DialogResult.Yes Then
                            Dim dtAdm As New DataTable
                            dtAdm = ObjHeader.GetDataADM
                            ObjHeader.ObjForecastCollection.Clear()
                            For Each row In dtAdm.Rows
                                Try
                                    ObjForecast = New forecast_price_models
                                    With ObjForecast
                                        .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                                        .CustID = If(row("CustID") Is DBNull.Value, "", row("CustID").ToString())
                                        .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                                        .InvtID = If(row("InvtID") Is DBNull.Value, "", row("InvtID").ToString())
                                        .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                                        .PartNo = If(row("PartNo") Is DBNull.Value, "", row("PartNo").ToString())
                                        .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                                        .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe").ToString())
                                        .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                                        .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
                                        .JanQty1 = If(row("JanQty1") Is DBNull.Value, "0", Convert.ToInt32(row("JanQty1")))
                                        .FebQty1 = If(row("FebQty1") Is DBNull.Value, "0", Convert.ToInt32(row("FebQty1")))
                                        .MarQty1 = If(row("MarQty1") Is DBNull.Value, "0", Convert.ToInt32(row("MarQty1")))
                                        .AprQty1 = If(row("AprQty1") Is DBNull.Value, "0", Convert.ToInt32(row("AprQty1")))
                                        .MeiQty1 = If(row("MeiQty1") Is DBNull.Value, "0", Convert.ToInt32(row("MeiQty1")))
                                        .JunQty1 = If(row("JunQty1") Is DBNull.Value, "0", Convert.ToInt32(row("JunQty1")))
                                        .JulQty1 = If(row("JulQty1") Is DBNull.Value, "0", Convert.ToInt32(row("JulQty1")))
                                        .AgtQty1 = If(row("AgtQty1") Is DBNull.Value, "0", Convert.ToInt32(row("AgtQty1")))
                                        .SepQty1 = If(row("SepQty1") Is DBNull.Value, "0", Convert.ToInt32(row("SepQty1")))
                                        .OktQty1 = If(row("OktQty1") Is DBNull.Value, "0", Convert.ToInt32(row("OktQty1")))
                                        .NovQty1 = If(row("NovQty1") Is DBNull.Value, "0", Convert.ToInt32(row("NovQty1")))
                                        .DesQty1 = If(row("DesQty1") Is DBNull.Value, "0", Convert.ToInt32(row("DesQty1")))

                                        .JanQty2 = If(row("JanQty2") Is DBNull.Value, "0", Convert.ToInt32(row("JanQty2")))
                                        .FebQty2 = If(row("FebQty2") Is DBNull.Value, "0", Convert.ToInt32(row("FebQty2")))
                                        .MarQty2 = If(row("MarQty2") Is DBNull.Value, "0", Convert.ToInt32(row("MarQty2")))
                                        .AprQty2 = If(row("AprQty2") Is DBNull.Value, "0", Convert.ToInt32(row("AprQty2")))
                                        .MeiQty2 = If(row("MeiQty2") Is DBNull.Value, "0", Convert.ToInt32(row("MeiQty2")))
                                        .JunQty2 = If(row("JunQty2") Is DBNull.Value, "0", Convert.ToInt32(row("JunQty2")))
                                        .JulQty2 = If(row("JulQty2") Is DBNull.Value, "0", Convert.ToInt32(row("JulQty2")))
                                        .AgtQty2 = If(row("AgtQty2") Is DBNull.Value, "0", Convert.ToInt32(row("AgtQty2")))
                                        .SepQty2 = If(row("SepQty2") Is DBNull.Value, "0", Convert.ToInt32(row("SepQty2")))
                                        .OktQty2 = If(row("OktQty2") Is DBNull.Value, "0", Convert.ToInt32(row("OktQty2")))
                                        .NovQty2 = If(row("NovQty2") Is DBNull.Value, "0", Convert.ToInt32(row("NovQty2")))
                                        .DesQty2 = If(row("DesQty2") Is DBNull.Value, "0", Convert.ToInt32(row("DesQty2")))

                                        .JanQty3 = If(row("JanQty3") Is DBNull.Value, "0", Convert.ToInt32(row("JanQty3")))
                                        .FebQty3 = If(row("FebQty3") Is DBNull.Value, "0", Convert.ToInt32(row("FebQty3")))
                                        .MarQty3 = If(row("MarQty3") Is DBNull.Value, "0", Convert.ToInt32(row("MarQty3")))
                                        .AprQty3 = If(row("AprQty3") Is DBNull.Value, "0", Convert.ToInt32(row("AprQty3")))
                                        .MeiQty3 = If(row("MeiQty3") Is DBNull.Value, "0", Convert.ToInt32(row("MeiQty3")))
                                        .JunQty3 = If(row("JunQty3") Is DBNull.Value, "0", Convert.ToInt32(row("JunQty3")))
                                        .JulQty3 = If(row("JulQty3") Is DBNull.Value, "0", Convert.ToInt32(row("JulQty3")))
                                        .AgtQty3 = If(row("AgtQty3") Is DBNull.Value, "0", Convert.ToInt32(row("AgtQty3")))
                                        .SepQty3 = If(row("SepQty3") Is DBNull.Value, "0", Convert.ToInt32(row("SepQty3")))
                                        .OktQty3 = If(row("OktQty3") Is DBNull.Value, "0", Convert.ToInt32(row("OktQty3")))
                                        .NovQty3 = If(row("NovQty3") Is DBNull.Value, "0", Convert.ToInt32(row("NovQty3")))
                                        .DesQty3 = If(row("DesQty3") Is DBNull.Value, "0", Convert.ToInt32(row("DesQty3")))

                                        .JanHarga1 = If(row("JanHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("JanHarga1")))
                                        .FebHarga1 = If(row("FebHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("FebHarga1")))
                                        .MarHarga1 = If(row("MarHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("MarHarga1")))
                                        .AprHarga1 = If(row("AprHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("AprHarga1")))
                                        .MeiHarga1 = If(row("MeiHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("MeiHarga1")))
                                        .JunHarga1 = If(row("JunHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("JunHarga1")))
                                        .JulHarga1 = If(row("JulHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("JulHarga1")))
                                        .AgtHarga1 = If(row("AgtHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("AgtHarga1")))
                                        .SepHarga1 = If(row("SepHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("SepHarga1")))
                                        .OktHarga1 = If(row("OktHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("OktHarga1")))
                                        .NovHarga1 = If(row("NovHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("NovHarga1")))
                                        .DesHarga1 = If(row("DesHarga1") Is DBNull.Value, "0", Convert.ToDouble(row("DesHarga1")))

                                        .JanHarga2 = If(row("JanHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("JanHarga2")))
                                        .FebHarga2 = If(row("FebHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("FebHarga2")))
                                        .MarHarga2 = If(row("MarHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("MarHarga2")))
                                        .AprHarga2 = If(row("AprHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("AprHarga2")))
                                        .MeiHarga2 = If(row("MeiHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("MeiHarga2")))
                                        .JunHarga2 = If(row("JunHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("JunHarga2")))
                                        .JulHarga2 = If(row("JulHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("JulHarga2")))
                                        .AgtHarga2 = If(row("AgtHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("AgtHarga2")))
                                        .SepHarga2 = If(row("SepHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("SepHarga2")))
                                        .OktHarga2 = If(row("OktHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("OktHarga2")))
                                        .NovHarga2 = If(row("NovHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("NovHarga2")))
                                        .DesHarga2 = If(row("DesHarga2") Is DBNull.Value, "0", Convert.ToDouble(row("DesHarga2")))

                                        .JanHarga3 = If(row("JanHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("JanHarga3")))
                                        .FebHarga3 = If(row("FebHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("FebHarga3")))
                                        .MarHarga3 = If(row("MarHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("MarHarga3")))
                                        .AprHarga3 = If(row("AprHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("AprHarga3")))
                                        .MeiHarga3 = If(row("MeiHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("MeiHarga3")))
                                        .JunHarga3 = If(row("JunHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("JunHarga3")))
                                        .JulHarga3 = If(row("JulHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("JulHarga3")))
                                        .AgtHarga3 = If(row("AgtHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("AgtHarga3")))
                                        .SepHarga3 = If(row("SepHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("SepHarga3")))
                                        .OktHarga3 = If(row("OktHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("OktHarga3")))
                                        .NovHarga3 = If(row("NovHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("NovHarga3")))
                                        .DesHarga3 = If(row("DesHarga3") Is DBNull.Value, "0", Convert.ToDouble(row("DesHarga3")))

                                        .Jan_PO1 = If(row("Jan PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO1")))
                                        .Feb_PO1 = If(row("Feb PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO1")))
                                        .Mar_PO1 = If(row("Mar PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO1")))
                                        .Apr_PO1 = If(row("Apr PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO1")))
                                        .Mei_PO1 = If(row("Mei PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO1")))
                                        .Jun_PO1 = If(row("Jun PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO1")))
                                        .Jul_PO1 = If(row("Jul PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO1")))
                                        .Agt_PO1 = If(row("Agt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO1")))
                                        .Sep_PO1 = If(row("Sep PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO1")))
                                        .Okt_PO1 = If(row("Okt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO1")))
                                        .Nov_PO1 = If(row("Nov PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO1")))
                                        .Des_PO1 = If(row("Des PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO1")))

                                        .Jan_PO2 = If(row("Jan PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO2")))
                                        .Feb_PO2 = If(row("Feb PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO2")))
                                        .Mar_PO2 = If(row("Mar PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO2")))
                                        .Apr_PO2 = If(row("Apr PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO2")))
                                        .Mei_PO2 = If(row("Mei PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO2")))
                                        .Jun_PO2 = If(row("Jun PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO2")))
                                        .Jul_PO2 = If(row("Jul PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO2")))
                                        .Agt_PO2 = If(row("Agt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO2")))
                                        .Sep_PO2 = If(row("Sep PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO2")))
                                        .Okt_PO2 = If(row("Okt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO2")))
                                        .Nov_PO2 = If(row("Nov PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO2")))
                                        .Des_PO2 = If(row("Des PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO2")))
                                        .created_date = DateTime.Today
                                        .created_by = gh_Common.Username

                                    End With
                                    ObjHeader.ObjForecastCollection.Add(ObjForecast)
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                    Console.WriteLine(ex.Message)
                                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                                    WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, 0, "Invt ID", gh_Common.Username)
                                    Continue For
                                End Try

                            Next
                            ObjHeader.InsertDataADM()
                        End If
                    End If

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
                    'If strTahun <> "" Then
                    '    ObjForecast.DeleteByTahun(strTahun)
                    'End If

                    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                    ObjHeader.ObjForecastCollection.Clear()

                    For i As Integer = 0 To dtFilter.Rows.Count - 1
                        Try
                            ObjForecast = New forecast_price_models
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
                                '.InsertData()

                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, i, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    ObjHeader.Tahun = strTahun
                    ObjHeader.InsertData()
                    SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                    'ProgressBar1.Visible = False
                    'Cursor = Cursors.Default
                    LoadGrid()
                End If
            Catch ex As Exception
                Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                SplashScreenManager.CloseForm()
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
