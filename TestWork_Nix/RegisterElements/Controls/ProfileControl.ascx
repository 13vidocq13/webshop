<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileControl.ascx.cs" Inherits="TestWork_Nix.RegisterElements.Controls.ProfileControl" %>

<asp:Table ID="Table1" runat="server" BorderWidth="1px" CellSpacing="0">
    <asp:TableRow BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center">
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Label ID="LabelProfile" runat="server" Text="User Profile:"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow ID="TableRowLanguage" BackColor="#E3EAEB">
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelLAnguage" runat="server"
             Text="Preferred language:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListLanguage" runat="server">
                <asp:ListItem Value="English">English</asp:ListItem>
                <asp:ListItem Value="Russian">Русский</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelNumber" runat="server" Text="Phone number:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxCode" runat="server" Width="48px"></asp:TextBox>
            <asp:Label ID="Label" runat="server" Text="&#8212;"></asp:Label>
            <asp:TextBox ID="TextBoxNumber" runat="server" Width="64px"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelName" runat="server" Text="Name:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelSurName" runat="server" Text="SurName:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxSurName" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelAddress" runat="server" Text="Home address:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxAddress" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow ID="TableRowPay" Visible="false"> 
        <asp:TableCell HorizontalAlign="Right">
            <asp:Label ID="LabelMethodOfPay" runat="server" Text="MethodOfPay:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:DropDownList ID="DropDownListMethodOfPay" runat="server">
                <asp:ListItem Text="Credit card" Value="CreditCard" />
                <asp:ListItem Text="Inside pay system" Value="InsidePaySystem"/>
            </asp:DropDownList>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" ForeColor="#1C5E55" 
            BorderWidth="1px" />    
            <asp:Button ID="ButtonCancel" runat="server" ValidationGroup="noValidate" Text="Cancel" ForeColor="#1C5E55" BorderWidth="1px" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

<asp:Panel ID="PanelValidators" runat="server">
    <asp:RegularExpressionValidator ID="RegularExpressionValidatorCode" 
    runat="server" ErrorMessage="Code must have a 3 digital" 
    ValidationExpression="\d{3}" ControlToValidate="TextBoxCode"></asp:RegularExpressionValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhone" 
    runat="server" ErrorMessage="Phone must have a 7 digital" 
    ValidationExpression="\d{7}" ControlToValidate="TextBoxNumber"></asp:RegularExpressionValidator>
</asp:Panel>



            