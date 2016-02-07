using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.CRUD;
using EntitiesAndMapping.Entities;

namespace Business_Logic_Layer
{
    public class GoodsActions
    {
        public List<Goods> GetGoods(int categoryID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.GetGoods(categoryID);
        }

        public List<Goods> GetGoodsMostSold()
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.GetGoodsMostSold();
        }

        public byte[] FindMiniPicture(int goodsID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.FindMiniPicture(goodsID);
        }

        public byte[] FindPicture(int goodsID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.FindPicture(goodsID);
        }

        public int AddGoods(Goods goods, GoodsImages goodsImages, int categotyID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.AddGoods(goods, goodsImages, categotyID);
        }

        public Goods FindSelectedGoods(int ID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.FindSelectedGoods(ID);
        }

        public void SaveEditGoods(Goods goods, GoodsImages goodsImages, int goodsID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            goodsCRUD.SaveEditGoods(goods, goodsImages, goodsID);
        }

        public void DeleteGoods(int goodsID)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            goodsCRUD.DeleteGoods(goodsID);
        }

        public IList<Goods> LastAddedGoods(int firstResult, int selectCount)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.LastAddedGoods(firstResult, selectCount);
        }

        public IList<Goods> HaveDiscountGoods(int firstResult, int selectCount)
        {
            GoodsCRUD goodsCRUD = new GoodsCRUD();
            return goodsCRUD.HaveDiscountGoods(firstResult, selectCount);
        }
    }
}
