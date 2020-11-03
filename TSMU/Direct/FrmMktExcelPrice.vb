Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class FrmMktExcelPrice
    Dim cls_UploadPrice As New ClsMktUploadPrice
    Dim proses As String = String.Empty
    Dim path As String = String.Empty
    Dim dtExcel As New DataTable
    Dim dtTemplate As New DataTable
    Dim dtColumn As DataTable
    Dim dtResult As New DataTable
    Dim dtUploadTemp As New DataTable
    Dim dtUpload As New DataTable
    Dim listColumn As New List(Of String)
    Dim isUpload As Boolean = False

    Dim clmPartNoExcel As String = String.Empty
    Dim clmPriceExcelP As String = String.Empty
    Dim clmPriceExcelS As String = String.Empty
    Dim clmDateExcel As String = String.Empty
    Dim clmDescExcel As String = String.Empty

    Dim succes As Integer
    Dim info As Integer
    Dim warning As Integer
    Dim _error As Integer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ReadOnly Property _isUpload() As Boolean
        Get
            Return isUpload
        End Get
    End Property

    ReadOnly Property _dtResult() As DataTable
        Get
            Return dtUpload
        End Get
    End Property

    Public Property CustID() As String
    Public Property Template() As String
    Public Property FileName() As String

    Private Sub FrmMktExcelPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            If String.IsNullOrEmpty(txtTemplate.Text) Then
                Throw New Exception("Template is required !")
            Else
                OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx"
                Dim result As DialogResult = OpenFileDialog1.ShowDialog()
                If result = System.Windows.Forms.DialogResult.OK Then
                    path = OpenFileDialog1.FileName
                    Dim text As String = System.IO.File.ReadAllText(path)
                    txtFileName.Text = path
                    Dim FileInfo As New FileInfo(path)
                    FileName = FileInfo.Name
                    dtResult.Clear()
                    GridResult.DataSource = dtResult
                    GridViewResult.BestFitColumns()
                    GridViewResult.Columns(2).Caption = clmPartNoExcel
                    lblResult.Text = "Total Success : 0 | Total Info : 0 | Total Warning : 0 | Total Error : 0"
                End If
            End If

        Catch ex As Exception When Not TypeOf ex Is MissingMethodException
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If proses <> "" Then
                Throw New Exception("Proses masih berjalan !")
            End If
            If txtFileName.Text = "" Then
                txtFileName.Focus()
                Throw New Exception("File Excel yang akan di upload tidak ada !")
            End If
            Dim connString As String = String.Empty
            Dim extension As String = System.IO.Path.GetExtension(path)

            Select Case extension
                Case ".xls"
                    'Excel 97-03
                    connString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 or higher
                    connString = ConfigurationManager.ConnectionStrings("Excel07+ConString").ConnectionString
                    Exit Select
            End Select

            connString = String.Format(connString, path)
            Using excel_con As New OleDbConnection(connString)
                excel_con.Open()
                'Dim sheet1 As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
                Dim __rows As String = String.Empty
                Dim onWhere As String = String.Empty
                For Each row As DataRow In dtTemplate.Select("TemplateID = '" & txtTemplate.EditValue & "'")
                    __rows = row("SheetName") + "$" + row("StartRow") + ":" + row("EndRow")
                    onWhere = IIf(row("OnWhere") Is DBNull.Value, "", row("OnWhere"))
                Next
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") + __rows) + "]" + onWhere, excel_con)
                    Try
                        dtExcel = New DataTable
                        oda.Fill(dtExcel)
                    Catch ex As Exception
                        Throw New Exception("Pilih template yang sesuai !")
                    End Try
                End Using
                excel_con.Close()
            End Using
            CheckPrice()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub ListItemsTemplate()
        cls_UploadPrice = New ClsMktUploadPrice
        dtTemplate = New DataTable
        dtTemplate = cls_UploadPrice.GetListTemplate(CustID)
        txtTemplate.Properties.DataSource = dtTemplate
        txtTemplate.Size = txtTemplate.CalcBestSize()
        txtTemplate.Properties.PopupFormMinSize = txtTemplate.Size
        txtTemplate.Properties.PopupWidth = txtTemplate.Size.Width
        txtTemplate.EditValue = "001"
    End Sub

    Private Sub CheckPrice()
        dtResult.Clear()
        cls_UploadPrice = New ClsMktUploadPrice
        If checkColumn() = False Then
            Dim No As Integer
            succes = 0
            info = 0
            warning = 0
            _error = 0
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            dt = cls_UploadPrice.CheckInventoryID(CustID)
            For Each rows As DataRow In dtExcel.Rows
                If Not String.IsNullOrEmpty(IIf(rows(clmPartNoExcel) Is DBNull.Value, "", rows(clmPartNoExcel))) Then
                    Dim rowInvtID As DataRow()
                    Dim status As String = "Error"
                    Dim message As String = String.Empty
                    Dim invtID As String = String.Empty
                    Dim newPrice As Double
                    Dim startDate As Date = Date.Today
                    rowInvtID = dt.Select("AlternateID = " & QVal(Replace(rows(clmPartNoExcel), "-", "")) & " ")
                    If rowInvtID.Count = 0 Then
                        No += 1
                        message = "" & clmPartNoExcel & " Not Found !"
                        _error += 1
                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, startDate, status, message)
                    ElseIf rowInvtID.Count = 1 Then
                        No += 1
                        invtID = rowInvtID(0)("InvtID").ToString
                        If clmDateExcel IsNot Nothing Then
                            startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(0)("StartDate"), rows(clmDateExcel)))
                        End If
                        If String.IsNullOrEmpty(IIf(rowInvtID(0)("DiscPrice") Is DBNull.Value, "", rowInvtID(0)("DiscPrice").ToString)) Then
                            message = "Price Not Found !"
                            _error += 1
                            addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, "", status, message)
                        Else
                            If clmPriceExcelS Is Nothing Then
                                newPrice = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            ElseIf rowInvtID(0)("PartType") = "P" OrElse rowInvtID(0)("PartType") = "N" Then
                                newPrice = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            ElseIf rowInvtID(0)("PartType") = "S" Then
                                newPrice = IIf(rows(clmPriceExcelS) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelS))
                            Else
                                newPrice = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            End If
                            If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                status = "Warning"
                                message = "Part No More Than 1 !"
                                warning += 1
                                addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPrice, startDate, status, message)
                            Else
                                status = "Success"
                                succes += 1
                                addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPrice, startDate, status, message)
                            End If
                        End If
                    ElseIf rowInvtID.Count > 1 Then
                        No += 1
                        For j As Integer = 0 To rowInvtID.Count - 1
                            invtID = rowInvtID(j)("InvtID").ToString
                            If clmDateExcel IsNot Nothing Then
                                startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(j)("StartDate"), rows(clmDateExcel)))
                            End If
                            If clmPriceExcelS Is Nothing Then
                                newPrice = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelP))
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    status = "Error"
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, startDate, status, message)
                                Else
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    End If
                                End If
                            ElseIf rowInvtID(j)("PartType") = "P" OrElse rowInvtID(j)("PartType") = "N" Then
                                newPrice = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelP))
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, startDate, status, message)
                                Else
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    End If
                                End If
                            ElseIf rowInvtID(j)("PartType") = "S" Then
                                newPrice = IIf(rows(clmPriceExcelS) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelS))
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, startDate, status, message)
                                Else
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(No, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPrice, startDate, status, message)
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
            SplashScreenManager.CloseForm()
            With GridViewResult
                .Columns("PartNo").Caption = clmPartNoExcel
                .Columns("Desc").Caption = clmDescExcel
                .Columns("No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                GridCellFormat(GridViewResult)
                .BestFitColumns()
            End With
            lblResult.Text = "Total Success : " & succes & " | Total Info : " & info & "| Total Warning : " & warning & " | Total Error : " & _error & ""
            If _error = 0 Then
                btnExport.Text = "Upload"
                With GridViewResult
                    .OptionsBehavior.Editable = True
                    .Columns("No").OptionsColumn.AllowEdit = False
                    .Columns("PartNo").OptionsColumn.AllowEdit = False
                    .Columns("InvtID").OptionsColumn.AllowEdit = False
                    .Columns("Desc").OptionsColumn.AllowEdit = False
                    .Columns("OldPrice").OptionsColumn.AllowEdit = False
                    .Columns("NewPrice").OptionsColumn.AllowEdit = False
                    .Columns("EffectiveDate").OptionsColumn.AllowEdit = False
                    .Columns("Status").OptionsColumn.AllowEdit = False
                    .Columns("Message").OptionsColumn.AllowEdit = False
                End With
            Else
                btnExport.Text = "Save To Excel"
                GridViewResult.OptionsBehavior.Editable = False
            End If
        Else
            dtResult.Clear()
            GridResult.DataSource = dtResult
            GridResult.Refresh()
            lblResult.Text = "Total Success : 0 | Total Info : 0 | Total Warning : 0 | Total Error : 0"
        End If
    End Sub

    Function CheckDuplicateInvtID(partNo As String, _invtID As String) As Boolean
        '' Cek apakah inventory id ada yang sama
        Dim isDuplicate As Boolean = False
        For i As Integer = 0 To GridViewResult.RowCount - 1
            If GridViewResult.GetRowCellValue(i, "PartNo") <> partNo AndAlso GridViewResult.GetRowCellValue(i, "InvtID") = _invtID Then
                If GridViewResult.GetRowCellValue(i, "Status") = "Success" Then
                    succes -= 1
                    warning += 1
                ElseIf GridViewResult.GetRowCellValue(i, "Status") = "Info" Then
                    info -= 1
                    warning += 1
                End If
                GridViewResult.SetRowCellValue(i, "Status", "Warning")
                GridViewResult.SetRowCellValue(i, "Message", "Part No More Than 1 !")
                isDuplicate = True
            End If
        Next
        Return isDuplicate
    End Function

    Private Sub addNewDtResult(No As Integer, partNo As String, invtID As String, Desc As String, oldPrice As Double, newPrice As Double, effDate As Date, Status As String, Message As String)
        Dim newRow As DataRow
        newRow = dtResult.NewRow
        newRow("Check") = True
        newRow("No") = No
        newRow("PartNo") = partNo
        newRow("InvtID") = invtID
        newRow("Desc") = Desc
        newRow("OldPrice") = oldPrice
        newRow("NewPrice") = newPrice
        newRow("EffectiveDate") = effDate
        newRow("Status") = Status
        newRow("Message") = Message
        dtResult.Rows.Add(newRow)
    End Sub

    Private Sub addNewDtUpload()
        Try
            dtUploadTemp.Clear()
            Dim no As Integer
            For i As Integer = 0 To GridViewResult.RowCount - 1
                If GridViewResult.GetRowCellValue(i, "Check") = True Then
                    If GridViewResult.GetRowCellValue(i, "NewPrice") Is DBNull.Value Then
                        Throw New Exception("New Price Is Required !")
                    ElseIf GridViewResult.GetRowCellValue(i, "EffectiveDate") Is DBNull.Value Then
                        Throw New Exception("Effective Date Is Required ! !")
                    Else
                        Dim _newRow As DataRow
                        _newRow = dtUploadTemp.NewRow
                        no += 1
                        _newRow("No") = no
                        _newRow("PartNo") = GridViewResult.GetRowCellValue(i, "PartNo")
                        _newRow("InvtID") = GridViewResult.GetRowCellValue(i, "InvtID")
                        _newRow("PartName") = GridViewResult.GetRowCellValue(i, "Desc")
                        _newRow("OldPrice") = GridViewResult.GetRowCellValue(i, "OldPrice")
                        _newRow("NewPrice") = GridViewResult.GetRowCellValue(i, "NewPrice")
                        _newRow("EffectiveDate") = GridViewResult.GetRowCellValue(i, "EffectiveDate")
                        dtUploadTemp.Rows.Add(_newRow)
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function checkColumn() As Boolean
        Dim isNotFound As Boolean = False
        Try
            For i As Integer = 0 To listColumn.Count - 1
                If listColumn(i) IsNot Nothing AndAlso Not dtExcel.Columns.Contains(listColumn(i)) Then
                    isNotFound = True
                    Throw New Exception("Column (" & listColumn(i) & ") tidak ditemukan, Pilih template yang sesuai!")
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return isNotFound
    End Function

    Public Sub CreateTable()
        dtResult = New DataTable
        dtResult.Columns.AddRange(New DataColumn(9) {New DataColumn("Check", GetType(Boolean)),
                                                    New DataColumn("No", GetType(Integer)),
                                                    New DataColumn("PartNo", GetType(String)),
                                                    New DataColumn("InvtID", GetType(String)),
                                                    New DataColumn("Desc", GetType(String)),
                                                    New DataColumn("OldPrice", GetType(Double)),
                                                    New DataColumn("NewPrice", GetType(Double)),
                                                    New DataColumn("EffectiveDate", GetType(Date)),
                                                    New DataColumn("Status", GetType(String)),
                                                    New DataColumn("Message", GetType(String))})

        dtUploadTemp = New DataTable
        dtUploadTemp.Columns.AddRange(New DataColumn(6) {New DataColumn("No", GetType(Integer)),
                                                        New DataColumn("PartNo", GetType(String)),
                                                        New DataColumn("InvtID", GetType(String)),
                                                        New DataColumn("PartName", GetType(String)),
                                                        New DataColumn("OldPrice", GetType(Double)),
                                                        New DataColumn("NewPrice", GetType(Double)),
                                                        New DataColumn("EffectiveDate", GetType(Date))})
    End Sub

    Private Sub txtTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles txtTemplate.EditValueChanged
        cls_UploadPrice = New ClsMktUploadPrice
        dtColumn = New DataTable
        dtColumn = cls_UploadPrice.GetColumnExcel(txtTemplate.EditValue)
        txtFileName.Text = ""

        For Each _rows As DataRow In dtColumn.Rows
            clmPartNoExcel = Replace(Replace(Replace(_rows("PartNo").ToString, ".", "#"), "[", "("), "]", ")")
            clmPriceExcelP = Replace(Replace(Replace(_rows("PriceP").ToString, ".", "#"), "[", "("), "]", ")")
            clmPriceExcelS = Replace(Replace(Replace(_rows("PriceS").ToString, ".", "#"), "[", "("), "]", ")")
            clmDateExcel = Replace(Replace(Replace(_rows("StartDate").ToString, ".", "#"), "[", "("), "]", ")")
            clmDescExcel = Replace(Replace(Replace(_rows("Desc").ToString, ".", "#"), "[", "("), "]", ")")
        Next
        listColumn = New List(Of String)({clmPartNoExcel, clmDescExcel, clmPriceExcelP, clmPriceExcelS, clmDateExcel})

        dtResult.Clear()
        GridResult.DataSource = dtResult
        GridViewResult.Columns("PartNo").Caption = clmPartNoExcel
        GridViewResult.Columns("Desc").Caption = clmDescExcel
        GridViewResult.BestFitColumns()
        lblResult.Text = "Total Success : 0 | Total Info : 0 | Total Warning : 0 | Total Error : 0"
        btnExport.Text = "Save To Excel"
    End Sub

    Private Sub GridviewResult_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridViewResult.CustomDrawCell
        Dim view As GridView = sender
        If view Is Nothing Then
            Return
        End If
        If view.IsFilterRow(e.RowHandle) Then
            Return
        End If
        If e.Column.FieldName.ToLower = "Status" Then
            If Convert.ToString(e.CellValue).ToLower = "Success" Then
                e.Appearance.BackColor = Color.White
            ElseIf Convert.ToString(e.CellValue).ToLower = "Info" Then
                e.Appearance.BackColor = Color.Blue
                e.Appearance.ForeColor = Color.White
            ElseIf Convert.ToString(e.CellValue).ToLower = "Warning" Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If GridViewResult.RowCount > 0 Then
                If btnExport.Text = "Save To Excel" Then
                    Dim save As New SaveFileDialog With {
                    .Filter = "Excel File|*.xls",
                    .Title = "Save an Excel File"
                }
                    If save.ShowDialog = DialogResult.OK Then
                        GridResult.ExportToXls(save.FileName)
                    End If
                Else
                    Dim dtRows As DataRow()
                    dtRows = dtResult.Select("Check = True")
                    If dtRows.Count > 0 Then
                        If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            addNewDtUpload()
                            dtUpload = dtUploadTemp
                            Template = txtTemplate.Text
                            isUpload = True
                            Me.Close()
                        End If
                    Else
                        Throw New Exception("Please Select Data !")
                    End If
                End If
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Private Sub txtCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtCustomer.ButtonClick
        Dim ls_Judul As String = ""
        Dim dtSearch As New DataTable

        dtSearch = cls_UploadPrice.GetDataCustomer
        ls_Judul = "CUSTOMER"

        Dim lF_SearchData As FrmSystem_LookupGrid
        lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        'lF_SearchData.HiddenCols = 0
        lF_SearchData.Text = "Select Data " & ls_Judul
        lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        lF_SearchData.ShowDialog()

        If lF_SearchData.Values IsNot Nothing Then
            CustID = lF_SearchData.Values.Item(0).ToString.Trim
            txtCustomer.Text = lF_SearchData.Values.Item(1).ToString.Trim
            ListItemsTemplate()
        End If
        lF_SearchData.Close()
    End Sub

End Class