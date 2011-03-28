<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(300, 5)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Afrikaans", "Albanian", "Arabic (Saudi Arabia)", "Arabic (Iraq)", "Arabic (Egypt)", "Arabic (Libya)", "Arabic (Algeria)", "Arabic (Morocco)", "Arabic (Tunisia)", "Arabic (Oman)", "Arabic (Yemen)", "Arabic (Syria)", "Arabic (Jordan)", "Arabic (Lebanon)", "Arabic (Kuwait)", "Arabic (UAE)", "Arabic (Bahrain)", "Arabic (Qatar)", "Armenian", "Azeri (Latin)", "Azeri (Cyrillic)", "Basque", "Belarusian", "Bulgarian", "Catalan", "Chinese (Taiwan)", "Chinese (PRC)", "Chinese (Hong Kong)", "Chinese (Singapore)", "Chinese (Macau)", "Croatian", "Czech", "Danish", "Dutch (Standard)", "Dutch (Belgian)", "English (United States)", "English (United Kingdom)", "English (Australian)", "English (Canadian)", "English (New Zealand)", "English (Irish)", "English (South Africa)", "English (Jamaica)", "English (Caribbean)", "English (Belize)", "English (Trinidad)", "English (Zimbabwe)", "English (Philippines)", "Estonian", "Faeroese", "Farsi", "Finnish", "French (Standard)", "French (Belgian)", "French (Canadia)", "French (Swiss)", "French (Luxembourg)", "French (Monaco)", "Georgian", "German (Standard)", "German (Swiss)", "German (Austrian)", "German (Luxembourg)", "German (Liechtenstein)", "Greek", "Hebrew", "Hindi", "Hungarian", "Icelandic", "Indonesian", "Italian (Standard)", "Italian (Swiss)", "Japanese", "Kazakh", "Konkani", "Korean", "Latvian", "Lithuanian", "Macedonian", "Malay (Malaysia)", "Malay (Brunei Darussalam)", "Marathi", "Norwegian (Bokmal)", "Norwegian (Nynorsk)", "Polish", "Portuguese (Brazilian)", "Portuguese (Standard)", "Romanian", "Russian", "Sanskrit", "Serbian (Latin)", "Serbian (Cyrillic)", "Slovak", "Slovenian", "Spanish (Spain)", "Spanish (Mexican)", "Spanish (Guatemala)", "Spanish (Costa Rica)", "Spanish (Panama)", "Spanish (Dominican Republic)", "Spanish (Venezuela)", "Spanish (Colombia)", "Spanish (Peru)", "Spanish (Argentina)", "Spanish (Ecuador)", "Spanish (Chile)", "Spanish (Uruguay)", "Spanish (Paraguay)", "Spanish (Bolivia)", "Spanish (El Salvador)", "Spanish (Honduras)", "Spanish (Nicaragua)", "Spanish (Puerto Rico)", "Swahili", "Swedish", "Swedish (Finland)", "Tamil", "Tatar", "Thai", "Turkish", "Ukrainian", "Urdu", "Uzbek (Latin)", "Uzbek (Cyrillic)", "Vietnamese"})
        Me.ComboBox1.Location = New System.Drawing.Point(102, 9)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "New Alt. Locale:"
        '
        'Dialog3
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(450, 38)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Alt. Locale..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
