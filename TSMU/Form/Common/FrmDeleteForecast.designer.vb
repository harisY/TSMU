﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeleteForecast
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
        Me._cmbCust = New DevExpress.XtraEditors.ComboBoxEdit()
        Me._cmbTahun = New DevExpress.XtraEditors.ComboBoxEdit()
        Me._cmbBulan = New DevExpress.XtraEditors.LookUpEdit()
        Me._CmbFlag = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutFlag = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me._btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.TxtFile2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtTahun2 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me._CmbSite = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._cmbCust.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._cmbTahun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._cmbBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._CmbFlag.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.TxtFile2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTahun2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._CmbSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 13)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 19)
        Me.lblStatus.TabIndex = 2
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._CmbSite)
        Me.LayoutControl1.Controls.Add(Me._cmbCust)
        Me.LayoutControl1.Controls.Add(Me._cmbTahun)
        Me.LayoutControl1.Controls.Add(Me._cmbBulan)
        Me.LayoutControl1.Controls.Add(Me._CmbFlag)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(429, 193)
        Me.LayoutControl1.TabIndex = 3
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_cmbCust
        '
        Me._cmbCust.Location = New System.Drawing.Point(83, 76)
        Me._cmbCust.Name = "_cmbCust"
        Me._cmbCust.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbCust.Size = New System.Drawing.Size(334, 28)
        Me._cmbCust.StyleController = Me.LayoutControl1
        Me._cmbCust.TabIndex = 2
        '
        '_cmbTahun
        '
        Me._cmbTahun.Location = New System.Drawing.Point(83, 12)
        Me._cmbTahun.Name = "_cmbTahun"
        Me._cmbTahun.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbTahun.Properties.DropDownRows = 4
        Me._cmbTahun.Size = New System.Drawing.Size(334, 28)
        Me._cmbTahun.StyleController = Me.LayoutControl1
        Me._cmbTahun.TabIndex = 0
        '
        '_cmbBulan
        '
        Me._cmbBulan.Location = New System.Drawing.Point(83, 44)
        Me._cmbBulan.Name = "_cmbBulan"
        Me._cmbBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._cmbBulan.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Bulan")})
        Me._cmbBulan.Properties.NullText = ""
        Me._cmbBulan.Properties.PopupSizeable = False
        Me._cmbBulan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me._cmbBulan.Size = New System.Drawing.Size(334, 28)
        Me._cmbBulan.StyleController = Me.LayoutControl1
        Me._cmbBulan.TabIndex = 1
        '
        '_CmbFlag
        '
        Me._CmbFlag.Location = New System.Drawing.Point(83, 140)
        Me._CmbFlag.Name = "_CmbFlag"
        Me._CmbFlag.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._CmbFlag.Size = New System.Drawing.Size(334, 28)
        Me._CmbFlag.StyleController = Me.LayoutControl1
        Me._CmbFlag.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutFlag, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(429, 193)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._cmbTahun
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem1.Text = "Tahun"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(68, 19)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._cmbCust
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem2.Text = "Customer"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(68, 19)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._cmbBulan
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem3.Text = "Bulan"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(68, 19)
        '
        'LayoutFlag
        '
        Me.LayoutFlag.Control = Me._CmbFlag
        Me.LayoutFlag.Location = New System.Drawing.Point(0, 128)
        Me.LayoutFlag.Name = "LayoutFlag"
        Me.LayoutFlag.Size = New System.Drawing.Size(409, 45)
        Me.LayoutFlag.Text = "Flag"
        Me.LayoutFlag.TextSize = New System.Drawing.Size(68, 19)
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me._btnExport)
        Me.PanelControl1.Controls.Add(Me.lblStatus)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 230)
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
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(437, 232)
        Me.XtraTabControl1.TabIndex = 5
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(429, 193)
        Me.XtraTabPage1.Text = "Filter Parameter"
        '
        'TxtFile2
        '
        Me.TxtFile2.Location = New System.Drawing.Point(60, 44)
        Me.TxtFile2.Name = "TxtFile2"
        Me.TxtFile2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtFile2.Size = New System.Drawing.Size(357, 28)
        Me.TxtFile2.TabIndex = 5
        '
        'TxtTahun2
        '
        Me.TxtTahun2.Location = New System.Drawing.Point(60, 12)
        Me.TxtTahun2.Name = "TxtTahun2"
        Me.TxtTahun2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTahun2.Size = New System.Drawing.Size(357, 28)
        Me.TxtTahun2.TabIndex = 4
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.LayoutControlItem6})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(429, 163)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtTahun2
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem5.Text = "Tahun"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 20)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 64)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(409, 79)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtFile2
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem6.Text = "File"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(50, 20)
        '
        '_CmbSite
        '
        Me._CmbSite.Location = New System.Drawing.Point(83, 108)
        Me._CmbSite.Name = "_CmbSite"
        Me._CmbSite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._CmbSite.Size = New System.Drawing.Size(334, 28)
        Me._CmbSite.StyleController = Me.LayoutControl1
        Me._CmbSite.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._CmbSite
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(409, 32)
        Me.LayoutControlItem4.Text = "Site"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(68, 19)
        '
        'FrmDeleteForecast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 277)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDeleteForecast"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._cmbCust.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._cmbTahun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._cmbBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._CmbFlag.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutFlag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.TxtFile2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTahun2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._CmbSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents _cmbCust As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents _btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents _cmbBulan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents _CmbFlag As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutFlag As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _cmbTahun As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtFile2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtTahun2 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _CmbSite As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
