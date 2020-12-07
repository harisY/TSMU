<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankPaid2
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtTgl = New DevExpress.XtraEditors.DateEdit()
        Me._transaksi = New DevExpress.XtraEditors.TextEdit()
        Me._txttot = New DevExpress.XtraEditors.TextEdit()
        Me._txtcuryid = New DevExpress.XtraEditors.TextEdit()
        Me._txtaccountname = New DevExpress.XtraEditors.TextEdit()
        Me._txtperpost = New DevExpress.XtraEditors.TextEdit()
        Me._txtaccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._transaksi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txttot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtcuryid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtaccountname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtperpost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtTgl)
        Me.LayoutControl1.Controls.Add(Me._transaksi)
        Me.LayoutControl1.Controls.Add(Me._txttot)
        Me.LayoutControl1.Controls.Add(Me._txtcuryid)
        Me.LayoutControl1.Controls.Add(Me._txtaccountname)
        Me.LayoutControl1.Controls.Add(Me._txtperpost)
        Me.LayoutControl1.Controls.Add(Me._txtaccount)
        Me.LayoutControl1.Location = New System.Drawing.Point(-82, 40)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(716, 0, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup2
        Me.LayoutControl1.Size = New System.Drawing.Size(1373, 50)
        Me.LayoutControl1.TabIndex = 10
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtTgl
        '
        Me.TxtTgl.EditValue = Nothing
        Me.TxtTgl.Location = New System.Drawing.Point(296, 12)
        Me.TxtTgl.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTgl.Name = "TxtTgl"
        Me.TxtTgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTgl.Size = New System.Drawing.Size(115, 22)
        Me.TxtTgl.StyleController = Me.LayoutControl1
        Me.TxtTgl.TabIndex = 7
        '
        '_transaksi
        '
        Me._transaksi.Location = New System.Drawing.Point(986, 12)
        Me._transaksi.Margin = New System.Windows.Forms.Padding(4)
        Me._transaksi.Name = "_transaksi"
        Me._transaksi.Size = New System.Drawing.Size(74, 22)
        Me._transaksi.StyleController = Me.LayoutControl1
        Me._transaksi.TabIndex = 6
        '
        '_txttot
        '
        Me._txttot.Enabled = False
        Me._txttot.Location = New System.Drawing.Point(1183, 12)
        Me._txttot.Margin = New System.Windows.Forms.Padding(4)
        Me._txttot.Name = "_txttot"
        Me._txttot.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me._txttot.Properties.Appearance.Options.UseBackColor = True
        Me._txttot.Size = New System.Drawing.Size(142, 22)
        Me._txttot.StyleController = Me.LayoutControl1
        Me._txttot.TabIndex = 5
        '
        '_txtcuryid
        '
        Me._txtcuryid.Location = New System.Drawing.Point(910, 12)
        Me._txtcuryid.Margin = New System.Windows.Forms.Padding(4)
        Me._txtcuryid.Name = "_txtcuryid"
        Me._txtcuryid.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me._txtcuryid.Properties.Appearance.Options.UseBackColor = True
        Me._txtcuryid.Size = New System.Drawing.Size(72, 22)
        Me._txtcuryid.StyleController = Me.LayoutControl1
        Me._txtcuryid.TabIndex = 4
        '
        '_txtaccountname
        '
        Me._txtaccountname.Location = New System.Drawing.Point(626, 12)
        Me._txtaccountname.Margin = New System.Windows.Forms.Padding(4)
        Me._txtaccountname.Name = "_txtaccountname"
        Me._txtaccountname.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me._txtaccountname.Properties.Appearance.Options.UseBackColor = True
        Me._txtaccountname.Size = New System.Drawing.Size(280, 22)
        Me._txtaccountname.StyleController = Me.LayoutControl1
        Me._txtaccountname.TabIndex = 3
        '
        '_txtperpost
        '
        Me._txtperpost.Location = New System.Drawing.Point(99, 12)
        Me._txtperpost.Margin = New System.Windows.Forms.Padding(4)
        Me._txtperpost.Name = "_txtperpost"
        Me._txtperpost.Properties.Appearance.Options.UseTextOptions = True
        Me._txtperpost.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me._txtperpost.Size = New System.Drawing.Size(106, 22)
        Me._txtperpost.StyleController = Me.LayoutControl1
        Me._txtperpost.TabIndex = 0
        '
        '_txtaccount
        '
        Me._txtaccount.Location = New System.Drawing.Point(502, 12)
        Me._txtaccount.Margin = New System.Windows.Forms.Padding(4)
        Me._txtaccount.Name = "_txtaccount"
        Me._txtaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._txtaccount.Size = New System.Drawing.Size(120, 22)
        Me._txtaccount.StyleController = Me.LayoutControl1
        Me._txtaccount.TabIndex = 2
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem3, Me.EmptySpaceItem4, Me.LayoutControlItem2, Me.LayoutControlItem11, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1352, 56)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._txtperpost
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(197, 26)
        Me.LayoutControlItem1.Text = "PerPost"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(84, 16)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(1052, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(32, 26)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(1332, 10)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._txtaccount
        Me.LayoutControlItem2.Location = New System.Drawing.Point(403, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(211, 26)
        Me.LayoutControlItem2.Text = "Rekening Bank"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me._txtaccountname
        Me.LayoutControlItem11.Enabled = False
        Me.LayoutControlItem11.Location = New System.Drawing.Point(614, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(284, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._txtcuryid
        Me.LayoutControlItem4.Enabled = False
        Me.LayoutControlItem4.Location = New System.Drawing.Point(898, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(76, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(1317, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(15, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._txttot
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1084, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(233, 26)
        Me.LayoutControlItem3.Text = "Total Amount"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(84, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me._transaksi
        Me.LayoutControlItem5.Location = New System.Drawing.Point(974, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(78, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtTgl
        Me.LayoutControlItem6.Location = New System.Drawing.Point(197, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(206, 26)
        Me.LayoutControlItem6.Text = "Date"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(84, 16)
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridControl2.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl2.Location = New System.Drawing.Point(0, 98)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit4})
        Me.GridControl2.Size = New System.Drawing.Size(1294, 631)
        Me.GridControl2.TabIndex = 13
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.DetailHeight = 431
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'FrmBankPaid2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1294, 729)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmBankPaid2"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.GridControl2, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtTgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._transaksi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txttot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtcuryid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtaccountname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtperpost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtTgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents _transaksi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txttot As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtcuryid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtaccountname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtperpost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtaccount As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
