﻿Public Class Frm_EBudget
    Dim dt As DataTable
    Dim dtStatus As DataTable
    Dim fc_Class As New Cls_eBudget

    Private Sub Frm_EBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim th As Integer = (Date.Now.Year) + 1
        TtahunCreate.Text = th.ToString()

        Call combotahun()
        Call combotahunApprove()
        Call comboAccountApprove()
        ' Call comboSiteApprove()
        Call comboDeptApprove()
        Call Status()

    End Sub

    Private Sub combotahun()

        CTahunOpenBudget.Properties.Items.Clear()
        dt = New DataTable
        dt = fc_Class.GetTahun()
        'CTahunOpenBudget.Properties.Items.Add("ALL")
        For i As Integer = 0 To dt.Rows.Count - 1
            CTahunOpenBudget.Properties.Items.Add(dt.Rows(i).Item(0))
        Next
    End Sub

    Private Sub combotahunApprove()

        'CTahunOpenBudget.Properties.Items.Clear()
        dt = New DataTable
        dt = fc_Class.GetTahunApprove()
        Tahun_Approve.Properties.DataSource = Nothing
        Tahun_Approve.Properties.DataSource = dt
        Tahun_Approve.Properties.ValueMember = "Tahun"
        Tahun_Approve.Properties.DisplayMember = "Tahun"
    End Sub

    Private Sub comboAccountApprove()

        'CTahunOpenBudget.Properties.Items.Clear()
        dt = New DataTable
        dt = fc_Class.GetAccountApprove()
        Account_Approve.Properties.DataSource = Nothing
        Account_Approve.Properties.DataSource = dt
        Account_Approve.Properties.ValueMember = "AcctID"
        Account_Approve.Properties.DisplayMember = "AcctName"

    End Sub

    'Private Sub comboSiteApprove()

    '    'CTahunOpenBudget.Properties.Items.Clear()
    '    dt = New DataTable
    '    dt = fc_Class.GetSiteApprove()
    '    Site_Approve.Properties.DataSource = Nothing
    '    Site_Approve.Properties.DataSource = dt
    '    Site_Approve.Properties.ValueMember = "SiteID"
    '    Site_Approve.Properties.DisplayMember = "SiteID"

    'End Sub
    Private Sub comboDeptApprove()

        'CTahunOpenBudget.Properties.Items.Clear()
        dt = New DataTable
        dt = fc_Class.GetDeptApprove()
        Dept_Approve.Properties.DataSource = Nothing
        Dept_Approve.Properties.DataSource = dt
        Dept_Approve.Properties.ValueMember = "DeptID"
        Dept_Approve.Properties.DisplayMember = "DeptName"

    End Sub

    Private Sub Status()

        dt = New DataTable
        dt = fc_Class.GetStatus()
        If dt.Rows.Count > 0 Then
            LTahun.Text = dt.Rows(0).Item("Tahun")
            LSemester.Text = dt.Rows(0).Item("Semester")
            LStatus.Text = dt.Rows(0).Item("Status")
        Else
            LTahun.Text = "-"
            LSemester.Text = "-"
            LStatus.Text = "-"
        End If

    End Sub

    Private Sub TtahunCreate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TtahunCreate.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CTahunOpenBudget_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CTahunOpenBudget.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CSemester_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CSemester.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BCreate_Click(sender As Object, e As EventArgs) Handles BCreate.Click
        Dim Tahun_Copy As String
        Dim Tahun_Create As String
        If TtahunCreate.Text = "" Then
            Tahun_Copy = Date.Now.Year()
            Tahun_Create = (Date.Now.Year()) + 1
        Else
            Tahun_Copy = Val(TtahunCreate.Text) - 1
            Tahun_Create = Trim(TtahunCreate.Text)
        End If

        dt = New DataTable
        dt = fc_Class.CekTahun(Tahun_Create)
        If dt.Rows.Count > 0 Then
            MessageBox.Show("Data sudah Di Copy Sebelumnya",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
        Else

            Dim konfirmasi = MsgBox("Apakah Budget '" & Tahun_Create & "' akan di Create?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                Dim a As Boolean = False
                fc_Class.CopyBudget(Tahun_Copy, Tahun_Create)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                'If a = True Then
                '    MessageBox.Show("Create Budget Sukses",
                '              "Informasi",
                '              MessageBoxButtons.OK,
                '              MessageBoxIcon.Information,
                '              MessageBoxDefaultButton.Button1)

                'Else
                '    MessageBox.Show("Create Budget Gagal!",
                '              "Warning",
                '              MessageBoxButtons.OK,
                '              MessageBoxIcon.Exclamation,
                '              MessageBoxDefaultButton.Button1)
                'End If

            End If



        End If

        Call combotahun()
        Call Status()


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Dim a As Boolean = False
        Dim konfirmasi = MsgBox("Apakah Budget akan di Tutup?", vbQuestion + vbYesNo, "Konfirmasi")
        If konfirmasi = vbYes Then
            a = fc_Class.Close_Budget()
            If a = True Then
                MessageBox.Show("Budget Sukses di tutup",
                              "Informasi",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1)

            Else
                MessageBox.Show("Budget Gagal di tutup!",
                              "Warning",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning,
                              MessageBoxDefaultButton.Button1)
            End If
        End If
        Call Status()

    End Sub

    Private Sub BOpen_Click(sender As Object, e As EventArgs) Handles BOpen.Click

        If CTahunOpenBudget.Text = "" Or CSemester.Text = "" Then
            MessageBox.Show("Periksa Tahun dan semester",
                              "Validasi",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning,
                              MessageBoxDefaultButton.Button1)
        Else
            If CSemester.Text = 2 Then
                Dim cek As Boolean = fc_Class.CekBackup(CTahunOpenBudget.Text)

                If cek = True Then
                    Dim tanya = MsgBox("Backup Budget tahun '" & CTahunOpenBudget.Text & "' Semster 1 sudah ada, apakah akan di timpah", vbQuestion + vbYesNo, "Konfirmasi")
                    If tanya = vbYes Then
                        fc_Class.BackupSemester1(CTahunOpenBudget.Text)
                    End If
                Else
                    fc_Class.BackupSemester1(CTahunOpenBudget.Text)
                End If
            End If

            Dim a As Boolean = False
            Dim konfirmasi = MsgBox("Apakah Budget akan di Buka?", vbQuestion + vbYesNo, "Konfirmasi")
            If konfirmasi = vbYes Then
                a = fc_Class.Open_Budget(CTahunOpenBudget.Text, CSemester.Text, "Open")
                If a = True Then
                    MessageBox.Show("Budget Sukses di Buka",
                                      "Informasi",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information,
                                      MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Budget Gagal!",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning,
                                      MessageBoxDefaultButton.Button1)
                End If
            End If
            Call Status()

        End If

    End Sub

    Private Sub C_Dept_EditValueChanged(sender As Object, e As EventArgs) Handles Dept_Approve.EditValueChanged

    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click



        If Tahun_Approve.EditValue = "" Or Persen_Approve.EditValue = "" Then
            MessageBox.Show("Periksa Tahun atau Persen ",
                                     "Waning",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button1)
        Else
            Dim A As Double = 0
            A = Convert.ToDouble(Persen_Approve.EditValue)
            If A > 100 Then
                MessageBox.Show("Nilai Persen Tidak Boleh Lebih dari 100 ",
                                     "Waning",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button1)
            Else
                fc_Class.ApproveBOD(Tahun_Approve.EditValue, Semester_Approve.EditValue, Dept_Approve.EditValue, Account_Approve.EditValue, Site_Approve.EditValue, Convert.ToDouble(Persen_Approve.EditValue))
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If

        End If

    End Sub

    Private Sub tpersenApprove_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Persen_Approve.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13) Or (tombol = 46)) Then
            e.Handled = True
        End If



    End Sub

    Private Sub tpersenApprove_EditValueChanged(sender As Object, e As EventArgs) Handles Persen_Approve.EditValueChanged



    End Sub

    Private Sub Site_Approve_EditValueChanged(sender As Object, e As EventArgs) Handles Site_Approve.EditValueChanged

    End Sub
End Class
