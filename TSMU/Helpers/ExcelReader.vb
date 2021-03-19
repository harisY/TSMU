Imports System.IO
Imports ExcelDataReader

Public Class ExcelReader
    Public Shared Function ExcelToDataTable(ByVal fileName As String) As DataTable
        Using stream = File.Open(fileName, FileMode.Open, FileAccess.Read)

            Using reader = ExcelReaderFactory.CreateReader(stream)
                Dim result = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                    .ConfigureDataTable = Function(data) New ExcelDataTableConfiguration() With {
                        .UseHeaderRow = True
                    }
                })
                Dim table As DataTableCollection = result.Tables
                Dim resultTable As DataTable = table(0)
                Return resultTable
            End Using
        End Using
    End Function
End Class
