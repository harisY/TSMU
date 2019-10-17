Imports DevExpress.XtraEditors
Imports System.Globalization
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmDetailPaymentDirect
    Dim ObjCashBank As New cashbank_models
    Dim _NoBukti As String

    Sub New(NoBukti As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = NoBukti
    End Sub
    Private Sub DataCashBank()
        Dim dtGrid As New DataTable
        'ObjCashBank.Perpost = _txtperpost.Text
        'ObjCashBank.AcctID = _txtaccount.Text
        dtGrid = ObjCashBank.GetGridDetailCashBankByAccountID03(_NoBukti)
        GridControl1.DataSource = dtGrid
        GridCellFormat(GridView1)

    End Sub

    Private Sub FrmDetailPaymentDirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataCashBank()
        GetTot2()
    End Sub

    Private Sub BtnRefNo_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles BtnRefNo.ButtonClick

        Try
            Dim newform As New FrmReportSettle
            Dim stext As String
            newform.StartPosition = FormStartPosition.CenterScreen
            For i As Integer = 0 To GridView1.RowCount - 1
                stext = GridView1.GetRowCellValue(i, "Noref")
                stext = Replace(stext, " / ", "")
                newform.TxtNosettle.Text = stext
            Next
            newform.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub GetTot2()
        Dim TotAmount As Double = 0

        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "SettleAmount"))
            Next

            If TotAmount = 0 Then
                LblTotAmount2.Text = "0"
            Else
                LblTotAmount2.Text = Format(TotAmount, gs_FormatBulat)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




End Class