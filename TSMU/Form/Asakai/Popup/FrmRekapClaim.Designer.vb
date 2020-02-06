<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRekapClaim
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PartName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateAwal = New System.Windows.Forms.DateTimePicker()
        Me.DateAhir = New System.Windows.Forms.DateTimePicker()
        Me.BCari = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 62)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(731, 380)
        Me.Grid.TabIndex = 23
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PartNo, Me.PartName, Me.Qty})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(687, 284, 260, 232)
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PartNo
        '
        Me.PartNo.FieldName = "Part No"
        Me.PartNo.Name = "PartNo"
        Me.PartNo.Visible = True
        Me.PartNo.VisibleIndex = 0
        Me.PartNo.Width = 253
        '
        'PartName
        '
        Me.PartName.FieldName = "Part Name"
        Me.PartName.Name = "PartName"
        Me.PartName.Visible = True
        Me.PartName.VisibleIndex = 1
        Me.PartName.Width = 374
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 2
        Me.Qty.Width = 84
        '
        'DateAwal
        '
        Me.DateAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAwal.Location = New System.Drawing.Point(12, 12)
        Me.DateAwal.Name = "DateAwal"
        Me.DateAwal.Size = New System.Drawing.Size(158, 20)
        Me.DateAwal.TabIndex = 24
        '
        'DateAhir
        '
        Me.DateAhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateAhir.Location = New System.Drawing.Point(12, 36)
        Me.DateAhir.Name = "DateAhir"
        Me.DateAhir.Size = New System.Drawing.Size(158, 20)
        Me.DateAhir.TabIndex = 25
        '
        'BCari
        '
        Me.BCari.Location = New System.Drawing.Point(176, 13)
        Me.BCari.Name = "BCari"
        Me.BCari.Size = New System.Drawing.Size(75, 23)
        Me.BCari.TabIndex = 26
        Me.BCari.Text = "Cari"
        Me.BCari.UseVisualStyleBackColor = True
        '
        'FrmRekapClaim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 454)
        Me.Controls.Add(Me.BCari)
        Me.Controls.Add(Me.DateAhir)
        Me.Controls.Add(Me.DateAwal)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmRekapClaim"
        Me.Text = "Inventory"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateAwal As DateTimePicker
    Friend WithEvents DateAhir As DateTimePicker
    Friend WithEvents BCari As Button
    Friend WithEvents PartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PartName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
End Class
