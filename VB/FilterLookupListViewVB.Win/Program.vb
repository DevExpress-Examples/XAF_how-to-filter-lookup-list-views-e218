Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports FilterLookupListViewVB.Module

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
#If EASYTEST Then
              DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
        Dim _application As FilterLookupListViewVBWindowsFormsApplication = New FilterLookupListViewVBWindowsFormsApplication()
        _application.ConnectionString = CodeCentralExampleInMemoryDataStoreProvider.ConnectionString
#If EASYTEST Then
        If (Not ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString") Is Nothing) Then
            _application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString").ConnectionString
        End If
#End If
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            _application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
        End If
        If System.Diagnostics.Debugger.IsAttached Then
            _application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End If
        Try
			'Uncomment this line when using the Middle Tier application server:
			'Dim _middleTierClientApplicationConfigurator As DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator = New DevExpress.ExpressApp.MiddleTier.MiddleTierClientApplicationConfigurator(winApplication)
            _application.Setup()
            _application.Start()
        Catch e As Exception
            _application.HandleException(e)
        End Try

    End Sub
End Class
