Public Class clsCalculateBoMdetail
    Public Property bomId() As String
    Public Property invtid() As String
    Public Property descr() As String
    Public Property unit() As String
    Public Property level() As String
    Public Property Jan_qty() As Single
    Public Property feb_qty() As Single
    Public Property mar_qty() As Single
    Public Property apr_qty() As Single
    Public Property mei_qty() As Single
    Public Property jun_qty() As Single
    Public Property jul_qty() As Single
    Public Property agust_qty() As Single
    Public Property sep_qty() As Single
    Public Property okt_qty() As Single
    Public Property nov_qty() As Single
    Public Property des_qty() As Single

#Region "CRUD"
    Public Sub InsertDetails()
        Try
            Dim ls_SP As String =
            "INSERT INTO [calculated_forecast_detail]
                ([bomId]
                ,[invtid]
                ,[descr]
                ,[unit]
                ,[level]
                ,[Jan_qty]
                ,[feb_qty]
                ,[mar_qty]
                ,[apr_qty]
                ,[mei_qty]
                ,[jun_qty]
                ,[jul_qty]
                ,[agu_qty]
                ,[sep_qty]
                ,[okt_qty]
                ,[nov_qty]
                ,[des_qty])
            VALUES
                (" & QVal(bomId) & "
                ," & QVal(invtid) & "
                ," & QVal(descr) & "
                ," & QVal(unit) & "
                ," & QVal(level) & "
                ," & QVal(Jan_qty) & "
                ," & QVal(feb_qty) & "
                ," & QVal(mar_qty) & "
                ," & QVal(apr_qty) & "
                ," & QVal(mei_qty) & "
                ," & QVal(jun_qty) & "
                ," & QVal(jul_qty) & "
                ," & QVal(agust_qty) & "
                ," & QVal(sep_qty) & "
                ," & QVal(okt_qty) & "
                ," & QVal(nov_qty) & "
                ," & QVal(des_qty) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
