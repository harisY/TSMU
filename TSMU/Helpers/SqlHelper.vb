Imports System.Data.SqlClient
Imports Dapper

Module SqlHelper
    Function GetRecord(Of T)(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As T
        Dim objRecord As T = Nothing

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            objRecord = SqlMapper.Query(Of T)(objConnection, spName, p, commandType:=CommandType.StoredProcedure).FirstOrDefault()
            objConnection.Close()
        End Using

        Return objRecord
    End Function

    Function GetRecords(Of T)(ByVal spName As String, Optional ByVal parameters As List(Of ParameterInfo) = Nothing) As List(Of T)
        Dim recordList As List(Of T) = New List(Of T)()

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            recordList = SqlMapper.Query(Of T)(objConnection, spName, p, commandType:=CommandType.StoredProcedure).ToList()
            objConnection.Close()
        End Using

        Return recordList
    End Function

    Function GetIntRecord(Of T)(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As Integer
        Dim intRecord As Integer = 0

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            Using reader = SqlMapper.ExecuteReader(objConnection, spName, p, commandType:=CommandType.StoredProcedure)

                If reader IsNot Nothing AndAlso reader.Read() Then
                    intRecord = Convert.ToInt32(reader(0).ToString())
                End If
            End Using

            objConnection.Close()
        End Using

        Return intRecord
    End Function

    Function GetBoolRecord(Of T)(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As Boolean
        Dim BoolRecord As Boolean = False

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            Using reader = SqlMapper.ExecuteReader(objConnection, spName, p, commandType:=CommandType.StoredProcedure)

                If reader IsNot Nothing AndAlso reader.Read() Then
                    BoolRecord = Convert.ToBoolean(reader(0).ToString())
                End If
            End Using

            objConnection.Close()
        End Using

        Return BoolRecord
    End Function

    Function GetStringRecord(Of T)(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As String
        Dim BoolRecord As String = String.Empty

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            Using reader = SqlMapper.ExecuteReader(objConnection, spName, p, commandType:=CommandType.StoredProcedure)

                If reader IsNot Nothing AndAlso reader.Read() Then
                    BoolRecord = Convert.ToString(reader(0).ToString())
                End If
            End Using

            objConnection.Close()
        End Using

        Return BoolRecord
    End Function

    Function ExecuteQuery(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As Integer
        Dim success As Integer = 0

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            success = SqlMapper.Execute(objConnection, spName, p, commandType:=CommandType.StoredProcedure)
            objConnection.Close()
        End Using

        Return success
    End Function

    Function ExecuteQueryWithIntOutputParam(ByVal spName As String, ByVal parameters As List(Of ParameterInfo)) As Integer
        Dim success As Integer = 0

        Using objConnection As SqlConnection = New SqlConnection(GetConnString)
            objConnection.Open()
            Dim p As DynamicParameters = New DynamicParameters()

            For Each param In parameters
                p.Add("@" & param.ParameterName, param.ParameterValue)
            Next

            success = SqlMapper.Execute(objConnection, spName, p, commandType:=CommandType.StoredProcedure)
            objConnection.Close()
        End Using

        Return success
    End Function

 
End Module
