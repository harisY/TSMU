<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICConvertMuatDetail
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtTotalMobil = New DevExpress.XtraEditors.TextEdit()
        Me.btnKonversi = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.txtTotalMobil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridDetail)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(4, 64)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1186, 637)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridDetail
        '
        Me.GridDetail.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridDetail.Location = New System.Drawing.Point(2, 2)
        Me.GridDetail.MainView = Me.GridViewDetail
        Me.GridDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.Size = New System.Drawing.Size(1182, 633)
        Me.GridDetail.TabIndex = 4
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetail})
        '
        'GridViewDetail
        '
        Me.GridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewDetail.DetailHeight = 412
        Me.GridViewDetail.GridControl = Me.GridDetail
        Me.GridViewDetail.Name = "GridViewDetail"
        Me.GridViewDetail.OptionsView.ColumnAutoWidth = False
        Me.GridViewDetail.OptionsView.ShowGroupPanel = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.Root.Size = New System.Drawing.Size(1186, 637)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridDetail
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1186, 637)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1194, 705)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.txtTotalMobil)
        Me.LayoutControl2.Controls.Add(Me.btnKonversi)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Padding = New System.Windows.Forms.Padding(12)
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1188, 54)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'txtTotalMobil
        '
        Me.txtTotalMobil.Enabled = False
        Me.txtTotalMobil.Location = New System.Drawing.Point(341, 10)
        Me.txtTotalMobil.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtTotalMobil.Name = "txtTotalMobil"
        Me.txtTotalMobil.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalMobil.Size = New System.Drawing.Size(100, 28)
        Me.txtTotalMobil.StyleController = Me.LayoutControl2
        Me.txtTotalMobil.TabIndex = 5
        '
        'btnKonversi
        '
        Me.btnKonversi.Location = New System.Drawing.Point(2, 10)
        Me.btnKonversi.MaximumSize = New System.Drawing.Size(150, 0)
        Me.btnKonversi.Name = "btnKonversi"
        Me.btnKonversi.Size = New System.Drawing.Size(150, 32)
        Me.btnKonversi.StyleController = Me.LayoutControl2
        Me.btnKonversi.TabIndex = 4
        Me.btnKonversi.Text = "Konversi Muat"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1188, 54)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnKonversi
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(154, 54)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtTotalMobil
        Me.LayoutControlItem3.Location = New System.Drawing.Point(154, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 10, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1034, 54)
        Me.LayoutControlItem3.Text = "Total Kebutuhan Truk  "
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(164, 19)
        '
        'FrmPPICConvertMuatDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1194, 732)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmPPICConvertMuatDetail"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.txtTotalMobil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnKonversi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalMobil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
