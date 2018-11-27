Imports System.Xml
Public Class Form2
    Dim ling As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the caption bar text of the form.   
        Me.Text = "tutorialspoint.com"
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1().Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("movies.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "movie" Then
                ListBox1.Items.Add(xr.GetAttribute(0))
            End If
        Loop
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox2().Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("movies.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "type" Then
                ListBox2.Items.Add(xr.ReadElementString)
            Else
                xr.Read()
            End If
        Loop
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox3().Items.Clear()
        Dim xr As XmlReader = XmlReader.Create("movies.xml")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "description" Then
                ListBox3.Items.Add(xr.ReadElementString)
            Else
                xr.Read()
            End If
        Loop

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        Dim xr As XmlReader = XmlReader.Create("http://svc.efaktur.pajak.go.id/validasi/faktur/016225708085000/0031563618567/14abd92327c6debc03f567e86c17db6cd6a19da676639f8f0a1aafe509d98d3f")
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "nomorFaktur" Then
                TextBox1.Text = xr.ReadElementString
            Else
                xr.Read()
            End If
        Loop
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        ling = TextBox2.Text
        Dim xr As XmlReader = XmlReader.Create(ling)
        Do While xr.Read()
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "kdJenisTransaksi" Then
                TextBox1.Text = xr.ReadElementString
                If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "kdJenisTransaksi" Then
                    TextBox1.Text = xr.ReadElementString
                Else
                    xr.Read()
                End If
            End If
        Loop
    End Sub
End Class