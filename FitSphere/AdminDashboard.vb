Imports MySql.Data.MySqlClient
Public Class AdminDashboard

    Private Sub btnCust_Click(sender As Object, e As EventArgs) Handles btnCust.Click
        switchPanel(New CustomerPage)
    End Sub

    Private Sub btnTrainer_Click(sender As Object, e As EventArgs) Handles btnTrainer.Click
        switchPanel(New TrainerPage)
    End Sub

    Private Sub btnMem_Click(sender As Object, e As EventArgs) Handles btnMem.Click
        switchPanel(New MembershipPage)
    End Sub

    Private Sub btnTransac_Click(sender As Object, e As EventArgs) Handles btnTransac.Click
        switchPanel(New TransactionPage)
    End Sub

    Private Sub btnEquip_Click(sender As Object, e As EventArgs) Handles btnEquip.Click
        switchPanel(New EquipmentPage)
    End Sub

    Private Sub btnSupp_Click(sender As Object, e As EventArgs) Handles btnSupp.Click
        switchPanel(New SupplierPage)
    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        switchPanel(New ReportPage)
        'PrintReport.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Close()
            Dim landingPage As New LandingPage()
            landingPage.Show()
        End If
    End Sub

    Sub switchPanel(ByVal panel As Form)

        If Panel1.Controls.Contains(panel) Then
            panel.BringToFront()
            Return
        End If

        For Each form As Form In Panel1.Controls.OfType(Of Form)().ToList()
            form.Close()
        Next

        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class