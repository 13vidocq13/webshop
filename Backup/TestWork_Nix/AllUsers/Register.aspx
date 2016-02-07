<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TestWork_Nix.Register" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ Register TagPrefix="WebShop" TagName="RegisterControl" Src="~/RegisterElements/Controls/RegisterControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <WebShop:RegisterControl runat="server" ID="RegisterControl1" />
</asp:Content>
