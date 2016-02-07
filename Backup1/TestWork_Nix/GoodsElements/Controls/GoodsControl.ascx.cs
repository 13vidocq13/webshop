using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;
using EntitiesAndMapping.Entities;

namespace TestWork_Nix
{
    public partial class GoodsControl : System.Web.UI.UserControl
    {
        int goodsID;

        public event ButtonSubmitEventHandler Submit;

        public delegate void ButtonSubmitEventHandler(object sender, ButtonSubmitEventArgs e);

        protected virtual void ButtonAdd_OnClick(ButtonSubmitEventArgs e)
        {
            if (Submit != null)
            {
                Submit(this, e);
            }
        }

        public void ButtonAdd_Click(object sender, EventArgs e)
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

            var args = new ButtonSubmitEventArgs(name, price, isDiscount, discount,
                image, miniImage);


            ButtonAdd_OnClick(args);

            var goods = new Goods();
            goods.Name = name;
            goods.Price = price;
            goods.IsDiscount = isDiscount;

            if (discount > 0)
            {
                goods.Discount = discount;    
            }
            
            goods.AdditionDate = DateTime.Now;

            var goodsImages = new GoodsImages();
            goodsImages.Image = image;
            goodsImages.MiniImage = miniImage;

            GoodsActions goodsActions = new GoodsActions();
            goodsActions.AddGoods(goods, goodsImages, goodsID);
            Response.Redirect("~/Administrator/GoodsPreview.aspx");   
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/GoodsPreview.aspx");
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBoxDiscount.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
            }
            else
            {
                TextBoxDiscount.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
            }
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
                return FileUploadMiniImage.TemplateSourceDirectory;
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

        public byte[] MiniImage
        {
            get
            {
                return FileUploadMiniImage.FileBytes;
            }
        }

        #endregion

    }

    public class ButtonSubmitEventArgs : EventArgs
    {
        public ButtonSubmitEventArgs(string name, float price, bool isDiscount
            , int? discount, byte[] image, byte[] miniImage)
        {
            Name = name;
            Price = price;
            IsDiscount = isDiscount;
            
            if (discount > 0)
            {
                Discount = discount;
            }
            else
            {
                Discount = null;
            }
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

        public int? Discount
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