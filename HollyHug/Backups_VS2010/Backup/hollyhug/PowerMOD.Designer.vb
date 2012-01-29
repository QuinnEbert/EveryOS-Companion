<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerMOD
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
        Me.components = New System.ComponentModel.Container
        Me.ProgModsGroupBox = New System.Windows.Forms.GroupBox
        Me.StatusLabel_MediaCenter = New System.Windows.Forms.Label
        Me.RedrawUI = New System.Windows.Forms.Timer(Me.components)
        Me.WindowInfoLabel = New System.Windows.Forms.Label
        Me.StatusLabel_iTunes = New System.Windows.Forms.Label
        Me.ModeModsGroupBox = New System.Windows.Forms.GroupBox
        Me.StatusLabel_BedTime = New System.Windows.Forms.Label
        Me.ProgModsGroupBox.SuspendLayout()
        Me.ModeModsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgModsGroupBox
        '
        Me.ProgModsGroupBox.Controls.Add(Me.StatusLabel_iTunes)
        Me.ProgModsGroupBox.Controls.Add(Me.StatusLabel_MediaCenter)
        Me.ProgModsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgModsGroupBox.Location = New System.Drawing.Point(13, 13)
        Me.ProgModsGroupBox.Name = "ProgModsGroupBox"
        Me.ProgModsGroupBox.Size = New System.Drawing.Size(279, 63)
        Me.ProgModsGroupBox.TabIndex = 0
        Me.ProgModsGroupBox.TabStop = False
        Me.ProgModsGroupBox.Text = "Program-Driven Mods:"
        '
        'StatusLabel_MediaCenter
        '
        Me.StatusLabel_MediaCenter.Location = New System.Drawing.Point(7, 20)
        Me.StatusLabel_MediaCenter.Name = "StatusLabel_MediaCenter"
        Me.StatusLabel_MediaCenter.Size = New System.Drawing.Size(266, 13)
        Me.StatusLabel_MediaCenter.TabIndex = 0
        Me.StatusLabel_MediaCenter.Text = "Label2"
        '
        'RedrawUI
        '
        Me.RedrawUI.Interval = 5000
        '
        'WindowInfoLabel
        '
        Me.WindowInfoLabel.AutoEllipsis = True
        Me.WindowInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowInfoLabel.Location = New System.Drawing.Point(13, 326)
        Me.WindowInfoLabel.Name = "WindowInfoLabel"
        Me.WindowInfoLabel.Size = New System.Drawing.Size(279, 29)
        Me.WindowInfoLabel.TabIndex = 1
        Me.WindowInfoLabel.Text = "This window will be automatically refreshed every FIVE seconds..."
        '
        'StatusLabel_iTunes
        '
        Me.StatusLabel_iTunes.Location = New System.Drawing.Point(7, 41)
        Me.StatusLabel_iTunes.Name = "StatusLabel_iTunes"
        Me.StatusLabel_iTunes.Size = New System.Drawing.Size(266, 13)
        Me.StatusLabel_iTunes.TabIndex = 1
        Me.StatusLabel_iTunes.Text = "Label2"
        '
        'ModeModsGroupBox
        '
        Me.ModeModsGroupBox.Controls.Add(Me.StatusLabel_BedTime)
        Me.ModeModsGroupBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeModsGroupBox.Location = New System.Drawing.Point(16, 274)
        Me.ModeModsGroupBox.Name = "ModeModsGroupBox"
        Me.ModeModsGroupBox.Size = New System.Drawing.Size(270, 49)
        Me.ModeModsGroupBox.TabIndex = 2
        Me.ModeModsGroupBox.TabStop = False
        Me.ModeModsGroupBox.Text = "Human-Driven Mods:"
        '
        'StatusLabel_BedTime
        '
        Me.StatusLabel_BedTime.Location = New System.Drawing.Point(7, 21)
        Me.StatusLabel_BedTime.Name = "StatusLabel_BedTime"
        Me.StatusLabel_BedTime.Size = New System.Drawing.Size(257, 13)
        Me.StatusLabel_BedTime.TabIndex = 1
        Me.StatusLabel_BedTime.Text = "Label2"
        '
        'PowerMOD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 364)
        Me.Controls.Add(Me.ModeModsGroupBox)
        Me.Controls.Add(Me.WindowInfoLabel)
        Me.Controls.Add(Me.ProgModsGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PowerMOD"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "HollyAnn - APM Mod Statistics"
        Me.ProgModsGroupBox.ResumeLayout(False)
        Me.ModeModsGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgModsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents RedrawUI As System.Windows.Forms.Timer
    Friend WithEvents StatusLabel_MediaCenter As System.Windows.Forms.Label
    Friend WithEvents WindowInfoLabel As System.Windows.Forms.Label
    Friend WithEvents StatusLabel_iTunes As System.Windows.Forms.Label
    Friend WithEvents ModeModsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents StatusLabel_BedTime As System.Windows.Forms.Label
End Class
