using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate.Linq;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer;
using System.Web.Security;
using Business_Logic_Layer.Help;

namespace TestWork_Nix
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Login1.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GoodsPreviewLastAdded.repeater.ItemCommand += new RepeaterCommandEventHandler(LastAddedNext_ItemCommand);
            GoodsPreviewDiscount.repeater.ItemCommand += new RepeaterCommandEventHandler(DiscountNext_ItemCommand);
            GoodsPreviewMostSold.repeater.ItemCommand += new RepeaterCommandEventHandler(MostSoldNext_ItemCommand);

            //if (Cache["LastAdded"] != null)
            //{
            //    GoodsPreviewLastAdded.DataSource = (IList<DataSourceAdapter>)Cache["LastAdded"];
            //}
            //else
            //{
            //    GoodsActions goodsActions = new GoodsActions();
            //    IList<Goods> listGoods = goodsActions.LastAddedGoods(0, 10);
            //    DataSourceAdapterBinding dataSourceAdapterBinding = new DataSourceAdapterBinding();

            //    GoodsPreviewLastAdded.DataSource = dataSourceAdapterBinding.AdapterFill(listGoods);
            //    Cache.Insert("LastAdded", GoodsPreviewLastAdded.DataSource, null,
            //        DateTime.Now.AddMinutes(60), TimeSpan.Zero);
            //}

            if (!Page.IsPostBack)
            {
                GoodsActions goodsActions = new GoodsActions();
                IList<Goods> listGoods = goodsActions.LastAddedGoods(0, 10);
                DataSourceAdapterBinding dataSourceAdapterBinding = new DataSourceAdapterBinding();

                GoodsPreviewLastAdded.DataSource = dataSourceAdapterBinding.AdapterFill(listGoods);
                ViewState["LastAdded"] = GoodsPreviewLastAdded.DataSource;
                

                listGoods.Clear();
                listGoods = goodsActions.HaveDiscountGoods(0, 10);
                GoodsPreviewDiscount.DataSource = dataSourceAdapterBinding.AdapterFill(listGoods); 
                ViewState["Discount"] = GoodsPreviewDiscount.DataSource;

                listGoods.Clear();
                listGoods = goodsActions.GetGoodsMostSold();
                GoodsPreviewMostSold.DataSource = dataSourceAdapterBinding.AdapterFill(listGoods);
                ViewState["MostSold"] = GoodsPreviewMostSold.DataSource;
            }
            else
            {
                if (ViewState["LastAdded"] != null)
                {
                    GoodsPreviewLastAdded.DataSource = (IList<DataSourceAdapter>)ViewState["LastAdded"];
                }

                if (ViewState["Discount"] != null)
                {
                    GoodsPreviewDiscount.DataSource = (IList<DataSourceAdapter>)ViewState["Discount"];
                }
                if (ViewState["MostSold"] != null)
                {
                    GoodsPreviewMostSold.DataSource = (IList<DataSourceAdapter>) ViewState["MostSold"];
                }
            }
        }

        void MostSoldNext_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("GoodsPreview.aspx");
        }

        void DiscountNext_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("GoodsPreview.aspx");
        }

        void LastAddedNext_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Response.Redirect("GoodsPreview.aspx");
        }

        void LastAddedNext_Click(object sender, EventArgs e)
        {
            
        }

        void DiscountNext_Click(object sender, EventArgs e)
        {

        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            GoodsPreviewLastAdded.repeater.ItemCommand -= LastAddedNext_ItemCommand;
            GoodsPreviewDiscount.repeater.ItemCommand -= DiscountNext_ItemCommand;
            GoodsPreviewMostSold.repeater.ItemCommand -= MostSoldNext_ItemCommand;
        }
    }
}
