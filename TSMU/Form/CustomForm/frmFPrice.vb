Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraSplashScreen
Public Class frmFPrice
    Dim ObjCommon As CommonModel

    Dim ObjForecast As New forecast_price_models
    Dim ObjHeader As New forecast_price_models_header
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        TForecastPrice1TableAdapter.Connection.ConnectionString = GetConnString()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub TForecastPrice1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TForecastPrice1BindingNavigatorSaveItem.Click

        Try
            Me.Validate()
            Me.TForecastPrice1BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.DataSet1)
            MsgBox("Data Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub frmFPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.tForecastPrice1' table. You can move, or remove it, as needed.
        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
        With GridView1
            .BestFitColumns()

            .Columns(0).Visible = False

            .FixedLineWidth = 2
            .Columns(1).Fixed = Columns.FixedStyle.Left
            .Columns(2).Fixed = Columns.FixedStyle.Left
            .Columns(3).Fixed = Columns.FixedStyle.Left
            .Columns(4).Fixed = Columns.FixedStyle.Left
            .Columns(11).Fixed = Columns.FixedStyle.Left
            '.OptionsView.ShowFooter = True
            '.OptionsBehavior.Editable = False
        End With
        SetEditColumnGrid()
    End Sub
    Private Sub SetEditColumnGrid()
        Try
            Dim cmbCustID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInvtID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbSite As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbOE As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbFlag As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInhouse As RepositoryItemComboBox = New RepositoryItemComboBox()

            AddHandler cmbCustID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInvtID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbSite.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbOE.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbFlag.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInhouse.EditValueChanged, AddressOf ComboBox_EditValueChanged

            ObjCommon = New CommonModel
            Dim dt As New DataTable
            dt = ObjCommon.GeCustID
            cmbCustID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbCustID.Items.Add(dt.Rows(i).Item("CustId").ToString())
            Next
            GridView1.Columns("CustID").ColumnEdit = cmbCustID
            TForecastPrice1GridControl.RepositoryItems.Add(cmbCustID)

            dt = New DataTable
            dt = ObjCommon.GetInvtID
            cmbInvtID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbInvtID.Items.Add(dt.Rows(i).Item("InvtID").ToString())
            Next
            cmbOE.Items.AddRange(New String() {"OE", "PE"})
            cmbSite.Items.AddRange(New String() {"TNG-U", "TSC3-U"})
            cmbFlag.Items.AddRange(New String() {"N/A", "KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"})
            cmbInhouse.Items.AddRange(New String() {"Inhouse", "Subcon"})

            With GridView1
                .Columns("CustID").ColumnEdit = cmbCustID
                .Columns("InvtID").ColumnEdit = cmbInvtID
                .Columns("Oe/Pe").ColumnEdit = cmbOE
                .Columns("IN/SUB").ColumnEdit = cmbInhouse
                .Columns("Site").ColumnEdit = cmbSite
                .Columns("Flag").ColumnEdit = cmbFlag
            End With
            With TForecastPrice1GridControl.RepositoryItems
                .Add(cmbCustID)
                .Add(cmbInvtID)
                .Add(cmbOE)
                .Add(cmbInhouse)
                .Add(cmbSite)
                .Add(cmbFlag)
            End With

            'AddHandler GridView1.CustomColumnDisplayText, AddressOf GridView1_CustomColumnDisplayText
            'AddHandler GridView1.ShowingEditor, AddressOf GridView1_ShowingEditor
            'AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'GridView1.PostEditor()
            'GridView1.UpdateCurrentRow()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub tsbImport_Click(sender As Object, e As EventArgs) Handles tsbImport.Click
        Try
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
                        For Each row As DataRow In dtFilter.Rows
                            Try
                                ObjForecast = New forecast_price_models
                                'Dim ObjCollection As New forecast_price_models
                                With ObjForecast
                                    .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                                    .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID").ToString())
                                    .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                                    .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID").ToString())
                                    .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                                    .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                                    .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                                    .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe").ToString())
                                    .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                                    .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
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

                                    .JanHarga1 = If(row("Jan Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga1")))
                                    .FebHarga1 = If(row("Feb Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga1")))
                                    .MarHarga1 = If(row("Mar Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga1")))
                                    .AprHarga1 = If(row("Apr Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga1")))
                                    .MeiHarga1 = If(row("Mei Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga1")))
                                    .JunHarga1 = If(row("Jun Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga1")))
                                    .JulHarga1 = If(row("Jul Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga1")))
                                    .AgtHarga1 = If(row("Agt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga1")))
                                    .SepHarga1 = If(row("Sep Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga1")))
                                    .OktHarga1 = If(row("Okt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga1")))
                                    .NovHarga1 = If(row("Nov Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga1")))
                                    .DesHarga1 = If(row("Des Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga1")))

                                    .JanHarga2 = If(row("Jan Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga2")))
                                    .FebHarga2 = If(row("Feb Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga2")))
                                    .MarHarga2 = If(row("Mar Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga2")))
                                    .AprHarga2 = If(row("Apr Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga2")))
                                    .MeiHarga2 = If(row("Mei Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga2")))
                                    .JunHarga2 = If(row("Jun Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga2")))
                                    .JulHarga2 = If(row("Jul Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga2")))
                                    .AgtHarga2 = If(row("Agt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga2")))
                                    .SepHarga2 = If(row("Sep Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga2")))
                                    .OktHarga2 = If(row("Okt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga2")))
                                    .NovHarga2 = If(row("Nov Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga2")))
                                    .DesHarga2 = If(row("Des Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga2")))

                                    .JanHarga3 = If(row("Jan Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga3")))
                                    .FebHarga3 = If(row("Feb Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga3")))
                                    .MarHarga3 = If(row("Mar Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga3")))
                                    .AprHarga3 = If(row("Apr Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga3")))
                                    .MeiHarga3 = If(row("Mei Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga3")))
                                    .JunHarga3 = If(row("Jun Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga3")))
                                    .JulHarga3 = If(row("Jul Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga3")))
                                    .AgtHarga3 = If(row("Agt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga3")))
                                    .SepHarga3 = If(row("Sep Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga3")))
                                    .OktHarga3 = If(row("Okt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga3")))
                                    .NovHarga3 = If(row("Nov Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga3")))
                                    .DesHarga3 = If(row("Des Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga3")))

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
                            .InsertData1()
                            SplashScreenManager.CloseForm()
                            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                            Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
                        End With

                    End If
                Catch ex As Exception
                    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    SplashScreenManager.CloseForm()
                    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

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

                        For Each row As DataRow In dtFilter.Rows
                            Try
                                ObjForecast = New forecast_price_models
                                With ObjForecast
                                    .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                                    .CustID = If(row("Cust ID") Is DBNull.Value, "", row("Cust ID").ToString())
                                    .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                                    .InvtID = If(row("Invt ID") Is DBNull.Value, "", row("Invt ID").ToString())
                                    .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                                    .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                                    .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                                    .OePe = If(row("Oe/Pe") Is DBNull.Value, "", row("Oe/Pe").ToString())
                                    .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                                    .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
                                    .Flag = If(row("Flag") Is DBNull.Value, "", row("Flag").ToString())
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

                                    .JanHarga1 = If(row("Jan Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga1")))
                                    .FebHarga1 = If(row("Feb Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga1")))
                                    .MarHarga1 = If(row("Mar Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga1")))
                                    .AprHarga1 = If(row("Apr Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga1")))
                                    .MeiHarga1 = If(row("Mei Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga1")))
                                    .JunHarga1 = If(row("Jun Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga1")))
                                    .JulHarga1 = If(row("Jul Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga1")))
                                    .AgtHarga1 = If(row("Agt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga1")))
                                    .SepHarga1 = If(row("Sep Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga1")))
                                    .OktHarga1 = If(row("Okt Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga1")))
                                    .NovHarga1 = If(row("Nov Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga1")))
                                    .DesHarga1 = If(row("Des Harga1") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga1")))

                                    .JanHarga2 = If(row("Jan Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga2")))
                                    .FebHarga2 = If(row("Feb Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga2")))
                                    .MarHarga2 = If(row("Mar Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga2")))
                                    .AprHarga2 = If(row("Apr Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga2")))
                                    .MeiHarga2 = If(row("Mei Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga2")))
                                    .JunHarga2 = If(row("Jun Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga2")))
                                    .JulHarga2 = If(row("Jul Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga2")))
                                    .AgtHarga2 = If(row("Agt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga2")))
                                    .SepHarga2 = If(row("Sep Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga2")))
                                    .OktHarga2 = If(row("Okt Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga2")))
                                    .NovHarga2 = If(row("Nov Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga2")))
                                    .DesHarga2 = If(row("Des Harga2") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga2")))

                                    .JanHarga3 = If(row("Jan Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jan Harga3")))
                                    .FebHarga3 = If(row("Feb Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Feb Harga3")))
                                    .MarHarga3 = If(row("Mar Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mar Harga3")))
                                    .AprHarga3 = If(row("Apr Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Apr Harga3")))
                                    .MeiHarga3 = If(row("Mei Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Mei Harga3")))
                                    .JunHarga3 = If(row("Jun Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jun Harga3")))
                                    .JulHarga3 = If(row("Jul Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Jul Harga3")))
                                    .AgtHarga3 = If(row("Agt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Agt Harga3")))
                                    .SepHarga3 = If(row("Sep Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Sep Harga3")))
                                    .OktHarga3 = If(row("Okt Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Okt Harga3")))
                                    .NovHarga3 = If(row("Nov Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Nov Harga3")))
                                    .DesHarga3 = If(row("Des Harga3") Is DBNull.Value, "0", Convert.ToDouble(row("Des Harga3")))

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
                        ObjHeader.Tahun = strTahun
                        ObjHeader.InsertData()
                        SplashScreenManager.CloseForm()
                        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
                    End If
                Catch ex As Exception
                    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                    SplashScreenManager.CloseForm()
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            SplashScreenManager.CloseForm()
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(TForecastPrice1GridControl)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub

    Private Sub CekHargaBedaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekHargaBedaToolStripMenuItem.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetHargaSAPKAP_ADM

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST HARGA INVENTORY SAMA TAPI HARGA BEDA", 0)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CekInventory1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CekInventory1ToolStripMenuItem.Click
        Try
            ObjForecast = New forecast_price_models
            Dim dt As New DataTable
            dt = ObjForecast.GetDoubleInvtID

            If Not isOpen("frmListHargaADM") Then
                Dim f = frmListHargaADM
                f = New frmListHargaADM(dt, "LIST INVENTORY ID YANG LEBIH DARI 1", 1)
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show()
            Else
                XtraMessageBox.Show("Form sudah terbuka !")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        Try
            Dim gridView As GridView = TryCast(sender, GridView)
            Dim hitInfo As GridHitInfo = gridView.CalcHitInfo(e.Location)
            If hitInfo.Column Is Nothing OrElse hitInfo.Column.FieldName = "Tahun" _
                OrElse hitInfo.Column.FieldName = "CustID" _
                OrElse hitInfo.Column.FieldName = "InvtID" _
                OrElse hitInfo.Column.FieldName = "Model" Then
                Return
            End If

            Me.BeginInvoke(Sub()
                               gridView.ShowEditorByMouse()
                           End Sub)
            'Me.BeginInvoke(New MethodInvoker(Function()
            '                                     gridView.ShowEditorByMouse()
            '                                 End Function))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If GridView1.FocusedColumn.FieldName = "CustID" Then
                ObjHeader = New forecast_price_models_header
                Dim CustID = If(GridView1.GetFocusedRowCellValue("CustID") Is DBNull.Value, "", Convert.ToString(GridView1.GetFocusedRowCellValue("CustID")))
                If CustID = "" Then
                    Exit Sub
                End If
                Dim dt As New DataTable
                dt = ObjHeader.GetInventoryName(CustID)
                If dt.Rows.Count > 0 Then
                    GridView1.FocusedColumn = GridView1.VisibleColumns(2)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Customer", dt.Rows(0)(0))
                    'GridView1.PostEditor()
                    'GridView1.CloseEditor()
                    'GridView1.UpdateCurrentRow()
                    'GridView1.FocusedColumn = GridView1.VisibleColumns(3)
                Else
                    MsgBox("Data tidak ditemukan !")
                End If

            End If

            If GridView1.FocusedColumn.FieldName = "InvtID" Then
                Dim ObjInvt As New global_function_models

                Dim InvtID = If(GridView1.GetFocusedRowCellValue("InvtID") Is DBNull.Value, "", GridView1.GetFocusedRowCellValue("InvtID"))
                If InvtID = "" Then
                    Exit Sub
                End If
                Dim dt As New DataTable
                dt = ObjInvt.getPartNo_Solomon(InvtID)
                If dt.Rows.Count > 0 Then
                    GridView1.FocusedColumn = GridView1.VisibleColumns(6)
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Description", dt.Rows(0)(2))
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "PartNo", dt.Rows(0)(1))
                    'GridView1.PostEditor()
                    'GridView1.CloseEditor()
                    'GridView1.UpdateCurrentRow()
                Else
                    MsgBox("Data tidak ditemukan !")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbRefresh_Click(sender As Object, e As EventArgs) Handles tsbRefresh.Click
        TampilGrid()
    End Sub
    Private Sub TampilGrid()
        Me.TForecastPrice1TableAdapter.Fill(Me.DataSet1.tForecastPrice1)
    End Sub
End Class