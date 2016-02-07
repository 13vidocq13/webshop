//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NHibernate;
//using EntitiesAndMapping.Entities;
//using EntitiesAndMapping.Entities.Base;
//using Data_Access_Layer.SessionManager;
//using NHibernate.Linq;


//namespace Data_Access_Layer
//{
//    public class CRUD
//    {
//        public void CreateRecord(BaseEntity entity)
//        {
//            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
//            {
//                Sessions.NewSession.SaveOrUpdate(entity);
//                Sessions.NewSession.Flush();
//            }
//        }

//        public void UpdateRecord(BaseEntity entity)
//        {

//        }

//        public void DeleteRecord(string entityName, int entityID)
//        {
//            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
//            {
//                Sessions.NewSession.Delete(entityName, entityID);
//                Sessions.NewSession.Flush();
//            }
//        }

//        //public void DeleteRecord(BaseEntity entity)
//        //{
//        //    using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
//        //    {
//        //        Sessions.NewSession.Delete(entity);
//        //        Sessions.NewSession.Flush();
//        //    }
//        //}
//    }
//}
