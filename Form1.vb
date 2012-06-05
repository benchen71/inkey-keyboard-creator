Imports System
Imports System.IO
Imports Ionic.zip

Public Class Form1
    Dim Key As Button()
    Dim NumKeys As Integer
    Dim KeyContents As String()
    Dim KeyContentsShift As String()
    Dim KeyContentsCtrl As String()
    Dim KeyContentsAlt As String()
    Dim KeyContentsShiftCtrl As String()
    Dim KeyContentsShiftAlt As String()
    Dim KeyContentsCtrlAlt As String()
    Dim KeyContentsShiftCtrlAlt As String()
    Dim KeyContentsAltGr As String()
    Dim KeyContentsShiftAltGr As String()
    Dim KeyContentsCtrlAltGr As String()
    Dim KeyContentsShiftCtrlAltGr As String()
    Dim KeyRotaSuppress As Boolean()
    Dim KeyRotaSuppressShift As Boolean()
    Dim KeyRotaSuppressCtrl As Boolean()
    Dim KeyRotaSuppressAlt As Boolean()
    Dim KeyRotaSuppressShiftCtrl As Boolean()
    Dim KeyRotaSuppressShiftAlt As Boolean()
    Dim KeyRotaSuppressCtrlAlt As Boolean()
    Dim KeyRotaSuppressShiftCtrlAlt As Boolean()
    Dim KeyRotaSuppressAltGr As Boolean()
    Dim KeyRotaSuppressShiftAltGr As Boolean()
    Dim KeyRotaSuppressCtrlAltGr As Boolean()
    Dim KeyRotaSuppressShiftCtrlAltGr As Boolean()
    Dim KeyLabel As Label()
    Dim LabelFont As Font
    Dim TextFont As Font
    Dim projectchanged As Boolean
    Dim AltGr As Boolean
    Dim DeadKeys As Boolean
    Dim DeadKey As Integer
    Dim DeadKey2 As Integer
    Dim KeyContentsDeadkey As String()
    Dim KeyContentsDeadkeyShift As String()
    Dim KeyContentsDeadkey2 As String()
    Dim KeyContentsDeadkey2Shift As String()

    Private Sub ChangeFontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeFontToolStripMenuItem.Click
        Dim temploop As Integer
        Dim FontError
        Dim beforefont

        beforefont = KeyLabel(1).Font.Name
        FontDialog1.Font = KeyLabel(1).Font

        FontError = FontDialog1.ShowDialog()
        If FontError <> DialogResult.Cancel Then
            LabelFont = New Font(FontDialog1.Font.Name, 10, FontStyle.Regular)
            TextFont = New Font(FontDialog1.Font.Name, 16, FontStyle.Regular)
            For temploop = 1 To NumKeys
                KeyLabel(temploop).Font = LabelFont
            Next temploop
            Dialog1.TextBox1.Font = TextFont
            TextBox1.Font = TextFont
        End If

        If (beforefont <> KeyLabel(1).Font.Name) Then
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim result
        If projectchanged Then
            result = Dialog4.ShowDialog
            If result = Windows.Forms.DialogResult.Yes Then
                SaveProject()
            ElseIf result = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim temploop As Integer
        Dim parameters() As String

        Key = New Button() {KeyBack, KeyGrave, KeyOne, KeyTwo, KeyThree, KeyFour, KeyFive, KeySix, KeySeven, KeyEight, KeyNine, KeyZero, KeyDash, KeyEquals, KeyReverseSolidus, _
        KeyQ, KeyW, KeyE, KeyR, KeyT, KeyY, KeyU, KeyI, KeyO, KeyP, KeyOpenBracket, KeyCloseBracket, _
        KeyA, KeyS, KeyD, KeyF, KeyG, KeyH, KeyJ, KeyK, KeyL, KeySemiColon, KeyApostrophe, _
        KeyZ, KeyX, KeyC, KeyV, KeyB, KeyN, KeyM, KeyComma, KeyPeriod, KeySolidus}
        KeyContents = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShift = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsCtrl = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsAlt = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShiftCtrl = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShiftAlt = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsCtrlAlt = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShiftCtrlAlt = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsAltGr = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShiftAltGr = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsCtrlAltGr = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsShiftCtrlAltGr = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

        KeyRotaSuppress = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShift = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressCtrl = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressAlt = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShiftCtrl = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShiftAlt = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressCtrlAlt = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShiftCtrlAlt = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressAltGr = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShiftAltGr = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressCtrlAltGr = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        KeyRotaSuppressShiftCtrlAltGr = New Boolean() {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}

        KeyLabel = New Label() {Label0, Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12, Label13, Label14, Label15, Label16, Label17, Label18, Label19, Label20, Label21, Label22, Label23, Label24, Label25, Label26, Label27, Label28, Label29, Label30, Label31, Label32, Label33, Label34, Label35, Label36, Label37, Label38, Label39, Label40, Label41, Label42, Label43, Label44, Label45, Label46, Label47}
        NumKeys = 47
        LabelFont = New Font(DefaultFont.Name, 10, FontStyle.Regular)
        For temploop = 1 To NumKeys
            Key(temploop).Font = LabelFont
            Key(temploop).Text = GetShortNameFromName(Key(temploop).Name)
            Key(temploop).Text = LCase(Key(temploop).Text)
            KeyLabel(temploop).Text = ""
            KeyLabel(temploop).ForeColor = Color.Red
            KeyLabel(temploop).Left = Key(temploop).Left + 4
            KeyLabel(temploop).Top = Key(temploop).Top + 4
            KeyLabel(temploop).Font = LabelFont
            KeyLabel(temploop).BackColor = Color.Transparent
        Next temploop
        projectchanged = False
        AltGr = True
        Me.Text = "Untitled - InKey Keyboard Creator"
        Dim tempsize As System.Drawing.Size
        tempsize.Width = 1010
        tempsize.Height = 404
        Me.Size = tempsize
        Dialog1.Width = 476
        Dialog1.GroupBox1.Width = 157
        DeadKeys = False
        DeadKey = -1
        DeadKey2 = -1
        KeyContentsDeadkey = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsDeadkeyShift = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsDeadkey2 = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        KeyContentsDeadkey2Shift = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

        ' Check for commandline parameter
        parameters = Environment.GetCommandLineArgs()
        If parameters.Length > 1 Then
            If parameters(1) <> "" Then
                OpenFileDialog1.FileName = parameters(1)
                LoadProject()
            End If
        End If
    End Sub

    Private Sub KeyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles KeyGrave.Click, KeyOne.Click, KeyTwo.Click, KeyThree.Click, KeyFour.Click, KeyFive.Click, KeySix.Click, KeySeven.Click, KeyEight.Click, KeyNine.Click, KeyZero.Click, KeyDash.Click, KeyEquals.Click, KeyReverseSolidus.Click, KeyQ.Click, KeyW.Click, KeyE.Click, KeyR.Click, KeyT.Click, KeyY.Click, KeyU.Click, KeyI.Click, KeyO.Click, KeyP.Click, KeyOpenBracket.Click, KeyCloseBracket.Click, KeyA.Click, KeyS.Click, KeyD.Click, KeyF.Click, KeyG.Click, KeyH.Click, KeyJ.Click, KeyK.Click, KeyL.Click, KeySemiColon.Click, KeyApostrophe.Click, KeyZ.Click, KeyX.Click, KeyC.Click, KeyV.Click, KeyB.Click, KeyN.Click, KeyM.Click, KeyComma.Click, KeyPeriod.Click, KeySolidus.Click
        Dim btn As Button = DirectCast(sender, Button)
        Dim KeyNumber As Integer
        Dim KeyName As String
        Dim textbefore As String
        Dim checkedbefore As Boolean
        Dim radiobefore As Boolean
        Dim deadkeytextbefore As String
        Dim radio2before As Boolean
        Dim deadkey2textbefore As String
        Dim result

        KeyNumber = GetKeyNumberFromName(btn.Name)
        KeyName = GetShortNameFromName(btn.Name)

        Dialog1.Text = "Enter character(s) for " + btn.Text.Replace("&&", "&")

        ' Load textbox with existing string
        If ButtonShift.Checked Then
            If ButtonCtrl.Checked Then
                If ButtonAlt.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsShiftCtrlAlt(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShiftCtrlAlt(KeyNumber)
                ElseIf ButtonAltGr.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsShiftCtrlAltGr(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShiftCtrlAltGr(KeyNumber)
                Else
                    Dialog1.TextBox1.Text = KeyContentsShiftCtrl(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShiftCtrl(KeyNumber)
                End If
            Else
                If ButtonAlt.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsShiftAlt(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShiftAlt(KeyNumber)
                ElseIf ButtonAltGr.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsShiftAltGr(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShiftAltGr(KeyNumber)
                Else
                    Dialog1.TextBox1.Text = KeyContentsShift(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressShift(KeyNumber)
                End If
            End If
        Else
            If ButtonCtrl.Checked Then
                If ButtonAlt.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsCtrlAlt(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressCtrlAlt(KeyNumber)
                ElseIf ButtonAltGr.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsCtrlAltGr(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressCtrlAltGr(KeyNumber)
                Else
                    Dialog1.TextBox1.Text = KeyContentsCtrl(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressCtrl(KeyNumber)
                End If
            Else
                If ButtonAlt.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsAlt(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressAlt(KeyNumber)
                ElseIf ButtonAltGr.Checked Then
                    Dialog1.TextBox1.Text = KeyContentsAltGr(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppressAltGr(KeyNumber)
                Else
                    Dialog1.TextBox1.Text = KeyContents(KeyNumber)
                    Dialog1.CheckBox1.Checked = KeyRotaSuppress(KeyNumber)
                End If
            End If
        End If

        ' Load Deadkey string (if any)
        Dialog1.TextBox2.Text = ""
        Dialog1.TextBox3.Text = ""
        If ButtonCtrl.Checked = False And ButtonAlt.Checked = False Then
            Dialog1.TextBox2.Enabled = True
            Dialog1.TextBox3.Enabled = True
            If ButtonShift.Checked Then
                Dialog1.TextBox2.Text = KeyContentsDeadkeyShift(KeyNumber)
                Dialog1.TextBox3.Text = KeyContentsDeadkey2Shift(KeyNumber)
            Else
                Dialog1.TextBox2.Text = KeyContentsDeadkey(KeyNumber)
                Dialog1.TextBox3.Text = KeyContentsDeadkey2(KeyNumber)
            End If
        Else
            Dialog1.TextBox2.Enabled = False
            Dialog1.TextBox3.Enabled = False
        End If

        ' Show if this key is the Deadkey
        If (((KeyNumber = DeadKey) Or (KeyNumber = DeadKey2)) And (DeadKeys)) Then
            If (KeyNumber = DeadKey) Then
                Dialog1.RadioButton1.Checked = True
                Dialog1.RadioButton2.Checked = False
            End If
            If (KeyNumber = DeadKey2) Then
                Dialog1.RadioButton2.Checked = True
                Dialog1.RadioButton1.Checked = False
            End If
            If ((ButtonShift.Checked = False) And (ButtonAlt.Checked = False) And (ButtonCtrl.Checked = False)) Then
                Dialog1.TextBox1.Enabled = False
            Else
                Dialog1.TextBox1.Enabled = True
            End If
        Else
            Dialog1.RadioButton1.Checked = False
            Dialog1.RadioButton2.Checked = False
            Dialog1.TextBox1.Enabled = True
        End If

        If ((ButtonShift.Checked = False) And (ButtonAlt.Checked = False) And (ButtonCtrl.Checked = False) And (DeadKeys)) Then
            ' Only time it is possible to change or choose deadkey
            Dialog1.RadioButton1.Enabled = True
            Dialog1.RadioButton2.Enabled = True
        Else
            Dialog1.RadioButton1.Enabled = False
            Dialog1.RadioButton2.Enabled = False
        End If

        textbefore = Dialog1.TextBox1.Text
        checkedbefore = Dialog1.CheckBox1.Checked
        radiobefore = Dialog1.RadioButton1.Checked
        deadkeytextbefore = Dialog1.TextBox2.Text
        radio2before = Dialog1.RadioButton2.Checked
        deadkey2textbefore = Dialog1.TextBox3.Text

        ' Show dialog box
        result = Dialog1.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then Exit Sub

        If ((ButtonShift.Checked = False) And (ButtonAlt.Checked = False) And (ButtonCtrl.Checked = False)) Then
            ' Unshifted deadkey can only output deadkey flag
            If Dialog1.RadioButton1.Checked = True Then Dialog1.TextBox1.Text = ""
            If Dialog1.RadioButton2.Checked = True Then Dialog1.TextBox1.Text = ""
        End If

        If Dialog1.TextBox1.Text <> textbefore Then
            ' Store textbox string
            If ButtonShift.Checked Then
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyContentsShiftCtrlAlt(KeyNumber) = Dialog1.TextBox1.Text
                    ElseIf ButtonAltGr.Checked Then
                        KeyContentsShiftCtrlAltGr(KeyNumber) = Dialog1.TextBox1.Text
                    Else
                        KeyContentsShiftCtrl(KeyNumber) = Dialog1.TextBox1.Text
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyContentsShiftAlt(KeyNumber) = Dialog1.TextBox1.Text
                    ElseIf ButtonAltGr.Checked Then
                        KeyContentsShiftAltGr(KeyNumber) = Dialog1.TextBox1.Text
                    Else
                        KeyContentsShift(KeyNumber) = Dialog1.TextBox1.Text
                    End If
                End If
            Else
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyContentsCtrlAlt(KeyNumber) = Dialog1.TextBox1.Text
                    ElseIf ButtonAltGr.Checked Then
                        KeyContentsCtrlAltGr(KeyNumber) = Dialog1.TextBox1.Text
                    Else
                        KeyContentsCtrl(KeyNumber) = Dialog1.TextBox1.Text
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyContentsAlt(KeyNumber) = Dialog1.TextBox1.Text
                    ElseIf ButtonAltGr.Checked Then
                        KeyContentsAltGr(KeyNumber) = Dialog1.TextBox1.Text
                    Else
                        KeyContents(KeyNumber) = Dialog1.TextBox1.Text
                    End If
                End If
            End If
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then
                SaveProjectToolStripMenuItem1.Enabled = True
            End If
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
        If checkedbefore <> Dialog1.CheckBox1.Checked Then
            ' Store textbox string
            If ButtonShift.Checked Then
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyRotaSuppressShiftCtrlAlt(KeyNumber) = Dialog1.CheckBox1.Checked
                    ElseIf ButtonAltGr.Checked Then
                        KeyRotaSuppressShiftCtrlAltGr(KeyNumber) = Dialog1.CheckBox1.Checked
                    Else
                        KeyRotaSuppressShiftCtrl(KeyNumber) = Dialog1.CheckBox1.Checked
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyRotaSuppressShiftAlt(KeyNumber) = Dialog1.CheckBox1.Checked
                    ElseIf ButtonAltGr.Checked Then
                        KeyRotaSuppressShiftAltGr(KeyNumber) = Dialog1.CheckBox1.Checked
                    Else
                        KeyRotaSuppressShift(KeyNumber) = Dialog1.CheckBox1.Checked
                    End If
                End If
            Else
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyRotaSuppressCtrlAlt(KeyNumber) = Dialog1.CheckBox1.Checked
                    ElseIf ButtonAltGr.Checked Then
                        KeyRotaSuppressCtrlAltGr(KeyNumber) = Dialog1.CheckBox1.Checked
                    Else
                        KeyRotaSuppressCtrl(KeyNumber) = Dialog1.CheckBox1.Checked
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyRotaSuppressAlt(KeyNumber) = Dialog1.CheckBox1.Checked
                    ElseIf ButtonAltGr.Checked Then
                        KeyRotaSuppressAltGr(KeyNumber) = Dialog1.CheckBox1.Checked
                    Else
                        KeyRotaSuppress(KeyNumber) = Dialog1.CheckBox1.Checked
                    End If
                End If
            End If
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
        If Dialog1.TextBox2.Text <> deadkeytextbefore Then
            If ButtonShift.Checked Then
                KeyContentsDeadkeyShift(KeyNumber) = Dialog1.TextBox2.Text
            Else
                KeyContentsDeadkey(KeyNumber) = Dialog1.TextBox2.Text
            End If
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
        If radiobefore <> Dialog1.RadioButton1.Checked Then
            ' Deadkey has been changed
            DeadKey = KeyNumber
            ResetKeyBorders()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
        If Dialog1.TextBox3.Text <> deadkey2textbefore Then
            If ButtonShift.Checked Then
                KeyContentsDeadkey2Shift(KeyNumber) = Dialog1.TextBox3.Text
            Else
                KeyContentsDeadkey2(KeyNumber) = Dialog1.TextBox3.Text
            End If
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
        If radio2before <> Dialog1.RadioButton2.Checked Then
            ' Deadkey has been changed
            DeadKey2 = KeyNumber
            ResetKeyBorders()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub

    Private Sub ButtonShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShift.CheckedChanged
        Dim temploop As Integer
        RefreshLabels()
        If ButtonShift.Checked = False Then
            For temploop = 1 To NumKeys
                Key(temploop).Text = GetShortNameFromName(Key(temploop).Name)
                Key(temploop).Text = LCase(Key(temploop).Text)
            Next temploop
        Else
            For temploop = 1 To NumKeys
                Key(temploop).Text = GetShortNameFromName(Key(temploop).Name)
                If Key(temploop).Text = "`" Then Key(temploop).Text = "~"
                If Key(temploop).Text = "1" Then Key(temploop).Text = "!"
                If Key(temploop).Text = "2" Then Key(temploop).Text = "@"
                If Key(temploop).Text = "3" Then Key(temploop).Text = "#"
                If Key(temploop).Text = "4" Then Key(temploop).Text = "$"
                If Key(temploop).Text = "5" Then Key(temploop).Text = "%"
                If Key(temploop).Text = "6" Then Key(temploop).Text = "^"
                If Key(temploop).Text = "7" Then Key(temploop).Text = "&&"
                If Key(temploop).Text = "8" Then Key(temploop).Text = "*"
                If Key(temploop).Text = "9" Then Key(temploop).Text = "("
                If Key(temploop).Text = "0" Then Key(temploop).Text = ")"
                If Key(temploop).Text = "-" Then Key(temploop).Text = "_"
                If Key(temploop).Text = "=" Then Key(temploop).Text = "+"
                If Key(temploop).Text = "\" Then Key(temploop).Text = "|"
                If Key(temploop).Text = "[" Then Key(temploop).Text = "{"
                If Key(temploop).Text = "]" Then Key(temploop).Text = "}"
                If Key(temploop).Text = ";" Then Key(temploop).Text = ":"
                If Key(temploop).Text = "'" Then Key(temploop).Text = """"
                If Key(temploop).Text = "," Then Key(temploop).Text = "<"
                If Key(temploop).Text = "." Then Key(temploop).Text = ">"
                If Key(temploop).Text = "/" Then Key(temploop).Text = "?"
            Next temploop
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result
        If projectchanged Then
            result = Dialog4.ShowDialog
            If result = Windows.Forms.DialogResult.Yes Then
                SaveProject()
                End
            ElseIf result = Windows.Forms.DialogResult.No Then
                End
            End If
        Else
            End
        End If
    End Sub

    Private Sub ButtonCtrl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCtrl.CheckedChanged
        RefreshLabels()
    End Sub

    Private Sub ButtonAlt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAlt.CheckedChanged
        If ButtonAlt.Checked Then ButtonAltGr.Checked = False
        RefreshLabels()
    End Sub

    Private Sub SaveProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem.Click
        SaveFileDialog1.Filter = "InKeyProject Files (*.ikp)|*.ikp|All files (*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SaveProject()
        End If
    End Sub
    Private Sub SaveProjectToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectToolStripMenuItem1.Click
        SaveProject()
    End Sub
    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim dialogresult

        If projectchanged Then
            dialogresult = Dialog4.ShowDialog
            If dialogresult = Windows.Forms.DialogResult.Yes Then
                SaveProject()
            ElseIf dialogresult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        OpenFileDialog1.Filter = "InKeyProject Files (*.ikp)|*.ikp|All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            LoadProject()
        End If
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
        Dim temploop As Integer
        Dim dialogresult

        If projectchanged Then
            dialogresult = Dialog4.ShowDialog
            If dialogresult = Windows.Forms.DialogResult.Yes Then
                SaveProject()
            ElseIf dialogresult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        LabelFont = New Font(DefaultFont.Name, 10, FontStyle.Regular)
        TextFont = New Font(FontDialog1.Font.Name, 16, FontStyle.Regular)
        Dialog1.TextBox1.Font = TextFont

        For temploop = 1 To NumKeys
            KeyContents(temploop) = ""
            KeyContentsShift(temploop) = ""
            KeyContentsCtrl(temploop) = ""
            KeyContentsAlt(temploop) = ""
            KeyContentsShiftCtrl(temploop) = ""
            KeyContentsShiftAlt(temploop) = ""
            KeyContentsCtrlAlt(temploop) = ""
            KeyContentsShiftCtrlAlt(temploop) = ""
            KeyContentsAltGr(temploop) = ""
            KeyContentsShiftAltGr(temploop) = ""
            KeyContentsCtrlAltGr(temploop) = ""
            KeyContentsShiftCtrlAltGr(temploop) = ""
            KeyContentsDeadkey(temploop) = ""
            KeyContentsDeadkeyShift(temploop) = ""
            ButtonShift.Checked = False
            ButtonCtrl.Checked = False
            ButtonAlt.Checked = False
            KeyLabel(temploop).Text = ""
            KeyLabel(temploop).Font = LabelFont
            KeyRotaSuppress(temploop) = False
            KeyRotaSuppressShift(temploop) = False
            KeyRotaSuppressCtrl(temploop) = False
            KeyRotaSuppressAlt(temploop) = False
            KeyRotaSuppressShiftCtrl(temploop) = False
            KeyRotaSuppressShiftAlt(temploop) = False
            KeyRotaSuppressCtrlAlt(temploop) = False
            KeyRotaSuppressShiftCtrlAlt(temploop) = False
            KeyRotaSuppressAltGr(temploop) = False
            KeyRotaSuppressShiftAltGr(temploop) = False
            KeyRotaSuppressCtrlAltGr(temploop) = False
            KeyRotaSuppressShiftCtrlAltGr(temploop) = False
        Next
        Form3.TextBox1.Text = ""
        Form3.TextBox2.Text = ""
        Form3.TextBox3.Text = ""
        Form3.TextBox4.Text = ""
        Form3.TextBox5.Text = ""
        Form3.Button2.Enabled = False
        Form3.TextBox6.Text = ""
        Form3.PictureBox1.Image = Nothing
        projectchanged = False
        SaveProjectToolStripMenuItem1.Enabled = False
        SaveFileDialog1.FileName = ""
        AltGr = False
        DeadKeys = False
        ActivateDeadkeyToolStripMenuItem.Checked = False
        Dialog1.TextBox2.Enabled = False
        Dialog1.RadioButton1.Enabled = False
        Dialog1.Width = 476
        ResetKeyBorders()
        ButtonAlt.Text = "Alt"
        ButtonAltGr.Text = "AltGr"
        ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle Alt/AltGr to LAlt/RAlt"
        Me.Text = "Untitled - InKey Keyboard Creator"
    End Sub

    Private Sub ConfigureKeyboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureKeyboardToolStripMenuItem.Click
        Dim beforelayoutname As String
        Dim beforemenutext As String
        Dim beforehotkey As String
        Dim beforelocale As String
        Dim beforealtlocale As String
        Dim beforeicon As String

        beforelayoutname = Form3.TextBox1.Text
        beforemenutext = Form3.TextBox2.Text
        beforehotkey = Form3.TextBox3.Text
        beforelocale = Form3.TextBox4.Text
        beforealtlocale = Form3.TextBox5.Text
        beforeicon = Form3.TextBox6.Text

        Form3.ShowDialog()

        If ((beforelayoutname <> Form3.TextBox1.Text) Or (beforemenutext <> Form3.TextBox2.Text) Or (beforehotkey <> Form3.TextBox3.Text) Or (beforelocale <> Form3.TextBox4.Text) Or (beforealtlocale <> Form3.TextBox5.Text) Or (beforeicon <> Form3.TextBox6.Text)) Then
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub

    Private Sub Label_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseHover, Label2.MouseHover, Label3.MouseHover, Label4.MouseHover, Label5.MouseHover, Label6.MouseHover, Label7.MouseHover, Label8.MouseHover, Label9.MouseHover, Label10.MouseHover, Label11.MouseHover, Label12.MouseHover, Label13.MouseHover, Label14.MouseHover, Label15.MouseHover, Label16.MouseHover, Label17.MouseHover, Label18.MouseHover, Label19.MouseHover, Label20.MouseHover, Label21.MouseHover, Label22.MouseHover, Label23.MouseHover, Label24.MouseHover, Label25.MouseHover, Label26.MouseHover, Label27.MouseHover, Label28.MouseHover, Label29.MouseHover, Label30.MouseHover, Label31.MouseHover, Label32.MouseHover, Label33.MouseHover, Label34.MouseHover, Label35.MouseHover, Label36.MouseHover, Label37.MouseHover, Label38.MouseHover, Label39.MouseHover, Label40.MouseHover, Label41.MouseHover, Label42.MouseHover, Label43.MouseHover, Label44.MouseHover, Label45.MouseHover, Label46.MouseHover, Label47.MouseHover
        Dim lbl As Label = DirectCast(sender, Label)
        If Len(lbl.Text) > 5 Then lbl.Visible = False
    End Sub

    Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        Label13.Visible = True
        Label14.Visible = True
        Label15.Visible = True
        Label16.Visible = True
        Label17.Visible = True
        Label18.Visible = True
        Label19.Visible = True
        Label20.Visible = True
        Label21.Visible = True
        Label22.Visible = True
        Label23.Visible = True
        Label24.Visible = True
        Label25.Visible = True
        Label26.Visible = True
        Label27.Visible = True
        Label28.Visible = True
        Label29.Visible = True
        Label30.Visible = True
        Label31.Visible = True
        Label32.Visible = True
        Label33.Visible = True
        Label34.Visible = True
        Label35.Visible = True
        Label36.Visible = True
        Label37.Visible = True
        Label38.Visible = True
        Label39.Visible = True
        Label40.Visible = True
        Label41.Visible = True
        Label42.Visible = True
        Label43.Visible = True
        Label44.Visible = True
        Label45.Visible = True
        Label46.Visible = True
        Label47.Visible = True
    End Sub
    Private Function GetKeyNumberFromName(ByVal KeyName As String) As Integer
        Dim KeyNumber As Integer
        KeyNumber = 0
        If KeyName = "KeyGrave" Then KeyNumber = 1
        If KeyName = "KeyOne" Then KeyNumber = 2
        If KeyName = "KeyTwo" Then KeyNumber = 3
        If KeyName = "KeyThree" Then KeyNumber = 4
        If KeyName = "KeyFour" Then KeyNumber = 5
        If KeyName = "KeyFive" Then KeyNumber = 6
        If KeyName = "KeySix" Then KeyNumber = 7
        If KeyName = "KeySeven" Then KeyNumber = 8
        If KeyName = "KeyEight" Then KeyNumber = 9
        If KeyName = "KeyNine" Then KeyNumber = 10
        If KeyName = "KeyZero" Then KeyNumber = 11
        If KeyName = "KeyDash" Then KeyNumber = 12
        If KeyName = "KeyEquals" Then KeyNumber = 13
        If KeyName = "KeyReverseSolidus" Then KeyNumber = 14
        If KeyName = "KeyQ" Then KeyNumber = 15
        If KeyName = "KeyW" Then KeyNumber = 16
        If KeyName = "KeyE" Then KeyNumber = 17
        If KeyName = "KeyR" Then KeyNumber = 18
        If KeyName = "KeyT" Then KeyNumber = 19
        If KeyName = "KeyY" Then KeyNumber = 20
        If KeyName = "KeyU" Then KeyNumber = 21
        If KeyName = "KeyI" Then KeyNumber = 22
        If KeyName = "KeyO" Then KeyNumber = 23
        If KeyName = "KeyP" Then KeyNumber = 24
        If KeyName = "KeyOpenBracket" Then KeyNumber = 25
        If KeyName = "KeyCloseBracket" Then KeyNumber = 26
        If KeyName = "KeyA" Then KeyNumber = 27
        If KeyName = "KeyS" Then KeyNumber = 28
        If KeyName = "KeyD" Then KeyNumber = 29
        If KeyName = "KeyF" Then KeyNumber = 30
        If KeyName = "KeyG" Then KeyNumber = 31
        If KeyName = "KeyH" Then KeyNumber = 32
        If KeyName = "KeyJ" Then KeyNumber = 33
        If KeyName = "KeyK" Then KeyNumber = 34
        If KeyName = "KeyL" Then KeyNumber = 35
        If KeyName = "KeySemiColon" Then KeyNumber = 36
        If KeyName = "KeyApostrophe" Then KeyNumber = 37
        If KeyName = "KeyZ" Then KeyNumber = 38
        If KeyName = "KeyX" Then KeyNumber = 39
        If KeyName = "KeyC" Then KeyNumber = 40
        If KeyName = "KeyV" Then KeyNumber = 41
        If KeyName = "KeyB" Then KeyNumber = 42
        If KeyName = "KeyN" Then KeyNumber = 43
        If KeyName = "KeyM" Then KeyNumber = 44
        If KeyName = "KeyComma" Then KeyNumber = 45
        If KeyName = "KeyPeriod" Then KeyNumber = 46
        If KeyName = "KeySolidus" Then KeyNumber = 47
        Return KeyNumber
    End Function
    Private Function GetShortNameFromName(ByVal KeyName As String) As String
        KeyName = Mid(KeyName, 4)
        If KeyName = "Grave" Then KeyName = "`"
        If KeyName = "One" Then KeyName = "1"
        If KeyName = "Two" Then KeyName = "2"
        If KeyName = "Three" Then KeyName = "3"
        If KeyName = "Four" Then KeyName = "4"
        If KeyName = "Five" Then KeyName = "5"
        If KeyName = "Six" Then KeyName = "6"
        If KeyName = "Seven" Then KeyName = "7"
        If KeyName = "Eight" Then KeyName = "8"
        If KeyName = "Nine" Then KeyName = "9"
        If KeyName = "Zero" Then KeyName = "0"
        If KeyName = "Dash" Then KeyName = "-"
        If KeyName = "Equals" Then KeyName = "="
        If KeyName = "ReverseSolidus" Then KeyName = "\"
        If KeyName = "OpenBracket" Then KeyName = "["
        If KeyName = "CloseBracket" Then KeyName = "]"
        If KeyName = "SemiColon" Then KeyName = ";"
        If KeyName = "Apostrophe" Then KeyName = "'"
        If KeyName = "Comma" Then KeyName = ","
        If KeyName = "Period" Then KeyName = "."
        If KeyName = "Solidus" Then KeyName = "/"
        Return KeyName
    End Function
    Private Function ConvertCodeToName(ByVal Lang As String) As String
        Dim LangName As String
        LangName = ""
        If Lang = "0436" Then LangName = "Afrikaans"
        If Lang = "041C" Then LangName = "Albanian"
        If Lang = "0484" Then LangName = "Alsatian (France)"
        If Lang = "045E" Then LangName = "Amharic (Ethiopia)"
        If Lang = "1401" Then LangName = "Arabic (Algeria)"
        If Lang = "3C01" Then LangName = "Arabic (Bahrain)"
        If Lang = "0C01" Then LangName = "Arabic (Egypt)"
        If Lang = "0801" Then LangName = "Arabic (Iraq)"
        If Lang = "2C01" Then LangName = "Arabic (Jordan)"
        If Lang = "3401" Then LangName = "Arabic (Kuwait)"
        If Lang = "3001" Then LangName = "Arabic (Lebanon)"
        If Lang = "1001" Then LangName = "Arabic (Libya)"
        If Lang = "1801" Then LangName = "Arabic (Morocco)"
        If Lang = "2001" Then LangName = "Arabic (Oman)"
        If Lang = "4001" Then LangName = "Arabic (Qatar)"
        If Lang = "0401" Then LangName = "Arabic (Saudi Arabia)"
        If Lang = "2801" Then LangName = "Arabic (Syria)"
        If Lang = "1C01" Then LangName = "Arabic (Tunisia)"
        If Lang = "3801" Then LangName = "Arabic (U.A.E.)"
        If Lang = "2401" Then LangName = "Arabic (Yemen)"
        If Lang = "042B" Then LangName = "Armenian"
        If Lang = "044D" Then LangName = "Assamese (India)"
        If Lang = "082C" Then LangName = "Azeri (Cyrillic)"
        If Lang = "042C" Then LangName = "Azeri (Latin)"
        If Lang = "046D" Then LangName = "Bashkir (Russia)"
        If Lang = "042D" Then LangName = "Basque"
        If Lang = "0423" Then LangName = "Belarusian"
        If Lang = "0845" Then LangName = "Bengali (Bangladesh)"
        If Lang = "0445" Then LangName = "Bengali (India)"
        If Lang = "201A" Then LangName = "Bosnian (Cyrillic, Bosnia and Herzegovina)"
        If Lang = "141A" Then LangName = "Bosnian (Latin, Bosnia and Herzegovina)"
        If Lang = "047E" Then LangName = "Breton (France)"
        If Lang = "0402" Then LangName = "Bulgarian"
        If Lang = "0403" Then LangName = "Catalan"
        If Lang = "0C04" Then LangName = "Chinese (Hong Kong)"
        If Lang = "1404" Then LangName = "Chinese (Macao)"
        If Lang = "0804" Then LangName = "Chinese (PRC)"
        If Lang = "0004" Then LangName = "Chinese (Simplified)"
        If Lang = "1004" Then LangName = "Chinese (Singapore)"
        If Lang = "0404" Then LangName = "Chinese (Taiwan)"
        If Lang = "7C04" Then LangName = "Chinese (Traditional)"
        If Lang = "0483" Then LangName = "Corsican (France)"
        If Lang = "041A" Then LangName = "Croatian"
        If Lang = "101A" Then LangName = "Croatian (Latin, Bosnia and Herzegovina)"
        If Lang = "0405" Then LangName = "Czech"
        If Lang = "0406" Then LangName = "Danish"
        If Lang = "048C" Then LangName = "Dari (Afghanistan)"
        If Lang = "0465" Then LangName = "Divehi"
        If Lang = "0813" Then LangName = "Dutch (Belgium)"
        If Lang = "0413" Then LangName = "Dutch (Standard)"
        If Lang = "0C09" Then LangName = "English (Australia)"
        If Lang = "2809" Then LangName = "English (Belize)"
        If Lang = "1009" Then LangName = "English (Canada)"
        If Lang = "2409" Then LangName = "English (Caribbean)"
        If Lang = "4009" Then LangName = "English (India)"
        If Lang = "1809" Then LangName = "English (Ireland)"
        If Lang = "2009" Then LangName = "English (Jamaica)"
        If Lang = "4409" Then LangName = "English (Malaysia)"
        If Lang = "1409" Then LangName = "English (New Zealand)"
        If Lang = "3409" Then LangName = "English (Philippines)"
        If Lang = "4809" Then LangName = "English (Singapore)"
        If Lang = "1C09" Then LangName = "English (South Africa)"
        If Lang = "2C09" Then LangName = "English (Trinidad and Tobago)"
        If Lang = "0809" Then LangName = "English (United Kingdom)"
        If Lang = "0409" Then LangName = "English (United States)"
        If Lang = "3009" Then LangName = "English (Zimbabwe)"
        If Lang = "0425" Then LangName = "Estonian"
        If Lang = "0438" Then LangName = "Faroese"
        If Lang = "0429" Then LangName = "Farsi"
        If Lang = "0464" Then LangName = "Filipino (Philippines)"
        If Lang = "040B" Then LangName = "Finnish"
        If Lang = "080C" Then LangName = "French (Belgian)"
        If Lang = "0C0C" Then LangName = "French (Canadia)"
        If Lang = "040C" Then LangName = "French (Standard)"
        If Lang = "140C" Then LangName = "French (Luxembourg)"
        If Lang = "180C" Then LangName = "French (Monaco)"
        If Lang = "100C" Then LangName = "French (Swiss)"
        If Lang = "0462" Then LangName = "Frisian (Netherlands)"
        If Lang = "0456" Then LangName = "Galician"
        If Lang = "0437" Then LangName = "Georgian"
        If Lang = "0C07" Then LangName = "German (Austrian)"
        If Lang = "0407" Then LangName = "German (Standard)"
        If Lang = "1407" Then LangName = "German (Liechtenstein)"
        If Lang = "1007" Then LangName = "German (Luxembourg)"
        If Lang = "0807" Then LangName = "German (Swiss)"
        If Lang = "0408" Then LangName = "Greek"
        If Lang = "046F" Then LangName = "Greenlandic (Greenland)"
        If Lang = "0447" Then LangName = "Gujarati"
        If Lang = "0468" Then LangName = "Hausa (Latin, Nigeria)"
        If Lang = "040D" Then LangName = "Hebrew"
        If Lang = "0439" Then LangName = "Hindi"
        If Lang = "040E" Then LangName = "Hungarian"
        If Lang = "040F" Then LangName = "Icelandic"
        If Lang = "0470" Then LangName = "Igbo (Nigeria)"
        If Lang = "0421" Then LangName = "Indonesian"
        If Lang = "085D" Then LangName = "Inuktitut (Latin, Canada)"
        If Lang = "045D" Then LangName = "Inuktitut (Syllabics, Canada)"
        If Lang = "083C" Then LangName = "Irish (Ireland)"
        If Lang = "0434" Then LangName = "isiXhosa (South Africa)"
        If Lang = "0435" Then LangName = "isiZulu (South Africa)"
        If Lang = "0410" Then LangName = "Italian (Standard)"
        If Lang = "0810" Then LangName = "Italian (Swiss)"
        If Lang = "0411" Then LangName = "Japanese"
        If Lang = "044B" Then LangName = "Kannada"
        If Lang = "043F" Then LangName = "Kazakh"
        If Lang = "0453" Then LangName = "Khmer (Cambodia)"
        If Lang = "0486" Then LangName = "K'iche (Guatemala)"
        If Lang = "0487" Then LangName = "Kinyarwanda (Rwanda)"
        If Lang = "0457" Then LangName = "Konkani"
        If Lang = "0412" Then LangName = "Korean"
        If Lang = "0440" Then LangName = "Kyrgyz"
        If Lang = "0454" Then LangName = "Lao (Lao P.D.R.)"
        If Lang = "0426" Then LangName = "Latvian"
        If Lang = "0427" Then LangName = "Lithuanian"
        If Lang = "082E" Then LangName = "Lower Sorbian (Germany)"
        If Lang = "046E" Then LangName = "Luxembourgish (Luxembourg)"
        If Lang = "042F" Then LangName = "Macedonian"
        If Lang = "083E" Then LangName = "Malay (Brunei Darussalam)"
        If Lang = "043E" Then LangName = "Malay (Malaysia)"
        If Lang = "044C" Then LangName = "Malayalam (India)"
        If Lang = "043A" Then LangName = "Maltese (Malta)"
        If Lang = "0481" Then LangName = "Maori (New Zealand)"
        If Lang = "047A" Then LangName = "Mapudungun (Chile)"
        If Lang = "044E" Then LangName = "Marathi"
        If Lang = "047C" Then LangName = "Mohawk (Mohawk)"
        If Lang = "0450" Then LangName = "Mongolian (Cyrillic, Mongolia)"
        If Lang = "0850" Then LangName = "Mongolian (Traditional Mongolian, PRC)"
        If Lang = "0461" Then LangName = "Nepali (Nepal)"
        If Lang = "0414" Then LangName = "Norwegian (Bokmal)"
        If Lang = "0814" Then LangName = "Norwegian (Nynorsk)"
        If Lang = "0482" Then LangName = "Occitan (France)"
        If Lang = "0448" Then LangName = "Oriya (India)"
        If Lang = "0463" Then LangName = "Pashto (Afghanistan)"
        If Lang = "0429" Then LangName = "Persian"
        If Lang = "0415" Then LangName = "Polish"
        If Lang = "0416" Then LangName = "Portuguese (Brazilian)"
        If Lang = "0816" Then LangName = "Portuguese (Standard)"
        If Lang = "0446" Then LangName = "Punjabi"
        If Lang = "046B" Then LangName = "Quechua (Bolivia)"
        If Lang = "086B" Then LangName = "Quechua (Ecuador)"
        If Lang = "0C6B" Then LangName = "Quechua (Peru)"
        If Lang = "0418" Then LangName = "Romanian"
        If Lang = "0417" Then LangName = "Romansh (Switzerland)"
        If Lang = "0419" Then LangName = "Russian"
        If Lang = "243B" Then LangName = "Sami, Inari (Finland)"
        If Lang = "103B" Then LangName = "Sami, Lule (Norway)"
        If Lang = "143B" Then LangName = "Sami, Lule (Sweden)"
        If Lang = "0C3B" Then LangName = "Sami, Northern (Finland)"
        If Lang = "043B" Then LangName = "Sami, Northern (Norway)"
        If Lang = "083B" Then LangName = "Sami, Northern (Sweden)"
        If Lang = "203B" Then LangName = "Sami, Skolt (Finland)"
        If Lang = "183B" Then LangName = "Sami, Southern (Norway)"
        If Lang = "1C3B" Then LangName = "Sami, Southern (Sweden)"
        If Lang = "044F" Then LangName = "Sanskrit"
        If Lang = "1C1A" Then LangName = "Serbian (Cyrillic, Bosnia and Herzegovina)"
        If Lang = "0C1A" Then LangName = "Serbian (Cyrillic)"
        If Lang = "181A" Then LangName = "Serbian (Latin, Bosnia and Herzegovina)"
        If Lang = "081A" Then LangName = "Serbian (Latin)"
        If Lang = "046C" Then LangName = "Sesotho sa Leboa (South Africa)"
        If Lang = "0432" Then LangName = "Setswana (South Africa)"
        If Lang = "045B" Then LangName = "Sinhala (Sri Lanka)"
        If Lang = "041B" Then LangName = "Slovak"
        If Lang = "0424" Then LangName = "Slovenian"
        If Lang = "2C0A" Then LangName = "Spanish (Argentina)"
        If Lang = "400A" Then LangName = "Spanish (Bolivia)"
        If Lang = "340A" Then LangName = "Spanish (Chile)"
        If Lang = "240A" Then LangName = "Spanish (Colombia)"
        If Lang = "140A" Then LangName = "Spanish (Costa Rica)"
        If Lang = "1C0A" Then LangName = "Spanish (Dominican Republic)"
        If Lang = "300A" Then LangName = "Spanish (Ecuador)"
        If Lang = "440A" Then LangName = "Spanish (El Salvador)"
        If Lang = "100A" Then LangName = "Spanish (Guatemala)"
        If Lang = "480A" Then LangName = "Spanish (Honduras)"
        If Lang = "080A" Then LangName = "Spanish (Mexican)"
        If Lang = "4C0A" Then LangName = "Spanish (Nicaragua)"
        If Lang = "180A" Then LangName = "Spanish (Panama)"
        If Lang = "3C0A" Then LangName = "Spanish (Paraguay)"
        If Lang = "280A" Then LangName = "Spanish (Peru)"
        If Lang = "500A" Then LangName = "Spanish (Puerto Rico)"
        If Lang = "0C0A" Then LangName = "Spanish (Spain)"
        If Lang = "540A" Then LangName = "Spanish (United States)"
        If Lang = "380A" Then LangName = "Spanish (Uruguay)"
        If Lang = "200A" Then LangName = "Spanish (Venezuela)"
        If Lang = "0441" Then LangName = "Swahili"
        If Lang = "081D" Then LangName = "Swedish (Finland)"
        If Lang = "041D" Then LangName = "Swedish"
        If Lang = "045A" Then LangName = "Syriac"
        If Lang = "0428" Then LangName = "Tajik (Cyrillic, Tajikistan)"
        If Lang = "085F" Then LangName = "Tamazight (Latin, Algeria)"
        If Lang = "0449" Then LangName = "Tamil"
        If Lang = "0444" Then LangName = "Tatar"
        If Lang = "044A" Then LangName = "Telugu"
        If Lang = "041E" Then LangName = "Thai"
        If Lang = "0451" Then LangName = "Tibetan (PRC)"
        If Lang = "041F" Then LangName = "Turkish"
        If Lang = "0442" Then LangName = "Turkmen (Turkmenistan)"
        If Lang = "0480" Then LangName = "Uighur (PRC)"
        If Lang = "0422" Then LangName = "Ukrainian"
        If Lang = "042E" Then LangName = "Upper Sorbian (Germany)"
        If Lang = "0420" Then LangName = "Urdu"
        If Lang = "0843" Then LangName = "Uzbek (Cyrillic)"
        If Lang = "0443" Then LangName = "Uzbek (Latin)"
        If Lang = "042A" Then LangName = "Vietnamese"
        If Lang = "0452" Then LangName = "Welsh (United Kingdom)"
        If Lang = "0488" Then LangName = "Wolof (Senegal)"
        If Lang = "0485" Then LangName = "Yakut (Russia)"
        If Lang = "0478" Then LangName = "Yi (PRC)"
        If Lang = "046A" Then LangName = "Yoruba (Nigeria)"
        Return LangName
    End Function
    Private Function ConvertNameToCode(ByVal LangName As String) As String
        Dim Lang As String
        Lang = ""
        If LangName = "Afrikaans" Then Lang = "0436"
        If LangName = "Albanian" Then Lang = "041C"
        If LangName = "Alsatian (France)" Then Lang = "0484"
        If LangName = "Amharic (Ethiopia)" Then Lang = "045E"
        If LangName = "Arabic (Algeria)" Then Lang = "1401"
        If LangName = "Arabic (Bahrain)" Then Lang = "3C01"
        If LangName = "Arabic (Egypt)" Then Lang = "0C01"
        If LangName = "Arabic (Iraq)" Then Lang = "0801"
        If LangName = "Arabic (Jordan)" Then Lang = "2C01"
        If LangName = "Arabic (Kuwait)" Then Lang = "3401"
        If LangName = "Arabic (Lebanon)" Then Lang = "3001"
        If LangName = "Arabic (Libya)" Then Lang = "1001"
        If LangName = "Arabic (Morocco)" Then Lang = "1801"
        If LangName = "Arabic (Oman)" Then Lang = "2001"
        If LangName = "Arabic (Qatar)" Then Lang = "4001"
        If LangName = "Arabic (Saudi Arabia)" Then Lang = "0401"
        If LangName = "Arabic (Syria)" Then Lang = "2801"
        If LangName = "Arabic (Tunisia)" Then Lang = "1C01"
        If LangName = "Arabic (U.A.E.)" Then Lang = "3801"
        If LangName = "Arabic (Yemen)" Then Lang = "2401"
        If LangName = "Armenian" Then Lang = "042B"
        If LangName = "Assamese (India)" Then Lang = "044D"
        If LangName = "Azeri (Cyrillic)" Then Lang = "082C"
        If LangName = "Azeri (Latin)" Then Lang = "042C"
        If LangName = "Bashkir (Russia)" Then Lang = "046D"
        If LangName = "Basque" Then Lang = "042D"
        If LangName = "Belarusian" Then Lang = "0423"
        If LangName = "Bengali (Bangladesh)" Then Lang = "0845"
        If LangName = "Bengali (India)" Then Lang = "0445"
        If LangName = "Bosnian (Cyrillic, Bosnia and Herzegovina)" Then Lang = "201A"
        If LangName = "Bosnian (Latin, Bosnia and Herzegovina)" Then Lang = "141A"
        If LangName = "Breton (France)" Then Lang = "047E"
        If LangName = "Bulgarian" Then Lang = "0402"
        If LangName = "Catalan" Then Lang = "0403"
        If LangName = "Chinese (Hong Kong)" Then Lang = "0C04"
        If LangName = "Chinese (Macao)" Then Lang = "1404"
        If LangName = "Chinese (PRC)" Then Lang = "0804"
        If LangName = "Chinese (Simplified)" Then Lang = "0004"
        If LangName = "Chinese (Singapore)" Then Lang = "1004"
        If LangName = "Chinese (Taiwan)" Then Lang = "0404"
        If LangName = "Chinese (Traditional)" Then Lang = "7C04"
        If LangName = "Corsican (France)" Then Lang = "0483"
        If LangName = "Croatian" Then Lang = "041A"
        If LangName = "Croatian (Latin, Bosnia and Herzegovina)" Then Lang = "101A"
        If LangName = "Czech" Then Lang = "0405"
        If LangName = "Danish" Then Lang = "0406"
        If LangName = "Dari (Afghanistan)" Then Lang = "048C"
        If LangName = "Divehi" Then Lang = "0465"
        If LangName = "Dutch (Belgium)" Then Lang = "0813"
        If LangName = "Dutch (Standard)" Then Lang = "0413"
        If LangName = "English (Australia)" Then Lang = "0C09"
        If LangName = "English (Belize)" Then Lang = "2809"
        If LangName = "English (Canada)" Then Lang = "1009"
        If LangName = "English (Caribbean)" Then Lang = "2409"
        If LangName = "English (India)" Then Lang = "4009"
        If LangName = "English (Ireland)" Then Lang = "1809"
        If LangName = "English (Jamaica)" Then Lang = "2009"
        If LangName = "English (Malaysia)" Then Lang = "4409"
        If LangName = "English (New Zealand)" Then Lang = "1409"
        If LangName = "English (Philippines)" Then Lang = "3409"
        If LangName = "English (Singapore)" Then Lang = "4809"
        If LangName = "English (South Africa)" Then Lang = "1C09"
        If LangName = "English (Trinidad and Tobago)" Then Lang = "2C09"
        If LangName = "English (United Kingdom)" Then Lang = "0809"
        If LangName = "English (United States)" Then Lang = "0409"
        If LangName = "English (Zimbabwe)" Then Lang = "3009"
        If LangName = "Estonian" Then Lang = "0425"
        If LangName = "Faroese" Then Lang = "0438"
        If LangName = "Farsi" Then Lang = "0429"
        If LangName = "Filipino (Philippines)" Then Lang = "0464"
        If LangName = "Finnish" Then Lang = "040B"
        If LangName = "French (Belgian)" Then Lang = "080C"
        If LangName = "French (Canadia)" Then Lang = "0C0C"
        If LangName = "French (Standard)" Then Lang = "040C"
        If LangName = "French (Luxembourg)" Then Lang = "140C"
        If LangName = "French (Monaco)" Then Lang = "180C"
        If LangName = "French (Swiss)" Then Lang = "100C"
        If LangName = "Frisian (Netherlands)" Then Lang = "0462"
        If LangName = "Galician" Then Lang = "0456"
        If LangName = "Georgian" Then Lang = "0437"
        If LangName = "German (Austrian)" Then Lang = "0C07"
        If LangName = "German (Standard)" Then Lang = "0407"
        If LangName = "German (Liechtenstein)" Then Lang = "1407"
        If LangName = "German (Luxembourg)" Then Lang = "1007"
        If LangName = "German (Swiss)" Then Lang = "0807"
        If LangName = "Greek" Then Lang = "0408"
        If LangName = "Greenlandic (Greenland)" Then Lang = "046F"
        If LangName = "Gujarati" Then Lang = "0447"
        If LangName = "Hausa (Latin, Nigeria)" Then Lang = "0468"
        If LangName = "Hebrew" Then Lang = "040D"
        If LangName = "Hindi" Then Lang = "0439"
        If LangName = "Hungarian" Then Lang = "040E"
        If LangName = "Icelandic" Then Lang = "040F"
        If LangName = "Igbo (Nigeria)" Then Lang = "0470"
        If LangName = "Indonesian" Then Lang = "0421"
        If LangName = "Inuktitut (Latin, Canada)" Then Lang = "085D"
        If LangName = "Inuktitut (Syllabics, Canada)" Then Lang = "045D"
        If LangName = "Irish (Ireland)" Then Lang = "083C"
        If LangName = "isiXhosa (South Africa)" Then Lang = "0434"
        If LangName = "isiZulu (South Africa)" Then Lang = "0435"
        If LangName = "Italian (Standard)" Then Lang = "0410"
        If LangName = "Italian (Swiss)" Then Lang = "0810"
        If LangName = "Japanese" Then Lang = "0411"
        If LangName = "Kannada" Then Lang = "044B"
        If LangName = "Kazakh" Then Lang = "043F"
        If LangName = "Khmer (Cambodia)" Then Lang = "0453"
        If LangName = "K'iche (Guatemala)" Then Lang = "0486"
        If LangName = "Kinyarwanda (Rwanda)" Then Lang = "0487"
        If LangName = "Konkani" Then Lang = "0457"
        If LangName = "Korean" Then Lang = "0412"
        If LangName = "Kyrgyz" Then Lang = "0440"
        If LangName = "Lao (Lao P.D.R.)" Then Lang = "0454"
        If LangName = "Latvian" Then Lang = "0426"
        If LangName = "Lithuanian" Then Lang = "0427"
        If LangName = "Lower Sorbian (Germany)" Then Lang = "082E"
        If LangName = "Luxembourgish (Luxembourg)" Then Lang = "046E"
        If LangName = "Macedonian" Then Lang = "042F"
        If LangName = "Malay (Brunei Darussalam)" Then Lang = "083E"
        If LangName = "Malay (Malaysia)" Then Lang = "043E"
        If LangName = "Malayalam (India)" Then Lang = "044C"
        If LangName = "Maltese (Malta)" Then Lang = "043A"
        If LangName = "Maori (New Zealand)" Then Lang = "0481"
        If LangName = "Mapudungun (Chile)" Then Lang = "047A"
        If LangName = "Marathi" Then Lang = "044E"
        If LangName = "Mohawk (Mohawk)" Then Lang = "047C"
        If LangName = "Mongolian (Cyrillic, Mongolia)" Then Lang = "0450"
        If LangName = "Mongolian (Traditional Mongolian, PRC)" Then Lang = "0850"
        If LangName = "Nepali (Nepal)" Then Lang = "0461"
        If LangName = "Norwegian (Bokmal)" Then Lang = "0414"
        If LangName = "Norwegian (Nynorsk)" Then Lang = "0814"
        If LangName = "Occitan (France)" Then Lang = "0482"
        If LangName = "Oriya (India)" Then Lang = "0448"
        If LangName = "Pashto (Afghanistan)" Then Lang = "0463"
        If LangName = "Persian" Then Lang = "0429"
        If LangName = "Polish" Then Lang = "0415"
        If LangName = "Portuguese (Brazilian)" Then Lang = "0416"
        If LangName = "Portuguese (Standard)" Then Lang = "0816"
        If LangName = "Punjabi" Then Lang = "0446"
        If LangName = "Quechua (Bolivia)" Then Lang = "046B"
        If LangName = "Quechua (Ecuador)" Then Lang = "086B"
        If LangName = "Quechua (Peru)" Then Lang = "0C6B"
        If LangName = "Romanian" Then Lang = "0418"
        If LangName = "Romansh (Switzerland)" Then Lang = "0417"
        If LangName = "Russian" Then Lang = "0419"
        If LangName = "Sami, Inari (Finland)" Then Lang = "243B"
        If LangName = "Sami, Lule (Norway)" Then Lang = "103B"
        If LangName = "Sami, Lule (Sweden)" Then Lang = "143B"
        If LangName = "Sami, Northern (Finland)" Then Lang = "0C3B"
        If LangName = "Sami, Northern (Norway)" Then Lang = "043B"
        If LangName = "Sami, Northern (Sweden)" Then Lang = "083B"
        If LangName = "Sami, Skolt (Finland)" Then Lang = "203B"
        If LangName = "Sami, Southern (Norway)" Then Lang = "183B"
        If LangName = "Sami, Southern (Sweden)" Then Lang = "1C3B"
        If LangName = "Sanskrit" Then Lang = "044F"
        If LangName = "Serbian (Cyrillic)" Then Lang = "0C1A"
        If LangName = "Serbian (Latin)" Then Lang = "081A"
        If LangName = "Serbian (Cyrillic, Bosnia and Herzegovina)" Then Lang = "1C1A"
        If LangName = "Serbian (Cyrillic, Serbia)" Then Lang = "0C1A"
        If LangName = "Serbian (Latin, Bosnia and Herzegovina)" Then Lang = "181A"
        If LangName = "Serbian (Latin, Serbia)" Then Lang = "081A"
        If LangName = "Sesotho sa Leboa (South Africa)" Then Lang = "046C"
        If LangName = "Setswana (South Africa)" Then Lang = "0432"
        If LangName = "Sinhala (Sri Lanka)" Then Lang = "045B"
        If LangName = "Slovak" Then Lang = "041B"
        If LangName = "Slovenian" Then Lang = "0424"
        If LangName = "Spanish (Argentina)" Then Lang = "2C0A"
        If LangName = "Spanish (Bolivia)" Then Lang = "400A"
        If LangName = "Spanish (Chile)" Then Lang = "340A"
        If LangName = "Spanish (Colombia)" Then Lang = "240A"
        If LangName = "Spanish (Costa Rica)" Then Lang = "140A"
        If LangName = "Spanish (Dominican Republic)" Then Lang = "1C0A"
        If LangName = "Spanish (Ecuador)" Then Lang = "300A"
        If LangName = "Spanish (El Salvador)" Then Lang = "440A"
        If LangName = "Spanish (Guatemala)" Then Lang = "100A"
        If LangName = "Spanish (Honduras)" Then Lang = "480A"
        If LangName = "Spanish (Mexican)" Then Lang = "080A"
        If LangName = "Spanish (Nicaragua)" Then Lang = "4C0A"
        If LangName = "Spanish (Panama)" Then Lang = "180A"
        If LangName = "Spanish (Paraguay)" Then Lang = "3C0A"
        If LangName = "Spanish (Peru)" Then Lang = "280A"
        If LangName = "Spanish (Puerto Rico)" Then Lang = "500A"
        If LangName = "Spanish (Spain)" Then Lang = "0C0A"
        If LangName = "Spanish (United States)" Then Lang = "540A"
        If LangName = "Spanish (Uruguay)" Then Lang = "380A"
        If LangName = "Spanish (Venezuela)" Then Lang = "200A"
        If LangName = "Swahili" Then Lang = "0441"
        If LangName = "Swedish (Finland)" Then Lang = "081D"
        If LangName = "Swedish" Then Lang = "041D"
        If LangName = "Syriac" Then Lang = "045A"
        If LangName = "Tajik (Cyrillic, Tajikistan)" Then Lang = "0428"
        If LangName = "Tamazight (Latin, Algeria)" Then Lang = "085F"
        If LangName = "Tamil" Then Lang = "0449"
        If LangName = "Tatar" Then Lang = "0444"
        If LangName = "Telugu" Then Lang = "044A"
        If LangName = "Thai" Then Lang = "041E"
        If LangName = "Tibetan (PRC)" Then Lang = "0451"
        If LangName = "Turkish" Then Lang = "041F"
        If LangName = "Turkmen (Turkmenistan)" Then Lang = "0442"
        If LangName = "Uighur (PRC)" Then Lang = "0480"
        If LangName = "Ukrainian" Then Lang = "0422"
        If LangName = "Upper Sorbian (Germany)" Then Lang = "042E"
        If LangName = "Urdu" Then Lang = "0420"
        If LangName = "Uzbek (Cyrillic)" Then Lang = "0843"
        If LangName = "Uzbek (Latin)" Then Lang = "0443"
        If LangName = "Vietnamese" Then Lang = "042A"
        If LangName = "Welsh (United Kingdom)" Then Lang = "0452"
        If LangName = "Wolof (Senegal)" Then Lang = "0488"
        If LangName = "Yakut (Russia)" Then Lang = "0485"
        If LangName = "Yi (PRC)" Then Lang = "0478"
        If LangName = "Yoruba (Nigeria)" Then Lang = "046A"
        Return Lang
    End Function
    Public Function inthelist(ByVal checklocale As String) As Boolean
        Dim temploop
        inthelist = False
        For temploop = 1 To Dialog3.ComboBox1.Items.Count
            If checklocale = Dialog3.ComboBox1.Items.Item(temploop - 1) Then
                inthelist = True
            End If
        Next
        Return inthelist
    End Function
    Private Sub ExportAsInKeyKeyboardFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportAsInKeyKeyboardFileToolStripMenuItem.Click
        Dim result
        Dim temploop, rotanum, i As Integer
        Dim KeyboardFoldername, KeyboardFolderpath, KeyboardFilename, IconFileName As String
        Dim IniFilename As String
        Dim hotkey, hotkeycontents, firstcharinhex, nextcharinhex, onloadscript, mainscript, deadkeycontents, firstcharindeadkeyhex, deadkey2contents, firstcharindeadkey2hex As String
        Dim aryTextFile() As String
        Dim elseneeded As Boolean

        If DeadKeys Then
            If ((ActivateDeadkeyToolStripMenuItem.Checked) And (DeadKey < 1)) Then
                result = MsgBox("Error: You have activated the deadkey, but" + Chr(10) + "you have not chosen your dead key yet.", MsgBoxStyle.Exclamation, "InKey Keyboard Creator")
                Exit Sub
            End If
            If ((DeadkeysToolStripMenuItem.Checked) And ((DeadKey2 < 1) Or (DeadKey < 1))) Then
                If ((DeadKey < 1) And (DeadKey2 > 0)) Then
                    result = MsgBox("Error: You have activated 2 deadkeys, but" + Chr(10) + "you have not chosen your first dead key yet.", MsgBoxStyle.Exclamation, "InKey Keyboard Creator")
                ElseIf ((DeadKey > 0) And (DeadKey2 < 1)) Then
                    result = MsgBox("Error: You have activated 2 deadkeys, but" + Chr(10) + "you have not chosen your second dead key yet.", MsgBoxStyle.Exclamation, "InKey Keyboard Creator")
                Else
                    result = MsgBox("Error: You have activated 2 deadkeys, but" + Chr(10) + "you have not chosen either dead key yet.", MsgBoxStyle.Exclamation, "InKey Keyboard Creator")
                End If
                Exit Sub
            End If

        End If

        result = MsgBox("Please check to make sure that all the keyboard settings are correct," + Chr(10) + "then click the OK button to export.", MsgBoxStyle.OkOnly, "InKey Keyboard Creator")
        result = Form3.ShowDialog()
        If result = System.Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        SaveFileDialog2.Filter = "Inkey Keyboard Files (*.inkey)|*.inkey|All files (*.*)|*.*"
        SaveFileDialog2.FilterIndex = 1
        SaveFileDialog2.FileName = Replace(Form3.TextBox1.Text, " ", "")
        If SaveFileDialog2.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Delete existing file
            If IO.File.Exists(SaveFileDialog2.FileName) Then
                IO.File.Delete(SaveFileDialog2.FileName)
            End If

            ' Create temporary folder
            KeyboardFoldername = Replace(Form3.TextBox1.Text, " ", "")
            KeyboardFolderpath = System.IO.Path.GetTempPath & "\" & KeyboardFoldername
            If Directory.Exists(KeyboardFolderpath) Then
                Directory.Delete(KeyboardFolderpath, True)
            End If
            Directory.CreateDirectory(KeyboardFolderpath)
            ChDir(KeyboardFolderpath)

            KeyboardFilename = Replace(Form3.TextBox1.Text, " ", "")
            Using sw As StreamWriter = New StreamWriter("Class.ini")
                sw.WriteLine("[Class]")
                sw.WriteLine("Cmd=" + KeyboardFilename + ".ahk")
                sw.WriteLine("UsesParams=0")
                sw.WriteLine("MultiInstance=0")
            End Using
            IniFilename = Form3.TextBox1.Text + " InKey.kbd.ini"
            Using sw As StreamWriter = New StreamWriter(IniFilename)
                sw.WriteLine("[Keyboard]")
                sw.WriteLine("Enabled=0")
                sw.WriteLine("LayoutName=" + Form3.TextBox1.Text)
                sw.WriteLine("MenuText=" + Form3.TextBox2.Text)
                sw.WriteLine("Hotkey=" + Form3.TextBox3.Text)
                sw.WriteLine("Lang=" + ConvertNameToCode(Form3.TextBox4.Text))
                If Form3.Button2.Enabled = True Then
                    sw.WriteLine("AltLang=" + ConvertNameToCode(Form3.TextBox5.Text))
                End If
                If Form3.TextBox6.Text = "" Then
                    IconFileName = Application.StartupPath + "\Generic.ico"
                Else
                    IconFileName = Form3.TextBox6.Text
                End If
                Dim oFileInfo As New System.IO.FileInfo(IconFileName)

                My.Computer.FileSystem.CopyFile(oFileInfo.FullName, KeyboardFolderpath + "\" + KeyboardFilename + oFileInfo.Extension, True)
                sw.WriteLine("Icon=" + KeyboardFilename + oFileInfo.Extension)

            End Using
            Using sw As StreamWriter = New StreamWriter(KeyboardFilename + ".ahk", False, System.Text.Encoding.UTF8)
                ' generate header for ahk file
                sw.WriteLine("/*	InKey script to provide a keyboard layout for " + Form3.TextBox1.Text)
                sw.WriteLine("      Autogenerated by InKeyKeyboardCreator")
                sw.WriteLine("")
                sw.WriteLine("	Keyboard:	" + Form3.TextBox1.Text)
                sw.WriteLine("	Version:    1.0")
                sw.WriteLine("	Author:     ")
                sw.WriteLine("	Official Distribution: http://inkeysoftware.com")
                sw.WriteLine("")
                sw.WriteLine("*/")
                sw.WriteLine("")
                sw.WriteLine(";________________________________________________________________________________________________________________")
                sw.WriteLine("; This section is required at the top of every InKey keyboard script:")
                sw.WriteLine("")
                sw.WriteLine("K_MinimumInKeyLibVersion = 0.092")
                sw.WriteLine("      ; The version number of the InKeyLib.ahki file that the keyboard developer used while writing this script.")
                sw.WriteLine("      ; It can be found near the top of the InKeyLib.ahki file.")
                sw.WriteLine("      ; It may be lower than the InKey version number.")
                sw.WriteLine("      ; If a user has an older version of InKeyLib.ahki, he will need to update it in order to use this keyboard script.")
                sw.WriteLine("      ; This protects your script from crashing from attempting to use functionality not present in older versions of InKeyLib.ahki.")
                sw.WriteLine("")
                sw.WriteLine("K_UseContext = 1  ; Causes uncaptured character keys to be included in the context too.")
                sw.WriteLine("")
                sw.WriteLine("#include InKeyLib.ahki")
                sw.WriteLine(";________________________________________________________________________________________________________________")
                sw.WriteLine("")
                sw.WriteLine("")

                ' parse all keys generating two strings:
                '  onloadscript contains the rotas (if any)
                '  mainscript contains the hotkeys
                rotanum = 0
                onloadscript = ""
                mainscript = ""

                ' unshifted keys (no ctrl, no alt) - potentially involves deadkey!
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContents(temploop)
                    deadkeycontents = KeyContentsDeadkey(temploop)
                    deadkey2contents = KeyContentsDeadkey2(temploop)
                    If ((hotkeycontents <> "") Or (deadkeycontents <> "") Or (deadkey2contents <> "") Or (temploop = DeadKey) Or (temploop = DeadKey2)) Then
                        firstcharinhex = 0
                        If hotkeycontents <> "" Then firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 0)
                        If mainscript = "" Then
                            mainscript = hotkey + Chr(10)
                        Else
                            mainscript = mainscript + Chr(10) + hotkey + Chr(10)
                        End If
                        If DeadKeys Then
                            firstcharindeadkeyhex = 0
                            firstcharindeadkey2hex = 0
                            elseneeded = False
                            If deadkeycontents <> "" Then
                                firstcharindeadkeyhex = Conversion.Hex(Strings.AscW(Mid(deadkeycontents, 1, 1)))
                                mainscript = mainscript + "if (flags()=96) {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharindeadkeyhex + ")  ;| " + Mid(deadkeycontents, 1, 1) + Chr(10)
                                elseneeded = True
                                If (Len(deadkeycontents) > 1) Then
                                    For i = 2 To Len(deadkeycontents)
                                        nextcharinhex = Conversion.Hex(Strings.AscW(Mid(deadkeycontents, i, 1)))
                                        mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(deadkeycontents, i, 1) + Chr(10)
                                    Next
                                End If
                            End If
                            If deadkey2contents <> "" Then
                                firstcharindeadkey2hex = Conversion.Hex(Strings.AscW(Mid(deadkey2contents, 1, 1)))
                                If elseneeded Then mainscript = mainscript + "} else "
                                mainscript = mainscript + "if (flags()=84) {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharindeadkey2hex + ")  ;| " + Mid(deadkey2contents, 1, 1) + Chr(10)
                                elseneeded = True
                                If (Len(deadkey2contents) > 1) Then
                                    For i = 2 To Len(deadkey2contents)
                                        nextcharinhex = Conversion.Hex(Strings.AscW(Mid(deadkey2contents, i, 1)))
                                        mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(deadkey2contents, i, 1) + Chr(10)
                                    Next
                                End If
                            End If

                            If temploop = DeadKey Then
                                If elseneeded Then
                                    mainscript = mainscript + "} else {" + Chr(10)
                                    mainscript = mainscript + Chr(9) + "SendChar(1,96) ;| This is the deadkey" + Chr(10)
                                Else
                                    mainscript = mainscript + "SendChar(1,96) ;| This is the deadkey" + Chr(10)
                                End If
                            ElseIf temploop = DeadKey2 Then
                                If elseneeded Then
                                    mainscript = mainscript + "} else {" + Chr(10)
                                    mainscript = mainscript + Chr(9) + "SendChar(1,84) ;| This is another deadkey" + Chr(10)
                                Else
                                    mainscript = mainscript + "SendChar(1,84) ;| This is another deadkey" + Chr(10)
                                End If
                            End If
                        End If
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppress(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If DeadKeys And elseneeded Then
                                mainscript = mainscript + "} else {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "DoRota(" + Trim(Str(rotanum)) + ")" + Chr(10)
                            Else
                                mainscript = mainscript + "DoRota(" + Trim(Str(rotanum)) + ")" + Chr(10)
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If DeadKeys And elseneeded Then
                                mainscript = mainscript + "} else {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1) + Chr(10)
                            Else
                                mainscript = mainscript + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1) + Chr(10)
                            End If
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                If DeadKeys And elseneeded Then
                                    mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1) + Chr(10)
                                Else
                                    mainscript = mainscript + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1) + Chr(10)
                                End If
                            Next
                        Else
                            ' Only one character to generate
                            If (hotkeycontents <> "") Then
                                If DeadKeys Then
                                    If ((temploop <> DeadKey) And (temploop <> DeadKey2)) Then
                                        If (elseneeded) Then
                                            mainscript = mainscript + "} else {" + Chr(10)
                                            mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents + Chr(10)
                                        Else
                                            mainscript = mainscript + "SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents + Chr(10)
                                        End If
                                    End If
                                Else
                                    mainscript = mainscript + "SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents + Chr(10)
                                End If
                            End If
                        End If
                        If elseneeded Then
                            mainscript = mainscript + "}" + Chr(10)
                        End If
                        mainscript = mainscript + "return"
                    End If
                Next

                ' shifted keys (no ctrl, no alt) - potentially involves deadkey!
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShift(temploop)
                    deadkeycontents = KeyContentsDeadkeyShift(temploop)
                    deadkey2contents = KeyContentsDeadkey2Shift(temploop)
                    If ((hotkeycontents <> "") Or (deadkeycontents <> "") Or (deadkey2contents <> "")) Then
                        firstcharinhex = 0
                        If hotkeycontents <> "" Then firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 1)
                        If mainscript = "" Then
                            mainscript = hotkey + Chr(10)
                        Else
                            mainscript = mainscript + Chr(10) + hotkey + Chr(10)
                        End If
                        If DeadKeys Then
                            firstcharindeadkeyhex = 0
                            firstcharindeadkey2hex = 0
                            elseneeded = False
                            If deadkeycontents <> "" Then
                                firstcharindeadkeyhex = Conversion.Hex(Strings.AscW(Mid(deadkeycontents, 1, 1)))
                                mainscript = mainscript + "if (flags()=96) {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharindeadkeyhex + ")  ;| " + Mid(deadkeycontents, 1, 1) + Chr(10)
                                elseneeded = True
                                If (Len(deadkeycontents) > 1) Then
                                    For i = 2 To Len(deadkeycontents)
                                        nextcharinhex = Conversion.Hex(Strings.AscW(Mid(deadkeycontents, i, 1)))
                                        mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(deadkeycontents, i, 1) + Chr(10)
                                    Next
                                End If
                            End If
                            If deadkey2contents <> "" Then
                                firstcharindeadkey2hex = Conversion.Hex(Strings.AscW(Mid(deadkey2contents, 1, 1)))
                                If elseneeded Then mainscript = mainscript + "} else "
                                mainscript = mainscript + "if (flags()=84) {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharindeadkey2hex + ")  ;| " + Mid(deadkey2contents, 1, 1) + Chr(10)
                                elseneeded = True
                                If (Len(deadkey2contents) > 1) Then
                                    For i = 2 To Len(deadkey2contents)
                                        nextcharinhex = Conversion.Hex(Strings.AscW(Mid(deadkey2contents, i, 1)))
                                        mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(deadkey2contents, i, 1) + Chr(10)
                                    Next
                                End If
                            End If
                        End If
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppress(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If DeadKeys And elseneeded Then
                                mainscript = mainscript + "} else {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "DoRota(" + Trim(Str(rotanum)) + ")" + Chr(10)
                            Else
                                mainscript = mainscript + "DoRota(" + Trim(Str(rotanum)) + ")" + Chr(10)
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If DeadKeys And elseneeded Then
                                mainscript = mainscript + "} else {" + Chr(10)
                                mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1) + Chr(10)
                            Else
                                mainscript = mainscript + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1) + Chr(10)
                            End If
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                If DeadKeys And elseneeded Then
                                    mainscript = mainscript + Chr(9) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1) + Chr(10)
                                Else
                                    mainscript = mainscript + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1) + Chr(10)
                                End If
                            Next
                        Else
                            ' Only one character to generate
                            If (hotkeycontents <> "") Then
                                If (DeadKeys And elseneeded) Then
                                    mainscript = mainscript + "} else {" + Chr(10)
                                    mainscript = mainscript + Chr(9) + "SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents + Chr(10)
                                Else
                                    mainscript = mainscript + "SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents + Chr(10)
                                End If
                            End If
                        End If
                        If elseneeded Then
                            mainscript = mainscript + "}" + Chr(10)
                        End If
                        mainscript = mainscript + "return"
                    End If
                Next

                ' unshifted keys (ctrl, no alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsCtrl(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 2)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressCtrl(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' shifted keys (ctrl, no alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShiftCtrl(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 3)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressShiftCtrl(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' unshifted keys (no ctrl, alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsAlt(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 4)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressAlt(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' shifted keys (no ctrl, alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShiftAlt(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 5)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressShiftAlt(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' unshifted keys (ctrl, alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsCtrlAlt(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 6)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressCtrlAlt(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' shifted keys (ctrl, alt)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShiftCtrlAlt(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 7)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressShiftCtrlAlt(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' unshifted keys (no ctrl, altgr)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsAltGr(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 8)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressAltGr(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' shifted keys (no ctrl, altgr)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShiftAltGr(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 9)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressShiftAltGr(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' unshifted keys (ctrl, altgr)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsCtrlAltGr(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 10)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressCtrlAltGr(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' shifted keys (ctrl, altgr)
                For temploop = 1 To NumKeys
                    hotkeycontents = KeyContentsShiftCtrlAltGr(temploop)
                    If hotkeycontents <> "" Then
                        firstcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, 1, 1)))
                        hotkey = FromNumToHotkey(temploop, 11)
                        If ((hotkeycontents.Contains(" ")) And Not KeyRotaSuppressShiftCtrlAltGr(temploop)) Then
                            ' Rota needed
                            rotanum = rotanum + 1
                            hotkeycontents = Replace(hotkeycontents, ";", "`;")
                            hotkeycontents = Replace(hotkeycontents, """", """""")
                            If onloadscript = "" Then
                                onloadscript = "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            Else
                                onloadscript = onloadscript + Chr(10) + "RegisterRota(" + Trim(Str(rotanum)) + ", """ + hotkeycontents + """, 0x" + firstcharinhex + ", 0, 0, 8)  ;| " + hotkeycontents
                            End If
                            If mainscript = "" Then
                                mainscript = hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " DoRota(" + Trim(Str(rotanum)) + ")"
                            End If
                        ElseIf (Len(hotkeycontents) > 1) Then
                            ' Rota not needed, but key needs to generate more than one character
                            If mainscript = "" Then
                                mainscript = hotkey
                            Else
                                mainscript = mainscript + Chr(10) + hotkey
                            End If
                            mainscript = mainscript + Chr(10) + "SendChar(0x" + firstcharinhex + ")  ;| " + Mid(hotkeycontents, 1, 1)
                            For i = 2 To Len(hotkeycontents)
                                nextcharinhex = Conversion.Hex(Strings.AscW(Mid(hotkeycontents, i, 1)))
                                mainscript = mainscript + Chr(10) + "SendChar(0x" + nextcharinhex + ")  ;| " + Mid(hotkeycontents, i, 1)
                            Next
                            mainscript = mainscript + Chr(10) + "return"
                        Else
                            ' Only one character to generate
                            If mainscript = "" Then
                                mainscript = hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            Else
                                mainscript = mainscript + Chr(10) + hotkey + " SendChar(0x" + firstcharinhex + ")  ;| " + hotkeycontents
                            End If
                        End If
                    End If
                Next

                ' write out rota registrations (if any) to file
                If onloadscript <> "" Then
                    sw.WriteLine("OnLoadScript:")
                    aryTextFile = onloadscript.Split(Chr(10))
                    For temploop = 0 To UBound(aryTextFile)
                        sw.WriteLine(aryTextFile(temploop))
                    Next temploop
                    sw.WriteLine("return")
                    sw.WriteLine(";________________________________________________________________________________________________________________")
                    sw.WriteLine("")
                End If

                ' write out hotkeys to file
                aryTextFile = mainscript.Split(Chr(10))
                For temploop = 0 To UBound(aryTextFile)
                    sw.WriteLine(aryTextFile(temploop))
                Next temploop
            End Using

            Try
                Using zip As ZipFile = New ZipFile
                    zip.AddDirectory(KeyboardFolderpath, KeyboardFilename)
                    zip.Save(SaveFileDialog2.FileName)
                End Using
            Catch ex1 As Exception
                Console.Error.WriteLine("exception: {0}", ex1.ToString)
            End Try

            MsgBox("Export completed successfully.", MsgBoxStyle.OkOnly, "InKey Keyboard Creator")
        End If
    End Sub
    Private Function FromNumToHotkey(ByVal Num As Integer, ByVal Extras As Integer) As String
        ' Extras: 1 - SHIFT, 2 - CTRL, 4 - ALT (add 4 for ALTGR)
        Dim Key As String
        Dim shifted As Boolean
        Dim ctrled As Boolean
        Dim alted As Boolean
        Dim altgred As Boolean

        Key = ""
        shifted = False
        ctrled = False
        alted = False
        altgred = False

        If Extras > 7 Then
            ' ALTGR
            If Extras = 8 Or Extras = 9 Or Extras = 10 Or Extras = 11 Then
                altgred = True
            End If
            Extras = Extras - 4
        Else
            If Extras = 4 Or Extras = 5 Or Extras = 6 Or Extras = 7 Then
                alted = True
            End If
        End If

        If Extras = 1 Or Extras = 3 Or Extras = 5 Or Extras = 7 Then
            shifted = True
        End If
        If Extras = 2 Or Extras = 3 Or Extras = 6 Or Extras = 7 Then
            ctrled = True
        End If

        If Num = 1 Then
            If shifted Then
                Key = "~"
            Else
                Key = "`"
            End If
        End If
        If Num = 2 Then
            If shifted Then
                Key = "!"
            Else
                Key = "1"
            End If
        End If
        If Num = 3 Then
            If shifted Then
                Key = "@"
            Else
                Key = "2"
            End If
        End If
        If Num = 4 Then
            If shifted Then
                Key = "#"
            Else
                Key = "3"
            End If
        End If
        If Num = 5 Then
            If shifted Then
                Key = "$"
            Else
                Key = "4"
            End If
        End If
        If Num = 6 Then
            If shifted Then
                Key = "%"
            Else
                Key = "5"
            End If
        End If
        If Num = 7 Then
            If shifted Then
                Key = "^"
            Else
                Key = "6"
            End If
        End If
        If Num = 8 Then
            If shifted Then
                Key = "&"
            Else
                Key = "7"
            End If
        End If
        If Num = 9 Then
            If shifted Then
                Key = "*"
            Else
                Key = "8"
            End If
        End If
        If Num = 10 Then
            If shifted Then
                Key = "("
            Else
                Key = "9"
            End If
        End If
        If Num = 11 Then
            If shifted Then
                Key = ")"
            Else
                Key = "0"
            End If
        End If
        If Num = 12 Then
            If shifted Then
                Key = "_"
            Else
                Key = "-"
            End If
        End If
        If Num = 13 Then
            If shifted Then
                Key = "+"
            Else
                Key = "="
            End If
        End If
        If Num = 14 Then
            If shifted Then
                Key = "|"
            Else
                Key = "\"
            End If
        End If
        If Num = 15 Then
            If shifted Then
                Key = "+q"
            Else
                Key = "q"
            End If
        End If
        If Num = 16 Then
            If shifted Then
                Key = "+w"
            Else
                Key = "w"
            End If
        End If
        If Num = 17 Then
            If shifted Then
                Key = "+e"
            Else
                Key = "e"
            End If
        End If
        If Num = 18 Then
            If shifted Then
                Key = "+r"
            Else
                Key = "r"
            End If
        End If
        If Num = 19 Then
            If shifted Then
                Key = "+t"
            Else
                Key = "t"
            End If
        End If
        If Num = 20 Then
            If shifted Then
                Key = "+y"
            Else
                Key = "y"
            End If
        End If
        If Num = 21 Then
            If shifted Then
                Key = "+u"
            Else
                Key = "u"
            End If
        End If
        If Num = 22 Then
            If shifted Then
                Key = "+i"
            Else
                Key = "i"
            End If
        End If
        If Num = 23 Then
            If shifted Then
                Key = "+o"
            Else
                Key = "o"
            End If
        End If
        If Num = 24 Then
            If shifted Then
                Key = "+p"
            Else
                Key = "p"
            End If
        End If
        If Num = 25 Then
            If shifted Then
                Key = "{"
            Else
                Key = "["
            End If
        End If
        If Num = 26 Then
            If shifted Then
                Key = "}"
            Else
                Key = "]"
            End If
        End If
        If Num = 27 Then
            If shifted Then
                Key = "+a"
            Else
                Key = "a"
            End If
        End If
        If Num = 28 Then
            If shifted Then
                Key = "+s"
            Else
                Key = "s"
            End If
        End If
        If Num = 29 Then
            If shifted Then
                Key = "+d"
            Else
                Key = "d"
            End If
        End If
        If Num = 30 Then
            If shifted Then
                Key = "+f"
            Else
                Key = "f"
            End If
        End If
        If Num = 31 Then
            If shifted Then
                Key = "+g"
            Else
                Key = "g"
            End If
        End If
        If Num = 32 Then
            If shifted Then
                Key = "+h"
            Else
                Key = "h"
            End If
        End If
        If Num = 33 Then
            If shifted Then
                Key = "+j"
            Else
                Key = "j"
            End If
        End If
        If Num = 34 Then
            If shifted Then
                Key = "+k"
            Else
                Key = "k"
            End If
        End If
        If Num = 35 Then
            If shifted Then
                Key = "+l"
            Else
                Key = "l"
            End If
        End If
        If Num = 36 Then
            If shifted Then
                Key = "+`;"
            Else
                Key = "`;"
            End If
        End If
        If Num = 37 Then
            If shifted Then
                Key = """"
            Else
                Key = "'"
            End If
        End If
        If Num = 38 Then
            If shifted Then
                Key = "+z"
            Else
                Key = "z"
            End If
        End If
        If Num = 39 Then
            If shifted Then
                Key = "+x"
            Else
                Key = "x"
            End If
        End If
        If Num = 40 Then
            If shifted Then
                Key = "+c"
            Else
                Key = "c"
            End If
        End If
        If Num = 41 Then
            If shifted Then
                Key = "+v"
            Else
                Key = "v"
            End If
        End If
        If Num = 42 Then
            If shifted Then
                Key = "+b"
            Else
                Key = "b"
            End If
        End If
        If Num = 43 Then
            If shifted Then
                Key = "+n"
            Else
                Key = "n"
            End If
        End If
        If Num = 44 Then
            If shifted Then
                Key = "+m"
            Else
                Key = "m"
            End If
        End If
        If Num = 45 Then
            If shifted Then
                Key = "<"
            Else
                Key = ","
            End If
        End If
        If Num = 46 Then
            If shifted Then
                Key = ">"
            Else
                Key = "."
            End If
        End If
        If Num = 47 Then
            If shifted Then
                Key = "?"
            Else
                Key = "/"
            End If
        End If
        If altgred Then
            If AltGr = True Then
                Key = "<^>!" + Key
            Else
                Key = ">!" + Key
            End If
        ElseIf alted Then
            Key = "!" + Key
        End If
        If ctrled Then
            Key = "^" + Key
        End If
        Key = "$" + Key + "::"
        Return Key
    End Function
    Private Function AddSpaces(ByVal contents As String) As String
        Dim result As String
        Dim i As Integer

        ' note that contents must always be a string of at least 2 characters
        result = Mid(contents, 1, 1)
        For i = 2 To Len(contents)
            result = result + " " + Mid(contents, i, 1)
        Next
        Return result
    End Function

    Private Sub AttemptToImportFromKeymanSourceFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttemptToImportFromKeymanSourceFileToolStripMenuItem.Click
        Dim temploop, i, j, KeyNum, CharCode As Integer
        Dim nextline, NewKey, NewKeyString, OutputString, OutputCode As String
        Dim deadkeyspresent, keyfound, outputfound, shifted, alted As Boolean
        Dim dialogresult
        Dim unassigned As String

        If projectchanged Then
            dialogresult = Dialog4.ShowDialog
            If dialogresult = Windows.Forms.DialogResult.Yes Then
                SaveProject()
            ElseIf dialogresult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

        OpenFileDialog1.Filter = "Keyman Source Files (*.kmn)|*.kmn"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            ButtonShift.Checked = False
            ButtonCtrl.Checked = False
            ButtonAlt.Checked = False
            Form3.TextBox1.Text = ""
            Form3.TextBox2.Text = ""
            Form3.TextBox3.Text = ""
            Form3.TextBox4.Text = ""
            Form3.TextBox5.Text = ""
            Form3.TextBox6.Text = ""
            Form3.Button2.Enabled = False
            Form3.PictureBox1.Image = Nothing

            ' clear all key contents arrays
            For temploop = 1 To NumKeys
                KeyContents(temploop) = ""
                KeyContentsShift(temploop) = ""
                KeyContentsCtrl(temploop) = ""
                KeyContentsAlt(temploop) = ""
                KeyContentsShiftCtrl(temploop) = ""
                KeyContentsShiftAlt(temploop) = ""
                KeyContentsCtrlAlt(temploop) = ""
                KeyContentsShiftCtrlAlt(temploop) = ""
                KeyContentsAltGr(temploop) = ""
                KeyContentsShiftAltGr(temploop) = ""
                KeyContentsCtrlAltGr(temploop) = ""
                KeyContentsShiftCtrlAltGr(temploop) = ""
            Next

            AltGr = False
            ButtonAlt.Text = "Alt"
            ButtonAltGr.Text = "AltGr"
            ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle Alt/AltGr to LAlt/RAlt"

            projectchanged = False
            deadkeyspresent = False
            unassigned = ""

            Using sr As StreamReader = New StreamReader(OpenFileDialog1.OpenFile())
                While Not sr.EndOfStream
                    nextline = sr.ReadLine()
                    If Mid(nextline, 1, 4) = "NAME" Then
                        Form3.TextBox1.Text = Mid(nextline, 7, Len(nextline) - 7)
                        Form3.TextBox2.Text = "&" + Form3.TextBox1.Text
                    ElseIf Mid(nextline, 1, 6) = "HOTKEY" Then
                        Form3.TextBox3.Text = Mid(nextline, 9, Len(nextline) - 9)
                    ElseIf ((Mid(nextline, 1, 7) = "deadkey") Or (Mid(nextline, 1, 2) = "dk")) Then
                        If Not deadkeyspresent Then
                            deadkeyspresent = True
                            MsgBox("The KMN file you are attempting to import uses deadkeys." + Chr(10) + "This import process does not support deadkeys." + Chr(10) + "The import process will try and add deadkey characters to a rota instead.", MsgBoxStyle.OkOnly, "InKey Keyboard Creator")
                        End If
                    ElseIf ((Mid(nextline, 1, 1) = "+") Or (Mid(nextline, 1, 2) = " +")) Then
                        keyfound = False
                        outputfound = False
                        NewKey = ""
                        NewKeyString = ""
                        OutputString = ""
                        shifted = False
                        alted = False
                        For i = 1 To Len(nextline)
                            ' Look for key indicated by inverted commas
                            If (((Mid(nextline, i, 1) = "'") Or (Mid(nextline, i, 1) = """")) And Not keyfound) Then
                                NewKey = Mid(nextline, i + 1, 1)
                                NewKeyString = ""
                                keyfound = True
                            End If
                            ' Look for key indicated by square brackets (K_ format)
                            If ((Mid(nextline, i, 1) = "[") And Not keyfound) Then
                                j = i + 1
                                While (Mid(nextline, j, 1) <> "]")
                                    j = j + 1
                                End While
                                NewKeyString = Mid(nextline, i + 1, j - i - 1)
                                'MsgBox("NewKeyString: " + NewKeyString)
                                NewKey = ""
                                keyfound = True
                            End If
                            If (Mid(nextline, i, 1) = ">") Then
                                OutputString = Mid(nextline, i + 1, Len(nextline) - i)
                                outputfound = True
                            End If
                        Next
                        If keyfound And outputfound Then
                            If NewKey <> "" Then KeyNum = ProcessNewKey(NewKey, shifted)
                            If NewKeyString <> "" Then KeyNum = ProcessNewKeyString(NewKeyString, shifted, alted)
                            If KeyNum = 0 Then
                                i = 1
                                While (i <= Len(OutputString))
                                    If Mid(OutputString, i, 2) = "U+" Then
                                        OutputCode = Mid(OutputString, i + 2, 4)
                                        CharCode = Integer.Parse(OutputCode, Globalization.NumberStyles.AllowHexSpecifier)
                                        If unassigned = "" Then
                                            unassigned = ChrW(CharCode)
                                        Else
                                            unassigned = unassigned + " " + ChrW(CharCode)
                                        End If
                                    End If
                                    i = i + 1
                                End While
                            Else
                                i = 1
                                While (i <= Len(OutputString))
                                    If Mid(OutputString, i, 2) = "U+" Then
                                        OutputCode = Mid(OutputString, i + 2, 4)
                                        CharCode = Integer.Parse(OutputCode, Globalization.NumberStyles.AllowHexSpecifier)
                                        If shifted Then
                                            KeyContentsShift(KeyNum) = KeyContentsShift(KeyNum) + ChrW(CharCode)
                                        ElseIf alted Then
                                            KeyContentsAlt(KeyNum) = KeyContentsAlt(KeyNum) + ChrW(CharCode)
                                        Else
                                            KeyContents(KeyNum) = KeyContents(KeyNum) + ChrW(CharCode)
                                        End If
                                    End If
                                    i = i + 1
                                End While
                            End If
                        ElseIf Not keyfound And outputfound Then
                            'add found character to unassigned character list
                            CharCode = Integer.Parse(OutputString, Globalization.NumberStyles.AllowHexSpecifier)
                            If unassigned = "" Then
                                unassigned = ChrW(CharCode)
                            Else
                                unassigned = unassigned + " " + ChrW(CharCode)
                            End If
                        End If
                    Else
                        'search for "stray" unicode characters to add to unassigned
                        outputfound = False
                        OutputString = ""
                        For i = 1 To Len(nextline)
                            If (Mid(nextline, i, 2) = "U+") Then
                                OutputString = Mid(nextline, i + 2, 4)
                                CharCode = Integer.Parse(OutputString, Globalization.NumberStyles.AllowHexSpecifier)
                                If unassigned = "" Then
                                    unassigned = ChrW(CharCode)
                                Else
                                    unassigned = unassigned + " " + ChrW(CharCode)
                                End If
                            End If
                        Next
                    End If
                End While
            End Using

            If deadkeyspresent Then
                Using sr As StreamReader = New StreamReader(OpenFileDialog1.OpenFile())
                    While Not sr.EndOfStream
                        nextline = sr.ReadLine()
                        If ((Mid(nextline, 1, 7) = "deadkey") Or (Mid(nextline, 1, 2) = "dk")) Then
                            keyfound = False
                            outputfound = False
                            NewKey = ""
                            OutputString = ""
                            shifted = False
                            For i = 1 To Len(nextline)
                                If (((Mid(nextline, i, 1) = "'") Or (Mid(nextline, i, 1) = """")) And Not keyfound) Then
                                    NewKey = Mid(nextline, i + 1, 1)
                                    keyfound = True
                                End If
                                If (Mid(nextline, i, 2) = "U+") Then
                                    OutputString = Mid(nextline, i + 2, 4)
                                    outputfound = True
                                End If
                            Next
                            If keyfound And outputfound Then
                                KeyNum = ProcessNewKey(NewKey, shifted)
                                CharCode = Integer.Parse(OutputString, Globalization.NumberStyles.AllowHexSpecifier)
                                If shifted Then
                                    If KeyContentsShift(KeyNum) <> "" Then
                                        KeyContentsShift(KeyNum) = KeyContentsShift(KeyNum) + ChrW(CharCode)
                                    Else
                                        KeyContentsShift(KeyNum) = NewKey + ChrW(CharCode)
                                    End If
                                Else
                                    If KeyContents(KeyNum) <> "" Then
                                        KeyContents(KeyNum) = KeyContents(KeyNum) + ChrW(CharCode)
                                    Else
                                        KeyContents(KeyNum) = NewKey + ChrW(CharCode)
                                    End If
                                End If
                            End If
                        End If
                    End While
                End Using
            End If

            ' Load anything imported into labels
            For temploop = 1 To NumKeys
                KeyLabel(temploop).Text = KeyContents(temploop).Replace("&", "&&")
            Next

            ' Any unassigned characters?
            If unassigned <> "" Then
                Dim tempsize As System.Drawing.Size
                tempsize.Width = 1010
                tempsize.Height = 458
                Me.Size = tempsize
                TextBox1.Text = unassigned
            Else
                Dim tempsize As System.Drawing.Size
                tempsize.Width = 1010
                tempsize.Height = 404
                Me.Size = tempsize
                TextBox1.Text = ""
            End If
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub
    Private Function ProcessNewKey(ByVal NewKey As String, ByRef shifted As Boolean) As Integer
        Dim KeyNum, KeyASCII As Integer
        Dim KeyName As String
        KeyName = ""
        KeyASCII = Asc(NewKey)
        If KeyASCII > 64 And KeyASCII < 91 Then
            shifted = True
            KeyName = "Key" + NewKey
        End If
        If KeyASCII > 96 And KeyASCII < 123 Then
            shifted = False
            KeyName = "Key" + NewKey.ToUpper
        End If
        If KeyASCII > 47 And KeyASCII < 58 Then
            shifted = False
            If NewKey = "1" Then KeyName = "KeyOne"
            If NewKey = "2" Then KeyName = "KeyTwo"
            If NewKey = "3" Then KeyName = "KeyThree"
            If NewKey = "4" Then KeyName = "KeyFour"
            If NewKey = "5" Then KeyName = "KeyFive"
            If NewKey = "6" Then KeyName = "KeySix"
            If NewKey = "7" Then KeyName = "KeySeven"
            If NewKey = "8" Then KeyName = "KeyEight"
            If NewKey = "9" Then KeyName = "KeyNine"
            If NewKey = "0" Then KeyName = "KeyZero"
        End If
        If KeyASCII = 33 Then
            shifted = True
            KeyName = "KeyOne"
        End If
        If KeyASCII = 64 Then
            shifted = True
            KeyName = "KeyTwo"
        End If
        If KeyASCII = 35 Then
            shifted = True
            KeyName = "KeyThree"
        End If
        If KeyASCII = 36 Then
            shifted = True
            KeyName = "KeyFour"
        End If
        If KeyASCII = 37 Then
            shifted = True
            KeyName = "KeyFive"
        End If
        If KeyASCII = 94 Then
            shifted = True
            KeyName = "KeySix"
        End If
        If KeyASCII = 38 Then
            shifted = True
            KeyName = "KeySeven"
        End If
        If KeyASCII = 42 Then
            shifted = True
            KeyName = "KeyEight"
        End If
        If KeyASCII = 40 Then
            shifted = True
            KeyName = "KeyNine"
        End If
        If KeyASCII = 41 Then
            shifted = True
            KeyName = "KeyZero"
        End If
        If KeyASCII = 96 Then
            shifted = False
            KeyName = "KeyGrave"
        End If
        If KeyASCII = 126 Then
            shifted = True
            KeyName = "KeyGrave"
        End If
        If KeyASCII = 45 Then
            shifted = False
            KeyName = "KeyDash"
        End If
        If KeyASCII = 95 Then
            shifted = True
            KeyName = "KeyDash"
        End If
        If KeyASCII = 61 Then
            shifted = False
            KeyName = "KeyEquals"
        End If
        If KeyASCII = 43 Then
            shifted = True
            KeyName = "KeyEquals"
        End If
        If KeyASCII = 92 Then
            shifted = False
            KeyName = "KeyReverseSolidus"
        End If
        If KeyASCII = 124 Then
            shifted = True
            KeyName = "KeyReverseSolidus"
        End If
        If KeyASCII = 91 Then
            shifted = False
            KeyName = "KeyOpenBracket"
        End If
        If KeyASCII = 123 Then
            shifted = True
            KeyName = "KeyOpenBracket"
        End If
        If KeyASCII = 93 Then
            shifted = False
            KeyName = "KeyCloseBracket"
        End If
        If KeyASCII = 125 Then
            shifted = True
            KeyName = "KeyCloseBracket"
        End If
        If KeyASCII = 59 Then
            shifted = False
            KeyName = "KeySemiColon"
        End If
        If KeyASCII = 58 Then
            shifted = True
            KeyName = "KeySemiColon"
        End If
        If KeyASCII = 39 Then
            shifted = False
            KeyName = "KeyApostrophe"
        End If
        If KeyASCII = 34 Then
            shifted = True
            KeyName = "KeyApostrophe"
        End If
        If KeyASCII = 44 Then
            shifted = False
            KeyName = "KeyComma"
        End If
        If KeyASCII = 60 Then
            shifted = True
            KeyName = "KeyComma"
        End If
        If KeyASCII = 46 Then
            shifted = False
            KeyName = "KeyPeriod"
        End If
        If KeyASCII = 62 Then
            shifted = True
            KeyName = "KeyPeriod"
        End If
        If KeyASCII = 47 Then
            shifted = False
            KeyName = "KeySolidus"
        End If
        If KeyASCII = 63 Then
            shifted = True
            KeyName = "KeySolidus"
        End If
        KeyNum = GetKeyNumberFromName(KeyName)
        Return KeyNum
    End Function
    Private Function ProcessNewKeyString(ByVal NewKeyString As String, ByRef shifted As Boolean, ByRef alted As Boolean) As Integer
        Dim KeyNum, KeyASCII As Integer
        Dim KeyName As String
        KeyName = ""
        If Mid(NewKeyString, 1, 5) = "SHIFT" Then
            shifted = True
            NewKeyString = Mid(NewKeyString, 9)
        ElseIf Mid(NewKeyString, 1, 3) = "ALT" Then
            alted = True
            NewKeyString = Mid(NewKeyString, 7)
        Else
            NewKeyString = Mid(NewKeyString, 3)
        End If

        If NewKeyString = "BKQUOTE" Then NewKeyString = "`"
        If NewKeyString = "HYPHEN" Then NewKeyString = "-"
        If NewKeyString = "EQUAL" Then NewKeyString = "="
        If NewKeyString = "LBRKT" Then NewKeyString = "["
        If NewKeyString = "RBRKT" Then NewKeyString = "]"
        If NewKeyString = "BKSLASH" Then NewKeyString = "\"
        If NewKeyString = "COLON" Then NewKeyString = ";"
        If NewKeyString = "QUOTE" Then NewKeyString = "'"
        If NewKeyString = "COMMA" Then NewKeyString = ","
        If NewKeyString = "PERIOD" Then NewKeyString = "."
        If NewKeyString = "SLASH" Then NewKeyString = "/"
        If NewKeyString = "SPACE" Then NewKeyString = " "

        KeyASCII = Asc(NewKeyString)

        If NewKeyString = "1" Then KeyName = "KeyOne"
        If NewKeyString = "2" Then KeyName = "KeyTwo"
        If NewKeyString = "3" Then KeyName = "KeyThree"
        If NewKeyString = "4" Then KeyName = "KeyFour"
        If NewKeyString = "5" Then KeyName = "KeyFive"
        If NewKeyString = "6" Then KeyName = "KeySix"
        If NewKeyString = "7" Then KeyName = "KeySeven"
        If NewKeyString = "8" Then KeyName = "KeyEight"
        If NewKeyString = "9" Then KeyName = "KeyNine"
        If NewKeyString = "0" Then KeyName = "KeyZero"

        If KeyASCII > 64 And KeyASCII < 91 Then
            KeyName = "Key" + NewKeyString
        End If

        If KeyASCII = 32 Then KeyName = "KeySpace"
        If KeyASCII = 96 Then KeyName = "KeyGrave"
        If KeyASCII = 45 Then KeyName = "KeyDash"
        If KeyASCII = 61 Then KeyName = "KeyEquals"
        If KeyASCII = 92 Then KeyName = "KeyReverseSolidus"
        If KeyASCII = 91 Then KeyName = "KeyOpenBracket"
        If KeyASCII = 93 Then KeyName = "KeyCloseBracket"
        If KeyASCII = 59 Then KeyName = "KeySemiColon"
        If KeyASCII = 39 Then KeyName = "KeyApostrophe"
        If KeyASCII = 44 Then KeyName = "KeyComma"
        If KeyASCII = 46 Then KeyName = "KeyPeriod"
        If KeyASCII = 47 Then KeyName = "KeySolidus"

        KeyNum = GetKeyNumberFromName(KeyName)

        'MsgBox("String: " + NewKeyString + " ASCII: " + Str(KeyASCII) + " Name: " + KeyName + " KeyNum: " + Str(KeyNum))

        Return KeyNum
    End Function

    Private Sub AutoAddSpacesToExistingRotasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoAddSpacesToExistingRotasToolStripMenuItem.Click
        Dim temploop As Integer

        For temploop = 1 To NumKeys
            If ((Len(KeyContents(temploop)) > 1) And Not KeyRotaSuppress(temploop)) Then
                If Not KeyContents(temploop).Contains(" ") Then
                    KeyContents(temploop) = AddSpaces(KeyContents(temploop))
                End If
            End If
            If ((Len(KeyContentsShift(temploop)) > 1) And Not KeyRotaSuppressShift(temploop)) Then
                If Not KeyContentsShift(temploop).Contains(" ") Then
                    KeyContentsShift(temploop) = AddSpaces(KeyContentsShift(temploop))
                End If
            End If
            If ((Len(KeyContentsCtrl(temploop)) > 1) And Not KeyRotaSuppressCtrl(temploop)) Then
                If Not KeyContentsCtrl(temploop).Contains(" ") Then
                    KeyContentsCtrl(temploop) = AddSpaces(KeyContentsCtrl(temploop))
                End If
            End If
            If ((Len(KeyContentsAlt(temploop)) > 1) And Not KeyRotaSuppressAlt(temploop)) Then
                If Not KeyContentsAlt(temploop).Contains(" ") Then
                    KeyContentsAlt(temploop) = AddSpaces(KeyContentsAlt(temploop))
                End If
            End If
            If ((Len(KeyContentsShiftCtrl(temploop)) > 1) And Not KeyRotaSuppressShiftCtrl(temploop)) Then
                If Not KeyContentsShiftCtrl(temploop).Contains(" ") Then
                    KeyContentsShiftCtrl(temploop) = AddSpaces(KeyContentsShiftCtrl(temploop))
                End If
            End If
            If ((Len(KeyContentsShiftAlt(temploop)) > 1) And Not KeyRotaSuppressShiftAlt(temploop)) Then
                If Not KeyContentsShiftAlt(temploop).Contains(" ") Then
                    KeyContentsShiftAlt(temploop) = AddSpaces(KeyContentsShiftAlt(temploop))
                End If
            End If
            If ((Len(KeyContentsCtrlAlt(temploop)) > 1) And Not KeyRotaSuppressCtrlAlt(temploop)) Then
                If Not KeyContentsCtrlAlt(temploop).Contains(" ") Then
                    KeyContentsCtrlAlt(temploop) = AddSpaces(KeyContentsCtrlAlt(temploop))
                End If
            End If
            If ((Len(KeyContentsShiftCtrlAlt(temploop)) > 1) And Not KeyRotaSuppressShiftCtrlAlt(temploop)) Then
                If Not KeyContentsShiftCtrlAlt(temploop).Contains(" ") Then
                    KeyContentsShiftCtrlAlt(temploop) = AddSpaces(KeyContentsShiftCtrlAlt(temploop))
                End If
            End If
            If ((Len(KeyContentsAltGr(temploop)) > 1) And Not KeyRotaSuppressAltGr(temploop)) Then
                If Not KeyContentsAltGr(temploop).Contains(" ") Then
                    KeyContentsAltGr(temploop) = AddSpaces(KeyContentsAltGr(temploop))
                End If
            End If
            If ((Len(KeyContentsShiftAltGr(temploop)) > 1) And Not KeyRotaSuppressShiftAltGr(temploop)) Then
                If Not KeyContentsShiftAltGr(temploop).Contains(" ") Then
                    KeyContentsShiftAltGr(temploop) = AddSpaces(KeyContentsShiftAltGr(temploop))
                End If
            End If
            If ((Len(KeyContentsCtrlAltGr(temploop)) > 1) And Not KeyRotaSuppressCtrlAltGr(temploop)) Then
                If Not KeyContentsCtrlAltGr(temploop).Contains(" ") Then
                    KeyContentsCtrlAltGr(temploop) = AddSpaces(KeyContentsCtrlAltGr(temploop))
                End If
            End If
            If ((Len(KeyContentsShiftCtrlAltGr(temploop)) > 1) And Not KeyRotaSuppressShiftCtrlAltGr(temploop)) Then
                If Not KeyContentsShiftCtrlAltGr(temploop).Contains(" ") Then
                    KeyContentsShiftCtrlAltGr(temploop) = AddSpaces(KeyContentsShiftCtrlAltGr(temploop))
                End If
            End If
        Next
        RefreshLabels()
        projectchanged = True
        If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
        If Form3.TextBox1.Text <> "" Then
            Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
        Else
            Me.Text = "*Untitled - InKey Keyboard Creator"
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ButtonAltGr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAltGr.CheckedChanged
        If ButtonAltGr.Checked Then ButtonAlt.Checked = False
        RefreshLabels()
    End Sub

    Private Sub ToggleAltAltGrToLAltRAltToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleAltAltGrToLAltRAltToolStripMenuItem.Click
        If ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle Alt/AltGr to LAlt/RAlt" Then
            ButtonAlt.Text = "LAlt"
            ButtonAltGr.Text = "RAlt"
            ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle LAlt/RAlt to Alt/AltGr"
            AltGr = False
        Else
            ButtonAlt.Text = "Alt"
            ButtonAltGr.Text = "AltGr"
            ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle Alt/AltGr to LAlt/RAlt"
            AltGr = True
        End If
        projectchanged = True
        If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
        If Form3.TextBox1.Text <> "" Then
            Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
        Else
            Me.Text = "*Untitled - InKey Keyboard Creator"
        End If
    End Sub

    Private Sub ActivateDeadkeyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivateDeadkeyToolStripMenuItem.Click
        If ActivateDeadkeyToolStripMenuItem.Checked = False Then
            DeadKeys = True
            ActivateDeadkeyToolStripMenuItem.Checked = True
            DeadkeysToolStripMenuItem.Checked = False
            Dialog1.TextBox2.Enabled = True
            Dialog1.RadioButton1.Enabled = True
            Dialog1.Width = 651
            Dialog1.GroupBox1.Width = 157
            ResetKeyBorders()
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        Else
            DeadKeys = False
            ActivateDeadkeyToolStripMenuItem.Checked = False
            Dialog1.TextBox2.Enabled = False
            Dialog1.RadioButton1.Enabled = False
            Dialog1.Width = 476
            ResetKeyBorders()
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub

    Private Sub DeadkeysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeadkeysToolStripMenuItem.Click
        If DeadkeysToolStripMenuItem.Checked = False Then
            DeadKeys = True
            DeadkeysToolStripMenuItem.Checked = True
            ActivateDeadkeyToolStripMenuItem.Checked = False
            Dialog1.TextBox2.Enabled = True
            Dialog1.RadioButton1.Enabled = True
            Dialog1.TextBox3.Enabled = True
            Dialog1.RadioButton2.Enabled = True
            Dialog1.Width = 807
            Dialog1.GroupBox1.Width = 314
            Dialog1.RadioButton1.Text = "This key is deadkey 1"
            Dialog1.Label3.Text = "This will follow deadkey 1:"
            ResetKeyBorders()
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        Else
            DeadKeys = False
            DeadkeysToolStripMenuItem.Checked = False
            Dialog1.TextBox2.Enabled = False
            Dialog1.RadioButton1.Enabled = False
            Dialog1.TextBox3.Enabled = False
            Dialog1.RadioButton2.Enabled = False
            Dialog1.RadioButton1.Text = "This key is the deadkey"
            Dialog1.Label3.Text = "This will follow the deadkey:"
            Dialog1.Width = 476
            ResetKeyBorders()
            RefreshLabels()
            projectchanged = True
            If SaveFileDialog1.FileName <> "" Then SaveProjectToolStripMenuItem1.Enabled = True
            If Form3.TextBox1.Text <> "" Then
                Me.Text = "*" + Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "*Untitled - InKey Keyboard Creator"
            End If
        End If
    End Sub

    Private Sub RefreshLabels()
        Dim temploop As Integer
        For temploop = 1 To NumKeys
            If ButtonShift.Checked Then
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyLabel(temploop).Text = KeyContentsShiftCtrlAlt(temploop).Replace("&", "&&")
                    ElseIf ButtonAltGr.Checked Then
                        KeyLabel(temploop).Text = KeyContentsShiftCtrlAltGr(temploop).Replace("&", "&&")
                    Else
                        KeyLabel(temploop).Text = KeyContentsShiftCtrl(temploop).Replace("&", "&&")
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyLabel(temploop).Text = KeyContentsShiftAlt(temploop).Replace("&", "&&")
                    ElseIf ButtonAltGr.Checked Then
                        KeyLabel(temploop).Text = KeyContentsShiftAltGr(temploop).Replace("&", "&&")
                    Else
                        If DeadKeys Then
                            If ((KeyContentsDeadkeyShift(temploop) <> "") Or (KeyContentsDeadkey2Shift(temploop) <> "")) Then
                                KeyLabel(temploop).Text = KeyContentsShift(temploop).Replace("&", "&&") + " (" + KeyContentsDeadkeyShift(temploop).Replace("&", "&&") + KeyContentsDeadkey2Shift(temploop).Replace("&", "&&") + ")"
                            Else
                                KeyLabel(temploop).Text = KeyContentsShift(temploop).Replace("&", "&&")
                            End If
                        Else
                            KeyLabel(temploop).Text = KeyContentsShift(temploop).Replace("&", "&&")
                        End If
                    End If
                End If
            Else
                If ButtonCtrl.Checked Then
                    If ButtonAlt.Checked Then
                        KeyLabel(temploop).Text = KeyContentsCtrlAlt(temploop).Replace("&", "&&")
                    ElseIf ButtonAltGr.Checked Then
                        KeyLabel(temploop).Text = KeyContentsCtrlAltGr(temploop).Replace("&", "&&")
                    Else
                        KeyLabel(temploop).Text = KeyContentsCtrl(temploop).Replace("&", "&&")
                    End If
                Else
                    If ButtonAlt.Checked Then
                        KeyLabel(temploop).Text = KeyContentsAlt(temploop).Replace("&", "&&")
                    ElseIf ButtonAltGr.Checked Then
                        KeyLabel(temploop).Text = KeyContentsAltGr(temploop).Replace("&", "&&")
                    Else
                        If DeadKeys Then
                            If ((KeyContentsDeadkey(temploop) <> "") Or (KeyContentsDeadkey2(temploop) <> "")) Then
                                KeyLabel(temploop).Text = KeyContents(temploop).Replace("&", "&&") + " (" + KeyContentsDeadkey(temploop).Replace("&", "&&") + KeyContentsDeadkey2(temploop).Replace("&", "&&") + ")"
                            Else
                                KeyLabel(temploop).Text = KeyContents(temploop).Replace("&", "&&")
                            End If
                        Else
                            KeyLabel(temploop).Text = KeyContents(temploop).Replace("&", "&&")
                        End If
                    End If
                End If
            End If
        Next temploop
    End Sub

    Private Sub ResetKeyBorders()
        KeyGrave.FlatAppearance.BorderSize = 1
        KeyOne.FlatAppearance.BorderSize = 1
        KeyTwo.FlatAppearance.BorderSize = 1
        KeyThree.FlatAppearance.BorderSize = 1
        KeyFour.FlatAppearance.BorderSize = 1
        KeyFive.FlatAppearance.BorderSize = 1
        KeySix.FlatAppearance.BorderSize = 1
        KeySeven.FlatAppearance.BorderSize = 1
        KeyEight.FlatAppearance.BorderSize = 1
        KeyNine.FlatAppearance.BorderSize = 1
        KeyZero.FlatAppearance.BorderSize = 1
        KeyDash.FlatAppearance.BorderSize = 1
        KeyEquals.FlatAppearance.BorderSize = 1
        KeyReverseSolidus.FlatAppearance.BorderSize = 1
        KeyQ.FlatAppearance.BorderSize = 1
        KeyW.FlatAppearance.BorderSize = 1
        KeyE.FlatAppearance.BorderSize = 1
        KeyR.FlatAppearance.BorderSize = 1
        KeyT.FlatAppearance.BorderSize = 1
        KeyY.FlatAppearance.BorderSize = 1
        KeyU.FlatAppearance.BorderSize = 1
        KeyI.FlatAppearance.BorderSize = 1
        KeyO.FlatAppearance.BorderSize = 1
        KeyP.FlatAppearance.BorderSize = 1
        KeyOpenBracket.FlatAppearance.BorderSize = 1
        KeyCloseBracket.FlatAppearance.BorderSize = 1
        KeyA.FlatAppearance.BorderSize = 1
        KeyS.FlatAppearance.BorderSize = 1
        KeyD.FlatAppearance.BorderSize = 1
        KeyF.FlatAppearance.BorderSize = 1
        KeyG.FlatAppearance.BorderSize = 1
        KeyH.FlatAppearance.BorderSize = 1
        KeyJ.FlatAppearance.BorderSize = 1
        KeyK.FlatAppearance.BorderSize = 1
        KeyL.FlatAppearance.BorderSize = 1
        KeySemiColon.FlatAppearance.BorderSize = 1
        KeyApostrophe.FlatAppearance.BorderSize = 1
        KeyZ.FlatAppearance.BorderSize = 1
        KeyX.FlatAppearance.BorderSize = 1
        KeyC.FlatAppearance.BorderSize = 1
        KeyV.FlatAppearance.BorderSize = 1
        KeyB.FlatAppearance.BorderSize = 1
        KeyN.FlatAppearance.BorderSize = 1
        KeyM.FlatAppearance.BorderSize = 1
        KeyComma.FlatAppearance.BorderSize = 1
        KeyPeriod.FlatAppearance.BorderSize = 1
        KeySolidus.FlatAppearance.BorderSize = 1
        KeyGrave.FlatAppearance.BorderColor = Color.Black
        KeyOne.FlatAppearance.BorderColor = Color.Black
        KeyTwo.FlatAppearance.BorderColor = Color.Black
        KeyThree.FlatAppearance.BorderColor = Color.Black
        KeyFour.FlatAppearance.BorderColor = Color.Black
        KeyFive.FlatAppearance.BorderColor = Color.Black
        KeySix.FlatAppearance.BorderColor = Color.Black
        KeySeven.FlatAppearance.BorderColor = Color.Black
        KeyEight.FlatAppearance.BorderColor = Color.Black
        KeyNine.FlatAppearance.BorderColor = Color.Black
        KeyZero.FlatAppearance.BorderColor = Color.Black
        KeyDash.FlatAppearance.BorderColor = Color.Black
        KeyEquals.FlatAppearance.BorderColor = Color.Black
        KeyReverseSolidus.FlatAppearance.BorderColor = Color.Black
        KeyQ.FlatAppearance.BorderColor = Color.Black
        KeyW.FlatAppearance.BorderColor = Color.Black
        KeyE.FlatAppearance.BorderColor = Color.Black
        KeyR.FlatAppearance.BorderColor = Color.Black
        KeyT.FlatAppearance.BorderColor = Color.Black
        KeyY.FlatAppearance.BorderColor = Color.Black
        KeyU.FlatAppearance.BorderColor = Color.Black
        KeyI.FlatAppearance.BorderColor = Color.Black
        KeyO.FlatAppearance.BorderColor = Color.Black
        KeyP.FlatAppearance.BorderColor = Color.Black
        KeyOpenBracket.FlatAppearance.BorderColor = Color.Black
        KeyCloseBracket.FlatAppearance.BorderColor = Color.Black
        KeyA.FlatAppearance.BorderColor = Color.Black
        KeyS.FlatAppearance.BorderColor = Color.Black
        KeyD.FlatAppearance.BorderColor = Color.Black
        KeyF.FlatAppearance.BorderColor = Color.Black
        KeyG.FlatAppearance.BorderColor = Color.Black
        KeyH.FlatAppearance.BorderColor = Color.Black
        KeyJ.FlatAppearance.BorderColor = Color.Black
        KeyK.FlatAppearance.BorderColor = Color.Black
        KeyL.FlatAppearance.BorderColor = Color.Black
        KeySemiColon.FlatAppearance.BorderColor = Color.Black
        KeyApostrophe.FlatAppearance.BorderColor = Color.Black
        KeyZ.FlatAppearance.BorderColor = Color.Black
        KeyX.FlatAppearance.BorderColor = Color.Black
        KeyC.FlatAppearance.BorderColor = Color.Black
        KeyV.FlatAppearance.BorderColor = Color.Black
        KeyB.FlatAppearance.BorderColor = Color.Black
        KeyN.FlatAppearance.BorderColor = Color.Black
        KeyM.FlatAppearance.BorderColor = Color.Black
        KeyComma.FlatAppearance.BorderColor = Color.Black
        KeyPeriod.FlatAppearance.BorderColor = Color.Black
        KeySolidus.FlatAppearance.BorderColor = Color.Black
        KeyGrave.FlatStyle = FlatStyle.Standard
        KeyOne.FlatStyle = FlatStyle.Standard
        KeyTwo.FlatStyle = FlatStyle.Standard
        KeyThree.FlatStyle = FlatStyle.Standard
        KeyFour.FlatStyle = FlatStyle.Standard
        KeyFive.FlatStyle = FlatStyle.Standard
        KeySix.FlatStyle = FlatStyle.Standard
        KeySeven.FlatStyle = FlatStyle.Standard
        KeyEight.FlatStyle = FlatStyle.Standard
        KeyNine.FlatStyle = FlatStyle.Standard
        KeyZero.FlatStyle = FlatStyle.Standard
        KeyDash.FlatStyle = FlatStyle.Standard
        KeyEquals.FlatStyle = FlatStyle.Standard
        KeyReverseSolidus.FlatStyle = FlatStyle.Standard
        KeyQ.FlatStyle = FlatStyle.Standard
        KeyW.FlatStyle = FlatStyle.Standard
        KeyE.FlatStyle = FlatStyle.Standard
        KeyR.FlatStyle = FlatStyle.Standard
        KeyT.FlatStyle = FlatStyle.Standard
        KeyY.FlatStyle = FlatStyle.Standard
        KeyU.FlatStyle = FlatStyle.Standard
        KeyI.FlatStyle = FlatStyle.Standard
        KeyO.FlatStyle = FlatStyle.Standard
        KeyP.FlatStyle = FlatStyle.Standard
        KeyOpenBracket.FlatStyle = FlatStyle.Standard
        KeyCloseBracket.FlatStyle = FlatStyle.Standard
        KeyA.FlatStyle = FlatStyle.Standard
        KeyS.FlatStyle = FlatStyle.Standard
        KeyD.FlatStyle = FlatStyle.Standard
        KeyF.FlatStyle = FlatStyle.Standard
        KeyG.FlatStyle = FlatStyle.Standard
        KeyH.FlatStyle = FlatStyle.Standard
        KeyJ.FlatStyle = FlatStyle.Standard
        KeyK.FlatStyle = FlatStyle.Standard
        KeyL.FlatStyle = FlatStyle.Standard
        KeySemiColon.FlatStyle = FlatStyle.Standard
        KeyApostrophe.FlatStyle = FlatStyle.Standard
        KeyZ.FlatStyle = FlatStyle.Standard
        KeyX.FlatStyle = FlatStyle.Standard
        KeyC.FlatStyle = FlatStyle.Standard
        KeyV.FlatStyle = FlatStyle.Standard
        KeyB.FlatStyle = FlatStyle.Standard
        KeyN.FlatStyle = FlatStyle.Standard
        KeyM.FlatStyle = FlatStyle.Standard
        KeyComma.FlatStyle = FlatStyle.Standard
        KeyPeriod.FlatStyle = FlatStyle.Standard
        KeySolidus.FlatStyle = FlatStyle.Standard

        If (DeadKeys) Then
            If DeadkeysToolStripMenuItem.Checked = True Then
                DeadKeyBorder(DeadKey, Color.Red)
                DeadKeyBorder(DeadKey2, Color.Blue)
            Else
                DeadKeyBorder(DeadKey, Color.Red)
            End If
        End If
    End Sub

    Private Sub DeadKeyBorder(ByVal KeyNumber, ByVal Color)
        If KeyNumber < 1 Then Exit Sub
        If KeyNumber = 1 Then
            KeyGrave.FlatAppearance.BorderSize = 3
            KeyGrave.FlatAppearance.BorderColor = Color
            KeyGrave.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 2 Then
            KeyOne.FlatAppearance.BorderSize = 3
            KeyOne.FlatAppearance.BorderColor = Color
            KeyOne.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 3 Then
            KeyTwo.FlatAppearance.BorderSize = 3
            KeyTwo.FlatAppearance.BorderColor = Color
            KeyTwo.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 4 Then
            KeyThree.FlatAppearance.BorderSize = 3
            KeyThree.FlatAppearance.BorderColor = Color
            KeyThree.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 5 Then
            KeyFour.FlatAppearance.BorderSize = 3
            KeyFour.FlatAppearance.BorderColor = Color
            KeyFour.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 6 Then
            KeyFive.FlatAppearance.BorderSize = 3
            KeyFive.FlatAppearance.BorderColor = Color
            KeyFive.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 7 Then
            KeySix.FlatAppearance.BorderSize = 3
            KeySix.FlatAppearance.BorderColor = Color
            KeySix.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 8 Then
            KeySeven.FlatAppearance.BorderSize = 3
            KeySeven.FlatAppearance.BorderColor = Color
            KeySeven.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 9 Then
            KeyEight.FlatAppearance.BorderSize = 3
            KeyEight.FlatAppearance.BorderColor = Color
            KeyEight.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 10 Then
            KeyNine.FlatAppearance.BorderSize = 3
            KeyNine.FlatAppearance.BorderColor = Color
            KeyNine.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 11 Then
            KeyZero.FlatAppearance.BorderSize = 3
            KeyZero.FlatAppearance.BorderColor = Color
            KeyZero.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 12 Then
            KeyDash.FlatAppearance.BorderSize = 3
            KeyDash.FlatAppearance.BorderColor = Color
            KeyDash.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 13 Then
            KeyEquals.FlatAppearance.BorderSize = 3
            KeyEquals.FlatAppearance.BorderColor = Color
            KeyEquals.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 14 Then
            KeyReverseSolidus.FlatAppearance.BorderSize = 3
            KeyReverseSolidus.FlatAppearance.BorderColor = Color
            KeyReverseSolidus.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 15 Then
            KeyQ.FlatAppearance.BorderSize = 3
            KeyQ.FlatAppearance.BorderColor = Color
            KeyQ.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 16 Then
            KeyW.FlatAppearance.BorderSize = 3
            KeyW.FlatAppearance.BorderColor = Color
            KeyW.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 17 Then
            KeyE.FlatAppearance.BorderSize = 3
            KeyE.FlatAppearance.BorderColor = Color
            KeyE.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 18 Then
            KeyR.FlatAppearance.BorderSize = 3
            KeyR.FlatAppearance.BorderColor = Color
            KeyR.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 19 Then
            KeyT.FlatAppearance.BorderSize = 3
            KeyT.FlatAppearance.BorderColor = Color
            KeyT.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 20 Then
            KeyY.FlatAppearance.BorderSize = 3
            KeyY.FlatAppearance.BorderColor = Color
            KeyY.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 21 Then
            KeyU.FlatAppearance.BorderSize = 3
            KeyU.FlatAppearance.BorderColor = Color
            KeyU.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 22 Then
            KeyI.FlatAppearance.BorderSize = 3
            KeyI.FlatAppearance.BorderColor = Color
            KeyI.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 23 Then
            KeyO.FlatAppearance.BorderSize = 3
            KeyO.FlatAppearance.BorderColor = Color
            KeyO.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 24 Then
            KeyP.FlatAppearance.BorderSize = 3
            KeyP.FlatAppearance.BorderColor = Color
            KeyP.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 25 Then
            KeyOpenBracket.FlatAppearance.BorderSize = 3
            KeyOpenBracket.FlatAppearance.BorderColor = Color
            KeyOpenBracket.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 26 Then
            KeyCloseBracket.FlatAppearance.BorderSize = 3
            KeyCloseBracket.FlatAppearance.BorderColor = Color
            KeyCloseBracket.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 27 Then
            KeyA.FlatAppearance.BorderSize = 3
            KeyA.FlatAppearance.BorderColor = Color
            KeyA.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 28 Then
            KeyS.FlatAppearance.BorderSize = 3
            KeyS.FlatAppearance.BorderColor = Color
            KeyS.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 29 Then
            KeyD.FlatAppearance.BorderSize = 3
            KeyD.FlatAppearance.BorderColor = Color
            KeyD.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 30 Then
            KeyF.FlatAppearance.BorderSize = 3
            KeyF.FlatAppearance.BorderColor = Color
            KeyF.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 31 Then
            KeyG.FlatAppearance.BorderSize = 3
            KeyG.FlatAppearance.BorderColor = Color
            KeyG.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 32 Then
            KeyH.FlatAppearance.BorderSize = 3
            KeyH.FlatAppearance.BorderColor = Color
            KeyH.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 33 Then
            KeyJ.FlatAppearance.BorderSize = 3
            KeyJ.FlatAppearance.BorderColor = Color
            KeyJ.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 34 Then
            KeyK.FlatAppearance.BorderSize = 3
            KeyK.FlatAppearance.BorderColor = Color
            KeyK.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 35 Then
            KeyL.FlatAppearance.BorderSize = 3
            KeyL.FlatAppearance.BorderColor = Color
            KeyL.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 36 Then
            KeySemiColon.FlatAppearance.BorderSize = 3
            KeySemiColon.FlatAppearance.BorderColor = Color
            KeySemiColon.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 37 Then
            KeyApostrophe.FlatAppearance.BorderSize = 3
            KeyApostrophe.FlatAppearance.BorderColor = Color
            KeyApostrophe.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 38 Then
            KeyZ.FlatAppearance.BorderSize = 3
            KeyZ.FlatAppearance.BorderColor = Color
            KeyZ.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 39 Then
            KeyX.FlatAppearance.BorderSize = 3
            KeyX.FlatAppearance.BorderColor = Color
            KeyX.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 40 Then
            KeyC.FlatAppearance.BorderSize = 3
            KeyC.FlatAppearance.BorderColor = Color
            KeyC.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 41 Then
            KeyV.FlatAppearance.BorderSize = 3
            KeyV.FlatAppearance.BorderColor = Color
            KeyV.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 42 Then
            KeyB.FlatAppearance.BorderSize = 3
            KeyB.FlatAppearance.BorderColor = Color
            KeyB.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 43 Then
            KeyN.FlatAppearance.BorderSize = 3
            KeyN.FlatAppearance.BorderColor = Color
            KeyN.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 44 Then
            KeyM.FlatAppearance.BorderSize = 3
            KeyM.FlatAppearance.BorderColor = Color
            KeyM.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 45 Then
            KeyComma.FlatAppearance.BorderSize = 3
            KeyComma.FlatAppearance.BorderColor = Color
            KeyComma.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 46 Then
            KeyPeriod.FlatAppearance.BorderSize = 3
            KeyPeriod.FlatAppearance.BorderColor = Color
            KeyPeriod.FlatStyle = FlatStyle.Flat
        End If
        If KeyNumber = 47 Then
            KeySolidus.FlatAppearance.BorderSize = 3
            KeySolidus.FlatAppearance.BorderColor = Color
            KeySolidus.FlatStyle = FlatStyle.Flat
        End If
    End Sub

    Private Sub SaveProject()
        Dim temploop As Integer
        Using sw As StreamWriter = New StreamWriter(SaveFileDialog1.OpenFile())
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyContents(temploop))
                sw.WriteLine(KeyContentsShift(temploop))
                sw.WriteLine(KeyContentsCtrl(temploop))
                sw.WriteLine(KeyContentsAlt(temploop))
                sw.WriteLine(KeyContentsShiftCtrl(temploop))
                sw.WriteLine(KeyContentsShiftAlt(temploop))
                sw.WriteLine(KeyContentsCtrlAlt(temploop))
                sw.WriteLine(KeyContentsShiftCtrlAlt(temploop))
            Next
            sw.WriteLine(Form3.TextBox1.Text)
            sw.WriteLine(Form3.TextBox2.Text)
            sw.WriteLine(Form3.TextBox3.Text)
            sw.WriteLine(Form3.TextBox4.Text)
            sw.WriteLine(Form3.TextBox5.Text)
            sw.WriteLine(Form3.TextBox6.Text)
            sw.WriteLine(LabelFont.Name)
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyRotaSuppress(temploop))
                sw.WriteLine(KeyRotaSuppressShift(temploop))
                sw.WriteLine(KeyRotaSuppressCtrl(temploop))
                sw.WriteLine(KeyRotaSuppressAlt(temploop))
                sw.WriteLine(KeyRotaSuppressShiftCtrl(temploop))
                sw.WriteLine(KeyRotaSuppressShiftAlt(temploop))
                sw.WriteLine(KeyRotaSuppressCtrlAlt(temploop))
                sw.WriteLine(KeyRotaSuppressShiftCtrlAlt(temploop))
            Next
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyContentsAltGr(temploop))
                sw.WriteLine(KeyContentsShiftAltGr(temploop))
                sw.WriteLine(KeyContentsCtrlAltGr(temploop))
                sw.WriteLine(KeyContentsShiftCtrlAltGr(temploop))
            Next
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyRotaSuppressAltGr(temploop))
                sw.WriteLine(KeyRotaSuppressShiftAltGr(temploop))
                sw.WriteLine(KeyRotaSuppressCtrlAltGr(temploop))
                sw.WriteLine(KeyRotaSuppressShiftCtrlAltGr(temploop))
            Next
            If AltGr = True Then
                sw.WriteLine("Alt/AltGr")
            Else
                sw.WriteLine("LAlt/RAlt")
            End If
            sw.WriteLine(DeadKeys)
            sw.WriteLine(DeadKey)
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyContentsDeadkey(temploop))
                sw.WriteLine(KeyContentsDeadkeyShift(temploop))
            Next
            sw.WriteLine(DeadKey2)
            For temploop = 1 To NumKeys
                sw.WriteLine(KeyContentsDeadkey2(temploop))
                sw.WriteLine(KeyContentsDeadkey2Shift(temploop))
            Next
        End Using
        projectchanged = False
        SaveProjectToolStripMenuItem1.Enabled = False
        If Form3.TextBox1.Text <> "" Then
            Me.Text = Form3.TextBox1.Text + " - InKey Keyboard Creator"
        Else
            Me.Text = "Untitled - InKey Keyboard Creator"
        End If
    End Sub
    Private Sub LoadProject()
        Dim LabelFontName As String
        Dim OptionAltGr As String
        Dim result As Boolean
        Dim tempicon
        Dim temploop As Integer

        ButtonShift.Checked = False
        ButtonCtrl.Checked = False
        ButtonAlt.Checked = False
        Using sr As StreamReader = New StreamReader(OpenFileDialog1.FileName)
            For temploop = 1 To NumKeys
                KeyContents(temploop) = sr.ReadLine()
                KeyContentsShift(temploop) = sr.ReadLine()
                KeyContentsCtrl(temploop) = sr.ReadLine()
                KeyContentsAlt(temploop) = sr.ReadLine()
                KeyContentsShiftCtrl(temploop) = sr.ReadLine()
                KeyContentsShiftAlt(temploop) = sr.ReadLine()
                KeyContentsCtrlAlt(temploop) = sr.ReadLine()
                KeyContentsShiftCtrlAlt(temploop) = sr.ReadLine()
            Next
            Form3.TextBox1.Text = sr.ReadLine()
            Form3.TextBox2.Text = sr.ReadLine()
            Form3.TextBox3.Text = sr.ReadLine()
            Form3.TextBox4.Text = sr.ReadLine()
            Form3.TextBox5.Text = sr.ReadLine()
            Form3.TextBox6.Text = sr.ReadLine()
            LabelFontName = sr.ReadLine()

            If Not sr.EndOfStream Then
                ' Project fileformat 1.4 (and later)
                For temploop = 1 To NumKeys
                    KeyRotaSuppress(temploop) = sr.ReadLine()
                    KeyRotaSuppressShift(temploop) = sr.ReadLine()
                    KeyRotaSuppressCtrl(temploop) = sr.ReadLine()
                    KeyRotaSuppressAlt(temploop) = sr.ReadLine()
                    KeyRotaSuppressShiftCtrl(temploop) = sr.ReadLine()
                    KeyRotaSuppressShiftAlt(temploop) = sr.ReadLine()
                    KeyRotaSuppressCtrlAlt(temploop) = sr.ReadLine()
                    KeyRotaSuppressShiftCtrlAlt(temploop) = sr.ReadLine()
                Next
            Else
                ' Project fileformat earlier than 1.4
                For temploop = 1 To NumKeys
                    KeyRotaSuppress(temploop) = False
                    KeyRotaSuppressShift(temploop) = False
                    KeyRotaSuppressCtrl(temploop) = False
                    KeyRotaSuppressAlt(temploop) = False
                    KeyRotaSuppressShiftCtrl(temploop) = False
                    KeyRotaSuppressShiftAlt(temploop) = False
                    KeyRotaSuppressCtrlAlt(temploop) = False
                    KeyRotaSuppressShiftCtrlAlt(temploop) = False
                Next
            End If

            If Not sr.EndOfStream Then
                ' Project fileformat 1.8 (and later)
                For temploop = 1 To NumKeys
                    KeyContentsAltGr(temploop) = sr.ReadLine()
                    KeyContentsShiftAltGr(temploop) = sr.ReadLine()
                    KeyContentsCtrlAltGr(temploop) = sr.ReadLine()
                    KeyContentsShiftCtrlAltGr(temploop) = sr.ReadLine()
                Next
                For temploop = 1 To NumKeys
                    KeyRotaSuppressAltGr(temploop) = sr.ReadLine()
                    KeyRotaSuppressShiftAltGr(temploop) = sr.ReadLine()
                    KeyRotaSuppressCtrlAltGr(temploop) = sr.ReadLine()
                    KeyRotaSuppressShiftCtrlAltGr(temploop) = sr.ReadLine()
                Next
            Else
                ' Project fileformat earlier than 1.8
                For temploop = 1 To NumKeys
                    KeyContentsAltGr(temploop) = ""
                    KeyContentsShiftAltGr(temploop) = ""
                    KeyContentsCtrlAltGr(temploop) = ""
                    KeyContentsShiftCtrlAltGr(temploop) = ""
                Next
                For temploop = 1 To NumKeys
                    KeyRotaSuppressAltGr(temploop) = False
                    KeyRotaSuppressShiftAltGr(temploop) = False
                    KeyRotaSuppressCtrlAltGr(temploop) = False
                    KeyRotaSuppressShiftCtrlAltGr(temploop) = False
                Next
            End If

            If Not sr.EndOfStream Then
                ' Project fileformat 1.8.3 (and later)
                OptionAltGr = sr.ReadLine()
            Else
                OptionAltGr = "Alt/AltGr"
            End If
            If OptionAltGr = "LAlt/RAlt" Then
                ButtonAlt.Text = "LAlt"
                ButtonAltGr.Text = "RAlt"
                ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle LAlt/RAlt to Alt/AltGr"
                AltGr = False
            Else
                ButtonAlt.Text = "Alt"
                ButtonAltGr.Text = "AltGr"
                ToggleAltAltGrToLAltRAltToolStripMenuItem.Text = "Toggle Alt/AltGr to LAlt/RAlt"
                AltGr = True
            End If

            If Not sr.EndOfStream Then
                ' Project fileformat 1.9 (and later)
                DeadKeys = sr.ReadLine()
                DeadKey = sr.ReadLine()
                For temploop = 1 To NumKeys
                    KeyContentsDeadkey(temploop) = sr.ReadLine()
                    KeyContentsDeadkeyShift(temploop) = sr.ReadLine()
                Next
            Else
                DeadKeys = False
                DeadKey = -1
                For temploop = 1 To NumKeys
                    KeyContentsDeadkey(temploop) = ""
                    KeyContentsDeadkeyShift(temploop) = ""
                Next
            End If
            If Not sr.EndOfStream Then
                ' Project fileformat 1.9.2 (and later)
                DeadKey2 = sr.ReadLine()
                For temploop = 1 To NumKeys
                    KeyContentsDeadkey2(temploop) = sr.ReadLine()
                    KeyContentsDeadkey2Shift(temploop) = sr.ReadLine()
                Next
            Else
                DeadKey2 = -1
                For temploop = 1 To NumKeys
                    KeyContentsDeadkey2(temploop) = ""
                    KeyContentsDeadkey2Shift(temploop) = ""
                Next
            End If

            If DeadKeys = True Then
                If DeadKey2 < 1 Then
                    ActivateDeadkeyToolStripMenuItem.Checked = True
                    Dialog1.Width = 651
                    Dialog1.GroupBox1.Width = 157
                Else
                    DeadkeysToolStripMenuItem.Checked = True
                    Dialog1.Width = 807
                    Dialog1.GroupBox1.Width = 314
                End If
            Else
                ActivateDeadkeyToolStripMenuItem.Checked = False
                DeadkeysToolStripMenuItem.Checked = False
                Dialog1.TextBox2.Enabled = False
                Dialog1.RadioButton1.Enabled = False
                Dialog1.TextBox3.Enabled = False
                Dialog1.RadioButton2.Enabled = False
                Dialog1.Width = 476
            End If
            ResetKeyBorders()
            LabelFont = New Font(LabelFontName, 10, FontStyle.Regular)
            TextFont = New Font(LabelFontName, 16, FontStyle.Regular)
            For temploop = 1 To NumKeys
                KeyLabel(temploop).Font = LabelFont
            Next temploop
            RefreshLabels()
            Dialog1.TextBox1.Font = TextFont
            TextBox1.Font = TextFont
            result = inthelist(Form3.TextBox4.Text)
            If result = False Then
                Form3.Button2.Enabled = True
            Else
                Form3.TextBox5.Text = ""
                Form3.Button2.Enabled = False
            End If
            If Form3.TextBox6.Text <> "" Then
                If System.IO.File.Exists(Form3.TextBox6.Text) Then
                    tempicon = New System.Drawing.Icon(Form3.TextBox6.Text)
                    Dim bmp As Bitmap = tempicon.ToBitmap()
                    Form3.PictureBox1.Image = bmp
                Else
                    MsgBox("Warning: Cannot find the icon file used in this ikp file." + Chr(10) + "Please relocate the appropriate icon.", MsgBoxStyle.OkOnly, "InKey Keyboard Creator")
                    Form3.TextBox6.Text = ""
                    Form3.PictureBox1.Image = Nothing
                End If
            Else
                Form3.PictureBox1.Image = Nothing
            End If
            projectchanged = False
            SaveFileDialog1.FileName = OpenFileDialog1.FileName
            SaveProjectToolStripMenuItem1.Enabled = False
            If Form3.TextBox1.Text <> "" Then
                Me.Text = Form3.TextBox1.Text + " - InKey Keyboard Creator"
            Else
                Me.Text = "Untitled - InKey Keyboard Creator"
            End If
        End Using
    End Sub
End Class
