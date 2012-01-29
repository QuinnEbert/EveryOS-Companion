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
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox_TheatreAudioDevice = New System.Windows.Forms.GroupBox
        Me.txtTheaterDeviceName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SmartAPM_Idle = New System.Windows.Forms.ComboBox
        Me.SmartAPM_Busy = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SmartAPM_Work = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.DoNotDisableCheckbox = New System.Windows.Forms.CheckBox
        Me.IdleTimeSlider = New System.Windows.Forms.TrackBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.SliderValueLabel = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.VoiceBox = New System.Windows.Forms.ComboBox
        Me.GroupBox_TheatreAudioDevice.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.IdleTimeSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnApply
        '
        Me.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnApply.Location = New System.Drawing.Point(12, 409)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(146, 24)
        Me.btnApply.TabIndex = 0
        Me.btnApply.Text = "Apply Changes"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(304, 409)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(128, 24)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Discard Changes"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox_TheatreAudioDevice
        '
        Me.GroupBox_TheatreAudioDevice.Controls.Add(Me.txtTheaterDeviceName)
        Me.GroupBox_TheatreAudioDevice.Controls.Add(Me.Label1)
        Me.GroupBox_TheatreAudioDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_TheatreAudioDevice.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox_TheatreAudioDevice.Name = "GroupBox_TheatreAudioDevice"
        Me.GroupBox_TheatreAudioDevice.Size = New System.Drawing.Size(280, 110)
        Me.GroupBox_TheatreAudioDevice.TabIndex = 2
        Me.GroupBox_TheatreAudioDevice.TabStop = False
        Me.GroupBox_TheatreAudioDevice.Text = "Theatre Audio Device"
        '
        'txtTheaterDeviceName
        '
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 53)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "    On startup, I will try and use some basic ""smart guessing"" to find a device t" & _
            "hat's a suitable ""Theatre"" audio output device.  On your system, I think that de" & _
            "vice is:"
        '
        'SmartAPM_Idle
        '
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "APM Idle Plan:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "APM Busy Plan:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Work)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DoNotDisableCheckbox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Idle)
        Me.GroupBox1.Controls.Add(Me.SmartAPM_Busy)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 207)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SmartPower Configuration:"
        '
        'SmartAPM_Work
        '
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
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(19, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "APM Work Plan:"
        '
        'Label10
        '
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
        Me.DoNotDisableCheckbox.Location = New System.Drawing.Point(44, 156)
        Me.DoNotDisableCheckbox.Name = "DoNotDisableCheckbox"
        Me.DoNotDisableCheckbox.Size = New System.Drawing.Size(230, 47)
        Me.DoNotDisableCheckbox.TabIndex = 7
        Me.DoNotDisableCheckbox.Text = "Do NOT Disable SmartPower When" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Manually Selecting New APM Plan"
        Me.DoNotDisableCheckbox.UseVisualStyleBackColor = True
        '
        'IdleTimeSlider
        '
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
        'GroupBox2
        '
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
        Me.GroupBox2.Location = New System.Drawing.Point(298, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(144, 300)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SmartPower IDLE Timer:"
        '
        'Label14
        '
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
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(10, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Cool'n'Quiet"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.AccessibleDescription = "AMD Athlon X2 (64-bit)"
        Me.PictureBox1.AccessibleName = "CPU Logo"
        Me.PictureBox1.Image = Global.HollyHug.My.Resources.Resources.AMD64x2_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(10, 70)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 88)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(7, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(131, 47)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "     Please set how long to wait for PC to IDLE before SmartPower:"
        '
        'SliderValueLabel
        '
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
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(86, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 279)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(269, 347)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(163, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(316, 330)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "VOICE TALENT BY"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(19, 338)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(244, 24)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Voice Selection for Cepstral:"
        '
        'VoiceBox
        '
        Me.VoiceBox.FormattingEnabled = True
        Me.VoiceBox.Location = New System.Drawing.Point(22, 365)
        Me.VoiceBox.Name = "VoiceBox"
        Me.VoiceBox.Size = New System.Drawing.Size(241, 21)
        Me.VoiceBox.TabIndex = 13
        '
        'AnnyConf
        '
        Me.AcceptButton = Me.btnApply
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(444, 445)
        Me.Controls.Add(Me.VoiceBox)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox_TheatreAudioDevice)
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
        Me.GroupBox_TheatreAudioDevice.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.IdleTimeSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox_TheatreAudioDevice As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTheaterDeviceName As System.Windows.Forms.Label
    Friend WithEvents SmartAPM_Idle As System.Windows.Forms.ComboBox
    Friend WithEvents SmartAPM_Busy As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DoNotDisableCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents IdleTimeSlider As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SliderValueLabel As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents VoiceBox As System.Windows.Forms.ComboBox
    Friend WithEvents SmartAPM_Work As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
