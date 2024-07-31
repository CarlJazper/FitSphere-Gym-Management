<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPlans
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crvPlans = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvPlans
        '
        Me.crvPlans.ActiveViewIndex = -1
        Me.crvPlans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPlans.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvPlans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvPlans.Location = New System.Drawing.Point(0, 0)
        Me.crvPlans.Name = "crvPlans"
        Me.crvPlans.Size = New System.Drawing.Size(992, 647)
        Me.crvPlans.TabIndex = 0
        Me.crvPlans.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportPlans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 647)
        Me.Controls.Add(Me.crvPlans)
        Me.Name = "ReportPlans"
        Me.Text = "ReportPlans"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crvPlans As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
