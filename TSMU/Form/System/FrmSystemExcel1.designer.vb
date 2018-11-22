<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSystemExcel1
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me._txtExcel = New DevExpress.XtraEditors.ButtonEdit()
        Me._cmbBulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me._cmbCust = New DevExpress.XtraEditors.ComboBoxEdit()
        Me._cmbTahun = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me._btnExport = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._txtExcel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._cmbBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._cmbCust.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._cmbTahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(17, 240)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblStatus.TabIndex = 2
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._txtExcel)
        Me.LayoutControl1.Controls.Add(Me._cmbBulan)
        Me.LayoutControl1.Controls.Add(Me._cmbCust)
        Me.LayoutControl1.Controls.Add(Me._cmbTahun)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(437, 265)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_txtExcel
        '
        Me._txtExcel.Location = New System.Drawing.Point(61, 84)
        Me._txtExcel.Name = "_txtExcel"
        Me._txtExcel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._txtExcel.Size = New System.Drawing.Size(364, 20)
        Me._txtExcel.StyleController = Me.LayoutControl1
        Me._txtExcel.TabIndex = 4
        '
        '_cmbBulan
        '
        Me._cmbBulan.Location = New System.Drawing.Point(61, 36)
        Me._cmbBulan.Name = "_cmbBulan"
        Me._cmbBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbBulan.Size = New System.Drawing.Size(364, 20)
        Me._cmbBulan.StyleController = Me.LayoutControl1
        Me._cmbBulan.TabIndex = 1
        '
        '_cmbCust
        '
        Me._cmbCust.Location = New System.Drawing.Point(61, 60)
        Me._cmbCust.Name = "_cmbCust"
        Me._cmbCust.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbCust.Size = New System.Drawing.Size(364, 20)
        Me._cmbCust.StyleController = Me.LayoutControl1
        Me._cmbCust.TabIndex = 2
        '
        '_cmbTahun
        '
        Me._cmbTahun.Location = New System.Drawing.Point(61, 12)
        Me._cmbTahun.Name = "_cmbTahun"
        Me._cmbTahun.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbTahun.Properties.DropDownRows = 4
        Me._cmbTahun.Size = New System.Drawing.Size(364, 20)
        Me._cmbTahun.StyleController = Me.LayoutControl1
        Me._cmbTahun.TabIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(437, 265)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._cmbTahun
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(417, 24)
        Me.LayoutControlItem1.Text = "Tahun"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._cmbCust
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(417, 24)
        Me.LayoutControlItem2.Text = "Customer"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._txtExcel
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(417, 173)
        Me.LayoutControlItem4.Text = "File"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._cmbBulan
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(417, 24)
        Me.LayoutControlItem3.Text = "Bulan"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(46, 13)
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me._btnExport)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 218)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(437, 47)
        Me.PanelControl1.TabIndex = 4
        '
        '_btnExport
        '
        Me._btnExport.Location = New System.Drawing.Point(343, 13)
        Me._btnExport.Name = "_btnExport"
        Me._btnExport.Size = New System.Drawing.Size(82, 22)
        Me._btnExport.StyleController = Me.LayoutControl1
        Me._btnExport.TabIndex = 5
        Me._btnExport.Text = "Ok"
        '
        'FrmSystemExcel1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 265)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.lblStatus)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmSystemExcel1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._txtExcel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._cmbBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._cmbCust.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._cmbTahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _cmbBulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents _cmbCust As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents _cmbTahun As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _txtExcel As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents _btnExport As DevExpress.XtraEditors.SimpleButton
End Class
