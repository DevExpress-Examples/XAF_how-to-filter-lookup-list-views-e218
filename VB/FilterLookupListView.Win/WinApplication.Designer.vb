Imports Microsoft.VisualBasic
Imports System
Namespace FilterLookupListView.Win
   Partial Public Class FilterLookupListViewWindowsFormsApplication
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
		 Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
		 Me.module3 = New FilterLookupListView.Module.FilterLookupListViewModule()
		 Me.module4 = New FilterLookupListView.Module.Win.FilterLookupListViewWindowsFormsModule()
		 Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
		 Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
		 Me.module7 = New DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule()
		 Me.scriptRecorderWindowsFormsModule1 = New DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule()
		 Me.scriptRecorderModuleBase1 = New DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase()
		 CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
		 ' 
		 ' module5
		 ' 
		 Me.module5.AllowValidationDetailsAccess = True
		 ' 
		 ' FilterLookupListViewWindowsFormsApplication
		 ' 
		 Me.ApplicationName = "FilterLookupListView"
		 Me.Modules.Add(Me.module1)
		 Me.Modules.Add(Me.module2)
		 Me.Modules.Add(Me.module6)
		 Me.Modules.Add(Me.module3)
		 Me.Modules.Add(Me.module4)
		 Me.Modules.Add(Me.module5)
		 Me.Modules.Add(Me.module7)
		 Me.Modules.Add(Me.scriptRecorderModuleBase1)
		 Me.Modules.Add(Me.scriptRecorderWindowsFormsModule1)
'		 Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.FilterLookupListViewWindowsFormsApplication_DatabaseVersionMismatch);
		 CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

	  End Sub

	  #End Region

	  Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
	  Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	  Private module3 As FilterLookupListView.Module.FilterLookupListViewModule
	  Private module4 As FilterLookupListView.Module.Win.FilterLookupListViewWindowsFormsModule
	  Private module5 As DevExpress.ExpressApp.Validation.ValidationModule
	  Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
	  Private module7 As DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule
	  Private scriptRecorderWindowsFormsModule1 As DevExpress.ExpressApp.ScriptRecorder.Win.ScriptRecorderWindowsFormsModule
	  Private scriptRecorderModuleBase1 As DevExpress.ExpressApp.ScriptRecorder.ScriptRecorderModuleBase
   End Class
End Namespace
