Public Class frmDashboard
    Dim _Dept As String
    Dim _Level As Integer
    Public Sub New(Dept As String, Optional Level As Integer = 0)

        ' This call is required by the designer.
        InitializeComponent()
        _Dept = Dept
        _Level = Level
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDashboard(gh_Common.GroupID)
    End Sub

    Private Sub LoadDashboard(Dept As String, Optional Level As Integer = 0)
        Select Case Dept
            Case "1MIS"
                If Not Controls.Contains(DashboardPainting.Instance) Then
                    Controls.Add(DashboardPainting.Instance)
                    DashboardPainting.Instance.Dock = DockStyle.Fill
                    DashboardPainting.Instance.BringToFront()

                End If
                DashboardFinance.Instance.BringToFront()
        End Select
    End Sub

    Private Sub frmDashboard_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            FrmMain.ribbon.SelectedPage = FrmMain.ribbon.Pages(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class