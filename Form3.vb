Public Class Form3

    'Declaring variables for each button click is inefficent as most of the variables are same so I can delcare them here instead.
    'But I am lazy, so not going to improve.

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Voice As Object
        Dim Output As Object
        Dim Username As String
        Username = Environ("userprofile")
        'Username is an environment variable which includes the path
        'For example, if the username is "user" the string stored will be:
        ' "C:/Users/user"
        Const SSFMCreateForWrite = 3
        'Constant set to 3 is requried if we want to overwrite the file

        Voice = CreateObject("sapi.spvoice")
        Output = CreateObject("sapi.spfilestream")
        Output.Open(Username & "/Documents/Speech.wav", SSFMCreateForWrite, False)
        'Starting audio stream
        Voice.AudioOutputStream = Output
        Voice.speak(Me.TextBox1.Text)
        Output.close()
        'Ended audio stream
        MsgBox("Output saved in " & Username & "\Documents\Speech.wav")
        'Another user reported bug here
        'Don't know what is causing it
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim Username As String
        Dim Voice As Object
        Dim File As String
        Dim Output As Object
        Dim AudioFile As String
        Const SSFMCreateForWrite = 3
        Username = Environ("userprofile")
        Voice = CreateObject("sapi.spvoice")
        Output = CreateObject("sapi.spfilestream")

        Me.TextBox1.Text = ""

        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.InitialDirectory = Username & "/Documents"
        OpenFileDialog1.Filter = "Text Document (*.txt)|*.txt| All files (*.*)|*.*"
        OpenFileDialog1.Title = "Select the text file"
        OpenFileDialog1.FileName = "Text.txt"
        OpenFileDialog1.ShowDialog()

        File = OpenFileDialog1.FileName
        AudioFile = File.Remove(Len(File) - 4)

        If My.Computer.FileSystem.FileExists(File) Then
            Output.Open(AudioFile & ".wav", SSFMCreateForWrite, False)
            'Starting audio stream

            Voice.AudioOutputStream = Output
            Voice.speak(My.Computer.FileSystem.ReadAllText(File))
            Output.close()
            'Ended audio stream
            MsgBox("Output saved in " & AudioFile & ".wav")
            'Saves as name of input file to avoid over-writing
        Else
        End If

    End Sub
End Class
