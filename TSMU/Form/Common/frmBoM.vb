Imports DevExpress.DataAccess.Excel
Imports DevExpress.XtraSplashScreen

Public Class frmBoM
    Dim ff_Detail As frmBoM_detail
    Dim dtGrid As DataTable
    Dim BomHeader As New clsBoM
    Dim BomDetails As New clsBoMdetails
    Dim ff_routing As frmBoM_routing
    Dim OFD As New OpenFileDialog
    Dim path As String
    Dim table As DataTable
    Dim tableDetail As DataTable
    Dim fc_ClassBoM As New clsBoMTrans
    Dim ExcelDt As New ExcelDataSource
    Dim BoMHTempt As BoM_Temp

    Private Sub frmBoM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False

        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, True, True, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = BomHeader.GetAllDataTable(bs_Filter)
            Grid.DataSource = dtGrid
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
                GridView1.BestFitColumns()
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_Excel()
        Try
            'ImportBoMHeader()
            ImportBoMDetails()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ImportBoMUpdateTon()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomHeader

                        If table.Rows(i)("M/C Ton") Is DBNull.Value OrElse table.Rows(i)("M/C Ton").ToString = "" Then
                            .MC = ""
                        Else
                            .MC = table.Rows(i)("M/C Ton").ToString
                        End If
                        .UpdateHeaderManual(table.Rows(i)("Parent ID"))
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "invtid", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ImportBoMUpdateCT()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomHeader

                        If table.Rows(i)("Cycle Time") Is DBNull.Value OrElse table.Rows(i)("Cycle Time").ToString = "" Then
                            .CycleTime = ""
                        Else
                            .CycleTime = table.Rows(i)("Cycle Time").ToString
                        End If
                        .UpdateHeaderManualCT(table.Rows(i)("Parent ID"))
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "invtid", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ImportBoMUpdateQtyDetails()

        Try
            For i As Integer = 0 To table.Rows.Count - 1
                Try
                    With BomDetails
                        Dim qty As String = Replace(table.Rows(i)("Qty").ToString, ",", ".")
                        Dim sQty As Single = Single.Parse(qty)
                        Dim sQty1 As Single = Convert.ToSingle(qty)
                        If table.Rows(i)("Parent ID") Is DBNull.Value OrElse table.Rows(i)("Parent ID").ToString = "" Then
                            .Parentid = ""
                        Else
                            .Parentid = Convert.ToString(table.Rows(i)("Parent ID").ToString())
                        End If
                        If table.Rows(i)("Invt ID Material") Is DBNull.Value OrElse table.Rows(i)("Invt ID Material").ToString = "" Then
                            .inventId = 0
                        Else
                            .inventId = Convert.ToString(table.Rows(i)("Invt ID Material").ToString())
                        End If
                        If table.Rows(i)("Qty") Is DBNull.Value OrElse table.Rows(i)("Qty").ToString = "" Then
                            .Qty = 0
                        Else
                            .Qty = sQty 'Convert.ToSingle(Replace(table.Rows(i)("Qty").ToString, ",", "."))
                        End If
                        '.UpdateQtyDetailsManual()
                    End With
                Catch ex As Exception
                    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                    WriteSalesToErrorLog("BoM", "Log", table, i, "Invt ID Material", gh_Common.Username)
                    Continue For
                End Try
            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ImportBoMDetails()
        Dim _TableDetail As New DataTable
        Dim Filename As String = String.Empty
        Dim Dial As New OpenFileDialog
        Dial.Filter = "Excel Files|*.xls;*.xlsx"
        Dim result As DialogResult = Dial.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            _TableDetail = ExcelToDatatable(Dial.FileName, "BOM DETAIL new")
        End If

        SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
        BomDetails.Fc_classdetail.Clear()
        For i As Integer = 0 To _TableDetail.Rows.Count - 1
            Try

                Dim fc_ClassBomDetails As New clsBoMdetails
                With fc_ClassBomDetails
                    If _TableDetail.Rows(i)("BOM ID") Is DBNull.Value OrElse _TableDetail.Rows(i)("BOM ID").ToString = "" Then
                        .BoMID = ""
                    Else
                        .BoMID = _TableDetail.Rows(i)("BOM ID").ToString
                    End If
                    If _TableDetail.Rows(i)("Parent ID") Is DBNull.Value OrElse _TableDetail.Rows(i)("Parent ID").ToString = "" Then
                        .Parentid = ""
                    Else
                        .Parentid = _TableDetail.Rows(i)("Parent ID").ToString
                    End If
                    If _TableDetail.Rows(i)("Inventory ID") Is DBNull.Value OrElse _TableDetail.Rows(i)("Inventory ID").ToString = "" Then
                        .inventId = ""
                    Else
                        .inventId = _TableDetail.Rows(i)("Inventory ID").ToString
                    End If
                    If _TableDetail.Rows(i)("Description") Is DBNull.Value OrElse _TableDetail.Rows(i)("Description").ToString = "" Then
                        .Descr_detail = ""
                    Else
                        .Descr_detail = _TableDetail.Rows(i)("Description").ToString
                    End If
                    If _TableDetail.Rows(i)(" Qty ") Is DBNull.Value OrElse _TableDetail.Rows(i)(" Qty ").ToString = "" Then
                        .Qty = 0
                    Else
                        .Qty = Replace(_TableDetail.Rows(i)(" Qty "), ",", ".")
                    End If
                    If _TableDetail.Rows(i)("Unit") Is DBNull.Value OrElse _TableDetail.Rows(i)("Unit").ToString = "" Then
                        .Unit = ""
                    Else
                        .Unit = _TableDetail.Rows(i)("Unit").ToString
                    End If
                End With
                BomDetails.Fc_classdetail.Add(fc_ClassBomDetails)
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                WriteSalesToErrorLog("BoM", "Log", _TableDetail, i, "Inventory ID", gh_Common.Username)
                Throw ex
                'Continue For
            End Try
        Next
        BomDetails.UpdateBoMDetail()
        SplashScreenManager.CloseForm()
        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        Cursor = Cursors.Default
        LoadGrid()

    End Sub

    Private Sub ImportBoMHeader()

        Dim _Table As New DataTable
        Dim Filename As String = String.Empty
        Dim Dial As New OpenFileDialog
        Dial.Filter = "Excel Files|*.xls;*.xlsx"
        Dim result As DialogResult = Dial.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            _Table = ExcelToDatatable(Dial.FileName, "BOM HEADER new")
        End If

        SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
        BomHeader.BoMHeaderCollection.Clear()

        For i As Integer = 0 To _Table.Rows.Count - 1
            Try
                Dim ObjHeader As New clsBoM
                With ObjHeader
                    If _Table.Rows(i)("BOM ID") Is DBNull.Value OrElse _Table.Rows(i)("BOM ID").ToString = "" Then
                        .BoMID = ""
                    Else
                        .BoMID = _Table.Rows(i)("BOM ID").ToString
                    End If
                    .Tgl = Date.Today
                    If _Table.Rows(i)("InvID") Is DBNull.Value OrElse _Table.Rows(i)("InvID").ToString = "" Then
                        .InvtID = ""
                    Else
                        .InvtID = _Table.Rows(i)("InvID").ToString
                    End If
                    If _Table.Rows(i)("Description") Is DBNull.Value OrElse _Table.Rows(i)("Description").ToString = "" Then
                        .Desc = ""
                    Else
                        .Desc = _Table.Rows(i)("Description").ToString
                    End If
                    If _Table.Rows(i)("Site") Is DBNull.Value OrElse _Table.Rows(i)("Site").ToString = "" Then
                        .SiteID = ""
                    Else
                        .SiteID = _Table.Rows(i)("Site").ToString
                    End If
                    If _Table.Rows(i)("Runner") Is DBNull.Value OrElse _Table.Rows(i)("Runner").ToString = "" Then
                        .Runner = ""
                    Else
                        .Runner = _Table.Rows(i)("Runner").ToString
                    End If
                    If _Table.Rows(i)(" CT ") Is DBNull.Value OrElse _Table.Rows(i)(" CT ").ToString = "" Then
                        .CycleTime = "0"
                    Else
                        .CycleTime = _Table.Rows(i)(" CT ")
                    End If
                    If _Table.Rows(i)("MC") Is DBNull.Value OrElse _Table.Rows(i)("MC").ToString = "" Then
                        .MC = ""
                    Else
                        .MC = _Table.Rows(i)("MC").ToString
                    End If

                    If _Table.Rows(i)(" Cavity ") Is DBNull.Value OrElse _Table.Rows(i)(" Cavity ").ToString = "" Then
                        .cavity = ""
                    Else
                        .cavity = _Table.Rows(i)(" Cavity ").ToString
                    End If
                    If _Table.Rows(i)("WC") Is DBNull.Value OrElse _Table.Rows(i)("WC").ToString = "" Then
                        .WC = ""
                    Else
                        .WC = _Table.Rows(i)("WC").ToString
                    End If
                    If _Table.Rows(i)("Allow") Is DBNull.Value OrElse _Table.Rows(i)("Allow").ToString = "" Then
                        .Allowance = 0
                    Else
                        .Allowance = _Table.Rows(i)("Allow")
                    End If
                    If _Table.Rows(i)("MP") Is DBNull.Value OrElse _Table.Rows(i)("MP").ToString = "" Then
                        .MP = "0"
                    Else
                        .MP = _Table.Rows(i)("MP")
                    End If
                    If _Table.Rows(i)("Status") Is DBNull.Value OrElse _Table.Rows(i)("Status") = "" Then
                        .Status = ""
                    Else
                        .Status = _Table.Rows(i)("Status")
                    End If
                    If _Table.Rows(i)("Active") Is DBNull.Value OrElse _Table.Rows(i)("Active").ToString = "" Then
                        .Active = 1
                    Else
                        .Active = _Table.Rows(i)("Active")
                    End If
                End With
                BomHeader.BoMHeaderCollection.Add(ObjHeader)
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                Console.WriteLine(ex.Message)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                WriteSalesToErrorLog("BoM", "Log", _Table, i, "InvID", gh_Common.Username)
                Throw ex
                'Continue For
            End Try
        Next
        'BomHeader.UpdateBoMHeader()
        BomHeader.InsertBoMHeader()
        SplashScreenManager.CloseForm()

        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        Cursor = Cursors.Default
        LoadGrid()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""

        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            bomid = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    bomid = GridView1.GetRowCellValue(rowHandle, "BOM ID")
                End If
            Next rowHandle

            If gh_Common.Group = "NPD TANGERANG" OrElse gh_Common.Group = "NPD CIKARANG" Then
                If bomid = "" Then
                    Throw New Exception("Pilih BOM yang akan di hapus.")
                End If
                If bomid.Substring(0, 1).ToLower = "p" Then
                    fc_ClassBoM.BoMID = bomid
                    fc_ClassBoM.DeleteData()
                    ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    LoadGrid()
                Else
                    Throw New Exception("BOM Regular tidak bisa di hapus")
                End If
            Else
                Throw New Exception("Anda tidak punya akses untuk hapus BOM")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmBoM_detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim objGrid As DataGridView = sender
            If objGrid.Rows.Count > 0 Then
                Call CallFrm(objGrid.SelectedRows(0).Cells(0).Value.ToString,
                             objGrid.SelectedRows(0).Cells(1).Value.ToString,
                             objGrid.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim invtID, bomid As String

    Private Sub frmBoM_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                invtID = String.Empty
                bomid = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                        bomid = GridView1.GetRowCellValue(rowHandle, "BOM ID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(bomid,
                             invtID,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            invtID = String.Empty
            bomid = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                    bomid = GridView1.GetRowCellValue(rowHandle, "BOM ID")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(bomid,
                         invtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ImportBomToUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportBomToUpdateToolStripMenuItem.Click
        'Try
        '    Dim dt As New DataTable
        '    Dim Filename As String = String.Empty
        '    Dim Dial As New OpenFileDialog
        '    Dial.Filter = "Excel Files|*.xls;*.xlsx"
        '    Dim result As DialogResult = Dial.ShowDialog()
        '    If result = System.Windows.Forms.DialogResult.OK Then
        '        dt = ExcelToDatatable(Dial.FileName, "BOM HEADER")
        '    End If
        '    SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
        '    BomHeader.BoMTempCollection.Clear()
        '    For Each row As DataRow In dt.Rows
        '        BoMHTempt = New BoM_Temp
        '        With BoMHTempt
        '            .InvtID = row("InvID")
        '        End With
        '        BomHeader.BoMTempCollection.Add(BoMHTempt)
        '    Next

        '    BomHeader.DeleteBoMOnUpload()
        '    SplashScreenManager.CloseForm()

        '    Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
        '    LoadGrid()
        'Catch ex As Exception
        '    SplashScreenManager.CloseForm()
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub

    Private Sub frmBoM_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadGrid()
    End Sub

End Class