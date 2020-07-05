Imports System.Data.SqlClient

Public Class ClsDashbard
    Dim dt As DataTable
    Dim ds As DataSet

    Public Property _From As Date
    Public Property _To As Date
    Public Function GetDashboardKanbanSum() As DataTable
        Try

            'SqlDependency.Stop(GetConnString)
            'SqlDependency.Start(GetConnString)

            Dim Query As String = "dashboard_kanban_sum"
            Dim pParam() As SqlParameter = New SqlParameter(1) {}
            pParam(0) = New SqlParameter("@from", SqlDbType.Date)
            pParam(0).Value = _From
            pParam(1) = New SqlParameter("@to", SqlDbType.Date)
            pParam(1).Value = _To
            ds = New DataSet
            dt = New DataTable
            ds = GetDataSetByCommand_Dashboard_SP(Query, "DtKanbanSum", pParam)
            Return ds.Tables("DtKanbanSum")
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Private Sub dep_onchange1(ByVal sender As Object, ByVal e As SqlNotificationEventArgs)

    '    If e.Type = SqlNotificationType.Change Then
    '        GetDashboardKanbanSum()
    '    End If

    'End Sub
End Class
