using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using TestWork_Nix.GoodsElements.Controls;
using Business_Logic_Layer;
using Business_Logic_Layer.Help;

namespace TestWork_Nix.Administrator
{
    public partial class GoodsEdit : System.Web.UI.Page
    {
        int selectedGoodsID;

        protected void Page_Load(object sender, EventArgs e)
        {
            GoodsEditControl1.Click += new GoodsEditControl.ControlEventHandler(GoodsEditControl1_Click);
        }

        void GoodsEditControl1_Click(object sender, ControlEventArgs e)
        {
                
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["SelectedGoodsID"] != null)
            {
                selectedGoodsID = int.Parse(Session["SelectedGoodsID"].ToString());
                GoodsEditControl1.GoodsID = selectedGoodsID;

                GoodsActions goodsActions = new GoodsActions();
                var goods = goodsActions.FindSelectedGoods(selectedGoodsID);

                DataSourceAdapterBinding dataSourceAdapterBinding = new DataSourceAdapterBinding();
                GoodsPreviewControl1.DataSource = dataSourceAdapterBinding.AdapterFill(goods);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            GoodsEditControl1.Click -= GoodsEditControl1_Click;
        }
    }
}
