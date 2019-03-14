<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSuspend_Detail
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me._total = New DevExpress.XtraEditors.TextEdit()
        Me._currency = New DevExpress.XtraEditors.TextEdit()
        Me._remark = New DevExpress.XtraEditors.TextEdit()
        Me._prno = New DevExpress.XtraEditors.TextEdit()
        Me._nosuspend = New DevExpress.XtraEditors.TextEdit()
        Me._tgl = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me._subaccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me._description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me._subtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._total.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._remark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._prno.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._nosuspend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._tgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._tgl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._total)
        Me.LayoutControl1.Controls.Add(Me._currency)
        Me.LayoutControl1.Controls.Add(Me._remark)
        Me.LayoutControl1.Controls.Add(Me._prno)
        Me.LayoutControl1.Controls.Add(Me._nosuspend)
        Me.LayoutControl1.Controls.Add(Me._tgl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(796, 112)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_total
        '
        Me._total.Location = New System.Drawing.Point(464, 60)
        Me._total.Name = "_total"
        Me._total.Size = New System.Drawing.Size(320, 20)
        Me._total.StyleController = Me.LayoutControl1
        Me._total.TabIndex = 9
        '
        '_currency
        '
        Me._currency.Location = New System.Drawing.Point(464, 36)
        Me._currency.Name = "_currency"
        Me._currency.Size = New System.Drawing.Size(320, 20)
        Me._currency.StyleController = Me.LayoutControl1
        Me._currency.TabIndex = 8
        '
        '_remark
        '
        Me._remark.Location = New System.Drawing.Point(76, 60)
        Me._remark.Name = "_remark"
        Me._remark.Size = New System.Drawing.Size(320, 20)
        Me._remark.StyleController = Me.LayoutControl1
        Me._remark.TabIndex = 6
        '
        '_prno
        '
        Me._prno.Location = New System.Drawing.Point(76, 36)
        Me._prno.Name = "_prno"
        Me._prno.Size = New System.Drawing.Size(320, 20)
        Me._prno.StyleController = Me.LayoutControl1
        Me._prno.TabIndex = 5
        '
        '_nosuspend
        '
        Me._nosuspend.Location = New System.Drawing.Point(76, 12)
        Me._nosuspend.Name = "_nosuspend"
        Me._nosuspend.Size = New System.Drawing.Size(320, 20)
        Me._nosuspend.StyleController = Me.LayoutControl1
        Me._nosuspend.TabIndex = 4
        '
        '_tgl
        '
        Me._tgl.EditValue = Nothing
        Me._tgl.Location = New System.Drawing.Point(464, 12)
        Me._tgl.Name = "_tgl"
        Me._tgl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._tgl.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._tgl.Properties.DisplayFormat.FormatString = ""
        Me._tgl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me._tgl.Properties.EditFormat.FormatString = ""
        Me._tgl.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me._tgl.Properties.Mask.EditMask = ""
        Me._tgl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me._tgl.Size = New System.Drawing.Size(320, 20)
        Me._tgl.StyleController = Me.LayoutControl1
        Me._tgl.TabIndex = 7
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(796, 112)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._nosuspend
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem1.Text = "No. Suspend"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(61, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(776, 20)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._prno
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem2.Text = "PRNo"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._remark
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem3.Text = "Remark"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._tgl
        Me.LayoutControlItem4.Location = New System.Drawing.Point(388, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem4.Text = "Date"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me._currency
        Me.LayoutControlItem5.Location = New System.Drawing.Point(388, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem5.Text = "Currency"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me._total
        Me.LayoutControlItem6.Location = New System.Drawing.Point(388, 48)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(388, 24)
        Me.LayoutControlItem6.Text = "Total"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(61, 13)
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 143)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2})
        Me.Grid.Size = New System.Drawing.Size(772, 426)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me._subaccount, Me._account, Me._description, Me._subtotal})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        '
        '_subaccount
        '
        Me._subaccount.Caption = "SubAccount"
        Me._subaccount.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me._subaccount.FieldName = "SubAccount"
        Me._subaccount.Name = "_subaccount"
        Me._subaccount.Visible = True
        Me._subaccount.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        '_account
        '
        Me._account.Caption = "Account"
        Me._account.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me._account.FieldName = "Account"
        Me._account.Name = "_account"
        Me._account.Visible = True
        Me._account.VisibleIndex = 1
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        '_description
        '
        Me._description.Caption = "Description"
        Me._description.FieldName = "Description"
        Me._description.Name = "_description"
        Me._description.Visible = True
        Me._description.VisibleIndex = 2
        '
        '_subtotal
        '
        Me._subtotal.Caption = "Amount"
        Me._subtotal.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me._subtotal.FieldName = "Amount"
        Me._subtotal.Name = "_subtotal"
        Me._subtotal.Visible = True
        Me._subtotal.VisibleIndex = 3
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'FrmSuspend_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(796, 581)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmSuspend_Detail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._total.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._currency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._remark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._prno.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._nosuspend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._tgl.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._tgl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _total As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _currency As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _remark As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _prno As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _nosuspend As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _tgl As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _subaccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents _subtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
