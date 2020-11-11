Public Class SettingService
    Dim ObjSetting As New SettingModel
    Public Function GetDrrPath() As String
        Dim Hasil As String = String.Empty
        Try
            Dim dt As New DataTable
            dt = GetDataTableByParam("tblSetting_GetSetting", CommandType.StoredProcedure, Nothing, GetConnString)
            If dt.Rows.Count > 0 Then
                Hasil = dt.Rows(0)(0).ToString()
            End If
            Return Hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
