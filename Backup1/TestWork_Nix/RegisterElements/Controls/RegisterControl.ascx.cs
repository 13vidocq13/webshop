using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer;

namespace TestWork_Nix.RegisterElements.Controls
{
    public partial class RegisterControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            msCaptcha1.ValidateCaptcha(TextBoxCaptcha.Text);

            if (msCaptcha1.UserValidated)
            {
                string userName = TextBoxUsername.Text;
                string password = TextBoxPassword.Text;
                string email = TextBoxEmail.Text;
                string question = TextBoxQuestion.Text;
                string answer = TextBoxAnswer.Text;

                var userInfo = new UserInfo();
                userInfo.Code = TextBoxCode.Text;
                userInfo.Phone = TextBoxNumber.Text;

                UsersActions usersActions = new UsersActions();
                usersActions.CreateUser(userName, password, email, question, 
                    answer, userInfo);

                Response.Redirect("Default.aspx");
            }
        }
    }
}