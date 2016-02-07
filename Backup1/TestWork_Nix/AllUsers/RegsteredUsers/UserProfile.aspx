<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="TestWork_Nix.UserProfile" %>
<%@ Register TagPrefix="WebShop" TagName="ProfileControl" Src="~/RegisterElements/Controls/ProfileControl.ascx" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelProfile" runat="server">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label1" runat="server" Text="Preferred language:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownListView" runat="server" Enabled="false">
                        <asp:ListItem Value="English">English</asp:ListItem>
                        <asp:ListItem Value="Russian">Русский</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label2" runat="server" Text="Phone number:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxPhone" runat="server" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxName" runat="server" Enabled="false"></asp:TextBox>  
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label4" runat="server" Text="SurName:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxSurName" runat="server" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Label ID="Label5" runat="server" Text="Home address:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAddress" runat="server" Enabled="false"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
        <h4>
            <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                onclick="LinkButtonEdit_Click">Edit</asp:LinkButton>
        </h4>
    <asp:Panel ID="PanelEdit" runat="server"  Visible="false">
        <WebShop:ProfileControl id="ProfileControl1" runat="server"/>
    </asp:Panel>
</asp:Content>