using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;

namespace Business_Logic_Layer.Help
{
    public class DataSourceAdapterBinding
    {
        public List<DataSourceAdapter> AdapterFill(IList<Goods> listGoods)
        {
            List<DataSourceAdapter> returnList = new List<DataSourceAdapter>();

            foreach (Goods item in listGoods)
            {
                DataSourceAdapter dataSourceAdapter = new DataSourceAdapter();
                dataSourceAdapter.ImageURL = "ImageHelp.aspx?imgID=" + item.ID;
                dataSourceAdapter.ID = item.ID;
                dataSourceAdapter.Name = item.Name;
                dataSourceAdapter.Price = item.Price.ToString();
                dataSourceAdapter.IsDiscount = item.IsDiscount;
                dataSourceAdapter.Discount = item.Discount.ToString();
                dataSourceAdapter.AdditionDate = item.AdditionDate.ToShortDateString();

                returnList.Add(dataSourceAdapter);
            }

            return returnList;
        }

        public DataSourceAdapter AdapterFill(Goods goods)
        {
            DataSourceAdapter dataSourceAdapter = new DataSourceAdapter();

            dataSourceAdapter.Name = goods.Name;
            dataSourceAdapter.Price = goods.Price.ToString();
            dataSourceAdapter.IsDiscount = goods.IsDiscount;
            dataSourceAdapter.Discount = goods.Discount.ToString();

            dataSourceAdapter.ImageURL = "GetBigImage.aspx?imgID=" + goods.ID;

            return dataSourceAdapter;
        }

        public IList<DataSourceAdapter> AdapterFillPriceCalculate(List<Goods> listGoods
            , int discount)
        {
            List<DataSourceAdapter> returnList = AdapterFill(listGoods);

            for (int i = 0; i < returnList.Count; i++)
            {
                float cost = listGoods[i].Price;

                if (listGoods[i].IsDiscount)
                {
                    cost -= listGoods[i].Price * (float)listGoods[i].Discount / 100;
                }

                cost -= cost * discount / 100;

                returnList[i].Cost = cost;
            }

            return returnList;
        }
    }
}
