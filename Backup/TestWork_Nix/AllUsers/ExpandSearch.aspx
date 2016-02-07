<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpandSearch.aspx.cs" Inherits="TestWork_Nix.AllUsers.ExpandSearch" %>
<%@ Register TagPrefix="WebShop" TagName="TreeViewControl" Src="~/Categoties/Controls/TreeViewCategoriesControl.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    <h4>
                        Условия поиска: 
                        <asp:DropDownList ID="DropDownListConditions" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DropDownListConditions_SelectedIndexChanged">
                            <asp:ListItem Value="empty" Text=""></asp:ListItem>
                            <asp:ListItem Value="inTheName">по названию</asp:ListItem>
                            <asp:ListItem Value="inTheCategory">по категории</asp:ListItem>
                            <asp:ListItem Value="inTheDateTime">по дате добавления</asp:ListItem>
                        </asp:DropDownList>
                    </h4>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Panel ID="PanelIsSelected" runat="server" Visible="false">
                        <asp:TextBox ID="TextBoxName" runat="server" Visible="false"></asp:TextBox>
                        <WebShop:TreeViewControl ID="TreeViewControl1" runat="server" Visible="false"/>
                    <asp:Panel ID="PanelAddDate" runat="server" Visible="False">
                        <asp:TextBox ID="TextBoxStartDate" runat="server" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="~/AllUsers/text-calendar_mini.png" 
                        onclick="ImageButton1_Click"  />
                        <span lang="en-us">&nbsp;</span>
                        <asp:TextBox ID="TextBoxEndDate" runat="server" Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                        ImageUrl="~/AllUsers/text-calendar_mini.png" 
                        onclick="ImageButton2_Click" />
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="#E3EAEB" 
                            BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                            Font-Names="Verdana" Font-Size="8pt" ForeColor="#6F9297" Height="200px" 
                            ShowGridLines="True" Width="220px" Visible="False" 
                            onselectionchanged="Calendar1_SelectionChanged" SelectionMode="DayWeekMonth">
                                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                <SelectorStyle BackColor="#FFCC66" />
                                <TodayDayStyle BackColor="#6F9297" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#CC9966" />
                                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                <DayHeaderStyle BackColor="#6F9297" Font-Bold="True" ForeColor="White" Height="1px" />
                                <TitleStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        </asp:Calendar>
                    </asp:Panel>
                    </asp:Panel>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Top">
                    <h4>
                        <asp:Label ID="LabelSort" runat="server" Text="Сортировать по: "></asp:Label>
                         <asp:DropDownList ID="DropDownListSort" runat="server">
                            <asp:ListItem Value="AdditionDate">по дате добавления</asp:ListItem>
                            <asp:ListItem Value="quantityOfSales">по количеству продаж</asp:ListItem>
                            <asp:ListItem Value="Name">по названию</asp:ListItem>
                            <asp:ListItem Value="byCategory">по катерогии</asp:ListItem>
                            <asp:ListItem Value="Price">по цене</asp:ListItem>
                            <asp:ListItem Value="IsDiscount">по наличию скидки</asp:ListItem>
                        </asp:DropDownList>                
                    </h4>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center"> 
                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" 
                    ForeColor="#1C5E55" BorderWidth="1px" onclick="ButtonSearch_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <RowStyle BackColor="#E3EAEB" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </div>
    </form>
</body>
</html>
