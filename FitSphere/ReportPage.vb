Public Class ReportPage

    Private Sub btnExpenses_Click(sender As Object, e As EventArgs) Handles btnExpenses.Click
        Dim reportForm As New ReportExpenses()
        reportForm.Show()
        'switchPanel(New ReportExpenses)
    End Sub

    Private Sub btnTrends_Click(sender As Object, e As EventArgs) Handles btnTrends.Click
        Dim reportForm As New ReportPlans()
        reportForm.Show()
        'switchPanel(New ReportExpenses)
    End Sub

    Private Sub btnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        Dim reportForm As New ReportsSales()
        reportForm.Show()
        'switchPanel(New ReportSales)
    End Sub
End Class