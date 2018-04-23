Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace FilterLookupListViewrsScenario1.Module
   <DefaultClassOptions> _
   Public Class Order
	   Inherits BaseObject
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Private product_Renamed As Product
	  Public Property Product() As Product
		 Get
			Return product_Renamed
		 End Get
		 Set(ByVal value As Product)
			SetPropertyValue("Product", product_Renamed, value)
		 End Set
	  End Property
	  Private accessory_Renamed As Accessory

	  'Filter the Lookup Property Editor's data source
	  <DataSourceProperty("Product.Accessories")> _
	  Public Property Accessory() As Accessory
		 Get
			Return accessory_Renamed
		 End Get
		 Set(ByVal value As Accessory)
			SetPropertyValue("Accessory", accessory_Renamed, value)
		 End Set
	  End Property
   End Class
   Public Class Product
	   Inherits BaseObject
	  Public Sub New(ByVal session As Session)
		  MyBase.New(session)
	  End Sub
	  Private productName_Renamed As String
	  Public Property ProductName() As String
		 Get
			Return productName_Renamed
		 End Get
		 Set(ByVal value As String)
			SetPropertyValue("ProductName", productName_Renamed, value)
		 End Set
	  End Property
	  <Association("P-To-C")> _
	  Public ReadOnly Property Accessories() As XPCollection(Of Accessory)
		 Get
			 Return GetCollection(Of Accessory)("Accessories")
		 End Get
	  End Property
   End Class
   Public Class Accessory
	   Inherits BaseObject
   Public Sub New(ByVal session As Session)
	   MyBase.New(session)
   End Sub
   Private accessoryName_Renamed As String
   Public Property AccessoryName() As String
	  Get
		 Return accessoryName_Renamed
	  End Get
	  Set(ByVal value As String)
		 SetPropertyValue("AccessoryName", accessoryName_Renamed, value)
	  End Set
   End Property
   Private isGlobal_Renamed As Boolean
   Public Property IsGlobal() As Boolean
	  Get
		 Return isGlobal_Renamed
	  End Get
	  Set(ByVal value As Boolean)
		 SetPropertyValue("IsGlobal", isGlobal_Renamed, value)
	  End Set
   End Property
   Private product_Renamed As Product
   <Association("P-To-C")> _
   Public Property Product() As Product
	  Get
		 Return product_Renamed
	  End Get
	  Set(ByVal value As Product)
		 SetPropertyValue("Product", product_Renamed, value)
	  End Set
   End Property
   End Class

End Namespace
