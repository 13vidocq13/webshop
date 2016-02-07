<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderControlPreview.ascx.cs" Inherits="TestWork_Nix.GoodsElements.Controls.OrderControlPreview" %>

<asp:GridView ID="GridView1" runat="server" CellPadding="0" ForeColor="#333333" 
    GridLines="None" AutoGenerateColumns="False" BorderWidth="1px" 
    onrowdeleting="GridView1_RowDeleting">
    <RowStyle BackColor="#E3EAEB" />
    <Columns>
        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Изображение">
        </asp:ImageField>
        <asp:BoundField DataField="Name" HeaderText="Наименование" />
        <asp:TemplateField HeaderText="Кол-во">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                MaxLength="5" Width="35px" Text="1"></asp:TextBox>                                
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Price" HeaderText="Цена(грн)" />
        <asp:BoundField DataField="Cost" HeaderText="Стоимость(грн)" />
        <asp:CommandField CancelText="Отмена" DeleteText="Удалить" 
            HeaderText="Удаление" ShowDeleteButton="True" />
    </Columns>
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
