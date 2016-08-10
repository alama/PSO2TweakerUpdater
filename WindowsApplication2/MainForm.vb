Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32

Public Class MainForm
    Private FreedomURL As String = Nothing

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThreadPool.QueueUserWorkItem(AddressOf UpdateTime, Nothing)
    End Sub

    Private Sub client_DownloadStringCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles Client.DownloadStringCompleted
        Dim TestURL As String = ""
        If RegKey.GetValue(Of Boolean)(RegKey.EnableBeta) = True Then
            TestURL = "http://aida.moe/freedom/"
        Else
            TestURL = e.Result
        End If
        FreedomURL = If(TestURL.Contains("freedom"), TestURL, e.Result)
        'MsgBox(FreedomURL)
        Client.DownloadFileAsync(New Uri(FreedomURL & "PSO2%20Tweaker.exe"), (Application.StartupPath & "\PSO2 Tweaker.exe"))
    End Sub

    Private Sub client_DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles Client.DownloadFileCompleted
        Process.Start("PSO2 Tweaker.exe")
        Application.Exit()
    End Sub

    Private Sub client_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Client.DownloadProgressChanged
        If FreedomURL IsNot Nothing Then
            ProgressBarX1.Value = e.ProgressPercentage
            ProgressBarX1.Text = "Downloaded " & e.BytesReceived & "/" & e.TotalBytesToReceive & " (" & e.ProgressPercentage & "%)"
        End If
    End Sub

    Private Sub UpdateTime(state As Object)
        For Each procs As Process In Process.GetProcessesByName("PSO2 Tweaker")
            procs.Kill()
            procs.WaitForExit(60000)
        Next

        File.Delete("PSO2 Tweaker.exe")
        Me.Invoke(New Action(Of Uri)(AddressOf Client.DownloadStringAsync), New Uri("http://arks-layer.com/freedom.txt"))
    End Sub
End Class

Public Class RegKey
    Public Const EnableBeta = "EnableBeta"

    Private Shared ReadOnly RegistryCache As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
    Private Shared ReadOnly RegistrySubKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\AIDA", True)

    Public Shared Function GetValue(Of T)(key As String) As T
        Try
            Dim returnValue As Object = Nothing
            If RegistryCache.TryGetValue(key, returnValue) Then Return DirectCast(Convert.ChangeType(returnValue, GetType(T)), T)

            returnValue = RegistrySubKey.GetValue(key, Nothing)
            If returnValue IsNot Nothing Then RegistryCache.Add(key, returnValue)

            Return DirectCast(Convert.ChangeType(returnValue, GetType(T)), T)
        Catch
            Return Nothing
        End Try
    End Function

    Public Shared Sub SetValue(Of T)(key As String, value As T)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\AIDA", key, value)
        RegistryCache(key) = value
    End Sub

    Public Shared Sub DeleteValue(key As String)
        'This is a dumb way to do this. [AIDA]
        Dim keytodelete = My.Computer.Registry.CurrentUser.OpenSubKey("Software\AIDA", True)
        keytodelete.DeleteValue(key)
        keytodelete.Close()
    End Sub
End Class