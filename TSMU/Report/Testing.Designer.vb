<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Testing
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim QrCodeGenerator1 As DevExpress.XtraPrinting.BarCode.QRCodeGenerator = New DevExpress.XtraPrinting.BarCode.QRCodeGenerator()
        Dim Code128Generator1 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Me.ObjectDataSource1 = New DevExpress.DataAccess.ObjectBinding.ObjectDataSource(Me.components)
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.panel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrBarCode2 = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine18 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine17 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine16 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine15 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine14 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine6 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine13 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine12 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine11 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine10 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine9 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine8 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine7 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrBarCode1 = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ExcelDataSource1 = New DevExpress.DataAccess.Excel.ExcelDataSource()
        CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'ObjectDataSource1
        '
        Me.ObjectDataSource1.DataSource = GetType(TSMU.dsLaporan.QRCodeDataTable)
        Me.ObjectDataSource1.Name = "ObjectDataSource1"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.panel1})
        Me.Detail.HeightF = 288.5354!
        Me.Detail.MultiColumn.ColumnCount = 3
        Me.Detail.MultiColumn.ColumnSpacing = 9.842491!
        Me.Detail.MultiColumn.ColumnWidth = 355.1181!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        '
        'panel1
        '
        Me.panel1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.panel1.CanGrow = False
        Me.panel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel23, Me.XrLabel22, Me.XrLabel21, Me.XrLabel20, Me.XrLabel19, Me.XrLabel18, Me.XrLabel17, Me.XrLabel16, Me.XrLabel15, Me.XrBarCode2, Me.XrLabel14, Me.XrLine18, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLine17, Me.XrLine16, Me.XrLine15, Me.XrLine14, Me.XrLabel7, Me.XrLine6, Me.XrLine5, Me.XrLine13, Me.XrLine12, Me.XrLine11, Me.XrLine10, Me.XrLine9, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLine8, Me.XrLine7, Me.XrBarCode1, Me.XrLine4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.XrLine3, Me.XrLine2, Me.XrLine1})
        Me.panel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.panel1.Name = "panel1"
        Me.panel1.SizeF = New System.Drawing.SizeF(347.7717!, 285.7021!)
        '
        'XrLabel23
        '
        Me.XrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel23.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Qty]")})
        Me.XrLabel23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(2.125009!, 253.9521!)
        Me.XrLabel23.Multiline = True
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(68.75!, 27.20825!)
        Me.XrLabel23.StylePriority.UseBorders = False
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.Text = "XrLabel23"
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel22
        '
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel22.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")})
        Me.XrLabel22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(74.00001!, 213.1604!)
        Me.XrLabel22.Multiline = True
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(59.37507!, 20.91669!)
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "XrLabel22"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel21
        '
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(133.3751!, 122.7917!)
        Me.XrLabel21.Multiline = True
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(62.08324!, 15.70836!)
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "Part Name"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel20
        '
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PartName]")})
        Me.XrLabel20.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(142.3333!, 140.5835!)
        Me.XrLabel20.Multiline = True
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(203.3133!, 51.11856!)
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "XrLabel20"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel19
        '
        Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel19.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[JobNo]")})
        Me.XrLabel19.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 138.5!)
        Me.XrLabel19.Multiline = True
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(123.3751!, 53.20198!)
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.StylePriority.UseTextAlignment = False
        Me.XrLabel19.Text = "XrLabel19"
        Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel18
        '
        Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel18.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PartNo]")})
        Me.XrLabel18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(74.00001!, 105.0!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(199.5833!, 15.70835!)
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "XrLabel18"
        '
        'XrLabel17
        '
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Color]")})
        Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(74.00001!, 87.20831!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(199.5833!, 15.70835!)
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.Text = "XrLabel17"
        '
        'XrLabel16
        '
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[KodePart]")})
        Me.XrLabel16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(276.7083!, 105.0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(68.93832!, 15.70836!)
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "XrLabel16"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Bulan]")})
        Me.XrLabel15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(276.7083!, 195.3687!)
        Me.XrLabel15.Multiline = True
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(73.18835!, 14.12506!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "XrLabel15"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrBarCode2
        '
        Me.XrBarCode2.AutoModule = True
        Me.XrBarCode2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrBarCode2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvtID]")})
        Me.XrBarCode2.LocationFloat = New DevExpress.Utils.PointFloat(273.5833!, 215.4167!)
        Me.XrBarCode2.Name = "XrBarCode2"
        Me.XrBarCode2.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100.0!)
        Me.XrBarCode2.ShowText = False
        Me.XrBarCode2.SizeF = New System.Drawing.SizeF(74.18835!, 65.74362!)
        Me.XrBarCode2.StylePriority.UseBorders = False
        Me.XrBarCode2.StylePriority.UseTextAlignment = False
        QrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.[Byte]
        Me.XrBarCode2.Symbology = QrCodeGenerator1
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(198.5833!, 236.1604!)
        Me.XrLabel14.Multiline = True
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(75.0!, 15.70836!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Delivery Date"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine18
        '
        Me.XrLine18.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine18.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine18.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine18.LocationFloat = New DevExpress.Utils.PointFloat(195.4583!, 236.1604!)
        Me.XrLine18.Name = "XrLine18"
        Me.XrLine18.SizeF = New System.Drawing.SizeF(3.125!, 47.08328!)
        Me.XrLine18.StylePriority.UseBorders = False
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(136.5001!, 236.1604!)
        Me.XrLabel13.Multiline = True
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(58.95824!, 15.70836!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Outgoing"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(74.00004!, 236.1604!)
        Me.XrLabel12.Multiline = True
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(59.37503!, 15.70836!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Quality"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(74.00004!, 195.3687!)
        Me.XrLabel11.Multiline = True
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(59.37503!, 15.70834!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "1 / 2 / 3"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(2.125041!, 236.1604!)
        Me.XrLabel10.Multiline = True
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(59.37503!, 15.70836!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Quantity"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(2.125009!, 215.4167!)
        Me.XrLabel9.Multiline = True
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(59.37503!, 15.70836!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Status"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(2.125041!, 193.7854!)
        Me.XrLabel8.Multiline = True
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(59.37503!, 15.70834!)
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Shift/Date"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine17
        '
        Me.XrLine17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine17.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine17.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine17.LocationFloat = New DevExpress.Utils.PointFloat(133.3751!, 122.7917!)
        Me.XrLine17.Name = "XrLine17"
        Me.XrLine17.SizeF = New System.Drawing.SizeF(3.125!, 158.3687!)
        Me.XrLine17.StylePriority.UseBorders = False
        '
        'XrLine16
        '
        Me.XrLine16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine16.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine16.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine16.LocationFloat = New DevExpress.Utils.PointFloat(273.5833!, 193.7854!)
        Me.XrLine16.Name = "XrLine16"
        Me.XrLine16.SizeF = New System.Drawing.SizeF(3.125061!, 87.37498!)
        Me.XrLine16.StylePriority.UseBorders = False
        '
        'XrLine15
        '
        Me.XrLine15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine15.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine15.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 281.1603!)
        Me.XrLine15.Name = "XrLine15"
        Me.XrLine15.SizeF = New System.Drawing.SizeF(345.6467!, 2.083344!)
        Me.XrLine15.StylePriority.UseBorders = False
        '
        'XrLine14
        '
        Me.XrLine14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine14.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine14.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine14.LocationFloat = New DevExpress.Utils.PointFloat(70.87504!, 211.577!)
        Me.XrLine14.Name = "XrLine14"
        Me.XrLine14.SizeF = New System.Drawing.SizeF(3.125069!, 71.6667!)
        Me.XrLine14.StylePriority.UseBorders = False
        '
        'XrLabel7
        '
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(2.125041!, 122.7917!)
        Me.XrLabel7.Multiline = True
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(48.9583!, 15.70836!)
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Job No."
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine6
        '
        Me.XrLine6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine6.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 120.7083!)
        Me.XrLine6.Name = "XrLine6"
        Me.XrLine6.SizeF = New System.Drawing.SizeF(347.7717!, 2.083344!)
        Me.XrLine6.StylePriority.UseBorders = False
        '
        'XrLine5
        '
        Me.XrLine5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(2.125009!, 102.9167!)
        Me.XrLine5.Name = "XrLine5"
        Me.XrLine5.SizeF = New System.Drawing.SizeF(347.7717!, 2.083344!)
        Me.XrLine5.StylePriority.UseBorders = False
        '
        'XrLine13
        '
        Me.XrLine13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine13.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine13.LocationFloat = New DevExpress.Utils.PointFloat(0!, 7.999992!)
        Me.XrLine13.Name = "XrLine13"
        Me.XrLine13.SizeF = New System.Drawing.SizeF(345.6467!, 2.083344!)
        Me.XrLine13.StylePriority.UseBorders = False
        '
        'XrLine12
        '
        Me.XrLine12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine12.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine12.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 251.8688!)
        Me.XrLine12.Name = "XrLine12"
        Me.XrLine12.SizeF = New System.Drawing.SizeF(273.5832!, 2.083328!)
        Me.XrLine12.StylePriority.UseBorders = False
        '
        'XrLine11
        '
        Me.XrLine11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine11.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine11.LocationFloat = New DevExpress.Utils.PointFloat(0.00006357829!, 234.0771!)
        Me.XrLine11.Name = "XrLine11"
        Me.XrLine11.SizeF = New System.Drawing.SizeF(276.7083!, 2.083328!)
        Me.XrLine11.StylePriority.UseBorders = False
        '
        'XrLine10
        '
        Me.XrLine10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine10.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine10.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 211.0771!)
        Me.XrLine10.Name = "XrLine10"
        Me.XrLine10.SizeF = New System.Drawing.SizeF(347.7717!, 2.083328!)
        Me.XrLine10.StylePriority.UseBorders = False
        '
        'XrLine9
        '
        Me.XrLine9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine9.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine9.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 191.702!)
        Me.XrLine9.Name = "XrLine9"
        Me.XrLine9.SizeF = New System.Drawing.SizeF(347.7717!, 2.083344!)
        Me.XrLine9.StylePriority.UseBorders = False
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(276.7083!, 87.20831!)
        Me.XrLabel6.Multiline = True
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(65.625!, 15.70835!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Kode Part" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(2.125041!, 105.0!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(59.37497!, 15.70835!)
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Part No."
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(2.125009!, 87.20831!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(59.375!, 15.70835!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Colour"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine8
        '
        Me.XrLine8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine8.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine8.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine8.LocationFloat = New DevExpress.Utils.PointFloat(273.5833!, 82.16667!)
        Me.XrLine8.Name = "XrLine8"
        Me.XrLine8.SizeF = New System.Drawing.SizeF(3.125!, 38.54166!)
        Me.XrLine8.StylePriority.UseBorders = False
        '
        'XrLine7
        '
        Me.XrLine7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine7.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine7.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine7.LocationFloat = New DevExpress.Utils.PointFloat(70.87501!, 84.25001!)
        Me.XrLine7.Name = "XrLine7"
        Me.XrLine7.SizeF = New System.Drawing.SizeF(3.125!, 38.54166!)
        Me.XrLine7.StylePriority.UseBorders = False
        '
        'XrBarCode1
        '
        Me.XrBarCode1.AutoModule = True
        Me.XrBarCode1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrBarCode1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InvtID]")})
        Me.XrBarCode1.LocationFloat = New DevExpress.Utils.PointFloat(24.00001!, 42.49999!)
        Me.XrBarCode1.Name = "XrBarCode1"
        Me.XrBarCode1.Padding = New DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100.0!)
        Me.XrBarCode1.ShowText = False
        Me.XrBarCode1.SizeF = New System.Drawing.SizeF(301.6667!, 32.29167!)
        Me.XrBarCode1.StylePriority.UseBorders = False
        Me.XrBarCode1.StylePriority.UseTextAlignment = False
        Me.XrBarCode1.Symbology = Code128Generator1
        Me.XrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLine4
        '
        Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 82.16667!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(347.7717!, 2.083328!)
        Me.XrLine4.StylePriority.UseBorders = False
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(276.7083!, 10.00001!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(71.06335!, 19.95831!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "ADM"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(102.125!, 10.00001!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(140.2083!, 19.95831!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PASS CARD"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(71.91667!, 21.95832!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "TSC1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLine3
        '
        Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(273.5833!, 7.916673!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(3.125!, 23.95833!)
        Me.XrLine3.StylePriority.UseBorders = False
        '
        'XrLine2
        '
        Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine2.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(71.91667!, 7.999992!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(2.083328!, 23.95833!)
        Me.XrLine2.StylePriority.UseBorders = False
        '
        'XrLine1
        '
        Me.XrLine1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine1.BorderWidth = 1.0!
        Me.XrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 29.95831!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(347.7717!, 2.083334!)
        Me.XrLine1.StylePriority.UseBorderDashStyle = False
        Me.XrLine1.StylePriority.UseBorders = False
        Me.XrLine1.StylePriority.UseBorderWidth = False
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 35.29167!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 51.00629!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'ExcelDataSource1
        '
        Me.ExcelDataSource1.Name = "ExcelDataSource1"
        '
        'Testing
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.ObjectDataSource1, Me.ExcelDataSource1})
        Me.DataSource = Me.ObjectDataSource1
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(51, 55, 35, 51)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ReportPrintOptions.DetailCountOnEmptyDataSource = 12
        Me.Version = "18.2"
        CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents ObjectDataSource1 As DevExpress.DataAccess.ObjectBinding.ObjectDataSource
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents panel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ExcelDataSource1 As DevExpress.DataAccess.Excel.ExcelDataSource
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine8 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine7 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine17 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine16 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine15 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine14 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine6 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine13 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine12 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine11 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine10 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine9 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine18 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrBarCode2 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrBarCode1 As DevExpress.XtraReports.UI.XRBarCode
End Class
