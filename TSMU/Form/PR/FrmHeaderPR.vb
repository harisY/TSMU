Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Public Class FrmHeaderPR

    Dim ff_Detail As FrmDetailPR
    Dim dtGrid As DataTable
    Dim fc_Class As New Cls_PR
    'Dim fc_Class As New CR_UserCreateModel
    Dim Active_Form As Int32 = 0
    Dim DeptId As String


    Public Class ContactList
        Inherits System.Collections.CollectionBase

        Default Public Property Item(ByVal index As Integer) As Contact
            Get
                Return DirectCast(List(index), Contact)
            End Get
            Set(ByVal value As Contact)
                List(index) = value
            End Set
        End Property

        Public Function Add(ByVal value As Contact) As Integer
            Return List.Add(value)
        End Function
        '...
    End Class

    Private Sub List_Status()


        'dtUntukBagian = New DataTable
        'dtUntukBagian = fc_Class.Get_UntuBagian()

        Dim cList As New ContactList()

        'For i As Integer = 0 To dtUntukBagian.Rows.Count - 1
        '    cList.Add(New Contact(dtUntukBagian.Rows(i).Item(0), dtUntukBagian.Rows(i).Item(1)))
        'Next
        cList.Add(New Contact("", "Create"))
        cList.Add(New Contact("P", "Print"))
        cList.Add(New Contact("R", "Release"))
        cList.Add(New Contact("D", "Deleted"))
        cList.Add(New Contact("C", "Close"))

        'bind the lookup editor to the list
        RepoStatus.DataSource = cList
        RepoStatus.DisplayMember = "Name"
        RepoStatus.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoStatus.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoStatus.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoStatus.TextEditStyle = TextEditStyles.Standard
    End Sub

    Public Class Contact
        'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private name_Renamed As String
        'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private id_Renamed As String

        Public Sub New(ByVal _id As String, ByVal _name As String)
            id_Renamed = _id
            name_Renamed = _name
        End Sub



        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As String)
                id_Renamed = value
            End Set
        End Property
    End Class




    Private Sub FrmHeaderPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call List_Status()
        bb_SetDisplayChangeConfirmation = False
        DeptId = gh_Common.GroupID
        Call LoadGrid(DeptId)


        'Call Sub_Dept(gh_Common.GroupID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, True)

    End Sub

    Private Sub LoadGrid(Dept As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            'pDate2 = Date.Now.AddMonths(3)
            'pDate1 = Date.Now.AddMonths(-3)

            Dim dt As New DataTable

            dt = fc_Class.Get_PR(Dept)
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

        'If Active_Form = 1 Then
        '    ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        'ElseIf Active_Form = 6 Then
        '    ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, GridPurchase, Active_Form)
        'End If

        ff_Detail = New FrmDetailPR(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)


        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick


        Try

            Active_Form = 1

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            Dim PRNo As String = ""

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    PRNo = GridView1.GetRowCellValue(rowHandle, "PR No")

                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(PRNo,
                            "",
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub


    Public Overrides Sub Proc_DeleteData()
        Dim IDTrans As String = ""

        Try
            'fc_Class.ObjDetails.Clear()
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            'ObjMaterialUsageDetail = New MaterialUsageDetailModel

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        'ObjMaterialUsageDetail.IDMaterialUsage = GridView1.GetRowCellValue(rowHandle, "IDMaterialUsage")
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "PR No")
                    End If
                Next rowHandle

                Try

                    ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
                    Dim dt As New DataTable
                    dt = fc_Class.GetDataDelete(IDTrans)

                    If dt.Rows.Count = 0 Then

                        MessageBox.Show("PR '" & IDTrans & "' Cannot Delete",
                                                     "Warning",
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button1)
                        Exit Sub
                    Else

                        fc_Class.Delete_PR(IDTrans)
                        Call LoadGrid(gh_Common.GroupID)
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)



                        Exit Sub

                    End If
                Catch ex As Exception
                    Throw
                End Try
            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadGrid(gh_Common.GroupID)
    End Sub

    Public Overrides Sub Proc_Search()

        Try
            'Dim Status As List(Of String) = New List(Of String)({"ALL", "Create", "Submit", "Revise", "Approve Dept Head", "Approve Div Head", "Submit To NPD"})
            Dim fSearch As New frmSearch()

            'If TabControl1.SelectedTab.Name = "TabPage1" Then
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                dtGrid = fc_Class.Get_PR_Search(gh_Common.GroupID, If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                Grid.DataSource = dtGrid

            End With

            'ElseIf TabControl1.SelectedTab.Name = "TabPage2" Then
            '    With fSearch
            '        .StartPosition = FormStartPosition.CenterScreen
            '        .ShowDialog()

            '        dtGrid = fc_Class.Get_CR_Purchase_Search(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
            '        GridPurchase.DataSource = dtGrid

            '    End With
            'End If


        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try





    End Sub



End Class
