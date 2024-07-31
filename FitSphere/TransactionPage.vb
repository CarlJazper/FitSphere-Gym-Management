Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule

Public Class TransactionPage
    Private Sub TransactionPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim comboBoxes As ComboBox() = {cbCid, cbTrainers, cbMemPlan, cbPayMeth, cbPaystatus}
        Dim fieldNames As String() = {"customer", "trainer", "membership plan", "payment method", "payment status"}

        If Not ValidateComboBoxes(comboBoxes, fieldNames) Then
            Return
        End If

        Dim selectedCustomer = CType(cbCid.SelectedItem, Object)
        Dim custId As Integer = selectedCustomer.ID
        Dim selectedTrainer = CType(cbTrainers.SelectedItem, Object)
        Dim trainerId As Integer = selectedTrainer.ID
        Dim selectedMemPlan = CType(cbMemPlan.SelectedItem, Object)
        Dim memPlanId As Integer = selectedMemPlan.ID
        Dim payMethod As String = cbPayMeth.SelectedItem.ToString()
        Dim payStatus As String = cbPaystatus.SelectedItem.ToString()
        Dim amount As Decimal = Convert.ToDecimal(lblDispprice.Text)
        Dim durationDays As Integer = 0
        Dim startDate As Date = dtpStart.Value
        Dim endDate As Date

        TransClearForm(Me)
        Try
            conn.Open()
            sql = $"SELECT duration_days FROM membership_plans WHERE membership_plan_id = {memPlanId}"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read() Then
                durationDays = Convert.ToInt32(dbread("duration_days"))
            End If
            dbread.Close()
            endDate = startDate.AddDays(durationDays)

            'sql = $"INSERT INTO transactions (customers_customer_id, trainer_id, membership_plan_id, payment_method, payment_status, amount, end_date) " &
            ' $"VALUES ({custId}, {trainerId}, {memPlanId}, '{payMethod}', '{payStatus}', {amount}, '{endDate.ToString("yyyy-MM-dd HH:mm:ss")}')"
            sql = $"INSERT INTO transactions (customers_customer_id, trainer_id, membership_plan_id, payment_method, payment_status, amount, start_date, end_date) " &
                  $"VALUES ({custId}, {trainerId}, {memPlanId}, '{payMethod}', '{payStatus}', {amount}, '{startDate.ToString("yyyy-MM-dd HH:mm:ss")}', '{endDate.ToString("yyyy-MM-dd HH:mm:ss")}')"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Transaction successfully added.")
                GenerateReceipt(conn, custId, trainerId, memPlanId, payMethod, payStatus, amount, endDate)
            Else
                MsgBox("Failed to add transaction.")
            End If

        Catch ex As MySqlException
            MsgBox("MySQL error: " & ex.Message)
        End Try
        conn.Close()
        LoadData()
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter equipment id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            Dim ans As DialogResult = MessageBox.Show("Do you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM transactions WHERE transaction_id = {id}"
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
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub cbCid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCid.SelectedIndexChanged
        Dim selectedCustomer As Object = cbCid.SelectedItem
        If selectedCustomer IsNot Nothing AndAlso selectedCustomer.GetType().GetProperty("ID") IsNot Nothing Then
            Dim custId As Integer = Convert.ToInt32(selectedCustomer.GetType().GetProperty("ID").GetValue(selectedCustomer, Nothing))

            Try
                conn.Open()
                sql = $"SELECT fname, lname, address, city, zip, phone, email FROM customers WHERE customer_id = {custId}"
                dbcomm = New MySqlCommand(sql, conn)
                dbread = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    PopulateCustomerFields(Me, dbread)
                End If
            Catch ex As MySqlException
                MsgBox(ex.Message)
            End Try
        End If
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub cbTrainers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTrainers.SelectedIndexChanged
        Dim selectedTrainer As Object = cbTrainers.SelectedItem

        If selectedTrainer IsNot Nothing AndAlso selectedTrainer.GetType().GetProperty("ID") IsNot Nothing Then
            Dim trainerId As Integer = Convert.ToInt32(selectedTrainer.GetType().GetProperty("ID").GetValue(selectedTrainer, Nothing))
            Try
                conn.Open()
                sql = $"SELECT CONCAT(fname, ' ', lname) AS fullname, specialty FROM trainers WHERE trainer_id = {trainerId}"
                dbcomm = New MySqlCommand(sql, conn)
                dbread = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    lblSpec.Text = dbread("specialty")
                    lblSpec.Visible = True
                End If
            Catch ex As MySqlException
                MsgBox(ex.Message)
            End Try
        End If
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub cbMemPlan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMemPlan.SelectedIndexChanged
        Dim selectedMemPlan As Object = cbMemPlan.SelectedItem

        If selectedMemPlan IsNot Nothing AndAlso selectedMemPlan.GetType().GetProperty("ID") IsNot Nothing Then
            Dim memID As Integer = Convert.ToInt32(selectedMemPlan.GetType().GetProperty("ID").GetValue(selectedMemPlan, Nothing))

            Try
                conn.Open()
                sql = $"SELECT duration_days, price FROM membership_plans WHERE membership_plan_id = {memID}"
                dbcomm = New MySqlCommand(sql, conn)
                dbread = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    lblDispname.Text = $"{dbread("duration_days")} Days"
                    lblDispprice.Text = dbread("price")
                    lblDispname.Visible = True
                    lblDispprice.Visible = True
                End If
            Catch ex As MySqlException
                MsgBox(ex.Message)
            End Try
        End If
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub LoadData()
        'datgrid
        Try
            conn.Open()
            sql = "select * from transactions"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "transactions1")
            dgvTrans.DataSource = ds
            dgvTrans.DataMember = "transactions1"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dbread.Close()
        conn.Close()

        'cb
        Try
            conn.Open()
            cbCid.Items.Clear()
            sql = "SELECT customer_id, CONCAT(fname, ' ', lname) AS fullname FROM customers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbCid.Items.Add(New With {Key .ID = dbread("customer_id"), Key .Display = dbread("fullname")})
            End While
            cbCid.DisplayMember = "Display"
            cbCid.ValueMember = "ID"
            dbread.Close()

            cbTrainers.Items.Clear()
            sql = "SELECT trainer_id, CONCAT(fname, ' ', lname) AS fullname FROM trainers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbTrainers.Items.Add(New With {Key .ID = dbread("trainer_id"), Key .Display = dbread("fullname")})
            End While
            cbTrainers.DisplayMember = "Display"
            cbTrainers.ValueMember = "ID"
            dbread.Close()

            cbMemPlan.Items.Clear()
            sql = "SELECT membership_plan_id, name FROM membership_plans"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbMemPlan.Items.Add(New With {Key .ID = dbread("membership_plan_id"), Key .Display = dbread("name")})
            End While
            cbMemPlan.DisplayMember = "Display"
            cbMemPlan.ValueMember = "ID"
        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
        dbread.Close()
        conn.Close()

        cbPayMeth.Items.Clear()
        cbPayMeth.Items.Add("cash")
        cbPayMeth.Items.Add("card")
        cbPayMeth.Items.Add("e-wallet")

        cbPaystatus.Items.Clear()
        cbPaystatus.Items.Add("paid")
        cbPaystatus.Items.Add("outstanding")
    End Sub

End Class
