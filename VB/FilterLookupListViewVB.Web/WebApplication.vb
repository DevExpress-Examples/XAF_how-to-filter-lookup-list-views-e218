Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Partial Public Class FilterLookupListViewVBAspNetApplication
	Inherits WebApplication
	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
	Private module3 As FilterLookupListViewVB.Module.FilterLookupListViewVBModule
	Private module4 As FilterLookupListViewVB.Module.Web.FilterLookupListViewVBAspNetModule
	Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
    Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
	Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule


	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub FilterLookupListViewVBAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
        e.Updater.Update()
        e.Handled = True
#Else
        If System.Diagnostics.Debugger.IsAttached Then
            e.Updater.Update()
            e.Handled = True
        Else
            Throw New InvalidOperationException( _
             "The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & Constants.vbCrLf & _
             "This error occurred  because the automatic database update was disabled when the application was started without debugging." & Constants.vbCrLf & _
             "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & _
             "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & _
             "or manually create a database using the 'DBUpdater' tool." & Constants.vbCrLf & _
             "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & _
             "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
        End If
#End If
    End Sub

	Private Sub InitializeComponent()
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule
        Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Me.module3 = New FilterLookupListViewVB.[Module].FilterLookupListViewVBModule
        Me.module4 = New FilterLookupListViewVB.[Module].Web.FilterLookupListViewVBAspNetModule
        Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule
        Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'module5
        '
        Me.module5.AllowValidationDetailsAccess = True
        '
        'FilterLookupListViewVBAspNetApplication
        '
        Me.ApplicationName = "FilterLookupListViewVB"
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.module6)
        Me.Modules.Add(Me.securityModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.module5)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
End Class

