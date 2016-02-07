using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Data_Access_Layer.SessionManager;
using EntitiesAndMapping.Entities.Base;
using EntitiesAndMapping.Entities;
using NHibernate.Linq;
using System.IO;
using NHibernate.Criterion;
using System.Data.SqlClient;


namespace Data_Access_Layer.CRUD
{
    public class GoodsCRUD
    {
        List<int> GetGoodsIDs(int categoryID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                return (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
                            where q.Categories.ID == categoryID
                            select q.Goods.ID).ToList<int>();
            }  
        }

        public List<Goods> GetGoods(int categoryID)
        {
            List<int> goodsIDsList = GetGoodsIDs(categoryID);
            List<Goods> returnList = new List<Goods>();

            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                foreach (int item in goodsIDsList)
                {
                    var query = (from q in Sessions.NewSession.Linq<Goods>()
                                 where q.ID == item
                                 select q).FirstOrDefault<Goods>();
                    returnList.Add(query);
                }

                return returnList;
            }
        }

        public List<Goods> GetGoodsMostSold()
        {
            List<Goods> returnList = new List<Goods>();
            IList<int> listIntMostSold = MostSoldGoodsIDs();

            foreach (int item in listIntMostSold)
            {
                var query = (from q in Sessions.NewSession.Linq<Goods>()
                             where q.ID == item
                             select q).FirstOrDefault<Goods>();
                returnList.Add(query);
            }

            return returnList;
        }

        public byte[] FindMiniPicture(int goodsID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                var query = (from q in Sessions.NewSession.Linq<GoodsImages>()
                             where q.Goods.ID == goodsID
                             select q.MiniImage).FirstOrDefault<byte[]>();
               
                if (query != null)
                {
                    return query;   
                }
                else
                {
                    return (from q in Sessions.NewSession.Linq<GoodsImages>()
                            where q.ID == 1
                            select q.MiniImage).FirstOrDefault<byte[]>();
                }
            }
        }

        public byte[] FindPicture(int goodsID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                var query = (from q in Sessions.NewSession.Linq<GoodsImages>()
                             where q.Goods.ID == goodsID
                             select q.Image).FirstOrDefault<byte[]>();

                if (query != null)
                {
                    return query;
                }
                else
                {
                    return (from q in Sessions.NewSession.Linq<GoodsImages>()
                            where q.ID == 1
                            select q.Image).FirstOrDefault<byte[]>();
                }
            }
        }

        public int AddGoods(Goods goods, GoodsImages goodsImages, int categoryID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                using (var transaction = Sessions.NewSession.BeginTransaction())
                {
                    //write goods in db
                    Sessions.NewSession.SaveOrUpdate(goods);
                    Sessions.NewSession.Flush();

                    //write relations in db
                    var entity = new RelationsCategoriesGoods();
                    entity.Categories = Sessions.NewSession.Get<Categories>(categoryID);
                    entity.Goods = Sessions.NewSession.Get<Goods>(goods.ID);
                    Sessions.NewSession.SaveOrUpdate(entity);
                    Sessions.NewSession.Flush();
                    
                    //write images in db
                    goodsImages.Goods = Sessions.NewSession.Get<Goods>(goods.ID);
                    Sessions.NewSession.SaveOrUpdate(goodsImages);
                    Sessions.NewSession.Flush();

                    transaction.Commit();
                }
            }

            return goodsImages.ID;
        }

        public void SaveEditGoods(Goods goods, GoodsImages goodsImages, int goodsID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                using (var transaction = Sessions.NewSession.BeginTransaction())
                {
                    var entity = Sessions.NewSession.Get<Goods>(goodsID);
                    entity.Name = goods.Name;
                    entity.Price = goods.Price;
                    entity.Discount = goods.Discount;
                    entity.IsDiscount = goods.IsDiscount;
                    Sessions.NewSession.SaveOrUpdate(entity);
                    Sessions.NewSession.Flush();

                    var images = (from q in Sessions.NewSession.Linq<GoodsImages>()
                                      where q.Goods.ID == goodsID
                                      select q).FirstOrDefault<GoodsImages>();

                    if (goodsImages.Image != null)
                    {
                        images.Image = goodsImages.Image; 
                    }
                    if (goodsImages.MiniImage != null)
                    {
                        images.MiniImage = goodsImages.MiniImage;
                    }

                    Sessions.NewSession.SaveOrUpdate(images);
                    Sessions.NewSession.Flush();

                    transaction.Commit();
                }
            }
        }

        public Goods FindSelectedGoods(int ID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                return (from q in Sessions.NewSession.Linq<Goods>()
                        where q.ID == ID
                        select q).FirstOrDefault<Goods>();
            }
        }

        public void DeleteGoods(int goodsID)
        {
            var entity = Sessions.NewSession.Get<Goods>(goodsID);
            Sessions.NewSession.Delete(entity);
            Sessions.NewSession.Flush();
        }

        IList<int> MostSoldGoodsIDs()
        {
            //ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(PurchasesNote));
            //criteria.SetProjection(Projections.Alias(Projections.GroupProperty("GoodsID"), "Goods"));

            //criteria.AddOrder(Order.Desc("Goods"));
            //return criteria.List<int>();

            string query = @"select top 10 GoodsID, count(GoodsID)
                                        from PurchasesNote
                                        group by GoodsID
                                        order by count(GoodsID) desc";
            string connectionString = @"Data Source=(local)\SQLEXPRESS;
                                                    Initial Catalog=WebShop;
                                                    Integrated Security=True";
            IList<int> returnList = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int item = (int)reader[0];
                        returnList.Add(item);
                    }
                }
            }

            return returnList;
        }

        
        public IList<Goods> LastAddedGoods(int firstResult, int selectCount)
        {
            ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(Goods));

            criteria.AddOrder(Order.Desc("AdditionDate"));
            criteria.SetMaxResults(selectCount);
            criteria.SetFirstResult(firstResult);

            return criteria.List<Goods>();
        }

        public IList<Goods> HaveDiscountGoods(int firstResult, int selectCount)
        {
            ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(Goods));

            criteria.Add(NHibernate.Criterion.Expression.Eq("IsDiscount", true));
            criteria.AddOrder(NHibernate.Criterion.Order.Desc("AdditionDate"));
            criteria.SetFirstResult(firstResult);
            criteria.SetMaxResults(selectCount);
            return criteria.List<Goods>();
        }
    }
}
