Public Class FrmReportCirculation

    Dim Laporan As New RptCirculationHead
    Dim Rpt_OtherDept As New RptCirculation_OtherDept
    Dim LaporanTotal As New RptCirculationTotal
    Dim Report As New ClsCR_CreateUser
    Dim dt As DataTable

    Public Circulation As String = ""



    Private Sub FrmReportCirculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call loadreport()

    End Sub

    Sub loadreport()

        'Dim _User As Boolean = True
        'Dim _Dept As Boolean = True
        'Dim _Div As Boolean = True
        'Dim _ODept As Boolean = True
        Dim _Status As String = ""

        dt = New DataTable
        dt = Report.Cek_CR_Report(Circulation)

        If dt.Rows.Count > 0 Then
            _Status = dt.Rows(0).Item("status")
            If _Status = "Other Dept" Or _Status = "Approve BOD" Or _Status = "Set Installment" Or _Status = "Close" Then
                Dim ds As New DataSet
                Dim dsOtherDept As New DataSet
                Dim dsApprove As New DataSet
                Dim dsTotal As New DataSet

                ds = Report.RptCirculation(Circulation)
                dsTotal = Report.RptCirculationTotalDOC(Circulation)

                Laporan.SetDataSource(ds)

                dsOtherDept = Report.RptCirculation_OtherDept(Circulation)
                dsApprove = Report.RptCirculation_Approve(Circulation)
                dsTotal = Report.RptCirculationTotalDOC(Circulation)

                Laporan.Subreports("RptCirculation_OtherDept.rpt").SetDataSource(dsOtherDept)
                Laporan.Subreports("RptCirculationApprove.rpt").SetDataSource(dsApprove)
                Laporan.Subreports("RptCirculationTotal.rpt").SetDataSource(dsTotal)

                With CrystalReportViewer1
                    .ReportSource = (Laporan)
                    .RefreshReport()
                    .Zoom(90)
                End With
            Else
                MessageBox.Show("Circulation can not be printed",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
                Me.Close()
            End If
        End If

    End Sub

End Class