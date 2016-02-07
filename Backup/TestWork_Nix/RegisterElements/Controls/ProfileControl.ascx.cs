using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using Business_Logic_Layer;

namespace TestWork_Nix.RegisterElements.Controls
{
    public partial class ProfileControl : System.Web.UI.UserControl
    {
        Guid userID;
        UserInfo Source = new UserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Source != null)
            {
                if (Source.LanguageIsEnglish)
                {
                    DropDownListLanguage.SelectedIndex = 0;    
                }
                else
	            {
                    DropDownListLanguage.SelectedIndex = 1;
	            }
                TextBoxCode.Text = Source.Code;
                TextBoxNumber.Text = Source.Phone;
                TextBoxName.Text = Source.Name;
                TextBoxSurName.Text = Source.SurName;
                TextBoxAddress.Text = Source.Address;
            }
        }

        public UserInfo DataSource
        {
            get
            {
                return Source;
            }
            set
            {
                Source = value;
            }
        }

        public Guid UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        public DropDownList DropDownList_Language
        {
            get
            {
                return DropDownListLanguage;
            }
            set
            {
                DropDownListLanguage = value;
            }
        }

        public DropDownList DropDownList_MethodOfPay
        {
            get
            {
                return DropDownListMethodOfPay;
            }
            set
            {
                DropDownListMethodOfPay = value;
            }
        }

        public TextBox TextBox_Code
        {
            get
            {
                return TextBoxCode;
            }
            set
            {
                TextBoxCode = value;
            }
        }

        public TextBox TextBox_Number
        {
            get
            {
                return TextBoxNumber;
            }
            set
            {
                TextBoxNumber = value;
            }
        }

        public TextBox TextBox_Name
        {
            get
            {
                return TextBoxName;
            }
            set
            {
                TextBoxName = value;
            }
        }

        public TextBox TextBox_SurName
        {
            get
            {
                return TextBoxSurName;
            }
            set
            {
                TextBoxSurName = value;
            }
        }

        public TextBox TextBox_Address  
        {
            get
            {
                return TextBoxAddress;
            }
            set
            {
                TextBoxAddress = value;
            }
        }

        public Button Button_Save
        {
            get
            {
                return ButtonSave;
            }
            set
            {
                ButtonSave = value;
            }
        }

        public Button Button_Cancel
        {
            get
            {
                return ButtonCancel;
            }
            set
            {
                ButtonCancel = value;
            }
        }

        public TableRow TableRow_Pay
        {
            get
            {
                return TableRowPay;
            }
            set
            {
                TableRowPay = value;
            }
        }

        public TableRow TableRow_Language
        {
            get
            {
                return TableRowLanguage;
            }
            set
            {
                TableRowLanguage = value;
            }
        }

        public Panel Panel_Validators
        {
            get
            {
                return PanelValidators;
            }
            set
            {
                PanelValidators = value;
            }
        }
    }
}