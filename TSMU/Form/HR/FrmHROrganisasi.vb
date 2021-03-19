Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.StyleFormatConditions
Imports System.ComponentModel.DataAnnotations

Public Class FrmHROrganisasi
    Dim srvHR As New HROrgService()
    Dim dtTreeOrg As New DataTable
    Dim frm_OrgDetail As FrmHROrgOrganisasiDetail
    Dim frm_JabDetail As FrmHROrgJabatanDetail
    Dim Now As Date

    Private Sub FrmHROrganisasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, False)
        Call LoadStruktur()
    End Sub

    Private Sub trStrukturOrg_GetStateImage(sender As Object, e As GetStateImageEventArgs) Handles trStrukturOrg.GetStateImage
        If e.Node.GetValue("OrgClass") = "O" Then
            e.Node.StateImageIndex = 2
        ElseIf e.Node.GetValue("OrgClass") = "P" Then
            If IIf(e.Node.GetValue("NIK") Is DBNull.Value, "", e.Node.GetValue("NIK")) = "" Then
                e.NodeImageIndex = 4
            Else
                e.NodeImageIndex = 5
            End If
        End If
    End Sub

    Private Sub trStrukturOrg_GetSelectImage(sender As Object, e As GetSelectImageEventArgs) Handles trStrukturOrg.GetSelectImage
        If e.FocusedNode Then
            e.NodeImageIndex = 1
        Else
            e.NodeImageIndex = 0
        End If
    End Sub

    Private Sub trStrukturOrg_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles trStrukturOrg.FocusedNodeChanged
        If e.Node.GetValue("OrgClass") = "O" Then
            Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, False)
        Else
            Call Proc_EnableButtons(False, False, True, True, False, False, False, False, False, False, False, False)
        End If
    End Sub

    Public Overrides Sub Proc_InputNewData()
        Try
            Dim itemChild As List(Of String) = New List(Of String)({"ORGANISASI", "JABATAN"})
            Dim frmOption As New frmAdvanceOption(itemChild)
            With frmOption
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            Dim orgID As String = trStrukturOrg.FocusedNode.GetValue("OrgID")
            Dim orgLevel As String = trStrukturOrg.FocusedNode.GetValue("Level")
            If frmOption.ItemChild = "" Then
                Throw New Exception("")
            ElseIf frmOption.ItemChild = "ORGANISASI" Then
                CallFrmOrganisasi("", orgID, orgLevel)
            ElseIf frmOption.ItemChild = "JABATAN" Then
                CallFrmJabatan("", orgID)
            End If
        Catch ex As Exception
            If Not String.IsNullOrEmpty(ex.Message) Then
                ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            End If
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadStruktur()
    End Sub

    Private Sub LoadStruktur()

        Now = Date.Today
        trStrukturOrg.Parent = Me
        trStrukturOrg.KeyFieldName = "ID"
        trStrukturOrg.ParentFieldName = "ParentID"
        trStrukturOrg.OptionsBehavior.PopulateServiceColumns = True
        dtTreeOrg = srvHR.GetStrukturOrg(Now)
        trStrukturOrg.DataSource = dtTreeOrg
        'trStrukturOrg.RowHeight = 25

        Dim colOrg As TreeListColumn = trStrukturOrg.Columns("Organisasi")
        Dim colOrgID As TreeListColumn = trStrukturOrg.Columns("OrgID")
        Dim colClass As TreeListColumn = trStrukturOrg.Columns("OrgClass")
        Dim colLevel As TreeListColumn = trStrukturOrg.Columns("Level")
        Dim colLevelDesc As TreeListColumn = trStrukturOrg.Columns("LevelDesc")
        Dim colNIK As TreeListColumn = trStrukturOrg.Columns("NIK")
        Dim colNama As TreeListColumn = trStrukturOrg.Columns("Nama")
        trStrukturOrg.Columns(trStrukturOrg.KeyFieldName).Visible = False
        trStrukturOrg.Columns(trStrukturOrg.ParentFieldName).Visible = False

        trStrukturOrg.OptionsView.AllowHtmlDrawHeaders = True
        trStrukturOrg.OptionsView.AutoWidth = False
        colOrgID.Visible = False
        colClass.Caption = "<b>Tipe</b>"
        colOrg.Caption = "<b> </b>"
        colLevel.Visible = False
        colLevelDesc.Caption = "<b>Level</b>"
        colNIK.Caption = "<b>NIK</b>"
        colNama.Caption = "<b>Nama</b>"

        Me.BeginInvoke(New MethodInvoker(Sub()
                                             trStrukturOrg.BestFitColumns()
                                         End Sub))

        'trStrukturOrg.SelectImageList = ImageCollection1
        trStrukturOrg.StateImageList = ImageCollection1
    End Sub

    Private Sub CallFrmOrganisasi(Optional ByVal ls_Code As String = "", Optional ByVal ParentID As String = "", Optional ByVal OrgLevel As String = "")
        If frm_OrgDetail IsNot Nothing AndAlso frm_OrgDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_OrgDetail.Close()
        ElseIf frm_JabDetail IsNot Nothing AndAlso frm_JabDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_JabDetail.Close()
        End If
        frm_OrgDetail = New FrmHROrgOrganisasiDetail(ls_Code, ParentID, OrgLevel, Me)
        frm_OrgDetail.MdiParent = FrmMain
        frm_OrgDetail.StartPosition = FormStartPosition.CenterScreen
        frm_OrgDetail.Show()
    End Sub

    Private Sub CallFrmJabatan(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "")
        If frm_OrgDetail IsNot Nothing AndAlso frm_OrgDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_OrgDetail.Close()
        ElseIf frm_JabDetail IsNot Nothing AndAlso frm_JabDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            frm_JabDetail.Close()
        End If
        frm_JabDetail = New FrmHROrgJabatanDetail(ls_Code, ls_Code2, Me)
        frm_JabDetail.MdiParent = FrmMain
        frm_JabDetail.StartPosition = FormStartPosition.CenterScreen
        frm_JabDetail.Show()
    End Sub

    Private Sub trStrukturOrg_DoubleClick(sender As Object, e As EventArgs) Handles trStrukturOrg.DoubleClick
        Dim orgID As String = trStrukturOrg.FocusedNode.GetValue("OrgID")
        Dim orgClass As String = trStrukturOrg.FocusedNode.GetValue("OrgClass")
        Dim orgLevel As String = trStrukturOrg.FocusedNode.GetValue("Level")
        If orgClass = "O" Then
            CallFrmOrganisasi(orgID, "", orgLevel)
        Else
            CallFrmJabatan(orgID, "")
        End If
    End Sub
End Class

