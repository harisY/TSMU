Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_invoice
    Dim fp As Cls_Payment = New Cls_Payment()

    Sub tampildata()

        fp.invcnbr = _invcnbr.Text
        Try

            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk2 As New DataGridViewCheckBoxColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap_det2()
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "InvtID"
                DataGridView1.Columns(0).Width = 100
                DataGridView1.Columns(1).HeaderText = "TranDesc"
                DataGridView1.Columns(1).Width = 270

                DataGridView1.Columns(2).HeaderText = "Amount"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight



            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Frm_invoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        tampildata()
    End Sub


    Private Sub Frm_invoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class