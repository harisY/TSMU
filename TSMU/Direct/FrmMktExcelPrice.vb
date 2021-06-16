Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.OleDb
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
    Dim clmPartNoExcelS As String = String.Empty
    Dim clmPriceExcelP As String = String.Empty
    Dim clmPriceExcelS As String = String.Empty
    Dim clmDateExcel As String = String.Empty
    Dim clmDescExcel As String = String.Empty

    Dim succes As Integer
    Dim info As Integer
    Dim warning As Integer
    Dim _error As Integer
    Dim No As Integer
    Dim totSelected As Integer
    Dim isCheck As Boolean
    Dim maxTotTrans As Integer

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
    Public Property Revised() As String
    Public Property TotRecortExcel() As String

    Private Sub FrmMktExcelPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
        GridResult.DataSource = dtResult
        GridViewResult.BestFitColumns()
        StatusList()
    End Sub

    Private Sub txtCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtCustomer.ButtonClick
        Dim ls_Judul As String = ""
        Dim dtSearch As New DataTable

        dtSearch = cls_UploadPrice.GetDataCustomer
        ls_Judul = "CUSTOMER"

        Dim lF_SearchData As FrmSystem_LookupGrid
        lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
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

    Private Sub txtTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles txtTemplate.EditValueChanged
        cls_UploadPrice = New ClsMktUploadPrice
        dtColumn = New DataTable
        dtColumn = cls_UploadPrice.GetColumnExcel(txtTemplate.EditValue)
        txtFileName.Text = ""

        For Each _rows As DataRow In dtColumn.Rows
            clmPartNoExcel = Replace(Replace(Replace(_rows("PartNoR").ToString, ".", "#"), "[", "("), "]", ")")
            clmPartNoExcelS = Replace(Replace(Replace(_rows("PartNoS").ToString, ".", "#"), "[", "("), "]", ")")
            clmPriceExcelP = Replace(Replace(Replace(_rows("PriceP").ToString, ".", "#"), "[", "("), "]", ")")
            clmPriceExcelS = Replace(Replace(Replace(_rows("PriceS").ToString, ".", "#"), "[", "("), "]", ")")
            clmDateExcel = Replace(Replace(Replace(_rows("StartDate").ToString, ".", "#"), "[", "("), "]", ")")
            clmDescExcel = Replace(Replace(Replace(_rows("Desc").ToString, ".", "#"), "[", "("), "]", ")")
        Next
        listColumn = New List(Of String)({clmPartNoExcel, clmPartNoExcelS, clmDescExcel, clmPriceExcelP, clmPriceExcelS, clmDateExcel})

        dtResult.Clear()
        GridResult.DataSource = dtResult
        GridViewResult.BestFitColumns()
        StatusList()
        btnExport.Text = "Save To Excel"
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
                    StatusList()
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
                Dim dtSheets As DataTable = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim listSheet As New List(Of String)
                Dim drSheet As DataRow

                For Each drSheet In dtSheets.Rows
                    listSheet.Add(Replace(drSheet("TABLE_NAME").ToString(), "'", ""))
                Next

                Dim __rows As String = String.Empty
                Dim onWhere As String = String.Empty
                Dim sheetName As String = String.Empty
                For Each row As DataRow In dtTemplate.Select("TemplateID = '" & txtTemplate.EditValue & "'")
                    sheetName = row("SheetName")
                    __rows = sheetName + "$" + row("StartRow") + ":" + row("EndRow")
                    onWhere = IIf(row("OnWhere") Is DBNull.Value, "", row("OnWhere"))
                Next

                If Not listSheet.Contains(sheetName + "$") Then
                    Throw New Exception("Sheet " & sheetName & " Not Found !")
                End If

                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") + __rows) + "]" + onWhere, excel_con)
                    Try
                        dtExcel = New DataTable
                        oda.Fill(dtExcel)
                    Catch ex As Exception
                        Throw New Exception("Template does not match !")
                    End Try
                End Using
                excel_con.Close()
            End Using
            CheckPrice()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CheckPrice()
        dtResult.Clear()
        cls_UploadPrice = New ClsMktUploadPrice
        If checkColumn() = False Then
            Dim NoExcel As Integer
            succes = 0
            info = 0
            warning = 0
            _error = 0
            No = 0
            totSelected = 0
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            dt = cls_UploadPrice.CheckInventoryID(CustID)
            For Each rows As DataRow In dtExcel.Rows
#Region "Kolom partno ke-1"
                If Not String.IsNullOrEmpty(IIf(rows(clmPartNoExcel) Is DBNull.Value, "", rows(clmPartNoExcel))) Then
                    Dim rowInvtID As DataRow()
                    Dim status As String = "Error"
                    Dim message As String = String.Empty
                    Dim invtID As String = String.Empty
                    Dim newPriceR As Double
                    Dim newPriceS As Double
                    Dim startDate As Date = Date.Today
                    rowInvtID = dt.Select("AlternateID = " & QVal(Replace(rows(clmPartNoExcel), "-", "")) & " ")
                    NoExcel += 1
                    isCheck = True
                    maxTotTrans = 0
                    If rowInvtID.Count = 0 Then
                        'Jika partno / alternateid tidak ditemukan di Master
                        message = "Part No Not Found !"
                        _error += 1
                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                    ElseIf rowInvtID.Count = 1 Then
                        'Jika 1 partno memiliki 1 inventoryid
                        newPriceR = 0
                        newPriceS = 0
                        invtID = rowInvtID(0)("InvtID").ToString
                        If clmDateExcel IsNot Nothing Then
                            startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(0)("StartDate"), rows(clmDateExcel)))
                        End If
                        If String.IsNullOrEmpty(IIf(rowInvtID(0)("DiscPrice") Is DBNull.Value, "", rowInvtID(0)("DiscPrice").ToString)) Then
                            status = "Error"
                            message = "Price Not Found !"
                            _error += 1
                            addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                        Else
                            If clmPriceExcelS Is Nothing OrElse clmPartNoExcelS IsNot Nothing Then
                                newPriceR = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            ElseIf rowInvtID(0)("PartType") = "P" OrElse rowInvtID(0)("PartType") = "N" Then
                                newPriceR = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            ElseIf rowInvtID(0)("PartType") = "S" Then
                                newPriceS = IIf(rows(clmPriceExcelS) Is DBNull.Value, rows(clmPriceExcelP), rows(clmPriceExcelS))
                            Else
                                newPriceR = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelP))
                            End If
                            If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                status = "Warning"
                                message = "Part No More Than 1 !"
                                warning += 1
                                addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                            Else
                                status = "Success"
                                succes += 1
                                addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                            End If
                        End If
                    ElseIf rowInvtID.Count > 1 Then
                        'Jika inventory id lebih dari 1
                        For j As Integer = 0 To rowInvtID.Count - 1
                            newPriceR = 0
                            newPriceS = 0
                            isCheck = True
                            maxTotTrans = 0
                            invtID = rowInvtID(j)("InvtID").ToString
                            If clmDateExcel IsNot Nothing Then
                                startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(j)("StartDate"), rows(clmDateExcel)))
                            End If
                            If clmPriceExcelS Is Nothing OrElse clmPartNoExcelS IsNot Nothing Then
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    status = "Error"
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                                Else
                                    newPriceR = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelP))
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    End If
                                End If
                            ElseIf rowInvtID(j)("PartType") = "P" OrElse rowInvtID(j)("PartType") = "N" Then
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    status = "Error"
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                                Else
                                    newPriceR = IIf(rows(clmPriceExcelP) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelP))
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    End If
                                End If
                            ElseIf rowInvtID(j)("PartType") = "S" Then
                                If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                    status = "Error"
                                    message = "Price Not Found !"
                                    _error += 1
                                    addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                                Else
                                    newPriceS = IIf(rows(clmPriceExcelS) Is DBNull.Value, rows(clmPriceExcelP), rows(clmPriceExcelS))
                                    If CheckDuplicateInvtID(rows(clmPartNoExcel), invtID) Then
                                        status = "Warning"
                                        message = "Part No More Than 1 !"
                                        warning += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    Else
                                        status = "Info"
                                        message = "Invt ID More Than 1 !"
                                        info += 1
                                        addNewDtResult(NoExcel, rows(clmPartNoExcel), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
#End Region

#Region "Jika ada kolom partno ke-2"
                If clmPartNoExcelS IsNot Nothing AndAlso Not String.IsNullOrEmpty(IIf(rows(clmPartNoExcelS) Is DBNull.Value, "", rows(clmPartNoExcelS))) Then
                    Dim rowInvtID As DataRow()
                    Dim status As String = "Error"
                    Dim message As String = String.Empty
                    Dim invtID As String = String.Empty
                    Dim newPriceR As Double = 0
                    Dim newPriceS As Double = 0
                    Dim startDate As Date = Date.Today
                    rowInvtID = dt.Select("AlternateID = " & QVal(Replace(rows(clmPartNoExcelS), "-", "")) & " ")
                    isCheck = True
                    maxTotTrans = 0
                    If rowInvtID.Count = 0 Then
                        'Jika partno / alternateid tidak ditemukan di Master
                        message = "Part No Not Found !"
                        _error += 1
                        addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                    ElseIf rowInvtID.Count = 1 Then
                        'Jika 1 partno memiliki 1 inventoryid
                        newPriceR = 0
                        newPriceS = 0
                        invtID = rowInvtID(0)("InvtID").ToString
                        If clmDateExcel IsNot Nothing Then
                            startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(0)("StartDate"), rows(clmDateExcel)))
                        End If
                        If String.IsNullOrEmpty(IIf(rowInvtID(0)("DiscPrice") Is DBNull.Value, "", rowInvtID(0)("DiscPrice").ToString)) Then
                            status = "Error"
                            message = "Price Not Found !"
                            _error += 1
                            addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                        Else
                            newPriceS = IIf(rows(clmPriceExcelS) Is DBNull.Value, rowInvtID(0)("DiscPrice"), rows(clmPriceExcelS))
                            If CheckDuplicateInvtID(rows(clmPartNoExcelS), invtID) Then
                                status = "Warning"
                                message = "Part No More Than 1 !"
                                warning += 1
                                addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                            Else
                                status = "Success"
                                succes += 1
                                addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), rowInvtID(0)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                            End If
                        End If
                    ElseIf rowInvtID.Count > 1 Then
                        'Jika inventory id lebih dari 1
                        For j As Integer = 0 To rowInvtID.Count - 1
                            newPriceR = 0
                            newPriceS = 0
                            isCheck = True
                            maxTotTrans = 0
                            invtID = rowInvtID(j)("InvtID").ToString
                            If clmDateExcel IsNot Nothing Then
                                startDate = Convert.ToDateTime(IIf(rows(clmDateExcel) Is DBNull.Value, rowInvtID(j)("StartDate"), rows(clmDateExcel)))
                            End If
                            If String.IsNullOrEmpty(IIf(rowInvtID(j)("DiscPrice") Is DBNull.Value, "", rowInvtID(j)("DiscPrice").ToString)) Then
                                status = "Error"
                                message = "Price Not Found !"
                                _error += 1
                                addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), 0, 0, 0, startDate, status, message)
                            Else
                                newPriceS = IIf(rows(clmPriceExcelS) Is DBNull.Value, rowInvtID(j)("DiscPrice"), rows(clmPriceExcelS))
                                If CheckDuplicateInvtID(rows(clmPartNoExcelS), invtID) Then
                                    status = "Warning"
                                    message = "Part No More Than 1 !"
                                    warning += 1
                                    addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                Else
                                    status = "Info"
                                    message = "Invt ID More Than 1 !"
                                    info += 1
                                    addNewDtResult(NoExcel, rows(clmPartNoExcelS), invtID, rows(clmDescExcel), rowInvtID(j)("DiscPrice"), newPriceR, newPriceS, startDate, status, message)
                                End If
                            End If
                        Next
                    End If
                End If
#End Region
            Next
            SplashScreenManager.CloseForm()
            GridCellFormat(GridViewResult)
            GridViewResult.BestFitColumns()
            GridViewResult.Columns("No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            GridViewResult.Columns("NoExcel").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            StatusList(succes, info, warning, _error, totSelected)
            If _error = 0 Then
                btnExport.Text = "Upload"
            Else
                btnExport.Text = "Save To Excel"
            End If
        Else
            dtResult.Clear()
            GridResult.DataSource = dtResult
            GridResult.Refresh()
            StatusList()
        End If
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

    Function CheckDuplicateInvtID(partNo As String, _invtID As String) As Boolean
        '' Cek apakah inventory id ada yang sama
        Dim isDuplicate As Boolean = False
        For i As Integer = 0 To GridViewResult.RowCount - 1
            If GridViewResult.GetRowCellValue(i, "PartNo") <> partNo AndAlso GridViewResult.GetRowCellValue(i, "InvtID") = _invtID Then
                cls_UploadPrice = New ClsMktUploadPrice
                maxTotTrans = GridViewResult.GetRowCellValue(i, "MaxTotTrans")
                If GridViewResult.GetRowCellValue(i, "Status") = "Success" Then
                    succes -= 1
                    warning += 1
                ElseIf GridViewResult.GetRowCellValue(i, "Status") = "Info" Then
                    info -= 1
                    warning += 1
                End If

                Dim totTransPrev As Integer = cls_UploadPrice.GetTotalTrans(GridViewResult.GetRowCellValue(i, "PartNo"), GridViewResult.GetRowCellValue(i, "InvtID"))
                Dim totTransCurr As Integer = cls_UploadPrice.GetTotalTrans(partNo, _invtID)

                If totTransPrev > maxTotTrans Then
                    maxTotTrans = totTransPrev
                End If

                If totTransCurr >= maxTotTrans Then
                    maxTotTrans = totTransCurr
                    If GridViewResult.GetRowCellValue(i, "Check") Then
                        warning -= 1
                        totSelected -= 1
                    End If
                    GridViewResult.SetRowCellValue(i, "Check", False)
                    GridViewResult.SetRowCellValue(i, "MaxTotTrans", maxTotTrans)
                Else
                    GridViewResult.SetRowCellValue(i, "MaxTotTrans", maxTotTrans)
                    isCheck = False
                End If

                GridViewResult.SetRowCellValue(i, "Status", "Warning")
                GridViewResult.SetRowCellValue(i, "Message", "Part No More Than 1 !")
                isDuplicate = True
            End If
        Next
        If isCheck = False Then
            warning -= 1
        End If
        Return isDuplicate
    End Function

    Private Sub addNewDtResult(NoExcel As Integer, partNo As String, invtID As String, Desc As String, oldPrice As Double, newPriceR As Double, newPriceS As Double, effDate As Date, Status As String, Message As String)
        Dim newRow As DataRow
        newRow = dtResult.NewRow
        No += 1
        TotRecortExcel = NoExcel
        If isCheck Then
            totSelected += 1
        End If
        newRow("Check") = isCheck
        newRow("No") = No
        newRow("NoExcel") = NoExcel
        newRow("PartNo") = partNo
        newRow("InvtID") = invtID
        newRow("PartName") = Desc
        newRow("OldPrice") = oldPrice
        newRow("NewPriceR") = newPriceR
        newRow("NewPriceS") = newPriceS
        newRow("EffectiveDate") = effDate
        newRow("Status") = Status
        newRow("Message") = Message
        newRow("MaxTotTrans") = maxTotTrans
        dtResult.Rows.Add(newRow)
    End Sub

    Private Sub addNewDtUpload()
        Try
            dtUploadTemp.Clear()
            Dim no As Integer
            For i As Integer = 0 To GridViewResult.RowCount - 1
                If GridViewResult.GetRowCellValue(i, "Check") = True Then
                    Dim _newRow As DataRow
                    _newRow = dtUploadTemp.NewRow
                    no += 1
                    _newRow("No") = no
                    _newRow("PartNo") = GridViewResult.GetRowCellValue(i, "PartNo")
                    _newRow("InvtID") = GridViewResult.GetRowCellValue(i, "InvtID")
                    _newRow("PartName") = GridViewResult.GetRowCellValue(i, "PartName")
                    _newRow("OldPrice") = GridViewResult.GetRowCellValue(i, "OldPrice")
                    _newRow("NewPriceR") = GridViewResult.GetRowCellValue(i, "NewPriceR")
                    _newRow("NewPriceS") = GridViewResult.GetRowCellValue(i, "NewPriceS")
                    _newRow("EffectiveDate") = GridViewResult.GetRowCellValue(i, "EffectiveDate")
                    dtUploadTemp.Rows.Add(_newRow)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CreateTable()
        dtResult = New DataTable
        dtResult.Columns.AddRange(New DataColumn(12) {New DataColumn("Check", GetType(Boolean)),
                                                    New DataColumn("No", GetType(Integer)),
                                                    New DataColumn("NoExcel", GetType(Integer)),
                                                    New DataColumn("PartNo", GetType(String)),
                                                    New DataColumn("InvtID", GetType(String)),
                                                    New DataColumn("PartName", GetType(String)),
                                                    New DataColumn("OldPrice", GetType(Double)),
                                                    New DataColumn("NewPriceR", GetType(Double)),
                                                    New DataColumn("NewPriceS", GetType(Double)),
                                                    New DataColumn("EffectiveDate", GetType(Date)),
                                                    New DataColumn("Status", GetType(String)),
                                                    New DataColumn("Message", GetType(String)),
                                                    New DataColumn("MaxTotTrans", GetType(String))})

        dtUploadTemp = New DataTable
        dtUploadTemp.Columns.AddRange(New DataColumn(7) {New DataColumn("No", GetType(Integer)),
                                                        New DataColumn("PartNo", GetType(String)),
                                                        New DataColumn("InvtID", GetType(String)),
                                                        New DataColumn("PartName", GetType(String)),
                                                        New DataColumn("OldPrice", GetType(Double)),
                                                        New DataColumn("NewPriceR", GetType(Double)),
                                                        New DataColumn("NewPriceS", GetType(Double)),
                                                        New DataColumn("EffectiveDate", GetType(Date))})
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

            GridViewResult.ClearColumnsFilter()
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
                        cls_UploadPrice = New ClsMktUploadPrice
                        Dim isRev As Integer = cls_UploadPrice.CheckFileName(FileName)
                        If isRev > 0 Then
                            If MsgBox("File Name Already Exist, Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                                addNewDtUpload()
                                dtUpload = dtUploadTemp
                                Template = txtTemplate.Text
                                Revised = "R" + Convert.ToString(isRev)
                                isUpload = True
                                Me.Close()
                            End If
                        Else
                            If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                                addNewDtUpload()
                                dtUpload = dtUploadTemp
                                Template = txtTemplate.Text
                                isUpload = True
                                Me.Close()
                            End If
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

    Private Sub CCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CCheck.CheckedChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim isCheck As Boolean
        Dim __Status As String
        isCheck = GridViewResult.GetRowCellValue(GridViewResult.FocusedRowHandle, "Check")
        __Status = GridViewResult.GetRowCellValue(GridViewResult.FocusedRowHandle, "Status")
        If isCheck Then
            totSelected += 1
            If __Status = "Success" Then
                succes += 1
            ElseIf __Status = "Info" Then
                info += 1
            ElseIf __Status = "Warning" Then
                warning += 1
            ElseIf __Status = "Error" Then
                _error += 1
            End If
        Else
            totSelected -= 1
            If __Status = "Success" Then
                succes -= 1
            ElseIf __Status = "Info" Then
                info -= 1
            ElseIf __Status = "Warning" Then
                warning -= 1
            ElseIf __Status = "Error" Then
                _error -= 1
            End If
        End If
        StatusList(succes, info, warning, _error, totSelected)
        If _error = 0 Then
            btnExport.Text = "Upload"
        Else
            btnExport.Text = "Save To Excel"
        End If
    End Sub

    Private Sub StatusList(Optional __success As Integer = 0, Optional __info As Integer = 0, Optional __warning As Integer = 0, Optional __error As Integer = 0, Optional __check As Integer = 0)
        lblSuccess.Text = Convert.ToString(__success) + " Success"
        lblInfo.Text = Convert.ToString(__info) + " Info"
        lblWarning.Text = Convert.ToString(__warning) + " Warnings"
        lblError.Text = Convert.ToString(__error) + " Errors"
        lblTotSelect.Text = "Of " + Convert.ToString(__check) + " Selected"
    End Sub

End Class