<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PowerAnn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PowerAnn))
        Me.Splitter = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.HollyAnn = New System.Windows.Forms.PictureBox
        Me.MainMenu = New System.Windows.Forms.MenuStrip
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OurPower = New System.Windows.Forms.Label
        Me.TickTock = New System.Windows.Forms.Timer(Me.components)
        Me.Splitter.Panel1.SuspendLayout()
        Me.Splitter.Panel2.SuspendLayout()
        Me.Splitter.SuspendLayout()
        CType(Me.HollyAnn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Splitter
        '
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Splitter.IsSplitterFixed = True
        Me.Splitter.Location = New System.Drawing.Point(0, 0)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Splitter.Panel1
        '
        Me.Splitter.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Splitter.Panel1.Controls.Add(Me.Label1)
        Me.Splitter.Panel1.Controls.Add(Me.HollyAnn)
        Me.Splitter.Panel1.Controls.Add(Me.MainMenu)
        '
        'Splitter.Panel2
        '
        Me.Splitter.Panel2.Controls.Add(Me.OurPower)
        Me.Splitter.Size = New System.Drawing.Size(224, 271)
        Me.Splitter.SplitterDistance = 84
        Me.Splitter.SplitterWidth = 1
        Me.Splitter.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(59, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 53)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SmartPower"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'HollyAnn
        '
        Me.HollyAnn.Image = Global.HollyHug.My.Resources.Resources.InstPict
        Me.HollyAnn.Location = New System.Drawing.Point(3, 27)
        Me.HollyAnn.Name = "HollyAnn"
        Me.HollyAnn.Size = New System.Drawing.Size(53, 53)
        Me.HollyAnn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.HollyAnn.TabIndex = 1
        Me.HollyAnn.TabStop = False
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WindowToolStripMenuItem})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(224, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MenuStrip1"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'OurPower
        '
        Me.OurPower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OurPower.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OurPower.ForeColor = System.Drawing.Color.White
        Me.OurPower.Location = New System.Drawing.Point(0, 0)
        Me.OurPower.Name = "OurPower"
        Me.OurPower.Size = New System.Drawing.Size(224, 186)
        Me.OurPower.TabIndex = 0
        Me.OurPower.Text = "NAN%"
        Me.OurPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TickTock
        '
        Me.TickTock.Interval = 1000
        '
        'PowerAnn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.ForestGreen
        Me.ClientSize = New System.Drawing.Size(224, 271)
        Me.Controls.Add(Me.Splitter)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MainMenu
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(240, 320)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(240, 320)
        Me.Name = "PowerAnn"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Power Status"
        Me.Splitter.Panel1.ResumeLayout(False)
        Me.Splitter.Panel1.PerformLayout()
        Me.Splitter.Panel2.ResumeLayout(False)
        Me.Splitter.ResumeLayout(False)
        CType(Me.HollyAnn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Splitter As System.Windows.Forms.SplitContainer
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TickTock As System.Windows.Forms.Timer
    Friend WithEvents HollyAnn As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OurPower As System.Windows.Forms.Label
End Class
