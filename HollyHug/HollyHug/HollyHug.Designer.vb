<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HollyHug
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HollyHug))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TrayDive = New System.Windows.Forms.Timer(Me.components)
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPowerLevelInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.UseSmartPowerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.RehashAPMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigAPMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DisProfs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PowerStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConfigAudioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseCTMixerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UseDeltaDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.HollyNetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MyDiaryLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ByebyeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadAt = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Mixer_CT = New System.Windows.Forms.Timer(Me.components)
        Me.SvcCheck = New System.Windows.Forms.Timer(Me.components)
        Me.BootDone = New System.Windows.Forms.Timer(Me.components)
        Me.HumanoidalActivityChecker = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.KeyCheck = New System.Windows.Forms.Timer(Me.components)
        Me.SpeedCheck = New System.Windows.Forms.Timer(Me.components)
        Me.PowerCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Info1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Info2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Info3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BattPoll = New System.Windows.Forms.Timer(Me.components)
        Me.TrayMenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 27)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "HollyHug"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 170)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(260, 33)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "My Answer to Everything Crappy" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "On the HP m9100z"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(73, 207)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(138, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "http://www.quinnebert.net/"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 229)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(177, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Hey!  Get back down in that tray!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrayDive
        '
        Me.TrayDive.Interval = 1000
        '
        'TrayIcon
        '
        Me.TrayIcon.BalloonTipTitle = "HollyAnn Says:"
        Me.TrayIcon.ContextMenuStrip = Me.TrayMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "HollyAnn"
        Me.TrayIcon.Visible = True
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.mnuPowerLevelInformation, Me.Info1ToolStripMenuItem, Me.Info2ToolStripMenuItem, Me.Info3ToolStripMenuItem, Me.ToolStripMenuItem11, Me.UseSmartPowerToolStripMenuItem, Me.ToolStripMenuItem7, Me.RehashAPMToolStripMenuItem, Me.ConfigAPMToolStripMenuItem, Me.ToolStripMenuItem3, Me.DisProfs, Me.ToolStripMenuItem2, Me.PowerStatusToolStripMenuItem, Me.ToolStripMenuItem6, Me.ConfigAudioToolStripMenuItem, Me.UseCTMixerToolStripMenuItem, Me.UseDeltaDAToolStripMenuItem, Me.ToolStripMenuItem8, Me.HollyNetToolStripMenuItem, Me.ToolStripMenuItem5, Me.MyDiaryLogToolStripMenuItem, Me.ToolStripMenuItem9, Me.AboutToolStripMenuItem, Me.SetupToolStripMenuItem, Me.ToolStripMenuItem10, Me.ByebyeToolStripMenuItem})
        Me.TrayMenu.Name = "TMenuEnd"
        Me.TrayMenu.Size = New System.Drawing.Size(226, 438)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(222, 6)
        '
        'mnuPowerLevelInformation
        '
        Me.mnuPowerLevelInformation.Enabled = False
        Me.mnuPowerLevelInformation.Name = "mnuPowerLevelInformation"
        Me.mnuPowerLevelInformation.Size = New System.Drawing.Size(225, 22)
        Me.mnuPowerLevelInformation.Text = "(no power level information)"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(222, 6)
        '
        'UseSmartPowerToolStripMenuItem
        '
        Me.UseSmartPowerToolStripMenuItem.Name = "UseSmartPowerToolStripMenuItem"
        Me.UseSmartPowerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.UseSmartPowerToolStripMenuItem.Text = "Use SmartPower"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(222, 6)
        '
        'RehashAPMToolStripMenuItem
        '
        Me.RehashAPMToolStripMenuItem.Name = "RehashAPMToolStripMenuItem"
        Me.RehashAPMToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.RehashAPMToolStripMenuItem.Text = "Reload APM..."
        '
        'ConfigAPMToolStripMenuItem
        '
        Me.ConfigAPMToolStripMenuItem.Name = "ConfigAPMToolStripMenuItem"
        Me.ConfigAPMToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ConfigAPMToolStripMenuItem.Text = "Setup APM..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(222, 6)
        '
        'DisProfs
        '
        Me.DisProfs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReloadToolStripMenuItem, Me.ToolStripMenuItem4})
        Me.DisProfs.Name = "DisProfs"
        Me.DisProfs.Size = New System.Drawing.Size(225, 22)
        Me.DisProfs.Text = "NV Configs"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(107, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(222, 6)
        '
        'PowerStatusToolStripMenuItem
        '
        Me.PowerStatusToolStripMenuItem.Name = "PowerStatusToolStripMenuItem"
        Me.PowerStatusToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.PowerStatusToolStripMenuItem.Text = "Power Status"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(222, 6)
        '
        'ConfigAudioToolStripMenuItem
        '
        Me.ConfigAudioToolStripMenuItem.Name = "ConfigAudioToolStripMenuItem"
        Me.ConfigAudioToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ConfigAudioToolStripMenuItem.Text = "Setup Audio..."
        '
        'UseCTMixerToolStripMenuItem
        '
        Me.UseCTMixerToolStripMenuItem.Name = "UseCTMixerToolStripMenuItem"
        Me.UseCTMixerToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.UseCTMixerToolStripMenuItem.Text = "Use CT Mixer"
        '
        'UseDeltaDAToolStripMenuItem
        '
        Me.UseDeltaDAToolStripMenuItem.Name = "UseDeltaDAToolStripMenuItem"
        Me.UseDeltaDAToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.UseDeltaDAToolStripMenuItem.Text = "Use Delta SP-DIF"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(222, 6)
        '
        'HollyNetToolStripMenuItem
        '
        Me.HollyNetToolStripMenuItem.Name = "HollyNetToolStripMenuItem"
        Me.HollyNetToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.HollyNetToolStripMenuItem.Text = "HollyNet"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(222, 6)
        '
        'MyDiaryLogToolStripMenuItem
        '
        Me.MyDiaryLogToolStripMenuItem.Name = "MyDiaryLogToolStripMenuItem"
        Me.MyDiaryLogToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.MyDiaryLogToolStripMenuItem.Text = "App Logs"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(222, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.AboutToolStripMenuItem.Text = "About Me"
        '
        'SetupToolStripMenuItem
        '
        Me.SetupToolStripMenuItem.Name = "SetupToolStripMenuItem"
        Me.SetupToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.SetupToolStripMenuItem.Text = "Settings"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(222, 6)
        '
        'ByebyeToolStripMenuItem
        '
        Me.ByebyeToolStripMenuItem.Name = "ByebyeToolStripMenuItem"
        Me.ByebyeToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.ByebyeToolStripMenuItem.Text = "Exit"
        '
        'ReloadAt
        '
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(252, 229)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "I"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 229)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "C"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Mixer_CT
        '
        Me.Mixer_CT.Interval = 500
        '
        'SvcCheck
        '
        Me.SvcCheck.Interval = 10000
        '
        'BootDone
        '
        Me.BootDone.Interval = 300000
        '
        'HumanoidalActivityChecker
        '
        Me.HumanoidalActivityChecker.Interval = 15000
        '
        'PictureBox1
        '
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(78, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'KeyCheck
        '
        Me.KeyCheck.Enabled = True
        '
        'SpeedCheck
        '
        Me.SpeedCheck.Enabled = True
        Me.SpeedCheck.Interval = 60000
        '
        'PowerCheck
        '
        Me.PowerCheck.Interval = 1000
        '
        'Info1ToolStripMenuItem
        '
        Me.Info1ToolStripMenuItem.Name = "Info1ToolStripMenuItem"
        Me.Info1ToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.Info1ToolStripMenuItem.Tag = "pwrInfoA"
        Me.Info1ToolStripMenuItem.Text = "info 1"
        '
        'Info2ToolStripMenuItem
        '
        Me.Info2ToolStripMenuItem.Name = "Info2ToolStripMenuItem"
        Me.Info2ToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.Info2ToolStripMenuItem.Tag = "pwrInfoB"
        Me.Info2ToolStripMenuItem.Text = "info 2"
        '
        'Info3ToolStripMenuItem
        '
        Me.Info3ToolStripMenuItem.Name = "Info3ToolStripMenuItem"
        Me.Info3ToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.Info3ToolStripMenuItem.Tag = "pwrInfoC"
        Me.Info3ToolStripMenuItem.Text = "info 3"
        '
        'BattPoll
        '
        Me.BattPoll.Interval = 60000
        '
        'HollyHug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HollyHug"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "HollyHug"
        Me.TopMost = True
        Me.TrayMenu.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TrayDive As System.Windows.Forms.Timer
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents RehashAPMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ByebyeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReloadAt As System.Windows.Forms.Timer
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigAPMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigAudioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UseCTMixerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Mixer_CT As System.Windows.Forms.Timer
    Friend WithEvents SvcCheck As System.Windows.Forms.Timer
    Friend WithEvents BootDone As System.Windows.Forms.Timer
    Friend WithEvents MyDiaryLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HumanoidalActivityChecker As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UseSmartPowerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeyCheck As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpeedCheck As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DisProfs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PowerStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PowerCheck As System.Windows.Forms.Timer
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HollyNetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPowerLevelInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UseDeltaDAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Info1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Info2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Info3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BattPoll As System.Windows.Forms.Timer

End Class
