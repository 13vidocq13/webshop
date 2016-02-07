<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ManageGoodsInCategory.aspx.cs" Inherits="TestWork_Nix.Administrator.ManageGoodsInCategory" %>
<%@ Register TagPrefix="WebShop" TagName="TreeViewControl" Src="~/Categoties/Controls/TreeViewCategoriesControl.ascx"%>

<asp:Content ContentPlaceHolderID="MainContent" runat="server"> 
    <asp:Table ID="Table1" runat="server">
      <asp:TableRow>
        <asp:TableCell>
         <h4>
            <asp:Label ID="Label1" runat="server">
            </asp:Label>
         </h4>
          <br />
             <asp:Repeater ID="RepeaterGoodsCategories" runat="server" 
             onitemcommand="RepeaterGoodsCategories_ItemCommand">
                <ItemTemplate>
                    <%#DataBinder.Eval(Container.DataItem, "Name")%> <asp:LinkButton ID="LinkButtonDelete" CommandName="Delete" runat="server"> Delete</asp:LinkButton><br />
                </ItemTemplate>
            </asp:Repeater>
            <h4> 
                <asp:LinkButton ID="LinkButtonAGtC" runat="server" 
                    onclick="LinkButtonAGtC_Click">Add Goods to category</asp:LinkButton></h4></asp:TableCell>
        <asp:TableCell> 
            <asp:Panel ID="PanelAddCategory" runat="server" Enabled="false" Visible="false">
                <WebShop:TreeViewControl runat="server" ID="TreeViewControl1" />
                <h4>
                    <asp:Label ID="LabelAddSuccess" runat="server" Text="">
                    </asp:Label>
                </h4>
                <br />
                <asp:Button ID="ButtonAdd" runat="server" Text="Add goods" Enabled="False" 
                    onclick="ButtonAdd_Click" />   
            </asp:Panel>            
        </asp:TableCell>
      </asp:TableRow>    
    </asp:Table>
</asp:Content>