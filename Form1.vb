Public Class Form1

    'Declaring variables for each button click is inefficent as most of the variables are same so I can delcare them here instead.
    'But I am lazy, so not going to improve.

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
        'Username is an environment variable which includes the path
        'For example, if the username is "user" the string stored will be:
        ' "C:/Users/user"
        Voice = CreateObject("sapi.spvoice")
        Me.TextBox1.Text = ""
        'Emptying so the TTS doesn't read the text entered previously

        'Configuring the Open File Dialog-box
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
        'Right click menu
        Form2.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Save as file dialog
        Form3.ShowDialog()
    End Sub
End Class
