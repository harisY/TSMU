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
    Dim ObjForecast As New ForecastDailyModel
    Dim ObjHeader As New forecast_po_model
    Dim Service As New ForecastDailyService

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
            dtGrid = Service.GetDataGrid()
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
        Dim Tahun As String = ""
        Dim DtTanggal As New DataTable
        Dim frmExcel As FrmLookupForecastDaily
        frmExcel = New FrmLookupForecastDaily() With {
            .Text = "Import " & ls_Judul,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frmExcel.ShowDialog()

        Tahun = frmExcel.Tahun
        Bulan = frmExcel.Bulan
        table = frmExcel.DtExcel
        Try
            DtTanggal = UnpivotDataTable2(table)
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            If DtTanggal.Rows.Count > 0 Then
                Service.ObjForecastCollection.Clear()
                For Each row As DataRow In DtTanggal.Rows
                    If row(5).ToString().AsInt() = 0 Then
                        Continue For
                    End If
                    ObjForecast = New ForecastDailyModel
                    With ObjForecast
                        .Tahun = Tahun
                        .Bulan = Bulan
                        .PartNo = row(0).ToString().AsString()
                        .UniqueNo = row(1).ToString().AsString()
                        .PartName = row(2).ToString().AsString()
                        .QtyKanban = row(3).ToString().AsInt()
                        .Tgl = row(5).ToString().AsInt()
                        .Qty = row(6).ToString().AsInt()
                    End With
                    Service.ObjForecastCollection.Add(ObjForecast)
                Next
                Service.Insert()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            SplashScreenManager.CloseForm()
            LoadGrid()

        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Shared Function UnpivotDataTable1(ByVal pivoted As DataTable) As DataTable
        Dim columnNames As String() = pivoted.Columns.Cast(Of DataColumn)().[Select](Function(x) x.ColumnName).ToArray()
        Dim unpivoted = New DataTable("unpivot")
        unpivoted.Columns.Add(pivoted.Columns(1).ColumnName, pivoted.Columns(1).DataType)
        'unpivoted.Columns.Add("Tgl", GetType(Integer))
        unpivoted.Columns.Add("Qty", GetType(String))

        For r As Integer = 0 To pivoted.Rows.Count - 1

            For c As Integer = 1 To columnNames.Length - 1
                Dim value = pivoted.Rows(r)(c)?.ToString()

                If Not String.IsNullOrWhiteSpace(value) Then
                    unpivoted.Rows.Add(pivoted.Rows(r)(1), value)
                End If
            Next
        Next

        Return unpivoted
    End Function
    Public Function UnpivotDataTable(ByVal dt As DataTable) As DataTable
        Dim columnNames As String() = dt.Columns.Cast(Of DataColumn)().[Select](Function(x) x.ColumnName).ToArray()
        Dim dt2 = New DataTable("unpivot")
        dt2.Columns.Add("Headers", GetType(String))

        For rowIndex As Integer = 0 To dt.Rows.Count - 1
            dt2.Columns.Add("Row" & rowIndex.ToString(), GetType(String))
        Next

        For i As Integer = 0 To columnNames.Length - 1

            dt2.Rows.Add(
                    columnNames(i),
                    dt.Rows(i).ItemArray(i)
                    )
        Next

        Return dt2
    End Function

    Public Function UnpivotDataTable2(ByVal dt As DataTable) As DataTable
        Try
            Dim NewDt As DataTable = New DataTable()
            NewDt.Columns.Add(New DataColumn("PartNo", GetType(String)))
            NewDt.Columns.Add(New DataColumn("Unique No", GetType(String)))
            NewDt.Columns.Add(New DataColumn("Part Name", GetType(String)))
            NewDt.Columns.Add(New DataColumn("Qty Kbn", GetType(Integer)))
            NewDt.Columns.Add(New DataColumn("Qty Box", GetType(Integer)))
            NewDt.Columns.Add(New DataColumn("Tgl", GetType(Integer)))
            NewDt.Columns.Add(New DataColumn("Qty", GetType(Integer)))

            'If dt.Rows.Count > 42 Then
            '    Throw New Exception("Jumlah Kolom tidak valid !")
            'End If
            For Each dr As DataRow In dt.Rows
                Dim colCount As Integer = 0

                For Each dc As DataColumn In dt.Columns

                    If colCount >= 10 AndAlso dr(1).ToString().AsString() <> "" Then
                        Dim dr2 As DataRow = NewDt.NewRow()
                        dr2("PartNo") = dr(1).ToString().AsString()
                        dr2("Unique No") = dr(2).ToString().AsString()
                        dr2("Part Name") = dr(3).ToString().AsString()
                        dr2("Qty Kbn") = dr(4).ToString().AsString()
                        dr2("Qty Box") = dr(5).ToString().AsInt()
                        dr2("Tgl") = dc.ColumnName.AsInt()
                        dr2("Qty") = dr(dc).ToString().AsInt()
                        NewDt.Rows.Add(dr2)
                    End If

                    colCount += 1
                Next
            Next
            Return NewDt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
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
        dtTemp.Columns.Add("Check", GetType(Boolean))
        dtTemp.Columns.Add("Tahun", GetType(String))
        dtTemp.Columns.Add("CustID", GetType(String))
        dtTemp.Columns.Add("CustName", GetType(String))
        dtTemp.Columns.Add("InvtID", GetType(String))
        dtTemp.Columns.Add("Description", GetType(String))
        dtTemp.Columns.Add("PartNo", GetType(String))
        dtTemp.Columns.Add("Model", GetType(String))
        dtTemp.Columns.Add("Oe", GetType(String))
        dtTemp.Columns.Add("InSub", GetType(String))
        dtTemp.Columns.Add("Site", GetType(String))
        dtTemp.Columns.Add("Flag", GetType(String))
        dtTemp.Columns.Add("N", GetType(Integer))
        dtTemp.Columns.Add("N1", GetType(Integer))
        dtTemp.Columns.Add("N2", GetType(Integer))
        dtTemp.Columns.Add("N3", GetType(Integer))
        dtTemp.Clear()
    End Sub

End Class
