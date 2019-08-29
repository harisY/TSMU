Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Public Class FrmPaymentDirect
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ff_Detail As FrmDetailPaymentDirect
    Dim ff_Detail2 As FrmDetailPaymentSuspend
    Dim ff_Detail3 As FrmDetailPaymentSettle
    Dim ff_Detail4 As FrmDetailPaymentSuspend
    Dim ff_Detail5 As FrmEditDirectPayment
    Dim ff_Detail6 As FrmBankPaid
    Dim ObjCashBank As New cashbank_models
    Dim ObjSaldoAwal As New saldo_awal_models
    Dim GridDtl As GridControl
    Dim NoBukti As String
    Dim ObjPayment As New cashbank_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
        End If
        InitialSetForm()
        '   FrmParent = lf_FormParent
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ''ObjPayment.ID = fs_Code
                ' ObjPayment.GetSettleById()
                ObjPayment.Perpost = fs_Code
                ObjPayment.AcctID = fs_Code2
                _txtperpost.Text = fs_Code
                _txtaccount.Text = fs_Code2
                ObjPayment.GetGridDetailCashBankByAccountID02()

                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Cash Bank " & fs_Code
            Else
                Me.Text = "Cash Bank"
            End If
            Call LoadTxtBox()
            '' LoadGridDetail()
            DataCashBank()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name.ToString
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjPayment
                    _txtperpost.Text = .Perpost
                    _txtaccount.Text = .AcctID
                End With
            Else
                _txtperpost.Text = ""
                _txtaccount.Text = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Private Sub coba()
        If _txtaccount.Text = "" Then
        Else
            ObjCashBank.Perpost = _txtperpost.Text
            ObjCashBank.AcctID = _txtaccount.Text
            ObjCashBank.account = _txtaccount.Text
        End If

        _txtaccountname.Text = ObjCashBank.GetNamaAccountbyid()
        Dim saldo As Double
        saldo = ObjCashBank.saldo2
        If saldo = 0 Then
            _txtsaldo.Text = saldo
        Else
            _txtsaldo.Text = Format(saldo, "#,#.##")
        End If
        Call DataCashBank()


        For b As Integer = 0 To GridView1.RowCount - 1

            If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                End If

            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            Else
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                End If
            End If
        Next
        Call DataSuspend()
    End Sub
    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles _txtaccount.EditValueChanged
        If _txtaccount.Text = "" Then
        Else
            ObjCashBank.Perpost = _txtperpost.Text
            ObjCashBank.AcctID = _txtaccount.Text
            ObjCashBank.account = _txtaccount.Text
        End If


        ''      ObjCashBank.curyid = Trim(_txtcuryid.Text)

        _txtaccountname.Text = ObjCashBank.GetNamaAccountbyid()
        Dim saldo As Double
        saldo = ObjCashBank.saldo2
        If saldo = 0 Then
            _txtsaldo.Text = saldo
        Else
            _txtsaldo.Text = Format(saldo, "#,#.##")
        End If
        '' _txtsaldo.Text = ObjCashBank.saldo2
        'If _txtsaldo.Text = "0" Then
        '    _txtsaldo.Text = "0"
        'Else
        ''_txtsaldo.Text = Format(Val(_txtsaldo.Text), "#,#.##")
        'End If
        'Dim dtGrid As New DataTable
        'dtGrid = suspen.GetGridDetailSuspendPaymentByAccountID

        'If dtGrid.Rows.Count > 0 Then
        '    GridControl1.DataSource = dtGrid
        '    GridCellFormat(GridView1)
        'End If
        Call DataCashBank()


        For b As Integer = 0 To GridView1.RowCount - 1
            'If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
            '    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
            'Else
            '    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
            'End If
            If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                End If

            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            Else
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                End If
            End If
        Next
        Call DataSuspend()
    End Sub
    Private Sub DataSuspend()
        Dim dtGrid2 As New DataTable

        dtGrid2 = ObjCashBank.GetGridDetailSuspendByAccountID
        GridControl2.DataSource = dtGrid2

        If dtGrid2.Rows.Count > 0 Then
            GridCellFormat(GridView2)
        Else
            GridCellFormat(GridView2)
        End If
    End Sub
    Private Sub DataSettlement()
        Dim dtGrid3 As New DataTable
        dtGrid3 = ObjCashBank.GetGridDetailSettleByAccountID
        GridControl3.DataSource = dtGrid3
        If dtGrid3.Rows.Count > 0 Then
            GridCellFormat(GridView3)
        End If
    End Sub
    Private Sub DataEntertaint()
        Dim dtGrid4 As New DataTable
        dtGrid4 = ObjCashBank.GetGridDetailEntertaintByAccountID
        GridControl5.DataSource = dtGrid4

        If dtGrid4.Rows.Count > 0 Then
            GridCellFormat(GridView5)
        End If
    End Sub

    Private Sub DataCashBank()
        Dim dtGrid As New DataTable
        ObjCashBank.Perpost = _txtperpost.Text
        ObjCashBank.AcctID = _txtaccount.Text
        dtGrid = ObjCashBank.GetGridDetailCashBankByAccountID02

        If dtGrid.Rows.Count > 0 Then
            GridControl1.DataSource = dtGrid
            GridCellFormat(GridView1)
        Else
            GridControl1.DataSource = dtGrid
            GridCellFormat(GridView1)
        End If
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
                    Call DataSuspend()
                    Call DataEntertaint()
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmPaymentDirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _txtperpost.EditValue = Format(DateTime.Today, "yyyy-MM")

        ' DataCashBank()
        DataSuspend()
        DataSettlement()
        DataEntertaint()
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
    Private Sub tabu1()
        For i As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(i, "Proses") = True Then
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
                    .Saldo_Awal = _txtsaldo.Text
                    .SuspendID = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                    .InsertToTable()
                    .UpdateSuspend()
                    '' .cek1 = True
                End With

            End If
        Next

    End Sub
    Private Sub tabu2()
        Dim bukti As String = ObjCashBank.autononb
        Dim tgl As DateTime = DateTime.Now
        Dim transaksi As String = "Advance"
        Dim suspendamount As Double = 0
        Dim ObjDetails As New cashbank_models
        For i As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(i, "Proses") = True Then
                suspendamount = suspendamount + GridView2.GetRowCellValue(i, "Amount")
            End If
        Next

        TempTable()
        dtTemp.Rows.Add()
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = tgl
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = bukti
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = transaksi
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = suspendamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = 0
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = 0
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = suspendamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = 0

        ''  GridControl1.DataSource = dtTemp

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

        Call DataSuspend()

        Call DataCashBank()


        For b As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                End If

            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            Else
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                End If
            End If
        Next
    End Sub

    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Tgl")
        dtTemp.Columns.Add("NoBukti")
        dtTemp.Columns.Add("Transaksi")
        dtTemp.Columns.Add("SuspendAmount")
        dtTemp.Columns.Add("SettleAmount")
        dtTemp.Columns.Add("Masuk")
        dtTemp.Columns.Add("Keluar")
        dtTemp.Columns.Add("Saldo")
        dtTemp.Clear()
    End Sub
    Private Sub tab_settle()
        For f As Integer = 0 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(f, "Proses") = True Then
                Dim bukti As String = ObjCashBank.autononb
                Dim totsuspend As Double = 0

                Dim ObjDetails As New cashbank_models
                With ObjDetails
                    .Tgl = DateTime.Parse(GridView3.GetRowCellValue(f, "Tgl").ToString())
                    .NoBukti = bukti
                    .Transaksi = "Settle"
                    .Keterangan = GridView3.GetRowCellValue(f, "Description").ToString().TrimEnd
                    .Noref = GridView3.GetRowCellValue(f, "SuspendID").ToString().TrimEnd + " / " + GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                    totsuspend = If(GridView3.GetRowCellValue(f, "Total") Is DBNull.Value, 0, Convert.ToDouble(GridView3.GetRowCellValue(f, "Total")))
                    .SuspendAmount = totsuspend
                    .SettleAmount = GridView3.GetRowCellValue(f, "SettleAmount")

                    If GridView3.GetRowCellValue(f, "SettleAmount") > totsuspend Then
                        .Keluar = GridView3.GetRowCellValue(f, "SettleAmount") - totsuspend
                        .Masuk = 0
                    ElseIf GridView3.GetRowCellValue(f, "SettleAmount") < totsuspend Then
                        .Keluar = 0
                        .Masuk = totsuspend - GridView3.GetRowCellValue(f, "SettleAmount")
                    Else
                        .Keluar = 0
                        .Masuk = 0
                    End If


                    .Saldo = 0
                    ' .Noref = GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                    .Perpost = _txtperpost.Text
                    .AcctID = _txtaccount.Text
                    .Saldo_Awal = _txtsaldo.Text
                    .SettleID = GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                    .InsertToTable2()
                    .UpdateSettle()
                End With

            End If
        Next

    End Sub
    Private Sub tab_settle02()
        Dim bukti As String = ObjCashBank.autononb
        Dim tgl As DateTime = DateTime.Now
        Dim transaksi As String = "Settle"
        Dim suspendamount As Double = 0
        Dim totsuspend As Double = 0
        Dim settleamount As Double = 0
        Dim Keluar As Double = 0
        Dim Masuk As Double = 0
        Dim TKeluar As Double = 0
        Dim TMasuk As Double = 0
        Dim ObjDetails As New cashbank_models
        For i As Integer = 0 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(i, "Proses") = True Then
                '' suspendamount = suspendamount + GridView2.GetRowCellValue(i, "Total")
                totsuspend = If(GridView3.GetRowCellValue(i, "Total") Is DBNull.Value, 0, Convert.ToDouble(GridView3.GetRowCellValue(i, "Total")))
                suspendamount = suspendamount + totsuspend
                settleamount = settleamount + GridView3.GetRowCellValue(i, "SettleAmount")
                If GridView3.GetRowCellValue(i, "SettleAmount") > totsuspend Then
                    Keluar = GridView3.GetRowCellValue(i, "SettleAmount") - totsuspend
                    Masuk = 0
                ElseIf GridView3.GetRowCellValue(i, "SettleAmount") < totsuspend Then
                    Keluar = 0
                    Masuk = totsuspend - GridView3.GetRowCellValue(i, "SettleAmount")
                Else
                    Keluar = 0
                    Masuk = 0
                End If

                TKeluar = TKeluar + Keluar
                TMasuk = TMasuk + Masuk
            End If
        Next

        TempTable()
        dtTemp.Rows.Add()
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = tgl
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = bukti
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = transaksi
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = suspendamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = settleamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = TMasuk
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = TKeluar
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = 0

        ''  GridControl1.DataSource = dtTemp

        ObjDetails.Tgl = tgl
        ObjDetails.NoBukti = bukti
        ObjDetails.Transaksi = transaksi
        ObjDetails.SuspendAmount = suspendamount
        ObjDetails.SettleAmount = settleamount
        ObjDetails.Masuk = TMasuk
        ObjDetails.Keluar = TKeluar
        ObjDetails.Saldo = 0
        ObjDetails.Perpost = _txtperpost.Text
        ObjDetails.AcctID = _txtaccount.Text
        ObjDetails.InsertToTable02()
        Call DataSettlement()
        Call DataCashBank()

        For b As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                End If

            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            Else
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                End If
            End If
        Next
    End Sub
    Private Sub tab_adv_ent()
        For n As Integer = 0 To GridView5.RowCount - 1
            If GridView5.GetRowCellValue(n, "Proses") = True Then
                Dim bukti As String = ObjCashBank.autononb
                ' suspen.SuspendID = suspendID
                Dim ObjDetails As New cashbank_models
                With ObjDetails
                    .Tgl = DateTime.Parse(GridView5.GetRowCellValue(n, "Tgl").ToString())
                    .NoBukti = bukti
                    .Transaksi = "Entertain"
                    .Keterangan = GridView5.GetRowCellValue(n, "Description").ToString().TrimEnd
                    .Keluar = GridView5.GetRowCellValue(n, "Amount")
                    .Masuk = 0
                    .Saldo = 0
                    .Noref = GridView5.GetRowCellValue(n, "SuspendID").ToString().TrimEnd
                    .Perpost = _txtperpost.Text
                    .AcctID = _txtaccount.Text
                    .Saldo_Awal = _txtsaldo.Text
                    .SuspendID = GridView5.GetRowCellValue(n, "SuspendID").ToString().TrimEnd
                    .InsertToTable()
                    .UpdateSuspend()
                    '' .cek1 = True
                End With

            End If
        Next

    End Sub
    Private Sub tab_adv_ent02()
        Dim bukti As String = ObjCashBank.autononb
        Dim tgl As DateTime = DateTime.Now
        Dim transaksi As String = "Entertain"
        Dim suspendamount As Double = 0
        Dim ObjDetails As New cashbank_models
        For i As Integer = 0 To GridView5.RowCount - 1
            If GridView5.GetRowCellValue(i, "Proses") = True Then
                suspendamount = suspendamount + GridView5.GetRowCellValue(i, "Amount")
            End If
        Next

        TempTable()
        dtTemp.Rows.Add()
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = tgl
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = bukti
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = transaksi
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = suspendamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = 0
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = 0
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = suspendamount
        dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = 0

        ''  GridControl1.DataSource = dtTemp

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

        Call DataEntertaint()

        Call DataCashBank()


        For b As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                End If

            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                End If
            Else
                If b = 0 Then
                    GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                Else
                    GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                End If
            End If
        Next
    End Sub
    Public Overrides Sub Proc_SaveData()

        Try
            If TabControl1.SelectedIndex = 0 Then
                For i As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(i, "Proses") = True Then
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
                            .Saldo_Awal = _txtsaldo.Text
                            .SuspendID = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                            .InsertToTable()
                            .UpdateSuspend()
                            '' .cek1 = True
                        End With

                    End If
                Next
                Call DataSuspend()

                Call DataCashBank()


                For b As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        End If

                    ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        End If
                    Else
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                        End If
                    End If
                Next

            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

        'Call SaveFromSuspend()
        'Call SaveFromSettlement()

        '---------------------------------------------------------
        Try
            If TabControl1.SelectedIndex = 1 Then

                For f As Integer = 0 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(f, "Proses") = True Then
                        Dim bukti As String = ObjCashBank.autononb
                        Dim totsuspend As Double = 0

                        ' suspen.SuspendID = suspendID
                        Dim ObjDetails As New cashbank_models
                        With ObjDetails
                            .Tgl = DateTime.Parse(GridView3.GetRowCellValue(f, "Tgl").ToString())
                            .NoBukti = bukti
                            .Transaksi = "Settle"
                            .Keterangan = GridView3.GetRowCellValue(f, "Description").ToString().TrimEnd
                            .Noref = GridView3.GetRowCellValue(f, "SuspendID").ToString().TrimEnd + " / " + GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                            '    .SuspendAmount = GridView3.GetRowCellValue(f, "Total")
                            totsuspend = If(GridView3.GetRowCellValue(f, "Total") Is DBNull.Value, 0, Convert.ToDouble(GridView3.GetRowCellValue(f, "Total")))
                            ' .SuspendAmount = If(GridView3.GetRowCellValue(f, "Total") Is DBNull.Value, 0, Convert.ToDouble(GridView3.GetRowCellValue(f, "Total")))
                            .SuspendAmount = totsuspend
                            .SettleAmount = GridView3.GetRowCellValue(f, "SettleAmount")

                            ''If GridView3.GetRowCellValue(f, "SettleAmount") > GridView3.GetRowCellValue(f, "Total") Then
                            If GridView3.GetRowCellValue(f, "SettleAmount") > totsuspend Then
                                ''.Keluar = GridView3.GetRowCellValue(f, "SettleAmount") - GridView3.GetRowCellValue(f, "Total")
                                .Keluar = GridView3.GetRowCellValue(f, "SettleAmount") - totsuspend
                                .Masuk = 0
                                ''ElseIf GridView3.GetRowCellValue(f, "SettleAmount") < GridView3.GetRowCellValue(f, "Total") Then
                            ElseIf GridView3.GetRowCellValue(f, "SettleAmount") < totsuspend Then
                                .Keluar = 0
                                ' .Masuk = GridView3.GetRowCellValue(f, "Total") - GridView3.GetRowCellValue(f, "SettleAmount")
                                .Masuk = totsuspend - GridView3.GetRowCellValue(f, "SettleAmount")
                            Else
                                .Keluar = 0
                                .Masuk = 0
                            End If


                            .Saldo = 0
                            ' .Noref = GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                            .Perpost = _txtperpost.Text
                            .AcctID = _txtaccount.Text
                            .Saldo_Awal = _txtsaldo.Text
                            .SettleID = GridView3.GetRowCellValue(f, "SettleID").ToString().TrimEnd
                            .InsertToTable2()
                            .UpdateSettle()
                        End With

                    End If
                Next
                Call DataSettlement()
                Call DataCashBank()

                For b As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        End If

                    ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        End If
                    Else
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                        End If
                    End If
                Next

                'For b As Integer = 0 To GridView1.RowCount - 1
                '    If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                '        GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                '    Else
                '        GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                '    End If
                'Next
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        '------------------------------------------

        Try
            If TabControl1.SelectedIndex = 2 Then
                For n As Integer = 0 To GridView5.RowCount - 1
                    If GridView5.GetRowCellValue(n, "Proses") = True Then
                        Dim bukti As String = ObjCashBank.autononb
                        ' suspen.SuspendID = suspendID
                        Dim ObjDetails As New cashbank_models
                        With ObjDetails
                            .Tgl = DateTime.Parse(GridView5.GetRowCellValue(n, "Tgl").ToString())
                            .NoBukti = bukti
                            .Transaksi = "Entertain"
                            .Keterangan = GridView5.GetRowCellValue(n, "Description").ToString().TrimEnd
                            .Keluar = GridView5.GetRowCellValue(n, "Amount")
                            .Masuk = 0
                            .Saldo = 0
                            .Noref = GridView5.GetRowCellValue(n, "SuspendID").ToString().TrimEnd
                            .Perpost = _txtperpost.Text
                            .AcctID = _txtaccount.Text
                            .Saldo_Awal = _txtsaldo.Text
                            .SuspendID = GridView5.GetRowCellValue(n, "SuspendID").ToString().TrimEnd
                            .InsertToTable()
                            .UpdateSuspend()
                            '' .cek1 = True
                        End With

                    End If
                Next
                Call DataEntertaint()
                Call DataCashBank()

                'For b As Integer = 0 To GridView1.RowCount - 1
                '    If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                '        GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                '    ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                '        GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                '    End If
                'Next
                For b As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(b, "Masuk").ToString <> "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString = "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) + Convert.ToDouble(GridView1.GetRowCellValue(b, "Masuk")))
                        End If

                    ElseIf GridView1.GetRowCellValue(b, "Masuk").ToString = "0" AndAlso GridView1.GetRowCellValue(b, "Keluar").ToString <> "0" Then
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")) - Convert.ToDouble(GridView1.GetRowCellValue(b, "Keluar")))
                        End If
                    Else
                        If b = 0 Then
                            GridView1.SetRowCellValue(b, "Saldo", CDbl(_txtsaldo.Text))
                        Else
                            GridView1.SetRowCellValue(b, "Saldo", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Saldo")))
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        _txtperpost.EditValue = Format(DateTime.Today, "yyyy-MM")
        DataSuspend()
        DataSettlement()
        DataEntertaint()
    End Sub
    Private Sub SaveFromSuspend()
        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(i, "Proses") = True Then
                    Dim bukti As String = ObjCashBank.autononb
                    ' suspen.SuspendID = suspendID
                    Dim ObjDetails As New cashbank_models
                    With ObjDetails
                        .Tgl = DateTime.Parse(GridView2.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Suspend"
                        .Keterangan = GridView2.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Keluar = GridView2.GetRowCellValue(i, "SettleAmount")
                        .Masuk = 0
                        .Saldo = 0
                        .Noref = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                        .Perpost = _txtperpost.Text
                        .AcctID = _txtaccount.Text
                        .Saldo_Awal = _txtsaldo.Text
                        .SuspendID = GridView2.GetRowCellValue(i, "SuspendID").ToString().TrimEnd
                        .InsertToTable()
                        .UpdateSuspend()
                        '' .cek1 = True
                    End With

                End If
            Next

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        '---------------------------------------------------------


        Try
            For i As Integer = 0 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(i, "Proses") = True Then
                    Dim bukti As String = ObjCashBank.autononb
                    ' suspen.SuspendID = suspendID
                    Dim ObjDetails As New cashbank_models
                    With ObjDetails
                        .Tgl = DateTime.Parse(GridView3.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Settle"
                        .Keterangan = GridView3.GetRowCellValue(i, "SuspendID").ToString().TrimEnd + " / " + GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Keluar = 0
                        .Masuk = GridView3.GetRowCellValue(i, "Total")
                        .Saldo = 0
                        .Noref = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Perpost = _txtperpost.Text
                        .AcctID = _txtaccount.Text
                        .Saldo_Awal = _txtsaldo.Text
                        .SettleID = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .InsertToTable()

                        .Tgl = DateTime.Parse(GridView3.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Voucher"
                        .Keterangan = GridView3.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Keluar = GridView3.GetRowCellValue(i, "SettleAmount")
                        .Masuk = 0
                        .Saldo = 0
                        .Noref = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Perpost = _txtperpost.Text
                        .AcctID = _txtaccount.Text
                        .Saldo_Awal = _txtsaldo.Text
                        .SettleID = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .InsertToTable()
                        .UpdateSettle()
                        '' .cek1 = True
                    End With

                End If
            Next

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub SaveFromSettlement()

        Try
            For i As Integer = 0 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(i, "Proses") = True Then
                    Dim bukti As String = ObjCashBank.autononb
                    ' suspen.SuspendID = suspendID
                    Dim ObjDetails As New cashbank_models
                    With ObjDetails
                        .Tgl = DateTime.Parse(GridView3.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Settle"
                        .Keterangan = GridView3.GetRowCellValue(i, "SuspendID").ToString().TrimEnd + " / " + GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Keluar = 0
                        .Masuk = GridView3.GetRowCellValue(i, "Total")
                        .Saldo = 0
                        .Noref = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Perpost = _txtperpost.Text
                        .AcctID = _txtaccount.Text
                        .Saldo_Awal = _txtsaldo.Text
                        .SettleID = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .InsertToTable()

                        .Tgl = DateTime.Parse(GridView3.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Voucher"
                        .Keterangan = GridView3.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Keluar = GridView3.GetRowCellValue(i, "Amount")
                        .Masuk = 0
                        .Saldo = 0
                        .Noref = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .Perpost = _txtperpost.Text
                        .AcctID = _txtaccount.Text
                        .Saldo_Awal = _txtsaldo.Text
                        .SettleID = GridView3.GetRowCellValue(i, "SettleID").ToString().TrimEnd
                        .InsertToTable()
                        .UpdateSettle()
                        '' .cek1 = True
                    End With

                End If
            Next

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub ReposPresesSettle_EditValueChanged(sender As Object, e As EventArgs) Handles ReposPresesSettle.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        TempTable1()
        For i As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(i, "Proses") = True Then
                dtTemp1.Rows.Add()
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(0) = GridView2.GetRowCellValue(i, "Tgl")
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(1) = GridView2.GetRowCellValue(i, "SuspendID")
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(2) = GridView2.GetRowCellValue(i, "Description")
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(3) = GridView2.GetRowCellValue(i, "Currency")
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(4) = GridView2.GetRowCellValue(i, "Amount")
                dtTemp1.Rows(dtTemp1.Rows.Count - 1).Item(5) = GridView2.GetRowCellValue(i, "AcctID")
            End If
        Next


        'Try
        'tabu1()
        '    tabu2()
        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
        '' Me.Close()
        'Dim id6 As String = String.Empty
        'Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        'For Each rowHandle As Integer In selectedRows
        '    If rowHandle >= 0 Then
        '        id6 = GridView1.GetRowCellValue(rowHandle, "NoBukti")
        '    End If
        'Next rowHandle
        ff_Detail6 = New FrmBankPaid(dtTemp1)
        ff_Detail6.ShowDialog()
        _txtperpost.Text = ff_Detail6.Perpost
        _txtaccount.Text = ff_Detail6.Rekening
        ' ff_Detail6.ShowDialog()
    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        Dim id As String = String.Empty
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id = GridView1.GetRowCellValue(rowHandle, "NoBukti")
            End If
        Next rowHandle
        ff_Detail = New FrmDetailPaymentDirect(id)
        ff_Detail.Show()
    End Sub
    Private Sub EditRek_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EditRek.ButtonClick
        Dim id5 As String = String.Empty
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id5 = GridView1.GetRowCellValue(rowHandle, "NoBukti")
            End If
        Next rowHandle
        ff_Detail5 = New FrmEditDirectPayment(id5)
        ff_Detail5.Show()
    End Sub
    Private Sub RepositoryItemButtonEdit4_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit4.ButtonClick
        Dim id As String = String.Empty
        Dim selectedRows() As Integer = GridView2.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id = GridView2.GetRowCellValue(rowHandle, "SuspendID")
            End If
        Next rowHandle
        ff_Detail2 = New FrmDetailPaymentSuspend(id)
        ff_Detail2.Show()
    End Sub
    Private Sub RepositoryItemButtonEdit5_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit5.ButtonClick
        Dim id As String = String.Empty
        Dim selectedRows() As Integer = GridView3.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id = GridView3.GetRowCellValue(rowHandle, "SettleID")
            End If
        Next rowHandle
        ff_Detail3 = New FrmDetailPaymentSettle(id)
        ff_Detail3.Show()
    End Sub
    Private Sub RepositoryItemButtonEdit6_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit6.ButtonClick
        Dim id2 As String = String.Empty
        Dim selectedRows() As Integer = GridView3.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id2 = GridView3.GetRowCellValue(rowHandle, "SuspendID")
            End If
        Next rowHandle
        ff_Detail4 = New FrmDetailPaymentSuspend(id2)
        ff_Detail4.Show()
    End Sub
    Private Sub btnpaid_Click(sender As Object, e As EventArgs) Handles btnpaid.Click
        Try
            tab_settle()

            tab_settle02()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty
        Dim transaksi As String = String.Empty
        Dim ObjDetails As New cashbank_models
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "NoBukti")
                    transaksi = Trim(GridView1.GetRowCellValue(rowHandle, "Transaksi"))
                End If
            Next rowHandle
            ObjDetails.ID = ID

            If transaksi = "Advance" Then
                ObjDetails.UpdateSuspend_hapus()
            ElseIf transaksi = "Settle" Then
                ObjDetails.UpdateSettle_hapus()
            End If
            ObjDetails.Delete()
            Call DataSuspend()
            Call DataSettlement()
            Call DataEntertaint()
            Call DataCashBank()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
            'Grid.RemoveItem(Grid.Row)
            'If Grid.Rows.Count > Grid.Rows.Fixed Then
            '    Call Proc_EnableButtons(True, False, True, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(True, False, False, True, True, True, False, False)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnadd_e_Click(sender As Object, e As EventArgs) Handles btnadd_e.Click
        Try
            tab_adv_ent()

            tab_adv_ent02()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim dtTemp1 As DataTable
    Private Sub TempTable1()
        dtTemp1 = New DataTable
        'dtTemp1.Columns.Add("Tgl")
        'dtTemp1.Columns.Add("AdvanceNo")
        'dtTemp1.Columns.Add("Description")
        'dtTemp1.Columns.Add("CuryID")
        'dtTemp1.Columns.Add("Amount")
        'dtTemp1.Columns.Add("Rek")
        'dtTemp1.Clear()

        dtTemp1.Columns.AddRange(New DataColumn(5) {New DataColumn("Tgl", GetType(DateTime)),
                                                   New DataColumn("SuspendID", GetType(String)),
                                                   New DataColumn("Description", GetType(String)),
                                                   New DataColumn("CuryID", GetType(String)),
                                                   New DataColumn("Amount", GetType(Decimal)),
                                                   New DataColumn("AcctID", GetType(String))})
        dtTemp1.Clear()
    End Sub

End Class
