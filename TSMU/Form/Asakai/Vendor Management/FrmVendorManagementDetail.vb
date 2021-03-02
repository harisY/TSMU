Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class FrmVendorManagementDetail
    Private dt As DataTable
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjVMProblemDetail As New VMProblemDetailModel
    Dim KodeTrans As String = ""
    Dim fc_Class As New VendorManagementModel
    Dim GridDtl As GridControl



    Dim _Tag As TagModel


    Dim SimpanFoto As String = "\\srv12\Asakai\Foto\"
    'Dim SimpanFoto As String = "D:\@KERJA\Project\Foto"
    Dim PathFoto As String = ""
    Dim NamaFile As String = ""
    Dim DirectoryFoto As String = ""
    Dim extension As String = ""
    Dim fileSavePath As String = ""
    Dim opfImage As New OpenFileDialog


    Private Sub FrmVendorManagementDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt = New DataTable
        dt.Columns.Add("Shift")
        dt.Columns.Add("Keterangan")
        dt.Columns.Add("Subcount")
        dt.Columns.Add("Kode Barang")
        dt.Columns.Add("Nama Barang")
        dt.Columns.Add("Type")
        dt.Columns.Add("Qty")
        dt.Columns.Add("Problem")
        dt.Columns.Add("Analisis")
        dt.Columns.Add("Correction Action")
        dt.Columns.Add("Preventive Action")
        dt.Columns.Add("Pic")
        dt.Columns.Add("Target")
        dt.Columns.Add("Gambar")
        dt.Columns.Add("Lot No")
        dt.Columns.Add("Path")
        dt.Columns.Add("Gambar Hapus")
        dt.Columns.Add("Status")

        Grid.DataSource = dt
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()



    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Vendor Management Problem " & fs_Code
            Else
                Me.Text = "Vendor Management Problem"
            End If
            Call TextBoxLoad()
            Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmQualityProblem"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try



        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGridProblem As New DataTable
                dtGridProblem = fc_Class.GetDataDetailVMProblem(fs_Code)
                Grid.DataSource = dtGridProblem
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub TextBoxLoad()

        If fs_Code <> "" Then
            DtTanggalLaporan.EditValue = fc_Class.H_Tanggal
        Else
            DtTanggalLaporan.EditValue = Date.Now
        End If

        TxtStatus.EditValue = ""
        TxtKeterangan.EditValue = ""
        TxtSubcount.EditValue = ""
        TxtInvtID.EditValue = ""
        TxtInvtName.EditValue = ""
        TxtType.EditValue = ""
        TxtQty.EditValue = "0"
        TxtProblem.EditValue = ""
        TxtAnalisis.EditValue = ""
        TxtCorrection.EditValue = ""
        TxtPreventive.EditValue = ""
        TxtPic.EditValue = ""
        TxtLotNo.EditValue = ""
        TxtStatus.EditValue = "Open"
        CmbShift.EditValue = "-"


        'DtTanggalLaporan.EditValue = Date.Now
        DtTarget.EditValue = Date.Now
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
           ByVal strCode2 As String,
              ByRef lf_FormParent As Form,
              ByVal li_GridRow As Integer,
              ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub BGambar_Click(sender As Object, e As EventArgs) Handles BGambar.Click

        opfImage.Filter = "Choose Image(*.jpg;*.png;*.gif;*.Jpeg)|*.jpg;*.png;*.gif;*.Jpeg"

        Dim a As String = "D:\@KERJA\Project\Foto\"

        If opfImage.ShowDialog = DialogResult.OK Then

            Dim Tanggal As String = Convert.ToString(Format(Date.Now, "yyyy-MM-dd"))
            PictureBox1.Image = Image.FromFile(opfImage.FileName)

            Dim NewSize As New Size(600, 400)
            Dim Resize As Image = New Bitmap(PictureBox1.Image, NewSize)
            PictureBox1.Image = Resize


            PathFoto = opfImage.FileName
            Dim extension As String = IO.Path.GetExtension(PathFoto)
            NamaFile = Tanggal & "_VM_" + IO.Path.GetRandomFileName() + extension
            fileSavePath = IO.Path.Combine(SimpanFoto, NamaFile)

            'File.Copy(opfImage.FileName, fileSavePath, True)

            Dim i As Image = PictureBox1.Image
            Dim i2 As Image = New Bitmap(i)
            i2.Save(SimpanFoto & NamaFile, System.Drawing.Imaging.ImageFormat.Jpeg)

        End If

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

        Try

            If TxtKeterangan.EditValue = "" Then
                MessageBox.Show("Keterangan Jangan Kosong",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtSubcount.EditValue = "" Then
                MessageBox.Show("Customer Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf TxtPic.EditValue = "" Then
                MessageBox.Show("Pic Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtID.EditValue = "" Then
                MessageBox.Show("Part No Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtInvtName.EditValue = "" Then
                MessageBox.Show("Part Name Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtQty.EditValue = "" Then
                MessageBox.Show("Qty Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtType.EditValue = "" Then
                MessageBox.Show("Pilih Tipe",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf CmbShift.EditValue = "" Then

                MessageBox.Show("Pilih Shift",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtLotNo.EditValue = "" Then

                MessageBox.Show("Isi Lot",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtProblem.EditValue = "" Then
                MessageBox.Show("Problem Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtAnalisis.EditValue = "" Then
                MessageBox.Show("Analisi Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtCorrection.EditValue = "" Then
                MessageBox.Show("Correction Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtPreventive.EditValue = "" Then
                MessageBox.Show("Preventive Harus di isi",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            ElseIf TxtStatus.EditValue = "" Then
                MessageBox.Show("Status Harus di isi",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf NamaFile = "" Then
                MessageBox.Show("Pilih Gambar",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)

            ElseIf PathFoto = "" Then
                MessageBox.Show("Pilih Gambar",
                                   "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
            Else
                GridView1.AddNewRow()
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Shift, CmbShift.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Keterangan, TxtKeterangan.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Subcount, TxtSubcount.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, KodeBarang, TxtInvtID.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, NamaBarang, TxtInvtName.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Type, TxtType.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Qty, TxtQty.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Problem, TxtProblem.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Analisis, TxtAnalisis.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, CorrectionAction, TxtCorrection.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PreventiveAction, TxtPreventive.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Pic, TxtPic.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, LotNo, TxtLotNo.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Target, DtTarget.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Gambar, NamaFile)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Status, TxtStatus.EditValue)
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Path, PathFoto)
                GridView1.UpdateCurrentRow()
                'File.Copy(opfImage.FileName, fileSavePath, True)
                Call TextBoxLoad()
                PictureBox1.Image = Nothing

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub TxtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtQty.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If

    End Sub


    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub getdataview1()
        Try
            Dim IsEmpty As Boolean = False

            If GridView1.RowCount = 0 Then

                MessageBox.Show("Belum Melakukan Inputan", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                For i As Integer = 0 To GridView1.RowCount - 1
                    GridView1.MoveFirst()
                    If GridView1.GetRowCellValue(i, GridView1.Columns(0)).ToString = "" Then
                        IsEmpty = True
                        MessageBox.Show("Pastikan Data Tidak ada yang kosong", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                    End If
                Next
            End If

            If isUpdate = False Then
                fc_Class.GetIDTransAuto()
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.EditValue, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailVMProblem.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjVMProblemDetail = New VMProblemDetailModel
                    With ObjVMProblemDetail
                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DtTanggalLaporan.EditValue, "yyyy-MM-dd")
                        .D_Shift = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Shift")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Shift")))
                        .D_Keterangan = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan")))
                        .D_Subcount = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Subcount")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Subcount")))
                        .D_InvtId = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Kode Barang")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Kode Barang")))
                        .D_InvtName = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Nama Barang")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Nama Barang")))
                        .D_Type = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Type")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Type")))
                        .D_Qty = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Qty")) Is Nothing, 0, Convert.ToString(GridView1.GetRowCellValue(i, "Qty")))
                        .D_Gambar = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                        .D_Problem = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Problem")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Problem")))
                        .D_Lot = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Lot No")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Lot No")))
                        .D_Analisis = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Analisis")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Analisis")))
                        .D_CORRECTIVE_ACTION = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action")))
                        .D_PREVENTIVE_ACTION = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action")))
                        .D_Pic = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Pic")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Pic")))
                        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                        .D_Status = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Status")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Status")))


                    End With
                    fc_Class.ObjDetailVMProblem.Add(ObjVMProblemDetail)


                    fileSavePath = IO.Path.Combine(SimpanFoto, Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                    File.Copy(Convert.ToString(GridView1.GetRowCellValue(i, "Path")), fileSavePath, True)



                Next

                fc_Class.InsertVMProblem(KodeTrans)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                KodeTrans = fc_Class.IDTrans
                fc_Class.H_Tanggal = Format(DtTanggalLaporan.EditValue, "yyyy-MM-dd")
                'Insert To ObjDetailMaterial
                fc_Class.ObjDetailVMProblem.Clear()
                For i As Integer = 0 To GridView1.RowCount - 1

                    ObjVMProblemDetail = New VMProblemDetailModel
                    With ObjVMProblemDetail

                        .D_IDTransaksi = KodeTrans
                        .D_Tanggal = Format(DtTanggalLaporan.EditValue, "yyyy-MM-dd")
                        .D_Shift = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Shift")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Shift")))
                        .D_Keterangan = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Keterangan")))
                        .D_Subcount = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Subcount")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Subcount")))
                        .D_InvtId = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Kode Barang")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Kode Barang")))
                        .D_InvtName = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Nama Barang")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Nama Barang")))
                        .D_Type = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Type")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Type")))
                        .D_Qty = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Qty")) Is Nothing, 0, Convert.ToString(GridView1.GetRowCellValue(i, "Qty")))
                        .D_Gambar = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                        .D_Problem = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Problem")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Problem")))
                        .D_Lot = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Lot No")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Lot No")))
                        .D_Analisis = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Analisis")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Analisis")))
                        .D_CORRECTIVE_ACTION = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Correction Action")))
                        .D_PREVENTIVE_ACTION = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Preventive Action")))
                        .D_Pic = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Pic")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Pic")))
                        .D_Target = Convert.ToString(GridView1.GetRowCellValue(i, "Target"))
                        .D_Status = IIf(Convert.ToString(GridView1.GetRowCellValue(i, "Status")) Is Nothing, "", Convert.ToString(GridView1.GetRowCellValue(i, "Status")))

                    End With
                    fc_Class.ObjDetailVMProblem.Add(ObjVMProblemDetail)


                    If Convert.ToString(GridView1.GetRowCellValue(i, "Path")) <> "" And Convert.ToString(GridView1.GetRowCellValue(i, "Gambar Hapus")) <> "" Then

                        File.Delete(SimpanFoto & "/" & Convert.ToString(GridView1.GetRowCellValue(i, "Gambar Hapus")))

                        fileSavePath = IO.Path.Combine(SimpanFoto, Convert.ToString(GridView1.GetRowCellValue(i, "Gambar")))
                        File.Copy(Convert.ToString(GridView1.GetRowCellValue(i, "Path")), fileSavePath, True)
                    End If

                Next
                fc_Class.UpdateData(fs_Code)
                GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub



    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If GridView1.RowCount < 1 Then

                MessageBox.Show("Belum Melakukan Inputan",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Else
                lb_Validated = True

            End If

            If lb_Validated Then
                With fc_Class


                    .H_Tanggal = Format(CDate(Format(DtTanggalLaporan.EditValue, "yyyy-MM-dd")))

                    'If isUpdate = False Then
                    '    .ValidateInsert()
                    'End If

                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated

    End Function

    Private Sub DtTanggalLaporan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtTanggalLaporan.KeyPress
        'Dim tombol As Integer
        'tombol = Asc(e.KeyChar)

        'If Not (tombol = 0) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub DtTarget_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtTarget.KeyPress
        'Dim tombol As Integer
        'tombol = Asc(e.KeyChar)

        'If Not (tombol = 0) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub CmbShift_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbShift.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStatus.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub
End Class
