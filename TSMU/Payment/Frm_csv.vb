Imports System.Data
Imports System.Data.SqlClient




Public Class Frm_csv

    Dim fp As Cls_Payment = New Cls_Payment()

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DevExpress.XtraPrinting.CsvExportOptions.FollowReportLayout = False
        Dim options As DevExpress.XtraPrinting.CsvExportOptions = New DevExpress.XtraPrinting.CsvExportOptions()
        options.SkipEmptyColumns = True
        options.Separator = ";"
        options.Encoding = System.Text.Encoding.[Default]

        GridView1.ExportToCsv("D:\Testing1.txt", options)

    End Sub

    Private Sub Frm_csv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim detsupplier As DataTable = fp.detsupplier
        GridControl1.DataSource = detsupplier

    End Sub
End Class