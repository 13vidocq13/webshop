using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.CRUD;
using EntitiesAndMapping.Entities;

namespace Business_Logic_Layer
{
    public class RelationsCategoriesGoodsActions
    {
        public List<Categories> GetCategoriesForGoods(int goodsId)
        {
            RelationsCategoriesGoodsCRUD relationsCategoriesGoodsCRUD = new RelationsCategoriesGoodsCRUD();
            return relationsCategoriesGoodsCRUD.GetCategoriesForGoods(goodsId);
        }

        public string AddCategoriesToGoods(int selectedCategoryID, int selectedGoodsID)
        {
            RelationsCategoriesGoodsCRUD relationsCategoriesGoodsCRUD = new RelationsCategoriesGoodsCRUD();
            return relationsCategoriesGoodsCRUD.AddCategoriesToGoods(selectedCategoryID, selectedGoodsID);
        }

        public void DeleteCategoriesFromGoods(int categoryID, int goodsID)
        {
            RelationsCategoriesGoodsCRUD relationsCategoriesGoodsCRUD = new RelationsCategoriesGoodsCRUD();
            relationsCategoriesGoodsCRUD.DeleteCategoriesFromGoods(categoryID, goodsID);
        }
    }
}
