Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, New System.ResolveEventHandler(AddressOf CurrentDomain_AssemblyResolve)
        End Sub
        Private Function CurrentDomain_AssemblyResolve(ByVal sender As System.Object, ByVal e As System.ResolveEventArgs) As System.Reflection.Assembly
            ' TODO: If you have more than one embedded assembly you need to check which 
            ' one to load.
            ' Load embedded assemblies 
            Dim stream As System.IO.Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("InKeyKeyboardCreator.Ionic.Zip.dll")
            Dim raw(stream.Length) As Byte
            stream.Read(raw, 0, stream.Length)
            Return System.Reflection.Assembly.Load(raw)
        End Function
    End Class
End Namespace

