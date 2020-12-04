﻿Imports System.Text
Imports CsvHelper
Imports ExcelLibrary
Imports System.Data.OleDb
Public Class FrmPOYIM
    Dim fc_Class As New clscompare
    Dim dtGrid As DataTable
    Dim tblImport As DataTable
    Private Sub FrmPOYIM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Grid.DataSource = Nothing

        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)

    End Sub
    Private Sub LoadGrid()
        Try
            fc_Class = New clscompare
            dtGrid = fc_Class.GetDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                ''   .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
            End With
            GridCellFormat(GridView1)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If _txtordnbr.Text = "" Then
            MsgBox("ISI LAST ORDER NUMBER DULU")
            Return
        Else

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
        End If
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
        '  Grid.DataSource = tblImport
        exConn.Close()
        ''     Proc_SaveData()
        LoadGrid()
        nomerorder()
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
        fc_Class.Delete2YIM()
        '' fc_Class.Delete()
        ''   fc_Class.perpost = _cmbperpost.Text
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                '     Dim tglx As DateTime = Format(Date.Now(), "yyyy-MM-dd")
                ' Using cmd As New SqlCommand("INSERT INTO cashbank (tgl,nobukti,transaksi,keterangan,keluar,noref,perpost,acctid) VALUES ('" & Trim(tglx) & "','" & bukti & "','Suspend','" & DataGridView1.Rows(i).Cells(2).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "','" & DataGridView1.Rows(i).Cells(1).Value & "','" & _perpost.Text & "','" & _acctid.Text & "')", con)
                Dim ObjDetails As New clscompare
                With ObjDetails
                    .g0 = If(DataGridView1.Rows(i).Cells(5).Value Is DBNull.Value, "", DataGridView1.Rows(i).Cells(5).Value)
                    .g1 = If(DataGridView1.Rows(i).Cells(9).Value Is DBNull.Value, "", DataGridView1.Rows(i).Cells(9).Value)
                    '' .g2 = DataGridView1.Rows(i).Cells(12).Value
                    .g2 = If(DataGridView1.Rows(i).Cells(12).Value Is DBNull.Value, "", DataGridView1.Rows(i).Cells(12).Value)
                    .g3 = If(DataGridView1.Rows(i).Cells(13).Value Is DBNull.Value, "", DataGridView1.Rows(i).Cells(13).Value)
                    .g4 = DataGridView1.Rows(i).Cells(16).Value
                    .g5 = If(DataGridView1.Rows(i).Cells(7).Value Is DBNull.Value, "", Convert.ToString(DataGridView1.Rows(i).Cells(7).Value))
                    .g7 = If(DataGridView1.Rows(i).Cells(8).Value Is DBNull.Value, "", Convert.ToString(DataGridView1.Rows(i).Cells(8).Value))
                    .g8 = .g5 + "/" + .g7

                    .g6 = If(DataGridView1.Rows(i).Cells(15).Value Is DBNull.Value, "LEAD TIME", Convert.ToString(DataGridView1.Rows(i).Cells(15).Value))

                    '.g3 = DataGridView1.Rows(i).Cells(13).Value
                    '.g4 = DataGridView1.Rows(i).Cells(16).Value
                    '.g5 = DataGridView1.Rows(i).Cells(7).Value

                    '.g6 = DataGridView1.Rows(i).Cells(8).Value


                    .txtFileLocation = _txtFileLocation.Text
                    '      fc_Class.cmbperpost = _cmbperpost.Text
                    .Insert2YIM()
                End With
            Next i
            fc_Class.Update2YIM()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Data Tersimpan")
        ''   Call LoadGrid2()
    End Sub
    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub
    Private Sub Proc_Excel()
        Try

            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid)
                MsgBox("Data Sudah Berhasil Di Export.")
            Else
                MsgBox("Grid Kosong!")
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub nomerorder()
        Dim nbr As String = ""
        nbr = Microsoft.VisualBasic.Right(_txtordnbr.Text, 4)
        Dim vpo As String = ""
        For b As Integer = 0 To GridView1.RowCount - 1
            Dim vordnbr As Integer = 0
            vpo = GridView1.GetRowCellValue(b, "PO")
            If b = 0 Then
                GridView1.SetRowCellValue(b, "Ordnbr", CDbl(nbr))
                GridView1.SetRowCellValue(b, "Nom", 1)
            Else
                If GridView1.GetRowCellValue(b, "PO").ToString <> GridView1.GetRowCellValue(b - 1, "PO").ToString Then
                    GridView1.SetRowCellValue(b, "Ordnbr", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Ordnbr")) + 1)
                Else
                    GridView1.SetRowCellValue(b, "Ordnbr", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Ordnbr")))
                End If
                GridView1.SetRowCellValue(b, "Nom", Convert.ToDouble(GridView1.GetRowCellValue(b - 1, "Nom")) + 1)
            End If

        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For i As Integer = 0 To GridView1.RowCount - 1

            With fc_Class
                .ordnbr = CStr(GridView1.GetRowCellValue(i, "Ordnbr"))
                .PO = CStr(GridView1.GetRowCellValue(i, "PO"))
                .nom = CStr(GridView1.GetRowCellValue(i, "Nom"))
                .Updateordnbr()

            End With
            fc_Class.Updatenom()
        Next
        fc_Class.periode = _txtperiode.Text

        fc_Class.Updatesonbr()
        LoadGrid()
    End Sub
End Class
