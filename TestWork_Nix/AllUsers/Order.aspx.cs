using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntitiesAndMapping.Entities;
using System.Web.Security;
using Business_Logic_Layer.Help;
using Business_Logic_Layer;
using EntitiesAndMapping.Help;


namespace TestWork_Nix
{
    public partial class Order : System.Web.UI.Page
    {
        const string premiumUser = "Premium user";
        const string registerUser = "Registered user";
        int discount = 0;
        Guid userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProfileControl1.TableRow_Pay.Visible = true;
                ProfileControl1.Button_Save.Text = "To order";
                ProfileControl1.TableRow_Language.Visible = false;

                var userInfo = new UserInfo();
                ProfileActions profileActions = new ProfileActions();
                UsersActions usersActions = new UsersActions();
                userID = usersActions.FindUserGuid(User.Identity.Name);
                userInfo = profileActions.GetUserInfo(userID);
                ProfileControl1.DataSource = userInfo;
            }

            ProfileControl1.Button_Save.Click += new EventHandler(Button_Save_Click);

            if (Session["OrderList"] != null)
            {
                
                Label1.Visible = false;
                List<Goods> orderList = new List<Goods>();
                orderList = (List<Goods>)Session["OrderList"];
                
                if (Roles.IsUserInRole(User.Identity.Name, premiumUser))
	            {
            		 discount = 10;
	            }
                else
	            {
                    if (Roles.IsUserInRole(User.Identity.Name, registerUser))
                    {
            		    discount = 5;
                    }
	                else
	                {
                        discount = 0;
	                }
	            }
                
                DataSourceAdapterBinding dataSourceAdapterBinding = new DataSourceAdapterBinding();
                OrderPreview1.DataSource = dataSourceAdapterBinding
                    .AdapterFillPriceCalculate(orderList, discount);
            }
            else
            {
                Label1.Visible = true;
            }
        }

        void Button_Save_Click(object sender, EventArgs e)
        {
            if (Session["OrderList"] != null)
            {
                PurchaseAdapterEntities purchaseAdapterEntities = new PurchaseAdapterEntities();
                List<Goods> orderList = new List<Goods>();
                orderList = (List<Goods>)Session["OrderList"];
                IList<int> list1 = new List<int>();

                for (int i = 0; i < orderList.Count; i++)
                {
                    list1.Add(orderList[i].ID);
                }

                purchaseAdapterEntities.GoodsIDs = list1;

                if (ProfileControl1.DropDownList_MethodOfPay.SelectedIndex == 0)
                {
                    purchaseAdapterEntities.MethodOfPayment = true;
                }
                else
                {
                    purchaseAdapterEntities.MethodOfPayment = false;
                }

                purchaseAdapterEntities.PurchaseDateTime = DateTime.Now;
                purchaseAdapterEntities.UserID = userID;

                PurchasesActions purchasesActions = new PurchasesActions();
                purchasesActions.AddPurchase(purchaseAdapterEntities);
            }
        }
    }
}
