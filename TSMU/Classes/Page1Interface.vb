Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Reflection

Public Class Page1Interface
    Implements IUserInterface

    Private Function GetUserInterface() As IEnumerable(Of MenuItem) Implements IUserInterface.GetUserInterface

        Dim sql As String = "GetMenuByUser"
        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@userName", SqlDbType.VarChar)
        param(0).Value = gh_Common.Username
        Dim dt As New DataTable
        dt = GetDataTableByCommand_SP(sql, param)
        Dim menus As List(Of MenuItem) = New List(Of MenuItem)()
        For Each row As DataRow In dt.Rows
            Dim openFormH As Form = Nothing
            Dim openFormD As Form = Nothing

            'openFormH = MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & row("MenuCode"))
            menus.Add(New MenuItem With {
                .Page = row("ParentMenu"),
                .PageIndex = 0,
                .Group = If(IsDBNull(row("ParentMenuChild")), row("ParentMenu"), row("ParentMenuChild")),
                .GroupIndex = 0,
                .Text = row("Title"),
                .Index = row("GroupIndex"),
                .Image = If(IsDBNull(row("Image")), My.Resources.map, My.Resources.ResourceManager.GetObject(row("Image"))),
                .Icon = My.Resources.map,
                .Type = row("MenuCode"),' GetType(), 'Type.GetType(row("MenuCode"), True, True),
                .Key = 1016,
                .Dialog = row("FlagFullScreen")
                })

            'If IsDBNull(row("ParentMenuChild")) Then
            '    menus.Add(New MenuItem With {
            '    .Page = row("ParentMenu"),
            '    .PageIndex = 0,
            '    .Group = row("ParentMenuChild"),
            '    .GroupIndex = 0,
            '    .Text = row("Title"),
            '    .Index = row("GroupIndex"),
            '    .Image = My.Resources.addressbook32,
            '    .Icon = My.Resources.Resources.addressbook32,
            '    .Type = openFormH,' GetType(), 'Type.GetType(row("MenuCode"), True, True),
            '    .Key = 1016
            '})
            'Else
            '    menus.Add(New MenuItem With {
            '    .Page = row("ParentMenu"),
            '    .PageIndex = 0,
            '    .Group = row("ParentMenuChild"),
            '    .GroupIndex = 0,
            '    .Text = row("Title"),
            '    .Index = row("GroupIndex"),
            '    .Image = My.Resources.addressbook32,
            '    .Icon = My.Resources.Resources.addressbook32,
            '    .Key = 1016,
            '    .Items = New List(Of MenuItem) From {
            '            New MenuItem With {
            '                .Text = row("Title"),
            '                .Index = row("GroupIndex"),
            '                .Image = My.Resources.delete_route,
            '                .Icon = My.Resources.arrow,
            '                .Type = openFormH,
            '                .Key = 1012
            '            }
            '    }
            '})
            'End If

        Next
        'MyAss.CreateInstance(My.Application.Info.AssemblyName & "." & row("ParentMenu")))
        'Dim menus As List(Of MenuItem) = New List(Of MenuItem) From {
        '    New MenuItem With {
        '        .Page = "Page 1",
        '        .PageIndex = 0,
        '        .Group = "Group 1",
        '        .GroupIndex = 0,
        '        .Text = "Form 1",
        '        .Index = 0,
        '        .Image = My.Resources.addressbook32,
        '        .Icon = My.Resources.Resources.addressbook32,
        '        .Type = GetType(Form1),
        '        .Key = 1016,
        '        .Dialog = True
        '    },
        '    New MenuItem With {
        '        .Page = "Page 1",
        '        .PageIndex = 0,
        '        .Group = "Group 1",
        '        .GroupIndex = 0,
        '        .Text = "Form 2",
        '        .Index = 1,
        '        .Image = My.Resources.Resources.map32,
        '        .Icon = My.Resources.Resources.map24,
        '        .Type = GetType(frmBoM),
        '        .Key = 1016
        '    },
        '    New MenuItem With {
        '        .Page = "Page 1",
        '        .PageIndex = 0,
        '        .Group = "Group 2",
        '        .GroupIndex = 1,
        '        .Text = "Form 3",
        '        .Index = 0,
        '        .Image = My.Resources.Resources.multivehicle32,
        '        .Icon = My.Resources.Resources.multivehicle24,
        '        .Key = 1016,
        '        .Items = New List(Of MenuItem) From {
        '            New MenuItem With {
        '                .Text = "Form 4",
        '                .Index = 0,
        '                .Image = My.Resources.Resources.delete_route,
        '                .Icon = My.Resources.Resources.arrow,
        '                .Type = GetType(Form4),
        '                .Key = 1012
        '            }
        '        }
        '    }
        '}
        Return menus
    End Function
End Class
