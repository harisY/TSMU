
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmPROutstanding


    Dim dtHeader As DataTable
    Dim dtDetail As DataTable
    Dim dtApprove As DataTable
    Dim dtApprove1 As DataTable

    Dim fc_Class As New Cls_PR

    Private Sub FrmPROutstanding_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BCekData_Click(sender As Object, e As EventArgs) Handles BCekData.Click

        Try
            Cursor.Current = Cursors.WaitCursor
            dtHeader = New DataTable
            dtHeader = fc_Class.Get_HeaderOutstanding()
            GridHeader.DataSource = dtHeader
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try

    End Sub
End Class
