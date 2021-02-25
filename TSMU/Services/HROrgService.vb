Public Class HROrgService
    Dim strQuery As String = String.Empty

    Public Function GetStrukturOrg() As DataTable
        Dim _result As Integer = 0
        Try
            Dim Sql As String = "HR_GetStrukturOrg"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter() {}

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

End Class
