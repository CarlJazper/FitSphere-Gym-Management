<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
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
        Me.btnCust = New System.Windows.Forms.Button()
        Me.btnTrainer = New System.Windows.Forms.Button()
        Me.btnTransac = New System.Windows.Forms.Button()
        Me.btnEquip = New System.Windows.Forms.Button()
        Me.btnMem = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSupp = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCust
        '
        Me.btnCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCust.Location = New System.Drawing.Point(235, 12)
        Me.btnCust.Name = "btnCust"
        Me.btnCust.Size = New System.Drawing.Size(90, 40)
        Me.btnCust.TabIndex = 0
        Me.btnCust.Text = "Customer"
        Me.btnCust.UseVisualStyleBackColor = True
        '
        'btnTrainer
        '
        Me.btnTrainer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTrainer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrainer.Location = New System.Drawing.Point(336, 12)
        Me.btnTrainer.Name = "btnTrainer"
        Me.btnTrainer.Size = New System.Drawing.Size(90, 40)
        Me.btnTrainer.TabIndex = 1
        Me.btnTrainer.Text = "Trainers"
        Me.btnTrainer.UseVisualStyleBackColor = True
        '
        'btnTransac
        '
        Me.btnTransac.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransac.Location = New System.Drawing.Point(731, 13)
        Me.btnTransac.Name = "btnTransac"
        Me.btnTransac.Size = New System.Drawing.Size(90, 40)
        Me.btnTransac.TabIndex = 2
        Me.btnTransac.Text = "Transaction"
        Me.btnTransac.UseVisualStyleBackColor = True
        '
        'btnEquip
        '
        Me.btnEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEquip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEquip.Location = New System.Drawing.Point(539, 12)
        Me.btnEquip.Name = "btnEquip"
        Me.btnEquip.Size = New System.Drawing.Size(90, 40)
        Me.btnEquip.TabIndex = 3
        Me.btnEquip.Text = "Equipment"
        Me.btnEquip.UseVisualStyleBackColor = True
        '
        'btnMem
        '
        Me.btnMem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMem.Location = New System.Drawing.Point(432, 12)
        Me.btnMem.Name = "btnMem"
        Me.btnMem.Size = New System.Drawing.Size(101, 40)
        Me.btnMem.TabIndex = 5
        Me.btnMem.Text = "Membership"
        Me.btnMem.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Location = New System.Drawing.Point(12, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1117, 457)
        Me.Panel1.TabIndex = 6
        '
        'btnSupp
        '
        Me.btnSupp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupp.Location = New System.Drawing.Point(635, 13)
        Me.btnSupp.Name = "btnSupp"
        Me.btnSupp.Size = New System.Drawing.Size(90, 40)
        Me.btnSupp.TabIndex = 7
        Me.btnSupp.Text = "Supplier"
        Me.btnSupp.UseVisualStyleBackColor = True
        '
        'btnLogout
        '
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Location = New System.Drawing.Point(1040, 21)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(75, 23)
        Me.btnLogout.TabIndex = 8
        Me.btnLogout.Text = "logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'btnPrintReport
        '
        Me.btnPrintReport.BackColor = System.Drawing.Color.Transparent
        Me.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintReport.Location = New System.Drawing.Point(827, 12)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(90, 40)
        Me.btnPrintReport.TabIndex = 0
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 29)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "FitSphere"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.FitSphere.My.Resources.Resources.exercise_weights_iron_dumbbell_with_extra_plates
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1136, 528)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1136, 528)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnPrintReport)
        Me.Controls.Add(Me.btnSupp)
        Me.Controls.Add(Me.btnMem)
        Me.Controls.Add(Me.btnEquip)
        Me.Controls.Add(Me.btnTransac)
        Me.Controls.Add(Me.btnTrainer)
        Me.Controls.Add(Me.btnCust)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Name = "AdminDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminDashboard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCust As Button
    Friend WithEvents btnTrainer As Button
    Friend WithEvents btnTransac As Button
    Friend WithEvents btnEquip As Button
    Friend WithEvents btnMem As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSupp As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnPrintReport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
