using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business_Logic_Layer;

namespace TestWork_Nix.GoodsElements.Controls
{
    public partial class GetBigImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imgID = Request.Params.Get("imgID");
            int goodsID;

            if (int.TryParse(imgID, out goodsID))
            {
                GoodsActions goodsActions = new GoodsActions();
                byte[] responsePicture = goodsActions.FindPicture(goodsID);

                Response.BinaryWrite(responsePicture);
            }
        }
    }
}
