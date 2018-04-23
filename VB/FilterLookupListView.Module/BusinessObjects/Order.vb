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
'INSTANT VB NOTE: The variable orderId was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _orderId As Integer
      Public Property OrderId() As Integer
         Get
            Return _orderId
         End Get
         Set(ByVal value As Integer)
            SetPropertyValue("OrderId", _orderId, value)
         End Set
      End Property
'INSTANT VB NOTE: The variable product was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _product As Product
      Public Property Product() As Product
         Get
            Return _product
         End Get
         Set(ByVal value As Product)
            SetPropertyValue("Product", _product, value)
            'Scenario 4 - Custom Lookup Property Data Source
            ' Refresh the Accessory Property data source 
            RefreshAvailableAccessories()
         End Set
      End Property

'INSTANT VB NOTE: The variable accessory was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _accessory As Accessory
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
            Return _accessory
         End Get
         Set(ByVal value As Accessory)
            SetPropertyValue("Accessory", _accessory, value)
         End Set
      End Property

      #Region "Scenario 4 - Custom Lookup Property Data Source"
'INSTANT VB NOTE: The variable availableAccessories was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _availableAccessories As XPCollection(Of Accessory)
      <Browsable(False)> _
      Public ReadOnly Property AvailableAccessories() As XPCollection(Of Accessory) ' Prohibits showing the AvailableAccessories collection separately
         Get
            If _availableAccessories Is Nothing Then
               ' Retrieve all Accessory objects 
               _availableAccessories = New XPCollection(Of Accessory)(Session)
               ' Filter the retrieved collection according to current conditions 
               RefreshAvailableAccessories()
            End If
            ' Return the filtered collection of Accessory objects 
            Return _availableAccessories
         End Get
      End Property
      Private Sub RefreshAvailableAccessories()
         If _availableAccessories Is Nothing Then
            Return
         End If
         ' Process the situation when the Product is not specified (see the Scenario 3 above) 
         If Product Is Nothing Then
            ' Show only Global Accessories when the Product is not specified 
            _availableAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
         Else
            ' Leave only the current Product's Accessories in the availableAccessories collection 
            _availableAccessories.Criteria = New BinaryOperator("Product", Product)
            If IncludeGlobalAccessories = True Then
               ' Add Global Accessories 
               Dim availableGlobalAccessories As New XPCollection(Of Accessory)(Session)
               availableGlobalAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
               _availableAccessories.AddRange(availableGlobalAccessories)
            End If
         End If
         ' Set null for the Accessory property to allow an end-user  
         'to set a new value from the refreshed data source 
         Accessory = Nothing
      End Sub
'INSTANT VB NOTE: The variable includeGlobalAccessories was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _includeGlobalAccessories As Boolean
      <ImmediatePostData> _
      Public Property IncludeGlobalAccessories() As Boolean 'Use this attribute to refresh the Accessory
         Get
            Return _includeGlobalAccessories
         End Get
         Set(ByVal value As Boolean)
            If _includeGlobalAccessories <> value Then
               _includeGlobalAccessories = value
               If Not IsLoading Then
                  ' Refresh the Accessory Property data source                     
                  RefreshAvailableAccessories()
                  SetPropertyValue("IncludeGlobalAccessories", _includeGlobalAccessories, value)
               End If
            End If
         End Set
      End Property
      #End Region 
   End Class
End Namespace
