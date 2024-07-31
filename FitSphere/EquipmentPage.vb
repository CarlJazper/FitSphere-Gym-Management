Imports MySql.Data.MySqlClient
Imports FitSphere.DatabaseModule

Public Class EquipmentPage

    Private Sub EquipmentPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim equipInf As EquipmentInfo = GetEquipmentInfo(Me)
        Dim supId As Integer = 0

        If cbSupp.SelectedItem IsNot Nothing Then
            Dim selectedSupplier = CType(cbSupp.SelectedItem, Object)
            supId = selectedSupplier.ID
        End If

        If equipInf.eqpName = "" Or equipInf.eqpPrc = "" Or equipInf.eqpQuan = "" Or supId = 0 Then
            MsgBox("Please fill in all fields including the supplier.")
            Return
        End If

        EquipmentClearForm(Me)
        Try
            conn.Open()
            Dim sql = "INSERT INTO equipment (name, quantity, price) VALUES ('" & equipInf.eqpName & "','" & equipInf.eqpQuan & "','" & equipInf.eqpPrc & "')"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery()

            If i > 0 Then
                Dim equipmentId As Integer = dbcomm.LastInsertedId
                sql = "INSERT INTO suppliers_has_equipment (suppliers_supplier_id, equipment_equipment_id) VALUES ('" & supId & "','" & equipmentId & "')"
                dbcomm = New MySqlCommand(sql, conn)
                i = dbcomm.ExecuteNonQuery()

                If i > 0 Then
                    MsgBox("Equipment saved.")
                Else
                    MsgBox("Equipment saved, but supplier not saved.")
                End If
            Else
                MsgBox("Equipment not saved.")
            End If

        Catch ex As MySqlException
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim equipInf As EquipmentInfo = GetEquipmentInfo(Me)
        Dim eqpId As Integer = Val(cbEqid.SelectedItem)
        Dim suppId As Integer = 0

        If cbSupp.SelectedItem IsNot Nothing Then
            Dim selectedSupplier = CType(cbSupp.SelectedItem, Object)
            suppId = selectedSupplier.ID
        End If

        If cbSupp.SelectedItem Is Nothing Then
            MsgBox("Please select an equipment to update.")
            Return
        End If

        EquipmentClearForm(Me)
        Try
            conn.Open()
            sql = $"UPDATE equipment SET name = '{equipInf.eqpName}', price = '{equipInf.eqpPrc}', quantity = '{equipInf.eqpQuan}' WHERE equipment_id = {eqpId}"
            dbcomm = New MySqlCommand(sql, conn)
            Dim i As Integer = dbcomm.ExecuteNonQuery

            If i > 0 Then
                sql = $"UPDATE suppliers_has_equipment SET suppliers_supplier_id = {suppId} WHERE equipment_equipment_id = {eqpId}"
                dbcomm = New MySqlCommand(sql, conn)
                i = dbcomm.ExecuteNonQuery

                If i > 0 Then
                    MsgBox("Equipment updated.")
                Else
                    MsgBox("Equipment saved, but supplier association not saved.")
                End If
            Else
                MsgBox("Equipment not saved.")
            End If

        Catch ex As MySqlException
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            conn.Open()
            Dim idStr As String = InputBox("Enter equipment id to be deleted", "Delete Record")
            Dim id As Integer

            If Not Integer.TryParse(idStr, id) Then
                Return
            End If

            Dim ans As DialogResult = MessageBox.Show("Do you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNoCancel)
            If ans = DialogResult.Yes Then
                sql = $"DELETE FROM suppliers_has_equipment WHERE equipment_equipment_id = {id}"
                dbcomm = New MySqlCommand(sql, conn)
                dbcomm.ExecuteNonQuery()

                sql = $"DELETE FROM equipment WHERE equipment_id = {id}"
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

    Private Sub cbEqid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEqid.SelectedIndexChanged
        EquipmentClearCb(Me)
        Dim eqpId As Integer = Val(cbEqid.SelectedItem)
        Dim selectedSupplierId As Integer = -1

        Try
            conn.Open()
            sql = $"SELECT e.name, e.price, e.quantity, s.supplier_id, s.name AS supplier_name " &
              "FROM equipment e " &
              "LEFT JOIN suppliers_has_equipment se ON e.equipment_id = se.equipment_equipment_id " &
              "LEFT JOIN suppliers s ON se.suppliers_supplier_id = s.supplier_id " &
              $"WHERE e.equipment_id = {eqpId}"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            If dbread.Read() Then
                txtEqname.Text = dbread("name")
                txtEqprice.Text = dbread("price")
                txtQuan.Text = dbread("quantity")
                selectedSupplierId = dbread("supplier_id")
            End If
            dbread.Close()

            For i As Integer = 0 To cbSupp.Items.Count - 1
                Dim item = CType(cbSupp.Items(i), Object)
                If item.ID = selectedSupplierId Then
                    cbSupp.SelectedIndex = i
                    Exit For
                End If
            Next

        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadData()
        Try
            conn.Open()

            sql = "SELECT e.equipment_id, e.name AS equipment_name, e.quantity, e.price, s.name AS supplier_name " &
                  "FROM equipment e " &
                  "LEFT JOIN suppliers_has_equipment se ON e.equipment_id = se.equipment_equipment_id " &
                  "LEFT JOIN suppliers s ON se.suppliers_supplier_id = s.supplier_id"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(ds, "equipment1")
            dgvEqp.DataSource = ds
            dgvEqp.DataMember = "equipment1"

            cbEqid.Items.Clear()
            sql = "SELECT * FROM equipment"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbEqid.Items.Add(dbread("equipment_id"))
            End While
            dbread.Close()

            cbSupp.Items.Clear()
            sql = "SELECT supplier_id, name FROM suppliers"
            dbcomm = New MySqlCommand(sql, conn)
            dbread = dbcomm.ExecuteReader()
            While dbread.Read()
                cbSupp.Items.Add(New With {.Name = dbread("name"), .ID = dbread("supplier_id")})
            End While
            cbSupp.DisplayMember = "Name"
            cbSupp.ValueMember = "ID"
            dbread.Close()

        Catch ex As Exception
            MsgBox("Error in collecting data from Database. Error is :" & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub txtEqprice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEqprice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtEqprice.TextLength >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtQuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuan.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        If txtQuan.TextLength >= 2 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub cbSupp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupp.SelectedIndexChanged

    End Sub

    Private Sub txtQuan_TextChanged(sender As Object, e As EventArgs) Handles txtQuan.TextChanged

    End Sub

    Private Sub txtEqprice_TextChanged(sender As Object, e As EventArgs) Handles txtEqprice.TextChanged

    End Sub

    Private Sub txtEqname_TextChanged(sender As Object, e As EventArgs) Handles txtEqname.TextChanged

    End Sub
End Class