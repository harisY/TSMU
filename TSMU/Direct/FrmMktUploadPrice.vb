Imports DevExpress.XtraSplashScreen

Public Class FrmMktUploadPrice
    Private Sub FrmMktUploadPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        'Try
        '    Obj = New KanbanYIMModel
        '    dtGrid = Obj.GetAllDataGrid()
        '    Grid.DataSource = dtGrid

        '    If GridView1.RowCount > 0 Then
        '        With GridView1
        '            .BestFitColumns()
        '            .Columns(0).Visible = False
        '            .FixedLineWidth = 2
        '            .Columns(16).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(17).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '            .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        '        End With
        '        GridCellFormat(GridView1)
        '    End If
        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable

        Dim frmExcelPrice As FrmMktExcelPrice
        frmExcelPrice = New FrmMktExcelPrice(table, 69)
        frmExcelPrice.StartPosition = FormStartPosition.CenterScreen
        frmExcelPrice.ShowDialog()

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable

            If dtFilter.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                'For Each row As DataRow In dtFilter.Rows
                '    Try
                '        Obj = New KanbanYIMModel
                '        With Obj
                '            .Delay_Days = If(row("Delay Days") Is DBNull.Value, "", row("Delay Days").ToString())
                '            .Delivery_Due_Date = If(row("Delivery Due Date") Is DBNull.Value, CType(Nothing, DateTime?), Convert.ToDateTime(row("Delivery Due Date")))
                '            .Delivery_Slip_No = If(row("Delivery Slip No#") Is DBNull.Value, "", row("Delivery Slip No#").ToString())
                '            .Delivery_Time_From = If(row("Delivery Time (From)") Is DBNull.Value, CType(Nothing, TimeSpan?), TimeSpan.Parse(row("Delivery Time (From)").ToString()))
                '            .Delivery_Time_To = If(row("Delivery Time (To)") Is DBNull.Value, CType(Nothing, TimeSpan?), TimeSpan.Parse(row("Delivery Time (To)").ToString()))
                '            .Item_Class = If(row("Item Class") Is DBNull.Value, "", row("Item Class").ToString())
                '            .Item_Name = If(row("Item Name") Is DBNull.Value, "", row("Item Name").ToString())
                '            .Item_Number = If(row("Item Number") Is DBNull.Value, "", row("Item Number").ToString())
                '            .Item_Status = If(row("Item Status") Is DBNull.Value, "", row("Item Status").ToString())
                '            .Order_No = If(row("Order No#") Is DBNull.Value, 0, Convert.ToString(row("Order No#")))
                '            .Order_Quantity = If(row("Order Quantity") Is DBNull.Value, 0, Convert.ToInt32(row("Order Quantity")))
                '            .Output_date = If(row("Output date") Is DBNull.Value, CType(Nothing, DateTime?), Convert.ToDateTime(row("Output date").ToString()))
                '            .PF = If(row("P/F") Is DBNull.Value, "", row("P/F").ToString())
                '            .PF_Name = If(row("P/F Name") Is DBNull.Value, "", row("P/F Name").ToString())
                '            .Production_Classification = If(row("Production Classification") Is DBNull.Value, "", row("Production Classification").ToString())
                '            .Remain_Quantity = If(row("Remain Quantity") Is DBNull.Value, 0, Convert.ToInt32(row("Remain Quantity")))
                '            .SEQ = If(row("SEQ") Is DBNull.Value, 0, Convert.ToInt32(row("SEQ")))
                '            .Shipping_LOC = If(row("Shipping LOC") Is DBNull.Value, "", row("Shipping LOC").ToString())
                '            .Supplier_Code = If(row("Supplier Code") Is DBNull.Value, "", row("Supplier Code").ToString())
                '            .Supplier_Name = If(row("Supplier Name") Is DBNull.Value, "", row("Supplier Name").ToString())
                '            .Unit = If(row("Unit") Is DBNull.Value, "", row("Unit").ToString())
                '            .User_Code = If(row("User Code") Is DBNull.Value, "", row("User Code").ToString())
                '            .User_Name = If(row("User Name") Is DBNull.Value, "", row("User Name").ToString())
                '            .InsertData()
                '        End With

                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '        Console.WriteLine(ex.Message)
                '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                '        Continue For
                '    End Try
                'Next

                'Dim dtKanban As New DataTable
                'dtKanban = Obj.GetKanban
                'For i As Integer = 0 To dtKanban.Rows.Count - 1
                '    Try
                '        Dim _tgl As String = Convert.ToString(dtKanban.Rows(i)(0))
                '        Dim _plant As String = Convert.ToString(dtKanban.Rows(i)(1))
                '        Dim _user As String = Convert.ToString(dtKanban.Rows(i)(2))
                '        Dim _qty As Integer = Convert.ToInt32(dtKanban.Rows(i)(3))

                '        Dim IsExist As Boolean = Obj.IsKanbanExist(_tgl, _plant, _user)
                '        If Not IsExist Then
                '            '    Obj.UpdateKanbanSum(Tgl, Cycle, Kanban)
                '            'Else
                '            Obj.SaveKanbanSum(_tgl, _plant, _user, _qty)
                '        End If
                '    Catch ex As Exception
                '        MsgBox(ex.Message)
                '        Console.WriteLine(ex.Message)
                '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                '        Continue For
                '    End Try
                'Next

                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
