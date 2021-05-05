Imports System.Collections.ObjectModel

Public Class PPICConvertMuatHeaderModel
    Public Property NoUpload As String
    Public Property UploadDate As Date
    Public Property CustID As String
    Public Property FileName As String
    Public Property Revised As String
    Public Property TotalRecordExcel As Integer
    Public Property TotalMobil As Integer
    Public Property CreateBy As String
    Public Property CreateDate As DateTime
    Public Property ObjConvertDetails() As New Collection(Of PPICConvertMuatDetailModel)
End Class
