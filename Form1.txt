Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Voice As Object
        Voice = CreateObject("sapi.spvoice")
        Voice.speak(Me.TextBox1.Text)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim Username As String
        Dim Voice As Object
        Dim File As String
        Username = Environ("userprofile")
        Voice = CreateObject("sapi.spvoice")
        Me.TextBox1.Text = ""

        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.InitialDirectory = Username & "/Documents"
        OpenFileDialog1.Filter = "Text Document (*.txt)|*.txt| All files (*.*)|*.*"
        OpenFileDialog1.Title = "Select the text file"
        OpenFileDialog1.FileName = "Text.txt"
        OpenFileDialog1.ShowDialog()

        File = OpenFileDialog1.FileName
        If My.Computer.FileSystem.FileExists(File) Then
            Voice.speak(My.Computer.FileSystem.ReadAllText(File))
        Else
        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Form3.ShowDialog()
        'Dim Voice As Object
        'Dim Output As Object
        'Dim Username As String
        'Const SSFMCreateForWrite = 3

        'Username = Environ("userprofile")
        'Voice = CreateObject("sapi.spvoice")
        'Output = CreateObject("sapi.spfilestream")

        'Output.Open(Username & "/Documents/Speech.wav", SSFMCreateForWrite, False)
        'Voice.AudioOutputStream = Output
        'Voice.speak(Me.TextBox1.Text)
        'Output.close()
        'MsgBox("Output saved in " & Username & "\Documents\Speech.wav")

    End Sub
End Class
