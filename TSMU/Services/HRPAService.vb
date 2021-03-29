Public Class HRPAService
    Dim strQuery As String = String.Empty

    Public Function GetDataKaryawan() As DataTable
        Try
            strQuery = "DECLARE @Now AS DATE;

                        SET @Now = GETDATE();

                        SELECT  pdk.EmployeeID ,
                                pdk.NIK ,
                                pdp.NamaLengkap ,
                                pdp.NamaPanggilan ,
                                pdp.JenisKelamin ,
                                pdp.TglLahir ,
                                pp.PerpindahanDesc AS Perpindahan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                pdk.Factory ,
                                oo.OrgDesc AS Organisasi ,
                                oj.OrgDesc AS Jabatan
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                INNER JOIN dbo.M_HRPADataPribadi AS pdp ON pdp.EmployeeID = pdk.EmployeeID
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON pdk.Organisasi = oo.OrgID
                                                                         AND oo.TglMulai <= @Now
                                                                         AND oo.TglSelesai >= @Now
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                                                      AND oj.TglMulai <= @Now
                                                                      AND oj.TglSelesai >= @Now
                                LEFT JOIN dbo.S_HRPAPerpindahan AS pp ON pdk.PerpindahanKaryawan = pp.Perpindahan
                        WHERE   ( pdk.TglMulai <= @Now
                                  AND pdk.TglSelesai >= @Now
                                )
                                AND pdp.TglMulai <= @Now
                                AND pdp.TglSelesai >= @Now
                        ORDER BY pdk.EmployeeID ASC"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataKaryawanByID(ByVal EmpID As String) As HRPAHeaderModel
        Try
            strQuery = "DECLARE @Now AS DATE;

                        SET @Now = GETDATE();

                        SELECT  pdk.EmployeeID ,
                                pdk.NIK ,
                                pdp.Foto ,
                                pdp.NamaLengkap ,
                                pdp.NamaPanggilan ,
                                pdp.JenisKelamin ,
                                pdp.TglLahir ,
                                tblHiring.TglJoin ,
                                pdk.Factory ,
                                pdk.PerpindahanKaryawan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                oo.OrgDesc AS Organisasi ,
                                oj.OrgDesc AS Jabatan
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                INNER JOIN dbo.M_HRPADataPribadi AS pdp ON pdp.EmployeeID = pdk.EmployeeID
                                LEFT JOIN ( SELECT DISTINCT
                                                    TglMulai AS TglJoin ,
                                                    EmployeeID
                                            FROM    dbo.M_HRPADataKaryawan
                                            WHERE   EmployeeID = " & QVal(EmpID) & "
                                                    AND PerpindahanKaryawan = '01'
                                          ) AS tblHiring ON tblHiring.EmployeeID = pdk.EmployeeID
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON pdk.Organisasi = oo.OrgID
                                                                         AND oo.TglMulai <= @Now
                                                                         AND oo.TglSelesai >= @Now
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                                                      AND oj.TglMulai <= @Now
                                                                      AND oj.TglSelesai >= @Now
                        WHERE   pdk.EmployeeID = " & QVal(EmpID) & "
                                AND ( pdk.TglMulai <= @Now
                                      AND pdk.TglSelesai >= @Now
                                    )
                                AND ( pdp.TglMulai <= @Now
                                      AND pdp.TglSelesai >= @Now
                                    );"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelHeader As New HRPAHeaderModel
            If dt.Rows.Count > 0 Then
                With modelHeader
                    .NIK = If(IsDBNull(dt.Rows(0).Item("NIK")), "", dt.Rows(0).Item("NIK").ToString())
                    .Foto = If(IsDBNull(dt.Rows(0).Item("Foto")), Nothing, dt.Rows(0).Item("Foto"))
                    .NamaLengkap = If(IsDBNull(dt.Rows(0).Item("NamaLengkap")), "", dt.Rows(0).Item("NamaLengkap").ToString())
                    .JenisKelamin = If(IsDBNull(dt.Rows(0).Item("JenisKelamin")), "", dt.Rows(0).Item("JenisKelamin").ToString())
                    .TglLahir = If(IsDBNull(dt.Rows(0).Item("TglLahir")), Nothing, dt.Rows(0).Item("TglLahir"))
                    .TglJoin = If(IsDBNull(dt.Rows(0).Item("TglJoin")), Nothing, dt.Rows(0).Item("TglJoin"))
                    .Factory = If(IsDBNull(dt.Rows(0).Item("Factory")), "", dt.Rows(0).Item("Factory").ToString())
                    .StatusKaryawan = If(IsDBNull(dt.Rows(0).Item("StatusKaryawan")), "", dt.Rows(0).Item("StatusKaryawan").ToString())
                    .TipeKaryawan = If(IsDBNull(dt.Rows(0).Item("TipeKaryawan")), "", dt.Rows(0).Item("TipeKaryawan").ToString())
                    .Organisasi = If(IsDBNull(dt.Rows(0).Item("Organisasi")), "", dt.Rows(0).Item("Organisasi").ToString())
                    .Jabatan = If(IsDBNull(dt.Rows(0).Item("Jabatan")), "", dt.Rows(0).Item("Jabatan").ToString())
                End With
            End If
            Return modelHeader
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataPribadi(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                PINFinger ,
                                NamaLengkap ,
                                NamaPanggilan ,
                                JenisKelamin ,
                                TempatLahir ,
                                TglLahir ,
                                Tamatan ,
                                Kewarganegaraan ,
                                Agama ,
                                GolonganDarah ,
                                StatusKawin ,
                                TglKawin ,
                                JumlahAnak ,
                                Reference ,
                                Foto ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKaryawan(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  pdk.ID ,
                                pdk.TglMulai ,
                                pdk.TglSelesai ,
                                pdk.EmployeeID ,
                                pdk.NIK ,
                                pdk.PerpindahanKaryawan ,
                                pp.PerpindahanDesc ,
                                pdk.AlasanPindah ,
                                ap.AlasanPindahDesc ,
                                pdk.Golongan AS Gol ,
                                --pg.GolDesc AS Golongan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                pdk.Factory ,
                                pdk.Organisasi AS OrgID ,
                                oo.OrgDesc AS Organisasi ,
                                pdk.Jabatan AS JabID ,
                                oj.OrgDesc AS Jabatan ,
                                pdk.Job ,
                                pdk.TglEfektif ,
                                pdk.TglBerakhir ,
                                pdk.SK ,
                                pdk.Ket ,
                                pdk.TglBuat ,
                                pdk.UserBuat ,
                                pdk.TglUbah ,
                                pdk.UserUbah
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON oo.OrgID = pdk.Organisasi
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                --LEFT JOIN dbo.S_HRPAGolongan AS pg ON pdk.Golongan = pg.Gol
                                LEFT JOIN dbo.S_HRPAPerpindahan AS pp ON pdk.PerpindahanKaryawan = pp.Perpindahan
                                LEFT JOIN dbo.S_HRPAAlasanPindah AS ap ON ap.AlasanPindah = pdk.AlasanPindah
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataAlamat(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                TipeAlamat ,
                                Seq ,
                                Alamat ,
                                RT ,
                                RW ,
                                Negara ,
                                Provinsi ,
                                KotaKab ,
                                Kecamatan ,
                                Kelurahan ,
                                KodePos ,
                                NoTelpon ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataAlamat
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKeluarga(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Hubungan ,
                                Seq ,
                                Nama ,
                                JenisKelamin ,
                                TempatLahir ,
                                TglLahir ,
                                TglKematian ,
                                Agama ,
                                Tamatan ,
                                Alamat ,
                                NoTelpon ,
                                Pekerjaan ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataKeluarga
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataPendidikan(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Seq ,
                                TipePendidikan ,
                                TingkatPendidikan ,
                                NamaInstitut ,
                                Jurusan ,
                                Alamat ,
                                IPK ,
                                Nilai ,
                                NamaPelatihan ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataPendidikan
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKomunikasi(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Seq ,
                                TipeKomunikasi ,
                                Deskripsi ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataKomunikasi
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveNewEmployee(DataPribadi As HRPADataPribadiModel, DataKaryawan As HRPADataKaryawanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataPribadi(DataPribadi)
                        InsertDataKaryawan(DataKaryawan)
                        If OrgStruktur.OrgID <> "" Then
                            InsertOrgStruktur(OrgStruktur)
                        End If
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


#Region "Service For MD Pribadi"
    Public Sub SaveNewDataPribadi(Data As HRPADataPribadiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataPribadi(Data)
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

    Public Sub SaveEditDataPribadi(Data As HRPADataPribadiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataPribadi(Data)
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

    Public Sub SaveDeleteDataPribadi(Data As HRPADataPribadiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteDataPribadi(Data)
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

    Public Sub InsertDataPribadi(Data As HRPADataPribadiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataPribadi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(22) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@PINFinger", SqlDbType.Char)
            pParam(3).Value = Data.PINFinger
            pParam(4) = New SqlClient.SqlParameter("@NamaLengkap", SqlDbType.VarChar)
            pParam(4).Value = Data.NamaLengkap
            pParam(5) = New SqlClient.SqlParameter("@NamaPanggilan", SqlDbType.VarChar)
            pParam(5).Value = Data.NamaPanggilan
            pParam(6) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(6).Value = Data.JenisKelamin
            pParam(7) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(7).Value = Data.TempatLahir
            pParam(8) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(8).Value = Data.TglLahir
            pParam(9) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(9).Value = Data.Tamatan
            pParam(10) = New SqlClient.SqlParameter("@Kewarganegaraan", SqlDbType.VarChar)
            pParam(10).Value = Data.Kewarganegaraan
            pParam(11) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(11).Value = Data.Agama
            pParam(12) = New SqlClient.SqlParameter("@GolonganDarah", SqlDbType.VarChar)
            pParam(12).Value = Data.GolonganDarah
            pParam(13) = New SqlClient.SqlParameter("@StatusKawin", SqlDbType.VarChar)
            pParam(13).Value = Data.StatusKawin
            pParam(14) = New SqlClient.SqlParameter("@TglKawin", SqlDbType.Date)
            pParam(14).Value = Data.TglKawin
            pParam(15) = New SqlClient.SqlParameter("@JumlahAnak", SqlDbType.Int)
            pParam(15).Value = Data.JumlahAnak
            pParam(16) = New SqlClient.SqlParameter("@Foto", SqlDbType.VarChar)
            pParam(16).Value = Data.Foto
            pParam(17) = New SqlClient.SqlParameter("@Reference", SqlDbType.VarChar)
            pParam(17).Value = Data.Reference
            pParam(18) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(18).Value = Data.Ket
            pParam(19) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(19).Value = Data.TglBuat
            pParam(20) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(20).Value = Data.UserBuat
            pParam(21) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(21).Value = Data.TglUbah
            pParam(22) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(22).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataPribadi(Data As HRPADataPribadiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataPribadi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(23) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@PINFinger", SqlDbType.Char)
            pParam(4).Value = Data.PINFinger
            pParam(5) = New SqlClient.SqlParameter("@NamaLengkap", SqlDbType.VarChar)
            pParam(5).Value = Data.NamaLengkap
            pParam(6) = New SqlClient.SqlParameter("@NamaPanggilan", SqlDbType.VarChar)
            pParam(6).Value = Data.NamaPanggilan
            pParam(7) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(7).Value = Data.JenisKelamin
            pParam(8) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(8).Value = Data.TempatLahir
            pParam(9) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(9).Value = Data.TglLahir
            pParam(10) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(10).Value = Data.Tamatan
            pParam(11) = New SqlClient.SqlParameter("@Kewarganegaraan", SqlDbType.VarChar)
            pParam(11).Value = Data.Kewarganegaraan
            pParam(12) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(12).Value = Data.Agama
            pParam(13) = New SqlClient.SqlParameter("@GolonganDarah", SqlDbType.VarChar)
            pParam(13).Value = Data.GolonganDarah
            pParam(14) = New SqlClient.SqlParameter("@StatusKawin", SqlDbType.VarChar)
            pParam(14).Value = Data.StatusKawin
            pParam(15) = New SqlClient.SqlParameter("@TglKawin", SqlDbType.Date)
            pParam(15).Value = Data.TglKawin
            pParam(16) = New SqlClient.SqlParameter("@JumlahAnak", SqlDbType.Int)
            pParam(16).Value = Data.JumlahAnak
            pParam(17) = New SqlClient.SqlParameter("@Foto", SqlDbType.VarChar)
            pParam(17).Value = Data.Foto
            pParam(18) = New SqlClient.SqlParameter("@Reference", SqlDbType.VarChar)
            pParam(18).Value = Data.Reference
            pParam(19) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(19).Value = Data.Ket
            pParam(20) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(20).Value = Data.TglBuat
            pParam(21) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(21).Value = Data.UserBuat
            pParam(22) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(22).Value = Data.TglUbah
            pParam(23) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(23).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDataPribadi(Data As HRPADataPribadiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PADeleteDataPribadi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(4).Value = Data.TglUbah
            pParam(5) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(5).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Service For MD Karir"
    Public Sub SaveNewDataKaryawan(DataKaryawan As HRPADataKaryawanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataKaryawan(DataKaryawan)
                        If Not String.IsNullOrEmpty(DataKaryawan.Jabatan) Then
                            InsertOrgStruktur(OrgStruktur)
                        End If
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

    Public Sub SaveEditDataKaryawan(DataKaryawan As HRPADataKaryawanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataKaryawan(DataKaryawan)
                        'If Not String.IsNullOrEmpty(DataKaryawan.Jabatan) Then
                        '    InsertOrgStruktur(OrgStruktur)
                        'End If
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

    Public Sub SaveDeleteDataKaryawan(DataKaryawan As HRPADataKaryawanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteDataKaryawan(DataKaryawan)
                        If Not String.IsNullOrEmpty(DataKaryawan.Jabatan) Then
                            DeleteOrgStruktur(OrgStruktur)
                        End If
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

    Public Sub InsertDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataKaryawan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(21) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
            pParam(3).Value = Data.NIK
            pParam(4) = New SqlClient.SqlParameter("@PerpindahanKaryawan", SqlDbType.VarChar)
            pParam(4).Value = Data.PerpindahanKaryawan
            pParam(5) = New SqlClient.SqlParameter("@AlasanPindah", SqlDbType.VarChar)
            pParam(5).Value = Data.AlasanPindah
            pParam(6) = New SqlClient.SqlParameter("@Golongan", SqlDbType.VarChar)
            pParam(6).Value = Data.Golongan
            pParam(7) = New SqlClient.SqlParameter("@StatusKaryawan", SqlDbType.VarChar)
            pParam(7).Value = Data.StatusKaryawan
            pParam(8) = New SqlClient.SqlParameter("@TipeKaryawan", SqlDbType.VarChar)
            pParam(8).Value = Data.TipeKaryawan
            pParam(9) = New SqlClient.SqlParameter("@TipePosisiKaryawan", SqlDbType.VarChar)
            pParam(9).Value = Data.TipePosisiKaryawan
            pParam(10) = New SqlClient.SqlParameter("@Factory", SqlDbType.VarChar)
            pParam(10).Value = Data.Factory
            pParam(11) = New SqlClient.SqlParameter("@Organisasi", SqlDbType.VarChar)
            pParam(11).Value = Data.Organisasi
            pParam(12) = New SqlClient.SqlParameter("@Jabatan", SqlDbType.VarChar)
            pParam(12).Value = Data.Jabatan
            pParam(13) = New SqlClient.SqlParameter("@Job", SqlDbType.VarChar)
            pParam(13).Value = Data.Job
            pParam(14) = New SqlClient.SqlParameter("@TglEfektif", SqlDbType.Date)
            pParam(14).Value = Data.TglEfektif
            pParam(15) = New SqlClient.SqlParameter("@TglBerakhir", SqlDbType.Date)
            pParam(15).Value = Data.TglBerakhir
            pParam(16) = New SqlClient.SqlParameter("@SK", SqlDbType.VarChar)
            pParam(16).Value = Data.SK
            pParam(17) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(17).Value = Data.Ket
            pParam(18) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(18).Value = Data.TglBuat
            pParam(19) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(19).Value = Data.UserBuat
            pParam(20) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(20).Value = Data.TglUbah
            pParam(21) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(21).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataKaryawan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(22) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
            pParam(4).Value = Data.NIK
            pParam(5) = New SqlClient.SqlParameter("@PerpindahanKaryawan", SqlDbType.VarChar)
            pParam(5).Value = Data.PerpindahanKaryawan
            pParam(6) = New SqlClient.SqlParameter("@AlasanPindah", SqlDbType.VarChar)
            pParam(6).Value = Data.AlasanPindah
            pParam(7) = New SqlClient.SqlParameter("@Golongan", SqlDbType.VarChar)
            pParam(7).Value = Data.Golongan
            pParam(8) = New SqlClient.SqlParameter("@StatusKaryawan", SqlDbType.VarChar)
            pParam(8).Value = Data.StatusKaryawan
            pParam(9) = New SqlClient.SqlParameter("@TipeKaryawan", SqlDbType.VarChar)
            pParam(9).Value = Data.TipeKaryawan
            pParam(10) = New SqlClient.SqlParameter("@TipePosisiKaryawan", SqlDbType.VarChar)
            pParam(10).Value = Data.TipePosisiKaryawan
            pParam(11) = New SqlClient.SqlParameter("@Factory", SqlDbType.VarChar)
            pParam(11).Value = Data.Factory
            pParam(12) = New SqlClient.SqlParameter("@Organisasi", SqlDbType.VarChar)
            pParam(12).Value = Data.Organisasi
            pParam(13) = New SqlClient.SqlParameter("@Jabatan", SqlDbType.VarChar)
            pParam(13).Value = Data.Jabatan
            pParam(14) = New SqlClient.SqlParameter("@Job", SqlDbType.VarChar)
            pParam(14).Value = Data.Job
            pParam(15) = New SqlClient.SqlParameter("@TglEfektif", SqlDbType.Date)
            pParam(15).Value = Data.TglEfektif
            pParam(16) = New SqlClient.SqlParameter("@TglBerakhir", SqlDbType.Date)
            pParam(16).Value = Data.TglBerakhir
            pParam(17) = New SqlClient.SqlParameter("@SK", SqlDbType.VarChar)
            pParam(17).Value = Data.SK
            pParam(18) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(18).Value = Data.Ket
            pParam(19) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(19).Value = Data.TglBuat
            pParam(20) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(20).Value = Data.UserBuat
            pParam(21) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(21).Value = Data.TglUbah
            pParam(22) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(22).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PADeleteDataKaryawan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(4).Value = Data.TglUbah
            pParam(5) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(5).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Service For MD Alamat"
    Public Sub SaveNewDataAlamat(Data As HRPADataAlamatModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataAlamat(Data)
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

    Public Sub SaveEditDataAlamat(Data As HRPADataAlamatModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataAlamat(Data)
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

    Public Sub SaveDeleteDataAlamat(Data As HRPADataAlamatModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        strQuery = " DELETE  FROM dbo.M_HRPADataAlamat
                                     WHERE   ID = " & QVal(Data.ID) & " "
                        ExecQuery(strQuery)

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
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataAlamat(Data As HRPADataAlamatModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataAlamat"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(19) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@TipeAlamat", SqlDbType.VarChar)
            pParam(3).Value = Data.TipeAlamat
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(5).Value = Data.Alamat
            pParam(6) = New SqlClient.SqlParameter("@RT", SqlDbType.VarChar)
            pParam(6).Value = Data.RT
            pParam(7) = New SqlClient.SqlParameter("@RW", SqlDbType.VarChar)
            pParam(7).Value = Data.RW
            pParam(8) = New SqlClient.SqlParameter("@Negara", SqlDbType.VarChar)
            pParam(8).Value = Data.Negara
            pParam(9) = New SqlClient.SqlParameter("@Provinsi", SqlDbType.VarChar)
            pParam(9).Value = Data.Provinsi
            pParam(10) = New SqlClient.SqlParameter("@KotaKab", SqlDbType.VarChar)
            pParam(10).Value = Data.KotaKab
            pParam(11) = New SqlClient.SqlParameter("@Kecamatan", SqlDbType.VarChar)
            pParam(11).Value = Data.Kecamatan
            pParam(12) = New SqlClient.SqlParameter("@Kelurahan", SqlDbType.VarChar)
            pParam(12).Value = Data.Kelurahan
            pParam(13) = New SqlClient.SqlParameter("@KodePos", SqlDbType.VarChar)
            pParam(13).Value = Data.KodePos
            pParam(14) = New SqlClient.SqlParameter("@NoTelpon", SqlDbType.VarChar)
            pParam(14).Value = Data.NoTelpon
            pParam(15) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(15).Value = Data.Ket
            pParam(16) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(16).Value = Data.TglBuat
            pParam(17) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(17).Value = Data.UserBuat
            pParam(18) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(18).Value = Data.TglUbah
            pParam(19) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(19).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataAlamat(Data As HRPADataAlamatModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataAlamat"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(20) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@TipeAlamat", SqlDbType.VarChar)
            pParam(3).Value = Data.TipeAlamat
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(5).Value = Data.Alamat
            pParam(6) = New SqlClient.SqlParameter("@RT", SqlDbType.VarChar)
            pParam(6).Value = Data.RT
            pParam(7) = New SqlClient.SqlParameter("@RW", SqlDbType.VarChar)
            pParam(7).Value = Data.RW
            pParam(8) = New SqlClient.SqlParameter("@Negara", SqlDbType.VarChar)
            pParam(8).Value = Data.Negara
            pParam(9) = New SqlClient.SqlParameter("@Provinsi", SqlDbType.VarChar)
            pParam(9).Value = Data.Provinsi
            pParam(10) = New SqlClient.SqlParameter("@KotaKab", SqlDbType.VarChar)
            pParam(10).Value = Data.KotaKab
            pParam(11) = New SqlClient.SqlParameter("@Kecamatan", SqlDbType.VarChar)
            pParam(11).Value = Data.Kecamatan
            pParam(12) = New SqlClient.SqlParameter("@Kelurahan", SqlDbType.VarChar)
            pParam(12).Value = Data.Kelurahan
            pParam(13) = New SqlClient.SqlParameter("@KodePos", SqlDbType.VarChar)
            pParam(13).Value = Data.KodePos
            pParam(14) = New SqlClient.SqlParameter("@NoTelpon", SqlDbType.VarChar)
            pParam(14).Value = Data.NoTelpon
            pParam(15) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(15).Value = Data.Ket
            pParam(16) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(16).Value = Data.TglBuat
            pParam(17) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(17).Value = Data.UserBuat
            pParam(18) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(18).Value = Data.TglUbah
            pParam(19) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(19).Value = Data.UserUbah
            pParam(20) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(20).Value = Data.ID

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Service For MD Keluarga"
    Public Sub SaveNewDataKeluarga(Data As HRPADataKeluargaModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataKeluarga(Data)
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

    Public Sub SaveEditDataKeluarga(Data As HRPADataKeluargaModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataKeluarga(Data)
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

    Public Sub SaveDeleteDataKeluarga(Data As HRPADataKeluargaModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        strQuery = " DELETE  FROM dbo.M_HRPADataKeluarga
                                     WHERE   ID = " & QVal(Data.ID) & " "
                        ExecQuery(strQuery)

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
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataKeluarga(Data As HRPADataKeluargaModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataKeluarga"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(20) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Hubungan", SqlDbType.VarChar)
            pParam(4).Value = Data.Hubungan
            pParam(5) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(5).Value = Data.Seq
            pParam(6) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
            pParam(6).Value = Data.Nama
            pParam(7) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(7).Value = Data.JenisKelamin
            pParam(8) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(8).Value = Data.TempatLahir
            pParam(9) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(9).Value = Data.TglLahir
            pParam(10) = New SqlClient.SqlParameter("@TglKematian", SqlDbType.Date)
            pParam(10).Value = Data.TglKematian
            pParam(11) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(11).Value = Data.Agama
            pParam(12) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(12).Value = Data.Tamatan
            pParam(13) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(13).Value = Data.Alamat
            pParam(14) = New SqlClient.SqlParameter("@NoTelpon", SqlDbType.VarChar)
            pParam(14).Value = Data.NoTelpon
            pParam(15) = New SqlClient.SqlParameter("@Pekerjaan", SqlDbType.VarChar)
            pParam(15).Value = Data.Pekerjaan
            pParam(16) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(16).Value = Data.Ket
            pParam(17) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(17).Value = Data.TglBuat
            pParam(18) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(18).Value = Data.UserBuat
            pParam(19) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(19).Value = Data.TglUbah
            pParam(20) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(20).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataKeluarga(Data As HRPADataKeluargaModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataKeluarga"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(20) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Hubungan", SqlDbType.VarChar)
            pParam(4).Value = Data.Hubungan
            pParam(5) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(5).Value = Data.Seq
            pParam(6) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
            pParam(6).Value = Data.Nama
            pParam(7) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(7).Value = Data.JenisKelamin
            pParam(8) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(8).Value = Data.TempatLahir
            pParam(9) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(9).Value = Data.TglLahir
            pParam(10) = New SqlClient.SqlParameter("@TglKematian", SqlDbType.Date)
            pParam(10).Value = Data.TglKematian
            pParam(11) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(11).Value = Data.Agama
            pParam(12) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(12).Value = Data.Tamatan
            pParam(13) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(13).Value = Data.Alamat
            pParam(14) = New SqlClient.SqlParameter("@NoTelpon", SqlDbType.VarChar)
            pParam(14).Value = Data.NoTelpon
            pParam(15) = New SqlClient.SqlParameter("@Pekerjaan", SqlDbType.VarChar)
            pParam(15).Value = Data.Pekerjaan
            pParam(16) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(16).Value = Data.Ket
            pParam(17) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(17).Value = Data.TglBuat
            pParam(18) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(18).Value = Data.UserBuat
            pParam(19) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(19).Value = Data.TglUbah
            pParam(20) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(20).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Service For MD Pendidikan"
    Public Sub SaveNewDataPendidikan(Data As HRPADataPendidikanModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataPendidikan(Data)
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

    Public Sub SaveEditDataPendidikan(Data As HRPADataPendidikanModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataPendidikan(Data)
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

    Public Sub SaveDeleteDataPendidikan(Data As HRPADataPendidikanModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        strQuery = " DELETE  FROM dbo.M_HRPADataPendidikan
                                     WHERE   ID = " & QVal(Data.ID) & " "
                        ExecQuery(strQuery)

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
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataPendidikan(Data As HRPADataPendidikanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataPendidikan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(17) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@TipePendidikan", SqlDbType.VarChar)
            pParam(5).Value = Data.TipePendidikan
            pParam(6) = New SqlClient.SqlParameter("@TingkatPendidikan", SqlDbType.VarChar)
            pParam(6).Value = Data.TingkatPendidikan
            pParam(7) = New SqlClient.SqlParameter("@NamaInstitut", SqlDbType.VarChar)
            pParam(7).Value = Data.NamaInstitut
            pParam(8) = New SqlClient.SqlParameter("@Jurusan", SqlDbType.VarChar)
            pParam(8).Value = Data.Jurusan
            pParam(9) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(9).Value = Data.Alamat
            pParam(10) = New SqlClient.SqlParameter("@IPK", SqlDbType.VarChar)
            pParam(10).Value = Data.IPK
            pParam(11) = New SqlClient.SqlParameter("@Nilai", SqlDbType.VarChar)
            pParam(11).Value = Data.Nilai
            pParam(12) = New SqlClient.SqlParameter("@NamaPelatihan", SqlDbType.VarChar)
            pParam(12).Value = Data.NamaPelatihan
            pParam(13) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(13).Value = Data.Ket
            pParam(14) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(14).Value = Data.TglBuat
            pParam(15) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(15).Value = Data.UserBuat
            pParam(16) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(16).Value = Data.TglUbah
            pParam(17) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(17).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataPendidikan(Data As HRPADataPendidikanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataPendidikan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(17) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@TipePendidikan", SqlDbType.VarChar)
            pParam(5).Value = Data.TipePendidikan
            pParam(6) = New SqlClient.SqlParameter("@TingkatPendidikan", SqlDbType.VarChar)
            pParam(6).Value = Data.TingkatPendidikan
            pParam(7) = New SqlClient.SqlParameter("@NamaInstitut", SqlDbType.VarChar)
            pParam(7).Value = Data.NamaInstitut
            pParam(8) = New SqlClient.SqlParameter("@Jurusan", SqlDbType.VarChar)
            pParam(8).Value = Data.Jurusan
            pParam(9) = New SqlClient.SqlParameter("@Alamat", SqlDbType.VarChar)
            pParam(9).Value = Data.Alamat
            pParam(10) = New SqlClient.SqlParameter("@IPK", SqlDbType.VarChar)
            pParam(10).Value = Data.IPK
            pParam(11) = New SqlClient.SqlParameter("@Nilai", SqlDbType.VarChar)
            pParam(11).Value = Data.Nilai
            pParam(12) = New SqlClient.SqlParameter("@NamaPelatihan", SqlDbType.VarChar)
            pParam(12).Value = Data.NamaPelatihan
            pParam(13) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(13).Value = Data.Ket
            pParam(14) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(14).Value = Data.TglBuat
            pParam(15) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(15).Value = Data.UserBuat
            pParam(16) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(16).Value = Data.TglUbah
            pParam(17) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(17).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Service For MD Komunikasi"
    Public Sub SaveNewDataKomunikasi(Data As HRPADataKomunikasiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataKomunikasi(Data)
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

    Public Sub SaveEditDataKomunikasi(Data As HRPADataKomunikasiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataKomunikasi(Data)
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

    Public Sub SaveDeleteDataKomunikasi(Data As HRPADataKomunikasiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        strQuery = " DELETE  FROM dbo.M_HRPADataKomunikasi
                                     WHERE   ID = " & QVal(Data.ID) & " "
                        ExecQuery(strQuery)

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
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataKomunikasi(Data As HRPADataKomunikasiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataKomunikasi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(11) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@TipeKomunikasi", SqlDbType.VarChar)
            pParam(5).Value = Data.TipeKomunikasi
            pParam(6) = New SqlClient.SqlParameter("@Deskripsi", SqlDbType.VarChar)
            pParam(6).Value = Data.Deskripsi
            pParam(7) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(7).Value = Data.Ket
            pParam(8) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(8).Value = Data.TglBuat
            pParam(9) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(9).Value = Data.UserBuat
            pParam(10) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(10).Value = Data.TglUbah
            pParam(11) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(11).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataKomunikasi(Data As HRPADataKomunikasiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataKomunikasi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(11) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(4).Value = Data.Seq
            pParam(5) = New SqlClient.SqlParameter("@TipeKomunikasi", SqlDbType.VarChar)
            pParam(5).Value = Data.TipeKomunikasi
            pParam(6) = New SqlClient.SqlParameter("@Deskripsi", SqlDbType.VarChar)
            pParam(6).Value = Data.Deskripsi
            pParam(7) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(7).Value = Data.Ket
            pParam(8) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(8).Value = Data.TglBuat
            pParam(9) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(9).Value = Data.UserBuat
            pParam(10) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(10).Value = Data.TglUbah
            pParam(11) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(11).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

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

    Public Sub DeleteOrgStruktur(OrgStruktur As HROrgStrukturModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgDeleteStruktur"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}
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

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

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

    Public Function GetListPerpindahan() As DataTable
        Try
            strQuery = "SELECT  Perpindahan ,
                                PerpindahanDesc
                        FROM    dbo.S_HRPAPerpindahan"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListAlasan(perpindahan As String) As DataTable
        Try
            strQuery = "SELECT  AlasanPindah ,
                                AlasanPindahDesc
                        FROM    dbo.S_HRPAAlasanPindah
                        WHERE   Perpindahan = " & QVal(perpindahan) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListGolongan() As DataTable
        Try
            strQuery = "SELECT  Gol ,
                                GolDesc
                        FROM    dbo.S_HRPAGolongan"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListOrganisasi() As DataTable
        Try
            strQuery = "SELECT  OrgID ,
                                OrgDesc
                        FROM    dbo.M_HROrgOrganisasi"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNumberEmpID() As String
        Try
            strQuery = "DECLARE @seq VARCHAR(8);
                        SET @seq = ( SELECT RIGHT('00000000' + CAST(MAX(EmployeeID) + 1 AS VARCHAR), 8)
                                     FROM   dbo.M_HRPADataPribadi
                                   ); 
                        SELECT  COALESCE(@seq, '00000001');"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNumberNIK() As String
        Try
            strQuery = "SELECT  RIGHT(Tahun, 2) + RIGHT('000000' + CAST(AvailableNo AS VARCHAR), 8)
                        FROM    dbo.S_Numbering
                        WHERE   MenuCode = 'FrmHRPANewEmployee'"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetMaxIDDataPribadi() As Integer
        Try
            Dim value As Integer
            strQuery = "SELECT  MAX(ID) + 1
                        FROM    dbo.M_HRPADataPribadi WITH ( NOLOCK )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            If dt.Rows.Count() > 0 Then
                value = dt.Rows(0).Item(0)
            End If
            Return value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetGeneralParam(Param As String) As String
        Try
            Dim value As String = String.Empty
            strQuery = "SELECT  Value1
                        FROM    dbo.S_GeneralParam
                        WHERE   Param = " & QVal(Param) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            If dt.Rows.Count() > 0 Then
                value = dt.Rows(0).Item(0).ToString
            End If
            Return value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Check apakah ada data yg jadi bagian periode ini (DATA PRIBADI)"
    Public Function CheckRangeDatePribadi(EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckRangeDateEditPribadi(ID As Integer, EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )
                                AND ID <> " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Check apakah ada data yg jadi bagian periode ini (DATA KARIR)"
    Public Function CheckRangeDateKarir(EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataKaryawan
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckRangeDateEditKarir(ID As Integer, EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataKaryawan
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )
                                AND ID <> " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Check apakah jabatan ada relasi ke Employee lain di periode ini"
    Public Function CheckRelasiJabatan(EmpID As String, Jabatan As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(*)
                        FROM    dbo.M_HROrgRelOrgStruktur
                        WHERE   OrgID = " & QVal(Jabatan) & "
                                AND ( ( TglMulai <= " & QVal(TglMulai) & "
                                        AND TglSelesai >= " & QVal(TglMulai) & "
                                      )
                                      OR ( TglMulai <= " & QVal(TglSelesai) & "
                                           AND TglSelesai >= " & QVal(TglSelesai) & "
                                         )
                                    )
                                AND OrgClass = 'P'
                                AND RelDir = 'B'
                                AND RelTipe = '03'
                                AND RelClass = 'E'
                                AND RelOrg <> " & QVal(EmpID) & ";"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
