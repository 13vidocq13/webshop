<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdministratorStartPage.aspx.cs" Inherits="TestWork_Nix.Administrator.AdministratorStartPage" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h3>
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Administrator/ManagementCategories.aspx">
    On page of management of categories</asp:LinkButton>
</h3>
</asp:Content>