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
    Public Sub New(ByVal Dt As DataTable, Customer As String, Tahun As String, Bulan As String)
        _Dt = Dt
        _Customer = Customer
        _Tahun = Tahun
        _Bulan = Bulan
    End Sub
    Public Sub GetExcelData()
        Try
            TempTable()
            For Each row As DataRow In _Dt.Rows
                Dim PartNo As String = If(String.IsNullOrEmpty(row("Part No.").ToString), "", row("Part No."))
                Dim N As Integer = If(String.IsNullOrEmpty(row("N").ToString), 0, row("N"))
                Dim N1 As Integer = If(String.IsNullOrEmpty(row("N+1").ToString), 0, row("N+1"))
                Dim N2 As Integer = If(String.IsNullOrEmpty(row("N+2").ToString), 0, row("N+2"))
                Dim N3 As Integer = If(String.IsNullOrEmpty(row("N+3").ToString), 0, row("N+3"))

                If Not String.IsNullOrEmpty(PartNo) Then
                    Dim dtHasil As New DataTable
                    dtHasil = GetInventory(_Customer, PartNo)
                    If dtHasil.Rows.Count > 0 Then
                        Dim InvtID As String = dtHasil.Rows(0)("InvtID").ToString()
                        Dim Descript As String = dtHasil.Rows(0)("Descript").ToString()
                        Dim Custname As String = dtHasil.Rows(0)("Name").ToString()
                        Dim _Model As String = InvtID.Substring(4, 1)

                        Dim Model As String
                        Select Case _Model.ToLower
                            Case "d"
                                Model = ModelN.D.ToString + InvtID.Substring(4, 3)
                            Case "t"
                                Model = ModelN.Taruna
                            Case "f"
                                Model = ModelN.Feroza
                            Case "g"
                                Model = ModelN.GCC
                            Case "z"
                                Model = ModelN.ZEBRA
                            Case Else
                                Model = ModelN.D.ToString + InvtID.Substring(4, 3)
                        End Select
                        Dim Site As String = GetSite(InvtID, PartNo)
                        Dim dr As DataRow = DtTemp.NewRow()
                        dr("Tahun") = _Tahun
                        dr("CustID") = _Customer
                        dr("CustName") = Custname
                        dr("InvtID") = InvtID
                        dr("Description") = Descript
                        dr("PartNo") = PartNo
                        dr("Model") = Model
                        dr("Oe") = "OE"
                        dr("InSub") = ""
                        dr("Site") = Site
                        dr("Flag") = "N/A"
                        dr("N") = N
                        dr("N1") = N1
                        dr("N2") = N2
                        dr("N3") = N3
                        DtTemp.Rows.Add(dr)
                    End If
                End If
            Next

            ObjHeader.ObjForecastCollection.Clear()
            For Each row As DataRow In DtTemp.Rows
                ObjForecast = New forecast_po_model_detail
                With ObjForecast
                    .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun"))
                    .CustID = If(row("CustID") Is DBNull.Value, "", row("CustID"))
                    .Customer = If(row("CustName") Is DBNull.Value, "", row("CustName"))
                    .InvtID = If(row("InvtID") Is DBNull.Value, "", row("InvtID"))
                    .Description = If(row("Description") Is DBNull.Value, "", row("Description"))
                    .PartNo = If(row("PartNo") Is DBNull.Value, "", row("PartNo"))
                    .Model = If(row("Model") Is DBNull.Value, "", row("Model"))
                    .OePe = If(row("Oe") Is DBNull.Value, "", row("Oe"))
                    .INSub = If(row("InSub") Is DBNull.Value, "", row("InSub"))
                    .Site = If(row("Site") Is DBNull.Value, "", row("Site"))
                    .Flag = If(row("Flag") Is DBNull.Value, "N/A", row("Flag").ToString())
                    Select Case _Bulan
                        Case "01"

                    End Select
                    .JanQty1 = If(row("Jan Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty1")))
                    .FebQty1 = If(row("Feb Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty1")))
                    .MarQty1 = If(row("Mar Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty1")))
                    .AprQty1 = If(row("Apr Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty1")))
                    .MeiQty1 = If(row("Mei Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty1")))
                    .JunQty1 = If(row("Jun Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty1")))
                    .JulQty1 = If(row("Jul Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty1")))
                    .AgtQty1 = If(row("Agt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty1")))
                    .SepQty1 = If(row("Sep Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty1")))
                    .OktQty1 = If(row("Okt Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty1")))
                    .NovQty1 = If(row("Nov Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty1")))
                    .DesQty1 = If(row("Des Qty1") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty1")))

                    .JanQty2 = If(row("Jan Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty2")))
                    .FebQty2 = If(row("Feb Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty2")))
                    .MarQty2 = If(row("Mar Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty2")))
                    .AprQty2 = If(row("Apr Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty2")))
                    .MeiQty2 = If(row("Mei Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty2")))
                    .JunQty2 = If(row("Jun Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty2")))
                    .JulQty2 = If(row("Jul Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty2")))
                    .AgtQty2 = If(row("Agt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty2")))
                    .SepQty2 = If(row("Sep Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty2")))
                    .OktQty2 = If(row("Okt Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty2")))
                    .NovQty2 = If(row("Nov Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty2")))
                    .DesQty2 = If(row("Des Qty2") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty2")))

                    .JanQty3 = If(row("Jan Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jan Qty3")))
                    .FebQty3 = If(row("Feb Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Feb Qty3")))
                    .MarQty3 = If(row("Mar Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mar Qty3")))
                    .AprQty3 = If(row("Apr Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Apr Qty3")))
                    .MeiQty3 = If(row("Mei Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Mei Qty3")))
                    .JunQty3 = If(row("Jun Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jun Qty3")))
                    .JulQty3 = If(row("Jul Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Jul Qty3")))
                    .AgtQty3 = If(row("Agt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Agt Qty3")))
                    .SepQty3 = If(row("Sep Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Sep Qty3")))
                    .OktQty3 = If(row("Okt Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Okt Qty3")))
                    .NovQty3 = If(row("Nov Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Nov Qty3")))
                    .DesQty3 = If(row("Des Qty3") Is DBNull.Value, "0", Convert.ToInt32(row("Des Qty3")))

                    .Jan_PO1 = If(row("Jan PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO1")))
                    .Feb_PO1 = If(row("Feb PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO1")))
                    .Mar_PO1 = If(row("Mar PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO1")))
                    .Apr_PO1 = If(row("Apr PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO1")))
                    .Mei_PO1 = If(row("Mei PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO1")))
                    .Jun_PO1 = If(row("Jun PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO1")))
                    .Jul_PO1 = If(row("Jul PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO1")))
                    .Agt_PO1 = If(row("Agt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO1")))
                    .Sep_PO1 = If(row("Sep PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO1")))
                    .Okt_PO1 = If(row("Okt PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO1")))
                    .Nov_PO1 = If(row("Nov PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO1")))
                    .Des_PO1 = If(row("Des PO1") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO1")))

                    .Jan_PO2 = If(row("Jan PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jan PO2")))
                    .Feb_PO2 = If(row("Feb PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Feb PO2")))
                    .Mar_PO2 = If(row("Mar PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mar PO2")))
                    .Apr_PO2 = If(row("Apr PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Apr PO2")))
                    .Mei_PO2 = If(row("Mei PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Mei PO2")))
                    .Jun_PO2 = If(row("Jun PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jun PO2")))
                    .Jul_PO2 = If(row("Jul PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Jul PO2")))
                    .Agt_PO2 = If(row("Agt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Agt PO2")))
                    .Sep_PO2 = If(row("Sep PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Sep PO2")))
                    .Okt_PO2 = If(row("Okt PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Okt PO2")))
                    .Nov_PO2 = If(row("Nov PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Nov PO2")))
                    .Des_PO2 = If(row("Des PO2") Is DBNull.Value, "0", Convert.ToInt32(row("Des PO2")))
                    .created_date = DateTime.Today
                    .created_by = gh_Common.Username
                End With
                ObjHeader.ObjForecastCollection.Add(ObjForecast)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
