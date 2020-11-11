Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Localization
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmCustomization
    Dim cls_Customization As New CustomizationModels
    Dim listIsIdentity As New List(Of String)
    Dim listIsPrimaryKey As New List(Of String)

    Private Sub FrmCustomization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False)
        ListItemsTableParam()
    End Sub

    Private Sub ListItemsTableParam()
        cls_Customization = New CustomizationModels
        Dim dt As New DataTable
        dt = cls_Customization.GetListTableParam()
        txtTblName.Properties.DataSource = dt
        txtTblName.Size = txtTblName.CalcBestSize()
        txtTblName.Properties.PopupFormMinSize = txtTblName.Size
        txtTblName.Properties.PopupWidth = txtTblName.Size.Width
    End Sub

    Private Sub txtTblName_EditValueChanged(sender As Object, e As EventArgs) Handles txtTblName.EditValueChanged
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Dim dtData As New DataTable
        dtData = cls_Customization.GetDataParam(txtTblName.EditValue)
        GridViewData.Columns.Clear()
        GridData.DataSource = dtData
        GridViewData.BestFitColumns()

        Dim dtColumn As New DataTable
        listIsIdentity = New List(Of String)
        listIsPrimaryKey = New List(Of String)
        dtColumn = cls_Customization.GetColumnParam(txtTblName.EditValue)
        For Each rows As DataRow In dtColumn.Rows
            If rows("IsIdentity") Then
                GridViewData.Columns(rows("ColumnName")).Visible = False
                listIsIdentity.Add(rows("ColumnName"))
            End If

            If rows("IsPrimaryKey") Then
                listIsPrimaryKey.Add(rows("ColumnName"))
            End If
        Next
        If GridViewData.RowCount > 0 Then
            Call Proc_EnableButtons(False, False, True, False, False, False, False, False, False, False, False)
        End If
    End Sub

    Private Sub GridViewData_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridViewData.ShowingPopupEditForm
        Dim labels As List(Of LabelControl) = New List(Of LabelControl)()
        FindChildrenByType(e.EditForm, labels)

        For Each label As LabelControl In labels
            label.Appearance.Font = New Font(label.Appearance.Font, FontStyle.Bold)
        Next

        Dim buttons As List(Of SimpleButton) = New List(Of SimpleButton)()
        FindChildrenByType(e.EditForm, buttons)

        For Each btn As SimpleButton In buttons
            If btn.Text = GridLocalizer.Active.GetLocalizedString(GridStringId.EditFormCancelButton) Then
                AddHandler btn.Click, AddressOf CancelButtonClick
            Else
                Dim view As GridView = TryCast(sender, GridView)
                If view.IsNewItemRow(e.RowHandle) < 0 Then
                    btn.Text = "Save"
                    AddHandler btn.Click, AddressOf SaveButtonClick
                Else
                    btn.Text = GridLocalizer.Active.GetLocalizedString(GridStringId.EditFormUpdateButton)
                    AddHandler btn.Click, AddressOf UpdateButtonClick
                End If
            End If
        Next
    End Sub

    Private Sub CancelButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        RemoveHandler(TryCast(sender, SimpleButton)).Click, AddressOf CancelButtonClick
        LoadGrid()
    End Sub

    Private Sub SaveButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            RemoveHandler(TryCast(sender, SimpleButton)).Click, AddressOf SaveButtonClick
            Dim listColumn As New List(Of String)
            Dim columns As String = String.Empty
            Dim listValues As New List(Of String)
            Dim values As String = String.Empty
            For Each col As Columns.GridColumn In GridViewData.Columns
                If Not listIsIdentity.Contains(col.FieldName) Then
                    listColumn.Add("[" & col.FieldName & "]")
                    listValues.Add(QVal(IIf(GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName) Is DBNull.Value, "", GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName))))
                End If
            Next
            columns = String.Join(",", listColumn.ToArray)
            values = String.Join(",", listValues.ToArray)

            cls_Customization = New CustomizationModels
            cls_Customization.InsertDataParam(txtTblName.EditValue, columns, values)
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            LoadGrid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub UpdateButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Try
            RemoveHandler(TryCast(sender, SimpleButton)).Click, AddressOf UpdateButtonClick
            Dim listUpdate As New List(Of String)
            Dim update As String = String.Empty
            Dim listWhere As New List(Of String)
            Dim where As String = String.Empty
            If listIsIdentity.Count > 0 Then
                For Each col As Columns.GridColumn In GridViewData.Columns
                    If Not listIsIdentity.Contains(col.FieldName) Then
                        Dim value As String = QVal(IIf(GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName) Is DBNull.Value, "", GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName)))
                        listUpdate.Add("[" & col.FieldName & "] = " & value)
                    Else
                        Dim value As String = QVal(IIf(GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName) Is DBNull.Value, "", GridViewData.GetRowCellValue(GridViewData.FocusedRowHandle, col.FieldName)))
                        listWhere.Add("[" & col.FieldName & "] = " & value)
                    End If
                Next
                update = String.Join(",", listUpdate.ToArray)
                where = String.Join("And", listWhere.ToArray)

                cls_Customization = New CustomizationModels
                cls_Customization.UpdateDataParam(txtTblName.EditValue, update, where)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            Else
                Err.Raise(ErrNumber, , "Is Identity Not Found !")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim listWhere As New List(Of String)
            Dim where As String = String.Empty
            Dim selectedRows() As Integer = GridViewData.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If listIsIdentity.Count > 0 Then
                    If rowHandle >= 0 Then
                        For i As Integer = 0 To listIsIdentity.Count - 1
                            Dim value As String
                            value = QVal(GridViewData.GetRowCellValue(rowHandle, listIsIdentity(i)).ToString)
                            listWhere.Add("[" & listIsIdentity(i) & "] = " & value)
                        Next
                    End If
                    where = String.Join("And", listWhere.ToArray)

                    cls_Customization = New CustomizationModels
                    cls_Customization.DeleteDataParam(txtTblName.EditValue, where)
                    Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    LoadGrid()
                Else
                    Err.Raise(ErrNumber, , "Is Identity Not Found !")
                End If
            Next rowHandle
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Private Sub FindChildrenByType(Of T As Class)(ByVal parent As Control, ByVal list As List(Of T))
        For Each child As Control In parent.Controls
            If TypeOf child Is T Then list.Add(TryCast(child, T))
            If child.HasChildren Then FindChildrenByType(child, list)
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridViewData.AddNewRow()
        GridViewData.OptionsNavigation.AutoFocusNewRow = True
        GridData.BeginInvoke(New Action(AddressOf GridViewData.ShowEditForm))
    End Sub

End Class
