using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer.Help;

namespace TestWork_Nix.GoodsElements.Controls
{
    public partial class OrderControlPreview : System.Web.UI.UserControl
    {
        IList<DataSourceAdapter> adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = adapter;
            GridView1.DataBind();
            
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                adapter[i].Count = int.Parse(((TextBox)GridView1
                    .Rows[i].FindControl("TextBox1")).Text);
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public IList<DataSourceAdapter> DataSource
        {
            get
            {
                return adapter;
            }
            set
            {
                adapter = value;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            adapter.RemoveAt(index);
            GridView1.DataSource = adapter;
            GridView1.DataBind();
            Session["OrderList"] = adapter.Count > 0 ? adapter : null;
        }
    }
}