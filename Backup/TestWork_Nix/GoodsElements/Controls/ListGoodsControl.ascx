<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListGoodsControl.ascx.cs" Inherits="TestWork_Nix.GoodsElements.Controls.ListGoodsControl" %>

<asp:GridView ID="GridViewGoods" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
    onselectedindexchanged="GridViewGoods_SelectedIndexChanged" 
    onrowdeleting="GridViewGoods_RowDeleting">
        <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
            </asp:ImageField>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" />
            <asp:BoundField DataField="Discount" HeaderText="Discount(%)" />
            <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
</asp:GridView>  
<asp:Label ID="Label1" runat="server"></asp:Label>
  
