using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer;

namespace TestWork_Nix.Categoties.Controls
{
    public partial class TreeViewCategoriesControl : System.Web.UI.UserControl
    {
        public event TreeViewManageEventHandler SelectedNodeChanged;
        public delegate void TreeViewManageEventHandler(object sender, TreeViewManageEventArgs e);
        string parrentName;
        int parentID;
        bool isSelectedCategory;

        public virtual void OnSelectedNodeChanged(TreeViewManageEventArgs e)
        {
            if (SelectedNodeChanged != null)
            {
                SelectedNodeChanged(this, e);
            }
        }

        public void TreeViewManage_SelectedNodeChanged(object sender, EventArgs e)
        {
            isSelectedCategory = true;
            parrentName = TreeViewManage.SelectedNode.Text;
            int.TryParse(TreeViewManage.SelectedNode.Value, out parentID);
            //ViewState.Add("ParentID", ParentID);
            
            if (ParentID > 0 && TreeViewManage.SelectedNode.ChildNodes.Count == 0)
            {
                CategoriesActions categoriesActions = new CategoriesActions();
                List<Categories> listCategories = categoriesActions.GetCategories(parentID);
                
                foreach (Categories item in listCategories)
                {
                    TreeNode treeNode = new TreeNode(item.Name, item.ID.ToString());
                    TreeViewManage.SelectedNode.ChildNodes.Add(treeNode);
                }
            }

            TreeViewManage.SelectedNode.Expand();

            var args = new TreeViewManageEventArgs(TreeViewManage.SelectedNode);
            OnSelectedNodeChanged(args);
        }

        #region Properties

        public TreeNode SelectedNodeExpand
        {
            get
            {
                return TreeViewManage.SelectedNode;
            }
            set
            {
                TreeViewManage.SelectedNode.Expand(); 
            }
        }

        public string ParrentName
        {
            get
            {
                return parrentName;
            }
            set
            {
                parrentName = value;
            }
        }

        public int ParentID
        {
            get
            {
                return parentID;
            }
            set
            {
                parentID = value;
            }
        }

        public int SelectedNodeID
        {
            get
            {
                return int.Parse(TreeViewManage.SelectedNode.Value);
            }
        }

        public string SelectedNodeText
        {
            get
            {
                return TreeViewManage.SelectedNode.Text;
            }
            set
            {
                TreeViewManage.SelectedNode.Text = value;
            }
        }

        public TreeNodeCollection TreeViewNodes
        {
            get
            {
                return TreeViewManage.Nodes;
            }
        }

        public TreeNodeCollection SelectedNodeCollection
        {
            get
            {
                return TreeViewManage.SelectedNode.ChildNodes;
            }
        }

        public bool IsSelectedCategory
        {
            get
            {
                return isSelectedCategory;
            }
            set
            {
                isSelectedCategory = value;
            }
        }

        #endregion

    }

    public class TreeViewManageEventArgs : EventArgs
    {
        public TreeViewManageEventArgs(TreeNode selectedNode)
        {
            SelectedNode = selectedNode;
        }

        public TreeNode SelectedNode
        {
            get;
            set;
        }
    }
}