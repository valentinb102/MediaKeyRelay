<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.butPlayPause = New System.Windows.Forms.Button()
        Me.butStop = New System.Windows.Forms.Button()
        Me.butPrev = New System.Windows.Forms.Button()
        Me.butNext = New System.Windows.Forms.Button()
        Me.inputTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'butPlayPause
        '
        Me.butPlayPause.Location = New System.Drawing.Point(12, 12)
        Me.butPlayPause.Name = "butPlayPause"
        Me.butPlayPause.Size = New System.Drawing.Size(75, 23)
        Me.butPlayPause.TabIndex = 1
        Me.butPlayPause.Text = "Play/Pause"
        Me.butPlayPause.UseVisualStyleBackColor = True
        '
        'butStop
        '
        Me.butStop.Location = New System.Drawing.Point(93, 12)
        Me.butStop.Name = "butStop"
        Me.butStop.Size = New System.Drawing.Size(75, 23)
        Me.butStop.TabIndex = 3
        Me.butStop.Text = "Stop"
        Me.butStop.UseVisualStyleBackColor = True
        '
        'butPrev
        '
        Me.butPrev.Location = New System.Drawing.Point(12, 41)
        Me.butPrev.Name = "butPrev"
        Me.butPrev.Size = New System.Drawing.Size(75, 23)
        Me.butPrev.TabIndex = 4
        Me.butPrev.Text = "Previous"
        Me.butPrev.UseVisualStyleBackColor = True
        '
        'butNext
        '
        Me.butNext.Location = New System.Drawing.Point(93, 41)
        Me.butNext.Name = "butNext"
        Me.butNext.Size = New System.Drawing.Size(75, 23)
        Me.butNext.TabIndex = 5
        Me.butNext.Text = "Next"
        Me.butNext.UseVisualStyleBackColor = True
        '
        'inputTextBox
        '
        Me.inputTextBox.Location = New System.Drawing.Point(33, 121)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(100, 22)
        Me.inputTextBox.TabIndex = 6
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 255)
        Me.Controls.Add(Me.inputTextBox)
        Me.Controls.Add(Me.butNext)
        Me.Controls.Add(Me.butPrev)
        Me.Controls.Add(Me.butStop)
        Me.Controls.Add(Me.butPlayPause)
        Me.Name = "MainForm"
        Me.Text = "Media Key Relay"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents butPlayPause As Button
    Friend WithEvents butStop As Button
    Friend WithEvents butPrev As Button
    Friend WithEvents butNext As Button
    Friend WithEvents inputTextBox As TextBox
End Class
