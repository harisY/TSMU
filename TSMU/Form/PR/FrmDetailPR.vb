Imports DevExpress.XtraGrid

Public Class FrmDetailPR

    Dim Grid As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Int32 = 0
    Dim PRNo As String = ""
    Dim indicatorIcon As Boolean = True




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
        Grid = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
        Active_Form = _Active_Form
        PRNo = strCode
    End Sub


    Private Sub FrmDetailPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridView3_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView3.CustomDrawRowIndicator
        ' GridView1
    End Sub
End Class
