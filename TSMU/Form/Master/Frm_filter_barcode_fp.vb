Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_filter_barcode_fp
    Dim fpb As Cls_barcode = New Cls_barcode()

    Public Event EditingControlShowing As DataGridViewEditingControlShowingEventHandler
    Sub tampildata()
        _gridshipper2.AllowUserToAddRows = False

        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fpb.getdatabarcode()
            _gridshipper2.DataSource = dtgrid
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampildata()
    End Sub
End Class