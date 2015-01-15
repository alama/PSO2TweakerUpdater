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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MainLabel = New DevComponents.DotNetBar.LabelX()
        Me.ProgressBarX1 = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Client = New System.Net.WebClient()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'MainLabel
        '
        '
        '
        '
        Me.MainLabel.BackgroundStyle.Class = ""
        Me.MainLabel.Location = New System.Drawing.Point(120, 12)
        Me.MainLabel.Name = "MainLabel"
        Me.MainLabel.Size = New System.Drawing.Size(196, 23)
        Me.MainLabel.TabIndex = 0
        Me.MainLabel.Text = "Downloading PSO2 Tweaker Updates..."
        '
        'ProgressBarX1
        '
        '
        '
        '
        Me.ProgressBarX1.BackgroundStyle.Class = ""
        Me.ProgressBarX1.Location = New System.Drawing.Point(1, 45)
        Me.ProgressBarX1.Name = "ProgressBarX1"
        Me.ProgressBarX1.Size = New System.Drawing.Size(427, 23)
        Me.ProgressBarX1.TabIndex = 1
        Me.ProgressBarX1.TextVisible = True
        '
        'Client
        '
        Me.Client.BaseAddress = ""
        Me.Client.CachePolicy = Nothing
        Me.Client.Credentials = Nothing
        Me.Client.UseDefaultCredentials = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.Location = New System.Drawing.Point(120, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(196, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Downloading PSO2 Tweaker Updates..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 80)
        Me.Controls.Add(Me.ProgressBarX1)
        Me.Controls.Add(Me.MainLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "PSO2 Tweaker Updater"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainLabel As DevComponents.DotNetBar.LabelX
    Friend WithEvents ProgressBarX1 As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Client As Net.WebClient
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX

End Class
