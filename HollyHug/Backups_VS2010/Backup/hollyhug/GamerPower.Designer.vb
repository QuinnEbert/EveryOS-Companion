<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GamerPower
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
        Me.FindProgramBinaryDialog = New System.Windows.Forms.OpenFileDialog
        Me.AddGameButton = New System.Windows.Forms.Button
        Me.SaveAndCloseButton = New System.Windows.Forms.Button
        Me.DelGameButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'FindProgramBinaryDialog
        '
        Me.FindProgramBinaryDialog.FileName = "Game-Bin.exe"
        Me.FindProgramBinaryDialog.Filter = "Game Binaries|*.exe"
        Me.FindProgramBinaryDialog.InitialDirectory = "C:\Program Files"
        Me.FindProgramBinaryDialog.ReadOnlyChecked = True
        Me.FindProgramBinaryDialog.SupportMultiDottedExtensions = True
        Me.FindProgramBinaryDialog.Title = "Select a game to add to the Power Game list:"
        '
        'AddGameButton
        '
        Me.AddGameButton.Location = New System.Drawing.Point(13, 329)
        Me.AddGameButton.Name = "AddGameButton"
        Me.AddGameButton.Size = New System.Drawing.Size(75, 23)
        Me.AddGameButton.TabIndex = 1
        Me.AddGameButton.Text = "ADD Game"
        Me.AddGameButton.UseVisualStyleBackColor = True
        '
        'SaveAndCloseButton
        '
        Me.SaveAndCloseButton.Location = New System.Drawing.Point(175, 329)
        Me.SaveAndCloseButton.Name = "SaveAndCloseButton"
        Me.SaveAndCloseButton.Size = New System.Drawing.Size(97, 23)
        Me.SaveAndCloseButton.TabIndex = 2
        Me.SaveAndCloseButton.Text = "Save and Close"
        Me.SaveAndCloseButton.UseVisualStyleBackColor = True
        '
        'DelGameButton
        '
        Me.DelGameButton.Location = New System.Drawing.Point(94, 329)
        Me.DelGameButton.Name = "DelGameButton"
        Me.DelGameButton.Size = New System.Drawing.Size(75, 23)
        Me.DelGameButton.TabIndex = 3
        Me.DelGameButton.Text = "DEL Game"
        Me.DelGameButton.UseVisualStyleBackColor = True
        '
        'GamerPower
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 364)
        Me.Controls.Add(Me.DelGameButton)
        Me.Controls.Add(Me.SaveAndCloseButton)
        Me.Controls.Add(Me.AddGameButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GamerPower"
        Me.Text = "HollyAnn's PowerGames Configuration"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FindProgramBinaryDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AddGameButton As System.Windows.Forms.Button
    Friend WithEvents SaveAndCloseButton As System.Windows.Forms.Button
    Friend WithEvents DelGameButton As System.Windows.Forms.Button
End Class
