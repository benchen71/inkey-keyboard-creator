Imports System.Windows.Forms

Public Class Dialog1
    Private Sub Dialog1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If TextBox1.Text.Contains(",") Then
            Label6.Visible = True
            RadioButton3.Visible = True
            RadioButton4.Visible = True
            TextBox4.Visible = True
        Else
            Label6.Visible = False
            RadioButton3.Visible = False
            RadioButton4.Visible = False
            TextBox4.Visible = False
        End If
        Me.TextBox1.Focus()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox1.Text = ""
            TextBox4.Text = ""
            LoopingBox.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            TextBox1.Enabled = False
            LoopingBox.Enabled = False
            TextBox4.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            TextBox1.Text = ""
            TextBox4.Text = ""
            LoopingBox.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            TextBox1.Enabled = False
            LoopingBox.Enabled = False
            TextBox4.Enabled = False
            RadioButton3.Enabled = False
            RadioButton4.Enabled = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked Then
            TextBox4.Enabled = True
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultiTapBox.CheckedChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Contains(",") Then
            Label6.Visible = True
            RadioButton3.Visible = True
            RadioButton4.Visible = True
            TextBox4.Visible = True
        Else
            Label6.Visible = False
            RadioButton3.Visible = False
            RadioButton4.Visible = False
            TextBox4.Visible = False
        End If
    End Sub
End Class
