Imports System.Collections.ObjectModel
Public Class BudgetSerivce
    Public Function GetAll() As DataTable
        Try
            Dim Sql As String = "t_budget_getDataGrid"
            Dim dt As New DataTable
            dt = GetDataTableSP(Sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetById(Id As Integer) As DRRModel
        Try
            Dim Sql As String = "DRRHeader_GetBydId"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.VarChar)
            pParam(0).Value = Id
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            Dim _Model As New DRRModel
            If dt.Rows.Count > 0 Then
                With _Model
                    .IdDRR = If(IsDBNull(dt.Rows(0)("Id")), 0, Convert.ToInt32(dt.Rows(0)("Id")))
                    .No_NPP = If(IsDBNull(dt.Rows(0)("No_NPP")), "", Convert.ToString(dt.Rows(0)("No_NPP")))
                    .Customer = If(IsDBNull(dt.Rows(0)("Customer")), "", Convert.ToString(dt.Rows(0)("Customer")))
                    .Project = If(IsDBNull(dt.Rows(0)("Project")), "", Convert.ToString(dt.Rows(0)("Project")))
                    .ForecastOrder = If(IsDBNull(dt.Rows(0)("ForecastOrder")), "", Convert.ToString(dt.Rows(0)("ForecastOrder")))
                    .DueDateMaspro = If(IsDBNull(dt.Rows(0)("DueDateMaspro")), Date.Today, Convert.ToDateTime(dt.Rows(0)("DueDateMaspro")))
                    .Tanggal = If(IsDBNull(dt.Rows(0)("Date")), Date.Today, Convert.ToDateTime(dt.Rows(0)("Date")))
                    .Time = If(IsDBNull(dt.Rows(0)("Time")), Date.Now, TimeSpan.Parse(dt.Rows(0)("Time").ToString))
                    .NoDokumen = If(IsDBNull(dt.Rows(0)("NoDokumen")), 0, Convert.ToString(dt.Rows(0)("NoDokumen")))
                    .Gambar1 = If(IsDBNull(dt.Rows(0)("Gambar1")), "", Convert.ToString(dt.Rows(0)("Gambar1")))
                    .Gambar2 = If(IsDBNull(dt.Rows(0)("Gambar2")), "", Convert.ToString(dt.Rows(0)("Gambar2")))
                    .Gambar3 = If(IsDBNull(dt.Rows(0)("Gambar3")), "", Convert.ToString(dt.Rows(0)("Gambar3")))
                    .Gambar4 = If(IsDBNull(dt.Rows(0)("Gambar4")), "", Convert.ToString(dt.Rows(0)("Gambar4")))
                End With
            End If
            Return _Model
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListBudget() As List(Of BudgetModel)
        Try
            Dim parameters As List(Of ParameterInfo) = New List(Of ParameterInfo)()
            Dim Budget As IList(Of BudgetModel) = New List(Of BudgetModel)
            Budget = GetRecords(Of BudgetModel)("t_budget_getDataGrid", parameters)
            Return Budget
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Transaction"
    Public Sub Insert(Header As BudgetModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try

                        Dim IsExist As Boolean
                        For i As Integer = 0 To Header.ObjCollection.Count - 1
                            IsExist = IsBudgetExist(Header, i)
                            If IsExist Then
                                Update(Header, i)
                            Else
                                Insert(Header, i)
                            End If
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Public Function IsBudgetExist(Header As BudgetModel, i As Integer) As Boolean
        Try
            Dim parameters As List(Of ParameterInfo) = New List(Of ParameterInfo)()
            parameters.Add(New ParameterInfo() With {.ParameterName = "Tahun", .ParameterValue = Header.ObjCollection(i).Tahun})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Bulan", .ParameterValue = Header.ObjCollection(i).Bulan})
            parameters.Add(New ParameterInfo() With {.ParameterName = "CustId", .ParameterValue = Header.ObjCollection(i).CustId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "InventoryId", .ParameterValue = Header.ObjCollection(i).InventoryId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "PartNo", .ParameterValue = Header.ObjCollection(i).PartNo})
            Dim _Result As Boolean = GetBoolRecord(Of BudgetModel)("t_budget_isdataExist", parameters)
            Return _Result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Insert(Header As BudgetModel, i As Integer) As Integer
        Try
            Dim parameters As List(Of ParameterInfo) = New List(Of ParameterInfo)()
            parameters.Add(New ParameterInfo() With {.ParameterName = "Tahun", .ParameterValue = Header.ObjCollection(i).Tahun})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Bulan", .ParameterValue = Header.ObjCollection(i).Bulan})
            parameters.Add(New ParameterInfo() With {.ParameterName = "CustId", .ParameterValue = Header.ObjCollection(i).CustId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Customer", .ParameterValue = Header.ObjCollection(i).Customer})
            parameters.Add(New ParameterInfo() With {.ParameterName = "InventoryId", .ParameterValue = Header.ObjCollection(i).InventoryId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Description", .ParameterValue = Header.ObjCollection(i).Description})
            parameters.Add(New ParameterInfo() With {.ParameterName = "PartNo", .ParameterValue = Header.ObjCollection(i).PartNo})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Model", .ParameterValue = Header.ObjCollection(i).Model})
            parameters.Add(New ParameterInfo() With {.ParameterName = "OE", .ParameterValue = Header.ObjCollection(i).OE})
            parameters.Add(New ParameterInfo() With {.ParameterName = "INSub", .ParameterValue = Header.ObjCollection(i).INSub})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Site", .ParameterValue = Header.ObjCollection(i).Site})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Flag", .ParameterValue = "N/A"})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Qty", .ParameterValue = Header.ObjCollection(i).Qty})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Price", .ParameterValue = Header.ObjCollection(i).Price})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Username", .ParameterValue = gh_Common.Username})

            Dim success As Integer = ExecuteQuery("t_budget_insert", parameters)
            Return success
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Update(Header As BudgetModel, i As Integer) As Integer
        Try
            Dim parameters As List(Of ParameterInfo) = New List(Of ParameterInfo)()
            parameters.Add(New ParameterInfo() With {.ParameterName = "Tahun", .ParameterValue = Header.ObjCollection(i).Tahun})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Bulan", .ParameterValue = Header.ObjCollection(i).Bulan})
            parameters.Add(New ParameterInfo() With {.ParameterName = "CustId", .ParameterValue = Header.ObjCollection(i).CustId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Customer", .ParameterValue = Header.ObjCollection(i).Customer})
            parameters.Add(New ParameterInfo() With {.ParameterName = "InventoryId", .ParameterValue = Header.ObjCollection(i).InventoryId})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Description", .ParameterValue = Header.ObjCollection(i).Description})
            parameters.Add(New ParameterInfo() With {.ParameterName = "PartNo", .ParameterValue = Header.ObjCollection(i).PartNo})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Model", .ParameterValue = Header.ObjCollection(i).Model})
            parameters.Add(New ParameterInfo() With {.ParameterName = "OE", .ParameterValue = Header.ObjCollection(i).OE})
            parameters.Add(New ParameterInfo() With {.ParameterName = "INSub", .ParameterValue = Header.ObjCollection(i).INSub})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Site", .ParameterValue = Header.ObjCollection(i).Site})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Flag", .ParameterValue = "N/A"})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Qty", .ParameterValue = Header.ObjCollection(i).Qty})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Price", .ParameterValue = Header.ObjCollection(i).Price})
            parameters.Add(New ParameterInfo() With {.ParameterName = "Username", .ParameterValue = gh_Common.Username})

            Dim success As Integer = ExecuteQuery("t_budget_update", parameters)
            Return success
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
