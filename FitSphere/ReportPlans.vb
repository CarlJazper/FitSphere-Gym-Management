Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportPlans
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles crvPlans.Load
        Try
            DatabaseModule.LoadPlanData()
            Dim report As New ReportDocument()
            Dim reportPath As String = "../../../crPlans.rpt"
            report.Load(reportPath)
            report.SetDataSource(DatabaseModule.dsRep)
            crvPlans.ReportSource = report
            crvPlans.Refresh()


        Catch ex As CrystalReportsException
            MsgBox("Crystal Reports error: " & ex.Message)
        Catch ex As Exception
            MsgBox("General error: " & ex.Message)
        End Try
    End Sub
End Class