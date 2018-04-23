Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace FilterLookupListView.Module.BusinessObjects
   '[DefaultClassOptions]
   Public Class Accessory
       Inherits BaseObject

      Public Sub New(ByVal session As Session)
          MyBase.New(session)
      End Sub
      Public Overrides Sub AfterConstruction()
         MyBase.AfterConstruction()
      End Sub
'INSTANT VB NOTE: The variable accessoryName was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _accessoryName As String
      Public Property AccessoryName() As String
         Get
            Return _accessoryName
         End Get
         Set(ByVal value As String)
            SetPropertyValue("AccessoryName", _accessoryName, value)
         End Set
      End Property
'INSTANT VB NOTE: The variable isGlobal was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _isGlobal As Boolean
      Public Property IsGlobal() As Boolean
         Get
            Return _isGlobal
         End Get
         Set(ByVal value As Boolean)
            SetPropertyValue("IsGlobal", _isGlobal, value)
         End Set
      End Property
'INSTANT VB NOTE: The variable product was renamed since Visual Basic does not allow variables and other class members to have the same name:
      Private _product As Product
      <Association("P-To-C")> _
      Public Property Product() As Product
         Get
            Return _product
         End Get
         Set(ByVal value As Product)
            SetPropertyValue("Product", _product, value)
         End Set
      End Property
   End Class

End Namespace
