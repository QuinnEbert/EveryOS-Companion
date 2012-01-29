<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnnyConf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnnyConf))
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.General = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.VoiceBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SmartAPM_Work = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DoNotDisableCheckbox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SmartAPM_Idle = New System.Windows.Forms.ComboBox()
        Me.SmartAPM_Busy = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.SliderValueLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IdleTimeSlider = New System.Windows.Forms.TrackBar()
        Me.GroupBox_TheatreAudioDevice = New System.Windows.Forms.GroupBox()
        Me.txtTheaterDeviceName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Notifications = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optPowerAnnouncePercentage5 = New System.Windows.Forms.RadioButton()
        Me.optPowerAnnouncePercentage1 = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.General.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.IdleTimeSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_TheatreAudioDevice.SuspendLayout()
        Me.Notifications.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnApply.Location = New System.Drawing.Point(12, 442)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(146, 24)
        Me.btnApply.TabIndex = 0
        Me.btnApply.Text = "Apply Changes"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(343, 442)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(128, 24)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Discard Changes"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.General)
        Me.TabControl1.Controls.Add(Me.Notifications)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(459, 424)
        Me.TabControl1.TabIndex = 2
        '
        'General
        '
        Me.General.Controls.Add(Me.Label15)
        Me.General.Controls.Add(Me.PictureBox2)
        Me.General.Controls.Add(Me.Label16)
        Me.General.Controls.Add(Me.VoiceBox)
        Me.General.Controls.Add(Me.GroupBox1)
        Me.General.Controls.Add(Me.GroupBox2)
        Me.General.Controls.Add(Me.GroupBox_TheatreAudioDevice)
        Me.General.Location = New System.Drawing.Point(4, 22)
        Me.General.Name = "General"
        Me.General.Padding = New System.Windows.Forms.Padding(3)
        Me.General.Size = New System.Drawing.Size(451, 398)
        Me.General.TabIndex = 0
        Me.General.Text = "General"
        Me.General.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(314, 330)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "VOICE TALENT BY"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(17, 338)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(244, 24)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Voice Selection for Cepstral:"
        '
        'VoiceBox
        '
        Me.VoiceBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.VoiceBox.FormattingEnabled = True
        Me.VoiceBox.Location = New System.Drawing.Point(10, 366)
        Me.VoiceBox.Name = "VoiceBox"
        Me.VoiceBox.Size = New System.Drawing.Size(241, 21)
        Me.VoiceBox.TabIndex = 20
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Work)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DoNotDisableCheckbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Idle)
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Busy)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 207)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SmartPower Configuration:"
        '
        'SmartAPM_Work
        '
        Me.SmartAPM_Work.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SmartAPM_Work.DropDownHeight = 240
        Me.SmartAPM_Work.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SmartAPM_Work.DropDownWidth = 320
        Me.SmartAPM_Work.FormattingEnabled = True
        Me.SmartAPM_Work.IntegralHeight = False
        Me.SmartAPM_Work.Location = New System.Drawing.Point(108, 80)
        Me.SmartAPM_Work.Name = "SmartAPM_Work"
        Me.SmartAPM_Work.Size = New System.Drawing.Size(154, 21)
        Me.SmartAPM_Work.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "APM Work Plan:"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(10, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(264, 14)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "ADVANCED TESTING OPTION:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DoNotDisableCheckbox
        '
        Me.DoNotDisableCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DoNotDisableCheckbox.Location = New System.Drawing.Point(44, 156)
        Me.DoNotDisableCheckbox.Name = "DoNotDisableCheckbox"
        Me.DoNotDisableCheckbox.Size = New System.Drawing.Size(230, 47)
        Me.DoNotDisableCheckbox.TabIndex = 7
        Me.DoNotDisableCheckbox.Text = "Do NOT Disable SmartPower When" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manually Selecting New APM Plan"
        Me.DoNotDisableCheckbox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "APM Idle Plan:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "APM Busy Plan:"
        '
        'SmartAPM_Idle
        '
        Me.SmartAPM_Idle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SmartAPM_Idle.DropDownHeight = 240
        Me.SmartAPM_Idle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SmartAPM_Idle.DropDownWidth = 320
        Me.SmartAPM_Idle.FormattingEnabled = True
        Me.SmartAPM_Idle.IntegralHeight = False
        Me.SmartAPM_Idle.Location = New System.Drawing.Point(108, 26)
        Me.SmartAPM_Idle.Name = "SmartAPM_Idle"
        Me.SmartAPM_Idle.Size = New System.Drawing.Size(154, 21)
        Me.SmartAPM_Idle.TabIndex = 3
        '
        'SmartAPM_Busy
        '
        Me.SmartAPM_Busy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SmartAPM_Busy.DropDownHeight = 240
        Me.SmartAPM_Busy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SmartAPM_Busy.DropDownWidth = 320
        Me.SmartAPM_Busy.FormattingEnabled = True
        Me.SmartAPM_Busy.IntegralHeight = False
        Me.SmartAPM_Busy.Location = New System.Drawing.Point(108, 53)
        Me.SmartAPM_Busy.Name = "SmartAPM_Busy"
        Me.SmartAPM_Busy.Size = New System.Drawing.Size(154, 21)
        Me.SmartAPM_Busy.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.SliderValueLabel)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.IdleTimeSlider)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 300)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SmartPower IDLE Timer:"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.ForeColor = System.Drawing.Color.Magenta
        Me.Label14.Location = New System.Drawing.Point(10, 217)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "HollyHug"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(10, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 40)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "DONE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RIGHT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WITH"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(10, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Cool'n'Quiet"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.Location = New System.Drawing.Point(7, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(131, 47)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "     Please set how long to wait for PC to IDLE before SmartPower:"
        '
        'SliderValueLabel
        '
        Me.SliderValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SliderValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SliderValueLabel.Location = New System.Drawing.Point(7, 242)
        Me.SliderValueLabel.Name = "SliderValueLabel"
        Me.SliderValueLabel.Size = New System.Drawing.Size(73, 35)
        Me.SliderValueLabel.TabIndex = 15
        Me.SliderValueLabel.Text = "NAN"
        Me.SliderValueLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 277)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Minutes"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(86, 230)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Tag = ""
        Me.Label8.Text = "2"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(86, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Tag = "3"
        Me.Label7.Text = "3"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(86, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "4"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "5"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "1"
        '
        'IdleTimeSlider
        '
        Me.IdleTimeSlider.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.IdleTimeSlider.BackColor = System.Drawing.SystemColors.Window
        Me.IdleTimeSlider.LargeChange = 1
        Me.IdleTimeSlider.Location = New System.Drawing.Point(93, 70)
        Me.IdleTimeSlider.Maximum = 5
        Me.IdleTimeSlider.Minimum = 1
        Me.IdleTimeSlider.Name = "IdleTimeSlider"
        Me.IdleTimeSlider.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.IdleTimeSlider.Size = New System.Drawing.Size(45, 230)
        Me.IdleTimeSlider.TabIndex = 8
        Me.IdleTimeSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.IdleTimeSlider.Value = 1
        '
        'GroupBox_TheatreAudioDevice
        '
        Me.GroupBox_TheatreAudioDevice.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox_TheatreAudioDevice.Controls.Add(Me.txtTheaterDeviceName)
        Me.GroupBox_TheatreAudioDevice.Controls.Add(Me.Label1)
        Me.GroupBox_TheatreAudioDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_TheatreAudioDevice.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox_TheatreAudioDevice.Name = "GroupBox_TheatreAudioDevice"
        Me.GroupBox_TheatreAudioDevice.Size = New System.Drawing.Size(280, 110)
        Me.GroupBox_TheatreAudioDevice.TabIndex = 14
        Me.GroupBox_TheatreAudioDevice.TabStop = False
        Me.GroupBox_TheatreAudioDevice.Text = "Theatre Audio Device"
        '
        'txtTheaterDeviceName
        '
        Me.txtTheaterDeviceName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtTheaterDeviceName.AutoEllipsis = True
        Me.txtTheaterDeviceName.ForeColor = System.Drawing.Color.Green
        Me.txtTheaterDeviceName.Location = New System.Drawing.Point(12, 84)
        Me.txtTheaterDeviceName.Name = "txtTheaterDeviceName"
        Me.txtTheaterDeviceName.Size = New System.Drawing.Size(262, 13)
        Me.txtTheaterDeviceName.TabIndex = 1
        Me.txtTheaterDeviceName.Text = "DEVICE NOT FOUND"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 53)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "    On startup, I will try and use some basic ""smart guessing"" to find a device t" & _
            "hat's a suitable ""Theatre"" audio output device.  On your system, I think that de" & _
            "vice is:"
        '
        'Notifications
        '
        Me.Notifications.Controls.Add(Me.GroupBox4)
        Me.Notifications.Controls.Add(Me.GroupBox3)
        Me.Notifications.Location = New System.Drawing.Point(4, 22)
        Me.Notifications.Name = "Notifications"
        Me.Notifications.Padding = New System.Windows.Forms.Padding(3)
        Me.Notifications.Size = New System.Drawing.Size(451, 398)
        Me.Notifications.TabIndex = 1
        Me.Notifications.Text = "Notifications"
        Me.Notifications.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LinkLabel1)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.PictureBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 191)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(438, 201)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Growl Services"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Controls.Add(Me.optPowerAnnouncePercentage5)
        Me.GroupBox3.Controls.Add(Me.optPowerAnnouncePercentage1)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(439, 178)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Power Status"
        '
        'optPowerAnnouncePercentage5
        '
        Me.optPowerAnnouncePercentage5.AutoSize = True
        Me.optPowerAnnouncePercentage5.Location = New System.Drawing.Point(22, 151)
        Me.optPowerAnnouncePercentage5.Name = "optPowerAnnouncePercentage5"
        Me.optPowerAnnouncePercentage5.Size = New System.Drawing.Size(153, 17)
        Me.optPowerAnnouncePercentage5.TabIndex = 2
        Me.optPowerAnnouncePercentage5.TabStop = True
        Me.optPowerAnnouncePercentage5.Text = "Announce Every 5 Percent"
        Me.optPowerAnnouncePercentage5.UseVisualStyleBackColor = True
        '
        'optPowerAnnouncePercentage1
        '
        Me.optPowerAnnouncePercentage1.AutoSize = True
        Me.optPowerAnnouncePercentage1.Location = New System.Drawing.Point(22, 127)
        Me.optPowerAnnouncePercentage1.Name = "optPowerAnnouncePercentage1"
        Me.optPowerAnnouncePercentage1.Size = New System.Drawing.Size(153, 17)
        Me.optPowerAnnouncePercentage1.TabIndex = 1
        Me.optPowerAnnouncePercentage1.TabStop = True
        Me.optPowerAnnouncePercentage1.Text = "Announce Every 1 Percent"
        Me.optPowerAnnouncePercentage1.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoEllipsis = True
        Me.Label18.Location = New System.Drawing.Point(7, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(426, 104)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = resources.GetString("Label18.Text")
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(267, 347)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(163, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = "AMD Athlon X2 (64-bit)"
        Me.PictureBox1.AccessibleName = "CPU Logo"
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = My.Resources.Resources.AMD64x2_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(10, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 88)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = My.Resources.Resources.HollyGrowl
        Me.PictureBox5.Location = New System.Drawing.Point(215, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(217, 176)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 0
        Me.PictureBox5.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = My.Resources.Resources.InstPict
        Me.PictureBox3.InitialImage = My.Resources.Resources.InstPict
        Me.PictureBox3.Location = New System.Drawing.Point(382, 43)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = My.Resources.Resources.powercpl_506
        Me.PictureBox4.InitialImage = My.Resources.Resources.InstPict
        Me.PictureBox4.Location = New System.Drawing.Point(357, 57)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 4
        Me.PictureBox4.TabStop = False
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(7, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(202, 83)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "HollyHug Supports" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Prowl" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Growl on Windows)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Notifications"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 102)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(203, 93)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Don't Have Growl" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For Windows?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click Here to Get It!"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnnyConf
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(482, 478)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AnnyConf"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "HollyAnn Configuration Dialog"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.General.ResumeLayout(False)
        Me.General.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.IdleTimeSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_TheatreAudioDevice.ResumeLayout(False)
        Me.Notifications.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents General As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents VoiceBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SmartAPM_Work As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DoNotDisableCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SmartAPM_Idle As System.Windows.Forms.ComboBox
    Friend WithEvents SmartAPM_Busy As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SliderValueLabel As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents IdleTimeSlider As System.Windows.Forms.TrackBar
    Friend WithEvents Notifications As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents optPowerAnnouncePercentage5 As System.Windows.Forms.RadioButton
    Friend WithEvents optPowerAnnouncePercentage1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox_TheatreAudioDevice As System.Windows.Forms.GroupBox
    Friend WithEvents txtTheaterDeviceName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
