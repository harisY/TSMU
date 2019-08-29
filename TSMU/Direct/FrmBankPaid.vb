Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmBankPaid
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String
    Dim DtScan1 As DataTable
    Dim ff_Detail As FrmPaymentDirect
    Dim _dt As DataTable
    Sub New(NoBukti As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = NoBukti

    End Sub

    Public Sub New(ByVal dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dt = New DataTable
        _dt = dt
    End Sub

    Public ReadOnly Property Perpost() As String
        Get
            Return _txtperpost.Text
        End Get

    End Property

    Public ReadOnly Property Rekening() As String
        Get
            Return _txtaccount.Text
        End Get
    End Property
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "")
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        '  FrmPaymentDirect.Close()
        ff_Detail = New FrmPaymentDirect(ls_Code, ls_Code2, Me)
        ff_Detail.MdiParent = MenuUtamaForm
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub DataCashBank()
        'Dim dtGrid As New DataTable
        ''ObjCashBank.Perpost = _txtperpost.Text
        ''ObjCashBank.AcctID = _txtaccount.Text
        'dtGrid = ObjCashBank.GetGridDetailCashBankByAccountID03(_NoBukti)
        'GridControl1.DataSource = dtGrid
        'GridCellFormat(GridView1)

    End Sub
    Private Sub FrmBankPaid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _txtperpost.EditValue = Format(DateTime.Today, "yyyy-MM")
        DataCashBank()
        'Call CreateTable()
        Dim totalamt As Double
        GridControl2.DataSource = _dt
        For i As Integer = 0 To GridView2.RowCount - 1
            totalamt = totalamt + GridView2.GetRowCellValue(i, "Amount")
        Next
        _txttot.Text = Format(totalamt, "#,#.##")
        GridCellFormat(GridView2)
    End Sub
    Private Sub tabu1()
        For i As Integer = 0 To GridView2.RowCount - 1

            Dim bukti As String = ObjCashBank.autononb
            ' suspen.SuspendID = suspendID
            Dim ObjDetails As New cashbank_models
            With ObjDetails
                .Tgl = DateTime.Parse(GridView2.GetRowCellValue(i, "Tgl").ToString())
                .NoBukti = bukti
                .Transaksi = "Advance"
                .Keterangan = GridView2.GetRowCellValue(i, "Description").ToString().TrimEnd
                .Noref = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                .SuspendAmount = GridView2.GetRowCellValue(i, "Amount")
                .SettleAmount = 0
                .Keluar = GridView2.GetRowCellValue(i, "Amount")
                .Masuk = 0
                .Saldo = 0
                '.Noref = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                .Perpost = _txtperpost.Text
                .AcctID = _txtaccount.Text
                .Saldo_Awal = 0
                .SuspendID = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                .InsertToTable()
                .UpdateSuspend()
                '' .cek1 = True
            End With


        Next

    End Sub

    Private Sub tabu2()
        Dim bukti As String = ObjCashBank.autononb
        Dim tgl As DateTime = DateTime.Now
        Dim transaksi As String = "Advance"
        Dim suspendamount As Double = 0
        Dim ObjDetails As New cashbank_models
        For i As Integer = 0 To GridView2.RowCount - 1
            suspendamount = suspendamount + GridView2.GetRowCellValue(i, "Amount")
        Next

        TempTable3()
        dtTemp3.Rows.Add()
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(0) = tgl
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(1) = bukti
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(2) = transaksi
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(3) = suspendamount
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(4) = 0
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(5) = 0
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(6) = suspendamount
        dtTemp3.Rows(dtTemp3.Rows.Count - 1).Item(7) = 0

        ''  GridControl1.DataSource = dtTemp3

        ObjDetails.Tgl = tgl
        ObjDetails.NoBukti = bukti
        ObjDetails.Transaksi = transaksi
        ObjDetails.SuspendAmount = suspendamount
        ObjDetails.SettleAmount = 0
        ObjDetails.Masuk = 0
        ObjDetails.Keluar = suspendamount
        ObjDetails.Saldo = 0
        ObjDetails.Perpost = _txtperpost.Text
        ObjDetails.AcctID = _txtaccount.Text
        ObjDetails.InsertToTable02()

    End Sub
    Dim dtTemp3 As DataTable
    Private Sub TempTable3()
        dtTemp3 = New DataTable
        dtTemp3.Columns.Add("Tgl")
        dtTemp3.Columns.Add("NoBukti")
        dtTemp3.Columns.Add("Transaksi")
        dtTemp3.Columns.Add("SuspendAmount")
        dtTemp3.Columns.Add("SettleAmount")
        dtTemp3.Columns.Add("Masuk")
        dtTemp3.Columns.Add("Keluar")
        dtTemp3.Columns.Add("Saldo")
        dtTemp3.Clear()
    End Sub
    Private Sub CreateTable()
        DtScan1 = New DataTable
        DtScan1.Columns.AddRange(New DataColumn(4) {New DataColumn("Tgl", GetType(String)),
                                                           New DataColumn("SuspendID", GetType(String)),
                                                           New DataColumn("Description", GetType(String)),
                                                           New DataColumn("Amount", GetType(String)),
                                                           New DataColumn("AcctID", GetType(String))})
        GridControl2.DataSource = DtScan1
        GridView2.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub TextEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _txtaccount.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = _txtaccount.Name Then
                dtSearch = ObjSuspend.GetBank
                ls_OldKode = _txtaccount.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _txtaccount.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    _txtaccount.Text = Value1
                    _txtaccountname.Text = Value2
                    _txtcuryid.Text = Value3
                    ObjCashBank.curyid = Value3
                    'Call DataSuspend()
                    'Call DataEntertaint()
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub



    Private Sub _TsbOk_Click(sender As Object, e As EventArgs) Handles _TsbOk.Click
        tabu1()
        tabu2()
        Me.Close()
    End Sub

End Class