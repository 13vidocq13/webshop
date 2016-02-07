<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPreview.aspx.cs" MasterPageFile="~/Site1.Master" Inherits="TestWork_Nix.AllUsers.GoodsPreview" %>
<%@ Register TagPrefix="WebShop" TagName="ControlGoodsPreview" Src="~/GoodsElements/Controls/ControlGoodsPreview.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server"> 
    <WebShop:ControlGoodsPreview runat="server" ID="GoodsPreview1"/>
    <asp:Button ID="Button1" runat="server" Text="в корзину" ForeColor="#1C5E55" 
        BorderWidth="1px" onclick="Button1_Click"/>
</asp:Content>