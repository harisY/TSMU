Imports System.Text
Imports CsvHelper
Imports ExcelLibrary
Imports System.Data.OleDb
Public Class FrmPOADM
    Dim fc_Class As New clscompare
    Dim dtGrid As DataTable
    Dim tblImport As DataTable
    Private Sub FrmPOADM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, True, False, False, False, True, True)
        '' _cmbperpost.Text = Year(Today) & Month(Today)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fName As String = ""
        OpenFileDialog1.InitialDirectory = "D:\"
        ' OpenFileDialog1.Filter = "CSV files(*.csv)|*.csv"
        OpenFileDialog1.Filter = "Excel 97-2003|*.xls|Excel 2007|*.xlsx"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If (OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            fName = OpenFileDialog1.FileName
        End If
        Dim SheetName As String = "Sheet1$"
        _txtFileLocation.Text = fName
        'csv()
        LoadExcel2Grid(_txtFileLocation.Text, SheetName)
    End Sub

    Sub LoadExcel2Grid(ByVal FileName As String, ByVal SheetName As String)
        Dim exConn As OleDbConnection
        Dim dt As DataSet
        Dim cmd As OleDbDataAdapter

        Dim sConn As String
        sConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
            FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

        exConn = New System.Data.OleDb.OleDbConnection(sConn)
        cmd = New System.Data.OleDb.OleDbDataAdapter(
          "select * from [" & SheetName & "]", exConn)
        cmd.TableMappings.Add("Table", SheetName)
        dt = New System.Data.DataSet
        cmd.Fill(dt)
        tblImport = dt.Tables(0)
        DataGridView1.DataSource = tblImport

        exConn.Close()
    End Sub
    Public Sub csv()
        '  Using reader = New StreamReader("C:\Users\firman\Desktop\yimvol1.csv")
        Using reader = New System.IO.StreamReader(_txtFileLocation.Text, Encoding.ASCII)

            Using csv = New CsvReader(reader)

                Using dr = New CsvDataReader(csv)
                    Dim dt = New DataTable()
                    dt.Load(dr)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        End Using

    End Sub
    Public Overrides Sub Proc_SaveData()
        fc_Class.txtFileLocation = txtFileLocation.Text

        '' fc_Class.Delete()
        ''   fc_Class.perpost = _cmbperpost.Text
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                '     Dim tglx As DateTime = Format(Date.Now(), "yyyy-MM-dd")
                ' Using cmd As New SqlCommand("INSERT INTO cashbank (tgl,nobukti,transaksi,keterangan,keluar,noref,perpost,acctid) VALUES ('" & Trim(tglx) & "','" & bukti & "','Suspend','" & DataGridView1.Rows(i).Cells(2).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & _perpost.Text & "','" & _acctid.Text & "')", con)
                Dim ObjDetails As New clscompare
                With ObjDetails
                    .g0 = DataGridView1.Rows(i).Cells(0).Value
                    .g1 = DataGridView1.Rows(i).Cells(1).Value
                    .g2 = DataGridView1.Rows(i).Cells(2).Value
                    .g3 = DataGridView1.Rows(i).Cells(3).Value
                    .g4 = DataGridView1.Rows(i).Cells(4).Value
                    .g5 = DataGridView1.Rows(i).Cells(5).Value
                    .g6 = DataGridView1.Rows(i).Cells(6).Value
                    .g7 = DataGridView1.Rows(i).Cells(7).Value
                    .g8 = DataGridView1.Rows(i).Cells(8).Value
                    .g9 = DataGridView1.Rows(i).Cells(9).Value
                    .g10 = DataGridView1.Rows(i).Cells(10).Value
                    .g11 = DataGridView1.Rows(i).Cells(11).Value

                    .txtFileLocation = _txtFileLocation.Text
                    '      fc_Class.cmbperpost = _cmbperpost.Text
                    .Insert2()
                End With
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Data Tersimpan")
        ''   Call LoadGrid2()
    End Sub
End Class
