Public Class FrmLogin
    Dim fs_Product As String = ""

    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            If UsernameTextBox.Text.Trim = "" Then
                UsernameTextBox.Focus()
                MsgBox("Please Input User Name!")
            ElseIf PasswordTextBox.Text.Trim = "" Then
                PasswordTextBox.Focus()
                MsgBox("Please Input Password!")
            Else
                gh_Common = New InstanceVariables.CommonHelper
                'gh_Trans = New InstanceVariables.TransactionHelper
                Dim ls_Error As String = ""
                Dim lc_User As New ClassSystemUser1
                lc_User.Username = UsernameTextBox.Text.Trim
                lc_User.Password = PasswordTextBox.Text.Trim
                If lc_User.CheckLoginPasswordBinary(lc_User.Username, PasswordTextBox.Text.Trim) Then
                    'gs_LoginUserID = lc_User.UserName
                    'gs_LoginNamaUser = lc_User.Nama
                    'gb_LoginAdminStatus = lc_User.StatusAdmin
                    gh_Common.Username = lc_User.Username
                    gh_Common.Name = lc_User.Name
                    gh_Common.AdminStatus = lc_User.AdminStatus
                    gh_Common.Group = lc_User.UserGroupName
                    gh_Common.Site = lc_User.Site
                    lc_User.UpdateLastLogin()
                    If ls_Error <> "" Then ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    '# Ambil data tabel setting...
                    Call InitializeApp()
                    'Me.Dispose()
                    Me.Close()
                Else
                    UsernameTextBox.Focus()
                    MsgBox("Wrong Username or Password!")
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
            gs_Error = Err.Description
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call gf_GetDatabaseVariables()
        fs_Product = My.Application.Info.ProductName
        _txtVersion.Text = "Version " & Application.ProductVersion
    End Sub

    Private Sub LoginForm_Shown(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            '# Every time Login window appears, disable all menu...
            Call CloseApp()
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
            UsernameTextBox.Focus()
            MenuUtamaForm.LblDatabase.Text = "Database : " & gs_Database & " (" & gs_DBServer & ")"
        End If
        UsernameTextBox.Focus()
    End Sub
    Private Sub BeginApp()
        MenuUtamaForm.tsmLogin.Text = "Log Out"
        Dim DaftarMenu As ToolStripMenuItem = Nothing
        For Each DaftarMenu In MenuUtamaForm.MenuStrip.Items
            DaftarMenu.Enabled = True
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub CloseApp()
        MenuUtamaForm.tsmLogin.Text = "Log In"
        Dim DaftarMenu As ToolStripMenuItem = Nothing
        For Each DaftarMenu In MenuUtamaForm.MenuStrip.Items
            If DaftarMenu.Name <> "FileToolStripMenuItem" Then DaftarMenu.Enabled = False
        Next
        For Each DaftarMenu In MyMenus
            DaftarMenu.Enabled = False
        Next
        MenuUtamaForm.FileMenu.Enabled = True
        MenuUtamaForm.tsmLogin.Enabled = True
        MenuUtamaForm.ExitToolStripMenuItem.Enabled = True
        MenuUtamaForm.tsnChangePass.Enabled = False
        MenuUtamaForm.LblLogin.Text = ""
        MenuUtamaForm.lblGroup.Text = ""
        'MenuUtamaForm.LblPeriod.Text = ""
        MenuUtamaForm.LblDatabase.Text = ""
        ShowMessage("", MessageTypeEnum.NotBoxMessage)
        'Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FrmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then

            If FrmSystem_ConfigDB.ShowDialog() = Windows.Forms.DialogResult.OK Then
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
                UsernameTextBox.Focus()
                MenuUtamaForm.LblDatabase.Text = "Database : " & gs_Database & " (" & gs_DBServer & ")"
            End If
        End If
    End Sub

    Private Sub FrmLogin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If UsernameTextBox.Text.Trim <> "" And PasswordTextBox.Text.Trim <> "" Then
                OK.PerformClick()
            Else
                Me.SelectNextControl(sender, True, True, True, True)
            End If
        End If
    End Sub
    Private Sub InitializeApp()
        Try
            Dim query As String = ""
            Dim ds As DataSet = Nothing
            Dim ls_Error As String = ""

            gc_Setting = New ClassSystemConfiguration
            fs_Product = "Bill of Material" 'My.Application.Info.AssemblyName

            gc_Setting.GetData()

            If gc_Setting.KodeSetting <> "" Then
                '# Nama & Unit Usaha...
                gs_CompanyName = gc_Setting.NamaPerusahaan.Trim
                gs_CompanyAddress = gc_Setting.Alamat.Trim
                gs_CompanyPhoneNo = gc_Setting.Telp.Trim
                gs_CompanyFaxNo = gc_Setting.Fax.Trim

                'gs_PhysicalFlow = "FIFO" ' gc_Setting.MetodeStok

                '# Nama Form Perusahaan...
                If gs_CompanyName <> "" Then
                    MenuUtamaForm.Text = fs_Product & " - " & gs_CompanyName
                Else
                    'FrmSystem_Menu.Text = fs_Product & " - [Company Name]"
                    'MenuUtamaForm.Text = "TSMU - " & fs_Product
                    MenuUtamaForm.Text = "TSMU "
                End If
                'gd_SumRound = gc_Setting.JumlahRounding
                'gb_RoundUp = gc_Setting.RoundingUp
            Else
                gs_CompanyName = "TSMU"
                gs_CompanyAddress = ""
                gs_CompanyPhoneNo = ""
                gs_CompanyFaxNo = ""

                'gs_PhysicalFlow = "FIFO"

                '# Nama Form Perusahaan...            
                'FrmSystem_Menu.Text = fs_Product & " - [Company Name]"
                'MenuUtamaForm.Text = "TSMU - " & fs_Product
                MenuUtamaForm.Text = "TSMU "
                'gd_SumRound = 1
                'gb_RoundUp = False
            End If

            ''# Load default accounts...
            'query = _
            '"SELECT TOP 1 * FROM tb_SystemSetting" & vbLf & _
            '"SELECT * FROM tb_SystemUserAkses WHERE UserName = " & QVal(gs_LoginUserID) & vbLf & _
            '""
            'ls_Error = GetDataSet(query, ds)
            'If ls_Error <> "" Then ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage) : Exit Sub

            'If ds.Tables(0).Rows.Count > 0 Then
            '    With ds.Tables(0).Rows(0)
            '        '# Nama & Unit Usaha...
            '        gs_CompanyName = Trim(.Item("NamaPerusahaan") & "")
            '        gs_CompanyAddress = Trim(.Item("Alamat") & "")
            '        gs_CompanyPhoneNo = Trim(.Item("Telp") & "")
            '        gs_CompanyFaxNo = Trim(.Item("Fax") & "")

            '        gs_PhysicalFlow = "FIFO" ' Trim(.Item("MetodeStok") & "")

            '        '# Nama Form Perusahaan...
            '        If Trim(.Item("NamaPerusahaan") & "") <> "" Then
            '            FrmSystem_Menu.Text = fs_Product & " - " & Trim(.Item("NamaPerusahaan") & "")
            '        Else
            '            FrmSystem_Menu.Text = fs_Product & " - [Company Name]"
            '        End If
            '        gd_SumRound = NumValue(IIf(Trim(.Item("JumlahRounding") & "") = "", 1, Trim(.Item("JumlahRounding") & "")))
            '        gb_RoundUp = IIf(Trim(.Item("RoundingUp") & "") = "1", True, False)
            '    End With
            'Else
            '    gs_CompanyName = "Takagi"
            '    gs_CompanyAddress = ""
            '    gs_CompanyPhoneNo = ""
            '    gs_CompanyFaxNo = ""

            '    gs_PhysicalFlow = "FIFO"

            '    '# Nama Form Perusahaan...            
            '    FrmSystem_Menu.Text = fs_Product & " - [Company Name]"
            '    gd_SumRound = 1
            '    gb_RoundUp = False
            'End If
            query = _
            "SELECT * FROM S_UserPermission WHERE UserName = " & QVal(gh_Common.Username) & vbLf & _
            ""
            Dim dt As DataTable = MainModul.GetDataTable(query)
            '# Main Menu Display
            MenuUtamaForm.AddMenuNavBar()

            '# User rights ( access, update )...
            'Dim dtRights As DataTable = ds.Tables(1)
            Dim dtRights As DataTable = dt
            dtRights.PrimaryKey = New DataColumn() {dtRights.Columns("KodeMenu")}
            If dtRights.Rows.Count > 0 Then
                Dim MenuItem As ToolStripItem = Nothing
                Dim findRow As DataRow = Nothing
                For Each MenuItem In MyMenus
                    findRow = dtRights.Rows.Find(MenuItem.Name)
                    If findRow IsNot Nothing Then
                        If findRow("HakAkses") = 1 OrElse MenuItem.Name = "FrmSystem_UserSetup" Then
                            MenuItem.Enabled = True
                        Else
                            MenuItem.Enabled = False
                        End If
                    End If
                Next
            End If
            '# Enable menu group...
            BeginApp()
            '# Menu Backup...
            MenuUtamaForm.tsnChangePass.Enabled = True
            '# Settings menu can only be accessed by Admin users...
            'FrmMenu.MenuSetting.Enabled = gb_AdminStatus
            'FrmMenu.FrmSystem_Configuration.Enabled = gb_AdminStatus
            'FrmMenu.FrmSystem_UserSetup.Enabled = gb_AdminStatus
            '# Menu Labels...
            MenuUtamaForm.LblLogin.Text = "User : " & gh_Common.Username
            MenuUtamaForm.lblGroup.Text = "Group : " & gh_Common.Group
            'FrmSystem_Menu.LblPeriod.Text = "Periode " & Format(ServerDate, "MMM-yyyy")
            'FrmMenu.LblDatabase.Text = "File : " & gs_Database & " (" & gs_DBServer & ")"
            '# Form name...

            ShowMessage("", MessageTypeEnum.NotBoxMessage)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
