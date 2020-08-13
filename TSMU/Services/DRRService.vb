Imports System.Collections.ObjectModel

Public Class DRRService
    Dim _globalService As GlobalService
    Public Property DetailModel() As New Collection(Of DRRDetail)
    'Public Property DetailModel() As New Collection(Of DRRModel)
    'Public Property _DrrModel As New DRRModel
#Region "HEADER"
    Public Function GetAll() As DataTable
        Try
            Dim Sql As String = "DRRHeader_GetAllData"
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
    Public Function GetDataByDate(Dari As Date, Sampai As Date) As DataTable
        Try
            Dim Sql As String = "DRRHeader_GetDataByDate"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Dari", SqlDbType.Date)
            pParam(0).Value = Dari
            pParam(1) = New SqlClient.SqlParameter("@Sampai", SqlDbType.Date)
            pParam(1).Value = Sampai
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCustomer() As DataTable
        Try
            Dim Sql As String = "DRR_getCustomer"
            Dim dt As New DataTable
            dt = GetDataTableSP(Sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNPP() As DataTable
        Try
            Dim Sql As String = "DRR_GetNPP"
            Dim dt As New DataTable
            dt = GetDataTableSP(Sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddHeader(ByVal Model As DRRModel) As Integer
        Try
            Dim _result As Integer = 0
            Dim Sql As String = "DRRHeader_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(13) {}
            pParam(0) = New SqlClient.SqlParameter("@No_NPP", SqlDbType.VarChar)
            pParam(0).Value = Model.No_NPP
            pParam(1) = New SqlClient.SqlParameter("@Customer", SqlDbType.VarChar)
            pParam(1).Value = Model.Customer
            pParam(2) = New SqlClient.SqlParameter("@Project", SqlDbType.VarChar)
            pParam(2).Value = Model.Project
            pParam(3) = New SqlClient.SqlParameter("@ForecastOrder", SqlDbType.VarChar)
            pParam(3).Value = Model.ForecastOrder
            pParam(4) = New SqlClient.SqlParameter("@DueDateMaspro", SqlDbType.Date)
            pParam(4).Value = Model.DueDateMaspro
            pParam(5) = New SqlClient.SqlParameter("@Date", SqlDbType.Date)
            pParam(5).Value = Model.Tanggal
            pParam(6) = New SqlClient.SqlParameter("@Time", SqlDbType.Time)
            pParam(6).Value = Model.Time
            pParam(7) = New SqlClient.SqlParameter("@NoDokumen", SqlDbType.VarChar)
            pParam(7).Value = Model.NoDokumen
            pParam(8) = New SqlClient.SqlParameter("@Gambar1", SqlDbType.VarChar)
            pParam(8).Value = Model.Gambar1
            pParam(9) = New SqlClient.SqlParameter("@Gambar2", SqlDbType.VarChar)
            pParam(9).Value = Model.Gambar2
            pParam(10) = New SqlClient.SqlParameter("@Gambar3", SqlDbType.VarChar)
            pParam(10).Value = Model.Gambar3
            pParam(11) = New SqlClient.SqlParameter("@Gambar4", SqlDbType.VarChar)
            pParam(11).Value = Model.Gambar4
            pParam(12) = New SqlClient.SqlParameter("@Gambar5", SqlDbType.VarChar)
            pParam(12).Value = Model.Gambar5
            pParam(13) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            pParam(13).Value = gh_Common.Username
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            If dt.Rows.Count > 0 Then
                _result = CInt(dt.Rows(0)(0))
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateHeader(ByVal Model As DRRModel)
        Try
            Dim _result As Integer = 0
            Dim Sql As String = "DRRHeader_Update"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(11) {}
            pParam(0) = New SqlClient.SqlParameter("@Id", SqlDbType.Int)
            pParam(0).Value = Model.IdDRR
            pParam(1) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            pParam(1).Value = gh_Common.Username
            pParam(2) = New SqlClient.SqlParameter("@ForecastOrder", SqlDbType.VarChar)
            pParam(2).Value = Model.ForecastOrder
            pParam(3) = New SqlClient.SqlParameter("@DueDateMaspro", SqlDbType.Date)
            pParam(3).Value = Model.DueDateMaspro
            pParam(4) = New SqlClient.SqlParameter("@Date", SqlDbType.Date)
            pParam(4).Value = Model.Tanggal
            pParam(5) = New SqlClient.SqlParameter("@Time", SqlDbType.Time)
            pParam(5).Value = Model.Time
            pParam(6) = New SqlClient.SqlParameter("@NoDokumen", SqlDbType.VarChar)
            pParam(6).Value = Model.NoDokumen
            pParam(7) = New SqlClient.SqlParameter("@Gambar1", SqlDbType.VarChar)
            pParam(7).Value = Model.Gambar1
            pParam(8) = New SqlClient.SqlParameter("@Gambar2", SqlDbType.VarChar)
            pParam(8).Value = Model.Gambar2
            pParam(9) = New SqlClient.SqlParameter("@Gambar3", SqlDbType.VarChar)
            pParam(9).Value = Model.Gambar3
            pParam(10) = New SqlClient.SqlParameter("@Gambar4", SqlDbType.VarChar)
            pParam(10).Value = Model.Gambar4
            pParam(11) = New SqlClient.SqlParameter("@Gambar5", SqlDbType.VarChar)
            pParam(11).Value = Model.Gambar5
            'pParam(12) = New SqlClient.SqlParameter("@CreatedBy", SqlDbType.VarChar)
            'pParam(12).Value = gh_Common.Username
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Unrelease(IdDrr As Integer)
        Try
            Dim _result As Integer = 0
            Dim Sql As String = "DRRHeader_Unrelease"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
            pParam(0).Value = IdDrr
            pParam(1) = New SqlClient.SqlParameter("@username", SqlDbType.VarChar)
            pParam(1).Value = gh_Common.Username
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Release(IdDrr As Integer)
        Try
            Dim _result As Integer = 0
            Dim Sql As String = "DRRHeader_Release"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@IdDrr", SqlDbType.Int)
            pParam(0).Value = IdDrr
            pParam(1) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(1).Value = gh_Common.Username

            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function IsRelease(IdDrr As Integer) As Boolean
        Dim _result As Boolean = False
        Try
            Dim Sql As String = "DRRHeader_IsRelease"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@IdDrr", SqlDbType.Int)
            pParam(0).Value = IdDrr
            Dim dt As New DataTable

            dt = GetDataTableByCommand_SP(Sql, pParam)
            If dt.Rows.Count > 0 Then
                _result = Convert.ToBoolean(dt.Rows(0)(0))
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetEmailByNPP(NPP As String) As String
        Dim _result As String = String.Empty
        Try
            Dim Sql As String = "NPP_Head_getCreatedBy"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NoNPP", SqlDbType.VarChar)
            pParam(0).Value = NPP
            Dim dt As New DataTable

            dt = GetDataTableByCommand_SP(Sql, pParam)
            If dt.Rows.Count > 0 Then
                _result = If(IsDBNull(dt.Rows(0)(0)), "", dt.Rows(0)(0).ToString())
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteHeader(Id As Integer)
        Try
            Dim Sql As String = "DRRHeader_Delete"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
            pParam(0).Value = Id
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "DETAIL"
    Public Function DetailGetById(Id As Integer) As DataTable
        Try
            Dim Sql As String = "DRRdetail_GetById"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
            pParam(0).Value = Id
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetPartName(NoNPP As String) As DataTable
        Try
            Dim Sql As String = "Drr_PopulatePartName"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@NoNPP", SqlDbType.VarChar)
            pParam(0).Value = NoNPP
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub AddDetail(ByVal Model As DRRDetail, IdDrr As Integer)
        Try
            Dim Sql As String = "DRRdetail_Insert"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(19) {}
            pParam(0) = New SqlClient.SqlParameter("@IdDrr", SqlDbType.Int)
            pParam(0).Value = IdDrr
            pParam(1) = New SqlClient.SqlParameter("@Level", SqlDbType.Int)
            pParam(1).Value = Model.Level
            pParam(2) = New SqlClient.SqlParameter("@Part_Name", SqlDbType.VarChar)
            pParam(2).Value = Model.Part_Name
            pParam(3) = New SqlClient.SqlParameter("@Part_No", SqlDbType.VarChar)
            pParam(3).Value = Model.Part_No
            pParam(4) = New SqlClient.SqlParameter("@Proses", SqlDbType.VarChar)
            pParam(4).Value = Model.Proses
            pParam(5) = New SqlClient.SqlParameter("@Qty", SqlDbType.Int)
            pParam(5).Value = Model.Qty
            pParam(6) = New SqlClient.SqlParameter("@Cavity", SqlDbType.VarChar)
            pParam(6).Value = Model.Cavity
            pParam(7) = New SqlClient.SqlParameter("@Tonage", SqlDbType.VarChar)
            pParam(7).Value = Model.Tonage
            pParam(8) = New SqlClient.SqlParameter("@Material", SqlDbType.VarChar)
            pParam(8).Value = Model.Material
            pParam(9) = New SqlClient.SqlParameter("@Part", SqlDbType.Float)
            pParam(9).Value = Model.Part
            pParam(10) = New SqlClient.SqlParameter("@Runner", SqlDbType.Float)
            pParam(10).Value = Model.Runner
            pParam(11) = New SqlClient.SqlParameter("@Long", SqlDbType.Float)
            pParam(11).Value = Model.Loong
            pParam(12) = New SqlClient.SqlParameter("@Width", SqlDbType.Float)
            pParam(12).Value = Model.Width
            pParam(13) = New SqlClient.SqlParameter("@Height", SqlDbType.Float)
            pParam(13).Value = Model.Height
            pParam(14) = New SqlClient.SqlParameter("@SurfaceTreatment", SqlDbType.VarChar)
            pParam(14).Value = Model.SurfaceTreatment
            pParam(15) = New SqlClient.SqlParameter("@CT", SqlDbType.Float)
            pParam(15).Value = Model.CT
            pParam(16) = New SqlClient.SqlParameter("@Thickn", SqlDbType.Float)
            pParam(16).Value = Model.Thickn
            pParam(17) = New SqlClient.SqlParameter("@Reference", SqlDbType.VarChar)
            pParam(17).Value = Model.Reference
            pParam(18) = New SqlClient.SqlParameter("@Remark", SqlDbType.VarChar)
            pParam(18).Value = Model.Remark
            pParam(19) = New SqlClient.SqlParameter("@Npp_Seq", SqlDbType.Int)
            pParam(19).Value = Model.Npp_Seq
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDetail(Id As Integer)
        Try
            Dim Sql As String = "DRRDetail_Delete"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@id", SqlDbType.Int)
            pParam(0).Value = Id
            ExecQueryByCommand_SP(Sql, pParam)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "TRANSANTION"
    Public Sub Insert(Header As DRRModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        Dim idDrr As Integer = 0
                        idDrr = AddHeader(Header)

                        For i As Integer = 0 To DetailModel.Count - 1
                            AddDetail(DetailModel(i), idDrr)
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(Header As DRRModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        UpdateHeader(Header)
                        DeleteDetail(Header.IdDRR)

                        For i As Integer = 0 To DetailModel.Count - 1
                            AddDetail(DetailModel(i), Header.IdDRR)
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(Id As Integer)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        DeleteHeader(Id)
                        DeleteDetail(Id)

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
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

End Class
