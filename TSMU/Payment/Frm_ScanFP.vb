Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_ScanFP
    ''Public da As MySqlDataAdapter
    Dim fpb As Cls_barcode = New Cls_barcode()
    Public dt As DataTable
    Dim ling As String
    'Private Property cmd As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()
    End Sub
    Private Sub bersih()
        txtbarcode.Text = ""
        _alamatPenjual.Text = ""
        _kdJenisTransaksi.Text = ""
        _fgPengganti.Text = ""
        _nomorFaktur.Text = ""
        _masapajak.Text = ""
        _tahunpajak.Text = ""
        _tanggalFaktur.Text = ""
        _npwpPenjual.Text = ""
        _namaPenjual.Text = ""
        _jumlahDpp.Text = ""
        _jumlahPpn.Text = ""
        _jumlahPpnBm.Text = ""
        Me.txtfm.Focus()
    End Sub
    Private Sub Frm_ScanFP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bersih()
        'Koneksi()
        'da = New OdbcDataAdapter("Select * from faktur", Conn)
        'ds = New DataSet
        'ds.Clear()
        'da.Fill(ds, "faktur")
        'DataGridView1.DataSource = (ds.Tables("faktur"))
    End Sub

    'Dim Conn As OdbcConnection
    'Dim da As OdbcDataAdapter
    'Dim ds As DataSet
    'Dim str As String




    'Sub tampil()
    '    da = New MySqlDataAdapter("select * from tb_personil", koneksi)
    '    dt = New DataTable
    '    da.Fill(dt)
    '    dg.DataSource = dt

    '    dg.Columns(0).HeaderText = "NRP"
    '    dg.Columns(1).HeaderText = "Nama Personil"
    '    dg.Columns(2).HeaderText = "Pangkat"
    '    dg.Columns(3).HeaderText = "Tempat Lahir"
    '    dg.Columns(4).HeaderText = "Tanggal Lahir"
    '    dg.Columns(5).HeaderText = "Pendidikan Umum"
    '    dg.Columns(6).HeaderText = "Pendidikan Polri"
    '    dg.Columns(7).HeaderText = "Pendidikan Kejuruan"

    '    dg.AutoResizeColumns()
    '    dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Aqua
    'End Sub


    'Sub Koneksi()
    '    str = "Driver={MySQL ODBC 3.51 Driver};database=efaktur;server=localhost;uid=root;pwd=takagi"
    '    Conn = New OdbcConnection(str)
    '    If Conn.State = ConnectionState.Closed Then
    '        Conn.Open()
    '    End If
    'End Sub


    'Sub tampilbarcode()
    '    Try
    '        Call koneksi()
    '        Dim str As String
    '        str = "select * from faktur"
    '        cmd = New MySqlCommand(str, conn)
    '        rd = cmd.ExecuteReader
    '        rd.Read()

    '        If rd.HasRows Then
    '            txtNama.Text = rd.Item("nama")
    '            txtNoTelp.Text = rd.Item("notelp")
    '            rtbAlamat.Text = rd.Item("alamat")

    '        End If

    '    Catch ex As Exception



    '    End Try
    'End Sub

    Private Sub txtbarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtbarcode.KeyPress
        'If (e.KeyChar = Chr(13)) Then
        '    Call tampilbarcode()
        'End If
    End Sub

    Private Sub txtbarcode_LostFocus(sender As Object, e As EventArgs) Handles txtbarcode.LostFocus
        ling = txtbarcode.Text
        If ling = "" Then
        Else
            Dim xr As XmlReader = XmlReader.Create(ling)
            Do While xr.Read()
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "kdJenisTransaksi" Then
                    _kdJenisTransaksi.Text = xr.ReadElementString
                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "fgPengganti" Then
                        _fgPengganti.Text = xr.ReadElementString
                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "nomorFaktur" Then
                            _nomorFaktur.Text = xr.ReadElementString
                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "tanggalFaktur" Then
                                _tanggalFaktur.Text = xr.ReadElementString
                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpPenjual" Then
                                    _npwpPenjual.Text = xr.ReadElementString
                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaPenjual" Then
                                        _namaPenjual.Text = xr.ReadElementString
                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatPenjual" Then
                                            _alamatPenjual.Text = xr.ReadElementString
                                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "npwpLawanTransaksi" Then
                                                _jumlahDpp.Text = xr.ReadElementString
                                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "namaLawanTransaksi" Then
                                                    _jumlahDpp.Text = xr.ReadElementString
                                                    If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "alamatLawanTransaksi" Then
                                                        _jumlahDpp.Text = xr.ReadElementString
                                                        If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahDpp" Then
                                                            _jumlahDpp.Text = xr.ReadElementString
                                                            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpn" Then
                                                                _jumlahPpn.Text = xr.ReadElementString
                                                                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "jumlahPpnBm" Then
                                                                    _jumlahPpnBm.Text = xr.ReadElementString
                                                                Else
                                                                    xr.Read()
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Loop
            ''TextBox5.Text = Month(TextBox7.Text)
            _masapajak.Text = Mid(_tanggalFaktur.Text, 4, 2)
            _tahunpajak.Text = Mid(_tanggalFaktur.Text, 7, 4)
        End If
        Label33.Visible = True
        Label32.Visible = True
        Label34.Visible = True
        Label35.Visible = True
        Label36.Visible = True
        Label37.Visible = True
        Label40.Visible = True
        If _npwpPenjual.Text = "" Then 'Frm_fp._npwp.Text Then
            Label33.Text = "√"
            Label33.ForeColor = Color.Green
        Else
            Label33.Text = "X"
            Label33.ForeColor = Color.Red
        End If
        If _namaPenjual.Text = "" Then ' Frm_fp._nama_vendor.Text Then
            Label35.Text = "√"
            Label35.ForeColor = Color.Green
        Else
            Label35.Text = "X"
            Label35.ForeColor = Color.Red
        End If
        If _jumlahDpp.Text = "" Then 'Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value() Then
            Label36.Text = "√"
            Label36.ForeColor = Color.Green
        Else
            Label36.Text = "X"
            Label36.ForeColor = Color.Red
        End If

        If _nomorFaktur.Text = "" Then ' Mid(Replace(Replace(Frm_fp.DataGridView1.SelectedRows(0).Cells(7).Value(), ".", ""), "-", ""), 4, 13) Then
            Label34.Text = "√"
            Label34.ForeColor = Color.Green
        Else
            Label34.Text = "X"
            Label34.ForeColor = Color.Red
        End If

        If _jumlahPpn.Text = "" Then ' Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value() Then
            Label37.Text = "√"
            Label37.ForeColor = Color.Green
        Else
            Label37.Text = "X"
            Label37.ForeColor = Color.Red
        End If

        _dpp_ppn.Text = Val(_jumlahDpp.Text) + Val(_jumlahPpn.Text)
        Label1.Text = "" ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value())
        If _dpp_ppn.Text = "" Then ' Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(5).Value()) + Val(Frm_fp.DataGridView1.SelectedRows(0).Cells(4).Value()) Then
            Label40.Text = "√"
            Label40.ForeColor = Color.Green
        Else
            Label40.Text = "X"
            Label40.ForeColor = Color.Red
        End If
        If Label33.Text = "√" And Label34.Text = "√" And Label35.Text = "√" And Label36.Text = "√" And Label37.Text = "√" And Label40.Text = "√" Then
            Label32.Text = "Valid"
            Label32.ForeColor = Color.Green
        Else
            Label32.Text = "Not Valid"
            Label32.ForeColor = Color.Red
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        usergetobject()
        fpb.insertdata_barcodefp()
        MsgBox("Data tersimpan")
        Me.Close()
    End Sub

    Sub usergetobject()
        fpb.kdJenisTransaksi = _kdJenisTransaksi.Text
        fpb.fgPengganti = _fgPengganti.Text
        fpb.nomorFaktur = _nomorFaktur.Text
        fpb.tanggalFaktur = _tanggalFaktur.Text
        fpb.npwpPenjual = _npwpPenjual.Text
        fpb.namaPenjual = _namaPenjual.Text
        fpb.alamatPenjual = _alamatPenjual.Text
        fpb.jumlahDpp = _jumlahDpp.Text
        fpb.jumlahPpn = _jumlahPpn.Text
        fpb.jumlahPpnBm = _jumlahPpnBm.Text
        fpb.ling = _txtbarcode.Text
        fpb.masapajak = _masapajak.Text
        fpb.tahunpajak = _tahunpajak.Text
    End Sub

    Private Sub _jumlahDpp_TextChanged(sender As Object, e As EventArgs) Handles _jumlahDpp.TextChanged

    End Sub
End Class