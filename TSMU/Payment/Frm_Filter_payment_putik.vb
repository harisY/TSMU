
Imports System.Data
Imports System.Data.SqlClient
Public Class Frm_Filter_payment_putik

    Dim payment As Cls_Payment = New Cls_Payment()
    Dim fp As Cls_Payment = New Cls_Payment()

    'Dim fp As Cls_Payment = New Cls_Payment()
    'Dim pay As Cls_report = New Cls_report()


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



    Public Event EditingControlShowing As DataGridViewEditingControlShowingEventHandler
    Sub tampildata()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

                'If user1 = "putik" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next
                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "maria" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    chk3.ReadOnly = True
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "yamada" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'Else
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(19).Value = True
                '        _gridshipper2.Rows(i).Cells(19).Value = True
                '        chk3.Selected = True
                '        chk3.ReadOnly = True
                '    Next
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80

                'End If
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub checkboxHeadercek3_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim headerBox As CheckBox = DirectCast(_gridshipper2.Controls.Find("checkboxHeader3", True)(0), CheckBox)
        For Each row As DataGridViewRow In _gridshipper2.Rows
            row.Cells(17).Value = headerBox.Checked
        Next
    End Sub


    Private Sub Frm_Filter_payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "VOUCHER LIST - " & user1
        ''Label4.Text = user
        ''updatepph()

        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        Using con As New SqlConnection(constring)
            con.Open()
            Try
                Dim query As String
                query = "UPDATE t1 SET t1.tot_dpp = t2.dpp,t1.tot_ppn = t2.ppn,t1.pph = t2.pph,t1.total_dpp_ppn =t2.dpp+t2.ppn+t2.pph-t2.pph " & _
                        "FROM Payment_Header1 as t1 " & _
                        "INNER JOIN (select vrno, SUM(dpp) AS dpp,SUM(ppn) AS ppn,SUM(pph) AS pph " & _
                        "From Payment_Detail1 where cek1=1 group by vrno) as t2 on t2.vrno=t1.vrno "
                mdlmain.ExecQueryByCommand(query)
            Catch ex As Exception
            End Try
        End Using
        tampilalldata_putik()
    End Sub

    Sub updatepph()

        Try
            Dim dtGrid As DataTable = New DataTable
            dtGrid = payment.updatepph()
            _gridshipper2.DataSource = dtGrid
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Catch ex As Exception
            MsgBox(ex.Message)
            If ex.InnerException IsNot Nothing Then
                MsgBox(ex.InnerException)
            End If
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Frm_Payment.Show()
    End Sub

    Private Sub klikgrid()

        Frm_Payment_putik.Show()

        Try
            If _gridshipper2.Rows.Count > 0 Then

                With Frm_Payment_putik
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
                    ._debit_bank.Text = _gridshipper2.SelectedRows(0).Cells(9).Value.ToString() - _gridshipper2.SelectedRows(0).Cells(10).Value.ToString() - _gridshipper2.SelectedRows(0).Cells(12).Value.ToString() - _gridshipper2.SelectedRows(0).Cells(11).Value.ToString()
                    .Button2.Enabled = True
                    ._Tot_Voucher.Text = Format(Val(Frm_Payment_putik._Tot_Voucher.Text), "#,#.##")
                    ._Tot_Ppn.Text = Format(Val(Frm_Payment_putik._Tot_Ppn.Text), "#,#.##")
                    ._Tot_Dpp_Invoice.Text = Format(Val(Frm_Payment_putik._Tot_Dpp_Invoice.Text), "#,#.##")
                    ._Tot_Pph.Text = Format(Val(Frm_Payment_putik._Tot_Pph.Text), "#,#.##")
                    ._debit_bank.Text = Format(Val(Frm_Payment_putik._debit_bank.Text), "#,#.##")


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
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If e.ColumnIndex = 5 Then
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If e.ColumnIndex = 4 Then
            If _gridshipper2.SelectedRows(0).Cells(4).Value = True Then
                _gridshipper2.SelectedRows(0).Cells(4).Value = False
                Try
                    klikgrid()
                    'Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                _gridshipper2.SelectedRows(0).Cells(4).Value = True
            End If
        End If

        Try
            Dim cek1, cek2 As String
            For i As Integer = 0 To Me._gridshipper2.Rows.Count
                cek1 = Me._gridshipper2.Rows(i).Cells(15).ReadOnly = True
                cek2 = Me._gridshipper2.Rows(i).Cells(16).ReadOnly = True
            Next
        Catch ex As Exception
            ''Throw
        End Try
        ''Me.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        tampildata2()
    End Sub

    Sub tampildata2_putik()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3b_putik()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

                'If user1 = "putik" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next
                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "maria" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    chk3.ReadOnly = True
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "yamada" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'Else
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(19).Value = True
                '        _gridshipper2.Rows(i).Cells(19).Value = True
                '        chk3.Selected = True
                '        chk3.ReadOnly = True
                '    Next
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80

                'End If
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampildata2()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3b()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

                'If user1 = "putik" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next
                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "maria" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    chk3.ReadOnly = True
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'ElseIf user1 = "yamada" Then
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80

                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80
                '    chk4.ReadOnly = True
                'Else
                '    Dim chk As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk)

                '    chk.HeaderText = "CHECK 1"
                '    chk.Name = "chk"
                '    chk.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(17).Value = True
                '        _gridshipper2.Rows(i).Cells(17).Value = True
                '        chk.Selected = True
                '        chk.ReadOnly = True
                '    Next

                '    Dim chk2 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk2)

                '    chk2.HeaderText = "CHECK 2"
                '    chk2.Name = "chk2"
                '    chk2.Width = 80

                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(18).Value = True
                '        _gridshipper2.Rows(i).Cells(18).Value = True
                '        chk2.Selected = True
                '        chk2.ReadOnly = True
                '    Next

                '    Dim chk3 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk3)

                '    chk3.HeaderText = "CHECK 3"
                '    chk3.Name = "chk3"
                '    chk3.Width = 80
                '    For i As Integer = 0 To _gridshipper2.Rows.Count() - 1
                '        Dim c As Boolean
                '        c = _gridshipper2.Rows(i).Cells(19).Value = True
                '        _gridshipper2.Rows(i).Cells(19).Value = True
                '        chk3.Selected = True
                '        chk3.ReadOnly = True
                '    Next
                '    Dim chk4 As New DataGridViewCheckBoxColumn()
                '    _gridshipper2.Columns.Add(chk4)

                '    chk4.HeaderText = "DIREKTUR"
                '    chk4.Name = "chk4"
                '    chk4.Width = 80

                'End If
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Text = "VOUCHER LIST - " & user1
        ''Label4.Text = user1
        ''updatepph()
        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        Using con As New SqlConnection(constring)
            con.Open()
            Try
                Dim query As String
                query = "UPDATE t1 SET t1.tot_dpp = t2.dpp,t1.tot_ppn = t2.ppn,t1.pph = t2.pph,t1.total_dpp_ppn =t2.dpp+t2.ppn+t2.pph-t2.pph " & _
                        "FROM Payment_Header1 as t1 " & _
                        "INNER JOIN (select vrno, SUM(dpp) AS dpp,SUM(ppn) AS ppn,SUM(pph) AS pph " & _
                        "From Payment_Detail1 where cek1=1 group by vrno) as t2 on t2.vrno=t1.vrno "
                mdlmain.ExecQueryByCommand(query)
            Catch ex As Exception
            End Try
        End Using
        tampilalldata_putik()
    End Sub

    Sub tampilalldata_putik()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3_putik()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilalldata()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldata3()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then

                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tampildata2_putik()
        ''updatepph()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        tampiltglandsupplier()
        ''updatepph()
    End Sub

    Sub tampiltglandsupplier_putik()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatatglandsupplier_putik()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "Vocher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampiltglandsupplier()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatatglandsupplier()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "Vocher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub _Vend_Name1_DropDown1(sender As Object, e As EventArgs) Handles _Vend_Name1.DropDown
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = fp.supplier()
            _Vend_Name1.DataSource = dtgrid
            _Vend_Name1.ValueMember = "Name"
            _Vend_Name1.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub _Vend_Name_DropDown1(sender As Object, e As EventArgs)
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

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        tampilvrno()
    End Sub

    Sub tampilvrno()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatavrno()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "Vocher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        tampilsupplier()
    End Sub

    Sub tampilsupplier()
        _gridshipper2.AllowUserToAddRows = False

        Try
            'Dim dtgrid As DataTable = New DataTable
            'dtgrid = payment.getalldata3()
            '_gridshipper2.DataSource = dtgrid
            '_gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            ''vrno,tgl,BankID,BankName,VendID,VendorName,Descr,Tot_DPP,Tot_PPN,Total_DPP_PPN,PPh,Biaya_Transfer,CM_DM,CuryID,cek1,cek2,cek3,cek4 
            _gridshipper2.Refresh()
            _gridshipper2.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatasupplier()
            _gridshipper2.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            _gridshipper2.DataSource = bSource
            _gridshipper2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If _gridshipper2.Rows.Count > 0 Then
                _gridshipper2.Columns(0).HeaderText = "Voucher No."
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

                Dim rect As Rectangle = _gridshipper2.GetCellDisplayRectangle(17, -1, True)
                ' set checkbox header to center of header cell. +1 pixel to position 
                rect.Y = 3
                rect.X = rect.Location.X + 40 + (rect.Width / 4)
                Dim checkboxHeadercek3 = New CheckBox()
                With checkboxHeadercek3
                    .BackColor = Color.Transparent
                End With
                checkboxHeadercek3.Name = "checkboxHeader3"
                checkboxHeadercek3.Size = New Size(18, 18)
                checkboxHeadercek3.Location = rect.Location
                AddHandler checkboxHeadercek3.CheckedChanged, AddressOf checkboxHeadercek3_CheckedChanged
                _gridshipper2.Controls.Add(checkboxHeadercek3)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim constring As String = "Data Source=10.10.1.10;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
        Using con As New SqlConnection(constring)

            con.Open()
            Try
                Dim query As String
                Dim cek3, vrno As String
                For i As Integer = 0 To Me._gridshipper2.Rows.Count
                    cek3 = Me._gridshipper2.Rows(i).Cells(17).Value
                    vrno = Me._gridshipper2.Rows(i).Cells(0).Value.ToString
                    query = "update payment_header1 set cek3='" & cek3 & "' where vrno='" & vrno & "' "
                    mdlmain.ExecQueryByCommand(query)

                    'Dim bit As String
                    'bit = DataGridView1.SelectedCells(7).Value

                Next
            Catch ex As Exception
                ''Throw
            End Try

        End Using

        MessageBox.Show("Data Updated.")
        _gridshipper2.Columns.Clear()
        _gridshipper2.Refresh()
        tampildata()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        updatepph()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        updatepph()
    End Sub
End Class