Imports System.Collections.ObjectModel
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class frmForecastDaily
    Dim ff_Detail As frmSales_ForecastPrice_details
    Dim dtGrid As DataTable
    Dim ObjForecast As New forecast_po_model_detail
    Dim ObjHeader As New forecast_po_model

    Dim temp As RepositoryItemCheckedComboBoxEdit = Nothing
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'LoadGrid()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmForecastDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
    End Sub

    Private Function SummaryColumn(ColumName As String) As GridColumnSummaryItem
        Try
            Dim siAverage As New GridColumnSummaryItem()
            siAverage.SummaryType = SummaryItemType.Sum
            siAverage.FieldName = ColumName
            siAverage.DisplayFormat = "{0:#,##0.#0}"
            Return siAverage
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Private Sub LoadGrid()
        Try

            SplashScreenManager.ShowForm(GetType(FrmWait))

            dtGrid = New DataTable
            dtGrid = ObjForecast.GetAllDataGrid(bs_Filter)
            Grid.DataSource = dtGrid


            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If

            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Forecast MDFO"
        Dim Bulan As Integer
        Dim BulanAngka As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmLookupForecastDaily
        frmExcel = New FrmLookupForecastDaily(table) With {
            .Text = "Import " & ls_Judul,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frmExcel.ShowDialog()

        strTahun = frmExcel.Tahun
        Bulan = frmExcel.Bulan
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

            If strCustomer.ToLower = "adm" Then
                If frmExcel.DtAdm.Rows.Count > 0 Then
                    Dim _Service As New AdmService(frmExcel.DtAdm, strCustomer, strTahun, Bulan, frmExcel._Site, frmExcel.Flag)
                    Dim Dt1 As New DataTable
                    Dt1 = _Service.GetExcelData()

                    ObjHeader.ObjForecastCollection.Clear()
                    For Each row As DataRow In Frm.NewDt.Rows
                        ObjForecast = New forecast_po_model_detail
                        With ObjForecast
                            .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun"))
                            .CustID = If(row("CustID") Is DBNull.Value, "", row("CustID"))
                            .Customer = If(row("CustName") Is DBNull.Value, "", row("CustName"))
                            .InvtID = If(row("InvtID") Is DBNull.Value, "", row("InvtID"))
                            .Description = If(row("Description") Is DBNull.Value, "", row("Description"))
                            .PartNo = If(row("PartNo") Is DBNull.Value, "", row("PartNo"))
                            .Model = If(row("Model") Is DBNull.Value, "", row("Model"))
                            .OePe = If(row("Oe") Is DBNull.Value, "", row("Oe"))
                            .INSub = If(row("InSub") Is DBNull.Value, "", row("InSub"))
                            .Site = If(row("Site") Is DBNull.Value, "", row("Site"))
                            .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                            .N = If(row("N") Is DBNull.Value, 0, Convert.ToInt32(row("N")))
                            .N1 = If(row("N1") Is DBNull.Value, 0, Convert.ToInt32(row("N1")))
                            .N2 = If(row("N2") Is DBNull.Value, 0, Convert.ToInt32(row("N2")))
                            .N3 = If(row("N3") Is DBNull.Value, 0, Convert.ToInt32(row("N3")))
                            Select Case BulanAngka
                                Case "01"
                                    .BulanPO = "Jan"
                                    .BulanFC1 = "Feb"
                                    .BulanFC2 = "Mar"
                                    .BulanFC3 = "Apr"
                                Case "02"
                                    .BulanPO = "Feb"
                                    .BulanFC1 = "Mar"
                                    .BulanFC2 = "Apr"
                                    .BulanFC3 = "Mei"
                                Case "03"
                                    .BulanPO = "Mar"
                                    .BulanFC1 = "Apr"
                                    .BulanFC2 = "Mei"
                                    .BulanFC3 = "Jun"
                                Case "04"
                                    .BulanPO = "Apr"
                                    .BulanFC1 = "Mei"
                                    .BulanFC2 = "Jun"
                                    .BulanFC3 = "Jul"
                                Case "05"
                                    .BulanPO = "Mei"
                                    .BulanFC1 = "Jun"
                                    .BulanFC2 = "Jul"
                                    .BulanFC3 = "Agt"
                                Case "06"
                                    .BulanPO = "Jun"
                                    .BulanFC1 = "Jul"
                                    .BulanFC2 = "Agt"
                                    .BulanFC3 = "Sep"
                                Case "07"
                                    .BulanPO = "Jul"
                                    .BulanFC1 = "Agt"
                                    .BulanFC2 = "Sep"
                                    .BulanFC3 = "Okt"
                                Case "08"
                                    .BulanPO = "Agt"
                                    .BulanFC1 = "Sep"
                                    .BulanFC2 = "Okt"
                                    .BulanFC3 = "Nov"
                                Case "09"
                                    .BulanPO = "Sep"
                                    .BulanFC1 = "Okt"
                                    .BulanFC2 = "Nov"
                                    .BulanFC3 = "Des"
                                Case "10"
                                    .BulanPO = "Okt"
                                    .BulanFC1 = "Nov"
                                    .BulanFC2 = "Des"
                                    .BulanFC3 = "Jan"
                                Case "11"
                                    .BulanPO = "Nov"
                                    .BulanFC1 = "Des"
                                    .BulanFC2 = "Jan"
                                    .BulanFC3 = "Feb"
                                Case "12"
                                    .BulanPO = "Des"
                                    .BulanFC1 = "Jan"
                                    .BulanFC2 = "Feb"
                                    .BulanFC3 = "Mar"
                            End Select
                            .created_date = Date.Today
                            .created_by = gh_Common.Username
                        End With
                        ObjHeader.ObjForecastCollection.Add(ObjForecast)
                    Next

                    With ObjHeader
                        .Tahun = strTahun
                        .CustID = strCustomer
                        .Bulan = Bulan
                        .BulanAngka = BulanAngka
                        .PO = frmExcel.PO
                        .InsertDataAdm()
                        SplashScreenManager.CloseForm()
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        LoadGrid()
                    End With
                Else

                    SplashScreenManager.CloseForm()
                End If
            Else
                If table.Rows.Count = 0 Then
                    SplashScreenManager.CloseForm()
                    Return
                End If
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

                    ObjHeader.ObjForecastCollection.Clear()
                    For Each row As DataRow In dtFilter.Rows
                        Try
                            ObjForecast = New forecast_po_model_detail
                            'Dim ObjCollection As New forecast_price_models
                            With ObjForecast
                                .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun"))
                                .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID"))
                                .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer"))
                                .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID"))
                                .Description = If(row("Description") Is DBNull.Value, "", row("Description"))
                                .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No"))
                                .Model = If(row("Model") Is DBNull.Value, "", row("Model"))
                                .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe"))
                                .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB"))
                                .Site = If(row("Site") Is DBNull.Value, "", row("Site"))
                                .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                                .JanQty1 = If(row("Jan Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty1")))
                                .FebQty1 = If(row("Feb Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty1")))
                                .MarQty1 = If(row("Mar Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty1")))
                                .AprQty1 = If(row("Apr Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty1")))
                                .MeiQty1 = If(row("Mei Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty1")))
                                .JunQty1 = If(row("Jun Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty1")))
                                .JulQty1 = If(row("Jul Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty1")))
                                .AgtQty1 = If(row("Agt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty1")))
                                .SepQty1 = If(row("Sep Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty1")))
                                .OktQty1 = If(row("Okt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty1")))
                                .NovQty1 = If(row("Nov Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty1")))
                                .DesQty1 = If(row("Des Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty1")))

                                .JanQty2 = If(row("Jan Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty2")))
                                .FebQty2 = If(row("Feb Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty2")))
                                .MarQty2 = If(row("Mar Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty2")))
                                .AprQty2 = If(row("Apr Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty2")))
                                .MeiQty2 = If(row("Mei Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty2")))
                                .JunQty2 = If(row("Jun Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty2")))
                                .JulQty2 = If(row("Jul Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty2")))
                                .AgtQty2 = If(row("Agt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty2")))
                                .SepQty2 = If(row("Sep Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty2")))
                                .OktQty2 = If(row("Okt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty2")))
                                .NovQty2 = If(row("Nov Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty2")))
                                .DesQty2 = If(row("Des Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty2")))

                                .JanQty3 = If(row("Jan Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty3")))
                                .FebQty3 = If(row("Feb Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty3")))
                                .MarQty3 = If(row("Mar Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty3")))
                                .AprQty3 = If(row("Apr Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty3")))
                                .MeiQty3 = If(row("Mei Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty3")))
                                .JunQty3 = If(row("Jun Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty3")))
                                .JulQty3 = If(row("Jul Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty3")))
                                .AgtQty3 = If(row("Agt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty3")))
                                .SepQty3 = If(row("Sep Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty3")))
                                .OktQty3 = If(row("Okt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty3")))
                                .NovQty3 = If(row("Nov Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty3")))
                                .DesQty3 = If(row("Des Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty3")))

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
                                .N1 = If(row("NY Jan") Is DBNull.Value, "0", Convert.ToInt32(row("NY Jan")))
                                .N2 = If(row("NY Feb") Is DBNull.Value, "0", Convert.ToInt32(row("NY Feb")))
                                .N3 = If(row("NY Mar") Is DBNull.Value, "0", Convert.ToInt32(row("NY Mar")))
                                .created_date = DateTime.Today
                                .created_by = gh_Common.Username
                            End With
                            ObjHeader.ObjForecastCollection.Add(ObjForecast)
                        Catch ex As Exception
                            'MsgBox(ex.Message)
                            Console.WriteLine(ex.Message)
                            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            WriteSalesToErrorLog("ForecastPrice", "Log", dtFilter, 0, "Invt ID", gh_Common.Username)
                            Continue For
                        End Try
                    Next
                    With ObjHeader
                        .Tahun = strTahun
                        .CustID = strCustomer
                        .Bulan = Bulan
                        .BulanAngka = BulanAngka
                        .InsertData1()

                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        SplashScreenManager.CloseForm()
                        LoadGrid()
                    End With
                    'ObjForecast.UpdateDataByBulanNew(Bulan)
                End If
                SplashScreenManager.CloseForm()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

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

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ExportToExcelTSM_Click(sender As Object, e As EventArgs) Handles ExportToExcelTSM.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    ContextMenuStrip1.Show(e.Location)
        'End If
    End Sub


    Private Sub frmForecastDaily_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadGrid()
    End Sub
    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Tahun", GetType(String))
        dtTemp.Columns.Add("CustID", GetType(String))
        dtTemp.Columns.Add("InvtID", GetType(String))
        dtTemp.Columns.Add("PartNo", GetType(String))
        dtTemp.Columns.Add("Flag", GetType(String))
        dtTemp.Columns.Add("Site", GetType(String))
        dtTemp.Clear()
    End Sub

End Class
