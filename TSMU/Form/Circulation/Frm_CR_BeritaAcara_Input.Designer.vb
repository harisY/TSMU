<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CR_BeritaAcara_Input
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_Circulation = New DevExpress.XtraEditors.TextEdit()
        Me.T_BeritaAcara = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T_Date = New DevExpress.XtraEditors.DateEdit()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.T_Circulation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_BeritaAcara.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Date.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Circulation No"
        '
        'T_Circulation
        '
        Me.T_Circulation.Location = New System.Drawing.Point(107, 20)
        Me.T_Circulation.Name = "T_Circulation"
        Me.T_Circulation.Size = New System.Drawing.Size(206, 20)
        Me.T_Circulation.TabIndex = 1
        '
        'T_BeritaAcara
        '
        Me.T_BeritaAcara.Location = New System.Drawing.Point(107, 46)
        Me.T_BeritaAcara.Name = "T_BeritaAcara"
        Me.T_BeritaAcara.Size = New System.Drawing.Size(206, 20)
        Me.T_BeritaAcara.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "No Berita Acara"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date"
        '
        'T_Date
        '
        Me.T_Date.EditValue = Nothing
        Me.T_Date.Location = New System.Drawing.Point(107, 72)
        Me.T_Date.Name = "T_Date"
        Me.T_Date.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Date.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Date.Properties.DisplayFormat.FormatString = ""
        Me.T_Date.Properties.EditFormat.FormatString = ""
        Me.T_Date.Properties.Mask.EditMask = ""
        Me.T_Date.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.T_Date.Size = New System.Drawing.Size(206, 20)
        Me.T_Date.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(157, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(238, 108)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Frm_CR_BeritaAcara_Input
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 147)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.T_BeritaAcara)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T_Circulation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.T_Date)
        Me.Name = "Frm_CR_BeritaAcara_Input"
        Me.Text = "Berita Acara Input"
        CType(Me.T_Circulation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_BeritaAcara.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Date.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Date.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents T_Circulation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_BeritaAcara As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents T_Date As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
