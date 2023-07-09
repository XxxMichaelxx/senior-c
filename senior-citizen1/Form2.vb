Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Form2

    Dim conn As MySqlConnection
    Dim myCommand As New MySqlCommand
    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim SQL As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim mainForm As New Form4()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdData.CellContentClick

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection()
        conn.ConnectionString = "server=localhost; database=senior-citizeen; user=root; password=;"

        Try
            conn.Open()

            SQL = "SELECT RegistrationNumber, Name, DateofBirth, ContactNumber, CommunicationAddress, EmergencyAddress, AddedBy, RegitrationDate FROM tblseniorcitizen"
            myCommand.Connection = conn
            myCommand.CommandText = SQL
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            grdData.DataSource = myData
            conn.Close()
        Catch ex As Exception
            MsgBox("Error:" & Err.Description)
        Finally
            conn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim mainForm As New Form3()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim mainForm As New Form1()
        mainForm.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If grdData.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = grdData.SelectedRows(0)
            Dim registrationNumber As String = selectedRow.Cells("RegistrationNumber").Value.ToString()

            ' Open connection
            conn = New MySqlConnection()
            conn.ConnectionString = "server=localhost; database=senior-citizeen; user=root; password=;"

            Try
                conn.Open()

                ' Delete record
                SQL = "DELETE FROM tblseniorcitizen WHERE RegistrationNumber = @RegistrationNumber"
                myCommand.Connection = conn
                myCommand.CommandText = SQL
                myCommand.Parameters.AddWithValue("@RegistrationNumber", registrationNumber)
                myCommand.ExecuteNonQuery()

                ' Refresh the DataGridView
                myData.Clear()
                myAdapter.Fill(myData)

                conn.Close()
            Catch ex As Exception
                MsgBox("Error:" & Err.Description)
            Finally
                conn.Dispose()
            End Try
        Else
            MsgBox("Please select a row to delete.")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If grdData.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = grdData.SelectedRows(0)
            Dim registrationNumber As String = selectedRow.Cells("RegistrationNumber").Value.ToString()

            ' Retrieve the updated values from the TextBox controls
            Dim updatedName As String = TextBox1.Text
            Dim updatedDateOfBirth As String = TextBox2.Text
            Dim updatedContactNumber As String = TextBox3.Text
            Dim updatedCommunicationAddress As String = TextBox4.Text
            Dim updatedEmergencyAddress As String = TextBox5.Text

            ' Update the selected row in the DataGridView
            selectedRow.Cells("Name").Value = updatedName
            selectedRow.Cells("DateofBirth").Value = updatedDateOfBirth
            selectedRow.Cells("ContactNumber").Value = updatedContactNumber
            selectedRow.Cells("CommunicationAddress").Value = updatedCommunicationAddress
            selectedRow.Cells("EmergencyAddress").Value = updatedEmergencyAddress

            ' Update the corresponding data in the database
            conn.Open()

            SQL = "UPDATE tblseniorcitizen SET Name = @Name, DateofBirth = @DateOfBirth, ContactNumber = @ContactNumber, CommunicationAddress = @CommunicationAddress, EmergencyAddress = @EmergencyAddress WHERE RegistrationNumber = @RegistrationNumber"
            myCommand.Connection = conn
            myCommand.CommandText = SQL
            myCommand.Parameters.AddWithValue("@Name", updatedName)
            myCommand.Parameters.AddWithValue("@DateOfBirth", updatedDateOfBirth)
            myCommand.Parameters.AddWithValue("@ContactNumber", updatedContactNumber)
            myCommand.Parameters.AddWithValue("@CommunicationAddress", updatedCommunicationAddress)
            myCommand.Parameters.AddWithValue("@EmergencyAddress", updatedEmergencyAddress)
            myCommand.Parameters.AddWithValue("@RegistrationNumber", registrationNumber)
            myCommand.ExecuteNonQuery()

            conn.Close()

            Me.Close()
            Dim mainForm As New Form2()
            mainForm.Show()

        Else
            MsgBox("Please select a row to update.")
        End If
    End Sub

    Private Sub grdData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdData.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = grdData.Rows(e.RowIndex)

            ' Retrieve the selected data
            Dim name As String = selectedRow.Cells("Name").Value.ToString()
            Dim dateOfBirth As String = selectedRow.Cells("DateofBirth").Value.ToString()
            Dim contactNumber As String = selectedRow.Cells("ContactNumber").Value.ToString()
            Dim communicationAddress As String = selectedRow.Cells("CommunicationAddress").Value.ToString()
            Dim emergencyAddress As String = selectedRow.Cells("EmergencyAddress").Value.ToString()

            ' Populate the TextBox controls
            TextBox1.Text = name
            TextBox2.Text = dateOfBirth
            TextBox3.Text = contactNumber
            TextBox4.Text = communicationAddress
            TextBox5.Text = emergencyAddress
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' Clear the current data in the DataTable
        myData.Clear()

        ' Open the database connection and retrieve the data again
        conn.Open()

        SQL = "SELECT RegistrationNumber, Name, DateofBirth, ContactNumber, CommunicationAddress, EmergencyAddress, AddedBy, RegitrationDate FROM tblseniorcitizen"
        myCommand.Connection = conn
        myCommand.CommandText = SQL
        myAdapter.SelectCommand = myCommand
        myAdapter.Fill(myData)

        conn.Close()

        ' Update the DataGridView with the refreshed data
        grdData.DataSource = myData
    End Sub

End Class