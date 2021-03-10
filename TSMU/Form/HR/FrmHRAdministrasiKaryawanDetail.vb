Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports System.IO

Public Class FrmHRAdministrasiKaryawanDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim srvHR As New HRPAService
    Dim modelHeader As HRPAHeaderModel
    Dim dtGridDetail As DataTable
    Dim GridDtl As GridControl
    Dim dataRow As DataRow

    Dim frm_DataPribadi As FrmHRPADataPribadi
    Dim frm_DataKaryawan As FrmHRPADataKaryawan
    Dim frm_DataAlamat As FrmHRPADataAlamat
    Dim frm_DataKeluarga As FrmHRPADataKeluarga

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal li_GridRow As Integer,
                   ByRef lf_FormParent As Form,
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

    Private Sub FrmHRAdministrasiKaryawanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelHeader = New HRPAHeaderModel
                modelHeader = srvHR.GetDataKaryawanByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "KARYAWAN DETAIL"
            Else
                Me.Text = "NEW KARYAWAN"
            End If
            Call LoadTxtBox()
            LoadGridDataPribadi()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHRAdministrasiKaryawan"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With modelHeader
                    'If .Gambar IsNot Nothing Then
                    '    Dim tmpData As Byte()
                    '    tmpData = CType(.Gambar, Byte())
                    '    Dim ms As New MemoryStream(tmpData)
                    '    PictureFoto.Image = Image.FromStream(ms)
                    'End If
                    pictureFoto.Image = Image.FromFile("D:\Project\Takagi\Desain\HR\Foto\Agung.jpg")
                    txtNIK.Text = .NIK
                    txtNamaLengkap.Text = .NamaLengkap
                    txtJenisKelamin.Text = .JenisKelamin
                    txtFactory.Text = .Factory
                    dtTglLahir.EditValue = .TglLahir
                    txtStatus.Text = .StatusKaryawan
                    txtTipe.Text = .TipeKaryawan
                    txtOrganisasi.Text = .Organisasi
                    txtJabatan.Text = .Jabatan
                    cbMasterData.Text = "PRIBADI"
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cbMasterData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMasterData.SelectedIndexChanged
        Call CheckLoadGridMD()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call CheckLoadFormMD(btnAdd.Text)
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        dataRow = GridViewPADetail.GetDataRow(GridViewPADetail.FocusedRowHandle)
        Call CheckLoadFormMD(btnCopy.Text)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        dataRow = GridViewPADetail.GetDataRow(GridViewPADetail.FocusedRowHandle)
        Call CheckLoadFormMD(btnEdit.Text)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'dataRow = GridViewPADetail.GetDataRow(GridViewPADetail.FocusedRowHandle)
        'Call CheckLoadFormMD(btnDelete.Text)
    End Sub

    Private Sub GridPADetail_DoubleClick(sender As Object, e As EventArgs) Handles GridPADetail.DoubleClick
        Dim selectedRows() As Integer = GridViewPADetail.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                dataRow = GridViewPADetail.GetDataRow(rowHandle)
            End If
        Next rowHandle

        If GridViewPADetail.GetSelectedRows.Length > 0 Then
            Call CheckLoadFormMD("View")
        End If
    End Sub

    Private Sub CheckLoadGridMD()
        If cbMasterData.Text = "PRIBADI" Then
            Call LoadGridDataPribadi()
        ElseIf cbMasterData.Text = "KARIR" Then
            Call LoadGridDataKaryawan()
        ElseIf cbMasterData.Text = "ALAMAT" Then
            Call LoadGridDataAlamat()
        ElseIf cbMasterData.Text = "KELUARGA" Then
            Call LoadGridDataKeluarga()
        ElseIf cbMasterData.Text = "PENDIDIKAN" Then
            Call LoadGridDataPendidikan()
        ElseIf cbMasterData.Text = "KOMUNIKASI" Then
            Call LoadGridDataKomunikasi()
        Else
            Try
                GridViewPADetail.Columns.Clear()
                GridPADetail.DataSource = Nothing
            Finally
                GridPADetail.EndUpdate()
            End Try
        End If
    End Sub

    Private Sub CheckLoadFormMD(Action As String)
        If Action <> "Add" And dataRow Is Nothing Then
            MsgBox("Tidak Ada Data Yang Dipilih !", MessageBoxIcon.Information, "Information")
        Else
            If cbMasterData.Text = "PRIBADI" Then
                Call CallFrmDataPribadi(Action, dataRow)
            ElseIf cbMasterData.Text = "KARIR" Then
                Call CallFrmDataKaryawan(Action, dataRow)
            ElseIf cbMasterData.Text = "ALAMAT" Then
                Call CallFrmDataAlamat(Action, dataRow)
            ElseIf cbMasterData.Text = "KELUARGA" Then
                Call CallFrmDataKeluarga(Action, dataRow)
            End If
        End If

    End Sub

#Region "Grid Dynamic Master Data"
    Private Sub LoadGridDataPribadi()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataPribadi(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPINFinger As GridColumn = GridViewPADetail.Columns("PINFinger")
            colPINFinger.Visible = False

            Dim colTglLahir As GridColumn = GridViewPADetail.Columns("TglLahir")
            colTglLahir.DisplayFormat.FormatType = FormatType.DateTime
            colTglLahir.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglKawin As GridColumn = GridViewPADetail.Columns("TglKawin")
            colTglKawin.DisplayFormat.FormatType = FormatType.DateTime
            colTglKawin.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colGambar As GridColumn = GridViewPADetail.Columns("Gambar")
            colGambar.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

    Private Sub LoadGridDataKaryawan()
        GridPADetail.BeginUpdate()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataKaryawan(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPerpindahan As GridColumn = GridViewPADetail.Columns("PerpindahanKaryawan")
            colPerpindahan.Visible = False

            Dim colPerpindahanDes As GridColumn = GridViewPADetail.Columns("PerpindahanDesc")
            colPerpindahanDes.Caption = "Perpindahan"

            Dim colAlasan As GridColumn = GridViewPADetail.Columns("AlasanPindah")
            colAlasan.Visible = False

            Dim colAlasanPindahDesc As GridColumn = GridViewPADetail.Columns("AlasanPindahDesc")
            colAlasanPindahDesc.Caption = "Alasan Pindah"

            Dim colStatus As GridColumn = GridViewPADetail.Columns("StatusKaryawan")
            colStatus.Caption = "Status"

            Dim colTipe As GridColumn = GridViewPADetail.Columns("TipeKaryawan")
            colTipe.Caption = "Tipe"

            'Dim colGol As GridColumn = GridViewPADetail.Columns("Gol")
            'colGol.Visible = False

            Dim colOrg As GridColumn = GridViewPADetail.Columns("OrgID")
            colOrg.Visible = False

            Dim colJab As GridColumn = GridViewPADetail.Columns("JabID")
            colJab.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

    Private Sub LoadGridDataAlamat()
        GridPADetail.BeginUpdate()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataAlamat(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPerpindahan As GridColumn = GridViewPADetail.Columns("Seq")
            colPerpindahan.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

    Private Sub LoadGridDataKeluarga()
        GridPADetail.BeginUpdate()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataKeluarga(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPerpindahan As GridColumn = GridViewPADetail.Columns("Seq")
            colPerpindahan.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

    Private Sub LoadGridDataPendidikan()
        GridPADetail.BeginUpdate()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataPendidikan(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPerpindahan As GridColumn = GridViewPADetail.Columns("Seq")
            colPerpindahan.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

    Private Sub LoadGridDataKomunikasi()
        GridPADetail.BeginUpdate()
        Try
            dtGridDetail = New DataTable
            dtGridDetail = srvHR.GetDataDataKomunikasi(fs_Code)
            GridViewPADetail.Columns.Clear()
            GridPADetail.DataSource = Nothing
            GridPADetail.DataSource = dtGridDetail

            Dim colID As GridColumn = GridViewPADetail.Columns("ID")
            colID.Visible = False

            Dim colTglMulai As GridColumn = GridViewPADetail.Columns("TglMulai")
            colTglMulai.DisplayFormat.FormatType = FormatType.DateTime
            colTglMulai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colTglSelesai As GridColumn = GridViewPADetail.Columns("TglSelesai")
            colTglSelesai.DisplayFormat.FormatType = FormatType.DateTime
            colTglSelesai.DisplayFormat.FormatString = "dd/MM/yyyy"

            Dim colEmpID As GridColumn = GridViewPADetail.Columns("EmployeeID")
            colEmpID.Visible = False

            Dim colPerpindahan As GridColumn = GridViewPADetail.Columns("Seq")
            colPerpindahan.Visible = False

            Dim colTglBuat As GridColumn = GridViewPADetail.Columns("TglBuat")
            colTglBuat.DisplayFormat.FormatType = FormatType.DateTime
            colTglBuat.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            Dim colTglUbah As GridColumn = GridViewPADetail.Columns("TglUbah")
            colTglUbah.DisplayFormat.FormatType = FormatType.DateTime
            colTglUbah.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            GridViewPADetail.BestFitColumns()
        Finally
            GridPADetail.EndUpdate()
        End Try
    End Sub

#End Region

    Private Sub CallFrmDataPribadi(Optional ByVal isAction As String = "", Optional ByVal dataRow As DataRow = Nothing)
        If frm_DataPribadi IsNot Nothing AndAlso frm_DataPribadi.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_DataPribadi.Close()
        End If
        frm_DataPribadi = New FrmHRPADataPribadi(isAction, fs_Code, txtNIK.Text, dataRow, GridPADetail, Me)
        frm_DataPribadi.StartPosition = FormStartPosition.CenterScreen
        frm_DataPribadi.ShowDialog()
        CheckLoadGridMD()
    End Sub

    Private Sub CallFrmDataKaryawan(Optional ByVal isAction As String = "", Optional ByVal dataRow As DataRow = Nothing)
        If frm_DataKaryawan IsNot Nothing AndAlso frm_DataKaryawan.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_DataKaryawan.Close()
        End If
        frm_DataKaryawan = New FrmHRPADataKaryawan(isAction, fs_Code, txtNIK.Text, dataRow, GridPADetail, Me)
        frm_DataKaryawan.StartPosition = FormStartPosition.CenterScreen
        frm_DataKaryawan.ShowDialog()
        CheckLoadGridMD()
    End Sub

    Private Sub CallFrmDataAlamat(Optional ByVal isAction As String = "", Optional ByVal dataRow As DataRow = Nothing)
        If frm_DataAlamat IsNot Nothing AndAlso frm_DataAlamat.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_DataAlamat.Close()
        End If
        frm_DataAlamat = New FrmHRPADataAlamat(isAction, fs_Code, txtNIK.Text, dataRow, GridPADetail, Me)
        frm_DataAlamat.StartPosition = FormStartPosition.CenterScreen
        frm_DataAlamat.ShowDialog()
        CheckLoadGridMD()
    End Sub

    Private Sub CallFrmDataKeluarga(Optional ByVal isAction As String = "", Optional ByVal dataRow As DataRow = Nothing)
        If frm_DataKeluarga IsNot Nothing AndAlso frm_DataKeluarga.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_DataKeluarga.Close()
        End If
        frm_DataKeluarga = New FrmHRPADataKeluarga(isAction, fs_Code, txtNIK.Text, dataRow, GridPADetail, Me)
        frm_DataKeluarga.StartPosition = FormStartPosition.CenterScreen
        frm_DataKeluarga.ShowDialog()
        CheckLoadGridMD()
    End Sub

End Class
