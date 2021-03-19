<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmHROrganisasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHROrganisasi))
        Me.trStrukturOrg = New DevExpress.XtraTreeList.TreeList()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.trStrukturOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trStrukturOrg
        '
        Me.trStrukturOrg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trStrukturOrg.Location = New System.Drawing.Point(0, 27)
        Me.trStrukturOrg.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.trStrukturOrg.MinWidth = 25
        Me.trStrukturOrg.Name = "trStrukturOrg"
        Me.trStrukturOrg.OptionsBehavior.AllowExpandOnDblClick = False
        Me.trStrukturOrg.OptionsBehavior.Editable = False
        Me.trStrukturOrg.OptionsBehavior.ReadOnly = True
        Me.trStrukturOrg.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.[True]
        Me.trStrukturOrg.Size = New System.Drawing.Size(1105, 631)
        Me.trStrukturOrg.TabIndex = 1
        Me.trStrukturOrg.TreeLevelWidth = 22
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "iconsetquarters5_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "iconsettrafficlightsrimmed3_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "home_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(3, "bodepartment_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(4, "boposition2_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(5, "boposition_16x16.png")
        '
        'FrmHROrganisasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1105, 658)
        Me.Controls.Add(Me.trStrukturOrg)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmHROrganisasi"
        Me.Controls.SetChildIndex(Me.trStrukturOrg, 0)
        CType(Me.trStrukturOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trStrukturOrg As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
End Class
