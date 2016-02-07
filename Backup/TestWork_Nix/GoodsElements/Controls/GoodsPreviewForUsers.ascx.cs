using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer.Help;

namespace TestWork_Nix.GoodsElements.Controls
{
    public partial class GoodsPreviewForUsers : System.Web.UI.UserControl
    {
        IList<DataSourceAdapter> goodsDataSource = new List<DataSourceAdapter>();
        public event EventHandler Item_Command;

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater2.DataSource = goodsDataSource;
            Repeater2.DataBind();
        }

        public IList<DataSourceAdapter> DataSource
        {
            get
            {
                return goodsDataSource;
            }
            set
            {
                goodsDataSource = value;
            }
        }

        //public LinkButton linkButtonNext
        //{
        //    get
        //    {
        //        return LinkButtonNext;
        //    }
        //    set
        //    {
        //        LinkButtonNext = value;
        //    }
        //}

        public Repeater repeater
        {
            get
            {
                return Repeater2;
            }
            set
            {
                Repeater2 = value;
            }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int selectedID = goodsDataSource[e.Item.ItemIndex].ID;
            Session["selectedID"] = selectedID;
        }
    }
}