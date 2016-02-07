using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;
using TestWork_Nix.GoodsElements.Controls;

namespace TestWork_Nix.Administrator
{
    public partial class GoodsAdd : System.Web.UI.Page
    {
        public byte[] miniImage;
        int SelectedCategoryID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedCategoryID"] != null)
            {
                int.TryParse(Session["SelectedCategoryID"].ToString(), out SelectedCategoryID);

                if (SelectedCategoryID > 0)
	            {
                    GoodsControl1.GoodsID = SelectedCategoryID;
	            }
            }
        }

        void ControlGoodsPreview1_DataBinding(object sender, GoodsPreviewEventArgs e)
        {
            
        }

        //void ButtonSubmit_Click(object sender, EventArgs e)
        //{
            
        //}

        //protected void ButtonAdd_Click(object sender, EventArgs e)
        //{
        //    GoodsActions goodsActions = new GoodsActions();

        //    Response.Redirect("GoodsPreview.aspx");

        //}
    }
}
