Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.ComponentModel
Imports DevExpress.Data.Filtering


<DefaultClassOptions()> _
Public Class Order
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private fProduct As Product
    Private fAccessory As Accessory
    <DataSourceProperty("AvailableAccessories")> _
   Public Property Accessory() As Accessory
        Get
            Return fAccessory
        End Get
        Set(ByVal value As Accessory)
            SetPropertyValue("Accessory", fAccessory, value)
        End Set
    End Property
    Private fAvailableAccessories As XPCollection(Of Accessory)
    <Browsable(False)> _
    Public ReadOnly Property AvailableAccessories() As XPCollection(Of Accessory)
        Get
            If fAvailableAccessories Is Nothing Then
                ' Retrieve all Accessory objects
                fAvailableAccessories = New XPCollection(Of Accessory)(Session)
                ' Filter the retrieved collection according to current conditions
                RefreshAvailableAccessories()
            End If
            ' Return the filtered collection of Accessory objects
            Return fAvailableAccessories
        End Get
    End Property
    Private Sub RefreshAvailableAccessories()
        If fAvailableAccessories Is Nothing Then
            Return
        End If
        ' Process the situation when the Product is not specified (see the Scenario 3 above)
        If Product Is Nothing Then
            ' Show only Global Accessories when the Product is not specified
            fAvailableAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
        Else
            ' Leave only the current Product's Accessories in the availableAccessories collection
            fAvailableAccessories.Criteria = New BinaryOperator("Product", Product)
            If IncludeGlobalAccessories = True Then
                ' Add Global Accessories
                Dim availableGlobalAccessories As XPCollection(Of Accessory) = _
                   New XPCollection(Of Accessory)(Session)
                availableGlobalAccessories.Criteria = CriteriaOperator.Parse("[IsGlobal] = true")
                fAvailableAccessories.AddRange(availableGlobalAccessories)
            End If
        End If
        ' Set Nothing for the Accessory property to allow an end-user 
        'to set a new value from the refreshed data source
        Accessory = Nothing
    End Sub
    Public Property Product() As Product
        Get
            Return fProduct
        End Get
        Set(ByVal value As Product)
            SetPropertyValue("Product", fProduct, value)
            ' Refresh the Accessory Property data source
            RefreshAvailableAccessories()
        End Set
    End Property
    Private fIncludeGlobalAccessories As Boolean
    <ImmediatePostData()> _
    Public Property IncludeGlobalAccessories() As Boolean
        Get
            Return fIncludeGlobalAccessories
        End Get
      Set
            If fIncludeGlobalAccessories <> Value Then
                fIncludeGlobalAccessories = Value
                If (Not IsLoading) Then
                    ' Refresh the Accessory Property data source					
                    RefreshAvailableAccessories()
                    SetPropertyValue("IncludeGlobalAccessories", fIncludeGlobalAccessories, value)
                End If
            End If
        End Set
    End Property
End Class
Public Class Product
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Private productfName As String
    Public Property ProductName() As String
        Get
            Return productfName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ProductName", productfName, value)
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
    Private accessoryfName As String
    Public Property AccessoryName() As String
        Get
            Return accessoryfName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("AccessoryName", accessoryfName, value)
        End Set
    End Property
    Private fIsGlobal As Boolean
    Public Property IsGlobal() As Boolean
        Get
            Return fIsGlobal
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue("IsGlobal", fIsGlobal, value)
        End Set
    End Property
    Private fProduct As Product
    <Association("P-To-C")> _
    Public Property Product() As Product
        Get
            Return fProduct
        End Get
        Set(ByVal value As Product)
            SetPropertyValue("Product", fProduct, value)
        End Set
    End Property
End Class


