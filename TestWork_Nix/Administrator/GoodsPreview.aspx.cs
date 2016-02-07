using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using System.Data;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix.Administrator
{
    public partial class GoodsPreview : System.Web.UI.Page
    {
        int selectedCategoryID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SelectedCategoryID"] != null)
            {
                int.TryParse(Session["SelectedCategoryID"].ToString(), out selectedCategoryID);
                ListGoods1.SelectedCategoryID = selectedCategoryID;

                if (!Page.IsPostBack)
                {
                    CategoriesActions categotiesActions = new CategoriesActions();
                    LabelSelectedCategory.Text = "Category selected: " +
                    categotiesActions.FindCategoryName(selectedCategoryID);
                }
            }
        }

        protected void LinkButtonAddGoods_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoodsAdd.aspx");
        }
    }
}
