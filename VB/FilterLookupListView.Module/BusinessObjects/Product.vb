Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace FilterLookupListView.Module.BusinessObjects
   '[DefaultClassOptions]
   Public Class Product
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
      End Sub
      Public Overrides Sub AfterConstruction()
         MyBase.AfterConstruction()
      End Sub
'INSTANT VB NOTE: The variable productName was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _productName As String
      Public Property ProductName() As String
         Get
            Return _productName
         End Get
         Set(ByVal value As String)
            SetPropertyValue("ProductName", _productName, value)
         End Set
      End Property
      <Association("P-To-C")> _
      Public ReadOnly Property Accessories() As XPCollection(Of Accessory)
         Get
            Return GetCollection(Of Accessory)("Accessories")
         End Get
      End Property
   End Class

End Namespace
