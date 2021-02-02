Imports DevExpress.XtraSplashScreen

Public Class frmReport_Forecast_PO
    Dim dtGrid As DataTable
    Dim service As clsReport
    Private Initializing As Boolean = False

    Sub New()
        Initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmReport_Forecast_PO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        FillComboTahun()
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            service = New clsReport
            dtGrid = New DataTable
            dtGrid = service.POForecastByMonth_report(_CmbTahun.Text, TxtBulan.Text, TxtCustomer.Text)
            If dtGrid.Rows.Count > 0 Then
                GridPO.DataSource = dtGrid
                With GridView1
                    .BestFitColumns()
                End With

                GridCellFormat(GridView1)
            Else
                Throw New Exception($"Data Tahun '{_CmbTahun.Text}' Bulan '{TxtBulan.Text}' Customer '{TxtCustomer.Text}' tidak ditemukan.")
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Try
            If _CmbTahun.EditValue = "" Then
                Throw New Exception("SIlahkan pilih tahun !")
            End If
            If TxtBulan.Text = "" Then
                TxtBulan.Focus()
                Throw New Exception("Pilih Bulan !")
            End If
            If TxtCustomer.Text = "" Then
                TxtCustomer.Focus()
                Throw New Exception("Customer ID tidak boleh kosong")
            End If
            Call LoadGrid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Private Sub ExportToExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(GridPO)
        Else
            MsgBox("Data Kosong !")
        End If

    End Sub

    Private Sub GridPO_MouseDown(sender As Object, e As MouseEventArgs) Handles GridPO.MouseDown
        'If e.Button = System.Windows.Forms.MouseButtons.Right Then
        '    ContextMenuStrip1.Show(e.Location)
        'End If
    End Sub

    Private Sub FillComboTahun()
        Dim tahun() As Integer = {Date.Today.Year - 1, Date.Today.Year, Date.Today.Year + 1}
        _CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            _CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub _CmbTahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _CmbTahun.SelectedIndexChanged, TxtBulan.SelectedIndexChanged
        If Initializing Then
            Exit Sub
        End If
        If TxtBulan.Text <> "" AndAlso TxtCustomer.Text <> "" AndAlso _CmbTahun.Text <> "" Then
            LoadGrid()
        End If
    End Sub

    Private Sub frmReport_Forecast_PO_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False
    End Sub

    Private Sub TxtBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBulan.KeyPress
        'Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If TxtBulan.Text <> "" AndAlso TxtCustomer.Text <> "" Then
        '        LoadGrid()
        '    End If
        'End If
        e.Handled = True
    End Sub

End Class