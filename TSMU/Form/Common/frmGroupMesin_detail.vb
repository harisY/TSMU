﻿Public Class frmGroupMesin_detail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsGroupMesin
    Dim GridDtl As DataGridView

    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim _Tag As TagModel
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As DataGridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel With {
            .PageIndex = lf_FormParent.Tag.PageIndex
        }
        Tag = _Tag
    End Sub
    Private Sub frmGroup_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True)
        Call InitialSetForm()
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                fc_Class.getDataByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Master Group " & fs_Code
            Else
                Me.Text = "Master New Group"
            End If
            'FillComboLokasi()
            TabControl1.TabPages(0).BackColor = tabcolour
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmGroupMesin"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With fc_Class
                    _txtId.Text = .ID
                    _txtDeskripsi.Text = .Deskripsi
                    '_txtTon.Text = .Tonnase.ToString
                    _txtId.Focus()
                End With
            Else
                _txtId.Text = ""
                _txtDeskripsi.Text = ""
                '_txtTon.Text = "0"
                _txtId.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If String.IsNullOrEmpty(_txtId.Text) Then
                errProvider.SetError(_txtId, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtId, "")
            End If

            If String.IsNullOrEmpty(_txtDeskripsi.Text) Then
                errProvider.SetError(_txtDeskripsi, "Value cannot be empty.")
            Else
                errProvider.SetError(_txtDeskripsi, "")
            End If

            'If String.IsNullOrEmpty(_txtTon.Text) Then
            '    errProvider.SetError(_txtTon, "Value cannot be empty.")
            'ElseIf Not IsNumeric(_txtTon.Text) Then
            '    errProvider.SetError(_txtTon, "Value must be numeric.")
            'Else
            '    errProvider.SetError(_txtTon, "")
            'End If


            Dim success As Boolean = True
            For Each c As Control In TabPage1.Controls
                If errProvider.GetError(c).Length > 0 Then
                    success = False
                End If

            Next
            If success Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Please check your input field !")
            End If

            If lb_Validated Then
                With fc_Class
                    .ID = _txtId.Text.Trim.ToUpper
                    .Deskripsi = _txtDeskripsi.Text.Trim.ToUpper
                    '.Tonnase = Convert.ToInt32(_txtTon.Text)
                    If isUpdate = False Then
                        .ValidateInsert()
                    Else
                        '.ValidateUpdate()
                    End If
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                fc_Class.Insert()
            Else
                fc_Class.Update(fs_Code)
            End If

            GridDtl.DataSource = fc_Class.GetAllDataTable(bs_Filter)
            Dim targetString As String = _txtId.Text
            For Each row As DataGridViewRow In Me.GridDtl.Rows
                If RTrim(row.Cells(0).Value.ToString) = targetString Then
                    Me.GridDtl.ClearSelection()
                    Me.GridDtl.Rows(row.Index).Selected = True
                    Exit For
                End If
            Next
            IsClosed = True
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
