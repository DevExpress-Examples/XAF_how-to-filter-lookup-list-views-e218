using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace FilterLookupListViewrsScenario1.Module {
   [DefaultClassOptions]
   public class Order : BaseObject {
      public Order(Session session) : base(session) { }
      private Product product;
      public Product Product {
         get {
            return product;
         }
         set {
            SetPropertyValue("Product", ref product, value);
         }
      }
      private Accessory accessory;

      //Filter the Lookup Property Editor's data source
      [DataSourceProperty("Product.Accessories")]
      public Accessory Accessory {
         get {
            return accessory;
         }
         set {
            SetPropertyValue("Accessory", ref accessory, value);
         }
      }
   }
   public class Product : BaseObject {
      public Product(Session session) : base(session) { }
      private String productName;
      public String ProductName {
         get {
            return productName;
         }
         set {
            SetPropertyValue("ProductName", ref productName, value);
         }
      }
      [Association("P-To-C")]
      public XPCollection<Accessory> Accessories {
         get { return GetCollection<Accessory>("Accessories"); }
      }
   }
   public class Accessory : BaseObject {
   public Accessory(Session session) : base(session) { }
   private String accessoryName;
   public String AccessoryName {
      get { 
         return accessoryName; 
      }
      set {
         SetPropertyValue("AccessoryName", ref accessoryName, value);
      }
   }
   private bool isGlobal;
   public bool IsGlobal {
      get {
         return isGlobal;
      }
      set {
         SetPropertyValue("IsGlobal", ref isGlobal, value);
      }
   }
   private Product product;
   [Association("P-To-C")]
   public Product Product { 
      get {
         return product;
      } 
      set {
         SetPropertyValue("Product", ref product, value);
      } 
   }
}

}
