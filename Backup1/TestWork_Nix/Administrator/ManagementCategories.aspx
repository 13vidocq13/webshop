<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManagementCategories.aspx.cs" Inherits="TestWork_Nix.Administrator.ManagementCategories" %>
<%@ Register TagPrefix="WebShop" TagName="TreeViewCategories" Src="~/Categoties/Controls/TreeViewCategoriesControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
 <asp:Panel ID="PanelCategories" runat="server">
    <asp:Panel ID="PanelTreeview" runat="server">
        <asp:Table ID="Table1" runat="server">
           <asp:TableRow>
             <asp:TableCell>
                <WebShop:TreeViewCategories runat="server" ID="TreeViewCategories1"/>
             </asp:TableCell>
             <asp:TableCell>
                <h4>
                    <asp:LinkButton ID="LinkButtonToGoods" Visible="false" runat="server" OnClick="LinkButtonToGoods_Click">
                    Go to goods</asp:LinkButton>
                </h4>
             </asp:TableCell>
           </asp:TableRow> 
        </asp:Table>
    </asp:Panel>
        <br />
    <asp:Panel ID="PanelChangeAction" runat="server" Visible="False">
        <asp:Label ID="LabelSelectedCategory" runat="server"></asp:Label>
        <br />
        <h4>
            <asp:LinkButton ID="LinkButtonAdd" runat="server" onclick="LinkButtonAdd_Click">Add</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButtonEdit" runat="server" 
                onclick="LinkButtonEdit_Click" ValidationGroup="NoValidate">Edit</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButtonRemove" runat="server" 
                onclick="LinkButtonRemove_Click" ValidationGroup="NoValidate">Remove</asp:LinkButton>
        </h4>
    </asp:Panel>
    <asp:Panel ID="PanelAddCategory" runat="server" Visible="False">
     <asp:Label ID="LabelAddNode" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxAddCategory" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Field is empty" ValidationGroup="Categories" 
            ControlToValidate="TextBoxAddCategory"></asp:RequiredFieldValidator>
        <br />
     <asp:Label ID="LabelSuccessAdd" runat="server" Text="Node Added Successfully" 
         Visible="False"></asp:Label>
        <h4>
            <asp:LinkButton ID="LinkButtonAddCategory" runat="server" 
                ValidationGroup="Categories" onclick="LinkButtonAddCategory_Click">Add</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="LinkButtonCancelAdd" runat="server" 
                onclick="LinkButtonCancelAdd_Click">Cancel</asp:LinkButton>
        </h4>
    </asp:Panel>
     <asp:Panel ID="PanelEditCategory" runat="server" Visible="False">
         <asp:Label ID="LabelEdit" runat="server" Text="Edit:"></asp:Label>
         <br />
         <asp:TextBox ID="TextBoxEdit" runat="server" ValidationGroup="EditCategory"></asp:TextBox>
         <br />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
             ErrorMessage="Field is empty" ValidationGroup="EditCategory" 
             ControlToValidate="TextBoxEdit"></asp:RequiredFieldValidator>
         <br />
         <h4>
             <asp:LinkButton ID="LinkButtonSaveEdit" runat="server" 
                 ValidationGroup="EditCategory" onclick="LinkButtonSaveEdit_Click">Save</asp:LinkButton>
             &nbsp;<asp:LinkButton ID="LinkButtonCancelEdit" runat="server" 
                 ValidationGroup="NoValidate" onclick="LinkButtonCancelEdit_Click">Cancel</asp:LinkButton>
         </h4>
     </asp:Panel>
        <br />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">

    </asp:Content>
