using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.CRUD;
using EntitiesAndMapping.Help;

namespace Business_Logic_Layer
{
    public class PurchasesActions
    {
        public void AddPurchase(PurchaseAdapterEntities entities)
        {
            PurchasesCRUD purchasesCRUD = new PurchasesCRUD();
            purchasesCRUD.AddPurchase(entities);
        }
    }
}
