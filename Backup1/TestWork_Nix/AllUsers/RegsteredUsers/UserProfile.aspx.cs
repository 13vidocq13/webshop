using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using System.Web.Security;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix
{
    public partial class UserProfile : System.Web.UI.Page
    {
        Guid userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProfileControl1.Button_Save.Click += new EventHandler(Button_Save_Click);
            ProfileControl1.Button_Cancel.Click += new EventHandler(Button_Cancel_Click);

            RolesUser rolesUser = new RolesUser();
           
            var userInfo = new UserInfo();
            ProfileActions profileActions = new ProfileActions();
            UsersActions usersActions = new UsersActions();
            userID = usersActions.FindUserGuid(User.Identity.Name);
            userInfo = profileActions.GetUserInfo(userID);
            ProfileControl1.UserID = userID;
                
            if (userInfo != null)
            {
                ViewState.Add("userInfo", userInfo);

                if (userInfo.LanguageIsEnglish)
                {
                    DropDownListView.SelectedIndex = 0;
                }
                else
                {
                    DropDownListView.SelectedIndex = 1;
                }
                
                TextBoxPhone.Text = userInfo.Code + " - " + userInfo.Phone;
                TextBoxName.Text = userInfo.Name;
                TextBoxSurName.Text = userInfo.SurName;
                TextBoxAddress.Text = userInfo.Address;
                ProfileControl1.DataSource = userInfo;
            }
        }

        void Button_Cancel_Click(object sender, EventArgs e)
        {
            PanelProfile.Visible = true;
            PanelEdit.Visible = false;
        }

        void Button_Save_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();

            if (ProfileControl1.DropDownList_Language.SelectedIndex == 0)
	        {
        	    userInfo.LanguageIsEnglish = true;
            }
            else
            {
                userInfo.LanguageIsEnglish = false;
            }

            userInfo.Code = ProfileControl1.TextBox_Code.Text;
            userInfo.Phone = ProfileControl1.TextBox_Number.Text;
            userInfo.Name = ProfileControl1.TextBox_Name.Text;
            userInfo.SurName = ProfileControl1.TextBox_SurName.Text;
            userInfo.Address = ProfileControl1.TextBox_Address.Text;

            ProfileActions profileActions = new ProfileActions();
            profileActions.AddInfo(userID, userInfo);
        }

        protected void LinkButtonEdit_Click(object sender, EventArgs e)
        {
            PanelProfile.Visible = false;
            PanelEdit.Visible = true;

            if (ViewState["userInfo"] != null)
            {
                var userInfo = new UserInfo();
                userInfo = (UserInfo)ViewState["userInfo"];

                ProfileControl1.TextBox_Code.Text = userInfo.Code;
                ProfileControl1.TextBox_Number.Text = userInfo.Phone;
                ProfileControl1.TextBox_Name.Text = userInfo.Name;
                ProfileControl1.TextBox_SurName.Text = userInfo.SurName;
                ProfileControl1.TextBox_Address.Text = userInfo.Address;
            }
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ProfileControl1.Button_Save.Click -= Button_Save_Click;
            ProfileControl1.Button_Cancel.Click -= Button_Cancel_Click;
        }
    }
}
