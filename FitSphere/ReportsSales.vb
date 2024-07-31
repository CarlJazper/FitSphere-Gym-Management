Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared
Imports FitSphere.DatabaseModule

Public Class ReportsSales
    Private Sub ReportsSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DatabaseModule.LoadSalesData()
            Dim report As New ReportDocument()
            Dim reportPath As String = "../../../crSales.rpt"
            report.Load(reportPath)
            report.SetDataSource(DatabaseModule.dsRep)
            crvSales.ReportSource = report
            crvSales.Refresh()

        Catch ex As CrystalReportsException
            MsgBox("Crystal Reports error: " & ex.Message)
        Catch ex As Exception
            MsgBox("General error: " & ex.Message)
        End Try
    End Sub
End Class
