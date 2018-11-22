Imports System.Data
Imports System.Data.SqlClient

Public Class FormRptUpload1

    Dim fp As Cls_Payment = New Cls_Payment()
    Dim pay As Cls_report = New Cls_report()


    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim z As Integer
    Dim i As Integer
    Private strConn As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    ' Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tampilgridall()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tampilgridallbytgl()
    End Sub

    Sub tampilgridall()
        DataGridView1.AllowUserToAddRows = False

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
          
            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatauploadgrid()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count >= 0 Then
                DataGridView1.Columns(0).HeaderText = "No. Voucher"
                DataGridView1.Columns(0).Width = 120

                DataGridView1.Columns(1).HeaderText = "Supplier"
                DataGridView1.Columns(1).Width = 250

                DataGridView1.Columns(2).HeaderText = "Total Invoice"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 170
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "PPN"
                DataGridView1.Columns(3).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(4).HeaderText = "PPh"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "Transfer Charge"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 60
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "Total Transfer"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 140
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Dim prosespay As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(prosespay)
                ' '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                'prosespay.HeaderText = "Cek Payment"
                'prosespay.Name = "prosespay"
                'prosespay.Width = 80

                DataGridView1.Columns(7).HeaderText = "Cek Payment"
                DataGridView1.Columns(7).Width = 60
            End If

            'If DataGridView1.Rows.Count >= 0 Then
            '    DataGridView1.Columns(0).HeaderText = "Voucher No."
            '    DataGridView1.Columns(0).Width = 120

            '    DataGridView1.Columns(1).HeaderText = "Supplier"
            '    DataGridView1.Columns(1).Width = 250

            '    DataGridView1.Columns(2).HeaderText = "Perpost"
            '    DataGridView1.Columns(2).Width = 80

            '    DataGridView1.Columns(3).HeaderText = "Docbal"
            '    DataGridView1.Columns(3).Width = 80

            '    DataGridView1.Columns(4).HeaderText = "BankID"
            '    DataGridView1.Columns(4).Width = 80

            '    DataGridView1.Columns(5).HeaderText = "Cash Sub"
            '    DataGridView1.Columns(5).Width = 60


            '    DataGridView1.Columns(6).HeaderText = "Ref. Number 1"
            '    DataGridView1.Columns(6).Width = 80


            '    DataGridView1.Columns(7).HeaderText = "Ref. Number"
            '    DataGridView1.Columns(7).Width = 80

            '    DataGridView1.Columns(8).HeaderText = "Tanggal"
            '    DataGridView1.Columns(8).Width = 80

            '    DataGridView1.Columns(9).HeaderText = "Origdocamt"
            '    DataGridView1.Columns(9).Width = 80

            '    DataGridView1.Columns(10).HeaderText = "CuryDocBal"
            '    DataGridView1.Columns(10).Width = 80

            '    DataGridView1.Columns(11).HeaderText = "Check Payment"
            '    DataGridView1.Columns(11).Width = 80
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Sub tampilgridallbytgl()
        DataGridView1.AllowUserToAddRows = False

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatauploadgridbytgl()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "No. Voucher"
                DataGridView1.Columns(0).Width = 120

                DataGridView1.Columns(1).HeaderText = "Supplier"
                DataGridView1.Columns(1).Width = 250

                DataGridView1.Columns(2).HeaderText = "Total Invoice"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 170
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "PPN"
                DataGridView1.Columns(3).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(4).HeaderText = "PPh"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "Transfer Charge"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 60
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "Total Transfer"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 140
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Dim prosespay As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(prosespay)
                ' '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                'prosespay.HeaderText = "Cek Payment"
                'prosespay.Name = "prosespay"
                'prosespay.Width = 80

                DataGridView1.Columns(7).HeaderText = "Cek Payment"
                DataGridView1.Columns(7).Width = 60
            End If

            'If DataGridView1.Rows.Count >= 0 Then
            '    DataGridView1.Columns(0).HeaderText = "Voucher No."
            '    DataGridView1.Columns(0).Width = 120

            '    DataGridView1.Columns(1).HeaderText = "Supplier"
            '    DataGridView1.Columns(1).Width = 250

            '    DataGridView1.Columns(2).HeaderText = "Perpost"
            '    DataGridView1.Columns(2).Width = 80

            '    DataGridView1.Columns(3).HeaderText = "Docbal"
            '    DataGridView1.Columns(3).Width = 80

            '    DataGridView1.Columns(4).HeaderText = "BankID"
            '    DataGridView1.Columns(4).Width = 80

            '    DataGridView1.Columns(5).HeaderText = "Cash Sub"
            '    DataGridView1.Columns(5).Width = 60


            '    DataGridView1.Columns(6).HeaderText = "Ref. Number 1"
            '    DataGridView1.Columns(6).Width = 80


            '    DataGridView1.Columns(7).HeaderText = "Ref. Number"
            '    DataGridView1.Columns(7).Width = 80

            '    DataGridView1.Columns(8).HeaderText = "Tanggal"
            '    DataGridView1.Columns(8).Width = 80

            '    DataGridView1.Columns(9).HeaderText = "Origdocamt"
            '    DataGridView1.Columns(9).Width = 80

            '    DataGridView1.Columns(10).HeaderText = "CuryDocBal"
            '    DataGridView1.Columns(10).Width = 80

            '    DataGridView1.Columns(11).HeaderText = "Check Payment"
            '    DataGridView1.Columns(11).Width = 80
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub usergetobject()
        Dim i As Integer
        fp.voucno = DataGridView1.SelectedRows(i).Cells(0).Value.ToString
        fp.prosespay = DataGridView1.SelectedRows(i).Cells(0).Value.ToString
   
        'id = selectedItem.Cells(7).Value
        'idList(i) = id
        'i += 1

        'Next selectedItem

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If DataGridView1.Rows.Count > 0 Then
        '    usergetobject()
        '    fp.updatealluploadgrid()
        'End If

        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        Using con As New SqlConnection(constring)

            con.Open()
            Try
                Dim query As String
                '        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim prosespay, vrno As String
                For i As Integer = 0 To Me.DataGridView1.Rows.Count
                    prosespay = Me.DataGridView1.Rows(i).Cells(7).Value
                    vrno = Me.DataGridView1.Rows(i).Cells(0).Value.ToString
                    'Using cmd As New SqlCommand("update payment_header1 set prosespay='" & prosespay & "' where vrno='" & vrno & "' ", con)
                    '    '        '        cmd.Parameters.AddWithValue("@prosespay", DataGridView1.Rows(i).Cells(7).Value)
                    '    '        '        cmd.Parameters.AddWithValue("@vrno", DataGridView1.Rows(i).Cells(0).Value)
                    '    cmd.ExecuteNonQuery()
                    'End Using
               
                    query = "update payment_header1 set prosespay='" & prosespay & "' where vrno='" & vrno & "' "
                    mdlmain.ExecQueryByCommand(query)

                    'Dim bit As String
                    'bit = DataGridView1.SelectedCells(7).Value

                Next
            Catch ex As Exception
                ''Throw
            End Try

        End Using

                'For Each row As DataGridViewRow In DataGridView1.Rows
                '    'Assuming first column has the checkboxes
                '    If row.Cells(7).Value = True Then
                '        Dim query As String
                '        'Carry out update and make sure your DateTime is properly formatted
                '        query = "update payment_header1 set prosespay='1' where vrno='@vrno'"
                '        mdlmain.ExecQueryByCommand(query)
                '    End If
                'Next
                'Dim conn As SqlConnection = New SqlConnection()
                'conn.Open()

                'Dim comm As SqlCommand = New SqlCommand()
                'comm.Connection = conn

                'Dim prosespay, vrno As String
                'For i As Integer = 0 To Me.DataGridView1.Rows.Count
                '    prosespay = Me.DataGridView1.Rows(i).Cells(7).ToString()
                '    vrno = Me.DataGridView1.Rows(i).Cells(0).ToString()

                '    comm.CommandText = "update payment_header1 set prosespay='" & prosespay & "' where vrno='" & vrno & "' "
                '    comm.ExecuteNonQuery()
                'Next

                MessageBox.Show("Data Updated.")
                DataGridView1.Columns.Clear()
                DataGridView1.Refresh()
        tampilgridallbytgl()

    End Sub

    'Sub updatealluploadgrid1()
    '    fp.updatealluploadgrid()
    'End Sub

    'Sub updatealluploadgrid()
    '    Try
    '        Dim dtGrid As DataTable = New DataTable
    '        dtGrid = fp.updatealluploadgrid()
    '        DataGridView1.DataSource = dtGrid
    '        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        If ex.InnerException IsNot Nothing Then
    '            MsgBox(ex.InnerException)
    '        End If
    '    End Try
    'End Sub

    ''Private intSelectedRows As New List(Of Integer)

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        'Dim bit As Boolean
        'bit = DataGridView1.SelectedCells(7).Value

        'If DataGridView1.SelectedCells(7).Value = False Then
        '    DataGridView1.SelectedCells(7).Value = True
        'Else
        '    DataGridView1.SelectedCells(7).Value = True
        'End If
            'Dim prosespay, vrno As String
            'For i As Integer = 0 To Me.DataGridView1.Rows.Count
            '    prosespay = Me.DataGridView1.Rows(i).Cells(7).ToString()
            '    vrno = Me.DataGridView1.Rows(i).Cells(0).ToString()
            '    If e.ColumnIndex = 7 Then
            '        If Me.DataGridView1.Rows(i).Cells(7).Value = True Then
            '            Me.DataGridView1.Rows(i).Cells(7).Value = False
            '        Else
            '            Me.DataGridView1.Rows(i).Cells(7).Value = True
            '        End If
            '    End If
            'Next
        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If row.Cells(7).Value = False Then
        '        row.Cells(7).Value = True
        '    Else
        '        row.Cells(7).Value = True
        '    End If
        'Next
            'For i As Integer = 0 To DataGridView1.Rows.Count
            '    If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '        DataGridView1.SelectedRows(i).Cells(7).Value = False
            '    Else
            '        DataGridView1.SelectedRows(i).Cells(7).Value = True
            '    End If
            'Next i


            'If DataGridView1.Rows.Count > 0 Then
            'For i As Integer = 0 To Me.DataGridView1.Rows.Count
            '        If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '            DataGridView1.SelectedRows(i).Cells(7).Value = False
            '        Else
            '            DataGridView1.SelectedRows(i).Cells(7).Value = True
            '        End If
            'Next i
            'End If

            'For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            '    If e.ColumnIndex = 7 Then
            '        If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '            DataGridView1.SelectedRows(i).Cells(7).Value = False
            '        Else
            '            DataGridView1.SelectedRows(i).Cells(7).Value = True
            '        End If
            '    End If
            'Next

            'For i As Integer = 0 To Me.DataGridView1.RowCount - 2
            '    If CBool(Me.DataGridView1.Rows(i).Cells(0).Value) = True Then
            '        MessageBox.Show(Me.DataGridView1.Rows(i).Cells(1).Value.ToString())
            '    End If
            'Next

            'Dim TotalRecords As Integer = DataGridView1.RowCount - 0
            'For i As Integer = 0 To TotalRecords
            '    For Each row In DataGridView1.SelectedRows
            '        If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '            DataGridView1.SelectedRows(i).Cells(7).Value = False
            '        Else
            '            DataGridView1.SelectedRows(i).Cells(7).Value = True
            '        End If
            '    Next
            'Next

            'Dim id, i As Integer
            'Dim idList(5)
            'For Each selectedItem As DataGridViewRow In DataGridView1.SelectedRows
            '    'show ids of multiple selected rows
            '    If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '        DataGridView1.SelectedRows(i).Cells(7).Value = False
            '    Else
            '        DataGridView1.SelectedRows(i).Cells(7).Value = True
            '    End If
            '    id = selectedItem.Cells(7).Value
            '    idList(i) = id
            '    i += 1
            'Next selectedItem


            'Dim sResult As String = ""
            'For Each elem As String In idList
            '    sResult &= elem & ", "
            'Next

            'For Each cell In DataGridView1.SelectedCells
            '    If DataGridView1.SelectedRows(0).Cells(7).Value = True Then
            '        DataGridView1.SelectedRows(0).Cells(7).Value = False
            '    Else
            '        DataGridView1.SelectedRows(0).Cells(7).Value = True
            '    End If
            'Next

            'For Each row As DataGridViewRow In DataGridView1.Rows
            '    If e.ColumnIndex = 7 Then
            '        If DataGridView1.SelectedRows(i).Cells(7).Value = True Then
            '            DataGridView1.SelectedRows(i).Cells(7).Value = False
            '        Else
            '            DataGridView1.SelectedRows(i).Cells(7).Value = True
            '        End If
            '    End If
            'Next

            ''Dim selectedItems As DataGridViewSelectedRowCollection = DataGridView1.SelectedRows
            ''For Each selectedItem As DataGridViewRow In selectedItems
            'If e.ColumnIndex = 7 Then
            '    If DataGridView1.SelectedRows(0).Cells(7).Value = True Then
            '        DataGridView1.SelectedRows(0).Cells(7).Value = False
            '    Else
            '        DataGridView1.SelectedRows(0).Cells(7).Value = True
            '    End If
            'End If
            ''Next

            'Dim TotalRecords As Integer = DataGridView1.RowCount - 1
            'For i As Integer = 0 To TotalRecords
            '    If DataGridView1.Rows(i).Cells(7).Value = False Then
            '        DataGridView1.Rows(i).Cells(7).Value = True
            '    Else
            '        DataGridView1.Rows(i).Cells(7).Value = True
            '    End If
            'Next i



            'With CType(sender, DataGridView)
            '    Dim intRow As Integer = .CurrentRow.Index
            '    If Not Me.intSelectedRows.Contains(intRow) Then
            '        Me.intSelectedRows.Add(intRow)
            '    Else
            '        .CurrentRow.Selected = False
            '        Me.intSelectedRows.Remove(intRow)
            '    End If
            'End With

    End Sub


    'Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
    '    If Me.intSelectedRows.Contains(e.RowIndex) Then
    '        CType(sender, DataGridView).Rows(e.RowIndex).Selected = True
    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampilsudahdipilih()
    End Sub

    Sub tampilsudahdipilih()
        DataGridView1.AllowUserToAddRows = False

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay.getalldatauploadgridbytglsdhpilih()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "No. Voucher"
                DataGridView1.Columns(0).Width = 120

                DataGridView1.Columns(1).HeaderText = "Supplier"
                DataGridView1.Columns(1).Width = 250

                DataGridView1.Columns(2).HeaderText = "Total Invoice"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 170
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "PPN"
                DataGridView1.Columns(3).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(3).Width = 80
                DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(4).HeaderText = "PPh"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "Transfer Charge"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 60
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "Total Transfer"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 140
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                'Dim prosespay As New DataGridViewCheckBoxColumn()
                'DataGridView1.Columns.Add(prosespay)
                ' '' DataGridView1.Rows.Add("Row1", CheckState.Checked)
                'prosespay.HeaderText = "Cek Payment"
                'prosespay.Name = "prosespay"
                'prosespay.Width = 80

                DataGridView1.Columns(7).HeaderText = "Cek Payment"
                DataGridView1.Columns(7).Width = 60
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class