Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.OleDb
Imports System.Configuration
Imports System.IO
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls

Public Class FrmPPICUploadPO
    Dim srvPPIC As New PPICService()
    Dim path As String = String.Empty
    Dim dtExcel As New DataTable
    Dim dtResult As New DataTable
    Dim isUpload As Boolean = False

    Dim succes As Integer
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

    Public Property NoUpload() As String
    Public Property UploadDate() As Date
    Public Property CustID() As String
    Public Property DeliveryDueDate() As Date
    Public Property FileName() As String
    Public Property Revised() As String = "No"

    Private Sub FrmPPICUploadPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
        GridResult.DataSource = dtResult
        With GridViewResult
            Dim colSeq As GridColumn = .Columns("Seq")
            colSeq.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            Dim colPF As GridColumn = .Columns("PF")
            colPF.Caption = "P/F"

            Dim colDeliveryDueDate As GridColumn = .Columns("DeliveryDueDate")
            colDeliveryDueDate.DisplayFormat.FormatType = FormatType.DateTime
            colDeliveryDueDate.DisplayFormat.FormatString = "dd-MM-yyyy"

            Dim colDeliveryTime As GridColumn = .Columns("DeliveryTime")
            colDeliveryTime.Caption = "Delivery Time (To)"
            colDeliveryTime.DisplayFormat.FormatType = FormatType.DateTime
            colDeliveryTime.DisplayFormat.FormatString = "HH:mm"

            Dim colStandarQty As GridColumn = .Columns("StandarQty")
            colStandarQty.Visible = False

            Dim colKapasitasMuat As GridColumn = .Columns("KapasitasMuat")
            colKapasitasMuat.Visible = False

            .BestFitColumns()
        End With
        txtRevised.SelectedIndex = 0
        StatusList()
    End Sub

    Private Sub txtCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtCustomer.ButtonClick
        'Dim ls_Judul As String = ""
        'Dim dtSearch As New DataTable

        'dtSearch = cls_UploadPrice.GetDataCustomer
        'ls_Judul = "CUSTOMER"

        'Dim lF_SearchData As FrmSystem_LookupGrid
        'lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        'lF_SearchData.Text = "Select Data " & ls_Judul
        'lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        'lF_SearchData.ShowDialog()

        'If lF_SearchData.Values IsNot Nothing Then
        '    CustID = lF_SearchData.Values.Item(0).ToString.Trim
        '    txtCustomer.Text = lF_SearchData.Values.Item(1).ToString.Trim
        'End If
        'lF_SearchData.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
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
        Catch ex As Exception When Not TypeOf ex Is MissingMethodException
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If txtFileName.Text = "" Then
                txtFileName.Focus()
                Throw New Exception("File Excel yang akan di upload tidak ada !")
            ElseIf dtDeliveryDueDate.EditValue = Nothing Then
                dtDeliveryDueDate.Focus()
                Throw New Exception("Pilih Delivery Due Date Dulu !")
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

                Using oda As New OleDbDataAdapter(Convert.ToString("SELECT * FROM [A1:I3000]"), excel_con)
                    Try
                        dtExcel = New DataTable
                        oda.Fill(dtExcel)
                    Catch ex As Exception
                        Throw New Exception("Template does not match !")
                    End Try
                End Using
                excel_con.Close()
            End Using
            CheckListPO()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CheckListPO()
        Try
            dtResult.Clear()
            If checkColumn() = False Then
                succes = 0
                warning = 0
                _error = 0
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

                Dim dtBuildup As New DataTable
                dtBuildup = srvPPIC.CheckBuildup()
                For Each rows As DataRow In dtExcel.Rows

                    If Not String.IsNullOrEmpty(IIf(rows("Item Number") Is DBNull.Value, "", rows("Item Number"))) Then
                        Dim rowBuildup As DataRow()
                        Dim status As String = "Error"
                        Dim message As String = String.Empty
                        rowBuildup = dtBuildup.Select("ItemNumber = " & QVal(Replace(rows("Item Number"), "-", "")) & "")
                        If rowBuildup.Count = 0 Then
                            'Jika partno tidak ditemukan di KapOEM
                            message = "Item Number Tidak Ditemukan Di Master Standar Packing !"
                            _error += 1
                            addNewDtResult(rows, "", "", 0, 0, status, message)
                        ElseIf rows("Delivery Due Date") <> dtDeliveryDueDate.EditValue Then
                            'Jika Delivery Due Date Tidak Sama Dengan Detail
                            status = "Warning"
                            message = "Delivery Due Date Tidak Sama Dengan Yang Dipilih !"
                            warning += 1
                            addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                        ElseIf rows("User Code") Is DBNull.Value Then
                            'Jika User Code Kosong
                            message = "User Code Tidak Boleh Kosong !"
                            _error += 1
                            addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                        ElseIf rows("P/F") Is DBNull.Value Then
                            'Jika P/F Kosong
                            message = "P/F Tidak Boleh Kosong !"
                            _error += 1
                            addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                        ElseIf rows("Order No#") Is DBNull.Value Then
                            'Jika Order No Kosong
                            message = "Order No Tidak Boleh Kosong !"
                            _error += 1
                            addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                        Else
                            Dim dt As New DataTable
                            dt = srvPPIC.CheckInventoryID(CustID)

                            Dim rowInvtID As DataRow()
                            rowInvtID = dt.Select("AlternateID = " & QVal(Replace(rows("Item Number"), "-", "")) & " ")
                            If rowInvtID.Count = 0 Then
                                'Jika partno / alternateid tidak ditemukan di Master
                                status = "Warning"
                                message = "Item Number Tidak Ditemukan !"
                                warning += 1
                                addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                            Else
                                status = "Success"
                                succes += 1
                                addNewDtResult(rows, rowBuildup(0)("PartNo"), rowBuildup(0)("JenisPacking"), rowBuildup(0)("StandarQty"), rowBuildup(0)("KapasitasMuat"), status, message)
                            End If
                        End If
                    End If
                Next
                SplashScreenManager.CloseForm()
                GridViewResult.BestFitColumns()

                StatusList(succes, warning, _error, dtExcel.Rows.Count)
                If _error = 0 Then
                    btnExport.Text = "Upload"
                Else
                    btnExport.Text = "Save To Excel"
                End If
            Else
                GridResult.DataSource = dtResult
                GridResult.Refresh()
                StatusList()
            End If
        Catch ex As Exception
            dtResult.Clear()
            GridResult.DataSource = dtResult
            GridResult.Refresh()
            StatusList()
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Function checkColumn() As Boolean
        Dim listColumn As New List(Of String)
        listColumn.Add("Seq")
        listColumn.Add("Item Number")
        listColumn.Add("Item Name")
        listColumn.Add("User Code")
        listColumn.Add("P/F")
        listColumn.Add("Order No#")
        listColumn.Add("Delivery Due Date")
        listColumn.Add("Delivery Time (To)")
        listColumn.Add("Order Quantity")
        Dim isNotFound As Boolean = False
        Try
            For i As Integer = 0 To listColumn.Count - 1
                If listColumn(i) IsNot Nothing AndAlso Not dtExcel.Columns.Contains(listColumn(i)) Then
                    isNotFound = True
                    Throw New Exception("Column (" & listColumn(i) & ") tidak ditemukan, Template excel tidak sesuai!")
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return isNotFound
    End Function

    Private Sub addNewDtResult(Rows As DataRow, PartNo As String, JenisPacking As String, StandarQty As String, KapMuat As String, Status As String, Message As String)
        Dim newRow As DataRow
        newRow = dtResult.NewRow
        newRow("Seq") = Rows("Seq")
        newRow("PartNo") = PartNo
        newRow("ItemNumber") = Rows("Item Number")
        newRow("ItemName") = Rows("Item Name")
        newRow("UserCode") = Rows("User Code")
        newRow("PF") = Rows("P/F")
        newRow("OrderNo") = Rows("Order No#")
        newRow("DeliveryDueDate") = Rows("Delivery Due Date")
        newRow("DeliveryTime") = Rows("Delivery Time (To)")
        newRow("OrderQuantity") = Rows("Order Quantity")
        newRow("JenisPacking") = JenisPacking
        newRow("StandarQty") = StandarQty
        newRow("KapasitasMuat") = KapMuat
        newRow("Status") = Status
        newRow("Message") = Message
        dtResult.Rows.Add(newRow)
    End Sub

    Public Sub CreateTable()
        UploadDate = Date.Today
        CustID = "YIM"
        txtCustomer.Text = "YAMAHA INDONESIA MOTOR"
        dtResult = New DataTable
        dtResult.Columns.AddRange(New DataColumn(14) {New DataColumn("Seq", GetType(Integer)),
                                                    New DataColumn("PartNo", GetType(String)),
                                                    New DataColumn("ItemNumber", GetType(String)),
                                                    New DataColumn("ItemName", GetType(String)),
                                                    New DataColumn("UserCode", GetType(String)),
                                                    New DataColumn("PF", GetType(String)),
                                                    New DataColumn("OrderNo", GetType(String)),
                                                    New DataColumn("DeliveryDueDate", GetType(Date)),
                                                    New DataColumn("DeliveryTime", GetType(DateTime)),
                                                    New DataColumn("OrderQuantity", GetType(Integer)),
                                                    New DataColumn("JenisPacking", GetType(String)),
                                                    New DataColumn("StandarQty", GetType(Integer)),
                                                    New DataColumn("KapasitasMuat", GetType(Integer)),
                                                    New DataColumn("Status", GetType(String)),
                                                    New DataColumn("Message", GetType(String))})
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
                    .Filter = "Excel File|*.xls;*.xlsx",
                    .Title = "Save an Excel File"
                }
                    If save.ShowDialog = DialogResult.OK Then
                        GridResult.ExportToXls(save.FileName)
                    End If
                Else
                    If txtRevised.Text = "Yes" AndAlso String.IsNullOrEmpty(txtNoUpload.Text) Then
                        Err.Raise(ErrNumber, , "Harap Pilih No Upload Jika Revisi!")
                    End If

                    DeliveryDueDate = dtDeliveryDueDate.EditValue
                    Revised = txtRevised.Text
                    NoUpload = txtNoUpload.Text

                    If Not String.IsNullOrEmpty(NoUpload) Then
                        If MsgBox("List PO Already Exist, Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            srvPPIC.CopyDTToDB(dtResult)
                            isUpload = True
                            Me.Close()
                        End If
                    Else
                        If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            srvPPIC.CopyDTToDB(dtResult)
                            isUpload = True
                            Me.Close()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub StatusList(Optional __success As Integer = 0, Optional __warning As Integer = 0, Optional __error As Integer = 0, Optional __total As Integer = 0)
        lblSuccess.Text = Convert.ToString(__success) + " Of " + Convert.ToString(__total) + " Success"
        lblWarning.Text = Convert.ToString(__warning) + " Of " + Convert.ToString(__total) + " Warnings"
        lblError.Text = Convert.ToString(__error) + " Of " + Convert.ToString(__total) + " Errors"
    End Sub

    Private Sub txtRevised_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtRevised.SelectedIndexChanged
        If txtRevised.SelectedIndex = 1 Then
            Dim dtNoUpload As New DataTable
            dtNoUpload = srvPPIC.CheckDataExist(UploadDate)
            For Each rows In dtNoUpload.Rows
                txtNoUpload.Properties.Items.Add(rows("NoUpload"))
            Next
        Else
            txtNoUpload.Text = ""
            txtNoUpload.Properties.Items.Clear()
        End If
    End Sub

End Class