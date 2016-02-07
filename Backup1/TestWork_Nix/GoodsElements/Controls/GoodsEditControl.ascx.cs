using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix.GoodsElements.Controls
{
    public partial class GoodsEditControl : System.Web.UI.UserControl
    {
        int goodsID;
        public event ControlEventHandler Click;

        public delegate void ControlEventHandler(object sender, ControlEventArgs e);



        public virtual void ButtonAdd_OnClick(ControlEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GoodsActions goodsActions = new GoodsActions();
                var goods = goodsActions.FindSelectedGoods(goodsID);
                TextBoxName.Text = goods.Name;
                TextBoxPrice.Text = goods.Price.ToString();
                TextBoxDiscount.Text = goods.Discount.ToString();
                CheckBox1.Checked = goods.IsDiscount;

                if (CheckBox1.Checked)
                {
                    TextBoxDiscount.Enabled = true;
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            float price;
            float.TryParse(TextBoxPrice.Text, out price);
            bool isDiscount = CheckBox1.Checked;
            int discount;
            int.TryParse(TextBoxDiscount.Text, out discount);
            byte[] image = null;
            byte[] miniImage = null;

            if (FileUploadImage.HasFile)
            {
                image = FileUploadImage.FileBytes;
            }

            if (FileUploadMiniImage.HasFile)
            {
                miniImage = FileUploadMiniImage.FileBytes;
            }

            var goods = new Goods();
            goods.Name = name;
            goods.Price = price;
            goods.IsDiscount = isDiscount;

            if (discount > 0 && CheckBox1.Checked)
            {
                goods.Discount = discount;
            }
            else
            {
                goods.Discount = null;
            }

            var goodsImages = new GoodsImages();
            goodsImages.Image = image;
            goodsImages.MiniImage = miniImage;

            var args = new ControlEventArgs(name, price, isDiscount, discount, image, miniImage);
            GoodsActions goodsActions = new GoodsActions();
            goodsActions.SaveEditGoods(goods, goodsImages, goodsID);
            Response.Redirect("~/Administrator/GoodsPreview.aspx");        

            ButtonAdd_OnClick(args);
        }
    

        #region Properties

        public int GoodsID
        {
            get
            {
                return goodsID;
            }
            set
            {
                goodsID = value;
            }
        }

        public string MiniImageAddres
        {
            get
            {
                return FileUploadMiniImage.FileName;
            }
        }

        public Label LabelHeader
        {
            get
            {
                return LabelHeader1;
            }
            set
            {
                LabelHeader1 = value;
            }
        }

        public string LabelHeader_Text
        {
            get
            {
                return LabelHeader1.Text;
            }
            set
            {
                LabelHeader1.Text = value;
            }
        }

        public TextBox Text_Box_Name
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

        public TextBox Text_Box_Price
        {
            get
            {
                return TextBoxPrice;
            }
            set
            {
                TextBoxPrice = value;
            }
        }

        public TextBox Text_Box_Discount
        {
            get
            {
                return TextBoxDiscount;
            }
            set
            {
                TextBoxDiscount = value;
            }
        }

        public CheckBox Check_Box_IsDiscount
        {
            get
            {
                return CheckBox1;
            }
            set
            {
                CheckBox1 = value;
            }
        }

        public Button Button_Submit
        {
            get
            {
                return ButtonAdd;
            }
            set
            {
                ButtonAdd = value;
            }
        }

        #endregion

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/GoodsPreview.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBoxDiscount.Enabled = true;
                RangeValidator1.Enabled = true;
            }
            else
            {
                TextBoxDiscount.Enabled = false;
                RangeValidator1.Enabled = false;
            }
        }

    }

    public class ControlEventArgs : EventArgs
    {
        public ControlEventArgs(string name, float price, bool isDiscount
            , int discount, byte[] image, byte[] miniImage)
        {
            Name = name;
            Price = price;
            IsDiscount = isDiscount;
            Discount = discount;
            Image = image;
            MiniImage = miniImage;
        }

        public string Name
        {
            get;
            private set;
        }

        public float Price
        {
            get;
            set;
        }

        public bool IsDiscount
        {
            get;
            set;
        }

        public int Discount
        {
            get;
            set;
        }

        public byte[] Image
        {
            get;
            set;
        }

        public byte[] MiniImage
        {
            get;
            set;
        }
    }

}