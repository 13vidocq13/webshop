<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodsPreviewForUsers.ascx.cs" Inherits="TestWork_Nix.GoodsElements.Controls.GoodsPreviewForUsers" %>

<asp:Repeater id="Repeater2" runat="server" 
    onitemcommand="Repeater2_ItemCommand">
    <HeaderTemplate>
        <table CellSpacing="-1" cellpadding="-1" border="1px">
            <tr bgcolor="#1C5E55" style="color:White; font-weight:bold">
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Image"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Price"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Discount(%)"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="AdditionDate"></asp:Label>
                </td>
            </tr>
    </HeaderTemplate>

    <AlternatingItemTemplate>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "ImageURL")%>'/>
                <%--<img src='<%#DataBinder.Eval(Container.DataItem, "ImageURL")%>' />--%>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Price")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton4" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Discount")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton5" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "AdditionDate")%>
                </asp:LinkButton>
            </td>
        </tr>
    </AlternatingItemTemplate>

    <ItemTemplate>
        <tr bgcolor="#E3EAEB">
            <td>
               <asp:Image ID="Image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem, "ImageURL")%>'/>
               <%--<img src='<%#DataBinder.Eval(Container.DataItem, "ImageURL")%>' />
--%>            </td>
            <td>
                <asp:LinkButton ID="LinkButton2" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Name")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton3" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Price")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton4" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "Discount")%>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton5" runat="server">
                    <%#DataBinder.Eval(Container.DataItem, "AdditionDate")%>
                </asp:LinkButton>
            </td>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
        </table>
    </FooterTemplate>

</asp:Repeater>
