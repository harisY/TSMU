Imports Microsoft.Office.Interop
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Imports System.IO
Imports ExcelDataReader
Imports GemBox.Spreadsheet
Imports System.Data.OleDb

Public Class FormPaintingProduksi_Detail_CKR

    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim fc_Class As New PaintingProduksiModel_CKR

    'Dim fc_Class_Material_Detail As New PaintingProduksiModel_CKR

    'Dim fc_Class_Komponen_Detail As New PemakaianKomponenlDetail_CKR

    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim Total As Double

    Dim FileLokasi As String
    Dim sheet As String
    Dim CellValue As String
    Dim TotalPriceMaterial As Double

    Dim KolomQty As String
    Dim KolomHarga As String

    Dim BarisMaterial1 As String
    Dim BarisMAterial2 As String
    Dim BarisKompone1 As String
    Dim BarisKomponen2 As String
    Dim KodeTran As String = ""
    Dim _Tag As TagModel

    Dim dt As DataTable
    Dim dtScrap As DataTable
    Dim dtDetailScrap As DataTable
    Dim dtProblemQty As DataTable
    Dim dtProblemAnalisa As DataTable

    Dim KolomTanggal As String = ""
    Dim KolomTanggalScrap As String = ""
    Dim KolomTanggalScrapDetail As String = ""


    Private TabelExcel As DataTableCollection


    Private Sub FormPaintingProduksi_Detail_CKR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
               ByVal strCode2 As String,
                  ByRef lf_FormParent As Form,
                  ByVal li_GridRow As Integer,
                  ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
            KodeTran = fs_Code
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Public Sub GetKolom()
        Dim Kolom As Integer
        Kolom = Convert.ToInt64(Format(dtTanggal.Value, "dd"))

        KolomTanggal = "F" & ((Kolom + 1)).ToString
        KolomTanggalScrap = "F" & ((Kolom + 2)).ToString
        KolomTanggalScrapDetail = "F" & ((Kolom + 2)).ToString
    End Sub


    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                'fc_Class.getDataByID(fs_Code)
                'If ls_Error <> "" Then
                '    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                '    isCancel = True
                '    Me.Hide()
                '    Exit Sub
                'Else
                '    isUpdate = True
                'End If
                isUpdate = True
                Me.Text = "Painting " & fs_Code
            Else
                Me.Text = "Painting"
            End If
            'Call LoadTxtBox()
            'Call LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmPaintingProduksi_CKR"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then

                'Dim dtGridMaterial As New DataTable
                'dtGridMaterial = fc_Class.GetDataDetailMaterial(fs_Code)
                'GridMaterial.DataSource = dtGridMaterial

                'Dim dtGridKomponen As New DataTable
                'dtGridKomponen = fc_Class.GetDataDetailKomponen(fs_Code)
                'GridKomponen.DataSource = dtGridKomponen


            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnUploadExcel_Click(sender As Object, e As EventArgs) Handles BtnUploadExcel.Click

        Dim tanggal As Date = Format(dtTanggal.Value, "yyyy-MM-dd")
        dt = New DataTable
        ProgressBar1.Value = 0
        TxtFileName.Text = ""
        Timer1.Stop()
        GetKolom()
        Dim StraightPass As String = "STR_PASS$B5:AZ63"
        Dim Scrap As String = "Scrap$A4:AZ7"
        Dim ScrapDetail As String = "ScrapDetail$A8:AZ1000"
        Dim problemQty As String = "problem$A5:Z1000"
        Dim problemAnalisa As String = "problem$A5:Z1000"




        'Dim tanggalTransaksi As Date = Format(dtTanggal.Value, "yyyy-MM-dd")
        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files|*.xls;*.xlsx"}

            If ofd.ShowDialog() = DialogResult.OK Then
                FileLokasi = ofd.FileName
                TxtFileName.Text = FileLokasi

                If IO.File.Exists(FileLokasi) Then

                    Dim cb As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cb.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cn As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cb.ConnectionString}
                    cn.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggal & " as Nilai FROM [" & StraightPass & "]", cn) '
                    'Dim dtLimaBesar As New DataTable
                    dt = New DataTable
                    dt.Load(cmd.ExecuteReader)


                    Dim cbSCRAP As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbSCRAP.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnSCRAP As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbSCRAP.ConnectionString}
                    cnSCRAP.Open()
                    Dim cmdScrap As OleDbCommand = New OleDbCommand("SELECT F1 as Description," & KolomTanggalScrap & " as Nilai FROM [" & Scrap & "]", cnSCRAP) '
                    'Dim dtLimaBesar As New DataTable
                    dtScrap = New DataTable
                    dtScrap.Load(cmdScrap.ExecuteReader)


                    Dim cbScrapDetail As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbScrapDetail.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnSCRAPDetail As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbScrapDetail.ConnectionString}
                    cnSCRAPDetail.Open()
                    Dim cmdScrapDetail As OleDbCommand = New OleDbCommand("SELECT F1 as InvtID,F2 as InvtName," & KolomTanggalScrapDetail & " as Nilai FROM [" & ScrapDetail & "] Where F1 <>'' and " & KolomTanggalScrapDetail & " <> Null", cnSCRAPDetail) '
                    'Dim dtLimaBesar As New DataTable
                    dtDetailScrap = New DataTable
                    dtDetailScrap.Load(cmdScrapDetail.ExecuteReader)


                    Dim cbProblemQty As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbProblemQty.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnProblemQty As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbProblemQty.ConnectionString}
                    cnProblemQty.Open()
                    'Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3 FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <>''", cnProblemQty) '
                    Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT * FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <> Null ", cnProblemQty)
                    'Dim dtLimaBesar As New DataTable
                    dtProblemQty = New DataTable
                    dtProblemQty.Load(cmdProblemQty.ExecuteReader)


                    Dim cbProblemAnalisa As New OleDbConnectionStringBuilder With {.DataSource = FileLokasi, .Provider = "Microsoft.ACE.OLEDB.12.0"}  'Microsoft.ACE.OLEDB.12.0     Microsoft.Jet.OLEDB.4.0
                    cbProblemAnalisa.Add("Extended Properties", "Excel 8.0; IMEX=1; HDR=No;")
                    Dim cnProblemAnalisa As New System.Data.OleDb.OleDbConnection With {.ConnectionString = cbProblemQty.ConnectionString}
                    cnProblemAnalisa.Open()
                    'Dim cmdProblemQty As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3 FROM [" & problemQty & "] where F1 = #" & tanggal & "# and F2 <>''", cnProblemQty) '
                    Dim cmdProblemAnalisa As OleDbCommand = New OleDbCommand("SELECT F1,F2,F3,F4,F20,F21,F22,F23,F24,F25 FROM [" & problemAnalisa & "] where F1 = #" & tanggal & "# ", cnProblemAnalisa)
                    'Dim dtLimaBesar As New DataTable
                    dtProblemAnalisa = New DataTable
                    dtProblemAnalisa.Load(cmdProblemAnalisa.ExecuteReader)
                    'Call SetDataStraightPass()
                    'Call SetDataScrap()
                    'Call SetDataScrapDetail()
                    'Call SetDataProblemQty()
                    'Call SetDataProblemAnalisa()
                    cn.Close()
                    cnSCRAP.Close()
                    cnSCRAPDetail.Close()
                    cnProblemQty.Close()
                    cnProblemAnalisa.Close()

                    GridStraightPass.DataSource = dt
                    GridScrap.DataSource = dtScrap
                    GridDetailScrap.DataSource = dtDetailScrap
                    GridProblemQty.DataSource = dtProblemQty
                    GridAnalisaProblem.DataSource = dtProblemAnalisa

                    'Dim dt As DataTable
                    'Dim dtScrap As DataTable
                    'Dim dtDetailScrap As DataTable
                    'Dim dtProblemQty As DataTable
                    'Dim dtProblemAnalisa As DataTable


                    Timer1.Start()
                End If

            End If
        End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(10)
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
        End If
    End Sub
End Class
