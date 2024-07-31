<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPage
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
        Me.btnSalesReport = New System.Windows.Forms.Button()
        Me.btnTrends = New System.Windows.Forms.Button()
        Me.btnExpenses = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalesReport
        '
        Me.btnSalesReport.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesReport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSalesReport.Location = New System.Drawing.Point(20, 98)
        Me.btnSalesReport.Name = "btnSalesReport"
        Me.btnSalesReport.Size = New System.Drawing.Size(119, 29)
        Me.btnSalesReport.TabIndex = 0
        Me.btnSalesReport.Text = "Sales Report"
        Me.btnSalesReport.UseVisualStyleBackColor = False
        '
        'btnTrends
        '
        Me.btnTrends.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnTrends.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrends.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnTrends.Location = New System.Drawing.Point(167, 98)
        Me.btnTrends.Name = "btnTrends"
        Me.btnTrends.Size = New System.Drawing.Size(113, 29)
        Me.btnTrends.TabIndex = 1
        Me.btnTrends.Text = "Plan trends report"
        Me.btnTrends.UseVisualStyleBackColor = False
        '
        'btnExpenses
        '
        Me.btnExpenses.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenses.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnExpenses.Location = New System.Drawing.Point(301, 98)
        Me.btnExpenses.Name = "btnExpenses"
        Me.btnExpenses.Size = New System.Drawing.Size(118, 29)
        Me.btnExpenses.TabIndex = 2
        Me.btnExpenses.Text = "Expenses Report"
        Me.btnExpenses.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(371, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(343, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Welcome to Reports Page"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Controls.Add(Me.btnSalesReport)
        Me.GroupBox1.Controls.Add(Me.btnTrends)
        Me.GroupBox1.Controls.Add(Me.btnExpenses)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(313, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(439, 229)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose a report you want to view"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.FitSphere.My.Resources.Resources.exercise_weights_iron_dumbbell_with_extra_plates
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1117, 457)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'ReportPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1117, 457)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReportPage"
        Me.Text = "printreport"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnTrends As Button
    Friend WithEvents btnExpenses As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
