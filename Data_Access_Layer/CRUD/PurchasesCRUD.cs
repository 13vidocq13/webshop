using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.SessionManager;
using EntitiesAndMapping.Entities;
using EntitiesAndMapping.Help;

namespace Data_Access_Layer.CRUD
{
    public class PurchasesCRUD
    {
        public void AddPurchase(PurchaseAdapterEntities entities)
        {
            using (var transaction = Sessions.NewSession.BeginTransaction())
            {
                //write in Purchases table
                var purchasesEntity = new Purchases();
                purchasesEntity.MethodOfPayment = entities.MethodOfPayment;
                purchasesEntity.PurchaseDateTime = entities.PurchaseDateTime;
                purchasesEntity.aspnet_Users = Sessions.NewSession.Get<aspnet_Users>(entities.UserID);
                Sessions.NewSession.SaveOrUpdate(purchasesEntity);
                Sessions.NewSession.Flush();

                //write in PurchasesNote table
                foreach (int item in entities.GoodsIDs)
                {
                    var purchasesNoteEntity = new PurchasesNote();
                    purchasesNoteEntity.Purchases = Sessions.NewSession.Get<Purchases>(purchasesEntity.ID);
                    purchasesNoteEntity.Goods = Sessions.NewSession.Get<Goods>(item);

                    //purchasesNoteEntity.PurchasesID = purchasesEntity.ID;
                    purchasesNoteEntity.GoodsID = item;

                    Sessions.NewSession.SaveOrUpdate(purchasesNoteEntity);
                    Sessions.NewSession.Flush();
                }

                transaction.Commit();
            }
        }
    }
}
