using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer.Help;

namespace TestWork_Nix.GoodsElements.Controls
{
    public partial class ControlGoodsPreview : System.Web.UI.UserControl
    {
        DataSourceAdapter adapter;

        public delegate void GoodsPreviewEventHandler(object sender, GoodsPreviewEventArgs e);
        public event GoodsPreviewEventHandler DataBinding;

        #region Properties

        public DataSourceAdapter DataSource
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

        public Image ImageProp
        {
            get
            {
                return Image1;
            }
            set
            {
                Image1 = value;
            }
        }

        public Label Name
        {
            get
            {
                return LabelNameValue;
            }
            set
            {
                LabelNameValue = value;
            }
        }

        public Label Price
        {
            get
            {
                return LabelPriceValue;
            }
            set
            {
                LabelPriceValue = value;
            }
        }

        public CheckBox IsDiscount
        {
            get
            {
                return CheckBoxIsDiscount;
            }
            set
            {
                CheckBoxIsDiscount = value;
            }
        }

        public Label Discount
        {
            get
            {
                return LabelDiscountValue;
            }
            set
            {
                LabelDiscountValue = value;
            }
        }

        public Table Control
        {
            get
            {
                return Table1;
            }
            set
            {
                Table1 = value;
            }
        }

        #endregion

        //protected virtual void Page_Load(object sender, GoodsPreviewEventArgs e)
        //{
        //    DataFill(adapter);
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            DataFill(adapter);
        }

        void DataFill(DataSourceAdapter source)
        {
            Image1.ImageUrl = adapter.ImageURL;
            LabelNameValue.Text = adapter.Name;
            LabelPriceValue.Text = adapter.Price;
            CheckBoxIsDiscount.Checked = adapter.IsDiscount;
            LabelDiscountValue.Text = adapter.Discount;
        }
    }

    public class GoodsPreviewEventArgs : EventArgs
    {
        string miniImaGeURL;
        string name;
        float price;
        bool isDiscount;
        int discount;


        public string MiniImageURL
        {
            get
            {
                return miniImaGeURL;
            }
            set
            {
                miniImaGeURL = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public bool IsDiscount
        {
            get
            {
                return isDiscount;
            }
            set
            {
                isDiscount = value;
            }
        }

        public int Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
            }
        }
    }
}