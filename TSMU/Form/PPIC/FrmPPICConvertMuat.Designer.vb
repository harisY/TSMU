<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICConvertMuat
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
        Me.GridConvertMuat = New DevExpress.XtraGrid.GridControl()
        Me.GridViewConvertMuat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.GridConvertMuat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewConvertMuat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridConvertMuat
        '
        Me.GridConvertMuat.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.GridConvertMuat.Location = New System.Drawing.Point(14, 14)
        Me.GridConvertMuat.MainView = Me.GridViewConvertMuat
        Me.GridConvertMuat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridConvertMuat.Name = "GridConvertMuat"
        Me.GridConvertMuat.Size = New System.Drawing.Size(1232, 629)
        Me.GridConvertMuat.TabIndex = 1
        Me.GridConvertMuat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewConvertMuat})
        '
        'GridViewConvertMuat
        '
        Me.GridViewConvertMuat.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewConvertMuat.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewConvertMuat.DetailHeight = 412
        Me.GridViewConvertMuat.GridControl = Me.GridConvertMuat
        Me.GridViewConvertMuat.Name = "GridViewConvertMuat"
        Me.GridViewConvertMuat.OptionsBehavior.Editable = False
        Me.GridViewConvertMuat.OptionsView.ColumnAutoWidth = False
        Me.GridViewConvertMuat.OptionsView.ShowGroupPanel = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridConvertMuat)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1260, 657)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1260, 657)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridConvertMuat
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1236, 633)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'FrmPPICConvertMuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1260, 684)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmPPICConvertMuat"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.GridConvertMuat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewConvertMuat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridConvertMuat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewConvertMuat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
End Class
