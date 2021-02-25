Imports DevExpress.XtraEditors.Controls

Public Class FrmLookupForecastDaily
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Property DtExcel As DataTable
    Private Sub FrmLookupForecastDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboTahun()
        FillComboBulan()
    End Sub
    ReadOnly Property Tahun As String
        Get
            Return CmbTahun.Text.Trim
        End Get
    End Property
    ReadOnly Property Bulan As Integer
        Get
            If CmbBulan.EditValue <> 0 Then
                Return CmbBulan.EditValue
            Else
                Return 0
            End If
        End Get
    End Property
    Private Sub FillComboBulan()
        Dim items =
        {
            New With {Key .Text = "", Key .Value = 0},
            New With {Key .Text = "Januari", Key .Value = 1},
            New With {Key .Text = "Februari", Key .Value = 2},
            New With {Key .Text = "Maret", Key .Value = 3},
            New With {Key .Text = "April", Key .Value = 4},
            New With {Key .Text = "Mei", Key .Value = 5},
            New With {Key .Text = "Juni", Key .Value = 6},
            New With {Key .Text = "Juli", Key .Value = 7},
            New With {Key .Text = "Agustus", Key .Value = 8},
            New With {Key .Text = "September", Key .Value = 9},
            New With {Key .Text = "Oktober", Key .Value = 10},
            New With {Key .Text = "November", Key .Value = 11},
            New With {Key .Text = "Desember", Key .Value = 12}
        }
        CmbBulan.Properties.DataSource = Nothing
        CmbBulan.Properties.DataSource = items
        CmbBulan.Properties.DisplayMember = "Text"
        CmbBulan.Properties.ValueMember = "Value"
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", (DateTime.Today.Year + 1).ToString, DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub TxtFile_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtFile.ButtonClick
        Try
            Dim Dialog As New OpenFileDialog
            Dialog.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = Dialog.ShowDialog()
            If result = System.Windows.Forms.DialogResult.OK Then
                Dim Filename As String = Dialog.FileName
                TxtFile.EditValue = Filename
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            If CmbTahun.Text = "" Then
                CmbTahun.Focus()
                Throw New Exception("Pilih Tahun !")
            ElseIf CmbBulan.EditValue = 0 Then
                CmbBulan.Focus()
                Throw New Exception("Pilih Bulan !")
            Else
                DtExcel = ExcelToDatatable(TxtFile.Text, "Table 1")
                Close()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class