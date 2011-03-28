<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog2
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New Locale:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Afrikaans", "Albanian", "Alsatian (France)", "Amharic (Ethiopia)", "Arabic (Algeria)", "Arabic (Bahrain)", "Arabic (Egypt)", "Arabic (Iraq)", "Arabic (Jordan)", "Arabic (Kuwait)", "Arabic (Lebanon)", "Arabic (Libya)", "Arabic (Morocco)", "Arabic (Oman)", "Arabic (Qatar)", "Arabic (Saudi Arabia)", "Arabic (Syria)", "Arabic (Tunisia)", "Arabic (U.A.E.)", "Arabic (Yemen)", "Armenian", "Assamese (India)", "Azeri (Cyrillic)", "Azeri (Latin)", "Bashkir (Russia)", "Basque", "Belarusian", "Bengali (Bangladesh)", "Bengali (India)", "Bosnian (Cyrillic, Bosnia and Herzegovina)", "Bosnian (Latin, Bosnia and Herzegovina)", "Breton (France)", "Bulgarian", "Catalan", "Chinese (Hong Kong)", "Chinese (Macao)", "Chinese (PRC)", "Chinese (Simplified)", "Chinese (Singapore)", "Chinese (Taiwan)", "Chinese (Traditional)", "Corsican (France)", "Croatian", "Croatian (Latin, Bosnia and Herzegovina)", "Czech", "Danish", "Dari (Afghanistan)", "Divehi", "Dutch (Belgium)", "Dutch (Standard)", "English (Australia)", "English (Belize)", "English (Canada)", "English (Caribbean)", "English (India)", "English (Ireland)", "English (Jamaica)", "English (Malaysia)", "English (New Zealand)", "English (Philippines)", "English (Singapore)", "English (South Africa)", "English (Trinidad and Tobago)", "English (United Kingdom)", "English (United States)", "English (Zimbabwe)", "Estonian", "Faroese", "Farsi", "Filipino (Philippines)", "Finnish", "French (Belgian)", "French (Canadia)", "French (Standard)", "French (Luxembourg)", "French (Monaco)", "French (Swiss)", "Frisian (Netherlands)", "Galician", "Georgian", "German (Austrian)", "German (Standard)", "German (Liechtenstein)", "German (Luxembourg)", "German (Swiss)", "Greek", "Greenlandic (Greenland)", "Gujarati", "Hausa (Latin, Nigeria)", "Hebrew", "Hindi", "Hungarian", "Icelandic", "Igbo (Nigeria)", "Indonesian", "Inuktitut (Latin, Canada)", "Inuktitut (Syllabics, Canada)", "Irish (Ireland)", "isiXhosa (South Africa)", "isiZulu (South Africa)", "Italian (Standard)", "Italian (Swiss)", "Japanese", "Kannada", "Kazakh", "Khmer (Cambodia)", "K'iche (Guatemala)", "Kinyarwanda (Rwanda)", "Konkani", "Korean", "Kyrgyz", "Lao (Lao P.D.R.)", "Latvian", "Lithuanian", "Lower Sorbian (Germany)", "Luxembourgish (Luxembourg)", "Macedonian", "Malay (Brunei Darussalam)", "Malay (Malaysia)", "Malayalam (India)", "Maltese (Malta)", "Maori (New Zealand)", "Mapudungun (Chile)", "Marathi", "Mohawk (Mohawk)", "Mongolian (Cyrillic, Mongolia)", "Mongolian (Traditional Mongolian, PRC)", "Nepali (Nepal)", "Norwegian (Bokmal)", "Norwegian (Nynorsk)", "Occitan (France)", "Oriya (India)", "Pashto (Afghanistan)", "Persian", "Polish", "Portuguese (Brazilian)", "Portuguese (Standard)", "Punjabi", "Quechua (Bolivia)", "Quechua (Ecuador)", "Quechua (Peru)", "Romanian", "Romansh (Switzerland)", "Russian", "Sami, Inari (Finland)", "Sami, Lule (Norway)", "Sami, Lule (Sweden)", "Sami, Northern (Finland)", "Sami, Northern (Norway)", "Sami, Northern (Sweden)", "Sami, Skolt (Finland)", "Sami, Southern (Norway)", "Sami, Southern (Sweden)", "Sanskrit", "Serbian (Cyrillic, Bosnia and Herzegovina)", "Serbian (Cyrillic, Serbia)", "Serbian (Latin, Bosnia and Herzegovina)", "Serbian (Latin, Serbia)", "Sesotho sa Leboa (South Africa)", "Setswana (South Africa)", "Sinhala (Sri Lanka)", "Slovak", "Slovenian", "Spanish (Argentina)", "Spanish (Bolivia)", "Spanish (Chile)", "Spanish (Colombia)", "Spanish (Costa Rica)", "Spanish (Dominican Republic)", "Spanish (Ecuador)", "Spanish (El Salvador)", "Spanish (Guatemala)", "Spanish (Honduras)", "Spanish (Mexican)", "Spanish (Nicaragua)", "Spanish (Panama)", "Spanish (Paraguay)", "Spanish (Peru)", "Spanish (Puerto Rico)", "Spanish (Spain)", "Spanish (United States)", "Spanish (Uruguay)", "Spanish (Venezuela)", "Swahili", "Swedish (Finland)", "Swedish", "Syriac", "Tajik (Cyrillic, Tajikistan)", "Tamazight (Latin, Algeria)", "Tamil", "Tatar", "Telugu", "Thai", "Tibetan (PRC)", "Turkish", "Turkmen (Turkmenistan)", "Uighur (PRC)", "Ukrainian", "Upper Sorbian (Germany)", "Urdu", "Uzbek (Cyrillic)", "Uzbek (Latin)", "Vietnamese", "Welsh (United Kingdom)", "Wolof (Senegal)", "Yakut (Russia)", "Yi (PRC)", "Yoruba (Nigeria)"})
        Me.ComboBox1.Location = New System.Drawing.Point(102, 9)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(184, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Dialog2
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(450, 38)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Locale..."
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox

End Class
