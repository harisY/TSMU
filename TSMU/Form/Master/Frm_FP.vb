Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_FP
    Dim fp As Cls_FP = New Cls_FP()

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Private strConn As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    'Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection
    Dim total As String = 0
    Dim totalppn As String = 0
    Dim totalpph As String = 0
    Dim totaldpp As String = 0
    Dim tes As Boolean = True
    Dim aneh As Boolean
    Dim aneh1 As Boolean
    Dim aneh2 As Boolean

    Private Sub supplier()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplier()
            _VendID.DataSource = dtgrid
            _VendID.ValueMember = "VendID"
            _VendID.DisplayMember = "VendID"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub _VendID_DropDown(sender As Object, e As EventArgs) Handles _VendID.DropDown
        supplier()
    End Sub

    Sub usergetobject()
        fp.voucno = _VoucNo.Text
        fp.tgl_fp = _Tgl_fp.Text
        fp.VendID = _VendID.Text
        fp.Vend_Name = _Vend_Name.Text
        fp.jenis_jasa = _jenis_jasa.Text
        fp.npwp = _npwp.Text
        fp.No_Bukti_Potong = _No_Bukti_Potong.Text
        ''    fp.Pphid = _Pphid.text

        fp.CuryID = _curyid.Text
        fp.Tot_Dpp_Invoice = _Tot_Dpp_Invoice.Text
        fp.Tot_ppn = _Tot_Ppn.Text
        fp.Tot_voucher = _Tot_Voucher.Text
        fp.Tot_pph = _Tot_Pph.Text
        '   fp.Status = _Status.text
        fp.nama_vendor = _nama_vendor.Text

    End Sub

    Private Sub _VendID_LostFocus(sender As Object, e As EventArgs) Handles _VendID.LostFocus
        fp.VendID = _VendID.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyid2()
            _Vend_Name.Text = dtgrid.Rows(0).Item(0).ToString
            _npwp.Text = dtgrid.Rows(0).Item(1).ToString
            _jenis_jasa.Text = dtgrid.Rows(0).Item(2).ToString
            _nama_vendor.Text = dtgrid.Rows(0).Item(3).ToString
            '   det()

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub det()
        fp.VendID = _VendID.Text
        sqlCon = New SqlConnection(strConn)

        Using (sqlCon)
            Dim sqlComm As New SqlCommand
            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "PROSES_VOUCHER_APNOTPAYYMENT"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlCon.Open()
            sqlComm.ExecuteNonQuery()
        End Using

        tampildata()
    End Sub
    Private Sub _Vend_Name_DropDown(sender As Object, e As EventArgs) Handles _Vend_Name.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplier()
            _Vend_Name.DataSource = dtgrid
            _Vend_Name.ValueMember = "Name"
            _Vend_Name.DisplayMember = "Name"

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _Vend_Name_LostFocus(sender As Object, e As EventArgs) Handles _Vend_Name.LostFocus

        fp.Vend_Name = _Vend_Name.Text
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplierbyname2()
            _VendID.Text = dtgrid.Rows(0).Item(0).ToString
            _npwp.Text = dtgrid.Rows(0).Item(1).ToString
            _jenis_jasa.Text = dtgrid.Rows(0).Item(2).ToString
            _nama_vendor.Text = dtgrid.Rows(0).Item(3).ToString

            '  det()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Frm_FP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        aneh = True
        aneh1 = True
        aneh2 = True
        _VoucNo.Text = fp.autono
        _Tgl_fp.Text = Format(DateTime.Now)
    End Sub

    Sub dt()
       
    End Sub

    Sub tampildata()

        ' DataGridView1.Rows.Clear()

        '' DataGridView1.Columns.Remove(7)
        ' DataGridView1.Refresh()
        'If chk.Name = "chk" Then
        '    DataGridView1.Columns.Remove(chk)
        'End If
        'If btn.Name = "ppn" Then
        '    DataGridView1.Columns.Remove(btn)
        'End If
        'If btn1.Name = "PPh" Then
        '    DataGridView1.Columns.Remove(btn1)
        'End If
        Try

            total = 0
            totalppn = 0
            totaldpp = 0
            totalpph = 0
            _Tot_Voucher.Text = 0
            _Tot_Ppn.Text = 0
            _Tot_Dpp_Invoice.Text = 0
            _Tot_Pph.Text = 0
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()


            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then


                DataGridView1.Columns(0).HeaderText = "InvcNbr"
                DataGridView1.Columns(0).Width = 90

                DataGridView1.Columns(1).HeaderText = "InvcDate"
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView1.Columns(2).HeaderText = "Amount"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "CuryId"
                DataGridView1.Columns(3).Width = 40

                DataGridView1.Columns(4).HeaderText = "PPN"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "DPP"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 80
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "PPh"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(7).HeaderText = "No. FP"
                DataGridView1.Columns(7).Width = 140

                tes = False
                'Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Pilih"
                chk.Name = "chk"
                chk.Width = 40
                '         DataGridView1.Rows(1).Cells(8).Value = True
                '  Dim btn As New DataGridViewButtonColumn()
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Scan Barcode"
                btn.Text = ""
                btn.Name = "ppn"
                btn.UseColumnTextForButtonValue = True

                ' Dim btn1 As New DataGridViewButtonColumn()
                DataGridView1.Columns.Add(btn1)
                btn1.HeaderText = "PPh"
                btn1.Text = ""
                btn1.Name = "PPh"
                btn1.UseColumnTextForButtonValue = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampildata12()

        Try

            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.getalldataap_det3()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then


                DataGridView1.Columns(0).HeaderText = "InvcNbr"
                DataGridView1.Columns(0).Width = 90

                DataGridView1.Columns(1).HeaderText = "InvcDate"
                DataGridView1.Columns(1).Width = 70
                DataGridView1.Columns(1).DefaultCellStyle.Format = "dd-MM-yyyy"

                DataGridView1.Columns(2).HeaderText = "Amount"
                DataGridView1.Columns(2).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(2).Width = 80
                DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(3).HeaderText = "CuryId"
                DataGridView1.Columns(3).Width = 40

                DataGridView1.Columns(4).HeaderText = "PPN"
                DataGridView1.Columns(4).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(4).Width = 80
                DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(5).HeaderText = "DPP"
                DataGridView1.Columns(5).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(5).Width = 80
                DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(6).HeaderText = "PPh"
                DataGridView1.Columns(6).DefaultCellStyle.Format = "##,0"
                DataGridView1.Columns(6).Width = 80
                DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                DataGridView1.Columns(7).HeaderText = "No. FP"
                DataGridView1.Columns(7).Width = 140

                tes = False
                'Dim chk As New DataGridViewCheckBoxColumn()
                DataGridView1.Columns.Add(chk)
                chk.HeaderText = "Pilih"
                chk.Name = "chk"
                chk.Width = 40
                '         DataGridView1.Rows(1).Cells(8).Value = True
                '  Dim btn As New DataGridViewButtonColumn()
                DataGridView1.Columns.Add(btn)
                btn.HeaderText = "Scan Barcode"
                btn.Text = ""
                btn.Name = "ppn"
                btn.UseColumnTextForButtonValue = True

                ' Dim btn1 As New DataGridViewButtonColumn()
                DataGridView1.Columns.Add(btn1)
                btn1.HeaderText = "PPh"
                btn1.Text = ""
                btn1.Name = "PPh"
                btn1.UseColumnTextForButtonValue = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 9 Then
            Frm_ScanFP.StartPosition = FormStartPosition.CenterScreen
            ''  Frm_ScanFP.Label38.Text = DataGridView1.SelectedRows(0).Cells(4).Value()

            Frm_ScanFP.ShowDialog()

        End If
        If DataGridView1.Columns(e.ColumnIndex).Name = "PPh" Then
            DataGridView1.CurrentCell.Value = "ABCD"
        End If
        If e.ColumnIndex = 10 Then
            Frm_PPH.StartPosition = FormStartPosition.CenterScreen
            Frm_PPH._fp2.Text = DataGridView1.SelectedRows(0).Cells(7).Value
            Frm_PPH._VoucNo.Text = _VoucNo.Text
            Frm_PPH.TextBox2.Text = DataGridView1.SelectedRows(0).Cells(0).Value
            Frm_PPH.ShowDialog()

        End If

        If e.ColumnIndex = 8 Then

            If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
                DataGridView1.SelectedRows(0).Cells(8).Value = False
            Else
                DataGridView1.SelectedRows(0).Cells(8).Value = True
            End If

            If DataGridView1.SelectedRows(0).Cells(8).Value = True Then
                total = total + DataGridView1.SelectedRows(0).Cells(2).Value
                totalppn = totalppn + DataGridView1.SelectedRows(0).Cells(4).Value
                totaldpp = totaldpp + DataGridView1.SelectedRows(0).Cells(5).Value
                totalpph = totalpph + DataGridView1.SelectedRows(0).Cells(6).Value

            Else
                total = total - DataGridView1.SelectedRows(0).Cells(2).Value
                totalppn = totalppn - DataGridView1.SelectedRows(0).Cells(4).Value
                totaldpp = totaldpp - DataGridView1.SelectedRows(0).Cells(5).Value
                totalpph = totalpph - DataGridView1.SelectedRows(0).Cells(6).Value
            End If

            _Tot_Voucher.Text = Format(Val(total), "#,#.##")
            _Tot_Ppn.Text = Format(Val(totalppn), "#,#.##")
            _Tot_Dpp_Invoice.Text = Format(Val(totaldpp), "#,#.##")
            _Tot_Pph.Text = Format(Val(totalpph), "#,#.##")

        End If
    End Sub


    Private Sub bot_simpan()
        usergetobject()
        fp.insertdata()

        Dim connectionString As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"

        Using connection As New SqlConnection(connectionString)

            Dim cmdText As String = "INSERT INTO FP_Detail (FPNo,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,link_barcode) VALUES ('" & _VoucNo.Text & "', @Column1, @Column2, @Column3, @Column4,@Column5, @Column6, @Column7, @Column8, @Column9)"
            Dim command As New SqlCommand(cmdText, connection)
            command.Parameters.Add(New SqlParameter("@Column1", SqlDbType.Char))
            command.Parameters.Add(New SqlParameter("@Column2", SqlDbType.Date))
            command.Parameters.Add(New SqlParameter("@Column3", SqlDbType.Float))
            command.Parameters.Add(New SqlParameter("@Column4", SqlDbType.Char))
            command.Parameters.Add(New SqlParameter("@Column5", SqlDbType.Float))
            command.Parameters.Add(New SqlParameter("@Column6", SqlDbType.Float))
            command.Parameters.Add(New SqlParameter("@Column7", SqlDbType.Float))
            command.Parameters.Add(New SqlParameter("@Column8", SqlDbType.Char))
            command.Parameters.Add(New SqlParameter("@Column9", SqlDbType.Char))
            connection.Open()
            Dim transaction As SqlTransaction = connection.BeginTransaction()
            command.Transaction = transaction

            Try

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    command.Parameters("@Column1").Value = DataGridView1.Rows(i).Cells(0).FormattedValue
                    command.Parameters("@Column2").Value = DataGridView1.Rows(i).Cells(1).FormattedValue
                    command.Parameters("@Column3").Value = DataGridView1.Rows(i).Cells(2).FormattedValue
                    command.Parameters("@Column4").Value = DataGridView1.Rows(i).Cells(3).FormattedValue
                    command.Parameters("@Column5").Value = DataGridView1.Rows(i).Cells(4).FormattedValue
                    command.Parameters("@Column6").Value = DataGridView1.Rows(i).Cells(5).FormattedValue
                    command.Parameters("@Column7").Value = DataGridView1.Rows(i).Cells(6).FormattedValue
                    command.Parameters("@Column8").Value = DataGridView1.Rows(i).Cells(7).FormattedValue
                    command.Parameters("@Column9").Value = DataGridView1.Rows(i).Cells(8).FormattedValue
                    command.ExecuteNonQuery()
                Next i

                transaction.Commit()
                MessageBox.Show("Data Berhasil Disimpan")
            Catch ex As Exception

                Try
                    transaction.Rollback()

                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try

            End Try

        End Using

        fp.deletedatacek()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Frm_filter_fp.StartPosition = FormStartPosition.CenterScreen
        Frm_filter_fp.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        det()
    End Sub

    Sub clear()
        _VoucNo.Text = fp.autono
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"
        _npwp.Text = ""
        _nama_vendor.Text = ""
        _jenis_jasa.Text = ""
        _No_Bukti_Potong.Text = ""
        total = 0
        totalppn = 0
        totaldpp = 0
        totalpph = 0
        _Tot_Voucher.Text = 0
        _Tot_Ppn.Text = 0
        _Tot_Dpp_Invoice.Text = 0
        _Tot_Pph.Text = 0

        '     DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        _VoucNo.Text = fp.autono
        _VendID.Text = "P0001"
        _Vend_Name.Text = "3 M INDONESIA , PT"
        _npwp.Text = ""
        _nama_vendor.Text = ""
        _jenis_jasa.Text = ""
        _No_Bukti_Potong.Text = ""
        total = 0
        totalppn = 0
        totaldpp = 0
        totalpph = 0
        _Tot_Voucher.Text = 0
        _Tot_Ppn.Text = 0
        _Tot_Dpp_Invoice.Text = 0
        _Tot_Pph.Text = 0

        '     DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        usergetobject()
        fp.insertdata()
        fp.deletedatacek()

        For Each row As DataGridViewRow In DataGridView1.Rows
            ' Dim constring As String = "Data Source=.\SQL2008R2;Initial Catalog=AjaxSamples;Integrated Security=true"
            Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
            ' Dim constring As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
            Using con As New SqlConnection(constring)
                '   Using cmd As New SqlCommand("INSERT INTO Customers VALUES(@CustomerId, @Name, @Country)", con)
                Using cmd As New SqlCommand("INSERT INTO FP_Detail (FPNo,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,link_barcode) VALUES ('" & _VoucNo.Text & "', @No_Invoice,@Tgl_Invoice,@Jml_Invoice,@CuryID,@Ppn,@Dpp,@Pph,@No_Faktur,@link_barcode)", con)
                    con.Open()
                    Try

                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            cmd.Parameters.AddWithValue("@No_Invoice", row.Cells(0).Value)
                            cmd.Parameters.AddWithValue("@Tgl_Invoice", row.Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Jml_Invoice", row.Cells(2).Value)
                            cmd.Parameters.AddWithValue("@CuryID", row.Cells(3).Value)
                            cmd.Parameters.AddWithValue("@Ppn", row.Cells(4).Value)
                            cmd.Parameters.AddWithValue("@Dpp", row.Cells(5).Value)
                            cmd.Parameters.AddWithValue("@Pph", row.Cells(6).Value)
                            cmd.Parameters.AddWithValue("@No_Faktur", row.Cells(7).Value)
                            cmd.Parameters.AddWithValue("@link_barcode", row.Cells(8).Value)
                            ' con.Open()
                            cmd.ExecuteNonQuery()
                            ' con.Close()

                        Next i

                        ' transaction.Commit()
                        MessageBox.Show("Data Berhasil Disimpan")
                    Catch ex As Exception
                    End Try
                End Using
            End Using
        Next
        MessageBox.Show("Records inserted.")
        'fp.deletedatacek()
        fp.updatedatasolomon()
    End Sub




    Private Sub _VoucNo_TextChanged(sender As Object, e As EventArgs) Handles _VoucNo.TextChanged
        fp.Fp = _VoucNo.Text
        tampildata12()
    End Sub


    Private Sub _VendID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _VendID.SelectedIndexChanged

    End Sub
End Class