<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlGoodsPreview.ascx.cs" Inherits="TestWork_Nix.GoodsElements.Controls.ControlGoodsPreview" %>

<asp:Table ID="Table1" runat="server" BorderWidth="1px" CellSpacing="0">
  <asp:TableHeaderRow BackColor="#1C5E55" Font-Bold="True" ForeColor="White">
    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
        <asp:Label ID="Label1" runat="server" Text="Preview:"></asp:Label>
    </asp:TableCell>
  </asp:TableHeaderRow>
  
  <asp:TableRow>
    <asp:TableCell ColumnSpan="2">
        <asp:Image ID="Image1" runat="server" />
    
</asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell>
        <asp:Label ID="LabelName" runat="server" Text="Name:"></asp:Label>
    
</asp:TableCell>
    <asp:TableCell>
        <asp:Label ID="LabelNameValue" runat="server"></asp:Label>
    
</asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="LabelPrice" runat="server" Text="Price:"></asp:Label>
    
</asp:TableCell>
    <asp:TableCell>
        <asp:Label ID="LabelPriceValue" runat="server"></asp:Label>
    
</asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell>
        <asp:Label ID="LabelIsDiscount" runat="server" Text="IsDiscount:"></asp:Label>
    
</asp:TableCell>
    <asp:TableCell>
        <asp:CheckBox ID="CheckBoxIsDiscount" runat="server" Enabled="false"/>
    
</asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="LabelDiscount" runat="server" Text="Discount:"></asp:Label>
    
</asp:TableCell>
    <asp:TableCell>
        <asp:Label ID="LabelDiscountValue" runat="server"></asp:Label>
    
</asp:TableCell>
  </asp:TableRow>
</asp:Table>


