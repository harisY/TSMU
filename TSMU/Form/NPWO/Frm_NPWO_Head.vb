Imports System.Globalization
Public Class Frm_NPWO_Head

    Dim ff_Detail As Frm_Npwo_Detail1
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_Npwo_Header

    Dim FrmReport As ReportNPWO

    Dim DtDelete As DataTable
    Dim Active_Form As Integer


    Private Sub Frm_NPWO_Head_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim GServis As New GlobalService
        Active_Form = GServis.GetLevel_str("NPWO")

        dtGrid = New DataTable
        dtGrid.Columns.AddRange(New DataColumn(6) {New DataColumn("NPWO", GetType(String)),
                                                            New DataColumn("Issue Date", GetType(String)),
                                                            New DataColumn("Model", GetType(String)),
                                                            New DataColumn("Customer", GetType(String)),
                                                            New DataColumn("Order Of Month", GetType(String)),
                                                            New DataColumn("Approve", GetType(Boolean)),
                                                            New DataColumn("Rev", GetType(Int32))})
        Grid.DataSource = dtGrid




        bb_SetDisplayChangeConfirmation = False
        LoadGrid(Active_Form)

        If Active_Form = 1 Or Active_Form = 0 Then
            Call Proc_EnableButtons(True, False, False, True, False, False, False, False, False, False, False, True)
        ElseIf Active_Form = 2 Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
        ElseIf Active_Form = 3 Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
        End If


    End Sub
    Private Sub LoadGrid(_AcriveForm As Integer)
        Try

            Cursor.Current = Cursors.WaitCursor
            Dim dt As New DataTable

            dt = fc_Class.Get_NPWO(Active_Form)
                Grid.DataSource = dt


                Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New Frm_Npwo_Detail1(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid(Active_Form)
    End Sub

    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Group"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub
    Private Sub FilterGrid()
        Try
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_DeleteData()




        Dim NP As String = ""


        Dim selectedRows() As Integer = GridView1.GetSelectedRows()

        If GridView1.RowCount > 0 Then
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NP = GridView1.GetRowCellValue(rowHandle, "NPWO")
                End If
            Next rowHandle


            fc_Class.Delete(NP)
            Call LoadGrid(Active_Form)
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
        Else

        End If


    End Sub


    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim NoNpwo As String = ""
            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoNpwo = GridView1.GetRowCellValue(rowHandle, "NPWO")
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoNpwo, "",
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub

    Private Sub Frm_NPWO_Head_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub
End Class
