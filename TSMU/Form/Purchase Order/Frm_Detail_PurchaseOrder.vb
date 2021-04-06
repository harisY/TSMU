Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class Frm_Detail_PurchaseOrder
    Dim GridDtl As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Integer = 0
    Dim PONumber As String = ""

    Dim isUpdate As Boolean = False
    Private Sub Frm_Detail_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitialSetForm()

        Dim cList As New ContactList()
        cList.Add(New Contact("OR", "Reguler Order"))
        cList.Add(New Contact("DP", "Drop Ship"))
        cList.Add(New Contact("BL", "Blanket Order"))
        cList.Add(New Contact("St", "Standard Order"))

        'bind the lookup editor to the list
        T_TipePO.Properties.DataSource = cList
        T_TipePO.Properties.DisplayMember = "Name"
        T_TipePO.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_TipePO.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_TipePO.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_TipePO.Properties.TextEditStyle = TextEditStyles.Standard


    End Sub


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



    Public Overrides Sub InitialSetForm()

        If fs_Code <> "" Then
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Else
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
            Me.Text = "CIRCULATION FORM "
        End If

        bb_IsUpdate = isUpdate
        bs_MainFormName = FrmParent.Name.ToString()

    End Sub




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl,
                   ByRef _Active_Form As Integer)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If

        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
        Active_Form = _Active_Form
        PONumber = strCode

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim b As String = ""
        b = T_TipePO.EditValue

        T_TipePO.EditValue = "OR"

    End Sub
End Class
