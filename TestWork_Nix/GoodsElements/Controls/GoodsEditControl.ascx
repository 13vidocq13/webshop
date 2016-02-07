<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodsEditControl.ascx.cs" Inherits="TestWork_Nix.GoodsElements.Controls.GoodsEditControl" %>

<asp:Table ID="GoodsControlTable" runat="server" ForeColor="#333333" CellSpacing="0" 
    BorderStyle="Solid" BorderWidth="1px">
  <asp:TableRow BackColor="#1C5E55" Font-Bold="True" ForeColor="White">
    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
        <asp:Label ID="LabelHeader1" runat="server" Text="Edit Goods:"></asp:Label>
    </asp:TableCell>
  
  </asp:TableRow>
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell>
        <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:TextBox ID="TextBoxName" runat="server" ValidationGroup="Required"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="*" ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="Label3" runat="server" Text="Price:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:TextBox ID="TextBoxPrice" runat="server" ValidationGroup="Required"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="*" ControlToValidate="TextBoxPrice"></asp:RequiredFieldValidator>
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell>
        <asp:Label ID="Label4" runat="server" Text="IsDiscount:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:CheckBox ID="CheckBox1" runat="server" 
        oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="true" />        
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="Label5" runat="server" Text="Discount:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:TextBox ID="TextBoxDiscount" Enabled="false" runat="server"></asp:TextBox>
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell>
        <asp:Label ID="Label6" runat="server" Text="Image:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:FileUpload ID="FileUploadImage" runat="server" ForeColor="#1C5E55" BorderWidth="1px" />
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell>
        <asp:Label ID="Label7" runat="server" Text="MiniImage:"></asp:Label>
    </asp:TableCell>
    <asp:TableCell>
        <asp:FileUpload ID="FileUploadMiniImage" runat="server" ForeColor="#1C5E55" BorderWidth="1px" />
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow BackColor="#E3EAEB">
    <asp:TableCell ColumnSpan="2">
        <asp:RangeValidator ID="RangeValidator1" MinimumValue=0 MaximumValue=100 
        ControlToValidate="TextBoxDiscount" runat="server" Type="Integer" 
        ErrorMessage="Discount must be: 1 - 100%" Enabled="false"></asp:RangeValidator>
    </asp:TableCell>
  </asp:TableRow>
  
  <asp:TableRow>
    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
        <asp:Button ID="ButtonAdd" runat="server" Text="Save" 
        onclick="ButtonAdd_Click" ForeColor="#1C5E55" BorderWidth="1px"/>
        &nbsp;    
        <asp:Button ID="ButtonCancel" runat="server" onclick="ButtonCancel_Click" 
        Text="Cancel" ForeColor="#1C5E55" BorderWidth="1px" ValidationGroup="NO" />        
    </asp:TableCell>
  </asp:TableRow>
</asp:Table>

 




 

