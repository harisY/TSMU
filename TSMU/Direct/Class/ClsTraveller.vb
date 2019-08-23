Imports System.Collections.ObjectModel
Public Class ClsTraveller
    Dim _Query As String
    Public Property DeptID As String
    Public Property Nama As String
    Public Property NIK As String
    Public Property PassExpDate As DateTime
    Public Property PassNo As String
    Public Property VisaExpDate As DateTime
    Public Property VisaNo As String
    'Public Property IDLokasiDetail() As String

    Public Sub New()
        Me._Query = "SELECT NIK
      ,Nama
      ,DeptID
      ,VisaNo
      ,VisaExpDate
      ,PassNo
      ,PassExpDate
  FROM Traveller"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT NIK
                                  ,Nama
                                  ,DeptID
                                  ,VisaNo
                                  ,VisaExpDate
                                  ,PassNo
                                  ,PassExpDate
                              FROM Traveller"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal NIK As String)
        Try
            Dim query As String = "SELECT NIK      ,Nama      ,DeptID      ,VisaNo      ,VisaExpDate      ,PassNo      ,PassExpDate  FROM Traveller WHERE [NIK] = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.NIK = Trim(.Item("NIK") & "")
                    Me.Nama = Trim(.Item("Nama") & "")
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    Me.VisaNo = Trim(.Item("VisaNo") & "")
                    Me.VisaExpDate = Convert.ToDateTime(.Item("VisaExpDate") & "")
                    Me.PassNo = Trim(.Item("PassNo") & "")
                    Me.PassExpDate = Convert.ToDateTime(.Item("PassExpDate") & "")
                End With
            Else
                NIK = ""
                Nama = ""
                DeptID = ""
                VisaNo = ""
                VisaExpDate = DateTime.Today
                PassNo = ""
                PassExpDate = DateTime.Today
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function GetDept() As DataTable
        Try
            Dim sql As String =
            "SELECT [IdDept]
                  ,[NamaDept]
              FROM [mDept]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub ValidateInsert()
        If Me.Nama = "" OrElse Me.NIK = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT NIK
      ,Nama
      ,DeptID
      ,VisaNo
      ,VisaExpDate
      ,PassNo
      ,PassExpDate
  FROM Traveller WHERE [NIK]  = " & QVal(NIK) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.NIK & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [Traveller] 
                                               ([NIK]
                                               ,[Nama]
                                               ,[DeptID]
                                               ,[VisaNo]
                                               ,[VisaExpDate]
                                               ,[PassNo]
                                               ,[PassExpDate])
                                     VALUES
                                                (" & QVal(NIK) & "
                                               ," & QVal(Nama) & " 
                                               ," & QVal(DeptID) & " 
                                               ," & QVal(VisaNo) & " 
                                               ," & QVal(VisaExpDate) & " 
                                               ," & QVal(PassNo) & " 
                                               ," & QVal(PassExpDate) & ")"

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal NIK As String)
        Try
            Dim ls_SP As String = "UPDATE  Traveller  SET Nama = " & QVal(Nama) & "
                                  ,DeptID = " & QVal(DeptID) & "
                                  ,VisaNo = " & QVal(VisaNo) & "
                                  ,VisaExpDate = " & QVal(VisaExpDate) & "
                                  ,PassNo = " & QVal(PassNo) & "
                                  ,PassExpDate = " & QVal(PassExpDate) & "
                                    WHERE NIK = " & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal NIK As String)
        Try
            Dim ls_SP As String = "DELETE FROM Traveller WHERE NIK =" & QVal(NIK) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
