Imports System.Drawing
Imports System.IO
Public Class Form3
    Dim LayoutName As String
    Dim MenuText As String
    Dim Hotkey As String
    Dim Locale As String
    Dim AltLocale As String
    Dim IconInfo As String
    Private Function ErrorHandling() As Boolean
        Dim result As Boolean

        result = True

        'error handling
        If Button2.Enabled = True And TextBox5.Text = "" Then
            MsgBox("Warning: You need to select an Alternate Locale.", MsgBoxStyle.Critical, "InKey Keyboard Creator")
            result = False
        End If

        Return result
    End Function
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim result As Boolean

        ' Trim leading and trailing spaces
        TextBox1.Text = Trim(TextBox1.Text)
        TextBox2.Text = Trim(TextBox2.Text)
        TextBox3.Text = Trim(TextBox3.Text)

        result = ErrorHandling()
        If result Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Hide()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = LayoutName
        TextBox2.Text = MenuText
        TextBox3.Text = Hotkey
        TextBox4.Text = Locale
        TextBox5.Text = AltLocale
        TextBox6.Text = IconInfo

        If TextBox5.Text = "" Then Button2.Enabled = False

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim result
        result = Dialog2.ShowDialog
        If result = System.Windows.Forms.DialogResult.OK Then
            TextBox4.Text = Dialog2.ComboBox1.SelectedItem
            result = Form1.inthelist(TextBox4.Text)
            If result = False Then
                Button2.Enabled = True
            Else
                TextBox5.Text = ""
                Button2.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result
        result = Dialog3.ShowDialog
        If result = System.Windows.Forms.DialogResult.OK Then
            TextBox5.Text = Dialog3.ComboBox1.SelectedItem
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim tempicon
        OpenFileDialog1.Filter = "Icon Files (*.ico)|*.ico|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox6.Text = OpenFileDialog1.FileName
            'PictureBox1.Image = New System.Drawing.Icon(TextBox6.Text)
            'Me.Icon = New Icon(Me.GetType(), TextBox6.Text)
            tempicon = New System.Drawing.Icon(TextBox6.Text)
            Dim bmp As Bitmap = tempicon.ToBitmap()
            PictureBox1.Image = bmp

            'PictureBox1.Image = New Bitmap(Me.GetType, TextBox6.Text)
        End If
    End Sub

    Private Sub Form3_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result As Boolean
        result = ErrorHandling()
        If Not result Then e.Cancel = True
    End Sub

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tempicon
        LayoutName = TextBox1.Text
        MenuText = TextBox2.Text
        Hotkey = TextBox3.Text
        Locale = TextBox4.Text
        AltLocale = TextBox5.Text
        IconInfo = TextBox6.Text
        If TextBox6.Text <> "" Then
            tempicon = New System.Drawing.Icon(TextBox6.Text)
            Dim bmp As Bitmap = tempicon.ToBitmap()
            PictureBox1.Image = bmp
        Else
            PictureBox1.Image = Nothing
        End If
        Button4.Focus()
    End Sub
End Class