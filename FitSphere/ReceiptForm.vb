Imports FitSphere.DatabaseModule
Public Class ReceiptForm
    Private Sub ReceiptForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub SetReceiptDetails(customerName As String, trainerName As String, membershipPlanName As String, paymentMethod As String, paymentStatus As String, amount As Decimal, endDate As Date)

        lblCustomerName.Text = customerName
        lblTrainerName.Text = trainerName
        lblMembershipPlanName.Text = membershipPlanName
        lblPaymentMethod.Text = paymentMethod
        lblPaymentStatus.Text = paymentStatus
        lblAmount.Text = amount.ToString("C")
        lblEndDate.Text = endDate.ToString("yyyy-MM-dd")
    End Sub
End Class