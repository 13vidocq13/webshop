using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix.AllUsers
{
    public partial class ExpandSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownListConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelIsSelected.Visible = true;

            if (DropDownListConditions.Items[0].Value == "empty")
            {
                DropDownListConditions.Items.RemoveAt(0);
                DropDownListConditions.DataBind();
            }

            switch (DropDownListConditions.SelectedValue)
            {
                case "inTheName":
                    TextBoxName.Visible = true;
                    TreeViewControl1.Visible = false;
                    PanelAddDate.Visible = false;
                    break;

                case "inTheCategory":
                    TreeViewControl1.Visible = true;
                    TextBoxName.Visible = false;
                    PanelAddDate.Visible = false;
                    break;

                case "inTheDateTime":
                    PanelAddDate.Visible = true;
                    TextBoxName.Visible = false;
                    TreeViewControl1.Visible = false;
                    break;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string sortName = DropDownListSort.SelectedValue;
            SearchActions searchActions = new SearchActions();
                    
            switch (DropDownListConditions.SelectedValue)
            {
                case "inTheName":
                    string searchingName = TextBoxName.Text;
                    
                    IList<Goods> iListSearchedByName = searchActions.SearchByName(searchingName, sortName, 10);
                    GridView1.DataSource = iListSearchedByName;
                    GridView1.DataBind();
                    break;

                case "inTheCategory":
                    break;

                case "inTheDateTime":

                    if (ViewState["start"] != null && ViewState["end"] != null)
	                {
                        DateTime start = (DateTime)ViewState["start"];
                        DateTime end = (DateTime)ViewState["end"];
                        IList<Goods> IListSearchedByDateTime = searchActions
                            .SearchByDateTime(start, end, sortName, 10);
                        GridView1.DataSource = IListSearchedByDateTime;
                        GridView1.DataBind();
                    }
                    break;
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
            ViewState["tb"] = "start";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
            ViewState["tb"] = "end";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calendar1.Visible = false;

            if (ViewState["tb"] != null)
            {
                string tb = (string)ViewState["tb"];

                switch (tb)
                {
                    case "start":
                        TextBoxStartDate.Text = Calendar1.SelectedDate.Date.ToShortDateString();
                        ViewState.Add("start", Calendar1.SelectedDate.Date);
                        break;

                    case "end":
                        TextBoxEndDate.Text = Calendar1.SelectedDate.Date.ToShortDateString();
                        ViewState.Add("end", Calendar1.SelectedDate);
                        break;
                }
            }
        }
    }
}
