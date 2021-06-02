<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMaterialUsage_CKR
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDTrans = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalDari = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalSampai = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Keterangan = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(0, 28)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(790, 319)
        Me.Grid.TabIndex = 1
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDTrans, Me.TanggalDari, Me.TanggalSampai, Me.Keterangan})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'IDTrans
        '
        Me.IDTrans.FieldName = "IDTrans"
        Me.IDTrans.Name = "IDTrans"
        Me.IDTrans.Visible = True
        Me.IDTrans.VisibleIndex = 0
        Me.IDTrans.Width = 143
        '
        'TanggalDari
        '
        Me.TanggalDari.FieldName = "TanggalDari"
        Me.TanggalDari.Name = "TanggalDari"
        Me.TanggalDari.Visible = True
        Me.TanggalDari.VisibleIndex = 1
        Me.TanggalDari.Width = 138
        '
        'TanggalSampai
        '
        Me.TanggalSampai.FieldName = "TanggalSampai"
        Me.TanggalSampai.Name = "TanggalSampai"
        Me.TanggalSampai.Visible = True
        Me.TanggalSampai.VisibleIndex = 2
        Me.TanggalSampai.Width = 123
        '
        'Keterangan
        '
        Me.Keterangan.FieldName = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.Visible = True
        Me.Keterangan.VisibleIndex = 3
        Me.Keterangan.Width = 241
        '
        'FrmMaterialUsage_CKR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(790, 344)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmMaterialUsage_CKR"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDTrans As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalDari As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalSampai As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Keterangan As DevExpress.XtraGrid.Columns.GridColumn
End Class
