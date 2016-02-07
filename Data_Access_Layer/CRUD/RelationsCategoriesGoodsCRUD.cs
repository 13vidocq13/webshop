using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using Data_Access_Layer.SessionManager;
using NHibernate.Linq;

namespace Data_Access_Layer.CRUD
{
    public class RelationsCategoriesGoodsCRUD
    {
        private List<int> GetCategoriesIDsForGoods(int goodsId)
        {
            return (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
                    where q.Goods.ID == goodsId
                    select q.Categories.ID).ToList<int>();
        }

        public List<Categories> GetCategoriesForGoods(int goodsId)
        {
            List<Categories> returnList = new List<Categories>();
            List<int> CategoriesIDsForGoodsList = GetCategoriesIDsForGoods(goodsId);

            foreach (var item in CategoriesIDsForGoodsList)
            {
                var query = (from q in Sessions.NewSession.Linq<Categories>()
                                 where q.ID == item
                                 select q).FirstOrDefault<Categories>();
                returnList.Add(query);
            }

            return returnList;
        }

        private bool isContains(int selectedCategoryID, int selectedGoodsID)
        {
            var query = (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
                         where q.Categories.ID == selectedCategoryID
                         where q.Goods.ID == selectedGoodsID
                         select q).FirstOrDefault<RelationsCategoriesGoods>();
            
            if (query != null)
            {
                return true;    
            }
            
            return false;

            //List<int> li = new List<int>();
            //var query = (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
            //             where q.Goods.ID == selectedGoodsID
            //             select q.Goods.ID).ToList<int>();
            //li = query.ToList<int>();

            //var que = (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
            //               where )

            //if (Contains<RelationsCategoriesGoods>(query))
            //{
                
            //}
        }

        public string AddCategoriesToGoods(int selectedCategoryID, int selectedGoodsID)
        {
            if (!isContains(selectedCategoryID, selectedGoodsID))
            {
                var entity = new RelationsCategoriesGoods();
                entity.Categories = Sessions.NewSession.Get<Categories>(selectedCategoryID);
                entity.Goods = Sessions.NewSession.Get<Goods>(selectedGoodsID);
                Sessions.NewSession.SaveOrUpdate(entity);
                Sessions.NewSession.Flush();

                return "Added successfully";
            }
            else
            {
                return "Goods have a contains this category, please select another category";
            }
        }

        public void DeleteCategoriesFromGoods(int categoryID, int goodsID)
        {
            //var entity = new RelationsCategoriesGoods();
            //entity.Categories = Sessions.NewSession.Get<Categories>(categoryID);
            //entity.Goods = Sessions.NewSession.Get<Goods>(goodsID);
            Sessions.NewSession.Delete(FindEntity(categoryID, goodsID));
            Sessions.NewSession.Flush();
        }

        private RelationsCategoriesGoods FindEntity(int categoryID, int goodsID)
        {
            return (from q in Sessions.NewSession.Linq<RelationsCategoriesGoods>()
                    where q.Categories.ID == categoryID
                    where q.Goods.ID == goodsID
                    select q).FirstOrDefault<RelationsCategoriesGoods>();
        }
    }
}
