<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTravelerDetail
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
        Me.TxtPassNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtVisaNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNIK = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPassExpDate = New DevExpress.XtraEditors.DateEdit()
        Me.TxtVisaExpDate = New DevExpress.XtraEditors.DateEdit()
        Me.TxtDeptID = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtPassNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVisaNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNIK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPassExpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVisaExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVisaExpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDeptID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtPassNo)
        Me.LayoutControl1.Controls.Add(Me.TxtVisaNo)
        Me.LayoutControl1.Controls.Add(Me.TxtNama)
        Me.LayoutControl1.Controls.Add(Me.TxtNIK)
        Me.LayoutControl1.Controls.Add(Me.TxtPassExpDate)
        Me.LayoutControl1.Controls.Add(Me.TxtVisaExpDate)
        Me.LayoutControl1.Controls.Add(Me.TxtDeptID)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(828, 556)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtPassNo
        '
        Me.TxtPassNo.Location = New System.Drawing.Point(112, 132)
        Me.TxtPassNo.Name = "TxtPassNo"
        Me.TxtPassNo.Size = New System.Drawing.Size(285, 20)
        Me.TxtPassNo.StyleController = Me.LayoutControl1
        Me.TxtPassNo.TabIndex = 10
        '
        'TxtVisaNo
        '
        Me.TxtVisaNo.Location = New System.Drawing.Point(112, 84)
        Me.TxtVisaNo.Name = "TxtVisaNo"
        Me.TxtVisaNo.Size = New System.Drawing.Size(285, 20)
        Me.TxtVisaNo.StyleController = Me.LayoutControl1
        Me.TxtVisaNo.TabIndex = 8
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(112, 36)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(285, 20)
        Me.TxtNama.StyleController = Me.LayoutControl1
        Me.TxtNama.TabIndex = 6
        '
        'TxtNIK
        '
        Me.TxtNIK.Location = New System.Drawing.Point(112, 12)
        Me.TxtNIK.Name = "TxtNIK"
        Me.TxtNIK.Size = New System.Drawing.Size(285, 20)
        Me.TxtNIK.StyleController = Me.LayoutControl1
        Me.TxtNIK.TabIndex = 4
        '
        'TxtPassExpDate
        '
        Me.TxtPassExpDate.EditValue = Nothing
        Me.TxtPassExpDate.Location = New System.Drawing.Point(112, 156)
        Me.TxtPassExpDate.Name = "TxtPassExpDate"
        Me.TxtPassExpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtPassExpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtPassExpDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtPassExpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtPassExpDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtPassExpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtPassExpDate.Properties.Mask.EditMask = ""
        Me.TxtPassExpDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtPassExpDate.Size = New System.Drawing.Size(285, 20)
        Me.TxtPassExpDate.StyleController = Me.LayoutControl1
        Me.TxtPassExpDate.TabIndex = 5
        '
        'TxtVisaExpDate
        '
        Me.TxtVisaExpDate.EditValue = Nothing
        Me.TxtVisaExpDate.Location = New System.Drawing.Point(112, 108)
        Me.TxtVisaExpDate.Name = "TxtVisaExpDate"
        Me.TxtVisaExpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtVisaExpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtVisaExpDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtVisaExpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtVisaExpDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtVisaExpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtVisaExpDate.Properties.Mask.EditMask = ""
        Me.TxtVisaExpDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtVisaExpDate.Size = New System.Drawing.Size(285, 20)
        Me.TxtVisaExpDate.StyleController = Me.LayoutControl1
        Me.TxtVisaExpDate.TabIndex = 9
        '
        'TxtDeptID
        '
        Me.TxtDeptID.Location = New System.Drawing.Point(112, 60)
        Me.TxtDeptID.Name = "TxtDeptID"
        Me.TxtDeptID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDeptID.Size = New System.Drawing.Size(285, 20)
        Me.TxtDeptID.StyleController = Me.LayoutControl1
        Me.TxtDeptID.TabIndex = 7
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(828, 556)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(389, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(419, 536)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtPassExpDate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(389, 392)
        Me.LayoutControlItem2.Text = "Passport Expr. Date"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtNIK
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem1.Text = "NIK"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtNama
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem3.Text = "Nama Traveler"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtDeptID
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem4.Text = "DeptID"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtVisaNo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem5.Text = "Visa No"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtVisaExpDate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem6.Text = "Visa Expr. Date"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(97, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtPassNo
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(389, 24)
        Me.LayoutControlItem7.Text = "Passpost No"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(97, 13)
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'FrmTravelerDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmTravelerDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtPassNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVisaNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNIK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPassExpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVisaExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVisaExpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDeptID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtNIK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtPassNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtVisaNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtPassExpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TxtVisaExpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents TxtDeptID As DevExpress.XtraEditors.ButtonEdit
End Class
