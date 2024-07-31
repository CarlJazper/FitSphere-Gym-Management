Imports MySql.Data.MySqlClient

Module DatabaseModule
    Public conn As MySqlConnection = New MySqlConnection("Data Source=localhost;Database=db_fitsphere;User=root;Password=;")
    Public dbconn As New MySqlConnection
    Public sql As String
    Public dbcomm As MySqlCommand
    Public dbread As MySqlDataReader
    Public DataAdapter1 As MySqlDataAdapter
    Public ds As DataSet
    Public dsRep As New DataSet("DataSetReports")

    Public Sub LoadExpensesData()
        dsRep.Tables.Clear()
        Try
            conn.Open()
            sql = "SELECT e.equipment_id, e.name, e.quantity, e.price, " &
              "(e.quantity * e.price) AS total_price, " &
              "s.name AS supplier_name " &
              "FROM equipment e " &
              "LEFT JOIN suppliers_has_equipment se ON e.equipment_id = se.equipment_equipment_id " &
              "LEFT JOIN suppliers s ON se.suppliers_supplier_id = s.supplier_id"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(dsRep, "equipment")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub LoadSalesData()
        dsRep.Tables.Clear()
        Try
            conn.Open()
            sql = "SELECT t.transaction_id, " &
              "CONCAT(c.fname, ' ', c.lname) AS customer_name, " &
              "CONCAT(tr.fname, ' ', tr.lname) AS trainer_name, " &
              "mp.name AS membership_plan, " &
              "t.payment_method, t.payment_status, t.amount, t.start_date, t.end_date " &
              "FROM transactions t " &
              "JOIN customers c ON t.customers_customer_id = c.customer_id " &
              "JOIN trainers tr ON t.trainer_id = tr.trainer_id " &
              "JOIN membership_plans mp ON t.membership_plan_id = mp.membership_plan_id " &
              "ORDER BY t.transaction_id ASC"
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(dsRep, "transactions")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub LoadPlanData()
        dsRep.Tables.Clear()
        Try
            conn.Open()
            sql = "SELECT m.membership_plan_id, m.name, COUNT(t.membership_plan_id) AS availed_count " &
                        "FROM membership_plans m " &
                        "JOIN transactions t ON m.membership_plan_id = t.membership_plan_id " &
                        "GROUP BY m.name " &
                        "ORDER BY availed_count DESC "
            dbcomm = New MySqlCommand(sql, conn)
            DataAdapter1 = New MySqlDataAdapter(sql, conn)
            ds = New DataSet()
            DataAdapter1.Fill(dsRep, "membership_plans")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function ValidateComboBoxes(comboBoxes As ComboBox(), fieldNames As String()) As Boolean
        Dim messages As String = ""

        For i As Integer = 0 To comboBoxes.Length - 1
            If comboBoxes(i).SelectedItem Is Nothing Then
                messages &= $"Please select {fieldNames(i)}," & vbCrLf
            End If
        Next

        If messages <> "" Then
            MsgBox(messages.TrimEnd(","c, vbCrLf))
            Return False
        End If
        Return True
    End Function


    Public Sub ClearTextFields(ByVal ParamArray textFields() As TextBox)
        For Each txt As TextBox In textFields
            txt.Clear()
        Next
    End Sub

    Public Sub PopulateCustomerFields(form As Object, dbread As MySqlDataReader)
        Try
            If TypeOf form Is CustomerPage Then
                Dim custForm As CustomerPage = DirectCast(form, CustomerPage)
                custForm.txtFname.Text = dbread("fname").ToString()
                custForm.txtLname.Text = dbread("lname").ToString()
                custForm.txtAddress.Text = dbread("address").ToString()
                custForm.txtCity.Text = dbread("city").ToString()
                custForm.txtZip.Text = dbread("zip").ToString()
                custForm.txtPhone.Text = dbread("phone").ToString()
                custForm.txtEmail.Text = dbread("email").ToString()
            ElseIf TypeOf form Is TransactionPage Then
                Dim transForm As TransactionPage = DirectCast(form, TransactionPage)
                transForm.txtFname.Text = dbread("fname").ToString()
                transForm.txtLname.Text = dbread("lname").ToString()
                transForm.txtAddress.Text = dbread("address").ToString()
                transForm.txtCity.Text = dbread("city").ToString()
                transForm.txtZip.Text = dbread("zip").ToString()
                transForm.txtPhone.Text = dbread("phone").ToString()
                transForm.txtEmail.Text = dbread("email").ToString()
            Else
                Throw New ArgumentException("Unsupported form type.")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    'Customer
    Public Structure CustomerInfo
        Public firstName As String
        Public lastName As String
        Public email As String
        Public address As String
        Public city As String
        Public zipcode As String
        Public phone As String
    End Structure

    Public Function GetCustomerInfo(Form As CustomerPage) As CustomerInfo
        Dim info As CustomerInfo
        info.firstName = Form.txtFname.Text
        info.lastName = Form.txtLname.Text
        info.email = Form.txtEmail.Text
        info.address = Form.txtAddress.Text
        info.city = Form.txtCity.Text
        info.zipcode = Form.txtZip.Text
        info.phone = Form.txtPhone.Text
        Return info
    End Function

    Public Sub CustomerClearForm(Form As CustomerPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtEmail, Form.txtAddress, Form.txtCity, Form.txtZip, Form.txtPhone)
        Form.cbCid.SelectedIndex = -1
    End Sub

    Public Sub CustomerClearCb(Form As CustomerPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtEmail, Form.txtAddress, Form.txtCity, Form.txtZip, Form.txtPhone)
    End Sub

    'Equip
    Public Structure EquipmentInfo
        Public eqpName As String
        Public eqpQuan As String
        Public eqpPrc As String
    End Structure

    Public Function GetEquipmentInfo(Form As EquipmentPage) As EquipmentInfo
        Dim eqpinfo As EquipmentInfo
        eqpinfo.eqpName = Form.txtEqname.Text
        eqpinfo.eqpQuan = Form.txtQuan.Text
        eqpinfo.eqpPrc = Form.txtEqprice.Text
        Return eqpinfo
    End Function

    Public Sub EquipmentClearForm(Form As EquipmentPage)
        ClearTextFields(Form.txtEqname, Form.txtEqprice, Form.txtQuan)
        Form.cbEqid.SelectedIndex = -1
        Form.cbSupp.SelectedIndex = -1
    End Sub

    Public Sub EquipmentClearCb(Form As EquipmentPage)
        ClearTextFields(Form.txtEqname, Form.txtEqprice, Form.txtQuan)
    End Sub

    'Membership
    Public Structure MemInfo
        Public mName As String
        Public mDesc As String
        Public mDur As String
        Public mPrc As String
    End Structure

    Public Function GetMemInfo(Form As MembershipPage) As MemInfo
        Dim mpinfo As MemInfo
        mpinfo.mName = Form.txtMname.Text
        mpinfo.mDesc = Form.txtDesc.Text
        mpinfo.mDur = Form.txtDur.Text
        mpinfo.mPrc = Form.txtPrc.Text
        Return mpinfo
    End Function

    Public Sub MembershipClearForm(Form As MembershipPage)
        ClearTextFields(Form.txtMname, Form.txtDesc, Form.txtDur, Form.txtPrc)
        Form.cbMpid.SelectedIndex = -1
    End Sub

    'trainer
    Public Structure TrInfo
        Public trFname As String
        Public trLname As String
        Public trPhone As String
        Public trSpec As String
    End Structure

    Public Function GetTrInfo(Form As TrainerPage) As TrInfo
        Dim tinfo As TrInfo
        tinfo.trFname = Form.txtFname.Text
        tinfo.trLname = Form.txtLname.Text
        tinfo.trPhone = Form.txtPhone.Text
        tinfo.trSpec = Form.txtSpecialty.Text
        Return tinfo
    End Function

    Public Sub TrainerClearForm(Form As TrainerPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtPhone, Form.txtSpecialty)
        Form.cbTid.SelectedIndex = -1
    End Sub
    Public Sub TrainerClearCb(Form As TrainerPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtPhone, Form.txtSpecialty)
    End Sub

    'transaction
    Public Sub TransClearForm(Form As TransactionPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtEmail, Form.txtAddress, Form.txtCity, Form.txtZip, Form.txtPhone)
        Form.cbCid.SelectedIndex = -1
        Form.cbTrainers.SelectedIndex = -1
        Form.cbMemPlan.SelectedIndex = -1
        Form.cbPayMeth.SelectedIndex = -1
        Form.cbPaystatus.SelectedIndex = -1

        Form.lblDispname.Text = ""
        Form.lblDispprice.Text = ""
    End Sub

    Public Sub TransClearCb(Form As TransactionPage)
        ClearTextFields(Form.txtFname, Form.txtLname, Form.txtEmail, Form.txtAddress, Form.txtCity, Form.txtZip, Form.txtPhone)
    End Sub
    Public Function GetSelectedItemId(comboBox As ComboBox) As Integer
        If comboBox.SelectedItem IsNot Nothing Then
            Dim itemType = comboBox.SelectedItem.GetType()
            Dim propInfo = itemType.GetProperty("ID")

            If propInfo IsNot Nothing AndAlso propInfo.PropertyType Is GetType(Integer) Then
                Return Convert.ToInt32(propInfo.GetValue(comboBox.SelectedItem))
            End If
        End If
        Return 0
    End Function

    Public Function GetSelectedItemString(comboBox As ComboBox) As String
        Return If(comboBox.SelectedItem IsNot Nothing, comboBox.SelectedItem.ToString(), "")
    End Function

    'receipt
    Public Sub GenerateReceipt(conn As MySqlConnection, custId As Integer, trainerId As Integer, memPlanId As Integer, payMethod As String, payStatus As String, amount As Decimal, endDate As Date)
        Dim customerName As String = ""
        Dim trainerName As String = ""
        Dim membershipPlanName As String = ""

        Dim sql As String = $"SELECT CONCAT(fname, ' ', lname) AS fullname FROM customers WHERE customer_id = {custId}"
        Using dbcomm As New MySqlCommand(sql, conn)
            Using dbread As MySqlDataReader = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    customerName = dbread("fullname").ToString()
                End If
            End Using
        End Using

        sql = $"SELECT CONCAT(fname, ' ', lname) AS fullname FROM trainers WHERE trainer_id = {trainerId}"
        Using dbcomm As New MySqlCommand(sql, conn)
            Using dbread As MySqlDataReader = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    trainerName = dbread("fullname").ToString()
                End If
            End Using
        End Using

        sql = $"SELECT name FROM membership_plans WHERE membership_plan_id = {memPlanId}"
        Using dbcomm As New MySqlCommand(sql, conn)
            Using dbread As MySqlDataReader = dbcomm.ExecuteReader()
                If dbread.Read() Then
                    membershipPlanName = dbread("name").ToString()
                End If
            End Using
        End Using

        Dim receiptForm As New ReceiptForm()
        receiptForm.SetReceiptDetails(customerName, trainerName, membershipPlanName, payMethod, payStatus, amount, endDate)
        receiptForm.ShowDialog()
    End Sub

End Module
