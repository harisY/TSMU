<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeliveryDetail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeliveryDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.QtyOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Delivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Jumlah = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockTNG08DEL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockTNG05WHJ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockTNG06SFG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Stock2nd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockPaint = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockInjectPresisi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WHP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StockTNG04_02PNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalStock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Ket = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ItemNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LblTanggal = New System.Windows.Forms.Label()
        Me.BSearch = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(3, 84)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(920, 329)
        Me.Grid.TabIndex = 22
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Customer, Me.InvtId, Me.DeliveryDueDate, Me.QtyOrder, Me.Delivery, Me.Jumlah, Me.StockTNG08DEL, Me.StockTNG05WHJ, Me.StockTNG06SFG, Me.Stock2nd, Me.StockPaint, Me.StockInjectPresisi, Me.WHP, Me.StockTNG04_02PNT, Me.TotalStock, Me.Balance, Me.Ket, Me.ItemNumber})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(687, 284, 260, 232)
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'Customer
        '
        Me.Customer.FieldName = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.OptionsColumn.AllowEdit = False
        Me.Customer.OptionsColumn.FixedWidth = True
        Me.Customer.Visible = True
        Me.Customer.VisibleIndex = 0
        Me.Customer.Width = 95
        '
        'InvtId
        '
        Me.InvtId.FieldName = "InvtId"
        Me.InvtId.Name = "InvtId"
        Me.InvtId.OptionsColumn.AllowEdit = False
        Me.InvtId.Visible = True
        Me.InvtId.VisibleIndex = 1
        Me.InvtId.Width = 125
        '
        'DeliveryDueDate
        '
        Me.DeliveryDueDate.FieldName = "Delivery Due Date"
        Me.DeliveryDueDate.Name = "DeliveryDueDate"
        Me.DeliveryDueDate.OptionsColumn.AllowEdit = False
        Me.DeliveryDueDate.Visible = True
        Me.DeliveryDueDate.VisibleIndex = 3
        Me.DeliveryDueDate.Width = 118
        '
        'QtyOrder
        '
        Me.QtyOrder.AppearanceCell.Options.UseTextOptions = True
        Me.QtyOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.QtyOrder.FieldName = "Qty Order"
        Me.QtyOrder.Name = "QtyOrder"
        Me.QtyOrder.OptionsColumn.AllowEdit = False
        Me.QtyOrder.Visible = True
        Me.QtyOrder.VisibleIndex = 4
        Me.QtyOrder.Width = 72
        '
        'Delivery
        '
        Me.Delivery.AppearanceCell.Options.UseTextOptions = True
        Me.Delivery.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Delivery.FieldName = "Delivery"
        Me.Delivery.Name = "Delivery"
        Me.Delivery.OptionsColumn.AllowEdit = False
        Me.Delivery.Visible = True
        Me.Delivery.VisibleIndex = 5
        Me.Delivery.Width = 54
        '
        'Jumlah
        '
        Me.Jumlah.AppearanceCell.Options.UseTextOptions = True
        Me.Jumlah.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Jumlah.FieldName = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.OptionsColumn.AllowEdit = False
        Me.Jumlah.Visible = True
        Me.Jumlah.VisibleIndex = 6
        Me.Jumlah.Width = 48
        '
        'StockTNG08DEL
        '
        Me.StockTNG08DEL.AppearanceCell.Options.UseTextOptions = True
        Me.StockTNG08DEL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StockTNG08DEL.FieldName = "Stock TNG 08 DEL"
        Me.StockTNG08DEL.Name = "StockTNG08DEL"
        Me.StockTNG08DEL.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.StockTNG08DEL.Visible = True
        Me.StockTNG08DEL.VisibleIndex = 7
        Me.StockTNG08DEL.Width = 96
        '
        'StockTNG05WHJ
        '
        Me.StockTNG05WHJ.AppearanceCell.Options.UseTextOptions = True
        Me.StockTNG05WHJ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StockTNG05WHJ.FieldName = "Stock TNG 05 WHJ"
        Me.StockTNG05WHJ.Name = "StockTNG05WHJ"
        Me.StockTNG05WHJ.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.StockTNG05WHJ.Visible = True
        Me.StockTNG05WHJ.VisibleIndex = 8
        Me.StockTNG05WHJ.Width = 101
        '
        'StockTNG06SFG
        '
        Me.StockTNG06SFG.AppearanceCell.Options.UseTextOptions = True
        Me.StockTNG06SFG.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StockTNG06SFG.FieldName = "StockTNG06SFG"
        Me.StockTNG06SFG.Name = "StockTNG06SFG"
        Me.StockTNG06SFG.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.StockTNG06SFG.Visible = True
        Me.StockTNG06SFG.VisibleIndex = 9
        Me.StockTNG06SFG.Width = 93
        '
        'Stock2nd
        '
        Me.Stock2nd.FieldName = "Stock 2nd"
        Me.Stock2nd.Name = "Stock2nd"
        Me.Stock2nd.Width = 110
        '
        'StockPaint
        '
        Me.StockPaint.FieldName = "Stock Paint"
        Me.StockPaint.Name = "StockPaint"
        Me.StockPaint.Width = 110
        '
        'StockInjectPresisi
        '
        Me.StockInjectPresisi.FieldName = "Stock Inject Presisi"
        Me.StockInjectPresisi.Name = "StockInjectPresisi"
        Me.StockInjectPresisi.Width = 110
        '
        'WHP
        '
        Me.WHP.AppearanceCell.Options.UseTextOptions = True
        Me.WHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.WHP.FieldName = "WHP"
        Me.WHP.Name = "WHP"
        Me.WHP.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.WHP.Visible = True
        Me.WHP.VisibleIndex = 10
        Me.WHP.Width = 48
        '
        'StockTNG04_02PNT
        '
        Me.StockTNG04_02PNT.FieldName = "Stock TNG 04-02 PNT"
        Me.StockTNG04_02PNT.Name = "StockTNG04_02PNT"
        Me.StockTNG04_02PNT.Width = 112
        '
        'TotalStock
        '
        Me.TotalStock.AppearanceCell.Options.UseTextOptions = True
        Me.TotalStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TotalStock.FieldName = "Total Stock"
        Me.TotalStock.Name = "TotalStock"
        Me.TotalStock.OptionsColumn.AllowEdit = False
        Me.TotalStock.UnboundExpression = "[Stock TNG 05 WHJ] + [StockTNG06SFG] + [Stock TNG 08 DEL] + [WHP]"
        Me.TotalStock.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.TotalStock.Visible = True
        Me.TotalStock.VisibleIndex = 11
        Me.TotalStock.Width = 74
        '
        'Balance
        '
        Me.Balance.AppearanceCell.Options.UseTextOptions = True
        Me.Balance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.OptionsColumn.AllowEdit = False
        Me.Balance.UnboundExpression = "[Total Stock] - [Jumlah]"
        Me.Balance.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.Balance.Visible = True
        Me.Balance.VisibleIndex = 12
        Me.Balance.Width = 61
        '
        'Ket
        '
        Me.Ket.FieldName = "Keterangan"
        Me.Ket.Name = "Ket"
        Me.Ket.Visible = True
        Me.Ket.VisibleIndex = 13
        Me.Ket.Width = 158
        '
        'ItemNumber
        '
        Me.ItemNumber.FieldName = "Item Number"
        Me.ItemNumber.Name = "ItemNumber"
        Me.ItemNumber.Visible = True
        Me.ItemNumber.VisibleIndex = 2
        Me.ItemNumber.Width = 148
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.LblTanggal)
        Me.Panel1.Controls.Add(Me.BSearch)
        Me.Panel1.Location = New System.Drawing.Point(3, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(920, 50)
        Me.Panel1.TabIndex = 23
        '
        'LblTanggal
        '
        Me.LblTanggal.AutoSize = True
        Me.LblTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTanggal.Location = New System.Drawing.Point(90, 10)
        Me.LblTanggal.Name = "LblTanggal"
        Me.LblTanggal.Size = New System.Drawing.Size(86, 24)
        Me.LblTanggal.TabIndex = 1
        Me.LblTanggal.Text = "Tanggal"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(9, 13)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(75, 23)
        Me.BSearch.TabIndex = 0
        Me.BSearch.Text = "Browse"
        Me.BSearch.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmDeliveryDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(935, 425)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmDeliveryDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BSearch As Button
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeliveryDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents QtyOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Delivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Jumlah As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockTNG08DEL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockTNG05WHJ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockTNG06SFG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Stock2nd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockPaint As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockInjectPresisi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WHP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockTNG04_02PNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TotalStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Ket As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ItemNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LblTanggal As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
