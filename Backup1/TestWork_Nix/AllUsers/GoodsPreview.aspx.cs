using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer;
using Business_Logic_Layer.Help;

namespace TestWork_Nix.AllUsers
{
    public partial class GoodsPreview : System.Web.UI.Page
    {
        Goods goods;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["selectedID"] != null)
            {
                int selectedID = (int)Session["selectedID"];

                goods = new Goods();
                GoodsActions goodsActions = new GoodsActions();
                goods = goodsActions.FindSelectedGoods(selectedID);
                DataSourceAdapterBinding dataSourceAdapterBinding = new DataSourceAdapterBinding();
                GoodsPreview1.DataSource = dataSourceAdapterBinding.AdapterFill(goods);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Goods> orderList = new List<Goods>();
            if (Session["OrderList"] != null)
            {
                orderList = (List<Goods>)Session["OrderList"];
            }
            orderList.Add(goods);
            Session["OrderList"] = orderList;
            Response.Redirect("Order.aspx");
        }
    }
}
