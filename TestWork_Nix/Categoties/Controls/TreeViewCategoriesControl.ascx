<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewCategoriesControl.ascx.cs" Inherits="TestWork_Nix.Categoties.Controls.TreeViewCategoriesControl" %>
<asp:TreeView ID="TreeViewManage" runat="server" 
      onselectednodechanged="TreeViewManage_SelectedNodeChanged" ImageSet="Msdn" 
      NodeIndent="10">
      <ParentNodeStyle Font-Bold="False" />
      <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" 
        Font-Underline="True" />
      <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" 
        BorderWidth="1px" Font-Underline="False" HorizontalPadding="3px" 
        VerticalPadding="1px" />
        <Nodes>
            <asp:TreeNode Text="RootNode" Value="1"></asp:TreeNode>
        </Nodes>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" />
</asp:TreeView>
    