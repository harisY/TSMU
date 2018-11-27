Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_MasterRekening

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
    Private strConn As String = "Data Source=SRV08;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsc2011"
    ' Private strConn As String = "Data Source=MIS09;Initial Catalog=TSC16Application;User ID=sa;pwd=Tsmu2005"
    Private sqlCon As SqlConnection

    Private Sub Frm_MasterRekening_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "MASTER REKENING - " & user1
        DataGridView1.Refresh()
        tampildatarek()
    End Sub


    Sub tampildatarek()
        DataGridView1.AllowUserToAddRows = False

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatarek()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "Vendor ID"
                DataGridView1.Columns(0).Width = 110
                DataGridView1.Columns(1).HeaderText = "Supplier"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).HeaderText = "Detail Supplier"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).HeaderText = "Bank Name"
                DataGridView1.Columns(3).Width = 130
                DataGridView1.Columns(4).HeaderText = "No. Rek. Supplier"
                DataGridView1.Columns(4).Width = 130
                DataGridView1.Columns(5).HeaderText = "CuryID"
                DataGridView1.Columns(5).Width = 50
                ''.Columns(6).Visible = True
                ''DataGridView1.Columns(7).Visible = True

                DataGridView1.Columns.Add(btn)
                btn.HeaderText = ""
                btn.Text = "Edit"
                btn.Name = "edit"
                btn.Width = 50
                btn.UseColumnTextForButtonValue = True


            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampildatarekbyname()
        DataGridView1.AllowUserToAddRows = False

        Try
            DataGridView1.Refresh()
            DataGridView1.Columns.Clear()
            Dim chk As New DataGridViewCheckBoxColumn()
            Dim btn As New DataGridViewButtonColumn()
            Dim btn1 As New DataGridViewButtonColumn()

            Dim dtgrid As DataTable = New DataTable
            dtgrid = payment.getalldatarekbyname()
            DataGridView1.DataSource = dtgrid
            Dim bSource = New BindingSource
            bSource.DataSource = dtgrid
            DataGridView1.DataSource = bSource
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            If DataGridView1.Rows.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "Vendor ID"
                DataGridView1.Columns(0).Width = 110
                DataGridView1.Columns(1).HeaderText = "Supplier"
                DataGridView1.Columns(1).Width = 200
                DataGridView1.Columns(2).HeaderText = "Detail Supplier"
                DataGridView1.Columns(2).Width = 200
                DataGridView1.Columns(3).HeaderText = "Bank Name"
                DataGridView1.Columns(3).Width = 130
                DataGridView1.Columns(4).HeaderText = "No. Rek. Supplier"
                DataGridView1.Columns(4).Width = 130
                DataGridView1.Columns(5).HeaderText = "CuryID"
                DataGridView1.Columns(5).Width = 50
                ''.Columns(6).Visible = True
                ''DataGridView1.Columns(7).Visible = True

                DataGridView1.Columns.Add(btn)
                btn.HeaderText = ""
                btn.Text = "Edit"
                btn.Name = "edit"
                btn.Width = 50
                btn.UseColumnTextForButtonValue = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampildatarekbyname()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tampildatarek()
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Frm_InputMasterRek.StartPosition = FormStartPosition.CenterScreen
        Frm_InputMasterRek.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 6 Then
            'Frm_EditMasterRek.StartPosition = FormStartPosition.CenterScreen
            'Frm_EditMasterRek.ShowDialog()
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        If e.ColumnIndex = 0 Then
            Try
                klikgrid()
                'Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub klikgrid()
        Frm_EditMasterRek.StartPosition = FormStartPosition.CenterScreen
        Frm_EditMasterRek.Show()
        Try
            If Me.DataGridView1.Rows.Count > 0 Then

                With Frm_EditMasterRek
                    ._VendID.Text = Me.DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                    ._Vend_Name.Text = Me.DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
                    ._detsup.Text = Me.DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
                    ._bank.Text = Me.DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
                    ._norek.Text = Me.DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
                    ._curyid.Text = Me.DataGridView1.SelectedRows(0).Cells(5).Value.ToString()
                End With
            End If
        Catch ex As Exception
            Return
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tampildatarek()
    End Sub
End Class