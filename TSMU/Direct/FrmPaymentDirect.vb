Imports DevExpress.XtraEditors.Controls

Public Class FrmPaymentDirect
    ' Dim suspen As ClsSuspend = New ClsSuspend()
    Dim suspen As New cashbank_models
    Dim ObjCashBank As New cashbank_models
    Dim ObjSaldoAwal As New saldo_awal_models

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles _txtaccount.EditValueChanged
        suspen.perpost = _txtperpost.Text
        suspen.acctid = _txtaccount.Text
        suspen.account = _txtaccount.Text

        _txtaccountname.Text = suspen.GetNamaAccountbyid()
        _txtsaldo.Text = suspen.saldo2
        _txtsaldo.Text = Format(Val(_txtsaldo.Text), "#,#.##")

        'Dim dtGrid As New DataTable
        'dtGrid = suspen.GetGridDetailSuspendPaymentByAccountID

        'If dtGrid.Rows.Count > 0 Then
        '    GridControl1.DataSource = dtGrid
        '    GridCellFormat(GridView1)
        'End If
        Call DataCashBank()
        Call DataSuspend()

    End Sub
    Private Sub DataSuspend()
        Dim dtGrid As New DataTable
        dtGrid = suspen.GetGridDetailSuspendByAccountID

        If dtGrid.Rows.Count > 0 Then
            GridControl2.DataSource = dtGrid
            GridCellFormat(GridView2)
        End If
    End Sub
    Private Sub DataSettlement()
        Dim dtGrid As New DataTable
        dtGrid = suspen.GetGridDetailSettleByAccountID
        If dtGrid.Rows.Count > 0 Then
            GridControl3.DataSource = dtGrid
            GridCellFormat(GridView3)
        End If
    End Sub
    Private Sub DataEntertaint()
        Dim dtGrid As New DataTable
        dtGrid = suspen.GetGridDetailEntertaintByAccountID

        If dtGrid.Rows.Count > 0 Then
            GridControl3.DataSource = dtGrid
            GridCellFormat(GridView3)
        End If
    End Sub

    Private Sub DataCashBank()
        Dim dtGrid As New DataTable
        ObjCashBank.Perpost = _txtperpost.Text
        ObjCashBank.AcctID = _txtaccount.Text
        dtGrid = ObjCashBank.GetGridDetailCashBankByAccountID

        If dtGrid.Rows.Count > 0 Then
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
                dtSearch = ObjSuspend.GetAccount
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

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _txtaccount.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    _txtaccount.Text = Value1
                    _txtaccountname.Text = Value2

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmPaymentDirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _txtperpost.EditValue = Format(DateTime.Today, "yyyy-03")
        DataSuspend()
        DataSettlement()
        DataEntertaint()
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GridControl2.FocusedView.PostEditor()
    End Sub

    Public Overrides Sub Proc_SaveData()

        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(i, "Proses") = True Then
                    Dim bukti As String = suspen.autononb
                    ' suspen.SuspendID = suspendID
                    Dim ObjDetails As New cashbank_models
                    With ObjDetails
                        .Tgl = DateTime.Parse(GridView2.GetRowCellValue(i, "Tgl").ToString())
                        .NoBukti = bukti
                        .Transaksi = "Suspend"
                        .Keterangan = GridView2.GetRowCellValue(i, "Description").ToString().TrimEnd
                        .Keluar = GridView2.GetRowCellValue(i, "Amount")
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

        'Call SaveFromSuspend()
        Call SaveFromSettlement()
        Call DataCashBank()
        Call DataSuspend()
    End Sub

    Private Sub SaveFromSuspend()
        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(i, "Proses") = True Then
                    Dim bukti As String = suspen.autononb
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
                    Dim bukti As String = suspen.autononb
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
                        .InsertToTable2()

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
                        .InsertToTable2()
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
                    Dim bukti As String = suspen.autononb
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
End Class
