<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="TestWork_Nix.Order" %>
<%@ Register TagPrefix="WebShop" TagName="OrderPreview" Src="~/GoodsElements/Controls/OrderControlPreview.ascx"%>
<%@ Register TagPrefix="WebShop" TagName="Profile" Src="~/RegisterElements/Controls/ProfileControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <WebShop:OrderPreview runat="server" ID="OrderPreview1"/>
    <asp:Label ID="Label1" runat="server" Text="Ваша корзина пуста"></asp:Label>
    <WebShop:Profile runat="server" ID="ProfileControl1"/>
</asp:Content>
