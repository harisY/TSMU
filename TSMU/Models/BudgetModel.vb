Imports System.Collections.ObjectModel

Public Class BudgetModel
    Public Property ObjCollection() As New Collection(Of BudgetModel)
    Public Property Bulan() As String
    Public Property CreatedBy() As String
    Public Property CreatedDate() As DateTime
    Public Property CustId() As String
    Public Property Customer() As String
    Public Property Description() As String
    Public Property Flag() As String
    Public Property ID() As Integer
    Public Property INSub() As String
    Public Property InventoryId() As String
    Public Property Model() As String
    Public Property OE() As String
    Public Property PartNo() As String
    Public Property Price() As Decimal
    Public Property Qty() As Decimal
    Public Property Site() As String
    Public Property Tahun() As String
    Public Property UpdatedBy() As String
    Public Property UpdatedDate() As DateTime
End Class
