<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWork_Nix._Default" %>
<%@ Register TagPrefix="WebShop" TagName="GoodsPreview" Src="~/GoodsElements/Controls/GoodsPreviewForUsers.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right"> <asp:Login ID="Login1" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" 
                BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
                <TextBoxStyle Font-Size="0.8em" />
                <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
                <LayoutTemplate>
                    <table border="0" cellpadding="4" cellspacing="0" 
                        style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table border="0" cellpadding="0">
                                    <tr>
                                        <td align="center" 
                                            style="color:White;background-color:#1C5E55;font-size:0.9em;font-weight:bold;">
                                            Log In</td></tr><tr>
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td></tr><tr>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Size="0.8em"></asp:TextBox><asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator></td></tr><tr>
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td></tr><tr>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="Password is required." 
                                                ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator></td></tr><tr>
                                        <td>
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></td></tr><tr>
                                    <td align="left">
                                        <asp:LinkButton ID="LinkButton1" runat="server" 
                                            PostBackUrl="~/AllUsers/Register.aspx">Register</asp:LinkButton></td><td align="right">
                                            <asp:Button ID="LoginButton" runat="server" BackColor="White" 
                                                BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" Text="Log In" 
                                                ValidationGroup="Login1" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" 
                    ForeColor="White" />
                </asp:Login>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell> 
                <h4>
                    Последнее добавленное: 
                </h4>
                <WebShop:GoodsPreview runat="server" ID="GoodsPreviewLastAdded" />
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell> 
                <h4>
                    Товары со скидкой: 
                </h4>
                <WebShop:GoodsPreview runat="server" ID="GoodsPreviewDiscount"/>
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow>
            <asp:TableCell> 
                <h4>
                    Наиболее продаваемые товары: 
                </h4>
                <WebShop:GoodsPreview runat="server" id="GoodsPreviewMostSold"/>
           </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:LinkButton ID="LinkButtonSearch" runat="server" PostBackUrl="~/AllUsers/ExpandSearch.aspx" >Search</asp:LinkButton>
</asp:Content>
