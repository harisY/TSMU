Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_PPH

    Dim fp As Cls_FP = New Cls_FP()
    Dim tes As Boolean = True
    Dim total_dpp As String = 0

    Sub usergetobject()
        fp.voucno = _VoucNo.Text
        fp.No_Faktur = _fp2.Text

        fp.No_Bukti_Potong = _No_Bukti_Potong.Text
        fp.pphid = _pph.Text
        fp.ket_pph = _ket_pph.Text
        fp.tarif = _tarif.Text
        fp.Tot_Dpp_Invoice = _Dpp.Text
        fp.tahun = _tahun.Text
        fp.bulan = _bulan.Text
        fp.lokasi = _lokasi.Text
        fp.Tot_pph = _nilai_Pph.Text
        fp.ket_dpp = _Ket_Dpp.Text
        fp.invcnbr = TextBox2.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'utama._Tot_Ppn.Text = _Dpp.Text
        fp.Tot_Dpp_Invoice = _Dpp.Text
        fp.Tot_pph = _pph.Text
        fp.No_Faktur = _fp2.Text
        fp.voucno = _VoucNo.Text
        fp.invcnbr = TextBox2.Text
        Frm_FP._No_Bukti_Potong.Text = _No_Bukti_Potong.Text
        Frm_FP.DataGridView1.SelectedRows(0).Cells(6).Value = Replace(_nilai_Pph.Text, ",", "")

        fp.deletedatapph()
        usergetobject()
        fp.insertdata88()

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim constring As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
            'Dim constring As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"

            Using con As New SqlConnection(constring)
                Using cmd As New SqlCommand("INSERT INTO FP_pph_detail (FPNo,No_Faktur,invtid,descr,Dpp,cek) VALUES ('" & _VoucNo.Text & "','" & _fp2.Text & "',@Invtid,@descr,@Dpp,@cek)", con)
                    con.Open()
                    Try
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            cmd.Parameters.AddWithValue("@invtid", row.Cells(0).Value)
                            cmd.Parameters.AddWithValue("@descr", row.Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Dpp", row.Cells(2).Value)
                            cmd.Parameters.AddWithValue("@cek", row.Cells(3).Value)
                            cmd.ExecuteNonQuery()
                        Next i
                        MessageBox.Show("Data Berhasil Disimpan")
                    Catch ex As Exception
                    End Try
                End Using
            End Using
        Next
        MessageBox.Show("Records inserted.")

        'Frm_FP.DataGridView1.SelectedRows(0).Cells(8).Value = True
        'Frm_FP._Tot_Voucher.Text = Format(Val(Frm_FP._Tot_Voucher.Text + Frm_FP.DataGridView1.SelectedRows(0).Cells(2).Value), "#,#.##")
        'Frm_FP._Tot_Ppn.Text = Format(Val(Frm_FP._Tot_Ppn.Text + Frm_FP.DataGridView1.SelectedRows(0).Cells(4).Value), "#,#.##")
        'Frm_FP._Tot_Dpp_Invoice.Text = Format(Val(Frm_FP._Tot_Dpp_Invoice.Text + Frm_FP.DataGridView1.SelectedRows(0).Cells(5).Value), "#,#.##")
        'Frm_FP._Tot_Pph.Text = Format(Val(Frm_FP._Tot_Pph.Text + Frm_FP.DataGridView1.SelectedRows(0).Cells(6).Value), "#,#.##")

        Me.Close()
    End Sub

    Private Sub _pph_DropDown(sender As Object, e As EventArgs) Handles _pph.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.pasal()
            _pph.DataSource = dtgrid
            _pph.ValueMember = "pasal"
            _pph.DisplayMember = "pasal"

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _pph_LostFocus(sender As Object, e As EventArgs) Handles _pph.LostFocus
        If _pph.Text = "" Then
        Else
            fp.pph = _pph.Text
            _ket_pph.Text = fp.pasalbyid
        End If
    End Sub

    Private Sub _ket_pph_DropDown(sender As Object, e As EventArgs) Handles _ket_pph.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.ketpasal()
            _ket_pph.DataSource = dtgrid
            _ket_pph.ValueMember = "ket_pph"
            _ket_pph.DisplayMember = "ket_pph"

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _ket_pph_LostFocus(sender As Object, e As EventArgs) Handles _ket_pph.LostFocus
        If _ket_pph.Text = "" Then
        Else
            fp.ket_pph = _ket_pph.Text
            _tarif.Text = fp.ketpasalbyid
        End If
    End Sub

    Private Sub Frm_PPH_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        _tahun.Text = Year(DateTime.Now)
        total_dpp = 0
        _nilai_Pph.Text = 0
        _Dpp.Text = 0
        ' _tarif.Text = 0
        fp.Fp = _fp2.Text
        fp.invcnbr = TextBox2.Text
        TextBox1.Text = fp.cekfaktur
        TextBox3.Text = fp.cekinv
        _bulan.Text = DateTime.Now.ToString("MM")
        ''If _fp2.Text = TextBox1.Text Then
        If TextBox2.Text = TextBox3.Text Then
            tampildata2()
        Else
            tampildata()
        End If
    End Sub

    Private Sub _lokasi_LostFocus(sender As Object, e As EventArgs) Handles _lokasi.LostFocus
        fp.tarif = _tarif.Text
        fp.lokasi = _lokasi.Text
        fp.voucno = _VoucNo.Text
        _No_Bukti_Potong.Text = fp.autonoFP
        _nilai_Pph.Text = Format(Val(_Dpp.Text * _tarif.Text / 100), "#,#.##")
    End Sub

    Sub tampildata()

        fp.Fp = _fp2.Text
        fp.voucno = _VoucNo.Text
        Try
            _Dpp.Text = 0
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk2 As New DataGridViewCheckBoxColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap_det()
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

                tes = False

                DataGridView1.Columns.Add(chk2)

                chk2.Width = 40
                chk2.HeaderText = "Pilih"
                chk2.Name = "chk"

            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampildata2()

        fp.Fp = _fp2.Text
        fp.voucno = _VoucNo.Text
        Try
            _Dpp.Text = 0
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

                tes = False

                DataGridView1.Columns.Add(chk2)

                chk2.Width = 40
                chk2.HeaderText = "Pilih"
                chk2.Name = "chk"

            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 3 Then

            If DataGridView1.SelectedRows(0).Cells(3).Value = True Then
                DataGridView1.SelectedRows(0).Cells(3).Value = False
            Else
                DataGridView1.SelectedRows(0).Cells(3).Value = True
            End If

            If DataGridView1.SelectedRows(0).Cells(3).Value = True Then
                total_dpp = total_dpp + DataGridView1.SelectedRows(0).Cells(2).Value
            Else
                total_dpp = total_dpp - DataGridView1.SelectedRows(0).Cells(2).Value
            End If

            _Dpp.Text = Format(Val(total_dpp), "#,#.##")

            If _nilai_Pph.Text = "" Or _Dpp.Text = "" Then
                _nilai_Pph.Text = 0
            Else
                _nilai_Pph.Text = Format(Val(_Dpp.Text * _tarif.Text / 100), "#,#.##")
            End If

        End If
    End Sub

    Private Sub Frm_PPH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub _lokasi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lokasi.SelectedIndexChanged

    End Sub

    Private Sub _pph_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _pph.SelectedIndexChanged

    End Sub
End Class