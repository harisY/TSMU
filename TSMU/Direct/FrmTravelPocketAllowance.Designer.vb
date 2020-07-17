<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTravelPocketAllowance
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
        Me.components = New System.ComponentModel.Container()
        Me.GridPocketAllowance = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPocketAllowance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TravelTypeGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GolonganGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurryIDGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FirstTravelGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtAmountAllowance = New DevExpress.XtraEditors.TextEdit()
        Me.txtGolongan = New DevExpress.XtraEditors.TextEdit()
        Me.txtAmountFirstTravel = New DevExpress.XtraEditors.TextEdit()
        Me.txtTravelType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtCurryID = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.GridPocketAllowance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPocketAllowance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountAllowance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmountFirstTravel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCurryID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridPocketAllowance
        '
        Me.GridPocketAllowance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPocketAllowance.Location = New System.Drawing.Point(23, 91)
        Me.GridPocketAllowance.MainView = Me.GridViewPocketAllowance
        Me.GridPocketAllowance.Name = "GridPocketAllowance"
        Me.GridPocketAllowance.Size = New System.Drawing.Size(1252, 480)
        Me.GridPocketAllowance.TabIndex = 1
        Me.GridPocketAllowance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPocketAllowance})
        '
        'GridViewPocketAllowance
        '
        Me.GridViewPocketAllowance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TravelTypeGrid, Me.GolonganGrid, Me.CurryIDGrid, Me.AmountGrid, Me.FirstTravelGrid})
        Me.GridViewPocketAllowance.GridControl = Me.GridPocketAllowance
        Me.GridViewPocketAllowance.Name = "GridViewPocketAllowance"
        Me.GridViewPocketAllowance.OptionsBehavior.Editable = False
        Me.GridViewPocketAllowance.OptionsView.ColumnAutoWidth = False
        Me.GridViewPocketAllowance.OptionsView.ShowGroupPanel = False
        '
        'TravelTypeGrid
        '
        Me.TravelTypeGrid.Caption = "Travel Type"
        Me.TravelTypeGrid.FieldName = "TravelType"
        Me.TravelTypeGrid.MinWidth = 25
        Me.TravelTypeGrid.Name = "TravelTypeGrid"
        Me.TravelTypeGrid.OptionsColumn.FixedWidth = True
        Me.TravelTypeGrid.Visible = True
        Me.TravelTypeGrid.VisibleIndex = 0
        Me.TravelTypeGrid.Width = 100
        '
        'GolonganGrid
        '
        Me.GolonganGrid.Caption = "Golongan"
        Me.GolonganGrid.FieldName = "Golongan"
        Me.GolonganGrid.MinWidth = 25
        Me.GolonganGrid.Name = "GolonganGrid"
        Me.GolonganGrid.OptionsColumn.FixedWidth = True
        Me.GolonganGrid.Visible = True
        Me.GolonganGrid.VisibleIndex = 1
        Me.GolonganGrid.Width = 100
        '
        'CurryIDGrid
        '
        Me.CurryIDGrid.Caption = "Curry ID"
        Me.CurryIDGrid.FieldName = "CuryID"
        Me.CurryIDGrid.MinWidth = 25
        Me.CurryIDGrid.Name = "CurryIDGrid"
        Me.CurryIDGrid.OptionsColumn.FixedWidth = True
        Me.CurryIDGrid.Visible = True
        Me.CurryIDGrid.VisibleIndex = 2
        Me.CurryIDGrid.Width = 150
        '
        'AmountGrid
        '
        Me.AmountGrid.Caption = "Amount Allowance"
        Me.AmountGrid.DisplayFormat.FormatString = "n2"
        Me.AmountGrid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountGrid.FieldName = "Amount"
        Me.AmountGrid.MinWidth = 25
        Me.AmountGrid.Name = "AmountGrid"
        Me.AmountGrid.OptionsColumn.FixedWidth = True
        Me.AmountGrid.Visible = True
        Me.AmountGrid.VisibleIndex = 3
        Me.AmountGrid.Width = 200
        '
        'FirstTravelGrid
        '
        Me.FirstTravelGrid.Caption = "Amount First Travel"
        Me.FirstTravelGrid.DisplayFormat.FormatString = "n2"
        Me.FirstTravelGrid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.FirstTravelGrid.FieldName = "FirstTravel"
        Me.FirstTravelGrid.MinWidth = 25
        Me.FirstTravelGrid.Name = "FirstTravelGrid"
        Me.FirstTravelGrid.OptionsColumn.FixedWidth = True
        Me.FirstTravelGrid.Visible = True
        Me.FirstTravelGrid.VisibleIndex = 4
        Me.FirstTravelGrid.Width = 200
        '
        'txtAmountAllowance
        '
        Me.txtAmountAllowance.Location = New System.Drawing.Point(806, 53)
        Me.txtAmountAllowance.Name = "txtAmountAllowance"
        Me.txtAmountAllowance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAmountAllowance.Properties.DisplayFormat.FormatString = "n2"
        Me.txtAmountAllowance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmountAllowance.Properties.EditFormat.FormatString = "n2"
        Me.txtAmountAllowance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmountAllowance.Properties.Mask.EditMask = "n2"
        Me.txtAmountAllowance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmountAllowance.Properties.NullText = "0"
        Me.txtAmountAllowance.Properties.NullValuePrompt = "0"
        Me.txtAmountAllowance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmountAllowance.Size = New System.Drawing.Size(136, 22)
        Me.txtAmountAllowance.TabIndex = 3
        '
        'txtGolongan
        '
        Me.txtGolongan.Location = New System.Drawing.Point(336, 53)
        Me.txtGolongan.Name = "txtGolongan"
        Me.txtGolongan.Properties.DisplayFormat.FormatString = "f0"
        Me.txtGolongan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGolongan.Properties.EditFormat.FormatString = "f0"
        Me.txtGolongan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGolongan.Properties.Mask.EditMask = "f0"
        Me.txtGolongan.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtGolongan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGolongan.Size = New System.Drawing.Size(57, 22)
        Me.txtGolongan.TabIndex = 4
        '
        'txtAmountFirstTravel
        '
        Me.txtAmountFirstTravel.EditValue = ""
        Me.txtAmountFirstTravel.Location = New System.Drawing.Point(1136, 53)
        Me.txtAmountFirstTravel.Name = "txtAmountFirstTravel"
        Me.txtAmountFirstTravel.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAmountFirstTravel.Properties.DisplayFormat.FormatString = "n2"
        Me.txtAmountFirstTravel.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmountFirstTravel.Properties.EditFormat.FormatString = "n2"
        Me.txtAmountFirstTravel.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAmountFirstTravel.Properties.Mask.EditMask = "n2"
        Me.txtAmountFirstTravel.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAmountFirstTravel.Properties.NullText = "0"
        Me.txtAmountFirstTravel.Properties.NullValuePrompt = "0"
        Me.txtAmountFirstTravel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmountFirstTravel.Size = New System.Drawing.Size(139, 22)
        Me.txtAmountFirstTravel.TabIndex = 6
        '
        'txtTravelType
        '
        Me.txtTravelType.Location = New System.Drawing.Point(126, 53)
        Me.txtTravelType.Name = "txtTravelType"
        Me.txtTravelType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelType.Properties.Items.AddRange(New Object() {"LN", "DN"})
        Me.txtTravelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtTravelType.Size = New System.Drawing.Size(78, 22)
        Me.txtTravelType.TabIndex = 2
        '
        'txtCurryID
        '
        Me.txtCurryID.Enabled = False
        Me.txtCurryID.Location = New System.Drawing.Point(521, 53)
        Me.txtCurryID.Name = "txtCurryID"
        Me.txtCurryID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCurryID.Properties.Items.AddRange(New Object() {"USD", "YEN", "IDR"})
        Me.txtCurryID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCurryID.Size = New System.Drawing.Size(87, 22)
        Me.txtCurryID.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Travel Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Golongan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(425, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Curry ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(646, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Amount Allowance"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(981, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Amount First Travel"
        '
        'FrmTravelPocketAllowance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1287, 583)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAmountFirstTravel)
        Me.Controls.Add(Me.txtGolongan)
        Me.Controls.Add(Me.txtAmountAllowance)
        Me.Controls.Add(Me.GridPocketAllowance)
        Me.Controls.Add(Me.txtTravelType)
        Me.Controls.Add(Me.txtCurryID)
        Me.Name = "FrmTravelPocketAllowance"
        Me.Controls.SetChildIndex(Me.txtCurryID, 0)
        Me.Controls.SetChildIndex(Me.txtTravelType, 0)
        Me.Controls.SetChildIndex(Me.GridPocketAllowance, 0)
        Me.Controls.SetChildIndex(Me.txtAmountAllowance, 0)
        Me.Controls.SetChildIndex(Me.txtGolongan, 0)
        Me.Controls.SetChildIndex(Me.txtAmountFirstTravel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        CType(Me.GridPocketAllowance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPocketAllowance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountAllowance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmountFirstTravel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCurryID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridPocketAllowance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPocketAllowance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TravelTypeGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GolonganGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurryIDGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FirstTravelGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtAmountAllowance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGolongan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAmountFirstTravel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTravelType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtCurryID As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
End Class
