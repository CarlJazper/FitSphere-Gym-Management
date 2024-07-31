Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule

Public Class TrainerPage


    Private Sub TrainerPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub cbTid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTid.SelectedIndexChanged
        If cbTid.SelectedItem Is Nothing Then
            Return
        End If
        TrainerClearCb(Me)
        Dim trId As Integer = Val(cbTid.SelectedItem.ToString())

        Try
            conn.Open()
            sql = $"SELECT fname,lname, phone, specialty FROM trainers WHERE trainer_id = {trId}"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read() Then
                txtFname.Text = dbread("fname").ToString()
                txtLname.Text = dbread("lname").ToString()
                txtPhone.Text = dbread("phone").ToString()
                txtSpecialty.Text = dbread("specialty").ToString()
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim triInfo As TrInfo = GetTrInfo(Me)
        TrainerClearForm(Me)

        If triInfo.trFname = "" Or triInfo.trLname = "" Or triInfo.trPhone = "" Or triInfo.trSpec = "" Then
            MsgBox("Please fill in all fields")
        Else
            Try
                conn.Open()
                sql = "INSERT INTO trainers (fname, lname, phone, specialty) VALUES ('" & triInfo.trFname & "','" & triInfo.trLname & "','" & triInfo.trPhone & "','" & triInfo.trSpec & "')"
                dbcomm = New MySqlCommand(sql, conn)
                Dim i As Integer = dbcomm.ExecuteNonQuery

                If (i > 0) Then
                    MsgBox("record saved")
                Else
                    MsgBox("record not saved")

                End If
            Catch ex As MySqlException
                MsgBox("supplier not created")
            End Try
            conn.Close()
        End If
        loadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbTid.SelectedItem Is Nothing Then
            MsgBox("Please select a trainer to update.")
            Return
        End If

        Dim trId As Integer = Val(cbTid.SelectedItem.ToString())
        Dim triInfo As TrInfo = GetTrInfo(Me)

        TrainerClearForm(Me)

        Try
            conn.Open()
            sql = $"UPDATE trainers SET fname = '{triInfo.trFname  }', lname = '{triInfo.trLname }', phone = '{triInfo.trPhone }', specialty = '{triInfo.trSpec}' WHERE trainer_id = {trId}"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery

            If (i > 0) Then
                MsgBox("record updated")
            Else
                MsgBox("record not saved")
            End If
        Catch ex As Exception
            MsgBox("Error updating trainer: " & ex.Message)
        End Try
        conn.Close()
        loadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter trainer id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            sql = $"SELECT trainer_id FROM transactions WHERE trainer_id = {id} LIMIT 1"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()

            If dbread.Read Then
                MsgBox("Trainer cannot be deleted because there are associated transactions.")
                dbread.Close()
                Return
            End If
            dbread.Close()

            Dim ans As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM trainers WHERE trainer_id = {id}"
                dbcomm = New MySqlCommand(sql, conn)
                Dim i As Integer = dbcomm.ExecuteNonQuery

                If i > 0 Then
                    MsgBox("Record deleted")
                Else
                    MsgBox("Record not deleted")
                End If
            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
        loadData()
    End Sub

    Private Sub loadData()
        Try
            conn.Open()
            sql = "select * from trainers"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "trainers")
            dgvTrainerList.DataSource = ds
            dgvTrainerList.DataMember = "trainers"

            cbTid.Items.Clear()
            sql = "SELECT trainer_id FROM trainers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbTid.Items.Add(dbread("trainer_id"))
            End While

        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtPhone.TextLength >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class