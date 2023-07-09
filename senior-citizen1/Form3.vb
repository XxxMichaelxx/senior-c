Imports MySql.Data.MySqlClient
Public Class Form3
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim registrationNumber As String = GenerateRegistrationNumber()
        Dim name As String = TextBox1.Text.Trim()
        Dim dateOfBirth As DateTime = DateTimePicker1.Value
        Dim contactNumber As String = TextBox3.Text.Trim()
        Dim communicationAddress As String = TextBox4.Text.Trim()
        Dim emergencyAddress As String = TextBox5.Text.Trim()
        Dim emergencyContactnumber As String = TextBox6.Text.Trim()

        ' Create a connection string
        Dim connectionString As String = "server=localhost;database=senior-citizeen;user=root;password=;"

        ' Create a MySQL connection
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Create a SQL query to insert the data into the table
            Dim query As String = "INSERT INTO tblseniorcitizen (RegistrationNumber, Name, DateofBirth, ContactNumber, CommunicationAddress, EmergencyAddress, EmergencyContactnumber) " &
                                  "VALUES (@RegistrationNumber, @Name, @DateOfBirth, @ContactNumber, @CommunicationAddress, @EmergencyAddress, @EmergencyContactnumber);"
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter values
                command.Parameters.AddWithValue("@RegistrationNumber", registrationNumber)
                command.Parameters.AddWithValue("@Name", name)
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth)
                command.Parameters.AddWithValue("@ContactNumber", contactNumber)
                command.Parameters.AddWithValue("@CommunicationAddress", communicationAddress)
                command.Parameters.AddWithValue("@EmergencyAddress", emergencyAddress)
                command.Parameters.AddWithValue("@EmergencyContactnumber", emergencyContactnumber)


                ' Execute the query
                command.ExecuteNonQuery()

                MessageBox.Show("Data saved successfully")
            End Using
        End Using
    End Sub

    Private Function GenerateRegistrationNumber() As String
        Dim random As New Random()
        Dim registrationNumber As String = ""

        For i As Integer = 1 To 10
            registrationNumber += random.Next(0, 10).ToString()
        Next

        Return registrationNumber
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mainForm As New Form2()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim mainForm As New Form4()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mainForm As New Form1()
        mainForm.Show()
        Me.Close()
    End Sub
End Class