using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix.Administrator
{
    public partial class ManageGoodsInCategory : System.Web.UI.Page
    {
        int SelectedGoodsID;
        bool isSelected;
        List<Categories> categoriesGoodsList;

        protected void Page_Load(object sender, EventArgs e)
        {
            TreeViewControl1.SelectedNodeChanged += new TestWork_Nix.Categoties.Controls.TreeViewCategoriesControl.TreeViewManageEventHandler(TreeViewControl1_SelectedNodeChanged);

            if (Session["SelectedGoodsID"] != null)
            {
                SelectedGoodsID = int.Parse(Session["SelectedGoodsID"].ToString());
                
                if (!Page.IsPostBack)
	            {
                    categoriesGoodsList = new List<Categories>();
                    RelationsCategoriesGoodsActions R_C_G_Actions = new RelationsCategoriesGoodsActions();
                    categoriesGoodsList = R_C_G_Actions.GetCategoriesForGoods(SelectedGoodsID);
                    ViewState["categoriesGoodsList"] = categoriesGoodsList;
                    RepeaterGoodsCategories.DataSource = categoriesGoodsList;
                    RepeaterGoodsCategories.DataBind();
                    GoodsActions goodsActions = new GoodsActions();		 
	                Label1.Text = "Manage categories for " + (goodsActions
                        .FindSelectedGoods(SelectedGoodsID)).Name + ":";
                }
            }
        }

        void TreeViewControl1_SelectedNodeChanged(object sender, TestWork_Nix.Categoties.Controls.TreeViewManageEventArgs e)
        {
            if (!isSelected)
            {
                ButtonAdd.Enabled = true;
                isSelected = true;
            }

            return;
        }

        protected void RepeaterGoodsCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int selectedIndex = e.Item.ItemIndex;

            if (ViewState["categoriesGoodsList"] != null)
            {
                List<Categories> categoriesGoodsList = 
                    (List<Categories>)ViewState["categoriesGoodsList"];
                int categoryID = categoriesGoodsList[selectedIndex].ID;
                RelationsCategoriesGoodsActions R_C_G_Actions = new RelationsCategoriesGoodsActions();
                R_C_G_Actions.DeleteCategoriesFromGoods(categoryID, SelectedGoodsID);
                categoriesGoodsList.RemoveAt(selectedIndex);
                RepeaterGoodsCategories.DataSource = categoriesGoodsList;
                RepeaterGoodsCategories.DataBind();
                ViewState["categoriesGoodsList"] = categoriesGoodsList;
            }
        }

        protected void LinkButtonAGtC_Click(object sender, EventArgs e)
        {
            PanelAddCategory.Visible = true;
            PanelAddCategory.Enabled = true;
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            RelationsCategoriesGoodsActions R_C_G_Actions = new RelationsCategoriesGoodsActions();
            int SelectedCategoryID = TreeViewControl1.SelectedNodeID;
            LabelAddSuccess.Text = R_C_G_Actions.AddCategoriesToGoods(SelectedCategoryID, SelectedGoodsID);

            if (ViewState["categoriesGoodsList"] != null)
            {
                categoriesGoodsList = (List<Categories>)ViewState["categoriesGoodsList"];
                CategoriesActions categoriesActions = new CategoriesActions();
                categoriesGoodsList.Add(categoriesActions.FindCategory(SelectedCategoryID));
                RepeaterGoodsCategories.DataSource = categoriesGoodsList;
                ViewState["categoriesGoodsList"] = categoriesGoodsList;
            }
            else
            {
                categoriesGoodsList = R_C_G_Actions.GetCategoriesForGoods(SelectedGoodsID);
                RepeaterGoodsCategories.DataSource = categoriesGoodsList;
                ViewState["categoriesGoodsList"] = categoriesGoodsList;
            }

            RepeaterGoodsCategories.DataBind();
            PanelAddCategory.Enabled = false;
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            TreeViewControl1.SelectedNodeChanged -= TreeViewControl1_SelectedNodeChanged;
        }
    }
}
