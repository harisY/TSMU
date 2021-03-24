Public Class HROrgService
    Dim strQuery As String = String.Empty

    Public Function GetStrukturOrg(TglMulai As Date) As DataTable
        Try
            Dim Sql As String = "HR_GetStrukturOrg"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = TglMulai

            Dim dt As New DataTable

            dt = GetDataTableByCommand_SP(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListOrgLevel() As DataTable
        Try
            strQuery = "SELECT  OrgLevel ,
                                OrgLevelDesc
                        FROM    dbo.S_HROrgLevel"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetOrganisasiByID(ByVal _OrgID As String) As HROrgOrganisasiModel
        Try
            strQuery = "SELECT  TglMulai ,
                                TglSelesai ,
                                OrgID ,
                                OrgDesc ,
                                OrgLevel ,
                                Alias ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HROrgOrganisasi
                        WHERE   OrgID = " & QVal(_OrgID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelOrganisasi As New HROrgOrganisasiModel
            If dt.Rows.Count > 0 Then
                With modelOrganisasi
                    .TglMulai = If(IsDBNull(dt.Rows(0).Item("TglMulai")), Date.Today, dt.Rows(0).Item("TglMulai"))
                    .TglSelesai = If(IsDBNull(dt.Rows(0).Item("TglSelesai")), Date.Today, dt.Rows(0).Item("TglSelesai"))
                    .OrgID = If(IsDBNull(dt.Rows(0).Item("OrgID")), "", dt.Rows(0).Item("OrgID").ToString())
                    .OrgDesc = If(IsDBNull(dt.Rows(0).Item("OrgDesc")), "", dt.Rows(0).Item("OrgDesc").ToString())
                    .OrgLevel = If(IsDBNull(dt.Rows(0).Item("OrgLevel")), "", dt.Rows(0).Item("OrgLevel").ToString())
                    .Alias_ = If(IsDBNull(dt.Rows(0).Item("Alias")), "", dt.Rows(0).Item("Alias").ToString())
                    .Ket = If(IsDBNull(dt.Rows(0).Item("Ket")), "", dt.Rows(0).Item("Ket").ToString())
                    .TglBuat = If(IsDBNull(dt.Rows(0).Item("TglBuat")), DateTime.Now, dt.Rows(0).Item("TglBuat"))
                    .UserBuat = If(IsDBNull(dt.Rows(0).Item("UserBuat")), "", dt.Rows(0).Item("UserBuat").ToString())
                    .TglUbah = If(IsDBNull(dt.Rows(0).Item("TglUbah")), DateTime.Now, dt.Rows(0).Item("TglUbah"))
                    .UserUbah = If(IsDBNull(dt.Rows(0).Item("UserUbah")), "", dt.Rows(0).Item("UserUbah").ToString())
                End With
            End If
            Return modelOrganisasi
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetJabatanByID(ByVal _OrgID As String) As HROrgJabatanModel
        Try
            strQuery = "SELECT  TglMulai ,
                                TglSelesai ,
                                OrgID ,
                                OrgDesc ,
                                IsHead ,
                                Alias ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HROrgJabatan
                        WHERE   OrgID = " & QVal(_OrgID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelJabatan As New HROrgJabatanModel
            If dt.Rows.Count > 0 Then
                With modelJabatan
                    .TglMulai = If(IsDBNull(dt.Rows(0).Item("TglMulai")), Date.Today, dt.Rows(0).Item("TglMulai"))
                    .TglSelesai = If(IsDBNull(dt.Rows(0).Item("TglSelesai")), Date.Today, dt.Rows(0).Item("TglSelesai"))
                    .OrgID = If(IsDBNull(dt.Rows(0).Item("OrgID")), "", dt.Rows(0).Item("OrgID").ToString())
                    .OrgDesc = If(IsDBNull(dt.Rows(0).Item("OrgDesc")), "", dt.Rows(0).Item("OrgDesc").ToString())
                    .IsHead = If(IsDBNull(dt.Rows(0).Item("IsHead")), "", dt.Rows(0).Item("IsHead").ToString())
                    .Alias_ = If(IsDBNull(dt.Rows(0).Item("Alias")), "", dt.Rows(0).Item("Alias").ToString())
                    .Ket = If(IsDBNull(dt.Rows(0).Item("Ket")), "", dt.Rows(0).Item("Ket").ToString())
                    .TglBuat = If(IsDBNull(dt.Rows(0).Item("TglBuat")), DateTime.Now, dt.Rows(0).Item("TglBuat"))
                    .UserBuat = If(IsDBNull(dt.Rows(0).Item("UserBuat")), "", dt.Rows(0).Item("UserBuat").ToString())
                    .TglUbah = If(IsDBNull(dt.Rows(0).Item("TglUbah")), DateTime.Now, dt.Rows(0).Item("TglUbah"))
                    .UserUbah = If(IsDBNull(dt.Rows(0).Item("UserUbah")), "", dt.Rows(0).Item("UserUbah").ToString())
                End With
            End If
            Return modelJabatan
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveNewOrgJabatan(OrgJabatan As HROrgJabatanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertOrgJabatan(OrgJabatan)
                        InsertOrgStruktur(OrgStruktur)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveEditOrgJabatan(Now As Date, OrgJabatan As HROrgJabatanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditOrgJabatan(OrgJabatan)
                        EditOrgStruktur(Now, OrgStruktur)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveNewOrgOrganisasi(OrgOrganisasi As HROrgOrganisasiModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertOrgOrganisasi(OrgOrganisasi)
                        InsertOrgStruktur(OrgStruktur)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveEditOrgOrganisasi(Now As Date, OrgOrganisasi As HROrgOrganisasiModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditOrgOrganisasi(OrgOrganisasi)
                        EditOrgStruktur(Now, OrgStruktur)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertOrgStruktur(OrgStruktur As HROrgStrukturModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgInsertStruktur"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(11) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgStruktur.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgStruktur.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgStruktur.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgClass", SqlDbType.VarChar)
            pParam(3).Value = OrgStruktur.OrgClass
            pParam(4) = New SqlClient.SqlParameter("@RelTipe", SqlDbType.VarChar)
            pParam(4).Value = OrgStruktur.RelTipe
            pParam(5) = New SqlClient.SqlParameter("@RelClass", SqlDbType.VarChar)
            pParam(5).Value = OrgStruktur.RelClass
            pParam(6) = New SqlClient.SqlParameter("@RelOrg", SqlDbType.VarChar)
            pParam(6).Value = OrgStruktur.RelOrg
            pParam(7) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(7).Value = OrgStruktur.Ket
            pParam(8) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(8).Value = OrgStruktur.TglBuat
            pParam(9) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(9).Value = OrgStruktur.UserBuat
            pParam(10) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(10).Value = OrgStruktur.TglUbah
            pParam(11) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(11).Value = OrgStruktur.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditOrgStruktur(Now As Date, OrgStruktur As HROrgStrukturModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgEditStruktur"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
            pParam(0) = New SqlClient.SqlParameter("@Now", SqlDbType.Date)
            pParam(0).Value = Now
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = OrgStruktur.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = OrgStruktur.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(3).Value = OrgStruktur.OrgID
            pParam(4) = New SqlClient.SqlParameter("@OrgClass", SqlDbType.VarChar)
            pParam(4).Value = OrgStruktur.OrgClass
            pParam(5) = New SqlClient.SqlParameter("@RelTipe", SqlDbType.VarChar)
            pParam(5).Value = OrgStruktur.RelTipe
            pParam(6) = New SqlClient.SqlParameter("@RelClass", SqlDbType.VarChar)
            pParam(6).Value = OrgStruktur.RelClass
            pParam(7) = New SqlClient.SqlParameter("@RelOrg", SqlDbType.VarChar)
            pParam(7).Value = OrgStruktur.RelOrg
            pParam(8) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(8).Value = OrgStruktur.Ket
            pParam(9) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(9).Value = OrgStruktur.TglUbah
            pParam(10) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(10).Value = OrgStruktur.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertOrgJabatan(OrgJabatan As HROrgJabatanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgInsertJabatan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgJabatan.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgJabatan.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgJabatan.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgDesc", SqlDbType.VarChar)
            pParam(3).Value = OrgJabatan.OrgDesc
            pParam(4) = New SqlClient.SqlParameter("@IsHead", SqlDbType.VarChar)
            pParam(4).Value = OrgJabatan.IsHead
            pParam(5) = New SqlClient.SqlParameter("@Alias", SqlDbType.VarChar)
            pParam(5).Value = OrgJabatan.Alias_
            pParam(6) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(6).Value = OrgJabatan.Ket
            pParam(7) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(7).Value = OrgJabatan.TglBuat
            pParam(8) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(8).Value = OrgJabatan.UserBuat
            pParam(9) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(9).Value = OrgJabatan.TglUbah
            pParam(10) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(10).Value = OrgJabatan.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditOrgJabatan(OrgJabatan As HROrgJabatanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgEditJabatan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgJabatan.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgJabatan.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgJabatan.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgDesc", SqlDbType.VarChar)
            pParam(3).Value = OrgJabatan.OrgDesc
            pParam(4) = New SqlClient.SqlParameter("@IsHead", SqlDbType.VarChar)
            pParam(4).Value = OrgJabatan.IsHead
            pParam(5) = New SqlClient.SqlParameter("@Alias", SqlDbType.VarChar)
            pParam(5).Value = OrgJabatan.Alias_
            pParam(6) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(6).Value = OrgJabatan.Ket
            pParam(7) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(7).Value = OrgJabatan.TglUbah
            pParam(8) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(8).Value = OrgJabatan.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertOrgOrganisasi(OrgOrganisasi As HROrgOrganisasiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgInsertOrganisasi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgOrganisasi.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgOrganisasi.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgOrganisasi.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgDesc", SqlDbType.VarChar)
            pParam(3).Value = OrgOrganisasi.OrgDesc
            pParam(4) = New SqlClient.SqlParameter("@OrgLevel", SqlDbType.VarChar)
            pParam(4).Value = OrgOrganisasi.OrgLevel
            pParam(5) = New SqlClient.SqlParameter("@Alias", SqlDbType.VarChar)
            pParam(5).Value = OrgOrganisasi.Alias_
            pParam(6) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(6).Value = OrgOrganisasi.Ket
            pParam(7) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(7).Value = OrgOrganisasi.TglBuat
            pParam(8) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(8).Value = OrgOrganisasi.UserBuat
            pParam(9) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(9).Value = OrgOrganisasi.TglUbah
            pParam(10) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(10).Value = OrgOrganisasi.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditOrgOrganisasi(OrgOrganisasi As HROrgOrganisasiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgEditOrganisasi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgOrganisasi.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgOrganisasi.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgOrganisasi.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgDesc", SqlDbType.VarChar)
            pParam(3).Value = OrgOrganisasi.OrgDesc
            pParam(4) = New SqlClient.SqlParameter("@OrgLevel", SqlDbType.VarChar)
            pParam(4).Value = OrgOrganisasi.OrgLevel
            pParam(5) = New SqlClient.SqlParameter("@Alias", SqlDbType.VarChar)
            pParam(5).Value = OrgOrganisasi.Alias_
            pParam(6) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(6).Value = OrgOrganisasi.Ket
            pParam(7) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(7).Value = OrgOrganisasi.TglUbah
            pParam(8) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(8).Value = OrgOrganisasi.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetAutoNumberJabID() As String
        Try
            strQuery = "DECLARE @seq VARCHAR(8);
                        SET @seq = ( SELECT RIGHT('0000000'
                                                  + CAST(MAX(RIGHT(OrgID, 7)) + 1 AS VARCHAR(7)), 7)
                                     FROM   dbo.M_HROrgJabatan
                                   ); 
                        SELECT  'P' + COALESCE(@seq, '0000001');"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNumberOrgID() As String
        Try
            strQuery = "DECLARE @seq VARCHAR(8);
                        SET @seq = ( SELECT RIGHT('0000000'
                                                  + CAST(MAX(RIGHT(OrgID, 7)) + 1 AS VARCHAR(7)), 7)
                                     FROM   dbo.M_HROrgOrganisasi
                                   ); 
                        SELECT  'O' + COALESCE(@seq, '0000001');"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CekPeriodParent(ParentID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(*)
                        FROM    dbo.M_HROrgRelOrgStruktur
                        WHERE   OrgID = " & QVal(ParentID) & "
                                AND RelDir = 'A'
                                AND TglMulai <= " & QVal(TglMulai) & "
                                AND TglSelesai >= " & QVal(TglSelesai) & ";"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CekPeriodChild(CurrID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "DECLARE @minDate AS DATE;
                        DECLARE @maxDate AS DATE;

                        SELECT  @minDate = MIN(TglMulai) ,
                                @maxDate = MAX(TglSelesai)
                        FROM    dbo.M_HROrgRelOrgStruktur
                        WHERE   OrgID = " & QVal(CurrID) & "
                                AND RelDir = 'B';

                        DECLARE @result AS INT = 0;
                        IF @minDate IS NOT NULL
                            AND @maxDate IS NOT NULL
                            IF @minDate < " & QVal(TglMulai) & "
                                OR @maxDate > " & QVal(TglSelesai) & "
                                BEGIN
                                    SET @result = 1;
                                END; 
                        SELECT  @result;"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
