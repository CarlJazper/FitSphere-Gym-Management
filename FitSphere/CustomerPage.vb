Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule

Public Class CustomerPage

    Private Sub CustomerPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim custInfo As CustomerInfo = GetCustomerInfo(Me)
        CustomerClearForm(Me)

        If custInfo.firstName = "" Or custInfo.lastName = "" Or custInfo.email = "" Or custInfo.address = "" Or custInfo.city = "" Or custInfo.zipcode = "" Or custInfo.phone = "" Then
            MsgBox("Please fill in all fields")
        Else

            Try
                conn.Open()
                sql = "INSERT INTO customers (fname, lname, email, address, city, zip, phone) VALUES ('" & custInfo.firstName & "','" & custInfo.lastName & "','" & custInfo.email & "','" & custInfo.address & "','" & custInfo.city & "','" & custInfo.zipcode & "','" & custInfo.phone & "')"
                dbcomm = New MySqlCommand(sql, conn)
                Dim i As Integer = dbcomm.ExecuteNonQuery

                If (i > 0) Then
                    MsgBox("record saved")
                Else
                    MsgBox("record not saved")
                End If
            Catch ex As MySqlException
                MsgBox("customer not created")
            End Try
        End If
        conn.Close()
        LoadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbCid.SelectedItem Is Nothing Then
            MsgBox("Please select a customer to update.")
            Return
        End If

        Dim custInfo As CustomerInfo = GetCustomerInfo(Me)
        Dim custId As Integer = Val(cbCid.SelectedItem.ToString())
        CustomerClearForm(Me)

        Try
            conn.Open()
            sql = $"UPDATE customers SET fname = '{custInfo.firstName}', lname = '{custInfo.lastName}', address = '{custInfo.address}', city = '{custInfo.city}', zip = '{custInfo.zipcode}', phone = '{custInfo.phone}', email = '{custInfo.email}' WHERE customer_id = {custId}"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery

            If (i > 0) Then
                MsgBox("record updated")
            Else
                MsgBox("record not saved")
            End If
        Catch ex As Exception
            MsgBox("Error updating customer: " & ex.Message)
        End Try
        conn.Close()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter customer id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            Dim ans = MessageBox.Show("do you want to delete this record?", "record deleted", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM customers WHERE customer_id = {id}"
                dbcomm = New MySqlCommand(sql, conn)
                Dim i As Integer = dbcomm.ExecuteNonQuery

                If (i > 0) Then
                    MsgBox("record deleted")
                Else
                    MsgBox("record not deleted")
                End If
            End If

        Catch ex As MySqlException
            MsgBox("Customer cannot be deleted because they have existing transactions.")
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub cbCid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCid.SelectedIndexChanged
        CustomerClearCb(Me)
        If cbCid.SelectedItem Is Nothing Then
            Return
        End If

        Dim custId As Integer = Val(cbCid.SelectedItem.ToString())
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
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub LoadData()
        Try
            conn.Open()
            sql = "select * from customers"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "customers1")
            dgvCustList.DataSource = ds
            dgvCustList.DataMember = "customers1"

            cbCid.Items.Clear()
            sql = "SELECT customer_id FROM customers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbCid.Items.Add(dbread("customer_id"))
            End While
            dbread.Close()
        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try
        conn.Close()
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtPhone.TextLength >= 11 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtZip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtZip.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtZip.TextLength >= 5 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCustList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustList.CellContentClick

    End Sub
End Class