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
    Sub New(NoBukti As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _NoBukti = NoBukti
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
        DataCashBank()
    End Sub
End Class