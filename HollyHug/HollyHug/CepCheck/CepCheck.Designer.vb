﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CepCheck
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
        Me.TextArea = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextArea
        '
        Me.TextArea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextArea.Location = New System.Drawing.Point(0, 0)
        Me.TextArea.Multiline = True
        Me.TextArea.Name = "TextArea"
        Me.TextArea.ReadOnly = True
        Me.TextArea.Size = New System.Drawing.Size(284, 262)
        Me.TextArea.TabIndex = 0
        '
        'CepCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.TextArea)
        Me.Name = "CepCheck"
        Me.Text = "CepCheck"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextArea As System.Windows.Forms.TextBox

End Class
