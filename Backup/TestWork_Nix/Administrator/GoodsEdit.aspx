<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodsEdit.aspx.cs" Inherits="TestWork_Nix.Administrator.GoodsEdit" %>
<%@ Register TagPrefix="WebShop" TagName="GoodsEditControl" Src="~/GoodsElements/Controls/GoodsEditControl.ascx"%>
<%@ Register TagPrefix="WebShop" TagName="GoodsPreviewControl" Src="~/GoodsElements/Controls/ControlGoodsPreview.ascx"  %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server">
      <asp:TableRow>
        <asp:TableCell VerticalAlign="Top">
             <WebShop:GoodsEditControl runat="server" ID="GoodsEditControl1" />
             <br />
             <h4>
                 <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Administrator/ManageGoodsInCategory.aspx">
                 Go to manage goods in categoties</asp:LinkButton>
             </h4>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Top">
             <WebShop:GoodsPreviewControl runat="server" ID="GoodsPreviewControl1" />
        </asp:TableCell>
      </asp:TableRow>
    </asp:Table>
</asp:Content>