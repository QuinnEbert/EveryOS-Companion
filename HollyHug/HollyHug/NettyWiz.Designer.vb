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
        Me.FormNameLabel = New System.Windows.Forms.Label
        Me.FormStepLabel = New System.Windows.Forms.Label
        Me.Label_PushNext = New System.Windows.Forms.Label
        Me.btn_Prev = New System.Windows.Forms.Button
        Me.btn_Next = New System.Windows.Forms.Button
        Me.FormTextLabel = New System.Windows.Forms.Label
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
        Me.FormLayoutContainer.Panel1.Controls.Add(Me.FormNameLabel)
        Me.FormLayoutContainer.Panel1.Controls.Add(Me.FormStepLabel)
        Me.FormLayoutContainer.Panel1MinSize = 0
        '
        'FormLayoutContainer.Panel2
        '
        Me.FormLayoutContainer.Panel2.Controls.Add(Me.Label_PushNext)
        Me.FormLayoutContainer.Panel2.Controls.Add(Me.btn_Prev)
        Me.FormLayoutContainer.Panel2.Controls.Add(Me.btn_Next)
        Me.FormLayoutContainer.Panel2.Controls.Add(Me.FormTextLabel)
        Me.FormLayoutContainer.Panel2.ForeColor = System.Drawing.Color.Black
        Me.FormLayoutContainer.Panel2MinSize = 0
        Me.FormLayoutContainer.Size = New System.Drawing.Size(294, 374)
        Me.FormLayoutContainer.SplitterDistance = 64
        Me.FormLayoutContainer.SplitterWidth = 1
        Me.FormLayoutContainer.TabIndex = 0
        '
        'FormNameLabel
        '
        Me.FormNameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FormNameLabel.AutoSize = True
        Me.FormNameLabel.BackColor = System.Drawing.Color.Transparent
        Me.FormNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormNameLabel.ForeColor = System.Drawing.Color.Black
        Me.FormNameLabel.Location = New System.Drawing.Point(1, 1)
        Me.FormNameLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.FormNameLabel.Name = "FormNameLabel"
        Me.FormNameLabel.Padding = New System.Windows.Forms.Padding(12, 12, 0, 0)
        Me.FormNameLabel.Size = New System.Drawing.Size(63, 27)
        Me.FormNameLabel.TabIndex = 3
        Me.FormNameLabel.Text = "Label1"
        Me.FormNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
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
        'Label_PushNext
        '
        Me.Label_PushNext.Location = New System.Drawing.Point(16, 239)
        Me.Label_PushNext.Name = "Label_PushNext"
        Me.Label_PushNext.Size = New System.Drawing.Size(265, 32)
        Me.Label_PushNext.TabIndex = 3
        Me.Label_PushNext.Text = "Label1"
        '
        'btn_Prev
        '
        Me.btn_Prev.Location = New System.Drawing.Point(125, 274)
        Me.btn_Prev.Name = "btn_Prev"
        Me.btn_Prev.Size = New System.Drawing.Size(75, 23)
        Me.btn_Prev.TabIndex = 2
        Me.btn_Prev.Text = " << Back"
        Me.btn_Prev.UseVisualStyleBackColor = True
        '
        'btn_Next
        '
        Me.btn_Next.Location = New System.Drawing.Point(206, 274)
        Me.btn_Next.Name = "btn_Next"
        Me.btn_Next.Size = New System.Drawing.Size(75, 23)
        Me.btn_Next.TabIndex = 1
        Me.btn_Next.Text = "Next >> "
        Me.btn_Next.UseVisualStyleBackColor = True
        '
        'FormTextLabel
        '
        Me.FormTextLabel.Location = New System.Drawing.Point(13, 14)
        Me.FormTextLabel.Name = "FormTextLabel"
        Me.FormTextLabel.Size = New System.Drawing.Size(269, 170)
        Me.FormTextLabel.TabIndex = 0
        Me.FormTextLabel.Text = "Label1"
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
    Friend WithEvents FormNameLabel As System.Windows.Forms.Label
    Friend WithEvents FormTextLabel As System.Windows.Forms.Label
    Friend WithEvents btn_Prev As System.Windows.Forms.Button
    Friend WithEvents btn_Next As System.Windows.Forms.Button
    Friend WithEvents Label_PushNext As System.Windows.Forms.Label
End Class
