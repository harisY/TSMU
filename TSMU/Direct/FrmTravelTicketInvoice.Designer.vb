<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelTicketInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtVendor = New DevExpress.XtraEditors.ButtonEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoInvoice = New DevExpress.XtraEditors.TextEdit()
        Me.btnSaveInvoice = New DevExpress.XtraEditors.SimpleButton()
        Me.GridInvoice = New DevExpress.XtraGrid.GridControl()
        Me.GridViewInvoice = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NoRequest = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Seq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nama = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeptID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Purpose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Destination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Negara = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DepartureDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ArrivalDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TicketNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CuryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CAmount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CStatus = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Invoice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.dtDate = New DevExpress.XtraEditors.DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotAmount = New DevExpress.XtraEditors.TextEdit()
        Me.txtCuryID = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkBalance = New DevExpress.XtraEditors.CheckEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBalance = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuryID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Vendor"
        '
        'txtVendor
        '
        Me.txtVendor.Location = New System.Drawing.Point(83, 15)
        Me.txtVendor.Name = "txtVendor"
        Me.txtVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtVendor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtVendor.Size = New System.Drawing.Size(185, 22)
        Me.txtVendor.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(294, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Invoice"
        '
        'txtNoInvoice
        '
        Me.txtNoInvoice.Location = New System.Drawing.Point(363, 15)
        Me.txtNoInvoice.Name = "txtNoInvoice"
        Me.txtNoInvoice.Size = New System.Drawing.Size(150, 22)
        Me.txtNoInvoice.TabIndex = 16
        '
        'btnSaveInvoice
        '
        Me.btnSaveInvoice.Location = New System.Drawing.Point(1354, 11)
        Me.btnSaveInvoice.Name = "btnSaveInvoice"
        Me.btnSaveInvoice.Size = New System.Drawing.Size(92, 29)
        Me.btnSaveInvoice.TabIndex = 19
        Me.btnSaveInvoice.Text = "Save Invoice"
        '
        'GridInvoice
        '
        Me.GridInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridInvoice.Location = New System.Drawing.Point(15, 56)
        Me.GridInvoice.MainView = Me.GridViewInvoice
        Me.GridInvoice.Name = "GridInvoice"
        Me.GridInvoice.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CAmount, Me.CCheck, Me.CStatus})
        Me.GridInvoice.Size = New System.Drawing.Size(1431, 549)
        Me.GridInvoice.TabIndex = 20
        Me.GridInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewInvoice})
        '
        'GridViewInvoice
        '
        Me.GridViewInvoice.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NoRequest, Me.Seq, Me.Nama, Me.DeptID, Me.Purpose, Me.Destination, Me.Negara, Me.DepartureDate, Me.ArrivalDate, Me.TicketNumber, Me.CuryID, Me.Amount, Me.Status, Me.Invoice, Me.Check})
        Me.GridViewInvoice.GridControl = Me.GridInvoice
        Me.GridViewInvoice.Name = "GridViewInvoice"
        Me.GridViewInvoice.OptionsView.ShowFooter = True
        Me.GridViewInvoice.OptionsView.ShowGroupPanel = False
        '
        'NoRequest
        '
        Me.NoRequest.Caption = "No Request"
        Me.NoRequest.FieldName = "NoRequest"
        Me.NoRequest.MinWidth = 25
        Me.NoRequest.Name = "NoRequest"
        Me.NoRequest.OptionsColumn.AllowEdit = False
        Me.NoRequest.OptionsColumn.FixedWidth = True
        Me.NoRequest.Width = 140
        '
        'Seq
        '
        Me.Seq.Caption = "Seq"
        Me.Seq.FieldName = "Seq"
        Me.Seq.MinWidth = 25
        Me.Seq.Name = "Seq"
        Me.Seq.Width = 94
        '
        'Nama
        '
        Me.Nama.Caption = "Nama"
        Me.Nama.FieldName = "Nama"
        Me.Nama.MinWidth = 25
        Me.Nama.Name = "Nama"
        Me.Nama.OptionsColumn.AllowEdit = False
        Me.Nama.OptionsColumn.FixedWidth = True
        Me.Nama.Visible = True
        Me.Nama.VisibleIndex = 0
        Me.Nama.Width = 200
        '
        'DeptID
        '
        Me.DeptID.Caption = "Dept ID"
        Me.DeptID.FieldName = "DeptID"
        Me.DeptID.MinWidth = 25
        Me.DeptID.Name = "DeptID"
        Me.DeptID.OptionsColumn.AllowEdit = False
        Me.DeptID.OptionsColumn.FixedWidth = True
        Me.DeptID.Width = 80
        '
        'Purpose
        '
        Me.Purpose.Caption = "Purpose"
        Me.Purpose.FieldName = "Purpose"
        Me.Purpose.MinWidth = 25
        Me.Purpose.Name = "Purpose"
        Me.Purpose.OptionsColumn.AllowEdit = False
        Me.Purpose.Width = 25
        '
        'Destination
        '
        Me.Destination.Caption = "Destination"
        Me.Destination.FieldName = "Destination"
        Me.Destination.MinWidth = 25
        Me.Destination.Name = "Destination"
        Me.Destination.OptionsColumn.AllowEdit = False
        Me.Destination.OptionsColumn.FixedWidth = True
        Me.Destination.Visible = True
        Me.Destination.VisibleIndex = 1
        Me.Destination.Width = 150
        '
        'Negara
        '
        Me.Negara.Caption = "Negara"
        Me.Negara.FieldName = "Negara"
        Me.Negara.MinWidth = 25
        Me.Negara.Name = "Negara"
        Me.Negara.OptionsColumn.AllowEdit = False
        Me.Negara.OptionsColumn.FixedWidth = True
        Me.Negara.Width = 120
        '
        'DepartureDate
        '
        Me.DepartureDate.Caption = "Departure Date"
        Me.DepartureDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DepartureDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DepartureDate.FieldName = "DepartureDate"
        Me.DepartureDate.MinWidth = 25
        Me.DepartureDate.Name = "DepartureDate"
        Me.DepartureDate.OptionsColumn.AllowEdit = False
        Me.DepartureDate.OptionsColumn.FixedWidth = True
        Me.DepartureDate.Visible = True
        Me.DepartureDate.VisibleIndex = 2
        Me.DepartureDate.Width = 120
        '
        'ArrivalDate
        '
        Me.ArrivalDate.Caption = "Arrival Date"
        Me.ArrivalDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.ArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ArrivalDate.FieldName = "ArrivalDate"
        Me.ArrivalDate.MinWidth = 25
        Me.ArrivalDate.Name = "ArrivalDate"
        Me.ArrivalDate.OptionsColumn.AllowEdit = False
        Me.ArrivalDate.OptionsColumn.FixedWidth = True
        Me.ArrivalDate.Visible = True
        Me.ArrivalDate.VisibleIndex = 3
        Me.ArrivalDate.Width = 120
        '
        'TicketNumber
        '
        Me.TicketNumber.Caption = "Ticket Number"
        Me.TicketNumber.FieldName = "TicketNumber"
        Me.TicketNumber.MinWidth = 25
        Me.TicketNumber.Name = "TicketNumber"
        Me.TicketNumber.OptionsColumn.FixedWidth = True
        Me.TicketNumber.Visible = True
        Me.TicketNumber.VisibleIndex = 4
        Me.TicketNumber.Width = 140
        '
        'CuryID
        '
        Me.CuryID.Caption = "Curry ID"
        Me.CuryID.FieldName = "CuryID"
        Me.CuryID.MinWidth = 25
        Me.CuryID.Name = "CuryID"
        Me.CuryID.OptionsColumn.AllowEdit = False
        Me.CuryID.OptionsColumn.FixedWidth = True
        Me.CuryID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.CuryID.Visible = True
        Me.CuryID.VisibleIndex = 5
        Me.CuryID.Width = 70
        '
        'Amount
        '
        Me.Amount.Caption = "Amount"
        Me.Amount.ColumnEdit = Me.CAmount
        Me.Amount.DisplayFormat.FormatString = "n2"
        Me.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Amount.FieldName = "Amount"
        Me.Amount.MinWidth = 25
        Me.Amount.Name = "Amount"
        Me.Amount.OptionsColumn.FixedWidth = True
        Me.Amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,##0.#0}")})
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 6
        Me.Amount.Width = 130
        '
        'CAmount
        '
        Me.CAmount.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAmount.AutoHeight = False
        Me.CAmount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAmount.DisplayFormat.FormatString = "n2"
        Me.CAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmount.EditFormat.FormatString = "n2"
        Me.CAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmount.Mask.EditMask = "n2"
        Me.CAmount.Name = "CAmount"
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.ColumnEdit = Me.CStatus
        Me.Status.FieldName = "Status"
        Me.Status.MinWidth = 25
        Me.Status.Name = "Status"
        Me.Status.OptionsColumn.FixedWidth = True
        Me.Status.Width = 100
        '
        'CStatus
        '
        Me.CStatus.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CStatus.AutoHeight = False
        Me.CStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CStatus.Items.AddRange(New Object() {"BOOKED", "INVOICE", "CLOSE", "CANCEL"})
        Me.CStatus.Name = "CStatus"
        '
        'Invoice
        '
        Me.Invoice.Caption = "Invoice"
        Me.Invoice.FieldName = "Invoice"
        Me.Invoice.MinWidth = 25
        Me.Invoice.Name = "Invoice"
        Me.Invoice.OptionsColumn.FixedWidth = True
        Me.Invoice.Width = 120
        '
        'Check
        '
        Me.Check.Caption = "Check"
        Me.Check.ColumnEdit = Me.CCheck
        Me.Check.FieldName = "CheckList"
        Me.Check.MinWidth = 25
        Me.Check.Name = "Check"
        Me.Check.OptionsColumn.FixedWidth = True
        Me.Check.Width = 60
        '
        'CCheck
        '
        Me.CCheck.AutoHeight = False
        Me.CCheck.Name = "CCheck"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(534, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(733, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Due Date"
        '
        'dtDueDate
        '
        Me.dtDueDate.EditValue = Nothing
        Me.dtDueDate.Location = New System.Drawing.Point(822, 15)
        Me.dtDueDate.Name = "dtDueDate"
        Me.dtDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDueDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dtDueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDueDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dtDueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDueDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dtDueDate.Size = New System.Drawing.Size(110, 22)
        Me.dtDueDate.TabIndex = 23
        '
        'dtDate
        '
        Me.dtDate.EditValue = Nothing
        Me.dtDate.Location = New System.Drawing.Point(593, 15)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dtDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dtDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dtDate.Size = New System.Drawing.Size(110, 22)
        Me.dtDate.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(954, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Cury ID"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1114, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 17)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Total Amount"
        '
        'txtTotAmount
        '
        Me.txtTotAmount.Location = New System.Drawing.Point(1226, 15)
        Me.txtTotAmount.Name = "txtTotAmount"
        Me.txtTotAmount.Properties.DisplayFormat.FormatString = "n2"
        Me.txtTotAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTotAmount.Properties.EditFormat.FormatString = "n2"
        Me.txtTotAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTotAmount.Properties.Mask.EditMask = "n2"
        Me.txtTotAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotAmount.Size = New System.Drawing.Size(114, 22)
        Me.txtTotAmount.TabIndex = 26
        '
        'txtCuryID
        '
        Me.txtCuryID.EditValue = "IDR"
        Me.txtCuryID.Location = New System.Drawing.Point(1023, 15)
        Me.txtCuryID.Name = "txtCuryID"
        Me.txtCuryID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCuryID.Properties.Items.AddRange(New Object() {"IDR", "USD", "YEN"})
        Me.txtCuryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCuryID.Size = New System.Drawing.Size(69, 22)
        Me.txtCuryID.TabIndex = 25
        '
        'chkBalance
        '
        Me.chkBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkBalance.EditValue = True
        Me.chkBalance.Location = New System.Drawing.Point(1248, 613)
        Me.chkBalance.Name = "chkBalance"
        Me.chkBalance.Properties.Caption = ""
        Me.chkBalance.Size = New System.Drawing.Size(21, 19)
        Me.chkBalance.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1147, 614)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Selisih"
        '
        'txtBalance
        '
        Me.txtBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtBalance.Enabled = False
        Me.txtBalance.Location = New System.Drawing.Point(1275, 611)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Properties.DisplayFormat.FormatString = "n2"
        Me.txtBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBalance.Properties.EditFormat.FormatString = "n2"
        Me.txtBalance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBalance.Properties.Mask.EditMask = "n0"
        Me.txtBalance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtBalance.Size = New System.Drawing.Size(171, 22)
        Me.txtBalance.TabIndex = 29
        '
        'FrmTravelTicketInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1458, 645)
        Me.Controls.Add(Me.chkBalance)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotAmount)
        Me.Controls.Add(Me.txtCuryID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridInvoice)
        Me.Controls.Add(Me.btnSaveInvoice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVendor)
        Me.Controls.Add(Me.txtNoInvoice)
        Me.Controls.Add(Me.dtDueDate)
        Me.Controls.Add(Me.dtDate)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTravelTicketInvoice"
        Me.Text = "FrmTravelTicketInvoice"
        CType(Me.txtVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuryID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtVendor As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNoInvoice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSaveInvoice As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NoRequest As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Seq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nama As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeptID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Purpose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Destination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Negara As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DepartureDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ArrivalDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TicketNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CuryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CAmount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CStatus As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Invoice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Check As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCuryID As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkBalance As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBalance As DevExpress.XtraEditors.TextEdit
End Class
