<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HollyApt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HollyApt))
        Me.LogBox = New System.Windows.Forms.TextBox
        Me.GoButton = New System.Windows.Forms.Button
        Me.MyFolder = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'LogBox
        '
        Me.LogBox.Location = New System.Drawing.Point(12, 42)
        Me.LogBox.Multiline = True
        Me.LogBox.Name = "LogBox"
        Me.LogBox.Size = New System.Drawing.Size(353, 218)
        Me.LogBox.TabIndex = 0
        '
        'GoButton
        '
        Me.GoButton.Location = New System.Drawing.Point(12, 13)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(353, 23)
        Me.GoButton.TabIndex = 1
        Me.GoButton.Text = "Open and Process a Directory"
        Me.GoButton.UseVisualStyleBackColor = True
        '
        'MyFolder
        '
        Me.MyFolder.ShowNewFolderButton = False
        '
        'HollyApt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 429)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.LogBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HollyApt"
        Me.Text = "HollyApt - Optimize SmartPower By Monitoring Applications"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogBox As System.Windows.Forms.TextBox
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Friend WithEvents MyFolder As System.Windows.Forms.FolderBrowserDialog

End Class
