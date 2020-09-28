Public Class Cls_Npwo_Header



    Public Function Get_NPP() As DataTable
        Try
            Dim query As String = "[NPP_Get_NPP]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_NPWO(_ActiveForm As Integer) As DataTable
        Try
            Dim d As DateTime = Date.Today
            Dim TA As DateTime = d.AddDays(-d.Day)
            Dim TangalAwal As DateTime = TA.AddDays(-(TA.Day - 1))
            TangalAwal = TangalAwal.AddMonths(-5)
            Dim TangalAkhir As DateTime = Date.Now

            Dim query As String = "[NPWO_Get_NPWO]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@TgAwal", SqlDbType.Date)
            pParam(1) = New SqlClient.SqlParameter("@TgAkhir", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@ActiveForm", SqlDbType.Int)

            pParam(0).Value = TangalAwal
            pParam(1).Value = TangalAkhir
            pParam(2).Value = _ActiveForm



            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_NPWO_Search(_ActiveForm As Integer, Tg1 As Date, Tg2 As Date) As DataTable
        Try

            Dim query As String = "[NPWO_Get_NPWO]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@TgAwal", SqlDbType.Date)
            pParam(1) = New SqlClient.SqlParameter("@TgAkhir", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@ActiveForm", SqlDbType.Int)

            pParam(0).Value = Tg1
            pParam(1).Value = Tg2
            pParam(2).Value = _ActiveForm



            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Sub Delete(NPWO_ As String)
        Try



            Dim ls_SP As String = "DELETE FROM [Npwo_Head]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_SP)


            Dim ls_Detail As String = "DELETE FROM [Npwo_Detail]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail)

            Dim ls_Detail1 As String = "DELETE FROM [NpwoDetail1]
                                     WHERE No_Npwo = '" & NPWO_ & "'"

            MainModul.ExecQueryByCommand(ls_Detail1)

        Catch ex As Exception

        End Try


    End Sub


End Class
