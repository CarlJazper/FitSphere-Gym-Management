<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportsSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.crvSales = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvSales
        '
        Me.crvSales.ActiveViewIndex = -1
        Me.crvSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvSales.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvSales.Location = New System.Drawing.Point(0, 0)
        Me.crvSales.Name = "crvSales"
        Me.crvSales.Size = New System.Drawing.Size(994, 644)
        Me.crvSales.TabIndex = 0
        Me.crvSales.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ReportsSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 644)
        Me.Controls.Add(Me.crvSales)
        Me.Name = "ReportsSales"
        Me.Text = "ReportsSales"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents crvSales As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
