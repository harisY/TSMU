Public Class FrmTravelTicket
    Dim dtGrid As DataTable
    Dim fc_Class As New TravelTicketModel
    Dim ff_Detail As FrmTravelTicketDetail

    Dim TabPage As String

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravelTicketDetail(ls_Code, ls_Code2, Me, li_Row, GridTicket)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub FrmTravelTicket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False)
        XtraTabControl1.SelectedTabPage = TabPageRequest
        TabPage = XtraTabControl1.SelectedTabPage.Name
        Call LoadGridRequest()
    End Sub

    Private Sub LoadGridRequest()
        Try
            dtGrid = fc_Class.GetTravelRequest()
            GridRequest.DataSource = dtGrid
            GridCellFormat(GridViewRequest)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridTicket()
        Try
            dtGrid = fc_Class.GetTravelTicket()
            GridTicket.DataSource = dtGrid
            GridCellFormat(GridViewTicket)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        If TabPage = "TabPageRequest" Then
            LoadGridRequest()
        Else
            LoadGridTicket()
        End If
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim NoVoucher As String = String.Empty

        Try
            Dim selectedRows() As Integer = GridViewTicket.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoVoucher = GridViewTicket.GetRowCellValue(rowHandle, "NoVoucher")
                End If
            Next rowHandle

            'dt = ObjTravelSett.GetTravelSettHeaderByTravelID(ID)
            'Dim ada As Integer
            'ada = dt.Rows.Count()
            'If ada > 0 Then
            '    Err.Raise(ErrNumber, , "Travel ID " & ID & " dalam proses settlement !")
            '    'MessageBox.Show("Data dalam proses settlement", "Warning",
            '    '                MessageBoxButtons.OK,
            '    '                MessageBoxIcon.Exclamation,
            '    '                MessageBoxDefaultButton.Button1)
            'Else

            fc_Class.NoVoucher = NoVoucher
            fc_Class.DeleteData()

            tsBtn_refresh.PerformClick()
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageRequest" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False)
            LoadGridRequest()
        Else
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
            LoadGridTicket()
        End If
    End Sub

    Private Sub GridTicket_DoubleClick(sender As Object, e As EventArgs) Handles GridTicket.DoubleClick
        Try
            Dim NoVoucher = String.Empty
            Dim selectedRows() As Integer = GridViewTicket.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoVoucher = GridViewTicket.GetRowCellValue(rowHandle, "NoVoucher")
                End If
            Next rowHandle

            If GridViewTicket.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoVoucher,
                         GridViewTicket.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
