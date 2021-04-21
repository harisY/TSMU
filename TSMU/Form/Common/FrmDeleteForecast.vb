﻿Imports System.Configuration
Imports System.Data.OleDb
Imports DevExpress.XtraEditors.Controls

Public Class FrmDeleteForecast
    Dim fc_class As New clsSales_Budget
    Dim GridData As DataTable = Nothing
    Dim Gridfilter As DataTable = Nothing
    Dim a As Integer = 0
    Dim b As Integer = 0
    Dim _isSync As Boolean
    Dim _Caller As Integer
    Dim _IsCancel As Boolean = True
    Public Property DtAdm As DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByRef dt As DataTable, ByVal x As Integer, Caller As Integer, Optional ByVal IsSync As Boolean = False)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
        a = x
        _isSync = IsSync
        _Caller = Caller
    End Sub

    ReadOnly Property IsCancel As Boolean
        Get
            Return _IsCancel
        End Get
    End Property

    ReadOnly Property Tahun As String
        Get
            Return _cmbTahun.Text.Trim
        End Get
    End Property

    ReadOnly Property Tahun1 As String
        Get
            Return TxtTahun2.Text.Trim
        End Get
    End Property

    ReadOnly Property Customer As String
        Get
            Return _cmbCust.Text.Trim
        End Get
    End Property

    ReadOnly Property _Site As String
        Get
            Return _CmbSite.Text.Trim
        End Get
    End Property

    ReadOnly Property Flag As String
        Get
            Return _CmbFlag.Text.Trim
        End Get
    End Property

    ReadOnly Property Bulan As String
        Get
            If _cmbBulan.EditValue <> "" Then
                If _cmbBulan.Text.ToLower.Trim = "agustus" Then
                    Dim _bulan As String = ""
                    _bulan = Replace(Microsoft.VisualBasic.Left(_cmbBulan.Text.Trim, 3), "u", "t")
                    Return _bulan
                Else
                    Return Microsoft.VisualBasic.Left(_cmbBulan.Text.Trim, 3)
                End If
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property BulanAngka As String
        Get
            If _cmbBulan.EditValue <> "" Then
                Return _cmbBulan.EditValue.Trim
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property tab As Integer
        Get
            Return XtraTabControl1.SelectedTabPageIndex
        End Get
    End Property

    Private Sub FrmSystemExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboTahun()
        FillComboCustomer()
        FillComboBulan()
        lblStatus.Text = ""
        FillComboSite()
        FillComboFlag()
    End Sub

    Private Sub FillComboTahun()
        Dim tahun() As String = {"", (DateTime.Today.Year + 1).ToString, DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        _cmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            _cmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboTahun1()
        Dim tahun() As String = {"", (DateTime.Today.Year + 1).ToString, DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString}
        TxtTahun2.Properties.Items.Clear()
        For Each var As String In tahun
            TxtTahun2.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboSite()
        Dim tahun() As String = {"", "TNG-U", "TSC3-U"}
        _CmbSite.Properties.Items.Clear()
        For Each var As String In tahun
            _CmbSite.Properties.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboFlag()
        Dim tahun() As String = {"N/A", "ADMSPD", "KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"}
        _CmbFlag.Properties.Items.Clear()
        For Each var As String In tahun
            _CmbFlag.Properties.Items.Add(var)
        Next
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
        _cmbBulan.Properties.DataSource = Nothing
        _cmbBulan.Properties.DataSource = items
        _cmbBulan.Properties.DisplayMember = "Text"
        _cmbBulan.Properties.ValueMember = "Value"
    End Sub

    Private Sub FillComboCustomer()
        Dim dtTabel As New DataTable
        dtTabel = fc_class.getCusstID_Solomon
        Dim dr As DataRow = dtTabel.NewRow
        dr("CustId") = ""
        dtTabel.Rows.InsertAt(dr, 0)
        _cmbCust.Properties.Items.Clear()
        For i As Integer = 0 To dtTabel.Rows.Count - 1
            _cmbCust.Properties.Items.Add(dtTabel.Rows(i)("CustId"))
        Next
    End Sub

    Dim path As String
    Dim path2 As String

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub _btnExport_Click(sender As Object, e As EventArgs) Handles _btnExport.Click
        Try
            If _cmbTahun.Text = "" Then
                _cmbTahun.Focus()
                Throw New Exception("Pilih Tahun !")
            End If
            If _cmbBulan.Text = "" Then
                _cmbBulan.Focus()
                Throw New Exception("Pilih Bulan !")
            End If
            If _cmbCust.Text = "" Then
                _cmbCust.Focus()
                Throw New Exception("Pilih Customer !")
            End If
            If _CmbSite.Text = "" Then
                _CmbSite.Focus()
                Throw New Exception("Pilih Site !")
            End If
            If _CmbFlag.Text = "" Then
                _CmbFlag.Focus()
                Throw New Exception("Pilih Flag !")
            End If
            _IsCancel = False
            Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub TxtFile2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtFile2.ButtonClick
        Try
            OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            ' Test result.
            If result = System.Windows.Forms.DialogResult.OK Then
                path2 = OpenFileDialog1.FileName
                'path = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                'MsgBox(path)
                Dim text As String = System.IO.File.ReadAllText(path2)
                TxtFile2.Text = path2
                'Me.Text = text.Length.ToString
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class