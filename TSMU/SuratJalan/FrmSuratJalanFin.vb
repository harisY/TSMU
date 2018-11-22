Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmSuratJalanFin
    Dim ObjSj As clsSJ
    Dim Username As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ObjSj = New clsSJ
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmSuratJalanFin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrid()
        Call Proc_EnableButtons(True, True, False, True, True, False, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            Dim dt As New DataTable
            ObjSj.NoTran = _TxtNo.Text
            dt = ObjSj.GetSJbyNoTran
            _Grid1.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        _Grid1.DataSource = Nothing
        _TxtNo.Text = ""
        _TxtNo.Focus()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If GridView2.RowCount = 0 Then
                Throw New Exception("Tidak ada data yang akan di simpan.")
            End If

            For i As Integer = 0 To GridView2.RowCount - 1
                'Dim Checked As Boolean = False
                Dim ShipperID As String
                'Dim TglTerimaFin As DateTime

                ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                'TglTerimaFin = IIf(GridView2.GetRowCellValue(i, GridView2.Columns("Tgl Check Fin")) Is DBNull.Value, DateTime.Now, (GridView2.GetRowCellValue(i, GridView2.Columns("Tgl Check Fin"))))
                'Checked = GridView2.GetRowCellValue(i, "Check")
                Try
                    With ObjSj
                        .ShipperID = ShipperID
                        .TglCheckFin = DateTime.Today
                        .CheckFIn = 1
                        .CreatedBy = Username
                        .UpdateFin()
                    End With
                    'End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Continue For
                End Try
            Next
            'btnFilter.Enabled = False
            LoadGrid()
            MsgBox("Data Saved !", MsgBoxResult.No)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub RepositoryItemDateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.EditValueChanged
        _Grid1.FocusedView.PostEditor()
    End Sub

    Private Sub _TxtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles _TxtNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                LoadGrid()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSuratJalanFin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _TxtNo.Focus()
    End Sub
End Class
