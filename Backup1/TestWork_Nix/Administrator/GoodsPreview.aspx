<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodsPreview.aspx.cs" Inherits="TestWork_Nix.Administrator.GoodsPreview" %>
<%@ Register TagPrefix="WebShop" TagName="ListGoods" Src="~/GoodsElements/Controls/ListGoodsControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
            <center>
                <h3>Manage Goods:</h3>
            </center>
        <h4><asp:Label ID="LabelSelectedCategory" runat="server"></asp:Label></h4>
        <WebShop:ListGoods runat="server" ID="ListGoods1"/>
        <asp:LinkButton ID="LinkButtonAddGoods" runat="server" PostBackUrl="~/Administrator/GoodsAdd.aspx">Add Goods</asp:LinkButton>
</asp:Content>