Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule
Public Class MembershipPage

    Private Sub MembershipPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub cbMpid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMpid.SelectedIndexChanged
        If cbMpid.SelectedItem Is Nothing Then
            Return
        End If

        Dim mpId As Integer = Val(cbMpid.SelectedItem.ToString())
        Try
            conn.Open()
            sql = $"SELECT name, description, duration_days, price FROM membership_plans WHERE membership_plan_id = {mpId}"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read() Then
                txtMname.Text = dbread("name").ToString()
                txtDesc.Text = dbread("description").ToString()
                txtDur.Text = dbread("duration_days").ToString()
                txtPrc.Text = dbread("price").ToString()
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim mInf As MemInfo = GetMemInfo(Me)
        MembershipClearForm(Me)

        If mInf.mName = "" Or mInf.mDesc = "" Or mInf.mDur = "" Or mInf.mPrc = "" Then
            MsgBox("Please fill in all fields")
        Else
            Try
                conn.Open()
                sql = "INSERT INTO membership_plans (name, description, duration_days, price) VALUES ('" & mInf.mName & "','" & mInf.mDesc & "','" & mInf.mDur & "','" & mInf.mPrc & "')"
                dbcomm = New MySqlCommand(sql, conn)
                Dim i As Integer = dbcomm.ExecuteNonQuery

                If (i > 0) Then
                    MsgBox("record saved")
                Else
                    MsgBox("record not saved")
                End If
            Catch ex As MySqlException
                MsgBox("plan not created")
            End Try
            conn.Close()
        End If
        loadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbMpid.SelectedItem Is Nothing Then
            MsgBox("Please select a plan to update.")
            Return
        End If

        Dim mpId As Integer = Val(cbMpid.SelectedItem.ToString())
        Dim mInf As MemInfo = GetMemInfo(Me)
        MembershipClearForm(Me)

        Try
            conn.Open()
            sql = $"UPDATE membership_plans SET name = '{mInf.mName   }', description = '{mInf.mDesc  }', duration_days = '{mInf.mDur }', price = '{mInf.mPrc }' WHERE membership_plan_id = {mpId}"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery

            If (i > 0) Then
                MsgBox("record updated")
            Else
                MsgBox("record not saved")
            End If
        Catch ex As Exception
            MsgBox("Error updating membership plan: " & ex.Message)
        End Try
        conn.Close()
        loadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter plan id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            sql = $"SELECT membership_plan_id FROM transactions WHERE membership_plan_id = {id} LIMIT 1"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read Then
                MsgBox("Membership plan cannot be deleted because there are associated transactions.")
                dbread.Close()
                Return
            End If
            dbread.Close()

            Dim ans As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM membership_plans WHERE membership_plan_id = {id}"
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
            sql = "select * from membership_plans"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "membership_plans")
            dgvMemPlan.DataSource = ds
            dgvMemPlan.DataMember = "membership_plans"

            cbMpid.Items.Clear()
            sql = "SELECT membership_plan_id FROM membership_plans"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbMpid.Items.Add(dbread("membership_plan_id"))
            End While

        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txtDur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDur.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtDur.TextLength >= 3 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEqprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrc.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtPrc.TextLength >= 99 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class