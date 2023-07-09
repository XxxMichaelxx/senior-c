Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the entered username and password
        Dim username As String = TextBox1.Text.Trim()
        Dim password As String = TextBox2.Text.Trim()

        ' Create a connection string
        Dim connectionString As String = "server=localhost;database=senior-citizeen;user=root;password=;"

        ' Create a MySQL connection
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Create a SQL query to check the credentials
            Dim query As String = "SELECT COUNT(*) FROM admin WHERE username = @username AND password = @password;"
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter values
                command.Parameters.AddWithValue("@username", username)
                command.Parameters.AddWithValue("@password", password)

                ' Execute the query and get the result
                Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' Check the result
                If result > 0 Then
                    Dim mainForm As New Form2()
                    mainForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid username or password")
                    ' Handle the case of invalid credentials
                End If
            End Using
        End Using
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
