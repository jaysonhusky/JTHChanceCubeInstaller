Imports System
Imports System.IO
Imports System.Net
Public Class Form1
    'Configure Global Variables For User
    Dim UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
    Dim ChanceCubeConfig As String = "https://jayhusky.com/minecraft/chancecubes.cfg"
    ' This is ONLY for use on default installs, it will NOT work on custom installs until Version 2
    Dim LocalChanceCubeConfig As String = UserFolder & "\Documents\Curse\Minecraft\Instances\Project Ozone 2 Reloaded\config\ChanceCubes\chancecubes.cfg"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Configure Splash
        Label2.Hide() : Button1.Hide() : Label3.Hide()
        CheckFile()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GrabFileFromServer(ChanceCubeConfig, LocalChanceCubeConfig)
    End Sub
    Public Sub GrabFileFromServer(ByVal _URL As String, ByVal _SaveAs As String)
        ' Delete Local file, but save it to the Recycle Bin
        My.Computer.FileSystem.DeleteFile(_SaveAs, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin)
        'Download and Install new file
        Dim _WebClient As New System.Net.WebClient()
        _WebClient.DownloadFile(_URL, _SaveAs)
        'Refresh UI to match state.
        UpdateFormUI("Latest")
    End Sub
    Function CheckFile()
        ' Check if Config file exists
        Dim request = DirectCast(WebRequest.Create _
            (ChanceCubeConfig), WebRequest)
        Try
            Dim response As WebResponse = DirectCast(request.GetResponse(), WebResponse)
            ' It Exists, Lets compare to see if the User's version is newer than the server version.
            Dim req As WebRequest = HttpWebRequest.Create(ChanceCubeConfig)
            req.Method = "HEAD"
            Dim resp As WebResponse = req.GetResponse()
            Dim remoteFileLastModified As String = resp.Headers.Get("Last-Modified")
            Dim remoteFileLastModifiedDateTime As DateTime
            If DateTime.TryParse(remoteFileLastModified, remoteFileLastModifiedDateTime) Then
                CompareLastModifiedDates(remoteFileLastModifiedDateTime.ToString("d MMMM yyyy dddd HH:mm:ss"), ObtainLocalLastModified(LocalChanceCubeConfig))
            Else
                MsgBox("could not determine")
            End If
            response.Close()
        Catch ex As WebException
            ' File isn't found on server
            Dim response As WebResponse = DirectCast(ex.Response, WebResponse)
            MsgBox("File does not exist on server")
            response.Close()
        End Try
    End Function
    Function CompareLastModifiedDates(Server, Local)
        Dim date1 As Date = Server : Dim date2 As Date = Local : Dim result As Integer = DateTime.Compare(date1, date2) : Dim relationship As String
        If result < 0 Then
            Label3.Show() : Label4.Hide()
        ElseIf result = 0 Then
            Label3.Show() : Label4.Hide()
        Else
            Label4.Hide() : Label2.Show() : Button1.Show()
        End If
    End Function
    Function ObtainLocalLastModified(LCCC)
        Return File.GetLastWriteTime(LCCC).ToString()
    End Function
    Function UpdateFormUI(type)
        If (type) = "Latest" Then Label3.Show() : Button1.Hide()
    End Function
End Class