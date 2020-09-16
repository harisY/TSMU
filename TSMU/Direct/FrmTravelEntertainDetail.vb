Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmTravelEntertainDetail
    Dim isUpdate As Boolean = False
    Dim fs_code As String
    Dim fs_codeTemp As String
    Dim FrmParent As Form
    Dim _isSave As Boolean
    Dim isLoad As Boolean = False
    Dim __EntertainID As String

    Dim ObjEntertainHeader = New EntertainHeaderModel
    Dim cls_TravelSett As New TravelSettleHeaderModel

    Dim CreditCardID As String = ""
    Dim AccountNameNBank As String = ""
    Dim PaymentType As String = "CASH"

    Dim header As New DataTable
    Dim entertain As New DataTable
    Dim relasi As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCodeTemp As Integer,
                   ByRef lf_FormParent As Form,
                   ByVal header_ As DataTable,
                   ByVal detail_ As DataTable,
                   ByVal relasi_ As DataTable)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_code = strCode
        Else
            fs_codeTemp = strCodeTemp.ToString()
        End If
        header = header_
        entertain = detail_
        relasi = relasi_
        FrmParent = lf_FormParent
    End Sub

    ReadOnly Property dtHeader() As DataTable
        Get
            Return header
        End Get
    End Property

    ReadOnly Property dtEntertain() As DataTable
        Get
            Return entertain
        End Get
    End Property

    ReadOnly Property dtRelasi() As DataTable
        Get
            Return relasi
        End Get
    End Property

    ReadOnly Property isSave As Boolean
        Get
            Return _isSave
        End Get
    End Property

    Private Sub FrmTravelEntertainDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoad = True
        Call InitialSetForm()
    End Sub

    Public Sub InitialSetForm()
        Try
            If fs_code <> "" Then
                isUpdate = True
                __EntertainID = fs_code
                Me.Text = "ENTERTAINMENT"
            Else
                __EntertainID = fs_codeTemp
                Me.Text = "NEW ENTERTAINMENT"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If isUpdate AndAlso header.Rows.Count > 0 Then
                TxtTgl.EditValue = header.Rows(0).Item("Tgl")
                TxtNoSettlement.Text = fs_code
                TxtPrNo.Text = IIf(header.Rows(0).Item("PRNo") Is DBNull.Value, "", header.Rows(0).Item("PRNo"))
                TxtDep.Text = IIf(header.Rows(0).Item("DeptID") Is DBNull.Value, "", header.Rows(0).Item("DeptID"))
                TxtCurrency.Text = IIf(header.Rows(0).Item("CuryID") Is DBNull.Value, "", header.Rows(0).Item("CuryID"))
                TxtTotExpense.Text = Format(header.Rows(0).Item("Total"), gs_FormatDecimal)
                TxtRemark.Text = IIf(header.Rows(0).Item("Remark") Is DBNull.Value, "", header.Rows(0).Item("Remark"))
                txtPayType.Text = IIf(header.Rows(0).Item("PaymentType").ToString.Contains("CC"), "CREDIT CARD", header.Rows(0).Item("PaymentType"))
                PaymentType = IIf(header.Rows(0).Item("PaymentType") Is DBNull.Value, "", header.Rows(0).Item("PaymentType"))
                CreditCardID = IIf(header.Rows(0).Item("CreditCardID") Is DBNull.Value, "", header.Rows(0).Item("CreditCardID"))
                txtCCNumber.EditValue = IIf(header.Rows(0).Item("CreditCardNumber") Is DBNull.Value, "", header.Rows(0).Item("CreditCardNumber"))
                AccountNameNBank = IIf(header.Rows(0).Item("AccountName") Is DBNull.Value, "", header.Rows(0).Item("AccountName"))
            Else
                TxtCurrency.Text = "IDR"
                TxtDep.Text = gh_Common.GroupID
                txtPayType.Text = "CASH"
                CreditCardID = ""
                txtCCNumber.EditValue = ""
                AccountNameNBank = ""
                PaymentType = txtPayType.Text
                TxtRemark.Text = ""
                TxtTgl.EditValue = DateTime.Today
                TxtTotExpense.Text = Format(0, gs_FormatDecimal)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            GridEntertain.DataSource = entertain
            GridRelasi.DataSource = relasi

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _isSave = True
            Dim rows As DataRow

            If isUpdate AndAlso header.Rows.Count > 0 Then
                For Each rows In header.Rows
                    rows("SettleID") = TxtNoSettlement.Text
                    rows("PRNo") = TxtPrNo.Text
                    rows("DeptID") = TxtDep.Text
                    rows("Remark") = TxtRemark.Text
                    rows("Tgl") = TxtTgl.EditValue
                    rows("CuryID") = TxtCurrency.Text
                    rows("Total") = TxtTotExpense.Text
                    rows("PaymentType") = PaymentType
                    rows("CreditCardID") = CreditCardID
                    rows("CreditCardNumber") = txtCCNumber.EditValue
                    rows("AccountName") = AccountNameNBank
                Next
            Else
                rows = header.NewRow
                rows("SettleID") = fs_codeTemp
                rows("PRNo") = TxtPrNo.Text
                rows("DeptID") = TxtDep.Text
                rows("Remark") = TxtRemark.Text
                rows("Tgl") = TxtTgl.EditValue
                rows("CuryID") = TxtCurrency.Text
                rows("Total") = TxtTotExpense.Text
                rows("PaymentType") = PaymentType
                rows("CreditCardID") = CreditCardID
                rows("CreditCardNumber") = txtCCNumber.EditValue
                rows("AccountName") = AccountNameNBank
                header.Rows.Add(rows)
            End If
            Me.Close()
        Catch ex As Exception
            _isSave = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick
        Try
            ObjEntertainHeader = New EntertainHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjEntertainHeader.GetAccount
            ls_OldKode = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account"))
            ls_Judul = "Account"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "Account", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub hitungTotal()
        Try
            Dim Total As Double = 0
            For i As Integer = 0 To GridViewEntertain.RowCount - 1
                If Not GridViewEntertain.GetRowCellValue(i, "Amount") Is DBNull.Value Then
                    Total = Total + GridViewEntertain.GetRowCellValue(i, "Amount")
                End If
            Next
            TxtTotExpense.Text = Format(Total, gs_FormatDecimal)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSubAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GSubAccount.ButtonClick
        Try
            ObjEntertainHeader = New EntertainHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            dtSearch = ObjEntertainHeader.GetSubAccount
            ls_OldKode = IIf(GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "SubAccount") Is DBNull.Value, "", GridViewEntertain.GetRowCellValue(GridViewEntertain.FocusedRowHandle, "SubAccount"))
            ls_Judul = "Sub Account"


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "SubAccount", Value1)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GSubAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GSubAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub ReposDate_EditValueChanged(sender As Object, e As EventArgs) Handles ReposDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            ObjEntertainHeader = New EntertainHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjEntertainHeader.GetDept
            ls_OldKode = TxtDep.Text
            ls_Judul = "Departement"


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                TxtDep.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs) Handles GAmount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        hitungTotal()
    End Sub

    Private Sub txtPayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtPayType.SelectedIndexChanged
        Try
            If isLoad = False Then
                Dim PayType As String

                Dim ls_OldKode As String = ""
                PayType = txtPayType.Text
                If PayType = "CREDIT CARD" Then
                    Dim ls_Judul As String = ""
                    Dim dtSearch As New DataTable

                    dtSearch = cls_TravelSett.GetCreditCard
                    ls_Judul = "CREDIT CARD"

                    Dim lF_SearchData As FrmSystem_LookupGrid
                    lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
                    lF_SearchData.HiddenCols = 0
                    lF_SearchData.Text = "Select Data " & ls_Judul
                    lF_SearchData.StartPosition = FormStartPosition.CenterScreen
                    lF_SearchData.ShowDialog()

                    If lF_SearchData.Values IsNot Nothing Then
                        CreditCardID = lF_SearchData.Values.Item(0).ToString.Trim
                        txtCCNumber.EditValue = lF_SearchData.Values.Item(1).ToString.Trim
                        AccountNameNBank = lF_SearchData.Values.Item(2).ToString.Trim + "-" + lF_SearchData.Values.Item(3).ToString.Trim
                        PaymentType = "CC-" + lF_SearchData.Values.Item(1).ToString.Trim
                    Else
                        PaymentType = "CASH"
                        txtPayType.Text = PaymentType
                    End If

                    lF_SearchData.Close()
                Else
                    CreditCardID = ""
                    txtCCNumber.EditValue = ""
                    AccountNameNBank = ""
                    PaymentType = PayType
                End If
            End If
            isLoad = False
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridEntertain_KeyDown(sender As Object, e As KeyEventArgs) Handles GridEntertain.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridViewEntertain.AddNewRow()
            GridViewEntertain.OptionsNavigation.AutoFocusNewRow = True
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "SettleID", __EntertainID)
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "SettleID", __EntertainID)
            GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount", 0)
            GridViewRelasi.AddNewRow()
            GridViewRelasi.OptionsNavigation.AutoFocusNewRow = True
            If isUpdate Then
                GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", fs_code)
            Else
                GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", fs_codeTemp)
            End If

        ElseIf e.KeyCode = Keys.Delete Then
            GridViewEntertain.DeleteRow(GridViewEntertain.FocusedRowHandle)
            GridViewEntertain.RefreshData()
            hitungTotal()
        End If
    End Sub

    Private Sub GridEntertain_DoubleClick(sender As Object, e As EventArgs) Handles GridEntertain.DoubleClick
        GridViewEntertain.AddNewRow()
        GridViewEntertain.OptionsNavigation.AutoFocusNewRow = True
        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "SettleID", __EntertainID)
        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "SettleID", __EntertainID)
        GridViewEntertain.SetRowCellValue(GridViewEntertain.FocusedRowHandle, "Amount", 0)
        GridViewRelasi.AddNewRow()
        GridViewRelasi.OptionsNavigation.AutoFocusNewRow = True
        If isUpdate Then
            GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", fs_code)
        Else
            GridViewRelasi.SetRowCellValue(GridViewRelasi.FocusedRowHandle, "SettleID", fs_codeTemp)
        End If
    End Sub

End Class