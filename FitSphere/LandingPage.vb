Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule

Public Class LandingPage

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPass.Text.Trim()

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.")
        Else
            Try
                conn.Open()
                sql = "SELECT * FROM administrators WHERE username = @username AND password = @password"
                dbcomm = New MySqlCommand(sql, conn)
                dbcomm.Parameters.AddWithValue("@username", username)
                dbcomm.Parameters.AddWithValue("@password", password)

                dbread = dbcomm.ExecuteReader()

                If dbread.Read() Then
                    MessageBox.Show("Logged In")
                    Dim newForm As New AdminDashboard()
                    newForm.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid Username Or Password")
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            conn.Close()
        End If

    End Sub


End Class
