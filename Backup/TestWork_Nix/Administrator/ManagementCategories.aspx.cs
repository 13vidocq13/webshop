using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;
using System.Data;

namespace TestWork_Nix.Administrator
{
    public partial class ManagementCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelSuccessAdd.Visible = false;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!TreeViewCategories1.IsSelectedCategory)
                return;

            LinkButtonToGoods.Visible = true;
            PanelChangeAction.Visible = true;
        }

        #region Buttons

        protected void LinkButtonAdd_Click(object sender, EventArgs e)
        {
            PanelAddCategory.Visible = true;
            PanelChangeAction.Visible = false;
            LabelAddNode.Text = "Add New Node to: " + TreeViewCategories1.SelectedNodeText;
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            PanelChangeAction.Visible = false;
            PanelEditCategory.Visible = true;
            TextBoxEdit.Text = TreeViewCategories1.SelectedNodeText;
        }

        protected void LinkButtonRemove_Click(object sender, EventArgs e)
        {
            int id = TreeViewCategories1.SelectedNodeID;
            string text = TreeViewCategories1.SelectedNodeText;
            
            CategoriesActions categoriesActions = new CategoriesActions();
            categoriesActions.DeleteCategory(id);

            TreeNode treeNode = new TreeNode(text, id.ToString());
            TreeViewCategories1.SelectedNodeCollection.Clear();
            TreeViewCategories1.SelectedNodeCollection.Remove(treeNode);
        }

        protected void LinkButtonAddCategory_Click(object sender, EventArgs e)
        {
            int parentID = TreeViewCategories1.SelectedNodeID;
            
            //if (int.TryParse(TreeViewCategories1.SelectedNodeID, out parentID))
            {
                CategoriesActions categoriesActions = new CategoriesActions();
                Categories categories = new Categories();
                categories.Name = TextBoxAddCategory.Text;

                int createdID = categoriesActions.AddCategoty(categories, parentID);
                TreeNode treeNode = new TreeNode(categories.Name, createdID.ToString());
                //TreeViewManage.SelectedNode.ChildNodes.Add(treeNode);
                TreeViewCategories1.SelectedNodeCollection.Add(treeNode);
            }
            TextBoxAddCategory.Text = "";
            PanelAddCategory.Visible = false;
        }

        protected void LinkButtonCancelAdd_Click(object sender, EventArgs e)
        {
            PanelAddCategory.Visible = false;
        }

        protected void LinkButtonSaveEdit_Click(object sender, EventArgs e)
        {
            int parentID = TreeViewCategories1.SelectedNodeID;

            CategoriesActions categoriesActions = new CategoriesActions();
            categoriesActions.UpdateCategory(parentID, TextBoxEdit.Text);
            
            TreeViewCategories1.SelectedNodeText = TextBoxEdit.Text;
            PanelEditCategory.Visible = false;
        }

        protected void LinkButtonToGoods_Click(object sender, EventArgs e)
        {
            Session["SelectedCategoryID"] = TreeViewCategories1.SelectedNodeID;
            Response.Redirect("GoodsPreview.aspx");
        }

        protected void LinkButtonCancelEdit_Click(object sender, EventArgs e)
        {
            PanelEditCategory.Visible = false;
            PanelChangeAction.Visible = true;
        }
    
        #endregion
    }
}
