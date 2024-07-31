Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports FitSphere.DatabaseModule

Public Class ReportExpenses
    Private Sub ReportExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DatabaseModule.LoadExpensesData()
            Dim report As New ReportDocument()
            Dim reportPath As String = "../../../crExpenses.rpt"
            report.Load(reportPath)
            report.SetDataSource(DatabaseModule.dsRep)
            crvExpenses.ReportSource = report
            crvExpenses.Refresh()


        Catch ex As CrystalReportsException
            MsgBox("Crystal Reports error: " & ex.Message)
        Catch ex As Exception
            MsgBox("General error: " & ex.Message)
        End Try
    End Sub
End Class