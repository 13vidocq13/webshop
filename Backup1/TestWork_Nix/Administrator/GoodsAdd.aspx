<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GoodsAdd.aspx.cs" Inherits="TestWork_Nix.Administrator.GoodsAdd" %>
<%@ Register TagPrefix="WebShop" TagName="GoodsControl" Src="~/GoodsElements/Controls/GoodsControl.ascx" %>			 
<%@ Register TagPrefix="WebShop" TagName="ControlGoodsPreview" Src="~/GoodsElements/Controls/ControlGoodsPreview.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <WebShop:GoodsControl runat="server" id="GoodsControl1" />
</asp:Content>

