<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportExpenses
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
        Me.crvExpenses = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvExpenses
        '
        Me.crvExpenses.ActiveViewIndex = -1
        Me.crvExpenses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvExpenses.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvExpenses.Location = New System.Drawing.Point(0, 0)
        Me.crvExpenses.Name = "crvExpenses"
        Me.crvExpenses.Size = New System.Drawing.Size(992, 646)
        Me.crvExpenses.TabIndex = 0
        Me.crvExpenses.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 646)
        Me.Controls.Add(Me.crvExpenses)
        Me.Name = "ReportExpenses"
        Me.Text = "ReportExpenses"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crvExpenses As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
