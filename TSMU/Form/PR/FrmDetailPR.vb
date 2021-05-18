Imports DevExpress.XtraBars.ToastNotifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop
Imports System.Globalization
'Imports AddinExpress.Outlook.SecurityManager
Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class FrmDetailPR

    Dim BudgetAccount As Double
    Dim SisaBudgetAccount As Double

    Dim Grid As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Int32 = 0
    Dim PRNo As String = ""
    Dim indicatorIcon As Boolean = True
    Dim DtGrid As DataTable
    Dim fc_Class As New Cls_PR
    Dim fc_Class_Detail As New Cls_PR_Detail
    Dim DeptID As String = ""
    Dim isUpdate As Boolean = False
    Dim SubAccountDept As String = ""
    Dim LastPR As String = ""
    Dim LastPRDate As Date
    Public IsClosed As Boolean = False
    Dim GridDtl As GridControl
    Dim AktualPemakaian As Double
    Dim dtUntukBagian As DataTable


    Public Class ContactList
        Inherits System.Collections.CollectionBase

        Default Public Property Item(ByVal index As Integer) As Contact
            Get
                Return DirectCast(List(index), Contact)
            End Get
            Set(ByVal value As Contact)
                List(index) = value
            End Set
        End Property

        Public Function Add(ByVal value As Contact) As Integer
            Return List.Add(value)
        End Function
        '...
    End Class

    Private Sub List_UntukBagian()


        dtUntukBagian = New DataTable
        dtUntukBagian = fc_Class.Get_UntuBagian()

        Dim cList As New ContactList()

        For i As Integer = 0 To dtUntukBagian.Rows.Count - 1
            cList.Add(New Contact(dtUntukBagian.Rows(i).Item(0), dtUntukBagian.Rows(i).Item(1)))
        Next
        'cList.Add(New Contact("OR", "Reguler Order"))
        'cList.Add(New Contact("DP", "Drop Ship"))
        'cList.Add(New Contact("BL", "Blanket Order"))
        'cList.Add(New Contact("St", "Standard Order"))

        'bind the lookup editor to the list
        TBagian.Properties.DataSource = cList
        TBagian.Properties.DisplayMember = "Name"
        TBagian.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        TBagian.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        TBagian.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        TBagian.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub

    Public Class Contact
        'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private name_Renamed As String
        'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private id_Renamed As String

        Public Sub New(ByVal _id As String, ByVal _name As String)
            id_Renamed = _id
            name_Renamed = _name
        End Sub



        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As String)
                id_Renamed = value
            End Set
        End Property
    End Class



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl,
                   ByRef _Active_Form As Integer)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        Grid = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
        Active_Form = _Active_Form
        PRNo = strCode
    End Sub

    Private Sub CreateTable()

        DtGrid = New DataTable
        DtGrid.Columns.AddRange(New DataColumn(17) {New DataColumn("No", GetType(String)),
                                                            New DataColumn("XSeq", GetType(Int16)),
                                                            New DataColumn("Pembelian Untuk", GetType(String)),
                                                            New DataColumn("Kode Barang", GetType(String)),
                                                            New DataColumn("Nama Barang", GetType(String)),
                                                            New DataColumn("Spesifikasi", GetType(String)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("Sub Account", GetType(String)),
                                                            New DataColumn("Jumlah", GetType(Double)),
                                                            New DataColumn("Harga", GetType(Double)),
                                                            New DataColumn("Total", GetType(Double)),
                                                            New DataColumn("Budget", GetType(Double)),
                                                            New DataColumn("Sudah Dipakai", GetType(Double)),
                                                            New DataColumn("Satuan", GetType(String)),
                                                            New DataColumn("Digunakan Untuk", GetType(String)),
                                                            New DataColumn("Waktu Tempo", GetType(Date)),
                                                            New DataColumn("Keterangan", GetType(String)),
                                                            New DataColumn("Circulation", GetType(String))})
        GridPR.DataSource = DtGrid
        GridView3.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub FrmDetailPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load, TSirkulasi.DoubleClick

        Call List_UntukBagian()
        Me.T_SirkulasiJumlah.Properties.Mask.EditMask = "n0"
        Me.T_SirkulasiJumlah.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.T_SirkulasiJumlah.Properties.Mask.UseMaskAsDisplayFormat = True

        Me.TJumlahProses.Properties.Mask.EditMask = "n0"
        Me.TJumlahProses.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TJumlahProses.Properties.Mask.UseMaskAsDisplayFormat = True

        Call CreateTable()
        Call FillComboPembelianUntuk()
        Call InitialSetForm()




    End Sub

    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            Dim dt As New DataTable
            dt = fc_Class.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Departemen Tidak Ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                SubAccountDept = Trim((dt.Rows(0).Item("Sub")))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub Get_LastPR(Account As String)
        Try

            Dim dt As New DataTable
            dt = fc_Class.Get_LastPR(Account)
            If dt.Rows.Count <= 0 Then
                LastPR = ""
                LastPRDate = Date.Now
            Else
                LastPR = Trim((dt.Rows(0).Item("PRNo")))
                LastPRDate = Trim((dt.Rows(0).Item("PRDate")))
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub FillComboPembelianUntuk()
        Try
            Dim dt As New DataTable
            dt = fc_Class.GetPembelianUntuk
            'CPembelianUntuk.DataSource = dt

            CPembelianUntuk.DataSource = Nothing
            CPembelianUntuk.DataSource = dt
            CPembelianUntuk.ValueMember = "Value"
            CPembelianUntuk.DisplayMember = "Name"

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub BTambahBaris_Click(sender As Object, e As EventArgs) Handles BTambahBaris.Click

        ' GridView3.MoveFirst()
        GridView3.PostEditor()
        GridView3.UpdateCurrentRow()

        Dim a As Integer = 1
        a = a + GridView3.RowCount
        Dim b As Integer = GridView3.Columns("XSeq").SummaryItem.SummaryValue
        b = b + 1
        GridView3.AddNewRow()

        GridView3.OptionsNavigation.AutoFocusNewRow = True
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, No, a)
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, XSeq, b)
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Jumlah, 0)
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Harga, 0)
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Total, 0)






        'GridView3.SetRowCellValue(GridView3.FocusedRowHandle, PembelianUntuk, a)
    End Sub


    Private Sub CPembelianUntuk_EditValueChanged(sender As Object, e As EventArgs) Handles CPembelianUntuk.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))

        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, KodeBarang, "")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, NamaBarang, "")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Accountt, "")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Satuan, "")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo, Nothing)
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, "")
    End Sub

    Private Sub GridPR_KeyDown(sender As Object, e As KeyEventArgs) Handles GridPR.KeyDown
        'If Active_Form = 1 Or Active_Form = 5 Then
        If e.KeyData = Keys.Delete Then
            GridView3.DeleteRow(GridView3.FocusedRowHandle)
            GridView3.RefreshData()

        End If

        For i As Integer = 0 To GridView3.RowCount - 1

            'GridView3.GetRowCellValue(i, GridView3.Columns("No")) = i.ToString()

            GridView3.SetRowCellValue(i, No, i + 1)

        Next
        'End If

    End Sub

    Private Sub BBarang_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BBarang.ButtonClick

        Try
            fc_Class = New Cls_PR
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            DeptID = gh_Common.GroupID
            Dim Param As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, PembelianUntuk)


            'Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            'Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

            dtSearch = fc_Class.GetBarang(Param, SubAccountDept, TSirkulasi.EditValue)
            ''ls_OldKode = T_Account.Text
            ls_Judul = "Barang"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Pilih  " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            Dim Value4 As String = ""

            If lF_SearchData.Values IsNot Nothing Then 'AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode 
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                Value4 = lF_SearchData.Values.Item(3).ToString.Trim

                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, KodeBarang, Value1)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, NamaBarang, Value2)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Accountt, Value3)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Satuan, Value4)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo, "")
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, "")
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, GBudget, 0)

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Public Overrides Sub InitialSetForm()


        If fs_Code <> "" Then
            isUpdate = True
            fc_Class.GetDataByID(fs_Code)
            Call LoadTextEdit()
            Call LoadGridBarang(fs_Code)

            If fc_Class.H_StatusFlag = "" Or fc_Class.H_StatusFlag = "P" Then
                Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False)
            Else
                Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
            End If
            Call Sub_Dept(TBagian.EditValue)
            TBagian.Enabled = False

        Else
            'fc_Class.GetNoPRAuto(gh_Common.GroupID)
            TTanggal.EditValue = Date.Now
            'TBagian.EditValue = gh_Common.GroupID
            TNoPR.EditValue = ""
            Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False)
            ' bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString()
            Call Sub_Dept(gh_Common.GroupID.ToString())
            TBagian.EditValue = gh_Common.GroupID

        End If
        Me.Text = "PR FORM"
        bb_IsUpdate = isUpdate
        bs_MainFormName = FrmParent.Name.ToString()


    End Sub

    Private Sub LoadGridBarang(PRNo As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                DtGrid = fc_Class.GetDetail(PRNo)
                GridPR.DataSource = DtGrid
                Cursor.Current = Cursors.Default
                'Call TotalSumary()
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub LoadTextEdit()
        If fs_Code <> "" Then
            With fc_Class
                TNoPR.EditValue = .H_PRNo
                'TBagian.EditValue = .H_PRNo.Substring(0, 4)
                TTanggal.EditValue = .H_PRDate
                TSirkulasi.EditValue = IIf(.H_Sirkulasi Is DBNull.Value, "", .H_Sirkulasi)
                'TKeterangan.EditValue = IIf(.H_Remark Is DBNull.Value, "", .H_Remark)
                TRevisi.EditValue = .H_SeqRev
                TBagian.EditValue = .H_ForDept

            End With
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

        Dim IsEmpty As Boolean = False

        If GridView3.RowCount = 0 Then

            MessageBox.Show("Belum Menambahkan Item PR ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            Exit Sub

        Else

            For i As Integer = 0 To GridView3.RowCount - 1
                GridView3.MoveFirst()
                GridView3.PostEditor()
                GridView3.UpdateCurrentRow()
                Dim cekPembelian As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Pembelian Untuk")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Pembelian Untuk")))
                Dim cekKodeBarang As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Kode Barang")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Kode Barang")))
                Dim cekWaktuTempo As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Waktu Tempo")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Waktu Tempo")))
                Dim cekHarga As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Harga")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Harga")))
                Dim cekJumlah As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Jumlah")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Jumlah")))
                Dim cekSubAccount As String = IIf(GridView3.GetRowCellValue(i, GridView3.Columns("Sub Account")) Is DBNull.Value, "", GridView3.GetRowCellValue(i, GridView3.Columns("Sub Account")))
                If cekPembelian = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Pembelian Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf cekKodeBarang = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Kode Barang Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub



                ElseIf cekWaktuTempo = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Waktu Tempo Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf cekSubAccount = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Sub Account Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf cekHarga = "" Or cekHarga = "0" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Harga Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf cekJumlah = "" Or cekJumlah = "0" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Jumlah Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub


                End If
            Next


        End If


        fc_Class.GetNoPRAuto(TBagian.EditValue)

        With fc_Class

            .H_Sirkulasi = IIf(TSirkulasi.EditValue Is DBNull.Value, "", TSirkulasi.EditValue)
            .H_ApprovalDate = Format(Date.Now, "yyyy-MM-dd")
            .H_ApprovalPIC = ""
            .H_ApprovalRemark = ""
            .H_LocId = gh_Common.GroupID.Substring(0, 1)
            .H_LUpd_DateTime = Format(Date.Now, "yyyy-MM-dd")
            .H_LUpd_Prog = "0499910"
            .H_LUpd_User = gh_Common.Username
            .H_PRDate = Format(TTanggal.EditValue, "yyyy-MM-dd")
            '.H_PRNo = TNoPR.EditValue
            .H_Remark = gh_Common.GroupID
            .H_SecId = SubAccountDept.Substring(2, 2)
            .H_SeqRev = TRevisi.EditValue
            .H_StatusFlag = "P"
            .H_CreateBy = gh_Common.Username
            .H_CreateDate = Format(Date.Now, "yyyy-MM-dd")
            .H_UpdateBy = gh_Common.Username
            .H_UpdateDate = Format(Date.Now, "yyyy-MM-dd")
            .H_ForDept = TBagian.EditValue
            .H_DeptCreate = gh_Common.GroupID

        End With

        'Insert To Detail
        fc_Class.Collection_Detail.Clear()
        For i As Integer = 0 To GridView3.RowCount - 1

            Call Get_LastPR(GridView3.GetRowCellValue(i, "Account"))

            fc_Class_Detail = New Cls_PR_Detail
            With fc_Class_Detail

                .D_Acct = GridView3.GetRowCellValue(i, "Account")
                .D_CurrCode = "IDR"
                .D_DelDate = GridView3.GetRowCellValue(i, WaktuTempo)
                .D_InvtDescr = GridView3.GetRowCellValue(i, "Nama Barang")
                .D_InvtId = GridView3.GetRowCellValue(i, "Kode Barang")
                .D_InvtSpec = IIf(GridView3.GetRowCellValue(i, Spesifikasi) Is DBNull.Value, "", GridView3.GetRowCellValue(i, Spesifikasi))
                .D_LastPRNo = LastPR
                .D_LastPRDate = LastPRDate
                .D_LUpd_Datetime = Date.Now
                .D_LUpd_Prog = "0499910"
                .D_LUpd_User = gh_Common.Username
                .D_OverFlag = "N"

                If isUpdate = False Then
                    fc_Class_Detail.D_PRNo = fc_Class.AutoNumber
                Else
                    fc_Class_Detail.D_PRNo = TNoPR.EditValue
                End If

                .D_PurchaseType = GridView3.GetRowCellValue(i, PembelianUntuk)
                .D_Qty = GridView3.GetRowCellValue(i, Jumlah)
                .D_QtyPO = 0
                .D_QtyRcv = 0
                .D_Remark = IIf(GridView3.GetRowCellValue(i, Digunakan) Is DBNull.Value, "", GridView3.GetRowCellValue(i, Digunakan))
                .D_StatusDate = Date.Now
                .D_StatusFlag = "O"
                .D_StkItem = 0
                .D_Sub = GridView3.GetRowCellValue(i, SubAccount)
                .D_UnitPrice = GridView3.GetRowCellValue(i, Harga)
                .D_UnitQty = GridView3.GetRowCellValue(i, Satuan)
                .D_XQty = GridView3.GetRowCellValue(i, Jumlah)
                .D_SeqNo = GridView3.GetRowCellValue(i, No)
                .D_XSeqNo = GridView3.GetRowCellValue(i, XSeq)
                .D_Keterangan = IIf(GridView3.GetRowCellValue(i, Keterangan) Is DBNull.Value, "", GridView3.GetRowCellValue(i, Keterangan))

            End With
            fc_Class.Collection_Detail.Add(fc_Class_Detail)

        Next


        If isUpdate = False Then

            ''''''''''''''''''''''''' Insert''''''''''''''''''''''''''

            fc_Class.H_PRNo = fc_Class.AutoNumber


            fc_Class.Insert()
            bs_Filter = gh_Common.GroupID
            Grid.DataSource = fc_Class.Get_PR(gh_Common.GroupID)
            IsClosed = True
            ' Timer1.Enabled = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()

        Else
            '''''''''''''''''''''''''''''''''''''''''''''''''''''' Update
            fc_Class.H_PRNo = TNoPR.EditValue

            fc_Class.Update(TNoPR.EditValue)
            Grid.DataSource = fc_Class.Get_PR(gh_Common.GroupID)
            IsClosed = True
            ' Timer1.Enabled = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()
        End If

    End Sub

    Private Sub BBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BBarang.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BSubAccount_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BSubAccount.ButtonClick
        Try
            fc_Class = New Cls_PR
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            DeptID = gh_Common.GroupID
            Dim Param As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, PembelianUntuk)


            'Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            'Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

            dtSearch = fc_Class.GetBarang(Param, SubAccountDept, TSirkulasi.EditValue)
            ''ls_OldKode = T_Account.Text
            ls_Judul = "Barang"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Pilih  " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            Dim Value4 As String = ""

            If lF_SearchData.Values IsNot Nothing Then 'AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode 
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                Value4 = lF_SearchData.Values.Item(3).ToString.Trim

                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, KodeBarang, Value1)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, NamaBarang, Value2)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Accountt, Value3)
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Satuan, Value4)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub DTempo_EditValueChanged(sender As Object, e As EventArgs) Handles DTempo.EditValueChanged
        Try

            Dim baseEdit = TryCast(sender, BaseEdit)
            Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
            gridView.PostEditor()
            gridView.UpdateCurrentRow()



            Dim provider As CultureInfo = CultureInfo.InvariantCulture

            fc_Class = New Cls_PR
            Dim ls_Judul As String = ""
            Dim dt As New DataTable
            Dim ls_OldKode As String = ""
            ' DeptID = gh_Common.GroupID
            DeptID = TBagian.EditValue


            Dim Th As Date = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo)
            Dim Tahun As String = (Th.Year).ToString
            Dim Bulan As String = (Th.Month).ToString
            Dim ACCT As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Accountt).ToString()


            If Th < TTanggal.EditValue Then

                MessageBox.Show("Cek Pemilihan Tanggal ", "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Call CekBudget(Tahun, SubAccountDept, ACCT, Bulan)
            End If





            'GridView3.SetRowCellValue(GridView3.FocusedRowHandle, KodeBarang, Value1)


        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CekBudget(Tahun As String, DeptID As String, ACCT As String, bulan As String)
        Dim dtBudget As New DataTable
        dtBudget = fc_Class.GetBudget(Tahun, DeptID, ACCT)

        If dtBudget.Rows.Count <= 0 Then
            BudgetAccount = 0
            MessageBox.Show("Tidak Ada Budget Untuk Barang ini ", "Warning",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation,
                              MessageBoxDefaultButton.Button1)
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, "")
        Else
            If bulan = "1" Then
                BudgetAccount = dtBudget.Rows(0).Item("jan")
            ElseIf bulan = "2" Then
                BudgetAccount = dtBudget.Rows(0).Item("feb")
            ElseIf bulan = "3" Then
                BudgetAccount = dtBudget.Rows(0).Item("mar")
            ElseIf bulan = "4" Then
                BudgetAccount = dtBudget.Rows(0).Item("apr")
            ElseIf bulan = "5" Then
                BudgetAccount = dtBudget.Rows(0).Item("mei")
            ElseIf bulan = "6" Then
                BudgetAccount = dtBudget.Rows(0).Item("jun")
            ElseIf bulan = "7" Then
                BudgetAccount = dtBudget.Rows(0).Item("jul")
            ElseIf bulan = "8" Then
                BudgetAccount = dtBudget.Rows(0).Item("agu")
            ElseIf bulan = "9" Then
                BudgetAccount = dtBudget.Rows(0).Item("sep")
            ElseIf bulan = "10" Then
                BudgetAccount = dtBudget.Rows(0).Item("okt")
            ElseIf bulan = "11" Then
                BudgetAccount = dtBudget.Rows(0).Item("nov")
            ElseIf bulan = "12" Then
                BudgetAccount = dtBudget.Rows(0).Item("des")
            Else
                BudgetAccount = 0
            End If

            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, SubAccountDept)
        End If
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, GBudget, BudgetAccount)


        Dim dtActualBudget As New DataTable
        dtActualBudget = fc_Class.GetActualBudget(Tahun, bulan, SubAccountDept, ACCT, TNoPR.EditValue.ToString())
        If dtActualBudget.Rows.Count <= 0 Then
            AktualPemakaian = 0
        Else
            AktualPemakaian = dtActualBudget.Rows(0).Item("Total")
        End If

        Dim RangeRowIndex As Integer = GridView3.FocusedRowHandle
        If RangeRowIndex = 0 Then
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Sudah Dipakai", AktualPemakaian)
        Else

            Dim Pemakaian As Double = 0
            Dim Thg As Date
            Dim Tahung As String
            Dim Bulang As String
            Dim Acctg As String
            For i As Integer = 0 To RangeRowIndex - 1
                Thg = GridView3.GetRowCellValue(i, WaktuTempo)
                Tahung = (Thg.Year).ToString()
                Bulang = (Thg.Month).ToString()
                Acctg = GridView3.GetRowCellValue(i, Accountt)
                If Acctg = ACCT And Tahung = Tahun And Bulang = bulan Then
                    Pemakaian = Pemakaian + Convert.ToDouble(GridView3.GetRowCellValue(i, GridView3.Columns("Total")))
                End If
            Next

            AktualPemakaian = AktualPemakaian + Pemakaian
            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Sudah Dipakai", AktualPemakaian)
        End If




        'Dim dt As New DataTable
        'dt = fc_Class.GetSubAccount(Tahun, T_UntukBagian.EditValue, ACCT)
        'If dt.Rows.Count > 0 Then
        '    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, dt.Rows(0).Item("Sub"))
        '    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, GBudget, BudgetAccount)
        'Else
        '    MessageBox.Show("Tidak Ada Budget Untuk Barang ini ", "Warning",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Exclamation,
        '                       MessageBoxDefaultButton.Button1)

        '    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, SubAccount, "")
        '    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, GBudget, 0)
        '    Exit Sub
        'End If

    End Sub

    Private Sub RefreshPakai()

        Dim Th As Date
        Dim Tahun As String
        Dim Bulan As String
        Dim ACCT As String

        For i As Integer = 1 To GridView3.RowCount - 1

            Th = GridView3.GetRowCellValue(i, WaktuTempo)
            Tahun = (Th.Year).ToString
            Bulan = (Th.Month).ToString
            ACCT = GridView3.GetRowCellValue(i, Accountt).ToString()

            For j As Integer = 0 To i - 1

            Next
        Next

    End Sub

    Private Sub BNo_EditValueChanged(sender As Object, e As EventArgs) Handles BNo.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))

        gridView.PostEditor()
        gridView.UpdateCurrentRow()

    End Sub

    Private Sub TSirkulasi_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub TSirkulasi_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TSirkulasi.ButtonClick
        Try
            fc_Class = New Cls_PR
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim dtSt As New DataTable
            Dim ls_OldKode As String = ""
            DeptID = gh_Common.GroupID
            Dim tgl As Date = TTanggal.EditValue
            Dim Value1 As String = ""


            'Dim Tahun As String = Convert.ToString(Param.ToString("yyyy"))
            'Dim Bulan As String = Convert.ToString(Param.ToString("MM"))

            dtSearch = fc_Class.GetSirkulasi(tgl, DeptID)
            ''ls_OldKode = T_Account.Text
            ls_Judul = "Sirkulasi"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Pilih  " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()


            If lF_SearchData.Values IsNot Nothing Then 'AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode 
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim

                TSirkulasi.EditValue = Value1
                T_SirkulasiJumlah.EditValue = lF_SearchData.Values.Item(5).ToString.Trim
                TSirkulasi.SelectAll()

            End If

            dtSt = fc_Class.GetSirkulasiSudahPR(Value1, TNoPR.EditValue)
            If dtSt.Rows.Count <= 0 Then
                TJumlahProses.EditValue = "0"
            Else
                TJumlahProses.EditValue = lF_SearchData.Values.Item(5).ToString.Trim - dtSt.Rows(0).Item("Total")
            End If


            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TSirkulasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TSirkulasi.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0) Or (tombol = 8)) Then
            e.Handled = True
        End If

        If tombol = 8 Then
            T_SirkulasiJumlah.EditValue = ""
            TJumlahProses.EditValue = ""
        End If
    End Sub

    Private Sub TSirkulasi_Click(sender As Object, e As EventArgs) Handles TSirkulasi.Click
        TSirkulasi.SelectAll()
    End Sub

    Private Sub CJumlah_EditValueChanged(sender As Object, e As EventArgs) Handles CJumlah.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()



        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()



        Dim provider As CultureInfo = CultureInfo.InvariantCulture

        fc_Class = New Cls_PR
        Dim ls_Judul As String = ""
        Dim dt As New DataTable
        Dim ls_OldKode As String = ""
        ' DeptID = gh_Common.GroupID
        DeptID = TBagian.EditValue


        Dim Th As Date = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo)
        Dim Tahun As String = (Th.Year).ToString
        Dim Bulan As String = (Th.Month).ToString
        Dim ACCT As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Accountt).ToString()
        Call CekBudget(Tahun, SubAccountDept, ACCT, Bulan)

        'If Th < TTanggal.EditValue Then

        '    MessageBox.Show("Cek Pemilihan Tanggal ", "Warning",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Exclamation,
        '                       MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'Else
        '    Call CekBudget(Tahun, DeptID, ACCT, Bulan)
        'End If


        Call HitungTotal()

    End Sub

    Private Sub HitungTotal()
        Try

            Dim BGT As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, GBudget) Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, GBudget))
            Dim Pakai As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, GSudahDipakai) Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, GSudahDipakai))


            Dim Jml As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Jumlah) Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Jumlah))
            Dim Hrg As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Harga) Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Harga))

            GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Total, Jml * Hrg)

            Dim Acc_NoAccount As String = ""

            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    Acc_NoAccount = GridView1.GetRowCellValue(rowHandle, "Account")
                End If
            Next rowHandle

            Dim sisa As Double = BGT - (Pakai + (Jml * Hrg))

            If sisa < 0 Then
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Keterangan, "Over")
            Else
                GridView3.SetRowCellValue(GridView3.FocusedRowHandle, Keterangan, "")
            End If



        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Charga_EditValueChanged(sender As Object, e As EventArgs) Handles Charga.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()



        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()



        Dim provider As CultureInfo = CultureInfo.InvariantCulture

        fc_Class = New Cls_PR
        Dim ls_Judul As String = ""
        Dim dt As New DataTable
        Dim ls_OldKode As String = ""
        ' DeptID = gh_Common.GroupID
        DeptID = TBagian.EditValue


        Dim Th As Date = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo)
        Dim Tahun As String = (Th.Year).ToString
        Dim Bulan As String = (Th.Month).ToString
        Dim ACCT As String = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Accountt).ToString()
        Call CekBudget(Tahun, SubAccountDept, ACCT, Bulan)



        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()
        Dim _Account As Double = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Accountt) Is DBNull.Value, 0, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, Accountt))
        Dim _tgl As Date = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo) Is DBNull.Value, Nothing, GridView3.GetRowCellValue(GridView3.FocusedRowHandle, WaktuTempo))
        'Dim tahun As Int32 = _tgl.Year
        Call HitungTotal()
        Call Budget(Tahun.ToString(), gh_Common.GroupID, _Account)

    End Sub
    Private Sub Budget(Tahun As String, Dept As String, Account As String)

        Dim dtBudget As New DataTable
        dtBudget = fc_Class.GetBudget(Tahun, Dept, Account)

    End Sub



    Private Sub GridView3_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView3.RowStyle

        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim Keterangan As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Keterangan"))
            If Keterangan = "Over" Then
                e.Appearance.BackColor = Color.Yellow
                'e.Appearance.BackColor2 = Color.Yellow
                e.HighPriority = True
            End If
        End If
    End Sub


    Public Overrides Sub Proc_DeleteData()

        Try
            If fc_Class.H_StatusFlag = "" Or fc_Class.H_StatusFlag = "P" Then

                fc_Class.CancelPR(fs_Code)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                Grid.DataSource = fc_Class.Get_PR(gh_Common.GroupID)
                IsClosed = True
                Me.Hide()
            Else
                MessageBox.Show("PR Tidak Bisa Di Cancel ", "Warning",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation,
                         MessageBoxDefaultButton.Button1)

            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TAmmountSirkulasi_KeyPress(sender As Object, e As KeyPressEventArgs)

        'Dim tombol As Integer
        'tombol = Asc(e.KeyChar)

        'If Not ((tombol = 0)) Then
        '    e.Handled = True
        'End If

    End Sub

    Private Sub RepoUnitCost_EditValueChanged(sender As Object, e As EventArgs) Handles RepoUnitCost.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim a As Double = 0
        Dim b As Double = 0

        'Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        'For Each rowHandle As Integer In selectedRows
        '    If rowHandle >= 0 Then
        '        a = GridView1.GetRowCellValue(rowHandle, "Quantity")
        '        b = GridView1.GetRowCellValue(rowHandle, "Balance")
        '    End If

        'Next rowHandle
        'If a > b Then
        '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Quantity", b)
        'End If


        Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity"))
        Dim Price As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost"))


        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Extended Cost", Qty * Price)


    End Sub

    Private Sub T_UntukBagian_EditValueChanged(sender As Object, e As EventArgs) Handles TBagian.EditValueChanged

        Call Sub_Dept(TBagian.EditValue)

    End Sub


    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If TBagian.EditValue = "" Then
                MessageBox.Show("Pilih Untuk Bagian",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                'ElseIf T_VendorID.EditValue = "" Then
                '    MessageBox.Show("Please Check Vendor ID",
                '                   "Warning",
                '                   MessageBoxButtons.OK,
                '                   MessageBoxIcon.Exclamation,
                '                   MessageBoxDefaultButton.Button1)




            Else
                lb_Validated = True
            End If

            'If lb_Validated Then

            '    If isUpdate = False Then
            '        fc_Class.H_PONbr = T_PONumber.EditValue
            '        fc_Class.ValidateInsert()
            '    Else
            '        '.ValidateUpdate()
            '    End If

            'End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Private Sub T_UntukBagian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBagian.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not (tombol = 0) Then
            e.Handled = True
        End If


    End Sub
End Class
