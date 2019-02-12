Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class frmCalculate
    Dim dtGrid As DataTable
    Dim dataTB As DataTable
    Dim ObjSales As New clsSalesForecastCalculate
    Dim ObjSalesdetail As New clsCalculateBoMdetail
    Friend Delegate Sub SetDataSourceDelegate(table As DataTable)
    Dim Bulan1 As Integer
    Dim Bulan2 As Integer
    Dim strTahun As String

    Dim jan As Single
    Dim feb As Single
    Dim mar As Single
    Dim apr As Single
    Dim mei As Single
    Dim jun As Single
    Dim jul As Single
    Dim agt As Single
    Dim sep As Single
    Dim okt As Single
    Dim nov As Single
    Dim des As Single
    Dim bomidH1 As String
    Dim janPO As Single
    Dim febPO As Single
    Dim marPO As Single
    Dim aprPO As Single
    Dim meiPO As Single
    Dim junPO As Single
    Dim julPO As Single
    Dim agtPO As Single
    Dim sepPO As Single
    Dim oktPO As Single
    Dim novPO As Single
    Dim desPO As Single
    Dim inv As String

    Private Sub frmCalculate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBulan()
        FillComboTahun()
    End Sub
    Private Sub FillHeader_fdtlConfig1()
        dataTB = New DataTable
        dataTB.Columns.Add("Level 0")
        dataTB.Columns.Add("Level 1")
        dataTB.Columns.Add("Level 2")
        dataTB.Columns.Add("Level 3")
        dataTB.Columns.Add("Level 4")
        dataTB.Columns.Add("Level 5")
        dataTB.Columns.Add("Level 6")
        dataTB.Columns.Add("Level 7")
        dataTB.Columns.Add("Description")
        dataTB.Columns.Add("Qty")
        dataTB.Columns.Add("Unit")
        dataTB.Clear()
    End Sub
    Public Enum IndexCol1 As Byte
        Level0 = 0
        Level1 = 1
        Level2 = 2
        Level3 = 3
        Level4 = 4
        Level5 = 5
        Level6 = 6
        Level7 = 7
        desc = 8
        qty = 9
        unit = 10
    End Enum
    Private Sub setDataSource(table As DataTable)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)
        Else
            Grid.DataSource = table
        End If
    End Sub
    Private Sub FillComboBulan()
        Dim tahun() As String = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "November", "Desember"}
        CmbBulan1.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan1.Properties.Items.Add(var)
        Next

        CmbBulan2.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan2.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            CmbTahun.Properties.Items.Add(var)
        Next
    End Sub

    Private Async Sub BtnProses_Click(sender As Object, e As EventArgs) Handles BtnProses.Click
        Try

            Await Task.Run(Sub() LoadData())
            'LoadData()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            'SplashScreenManager.Default.SetWaitFormCaption("")
            Dim dt As New DataTable
            dt = ObjSales.GetBomToCalculate
            FillHeader_fdtlConfig1()

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)(0).ToString = "Level 0" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level0) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 1" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level1) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 2" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level2) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 3" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level3) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 4" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level4) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 5" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level5) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 6" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level6) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
                If dt.Rows(i)(0).ToString = "Level 7" Then
                    dataTB.Rows.Add()
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.Level7) = Trim(dt.Rows(i).Item("invtid") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.desc) = Trim(dt.Rows(i).Item("descr") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.qty) = Trim(dt.Rows(i).Item("qty") & "")
                    dataTB.Rows(dataTB.Rows.Count - 1).Item(IndexCol1.unit) = Trim(dt.Rows(i).Item("unit") & "")
                End If
            Next
            setDataSource(dataTB)
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Private Async Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try

            Await Task.Run(Sub() CalculatedBoM())
            MsgBox("Process Done !")

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub CalculatedBoM()
        Try
            Dim Id As Integer = 0
            Invoke(Sub()
                       Bulan1 = CmbBulan1.SelectedIndex
                       Bulan2 = CmbBulan2.SelectedIndex
                       strTahun = CmbTahun.Text

                       If strTahun = "" Then
                           CmbTahun.Focus()
                           Throw New Exception("Silahkan pilih tahun !")
                       End If
                       If CmbSales.Text = "" Then
                           CmbSales.Focus()
                           Throw New Exception("Pilih Sales !")
                       End If
                       If CmbBulan1.Text = "" Then
                           CmbBulan1.Focus()
                           Throw New Exception("Pilih Bulan !")
                       End If
                       If CmbBulan2.Text = "" Then
                           CmbBulan2.Focus()
                           Throw New Exception("Pilih Bulan !")
                       End If
                       If CmbBulan1.SelectedIndex > CmbBulan2.SelectedIndex Then
                           CmbBulan1.Focus()
                           Throw New Exception("Range bulan salah !")
                       End If
                   End Sub)
            If GridView1.RowCount = 0 Then
                Throw New Exception("Grid kosong, Load data terlebih dahulu !")
            End If

            'Hitung Forecast terhadap BOM
            If CmbSales.SelectedIndex = 0 Then
                Dim IsBudgetAlreadyCalculated As Boolean
                IsBudgetAlreadyCalculated = ObjSales.IsForecastSemester1Exist(strTahun, Bulan1, Bulan2)
                If IsBudgetAlreadyCalculated Then
                    If MsgBox("Forecast untuk Tahun " & strTahun & " dan Bulan " & Bulan1 & "/" & "" & Bulan2 & " sudah di hitung, Calculate ulang ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi") = MsgBoxResult.Yes Then
                        ObjSales.DeleteForecastByYearAndSemester(strTahun, Bulan1, Bulan2)
                        If Bulan1 = 1 And Bulan2 = 1 Then
                            Dim dt As New DataTable
                            dt = ObjSales.GetForecastToCalculate(Bulan1, Bulan2)
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    If Bulan1 = 1 And Bulan2 = 1 Then
                        Dim dt As New DataTable
                        dt = ObjSales.GetForecastToCalculate(Bulan1, Bulan2)

                        For i As Integer = 0 To dataTB.Rows.Count - 1
                            Dim bomidH As String = ""
                            Dim invtid As String = ""
                            Dim descr As String = ""
                            Dim unit As String = ""
                            Dim qty As Single = 0
                            Dim level0 As String = ""
                            Dim level1 As String = ""
                            Dim level2 As String = ""
                            Dim level3 As String = ""
                            Dim level4 As String = ""
                            Dim level5 As String = ""
                            Dim level6 As String = ""
                            Dim level7 As String = ""

                            descr = dataTB.Rows(i).Item("Description").ToString
                            unit = dataTB.Rows(i).Item("Unit").ToString
                            qty = dataTB.Rows(i).Item("Qty").ToString
                            level0 = dataTB.Rows(i).Item("Level 0").ToString
                            level1 = dataTB.Rows(i).Item("Level 1").ToString
                            level2 = dataTB.Rows(i).Item("Level 2").ToString
                            level3 = dataTB.Rows(i).Item("Level 3").ToString
                            level4 = dataTB.Rows(i).Item("Level 4").ToString
                            level5 = dataTB.Rows(i).Item("Level 5").ToString
                            level6 = dataTB.Rows(i).Item("Level 6").ToString
                            level7 = dataTB.Rows(i).Item("Level 7").ToString
                            'qty = dataTB.Rows(i).Item("Qty")

                            If level0 <> "" Then
                                'bomidH1 = bomidH
                                inv = level0
                                Dim strYear As String = ""
                                Bulan1 = 0
                                Bulan2 = 0
                                Invoke(Sub()
                                           strYear = CmbTahun.Text
                                           Bulan1 = CmbBulan1.SelectedIndex
                                           Bulan2 = CmbBulan2.SelectedIndex
                                       End Sub)
                                With ObjSales
                                    .invtid = level0
                                    .descr = descr
                                    .Semester = "1"
                                    .Tahun = strYear
                                    .Total = 0
                                    .TotalPO = 0
                                    Id = .InsertHeader()
                                End With

                            Else
                                For j As Integer = 0 To dt.Rows.Count - 1
                                    Dim invtidD As String = ""
                                    invtid = dt.Rows(j).Item("invtid").ToString
                                    jan = 0
                                    feb = 0
                                    mar = 0
                                    apr = 0
                                    mei = 0
                                    jun = 0
                                    If inv = invtid Then
                                        If dt.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString <> "0" Then
                                            jan = dt.Rows(j).Item("jan_qty03")
                                        ElseIf dt.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString = "0" Then
                                            jan = dt.Rows(j).Item("jan_qty03")
                                        ElseIf dt.Rows(j).Item("jan_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString = "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString = "0" Then
                                            jan = dt.Rows(j).Item("jan_qty03")
                                        ElseIf dt.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString <> "0" Then
                                            jan = dt.Rows(j).Item("jan_qty02")
                                        ElseIf dt.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString = "0" Then
                                            jan = dt.Rows(j).Item("jan_qty02")
                                        ElseIf dt.Rows(j).Item("jan_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jan_qty02").ToString = "0" AndAlso dt.Rows(j).Item("jan_qty01").ToString <> "0" Then
                                            jan = dt.Rows(j).Item("jan_qty01")
                                        Else
                                            jan = 0
                                        End If

                                        '===============PO Desember=====================
                                        If dt.Rows(j).Item("jan_po02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_po01").ToString <> "0" Then
                                            janPO = dt.Rows(j).Item("jan_po02")
                                        ElseIf dt.Rows(j).Item("jan_po02").ToString <> "0" AndAlso dt.Rows(j).Item("jan_po01").ToString = "0" Then
                                            janPO = dt.Rows(j).Item("jan_po02")
                                        ElseIf dt.Rows(j).Item("jan_po02").ToString = "0" AndAlso dt.Rows(j).Item("jan_po01").ToString <> "0" Then
                                            janPO = dt.Rows(j).Item("jan_po01")
                                        Else
                                            janPO = 0
                                        End If

                                        If dt.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString <> "0" Then
                                            feb = dt.Rows(j).Item("feb_qty03")
                                        ElseIf dt.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString = "0" Then
                                            feb = dt.Rows(j).Item("feb_qty03")
                                        ElseIf dt.Rows(j).Item("feb_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString = "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString = "0" Then
                                            feb = dt.Rows(j).Item("feb_qty03")
                                        ElseIf dt.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString <> "0" Then
                                            feb = dt.Rows(j).Item("feb_qty02")
                                        ElseIf dt.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString = "0" Then
                                            feb = dt.Rows(j).Item("feb_qty02")
                                        ElseIf dt.Rows(j).Item("feb_qty03").ToString = "0" AndAlso dt.Rows(j).Item("feb_qty02").ToString = "0" AndAlso dt.Rows(j).Item("feb_qty01").ToString <> "0" Then
                                            feb = dt.Rows(j).Item("feb_qty01")
                                        Else
                                            feb = 0
                                        End If

                                        '===============PO Februari=====================
                                        If dt.Rows(j).Item("feb_po02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_po01").ToString <> "0" Then
                                            febPO = dt.Rows(j).Item("feb_po02")
                                        ElseIf dt.Rows(j).Item("feb_po02").ToString <> "0" AndAlso dt.Rows(j).Item("feb_po01").ToString = "0" Then
                                            febPO = dt.Rows(j).Item("feb_po02")
                                        ElseIf dt.Rows(j).Item("feb_po02").ToString = "0" AndAlso dt.Rows(j).Item("feb_po01").ToString <> "0" Then
                                            febPO = dt.Rows(j).Item("feb_po01")
                                        Else
                                            febPO = 0
                                        End If

                                        If dt.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString <> "0" Then
                                            mar = dt.Rows(j).Item("mar_qty03")
                                        ElseIf dt.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString = "0" Then
                                            mar = dt.Rows(j).Item("mar_qty03")
                                        ElseIf dt.Rows(j).Item("mar_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString = "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString = "0" Then
                                            mar = dt.Rows(j).Item("mar_qty03")
                                        ElseIf dt.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString <> "0" Then
                                            mar = dt.Rows(j).Item("mar_qty02")
                                        ElseIf dt.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString = "0" Then
                                            mar = dt.Rows(j).Item("mar_qty02")
                                        ElseIf dt.Rows(j).Item("mar_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mar_qty02").ToString = "0" AndAlso dt.Rows(j).Item("mar_qty01").ToString <> "0" Then
                                            mar = dt.Rows(j).Item("mar_qty01")
                                        Else
                                            mar = 0
                                        End If

                                        '===============PO Maret=====================
                                        If dt.Rows(j).Item("mar_po02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_po01").ToString <> "0" Then
                                            marPO = dt.Rows(j).Item("mar_po02")
                                        ElseIf dt.Rows(j).Item("mar_po02").ToString <> "0" AndAlso dt.Rows(j).Item("mar_po01").ToString = "0" Then
                                            marPO = dt.Rows(j).Item("mar_po02")
                                        ElseIf dt.Rows(j).Item("mar_po02").ToString = "0" AndAlso dt.Rows(j).Item("mar_po01").ToString <> "0" Then
                                            marPO = dt.Rows(j).Item("mar_po01")
                                        Else
                                            marPO = 0
                                        End If

                                        If dt.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString <> "0" Then
                                            apr = dt.Rows(j).Item("apr_qty03")
                                        ElseIf dt.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString = "0" Then
                                            apr = dt.Rows(j).Item("apr_qty03")
                                        ElseIf dt.Rows(j).Item("apr_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString = "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString = "0" Then
                                            apr = dt.Rows(j).Item("apr_qty03")
                                        ElseIf dt.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString <> "0" Then
                                            apr = dt.Rows(j).Item("apr_qty02")
                                        ElseIf dt.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString = "0" Then
                                            apr = dt.Rows(j).Item("apr_qty02")
                                        ElseIf dt.Rows(j).Item("apr_qty03").ToString = "0" AndAlso dt.Rows(j).Item("apr_qty02").ToString = "0" AndAlso dt.Rows(j).Item("apr_qty01").ToString <> "0" Then
                                            apr = dt.Rows(j).Item("apr_qty01")
                                        Else
                                            apr = 0
                                        End If

                                        '===============PO April=====================
                                        If dt.Rows(j).Item("apr_po02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_po01").ToString <> "0" Then
                                            aprPO = dt.Rows(j).Item("apr_po02")
                                        ElseIf dt.Rows(j).Item("apr_po02").ToString <> "0" AndAlso dt.Rows(j).Item("apr_po01").ToString = "0" Then
                                            aprPO = dt.Rows(j).Item("apr_po02")
                                        ElseIf dt.Rows(j).Item("apr_po02").ToString = "0" AndAlso dt.Rows(j).Item("apr_po01").ToString <> "0" Then
                                            aprPO = dt.Rows(j).Item("apr_po01")
                                        Else
                                            aprPO = 0
                                        End If

                                        If dt.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString <> "0" Then
                                            mei = dt.Rows(j).Item("mei_qty03")
                                        ElseIf dt.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString = "0" Then
                                            mei = dt.Rows(j).Item("mei_qty03")
                                        ElseIf dt.Rows(j).Item("mei_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString = "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString = "0" Then
                                            mei = dt.Rows(j).Item("mei_qty03")
                                        ElseIf dt.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString <> "0" Then
                                            mei = dt.Rows(j).Item("mei_qty02")
                                        ElseIf dt.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString = "0" Then
                                            mei = dt.Rows(j).Item("mei_qty02")
                                        ElseIf dt.Rows(j).Item("mei_qty03").ToString = "0" AndAlso dt.Rows(j).Item("mei_qty02").ToString = "0" AndAlso dt.Rows(j).Item("mei_qty01").ToString <> "0" Then
                                            mei = dt.Rows(j).Item("mei_qty01")
                                        Else
                                            mei = 0
                                        End If

                                        '===============PO Mei=====================
                                        If dt.Rows(j).Item("mei_po02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_po01").ToString <> "0" Then
                                            meiPO = dt.Rows(j).Item("mei_po02")
                                        ElseIf dt.Rows(j).Item("mei_po02").ToString <> "0" AndAlso dt.Rows(j).Item("mei_po01").ToString = "0" Then
                                            meiPO = dt.Rows(j).Item("mei_po02")
                                        ElseIf dt.Rows(j).Item("mei_po02").ToString = "0" AndAlso dt.Rows(j).Item("mei_po01").ToString <> "0" Then
                                            meiPO = dt.Rows(j).Item("mei_po01")
                                        Else
                                            meiPO = 0
                                        End If

                                        If dt.Rows(j).Item("jun_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty03")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty02")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty01")
                                        Else
                                            jun = 0
                                        End If

                                        '===============PO Juni=====================
                                        If dt.Rows(j).Item("jun_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty03")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString = "0" Then
                                            jun = dt.Rows(j).Item("jun_qty03")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString = "0" Then
                                            jun = dt.Rows(j).Item("jun_qty03")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty02")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString <> "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString = "0" Then
                                            jun = dt.Rows(j).Item("jun_qty02")
                                        ElseIf dt.Rows(j).Item("jun_qty03").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty02").ToString = "0" AndAlso dt.Rows(j).Item("jun_qty01").ToString <> "0" Then
                                            jun = dt.Rows(j).Item("jun_qty01")
                                        Else
                                            jun = 0
                                        End If

                                        Exit For
                                    End If
                                Next

                                With ObjSalesdetail
                                    '.bomId = bomidH1
                                    If level0 = "" AndAlso level1 <> "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" Then
                                        .invtid = level1
                                        .level = "level1"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 <> "" AndAlso level3 = "" AndAlso level4 = "" Then
                                        .invtid = level2
                                        .level = "level2"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 <> "" AndAlso level4 = "" Then
                                        .invtid = level3
                                        .level = "level3"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 <> "" Then
                                        .invtid = level4
                                        .level = "level4"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level4 <> "" Then
                                        .invtid = level5
                                        .level = "level5"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level5 = "" AndAlso level6 <> "" Then
                                        .invtid = level6
                                        .level = "level6"
                                    ElseIf level0 = "" AndAlso level1 = "" AndAlso level2 = "" AndAlso level3 = "" AndAlso level4 = "" AndAlso level5 = "" AndAlso level6 = "" AndAlso level7 <> "" Then
                                        .invtid = level7
                                        .level = "level7"
                                    End If
                                    .descr = descr
                                    .unit = unit

                                    .Jan_qty = qty * jan
                                    .feb_qty = qty * feb
                                    .mar_qty = qty * jan
                                    .apr_qty = qty * apr
                                    .mei_qty = qty * mei
                                    .jun_qty = qty * jun
                                    .Jan_po = qty * janPO
                                    .feb_po = qty * febPO
                                    .mar_po = qty * janPO
                                    .apr_po = qty * aprPO
                                    .mei_po = qty * meiPO
                                    .jun_po = qty * junPO
                                    .jul_qty = 0
                                    .agt_qty = 0
                                    .sep_qty = 0
                                    .okt_qty = 0
                                    .nov_qty = 0
                                    .des_qty = 0
                                    .jul_po = 0
                                    .agt_po = 0
                                    .sep_po = 0
                                    .okt_po = 0
                                    .nov_po = 0
                                    .des_po = 0
                                    .InsertDetails(Id)
                                End With
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub proses_semester1(Bulan1 As String, Bulan2 As String)
        Dim Id As Integer = 0
        Dim dt1 As New DataTable
        dt1 = ObjSales.GetForecastSemester1(strTahun, "", "")
        If dt1.Rows.Count = 0 Then
            XtraMessageBox.Show("Data to calculate is empty !")
            Exit Sub
        End If

    End Sub
End Class
