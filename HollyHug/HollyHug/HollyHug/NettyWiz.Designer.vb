<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NettyWiz
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
        Me.FormLayoutContainer = New System.Windows.Forms.SplitContainer
        Me.FormTextLabel = New System.Windows.Forms.Label
        Me.FormStepLabel = New System.Windows.Forms.Label
        Me.Inter_InfoLabel = New System.Windows.Forms.Label
        Me.FormLayoutContainer.Panel1.SuspendLayout()
        Me.FormLayoutContainer.Panel2.SuspendLayout()
        Me.FormLayoutContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormLayoutContainer
        '
        Me.FormLayoutContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormLayoutContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.FormLayoutContainer.ForeColor = System.Drawing.SystemColors.Control
        Me.FormLayoutContainer.IsSplitterFixed = True
        Me.FormLayoutContainer.Location = New System.Drawing.Point(0, 0)
        Me.FormLayoutContainer.Name = "FormLayoutContainer"
        Me.FormLayoutContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'FormLayoutContainer.Panel1
        '
        Me.FormLayoutContainer.Panel1.BackColor = System.Drawing.Color.White
        Me.FormLayoutContainer.Panel1.Controls.Add(Me.FormTextLabel)
        Me.FormLayoutContainer.Panel1.Controls.Add(Me.FormStepLabel)
        Me.FormLayoutContainer.Panel1MinSize = 0
        '
        'FormLayoutContainer.Panel2
        '
        Me.FormLayoutContainer.Panel2.Controls.Add(Me.Inter_InfoLabel)
        Me.FormLayoutContainer.Panel2.ForeColor = System.Drawing.Color.Black
        Me.FormLayoutContainer.Panel2MinSize = 0
        Me.FormLayoutContainer.Size = New System.Drawing.Size(294, 374)
        Me.FormLayoutContainer.SplitterDistance = 64
        Me.FormLayoutContainer.SplitterWidth = 1
        Me.FormLayoutContainer.TabIndex = 0
        '
        'FormTextLabel
        '
        Me.FormTextLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FormTextLabel.AutoSize = True
        Me.FormTextLabel.BackColor = System.Drawing.Color.Transparent
        Me.FormTextLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormTextLabel.ForeColor = System.Drawing.Color.Black
        Me.FormTextLabel.Location = New System.Drawing.Point(1, 1)
        Me.FormTextLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.FormTextLabel.Name = "FormTextLabel"
        Me.FormTextLabel.Padding = New System.Windows.Forms.Padding(12, 12, 0, 0)
        Me.FormTextLabel.Size = New System.Drawing.Size(63, 27)
        Me.FormTextLabel.TabIndex = 3
        Me.FormTextLabel.Text = "Label1"
        Me.FormTextLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'FormStepLabel
        '
        Me.FormStepLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FormStepLabel.AutoSize = True
        Me.FormStepLabel.BackColor = System.Drawing.Color.Transparent
        Me.FormStepLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormStepLabel.ForeColor = System.Drawing.Color.Black
        Me.FormStepLabel.Location = New System.Drawing.Point(1, 35)
        Me.FormStepLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.FormStepLabel.Name = "FormStepLabel"
        Me.FormStepLabel.Padding = New System.Windows.Forms.Padding(12, 0, 0, 12)
        Me.FormStepLabel.Size = New System.Drawing.Size(57, 27)
        Me.FormStepLabel.TabIndex = 2
        Me.FormStepLabel.Text = "Label1"
        Me.FormStepLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Inter_InfoLabel
        '
        Me.Inter_InfoLabel.Location = New System.Drawing.Point(13, 14)
        Me.Inter_InfoLabel.Name = "Inter_InfoLabel"
        Me.Inter_InfoLabel.Size = New System.Drawing.Size(269, 201)
        Me.Inter_InfoLabel.TabIndex = 0
        Me.Inter_InfoLabel.Text = "Label1"
        '
        'NettyWiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 374)
        Me.Controls.Add(Me.FormLayoutContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NettyWiz"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HollyNet Setup Wizard"
        Me.FormLayoutContainer.Panel1.ResumeLayout(False)
        Me.FormLayoutContainer.Panel1.PerformLayout()
        Me.FormLayoutContainer.Panel2.ResumeLayout(False)
        Me.FormLayoutContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormLayoutContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents FormStepLabel As System.Windows.Forms.Label
    Friend WithEvents FormTextLabel As System.Windows.Forms.Label
    Friend WithEvents Inter_InfoLabel As System.Windows.Forms.Label
End Class
