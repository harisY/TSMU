Imports System.Runtime.CompilerServices
Module Extensions
    <Extension()>
    Function AsId(ByVal item As Object, ByVal Optional defaultId As Integer = -1) As Integer
        If item Is Nothing Then Return defaultId
        Dim result As Integer
        If Not Integer.TryParse(item.ToString(), result) Then Return defaultId
        Return result
    End Function
    <Extension()>
    Function AsInt(ByVal item As Object, ByVal Optional defaultInt As Integer = 0) As Integer
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultInt
        Dim result As Integer
        If Not Integer.TryParse(item.ToString(), result) Then Return defaultInt
        Return result
    End Function

    <Extension()>
    Function AsDouble(ByVal item As Object, ByVal Optional defaultDouble As Double = Nothing) As Double
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultDouble
        Dim result As Double
        If Not Double.TryParse(item.ToString(), result) Then Return defaultDouble
        Return result
    End Function
    <Extension()>
    Function AsFloat(ByVal item As Object, ByVal Optional defaultFloat As Double = 0) As Double
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultFloat
        Dim result As Double
        If Not Single.TryParse(item.ToString(), result) Then Return defaultFloat
        Return result
    End Function
    <Extension()>
    Function AsString(ByVal item As Object, ByVal Optional defaultString As String = "") As String
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultString
        Return item.ToString().Trim()
    End Function
    <Extension()>
    Function AsTime(ByVal item As Object, ByVal Optional defaultTime As TimeSpan = Nothing) As TimeSpan
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultTime
        Dim result As TimeSpan
        If Not TimeSpan.TryParse(item.ToString(), result) Then Return defaultTime
        Return result
    End Function
    <Extension()>
    Function AsDateTime(ByVal item As Object, ByVal Optional defaultDateTime As Date = Nothing) As Date
        If item Is Nothing OrElse String.IsNullOrEmpty(item.ToString()) OrElse item.Equals(DBNull.Value) Then Return defaultDateTime
        Dim result As Date
        If Not Date.TryParse(item.ToString(), result) Then Return defaultDateTime
        Return result
    End Function
    <Extension()>
    Function AsBool(ByVal item As Object, ByVal Optional defaultBool As Boolean = Nothing) As Boolean
        If item Is Nothing OrElse item.Equals(DBNull.Value) Then Return defaultBool
        Return New List(Of String)() From {
            "yes",
            "y",
            "true"
        }.Contains(item.ToString().ToLower())
    End Function
    <Extension()>
    Function AsByteArray(ByVal s As String) As Byte()
        If String.IsNullOrEmpty(s) Then Return Nothing
        Return Convert.FromBase64String(s)
    End Function
    <Extension()>
    Function AsBase64String(ByVal item As Object) As String
        If item Is Nothing Then Return Nothing
        Return Convert.ToBase64String(CType(item, Byte()))
    End Function
    <Extension()>
    Function AsGuid(ByVal item As Object) As Guid
        Try
            Return New Guid(item.ToString())
        Catch
            Return Guid.Empty
        End Try
    End Function
    <Extension()>
    Function OrderBy(ByVal sql As String, ByVal sortExpression As String) As String
        If String.IsNullOrEmpty(sortExpression) Then Return sql
        Return sql & " ORDER BY " & sortExpression
    End Function
    <Extension()>
    Function CommaSeparate(Of T, U)(ByVal source As IEnumerable(Of T), ByVal func As Func(Of T, U)) As String
        Return String.Join(",", source.[Select](Function(s) func(s).ToString()).ToArray())
    End Function
End Module
