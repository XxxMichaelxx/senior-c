Imports MySql.Data.MySqlClient
Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mainForm As New Form2()
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mainForm As New Form3()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim connectionString As String = "server=localhost;database=senior-citizeen;user=root;password=;"
        Dim query As String = "SELECT * FROM tblseniorcitizen WHERE RegistrationNumber LIKE @search OR Name LIKE @search"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@search", "%" & TextBox1.Text & "%")
                Dim adapter As New MySqlDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)
                grdSearch.DataSource = dataTable
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class