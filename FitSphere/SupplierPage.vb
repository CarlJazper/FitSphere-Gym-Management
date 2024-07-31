Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule
Imports System.Data.Common

Public Class SupplierPage

    Private Sub SupplierPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub cbSid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSid.SelectedIndexChanged
        If cbSid.SelectedItem Is Nothing Then
            Return
        End If

        txtName.Clear()
        txtAddr.Clear()
        txtContact.Clear()

        Dim suppId As Integer = Val(cbSid.SelectedItem.ToString())
        Try
            conn.Open()
            sql = $"SELECT name, address, contact_info FROM suppliers WHERE supplier_id = {suppId}"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read() Then
                txtName.Text = dbread("name").ToString()
                txtAddr.Text = dbread("address").ToString()
                txtContact.Text = dbread("contact_info").ToString()
            End If

        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try
        dbread.Close()
        conn.Close()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim suppName = txtName.Text
        Dim suppAdd = txtAddr.Text
        Dim suppContact = txtContact.Text

        txtName.Clear()
        txtAddr.Clear()
        txtContact.Clear()
        cbSid.SelectedIndex = -1

        If suppName = "" Or suppAdd = "" Or suppContact = "" Then
            MsgBox("Please fill in all fields")
        Else
            Try
                conn.Open()
                sql = "INSERT INTO suppliers (name, address, contact_info) VALUES ('" & suppName & "','" & suppAdd & "','" & suppContact & "')"
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
        LoadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbSid.SelectedItem Is Nothing Then
            MsgBox("Please select a supplier to update.")
            Return
        End If

        Dim suppId As Integer = Val(cbSid.SelectedItem.ToString())
        Dim suppName = txtName.Text
        Dim suppAdd = txtAddr.Text
        Dim suppContact = txtContact.Text

        txtName.Clear()
        txtAddr.Clear()
        txtContact.Clear()

        cbSid.SelectedIndex = -1
        Try
            conn.Open()
            sql = $"UPDATE suppliers SET name = '{suppName }', address = '{suppAdd}', contact_info = '{suppContact}' WHERE supplier_id = {suppId}"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery

            If (i > 0) Then
                MsgBox("record updated")
            Else
                MsgBox("record not saved")
            End If
        Catch ex As Exception
            MsgBox("Error updating supplier: " & ex.Message)
        End Try
        conn.Close()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter supplier id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            Dim ans As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM suppliers_has_equipment WHERE suppliers_supplier_id = {id}"
                dbcomm = New MySqlCommand(sql, conn)
                dbcomm.ExecuteNonQuery()

                sql = $"DELETE FROM suppliers WHERE supplier_id = {id}"
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

    Private Sub LoadData()
        Try
            conn.Open()
            sql = "select * from suppliers"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "suppliers1")
            dgvSupplist.DataSource = ds
            dgvSupplist.DataMember = "suppliers1"

            cbSid.Items.Clear()
            sql = "SELECT supplier_id FROM suppliers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbSid.Items.Add(dbread("supplier_id"))
            End While

        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        End Try

        conn.Close()
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtContact.TextLength >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class