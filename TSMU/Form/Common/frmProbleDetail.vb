Imports DevExpress.XtraGrid

Public Class frmProbleDetail
    Dim _Code As Integer
    Dim _Grid As GridControl

    Dim Service As New ProblemService
    Dim Model As ProblemModel
    Dim _Tag As TagModel
    Dim Parent As Form
    Dim Dt As DataTable

    Dim GlobalService As GlobalService

    Dim ls_Error As String = ""
    Dim isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal Code As Integer,
                   ByVal Code2 As String,
                   ByRef FrmParent As Form,
                   ByVal GridRow As Integer,
                   ByRef Grid As GridControl)

        ' This call is required by the designer.
        InitializeComponent()
        fs_Code = Code.ToString
        fs_Code2 = Code2
        bi_GridParentRow = GridRow

        _Grid = Grid
        Parent = FrmParent
        _Tag = New TagModel With {
            .PageIndex = FrmParent.Tag.PageIndex
        }
        Tag = _Tag
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmProbleDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        InitialSetForm()
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            Model = New ProblemModel
            Model = Service.GetDataById(fs_Code.AsInt)
            Text = "PROBLEM INPUT"

            LoadTxtBox()
            FillComboProses()

            InputBeginState(Me)
            'bb_IsUpdate = isUpdate
            'bs_MainFormName = FrmParent.Name
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            With Model
                CmbProses.EditValue = .Proses
                TxtCode.Text = .ProblemCode
                TxtName.Text = .Name
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillComboProses()
        GlobalService = New GlobalService
        Dt = New DataTable
        Dt = GlobalService.GetListWorkCenter
        CmbProses.Properties.DataSource = Nothing
        CmbProses.Properties.DataSource = Dt
        CmbProses.Properties.DisplayMember = "Text"
        CmbProses.Properties.ValueMember = "Value"
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If CmbProses.EditValue = "" Then
                CmbProses.Focus()
                Throw New Exception("Pilih Proses")
            End If
            If TxtCode.EditValue = "" Then
                TxtCode.Focus()
                Throw New Exception("Problem Code Harus diisi")
            End If
            If TxtName.Text = "" Then
                TxtName.Focus()
                Throw New Exception("Problem harus diisi")
            End If


            Model = New ProblemModel
            With Model
                .Id = fs_Code.AsInt
                .Proses = CmbProses.EditValue
                .ProblemCode = TxtCode.Text
                .Name = TxtName.Text
            End With
            If fs_Code = "0" Then
                Service.SimpanData(Model)
                ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                Service.UpdateData(Model)
                ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)

            End If
            _Grid.DataSource = Service.GetData()
            Close()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
