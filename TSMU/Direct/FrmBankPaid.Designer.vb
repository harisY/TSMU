<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankPaid
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me._txtcuryid = New DevExpress.XtraEditors.TextEdit()
        Me._txtaccountname = New DevExpress.XtraEditors.TextEdit()
        Me._txtsaldo = New DevExpress.XtraEditors.TextEdit()
        Me._txtperpost = New DevExpress.XtraEditors.TextEdit()
        Me._txtaccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._txtcuryid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtaccountname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtsaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtperpost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(855, 78)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(855, 78)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._txtcuryid)
        Me.LayoutControl1.Controls.Add(Me._txtaccountname)
        Me.LayoutControl1.Controls.Add(Me._txtsaldo)
        Me.LayoutControl1.Controls.Add(Me._txtperpost)
        Me.LayoutControl1.Controls.Add(Me._txtaccount)
        Me.LayoutControl1.Location = New System.Drawing.Point(9, 30)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(716, 0, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup2
        Me.LayoutControl1.Size = New System.Drawing.Size(600, 93)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_txtcuryid
        '
        Me._txtcuryid.Location = New System.Drawing.Point(457, 36)
        Me._txtcuryid.Name = "_txtcuryid"
        Me._txtcuryid.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me._txtcuryid.Properties.Appearance.Options.UseBackColor = True
        Me._txtcuryid.Size = New System.Drawing.Size(59, 20)
        Me._txtcuryid.StyleController = Me.LayoutControl1
        Me._txtcuryid.TabIndex = 4
        '
        '_txtaccountname
        '
        Me._txtaccountname.Location = New System.Drawing.Point(169, 36)
        Me._txtaccountname.Name = "_txtaccountname"
        Me._txtaccountname.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me._txtaccountname.Properties.Appearance.Options.UseBackColor = True
        Me._txtaccountname.Size = New System.Drawing.Size(284, 20)
        Me._txtaccountname.StyleController = Me.LayoutControl1
        Me._txtaccountname.TabIndex = 3
        '
        '_txtsaldo
        '
        Me._txtsaldo.Location = New System.Drawing.Point(85, 60)
        Me._txtsaldo.Name = "_txtsaldo"
        Me._txtsaldo.Size = New System.Drawing.Size(80, 20)
        Me._txtsaldo.StyleController = Me.LayoutControl1
        Me._txtsaldo.TabIndex = 5
        '
        '_txtperpost
        '
        Me._txtperpost.Location = New System.Drawing.Point(85, 12)
        Me._txtperpost.Name = "_txtperpost"
        Me._txtperpost.Size = New System.Drawing.Size(80, 20)
        Me._txtperpost.StyleController = Me.LayoutControl1
        Me._txtperpost.TabIndex = 0
        '
        '_txtaccount
        '
        Me._txtaccount.Location = New System.Drawing.Point(85, 36)
        Me._txtaccount.Name = "_txtaccount"
        Me._txtaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._txtaccount.Size = New System.Drawing.Size(80, 20)
        Me._txtaccount.StyleController = Me.LayoutControl1
        Me._txtaccount.TabIndex = 2
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem11, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.EmptySpaceItem3, Me.EmptySpaceItem4})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(600, 93)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._txtperpost
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(157, 24)
        Me.LayoutControlItem1.Text = "PerPost"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(70, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(508, 24)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(72, 24)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._txtaccount
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(157, 24)
        Me.LayoutControlItem2.Text = "Rekening Bank"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._txtsaldo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(157, 25)
        Me.LayoutControlItem3.Text = "Saldo Awal"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(70, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me._txtaccountname
        Me.LayoutControlItem11.Enabled = False
        Me.LayoutControlItem11.Location = New System.Drawing.Point(157, 24)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(288, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._txtcuryid
        Me.LayoutControlItem4.Enabled = False
        Me.LayoutControlItem4.Location = New System.Drawing.Point(445, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(63, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(263, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(274, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 25)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "PAID"
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(157, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(423, 24)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(157, 48)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(423, 25)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'FrmBankPaid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 177)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmBankPaid"
        Me.Text = "FrmBankPaid"
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._txtcuryid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtaccountname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtsaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtperpost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _txtcuryid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtaccountname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtsaldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtperpost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtaccount As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
End Class
