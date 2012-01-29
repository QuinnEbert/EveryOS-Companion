<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.btnWebSite = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.IconBoxR = New System.Windows.Forms.PictureBox()
        Me.IconBoxL = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblLiner = New System.Windows.Forms.Label()
        CType(Me.IconBoxR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconBoxL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnWebSite
        '
        Me.btnWebSite.Location = New System.Drawing.Point(12, 192)
        Me.btnWebSite.Name = "btnWebSite"
        Me.btnWebSite.Size = New System.Drawing.Size(75, 23)
        Me.btnWebSite.TabIndex = 0
        Me.btnWebSite.Text = "Web site"
        Me.btnWebSite.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(197, 192)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'IconBoxR
        '
        Me.IconBoxR.Image = CType(resources.GetObject("IconBoxR.Image"), System.Drawing.Image)
        Me.IconBoxR.Location = New System.Drawing.Point(176, 12)
        Me.IconBoxR.Name = "IconBoxR"
        Me.IconBoxR.Size = New System.Drawing.Size(96, 96)
        Me.IconBoxR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IconBoxR.TabIndex = 2
        Me.IconBoxR.TabStop = False
        '
        'IconBoxL
        '
        Me.IconBoxL.Image = CType(resources.GetObject("IconBoxL.Image"), System.Drawing.Image)
        Me.IconBoxL.Location = New System.Drawing.Point(12, 12)
        Me.IconBoxL.Name = "IconBoxL"
        Me.IconBoxL.Size = New System.Drawing.Size(96, 96)
        Me.IconBoxL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IconBoxL.TabIndex = 3
        Me.IconBoxL.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 115)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(260, 23)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "AppTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLiner
        '
        Me.lblLiner.Location = New System.Drawing.Point(12, 138)
        Me.lblLiner.Name = "lblLiner"
        Me.lblLiner.Size = New System.Drawing.Size(260, 51)
        Me.lblLiner.TabIndex = 5
        Me.lblLiner.Text = "AppLiner"
        Me.lblLiner.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 227)
        Me.Controls.Add(Me.lblLiner)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.IconBoxL)
        Me.Controls.Add(Me.IconBoxR)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnWebSite)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        CType(Me.IconBoxR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconBoxL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnWebSite As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents IconBoxR As System.Windows.Forms.PictureBox
    Friend WithEvents IconBoxL As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblLiner As System.Windows.Forms.Label

End Class
