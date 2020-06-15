<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelTicketDetail
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtNoVoucher = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GridTicket = New DevExpress.XtraGrid.GridControl()
        Me.GridViewTicket = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.StatusTicket = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CStatusTicket = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Invoice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.dtTanggal = New DevExpress.XtraEditors.DateEdit()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.btnAddDetail = New DevExpress.XtraEditors.SimpleButton()
        Me.btnProsesInvoice = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtNoVoucher.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CStatusTicket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNoVoucher
        '
        Me.txtNoVoucher.Enabled = False
        Me.txtNoVoucher.Location = New System.Drawing.Point(133, 51)
        Me.txtNoVoucher.Name = "txtNoVoucher"
        Me.txtNoVoucher.Size = New System.Drawing.Size(140, 22)
        Me.txtNoVoucher.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "No Voucher"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(310, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tanggal"
        '
        'GridTicket
        '
        Me.GridTicket.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridTicket.Location = New System.Drawing.Point(15, 89)
        Me.GridTicket.MainView = Me.GridViewTicket
        Me.GridTicket.Name = "GridTicket"
        Me.GridTicket.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CAmount, Me.CCheck, Me.CStatusTicket})
        Me.GridTicket.Size = New System.Drawing.Size(1507, 477)
        Me.GridTicket.TabIndex = 12
        Me.GridTicket.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTicket})
        '
        'GridViewTicket
        '
        Me.GridViewTicket.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NoRequest, Me.Seq, Me.Nama, Me.DeptID, Me.Purpose, Me.Destination, Me.Negara, Me.DepartureDate, Me.ArrivalDate, Me.TicketNumber, Me.CuryID, Me.Amount, Me.StatusTicket, Me.Invoice, Me.Check})
        Me.GridViewTicket.GridControl = Me.GridTicket
        Me.GridViewTicket.Name = "GridViewTicket"
        Me.GridViewTicket.OptionsView.ShowGroupPanel = False
        '
        'NoRequest
        '
        Me.NoRequest.Caption = "No Request"
        Me.NoRequest.FieldName = "NoRequest"
        Me.NoRequest.MinWidth = 25
        Me.NoRequest.Name = "NoRequest"
        Me.NoRequest.OptionsColumn.AllowEdit = False
        Me.NoRequest.OptionsColumn.FixedWidth = True
        Me.NoRequest.Visible = True
        Me.NoRequest.VisibleIndex = 0
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
        Me.Nama.VisibleIndex = 1
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
        Me.DeptID.Visible = True
        Me.DeptID.VisibleIndex = 2
        Me.DeptID.Width = 80
        '
        'Purpose
        '
        Me.Purpose.Caption = "Purpose"
        Me.Purpose.FieldName = "Purpose"
        Me.Purpose.MinWidth = 25
        Me.Purpose.Name = "Purpose"
        Me.Purpose.OptionsColumn.AllowEdit = False
        Me.Purpose.Visible = True
        Me.Purpose.VisibleIndex = 3
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
        Me.Destination.VisibleIndex = 4
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
        Me.Negara.Visible = True
        Me.Negara.VisibleIndex = 5
        Me.Negara.Width = 120
        '
        'DepartureDate
        '
        Me.DepartureDate.Caption = "Departure Date"
        Me.DepartureDate.FieldName = "DepartureDate"
        Me.DepartureDate.MinWidth = 25
        Me.DepartureDate.Name = "DepartureDate"
        Me.DepartureDate.OptionsColumn.AllowEdit = False
        Me.DepartureDate.OptionsColumn.FixedWidth = True
        Me.DepartureDate.Visible = True
        Me.DepartureDate.VisibleIndex = 6
        Me.DepartureDate.Width = 120
        '
        'ArrivalDate
        '
        Me.ArrivalDate.Caption = "Arrival Date"
        Me.ArrivalDate.FieldName = "ArrivalDate"
        Me.ArrivalDate.MinWidth = 25
        Me.ArrivalDate.Name = "ArrivalDate"
        Me.ArrivalDate.OptionsColumn.AllowEdit = False
        Me.ArrivalDate.OptionsColumn.FixedWidth = True
        Me.ArrivalDate.Visible = True
        Me.ArrivalDate.VisibleIndex = 7
        Me.ArrivalDate.Width = 120
        '
        'TicketNumber
        '
        Me.TicketNumber.Caption = "Ticket Number"
        Me.TicketNumber.FieldName = "TicketNumber"
        Me.TicketNumber.MinWidth = 25
        Me.TicketNumber.Name = "TicketNumber"
        Me.TicketNumber.OptionsColumn.AllowEdit = False
        Me.TicketNumber.OptionsColumn.FixedWidth = True
        Me.TicketNumber.Visible = True
        Me.TicketNumber.VisibleIndex = 8
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
        Me.CuryID.Visible = True
        Me.CuryID.VisibleIndex = 9
        Me.CuryID.Width = 70
        '
        'Amount
        '
        Me.Amount.Caption = "Amount"
        Me.Amount.ColumnEdit = Me.CAmount
        Me.Amount.FieldName = "Amount"
        Me.Amount.MinWidth = 25
        Me.Amount.Name = "Amount"
        Me.Amount.OptionsColumn.AllowEdit = False
        Me.Amount.OptionsColumn.FixedWidth = True
        Me.Amount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:#,##0.#0}")})
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 10
        Me.Amount.Width = 140
        '
        'CAmount
        '
        Me.CAmount.AutoHeight = False
        Me.CAmount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAmount.DisplayFormat.FormatString = "n2"
        Me.CAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmount.EditFormat.FormatString = "n2"
        Me.CAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmount.Name = "CAmount"
        '
        'StatusTicket
        '
        Me.StatusTicket.Caption = "Status Ticket"
        Me.StatusTicket.ColumnEdit = Me.CStatusTicket
        Me.StatusTicket.FieldName = "StatusTicket"
        Me.StatusTicket.MinWidth = 25
        Me.StatusTicket.Name = "StatusTicket"
        Me.StatusTicket.OptionsColumn.AllowEdit = False
        Me.StatusTicket.OptionsColumn.FixedWidth = True
        Me.StatusTicket.Visible = True
        Me.StatusTicket.VisibleIndex = 11
        Me.StatusTicket.Width = 100
        '
        'CStatusTicket
        '
        Me.CStatusTicket.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CStatusTicket.AutoHeight = False
        Me.CStatusTicket.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CStatusTicket.Items.AddRange(New Object() {"ISSUE", "INVOICE", "CLOSE", "CANCEL"})
        Me.CStatusTicket.Name = "CStatusTicket"
        '
        'Invoice
        '
        Me.Invoice.Caption = "Invoice"
        Me.Invoice.FieldName = "Invoice"
        Me.Invoice.MinWidth = 25
        Me.Invoice.Name = "Invoice"
        Me.Invoice.OptionsColumn.AllowEdit = False
        Me.Invoice.OptionsColumn.FixedWidth = True
        Me.Invoice.Visible = True
        Me.Invoice.VisibleIndex = 12
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
        Me.Check.Visible = True
        Me.Check.VisibleIndex = 13
        Me.Check.Width = 60
        '
        'CCheck
        '
        Me.CCheck.AutoHeight = False
        Me.CCheck.Name = "CCheck"
        '
        'dtTanggal
        '
        Me.dtTanggal.EditValue = Nothing
        Me.dtTanggal.Enabled = False
        Me.dtTanggal.Location = New System.Drawing.Point(409, 51)
        Me.dtTanggal.Name = "dtTanggal"
        Me.dtTanggal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTanggal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtTanggal.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dtTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtTanggal.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dtTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtTanggal.Properties.Mask.EditMask = ""
        Me.dtTanggal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.dtTanggal.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtTanggal.Size = New System.Drawing.Size(125, 22)
        Me.dtTanggal.TabIndex = 13
        '
        'btnAddDetail
        '
        Me.btnAddDetail.Location = New System.Drawing.Point(1790, 47)
        Me.btnAddDetail.Name = "btnAddDetail"
        Me.btnAddDetail.Size = New System.Drawing.Size(100, 29)
        Me.btnAddDetail.TabIndex = 21
        Me.btnAddDetail.Text = "Add Detail"
        '
        'btnProsesInvoice
        '
        Me.btnProsesInvoice.Location = New System.Drawing.Point(1910, 47)
        Me.btnProsesInvoice.Name = "btnProsesInvoice"
        Me.btnProsesInvoice.Size = New System.Drawing.Size(110, 29)
        Me.btnProsesInvoice.TabIndex = 22
        Me.btnProsesInvoice.Text = "Input Invoice"
        '
        'FrmTravelTicketDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1924, 578)
        Me.Controls.Add(Me.btnProsesInvoice)
        Me.Controls.Add(Me.btnAddDetail)
        Me.Controls.Add(Me.GridTicket)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNoVoucher)
        Me.Controls.Add(Me.dtTanggal)
        Me.Name = "FrmTravelTicketDetail"
        Me.Controls.SetChildIndex(Me.dtTanggal, 0)
        Me.Controls.SetChildIndex(Me.txtNoVoucher, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.GridTicket, 0)
        Me.Controls.SetChildIndex(Me.btnAddDetail, 0)
        Me.Controls.SetChildIndex(Me.btnProsesInvoice, 0)
        CType(Me.txtNoVoucher.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CStatusTicket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTanggal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNoVoucher As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GridTicket As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTicket As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NoRequest As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents dtTanggal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CAmount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Check As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents Seq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StatusTicket As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CStatusTicket As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Invoice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnAddDetail As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnProsesInvoice As DevExpress.XtraEditors.SimpleButton
End Class
