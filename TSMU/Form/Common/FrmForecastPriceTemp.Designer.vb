<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmForecastPriceTemp
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtPartName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtHarga = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPartNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtInventory = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.TxtTahun = New DevExpress.XtraEditors.TextEdit()
        Me.TxtBulan = New DevExpress.XtraEditors.LookUpEdit()
        Me.TxtSite = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtPartName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtHarga.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPartNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInventory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.03226!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.96774!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(563, 362)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtPartName)
        Me.LayoutControl1.Controls.Add(Me.TxtHarga)
        Me.LayoutControl1.Controls.Add(Me.TxtPartNo)
        Me.LayoutControl1.Controls.Add(Me.TxtInventory)
        Me.LayoutControl1.Controls.Add(Me.TxtCustomer)
        Me.LayoutControl1.Controls.Add(Me.TxtTahun)
        Me.LayoutControl1.Controls.Add(Me.TxtBulan)
        Me.LayoutControl1.Controls.Add(Me.TxtSite)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(557, 356)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtPartName
        '
        Me.TxtPartName.Location = New System.Drawing.Point(86, 142)
        Me.TxtPartName.Name = "TxtPartName"
        Me.TxtPartName.Size = New System.Drawing.Size(459, 22)
        Me.TxtPartName.StyleController = Me.LayoutControl1
        Me.TxtPartName.TabIndex = 10
        '
        'TxtHarga
        '
        Me.TxtHarga.EditValue = "0"
        Me.TxtHarga.Location = New System.Drawing.Point(86, 194)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtHarga.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TxtHarga.Properties.DisplayFormat.FormatString = "#,##"
        Me.TxtHarga.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.TxtHarga.Properties.EditFormat.FormatString = "#,##"
        Me.TxtHarga.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.TxtHarga.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TxtHarga.Size = New System.Drawing.Size(459, 22)
        Me.TxtHarga.StyleController = Me.LayoutControl1
        Me.TxtHarga.TabIndex = 9
        '
        'TxtPartNo
        '
        Me.TxtPartNo.Location = New System.Drawing.Point(86, 116)
        Me.TxtPartNo.Name = "TxtPartNo"
        Me.TxtPartNo.Size = New System.Drawing.Size(459, 22)
        Me.TxtPartNo.StyleController = Me.LayoutControl1
        Me.TxtPartNo.TabIndex = 8
        '
        'TxtInventory
        '
        Me.TxtInventory.Location = New System.Drawing.Point(86, 90)
        Me.TxtInventory.Name = "TxtInventory"
        Me.TxtInventory.Size = New System.Drawing.Size(459, 22)
        Me.TxtInventory.StyleController = Me.LayoutControl1
        Me.TxtInventory.TabIndex = 7
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(86, 64)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(459, 22)
        Me.TxtCustomer.StyleController = Me.LayoutControl1
        Me.TxtCustomer.TabIndex = 6
        '
        'TxtTahun
        '
        Me.TxtTahun.Location = New System.Drawing.Point(86, 12)
        Me.TxtTahun.Name = "TxtTahun"
        Me.TxtTahun.Size = New System.Drawing.Size(459, 22)
        Me.TxtTahun.StyleController = Me.LayoutControl1
        Me.TxtTahun.TabIndex = 4
        '
        'TxtBulan
        '
        Me.TxtBulan.Location = New System.Drawing.Point(86, 38)
        Me.TxtBulan.Name = "TxtBulan"
        Me.TxtBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtBulan.Properties.NullText = ""
        Me.TxtBulan.Size = New System.Drawing.Size(459, 22)
        Me.TxtBulan.StyleController = Me.LayoutControl1
        Me.TxtBulan.TabIndex = 5
        '
        'TxtSite
        '
        Me.TxtSite.Location = New System.Drawing.Point(86, 168)
        Me.TxtSite.Name = "TxtSite"
        Me.TxtSite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtSite.Properties.Items.AddRange(New Object() {"TNG-U", "TSC3-U"})
        Me.TxtSite.Size = New System.Drawing.Size(459, 22)
        Me.TxtSite.StyleController = Me.LayoutControl1
        Me.TxtSite.TabIndex = 11
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(557, 356)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtTahun
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem1.Text = "Tahun"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(71, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 208)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(537, 128)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtBulan
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem2.Text = "Bulan"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtCustomer
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem3.Text = "Customer ID"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtInventory
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem4.Text = "Inventory ID"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtPartNo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem5.Text = "Part No"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtHarga
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 182)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem6.Text = "Harga"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtPartName
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem7.Text = "Part Name"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(71, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TxtSite
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 156)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(537, 26)
        Me.LayoutControlItem8.Text = "Site"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(71, 16)
        '
        'FrmForecastPriceTemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(563, 389)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmForecastPriceTemp"
        Me.Text = "Input Inventory Sementara"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtPartName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtHarga.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPartNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInventory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TxtTahun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TxtHarga As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPartNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtInventory As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtBulan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TxtPartName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtSite As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
