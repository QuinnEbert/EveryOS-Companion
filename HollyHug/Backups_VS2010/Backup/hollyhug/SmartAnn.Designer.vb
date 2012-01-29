<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmartAnn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmartAnn))
        Me.AlterPanel = New System.Windows.Forms.Panel
        Me.altLabel2 = New System.Windows.Forms.Label
        Me.altLabel3 = New System.Windows.Forms.Label
        Me.altLabel1 = New System.Windows.Forms.Label
        Me.AlterTitle = New System.Windows.Forms.Label
        Me.InfosPanel = New System.Windows.Forms.Panel
        Me.ScreenTwoBox = New System.Windows.Forms.GroupBox
        Me.s2Status = New System.Windows.Forms.Label
        Me.s2DimY = New System.Windows.Forms.Label
        Me.s2DimX = New System.Windows.Forms.Label
        Me.ScreenOneBox = New System.Windows.Forms.GroupBox
        Me.s1Status = New System.Windows.Forms.Label
        Me.s1DimY = New System.Windows.Forms.Label
        Me.s1DimX = New System.Windows.Forms.Label
        Me.InfosTitle = New System.Windows.Forms.Label
        Me.StatsPanel = New System.Windows.Forms.Panel
        Me.StatsTitle = New System.Windows.Forms.Label
        Me.AlterPanel.SuspendLayout()
        Me.InfosPanel.SuspendLayout()
        Me.ScreenTwoBox.SuspendLayout()
        Me.ScreenOneBox.SuspendLayout()
        Me.StatsPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'AlterPanel
        '
        Me.AlterPanel.BackColor = System.Drawing.Color.DarkGreen
        Me.AlterPanel.Controls.Add(Me.altLabel2)
        Me.AlterPanel.Controls.Add(Me.altLabel3)
        Me.AlterPanel.Controls.Add(Me.altLabel1)
        Me.AlterPanel.Controls.Add(Me.AlterTitle)
        Me.AlterPanel.Location = New System.Drawing.Point(12, 12)
        Me.AlterPanel.Name = "AlterPanel"
        Me.AlterPanel.Size = New System.Drawing.Size(560, 100)
        Me.AlterPanel.TabIndex = 0
        '
        'altLabel2
        '
        Me.altLabel2.BackColor = System.Drawing.Color.Yellow
        Me.altLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altLabel2.ForeColor = System.Drawing.Color.Black
        Me.altLabel2.Location = New System.Drawing.Point(5, 71)
        Me.altLabel2.Margin = New System.Windows.Forms.Padding(19, 0, 3, 0)
        Me.altLabel2.Name = "altLabel2"
        Me.altLabel2.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.altLabel2.Size = New System.Drawing.Size(260, 25)
        Me.altLabel2.TabIndex = 3
        Me.altLabel2.Text = "ALT_NAME"
        Me.altLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altLabel3
        '
        Me.altLabel3.BackColor = System.Drawing.Color.Yellow
        Me.altLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altLabel3.ForeColor = System.Drawing.Color.Black
        Me.altLabel3.Location = New System.Drawing.Point(295, 71)
        Me.altLabel3.Margin = New System.Windows.Forms.Padding(19, 0, 3, 0)
        Me.altLabel3.Name = "altLabel3"
        Me.altLabel3.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.altLabel3.Size = New System.Drawing.Size(260, 25)
        Me.altLabel3.TabIndex = 2
        Me.altLabel3.Text = "ALT_NAME"
        Me.altLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'altLabel1
        '
        Me.altLabel1.BackColor = System.Drawing.Color.Yellow
        Me.altLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altLabel1.ForeColor = System.Drawing.Color.Black
        Me.altLabel1.Location = New System.Drawing.Point(295, 37)
        Me.altLabel1.Margin = New System.Windows.Forms.Padding(19, 0, 3, 0)
        Me.altLabel1.Name = "altLabel1"
        Me.altLabel1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.altLabel1.Size = New System.Drawing.Size(260, 25)
        Me.altLabel1.TabIndex = 1
        Me.altLabel1.Text = "ALT_NAME"
        Me.altLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AlterTitle
        '
        Me.AlterTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlterTitle.ForeColor = System.Drawing.Color.White
        Me.AlterTitle.Location = New System.Drawing.Point(4, 4)
        Me.AlterTitle.Name = "AlterTitle"
        Me.AlterTitle.Size = New System.Drawing.Size(556, 96)
        Me.AlterTitle.TabIndex = 0
        Me.AlterTitle.Text = "HollyAnn's Currently-Active Intelligent System Performance Alterations:"
        '
        'InfosPanel
        '
        Me.InfosPanel.BackColor = System.Drawing.Color.DarkGreen
        Me.InfosPanel.Controls.Add(Me.ScreenTwoBox)
        Me.InfosPanel.Controls.Add(Me.ScreenOneBox)
        Me.InfosPanel.Controls.Add(Me.InfosTitle)
        Me.InfosPanel.Location = New System.Drawing.Point(12, 129)
        Me.InfosPanel.Name = "InfosPanel"
        Me.InfosPanel.Size = New System.Drawing.Size(265, 273)
        Me.InfosPanel.TabIndex = 1
        '
        'ScreenTwoBox
        '
        Me.ScreenTwoBox.Controls.Add(Me.s2Status)
        Me.ScreenTwoBox.Controls.Add(Me.s2DimY)
        Me.ScreenTwoBox.Controls.Add(Me.s2DimX)
        Me.ScreenTwoBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScreenTwoBox.ForeColor = System.Drawing.Color.White
        Me.ScreenTwoBox.Location = New System.Drawing.Point(3, 155)
        Me.ScreenTwoBox.Name = "ScreenTwoBox"
        Me.ScreenTwoBox.Size = New System.Drawing.Size(259, 100)
        Me.ScreenTwoBox.TabIndex = 3
        Me.ScreenTwoBox.TabStop = False
        Me.ScreenTwoBox.Text = "Screen TWO:"
        '
        's2Status
        '
        Me.s2Status.AutoSize = True
        Me.s2Status.Location = New System.Drawing.Point(15, 70)
        Me.s2Status.Name = "s2Status"
        Me.s2Status.Size = New System.Drawing.Size(140, 16)
        Me.s2Status.TabIndex = 3
        Me.s2Status.Text = "NO STATUS DATA"
        '
        's2DimY
        '
        Me.s2DimY.AutoSize = True
        Me.s2DimY.Location = New System.Drawing.Point(140, 34)
        Me.s2DimY.Name = "s2DimY"
        Me.s2DimY.Size = New System.Drawing.Size(86, 16)
        Me.s2DimY.TabIndex = 3
        Me.s2DimY.Text = "HIGH = nan"
        '
        's2DimX
        '
        Me.s2DimX.AutoSize = True
        Me.s2DimX.Location = New System.Drawing.Point(140, 18)
        Me.s2DimX.Name = "s2DimX"
        Me.s2DimX.Size = New System.Drawing.Size(88, 16)
        Me.s2DimX.TabIndex = 2
        Me.s2DimX.Text = "WIDE = nan"
        '
        'ScreenOneBox
        '
        Me.ScreenOneBox.Controls.Add(Me.s1Status)
        Me.ScreenOneBox.Controls.Add(Me.s1DimY)
        Me.ScreenOneBox.Controls.Add(Me.s1DimX)
        Me.ScreenOneBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScreenOneBox.ForeColor = System.Drawing.Color.White
        Me.ScreenOneBox.Location = New System.Drawing.Point(3, 49)
        Me.ScreenOneBox.Name = "ScreenOneBox"
        Me.ScreenOneBox.Size = New System.Drawing.Size(259, 100)
        Me.ScreenOneBox.TabIndex = 2
        Me.ScreenOneBox.TabStop = False
        Me.ScreenOneBox.Text = "Screen ONE:"
        '
        's1Status
        '
        Me.s1Status.AutoSize = True
        Me.s1Status.Location = New System.Drawing.Point(15, 71)
        Me.s1Status.Name = "s1Status"
        Me.s1Status.Size = New System.Drawing.Size(140, 16)
        Me.s1Status.TabIndex = 2
        Me.s1Status.Text = "NO STATUS DATA"
        '
        's1DimY
        '
        Me.s1DimY.AutoSize = True
        Me.s1DimY.Location = New System.Drawing.Point(140, 34)
        Me.s1DimY.Name = "s1DimY"
        Me.s1DimY.Size = New System.Drawing.Size(86, 16)
        Me.s1DimY.TabIndex = 1
        Me.s1DimY.Text = "HIGH = nan"
        '
        's1DimX
        '
        Me.s1DimX.AutoSize = True
        Me.s1DimX.Location = New System.Drawing.Point(140, 18)
        Me.s1DimX.Name = "s1DimX"
        Me.s1DimX.Size = New System.Drawing.Size(88, 16)
        Me.s1DimX.TabIndex = 0
        Me.s1DimX.Text = "WIDE = nan"
        '
        'InfosTitle
        '
        Me.InfosTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfosTitle.ForeColor = System.Drawing.Color.White
        Me.InfosTitle.Location = New System.Drawing.Point(4, 9)
        Me.InfosTitle.Name = "InfosTitle"
        Me.InfosTitle.Size = New System.Drawing.Size(258, 36)
        Me.InfosTitle.TabIndex = 1
        Me.InfosTitle.Text = "INFOS:"
        '
        'StatsPanel
        '
        Me.StatsPanel.BackColor = System.Drawing.Color.DarkGreen
        Me.StatsPanel.Controls.Add(Me.StatsTitle)
        Me.StatsPanel.Location = New System.Drawing.Point(307, 129)
        Me.StatsPanel.Name = "StatsPanel"
        Me.StatsPanel.Size = New System.Drawing.Size(265, 273)
        Me.StatsPanel.TabIndex = 2
        '
        'StatsTitle
        '
        Me.StatsTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatsTitle.ForeColor = System.Drawing.Color.White
        Me.StatsTitle.Location = New System.Drawing.Point(4, 9)
        Me.StatsTitle.Name = "StatsTitle"
        Me.StatsTitle.Size = New System.Drawing.Size(258, 36)
        Me.StatsTitle.TabIndex = 1
        Me.StatsTitle.Text = "STATS:"
        '
        'SmartAnn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(584, 414)
        Me.Controls.Add(Me.StatsPanel)
        Me.Controls.Add(Me.InfosPanel)
        Me.Controls.Add(Me.AlterPanel)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(594, 444)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(594, 444)
        Me.Name = "SmartAnn"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HollyAnn's Intelligence-Insight"
        Me.AlterPanel.ResumeLayout(False)
        Me.InfosPanel.ResumeLayout(False)
        Me.ScreenTwoBox.ResumeLayout(False)
        Me.ScreenTwoBox.PerformLayout()
        Me.ScreenOneBox.ResumeLayout(False)
        Me.ScreenOneBox.PerformLayout()
        Me.StatsPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AlterPanel As System.Windows.Forms.Panel
    Friend WithEvents AlterTitle As System.Windows.Forms.Label
    Friend WithEvents altLabel1 As System.Windows.Forms.Label
    Friend WithEvents InfosPanel As System.Windows.Forms.Panel
    Friend WithEvents InfosTitle As System.Windows.Forms.Label
    Friend WithEvents StatsPanel As System.Windows.Forms.Panel
    Friend WithEvents StatsTitle As System.Windows.Forms.Label
    Friend WithEvents altLabel3 As System.Windows.Forms.Label
    Friend WithEvents ScreenTwoBox As System.Windows.Forms.GroupBox
    Friend WithEvents ScreenOneBox As System.Windows.Forms.GroupBox
    Friend WithEvents altLabel2 As System.Windows.Forms.Label
    Friend WithEvents s1DimY As System.Windows.Forms.Label
    Friend WithEvents s1DimX As System.Windows.Forms.Label
    Friend WithEvents s2Status As System.Windows.Forms.Label
    Friend WithEvents s2DimY As System.Windows.Forms.Label
    Friend WithEvents s2DimX As System.Windows.Forms.Label
    Friend WithEvents s1Status As System.Windows.Forms.Label
End Class
