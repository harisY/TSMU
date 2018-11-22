Public Class Frm_filter_fp
    Delegate Sub SetColumnIndex(ByVal i As Integer)
    Dim fp As Cls_FP = New Cls_FP()
    Public Event EditingControlShowing As DataGridViewEditingControlShowingEventHandler
    Sub tampildata11()

        _gridshipper2.AllowUserToAddRows = False
        _gridshipper2.MultiSelect = False
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldata2()
            _gridshipper2.DataSource = dtgrid
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub klikgrid()

        Try
            If _gridshipper2.Rows.Count > 0 Then

                With Frm_FP
                    ._VoucNo.Text = _gridshipper2.SelectedRows(0).Cells(0).Value.ToString()
                    ._Tgl_fp.Text = _gridshipper2.SelectedRows(0).Cells(1).Value.ToString()
                    ._VendID.Text = _gridshipper2.SelectedRows(0).Cells(2).Value.ToString()
                    ._Vend_Name.Text = _gridshipper2.SelectedRows(0).Cells(3).Value.ToString()
                    ._jenis_jasa.Text = _gridshipper2.SelectedRows(0).Cells(4).Value.ToString()
                    ._npwp.Text = _gridshipper2.SelectedRows(0).Cells(5).Value.ToString()
                    ._No_Bukti_Potong.Text = _gridshipper2.SelectedRows(0).Cells(6).Value.ToString()
                    ._curyid.Text = _gridshipper2.SelectedRows(0).Cells(13).Value.ToString()
                    ._Tot_Dpp_Invoice.Text = _gridshipper2.SelectedRows(0).Cells(14).Value.ToString()
                    ._Tot_Ppn.Text = _gridshipper2.SelectedRows(0).Cells(15).Value.ToString()
                    ._Tot_Voucher.Text = _gridshipper2.SelectedRows(0).Cells(16).Value.ToString()
                    ._Tot_Pph.Text = _gridshipper2.SelectedRows(0).Cells(17).Value.ToString()
                    ' ._Status.text = _gridshipper2.SelectedRows(0).Cells(18).Value.ToString()
                    ._nama_vendor.Text = _gridshipper2.SelectedRows(0).Cells(19).Value.ToString()

                End With
            End If
        Catch ex As Exception
            ' Return
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try

    End Sub

    Private Sub Frm_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _gridshipper2.Columns.Clear()
        _gridshipper2.Refresh()
        tampildata11()
    End Sub

    Private Sub _gridshipper2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles _gridshipper2.CellClick

        Try
            klikgrid()
            Me.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub _txtcari_TextChanged(sender As Object, e As EventArgs) Handles _txtcari.TextChanged

        Try
            fp.txtcari = _txtcari.Text
            fp.cmbcari = _cmbcari.Text
            Dim dt As DataTable = New DataTable

            dt = fp.getalldatalikeid
            _gridshipper2.DataSource = dt
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _gridshipper2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _gridshipper2.CellContentClick

    End Sub
End Class