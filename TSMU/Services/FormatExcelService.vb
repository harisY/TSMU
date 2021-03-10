Imports System.Data.SqlClient

Public Class FormatExcelService

End Class
Public Class AdmService
    Dim ObjAdm As AdmExcelModel
    Dim ObjAdmColl As AdmExcelModel
    Dim ObjForecast As New forecast_po_model_detail
    Dim ObjHeader As New forecast_po_model
    Dim _Dt As New DataTable
    Dim _Customer As String
    Dim _Tahun As String
    Dim _Bulan As String
    Dim _Site As String
    Dim _Flag As String
    Sub New()

    End Sub
    Public Sub New(ByVal Dt As DataTable, Customer As String, Tahun As String, Bulan As String, Site As String, Flag As String)
        _Dt = Dt
        _Customer = Customer
        _Tahun = Tahun
        _Bulan = Bulan
        _Site = Site
        _Flag = Flag
    End Sub
    'Public Function GetExcelData() As DataTable
    '    Try
    '        TempTable()
    '        'Delete_tForecast_Log()
    '        For Each row As DataRow In _Dt.Rows
    '            Dim PartNo As String = If(String.IsNullOrEmpty(row("Part No.").ToString), "", row("Part No."))
    '            'Dim PartName As String = If(String.IsNullOrEmpty(row("Part Name").ToString), "", row("Part Name"))
    '            Dim UniqueNo As String = If(String.IsNullOrEmpty(row("Unique No.").ToString), "", row("Unique No."))
    '            Dim N As Integer = If(String.IsNullOrEmpty(row("N").ToString), 0, row("N"))
    '            Dim N1 As Integer = If(String.IsNullOrEmpty(row("N+1").ToString), 0, row("N+1"))
    '            Dim N2 As Integer = If(String.IsNullOrEmpty(row("N+2").ToString), 0, row("N+2"))
    '            Dim N3 As Integer = If(String.IsNullOrEmpty(row("N+3").ToString), 0, row("N+3"))

    '            If Not String.IsNullOrEmpty(PartNo) Then
    '                Dim dtHasil As New DataTable
    '                dtHasil = GetInventory(_Customer, PartNo)
    '                If dtHasil.Rows.Count > 0 Then
    '                    Dim InvtID As String = dtHasil.Rows(0)("InvtID").ToString()
    '                    Dim Descript As String = dtHasil.Rows(0)("Descript").ToString()
    '                    Dim Custname As String = dtHasil.Rows(0)("Name").ToString()
    '                    If Len(InvtID) > 7 Then
    '                        Dim _Model As String = InvtID.Substring(4, 1)
    '                        Dim Model As String = String.Empty
    '                        Select Case _Model.ToLower
    '                            Case "d"
    '                                Model = "D" & InvtID.Substring(4, 3)
    '                            Case "t"
    '                                Model = "Taruna"
    '                            Case "f"
    '                                Model = "Feroza"
    '                            Case "g"
    '                                Model = "GCC"
    '                            Case "z"
    '                                Model = "ZEBRA"
    '                            Case Else
    '                                Model = ""
    '                                '    Model = ModelN.D.ToString + InvtID.Substring(4, 3)
    '                        End Select
    '                        'Dim Site As String = GetSite(InvtID, PartNo)
    '                        Dim dr As DataRow = DtTemp.NewRow()
    '                        dr("Tahun") = _Tahun
    '                        dr("CustID") = _Customer
    '                        dr("CustName") = Custname
    '                        dr("InvtID") = InvtID
    '                        dr("Description") = Descript
    '                        dr("PartNo") = PartNo
    '                        dr("Model") = Model
    '                        dr("Oe") = "OE"
    '                        dr("InSub") = ""
    '                        dr("Site") = _Site
    '                        dr("Flag") = _Flag
    '                        dr("N") = N
    '                        dr("N1") = N1
    '                        dr("N2") = N2
    '                        dr("N3") = N3
    '                        DtTemp.Rows.Add(dr)
    '                    Else
    '                        'MsgBox(InvtID.ToString & " Kurang dari 5 digit")
    '                    End If
    '                Else
    '                    Add_tForecast_Log(PartNo, UniqueNo, "")
    '                End If
    '                If dtHasil.Rows.Count > 1 Then
    '                    Add_tForecast_Log(PartNo, UniqueNo, "Lebih dari 1 Inventory ID")
    '                End If
    '            End If
    '        Next
    '        Return DtTemp
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetExcelData() As DataTable
        Try
            TempTable()
            'Delete_tForecast_Log()
            For Each row As DataRow In _Dt.Rows
                Dim PartNo As String = If(String.IsNullOrEmpty(row("Part No.").ToString), "", row("Part No."))
                'Dim PartName As String = If(String.IsNullOrEmpty(row("Part Name").ToString), "", row("Part Name"))
                Dim UniqueNo As String = If(String.IsNullOrEmpty(row("Unique No.").ToString), "", row("Unique No."))
                Dim N As Integer = If(String.IsNullOrEmpty(row("N").ToString), 0, row("N"))
                Dim N1 As Integer = If(String.IsNullOrEmpty(row("N+1").ToString), 0, row("N+1"))
                Dim N2 As Integer = If(String.IsNullOrEmpty(row("N+2").ToString), 0, row("N+2"))
                Dim N3 As Integer = If(String.IsNullOrEmpty(row("N+3").ToString), 0, row("N+3"))

                If Not String.IsNullOrEmpty(PartNo) Then
                    Dim dtHasil As New DataTable
                    dtHasil = GetInventory(_Customer, PartNo)
                    If dtHasil.Rows.Count > 0 Then
                        For Each row1 As DataRow In dtHasil.Rows
                            Dim InvtID As String = row1("InvtID").ToString().AsString
                            Dim Descript As String = row1("Descript").ToString().AsString
                            Dim Custname As String = row1("Name").ToString().AsString
                            Dim Model As String = String.Empty
                            If Len(InvtID) > 7 Then
                                Dim _Model As String = InvtID.Substring(4, 1)
                                Select Case _Model.ToLower
                                    Case "t"
                                        Model = "Taruna"
                                    Case "f"
                                        Model = "Feroza"
                                    Case "g"
                                        Model = "GCC"
                                    Case "z"
                                        Model = "ZEBRA"
                                    Case Else
                                        Model = InvtID.Substring(4, 3)
                                        '    Model = ModelN.D.ToString + InvtID.Substring(4, 3)
                                End Select
                                'Dim Site As String = GetSite(InvtID, PartNo)
                            End If
                            Dim dr As DataRow = DtTemp.NewRow()
                            dr("Check") = True
                            dr("Tahun") = _Tahun
                            dr("CustID") = _Customer
                            dr("CustName") = Custname
                            dr("InvtID") = InvtID
                            dr("Description") = Descript
                            dr("PartNo") = PartNo
                            dr("Model") = Model.AsString
                            dr("Oe") = "OE"
                            dr("InSub") = ""
                            dr("Site") = _Site
                            dr("Flag") = _Flag
                            dr("N") = N
                            dr("N1") = N1
                            dr("N2") = N2
                            dr("N3") = N3
                            DtTemp.Rows.Add(dr)
                        Next
                    Else
                        Dim dr As DataRow = DtTemp.NewRow()
                        dr("Check") = True
                        dr("Tahun") = _Tahun
                        dr("CustID") = _Customer
                        dr("CustName") = "N/A"
                        dr("InvtID") = "N/A"
                        dr("Description") = "N/A"
                        dr("PartNo") = PartNo
                        dr("Model") = "N/A"
                        dr("Oe") = "OE"
                        dr("InSub") = ""
                        dr("Site") = _Site
                        dr("Flag") = _Flag
                        dr("N") = N
                        dr("N1") = N1
                        dr("N2") = N2
                        dr("N3") = N3
                        DtTemp.Rows.Add(dr)
                        Add_tForecast_Log(PartNo, UniqueNo, "")
                    End If
                    If dtHasil.Rows.Count > 1 Then
                        Add_tForecast_Log(PartNo, UniqueNo, "Lebih dari 1 Inventory ID")
                    End If
                End If
            Next
            Return DtTemp
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Enum ModelN
        D
        Feroza
        GCC
        Taruna
        ZEBRA
    End Enum
    Public Function GetInventory(Entity As String, PartNo As String) As DataTable
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "Entity", .Value = Entity})
            Params.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = PartNo})
            Dim dt As New DataTable
            dt = GetDataTableByParam("ItemXRef_GetInvtID", CommandType.StoredProcedure, Params, GetConnString)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Add_tForecast_Log(PartNo As String, UniqueNo As String, Ket As String)
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = PartNo})
            Params.Add(New SqlParameter() With {.ParameterName = "UniqueNo", .Value = UniqueNo})
            Params.Add(New SqlParameter() With {.ParameterName = "Ket", .Value = Ket})
            ExecQueryWithValue("tForecastPrice_Log_Insert", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete_tForecast_Log()
        Try
            ExecQueryWithValue("tForecastPrice_Log_Delete", CommandType.StoredProcedure, Nothing, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetSite(InvtID As String, PartNo As String) As String
        Try
            Dim Hasil As String = String.Empty
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "InvtID", .Value = InvtID})
            Params.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = PartNo})
            Dim dt As New DataTable
            dt = GetDataTableByParam("SOLine_GetSite", CommandType.StoredProcedure, Params, GetConnString)
            If dt.Rows.Count > 0 Then
                Hasil = dt.Rows(0)(0).ToString()
            End If
            Return Hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Dim DtTemp As DataTable
    Private Sub TempTable()
        DtTemp = New DataTable
        DtTemp.Columns.Add("Check", GetType(Boolean))
        DtTemp.Columns.Add("Tahun", GetType(String))
        DtTemp.Columns.Add("CustID", GetType(String))
        DtTemp.Columns.Add("CustName", GetType(String))
        DtTemp.Columns.Add("InvtID", GetType(String))
        DtTemp.Columns.Add("Description", GetType(String))
        DtTemp.Columns.Add("PartNo", GetType(String))
        DtTemp.Columns.Add("Model", GetType(String))
        DtTemp.Columns.Add("Oe", GetType(String))
        DtTemp.Columns.Add("InSub", GetType(String))
        DtTemp.Columns.Add("Site", GetType(String))
        DtTemp.Columns.Add("Flag", GetType(String))
        DtTemp.Columns.Add("N", GetType(Integer))
        DtTemp.Columns.Add("N1", GetType(Integer))
        DtTemp.Columns.Add("N2", GetType(Integer))
        DtTemp.Columns.Add("N3", GetType(Integer))
        DtTemp.Clear()
    End Sub
End Class
