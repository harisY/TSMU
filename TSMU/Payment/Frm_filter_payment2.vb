Public Class Frm_filter_payment2

    Dim payment As Cls_Payment = New Cls_Payment()
    Public Event EditingControlShowing As DataGridViewEditingControlShowingEventHandler
    Sub tampildata()
        _gridshipper2.AllowUserToAddRows = False

        Try
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()

            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3a()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "InvcNbr"
                _gridshipper2.Columns(0).Width = 110
                _gridshipper2.Columns(1).HeaderText = "InvcDate"
                _gridshipper2.Columns(1).Width = 70
                _gridshipper2.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"
                _gridshipper2.Columns(1).Visible = False
                _gridshipper2.Columns(2).HeaderText = "BankID"
                _gridshipper2.Columns(2).Width = 110
                _gridshipper2.Columns(2).Visible = False
                _gridshipper2.Columns(3).HeaderText = "BankName"
                _gridshipper2.Columns(3).Width = 110
                _gridshipper2.Columns(3).Visible = False
                _gridshipper2.Columns(4).HeaderText = "VendID"
                _gridshipper2.Columns(4).Width = 110
                _gridshipper2.Columns(4).Visible = False
                _gridshipper2.Columns(5).HeaderText = "Supplier"
                _gridshipper2.Columns(5).Width = 300
                _gridshipper2.Columns(6).HeaderText = "Descr"
                _gridshipper2.Columns(6).Width = 110
                _gridshipper2.Columns(6).Visible = False
                _gridshipper2.Columns(7).HeaderText = "Tot_DPP"
                _gridshipper2.Columns(7).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(7).Width = 80
                _gridshipper2.Columns(7).Visible = False
                _gridshipper2.Columns(8).HeaderText = "Tot_PPN"
                _gridshipper2.Columns(8).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(8).Width = 80
                _gridshipper2.Columns(8).Visible = False
                _gridshipper2.Columns(9).HeaderText = "Total_DPP_PPN"
                _gridshipper2.Columns(9).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(9).Width = 80
                _gridshipper2.Columns(9).Visible = False
                _gridshipper2.Columns(10).HeaderText = "PPh"
                _gridshipper2.Columns(10).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(10).Width = 80
                _gridshipper2.Columns(10).Visible = False
                _gridshipper2.Columns(11).HeaderText = "Biaya_Transfer"
                _gridshipper2.Columns(11).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(11).Width = 80
                _gridshipper2.Columns(11).Visible = False
                _gridshipper2.Columns(12).HeaderText = "CM_DM"
                _gridshipper2.Columns(12).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(12).Width = 80
                _gridshipper2.Columns(12).Visible = False
                _gridshipper2.Columns(13).HeaderText = ""
                _gridshipper2.Columns(13).Width = 110
                _gridshipper2.Columns(13).Visible = False
                _gridshipper2.Columns(14).HeaderText = "Amount"
                _gridshipper2.Columns(14).DefaultCellStyle.Format = "##,0"
                _gridshipper2.Columns(14).Width = 80
                _gridshipper2.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                _gridshipper2.Columns(15).Visible = True
                _gridshipper2.Columns(16).Visible = True

            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Frm_Filter_payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "VOUCHER LIST - " & user1
        ''Label4.Text = user1
        tampildata()
    End Sub



    Private Sub klikgrid()

        Frm_Payment.Show()

        Try
            If _gridshipper2.Rows.Count > 0 Then

                With Frm_Payment
                    ._VocNo.Text = _gridshipper2.SelectedRows(0).Cells(0).Value.ToString()
                    ._Tgl_fp.Text = _gridshipper2.SelectedRows(0).Cells(1).Value.ToString()
                    ._BankID.Text = _gridshipper2.SelectedRows(0).Cells(2).Value.ToString()
                    ._BankName.Text = _gridshipper2.SelectedRows(0).Cells(3).Value.ToString()
                    ._VendID.Text = _gridshipper2.SelectedRows(0).Cells(4).Value.ToString()
                    ._Vend_Name.Text = _gridshipper2.SelectedRows(0).Cells(5).Value.ToString()
                    ._jenis_jasa.Text = _gridshipper2.SelectedRows(0).Cells(6).Value.ToString()
                    ._Tot_Dpp_Invoice.Text = _gridshipper2.SelectedRows(0).Cells(7).Value.ToString()
                    ._Tot_Ppn.Text = _gridshipper2.SelectedRows(0).Cells(8).Value.ToString()
                    ._Tot_Voucher.Text = _gridshipper2.SelectedRows(0).Cells(9).Value.ToString()
                    ._Tot_Pph.Text = _gridshipper2.SelectedRows(0).Cells(10).Value.ToString()
                    ._Biaya_Transfer.Text = _gridshipper2.SelectedRows(0).Cells(11).Value.ToString()
                    ._tot_cndn.Text = _gridshipper2.SelectedRows(0).Cells(12).Value.ToString()
                    ._curyid.Text = _gridshipper2.SelectedRows(0).Cells(13).Value.ToString()
                    ._debit_bank.Text = _gridshipper2.SelectedRows(0).Cells(9).Value.ToString() - _gridshipper2.SelectedRows(0).Cells(11).Value.ToString()
                    .Button2.Enabled = True


                End With
            End If
        Catch ex As Exception
            ' Return
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try

    End Sub

    Private Sub _gridshipper2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _gridshipper2.CellContentClick

        If e.ColumnIndex = 0 Then
            Try
                klikgrid()
                Me.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 5 Then
            MsgBox("aaa")
        End If
        If e.ColumnIndex = 4 Then
            If _gridshipper2.SelectedRows(0).Cells(4).Value = True Then
                _gridshipper2.SelectedRows(0).Cells(4).Value = False
                MsgBox("aaa")
            Else
                _gridshipper2.SelectedRows(0).Cells(4).Value = True
            End If
        End If
        ''Me.Close()
    End Sub
End Class