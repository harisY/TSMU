Imports DevExpress.LookAndFeel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmUploadKanbanAdm
    Dim dtGrid As DataTable
    Dim Obj As New KanbanAdmModel
    Private Sub frmUploadKanbanAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            dtGrid = Obj.GetAllDataGrid()
            Grid.DataSource = dtGrid

            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Barcode"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcelBarcode
        frmExcel = New FrmSystemExcelBarcode(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable

            If dtFilter.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    Try
                        With Obj
                            If dtFilter.Rows(i)("Rec Status") Is DBNull.Value OrElse dtFilter.Rows(i)("Rec Status").ToString = "" Then
                                .RecStatus = ""
                            Else
                                .RecStatus = dtFilter.Rows(i)("Rec Status").ToString
                            End If
                            If dtFilter.Rows(i)("DN Type") Is DBNull.Value OrElse dtFilter.Rows(i)("DN Type").ToString = "" Then
                                .DNType = ""
                            Else
                                .DNType = dtFilter.Rows(i)("DN Type").ToString
                            End If
                            If dtFilter.Rows(i)("Part No") Is DBNull.Value OrElse dtFilter.Rows(i)("Part No").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("Part No").ToString
                            End If
                            If dtFilter.Rows(i)("Part Name") Is DBNull.Value OrElse dtFilter.Rows(i)("Part Name").ToString = "" Then
                                .PartName = ""
                            Else
                                .PartName = dtFilter.Rows(i)("Part Name").ToString
                            End If

                            If dtFilter.Rows(i)("Job No") Is DBNull.Value OrElse dtFilter.Rows(i)("Job No").ToString = "" Then
                                .JobNo = ""
                            Else
                                .JobNo = dtFilter.Rows(i)("Job No").ToString
                            End If
                            If dtFilter.Rows(i)("Lane") Is DBNull.Value OrElse dtFilter.Rows(i)("Lane").ToString = "" Then
                                .Lane = 0
                            Else
                                .Lane = Integer.Parse(dtFilter.Rows(i)("Lane").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty/Kbn") Is DBNull.Value OrElse dtFilter.Rows(i)("Qty/Kbn").ToString = "" Then
                                .QtyKbn = 0
                            Else
                                .QtyKbn = Integer.Parse(dtFilter.Rows(i)("Qty/Kbn").ToString)
                            End If
                            If dtFilter.Rows(i)("Order(Kbn)") Is DBNull.Value OrElse dtFilter.Rows(i)("Order(Kbn)").ToString = "" Then
                                .OrderKbn = 0
                            Else
                                .OrderKbn = Integer.Parse(dtFilter.Rows(i)("Order(Kbn)").ToString)
                            End If

                            If dtFilter.Rows(i)("Order(Pcs)") Is DBNull.Value OrElse dtFilter.Rows(i)("Order(Pcs)").ToString = "" Then
                                .OrderPcs = 0
                            Else
                                .OrderPcs = Integer.Parse(dtFilter.Rows(i)("Order(Pcs)").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty Receive") Is DBNull.Value OrElse dtFilter.Rows(i)("Qty Receive").ToString = "" Then
                                .QtyReceive = 0
                            Else
                                .QtyReceive = Integer.Parse(dtFilter.Rows(i)("Qty Receive").ToString)
                            End If
                            If dtFilter.Rows(i)("Qty Balance").ToString = "" OrElse dtFilter.Rows(i)("Qty Balance") Is DBNull.Value Then
                                .QtyBalance = 0
                            Else
                                .QtyBalance = Integer.Parse(dtFilter.Rows(i)("Qty Balance").ToString)
                            End If

                            If dtFilter.Rows(i)("Cancel Status").ToString = "" OrElse dtFilter.Rows(i)("Cancel Status") Is DBNull.Value Then
                                .CancelStatus = ""
                            Else
                                .CancelStatus = dtFilter.Rows(i)("Cancel Status").ToString
                            End If

                            If dtFilter.Rows(i)("Remark").ToString = "" OrElse dtFilter.Rows(i)("Remark") Is DBNull.Value Then
                                .Remark = ""
                            Else
                                .Remark = dtFilter.Rows(i)("Remark").ToString
                            End If

                            .UploadedDate = DateTime.Now
                            .UploadedBy = gh_Common.Username
                            .InsertData()

                        End With

                    Catch ex As Exception
                        'MsgBox(ex.Message)
                        Console.WriteLine(ex.Message)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        Continue For
                    End Try
                Next
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
