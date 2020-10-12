Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraSplashScreen

Public Class FrmBulan
    Dim GridData As DataTable = Nothing
    'Dim ObjHeader As New forecast_price_models_header
    Dim ObjHeader As New forecast_po_model
    Dim ObjForecast As New forecast_po_model_detail 'forecast_price_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub FrmSystemExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBulan()
    End Sub

    Private Sub FillComboBulan()

        Dim items = {New With {Key .Text = "Januari", Key .Value = "01"},
                    New With {Key .Text = "Februari", Key .Value = "02"},
                    New With {Key .Text = "Maret", Key .Value = "03"},
                    New With {Key .Text = "April", Key .Value = "04"},
                    New With {Key .Text = "Mei", Key .Value = "05"},
                    New With {Key .Text = "Juni", Key .Value = "06"},
                    New With {Key .Text = "Juli", Key .Value = "07"},
                    New With {Key .Text = "Agustus", Key .Value = "08"},
                    New With {Key .Text = "September", Key .Value = "09"},
                    New With {Key .Text = "Oktober", Key .Value = "10"},
                    New With {Key .Text = "November", Key .Value = "11"},
                    New With {Key .Text = "Desember", Key .Value = "12"}
        }
        _CmbBulan.Properties.DataSource = Nothing
        _CmbBulan.Properties.DataSource = items
        _CmbBulan.Properties.DisplayMember = "Text"
        _CmbBulan.Properties.ValueMember = "Value"
    End Sub

    Public Property Bulan() As String

    Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
        Try

            If _CmbBulan.Text = "" Then
                _CmbBulan.Focus()
                Throw New Exception("Pilih Bulan !")
            End If
            Bulan = _CmbBulan.EditValue
            Close()
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class