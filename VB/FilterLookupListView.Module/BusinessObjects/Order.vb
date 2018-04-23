Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace FilterLookupListView.Module.BusinessObjects
   <DefaultClassOptions> _
   Public Class Order
	   Inherits BaseObject
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Public Overrides Sub AfterConstruction()
		 MyBase.AfterConstruction()
	  End Sub
	  Private orderId_Renamed As Integer
	  Public Property OrderId() As Integer
		 Get
			Return orderId_Renamed
		 End Get
		 Set(ByVal value As Integer)
			SetPropertyValue("OrderId", orderId_Renamed, value)
		 End Set
	  End Property
	  Private product_Renamed As Product
	  Public Property Product() As Product
		 Get
			Return product_Renamed
		 End Get
		 Set(ByVal value As Product)
			SetPropertyValue("Product", product_Renamed, value)
			'Scenario 4 - Custom Lookup Property Data Source
			' Refresh the Accessory Property data source 
			RefreshAvailableAccessories()
		 End Set
	  End Property

	  Private accessory_Renamed As Accessory
	  'Scenario 1
	  'Specify Lookup Property Data Source Related to the Selected Product
	  '[DataSourceProperty("Product.Accessories")]
	  'Scenario 2
	  'Specify Criteria for Lookup Property Data Source
	  '[DataSourceCriteria("IsGlobal = true")]
	  'Scenario 3
	  'Specify Lookup Property Data Source for an Unspecified Product
	  '[DataSourceProperty("Product.Accessories", DataSourcePropertyIsNullMode.CustomCriteria, "IsGlobal = true")]
	  'Scenario 4
	  'Custom Lookup Property Data Source
	  <DataSourceProperty("AvailableAccessories")> _
	  Public Property Accessory() As Accessory
		 Get
			Return accessory_Renamed
		 End Get
		 Set(ByVal value As Accessory)
			SetPropertyValue("Accessory", accessory_Renamed, value)
		 End Set
	  End Property

	  #Region "Scenario 4 - Custom Lookup Property Data Source"
	  Private availableAccessories_Renamed As XPCollection(Of Accessory)
	  <Browsable(False)> _
	  Public ReadOnly Property AvailableAccessories() As XPCollection(Of Accessory)
		 Get
			If availableAccessories_Renamed Is Nothing Then
			   ' Retrieve all Accessory objects 
			   availableAccessories_Renamed = New XPCollection(Of Accessory)(Session)
			   ' Filter the retrieved collection according to current conditions 
			   RefreshAvailableAccessories()
			End If
			' Return the filtered collection of Accessory objects 
			Return availableAccessories_Renamed
		 End Get
	  End Property
	  Private Sub RefreshAvailableAccessories()
		 If availableAccessories_Renamed Is Nothing Then
			Return
		 End If
		 ' Process the situation when the Product is not specified (see the Scenario 3 above) 
		 If Product Is Nothing Then
			' Show only Global Accessories when the Product is not specified 
			availableAccessories_Renamed.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
		 Else
			' Leave only the current Product's Accessories in the availableAccessories collection 
			availableAccessories_Renamed.Criteria = New BinaryOperator("Product", Product)
			If IncludeGlobalAccessories = True Then
			   ' Add Global Accessories 
			   Dim availableGlobalAccessories As New XPCollection(Of Accessory)(Session)
			   availableGlobalAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
			   availableAccessories_Renamed.AddRange(availableGlobalAccessories)
			End If
		 End If
		 ' Set null for the Accessory property to allow an end-user  
		 'to set a new value from the refreshed data source 
		 Accessory = Nothing
	  End Sub
	  Private includeGlobalAccessories_Renamed As Boolean
	  <ImmediatePostData> _
	  Public Property IncludeGlobalAccessories() As Boolean
		 Get
			Return includeGlobalAccessories_Renamed
		 End Get
		 Set(ByVal value As Boolean)
			If includeGlobalAccessories_Renamed <> value Then
			   includeGlobalAccessories_Renamed = value
			   If (Not IsLoading) Then
				  ' Refresh the Accessory Property data source                     
				  RefreshAvailableAccessories()
				  SetPropertyValue("IncludeGlobalAccessories", includeGlobalAccessories_Renamed, value)
			   End If
			End If
		 End Set
	  End Property
	  #End Region 
   End Class
End Namespace
