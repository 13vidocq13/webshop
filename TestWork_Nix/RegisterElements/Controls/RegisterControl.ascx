<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RegisterControl.ascx.cs" Inherits="TestWork_Nix.RegisterElements.Controls.RegisterControl" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="msCaptcha" %>

<asp:Table ID="Table2" runat="server" BorderWidth="1px" CellSpacing="0">
    <asp:TableRow BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center">
        <asp:TableCell ColumnSpan="2"> 
            <asp:Label ID="LabelRegisterForm" runat="server" Text="Register form:"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell> 
            <asp:Label ID="LabelUsername" runat="server" Text="Username:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell> 
            <asp:TextBox ID="TextBoxUsername" ValidationGroup="Required" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxUsername"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelEmail" runat="server" Text="Email:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxEmail" ValidationGroup="Required" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxEmail"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell>
            <asp:Label ID="LabelNumber" runat="server" Text="Phone Number:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxCode" runat="server" Width="48px"></asp:TextBox>
            <asp:Label ID="Label666" runat="server" Text="&#8212;"></asp:Label>
            <asp:TextBox ID="TextBoxNumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxNumber"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxPassword" TextMode="Password" ValidationGroup="Required" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxPassword"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell>
            <asp:Label ID="LabelRetypePassword" runat="server" Text="Retype Password:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxRetypePassword" TextMode="Password" ValidationGroup="Required" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxRetypePassword"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label ID="LabelQuestion" runat="server" Text="Security Question:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxQuestion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldQuestion" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxQuestion">
            </asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell>
            <asp:Label ID="LabelAnswer" runat="server" Text="Security Answer:"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxAnswer" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*" ControlToValidate="TextBoxAnswer">
            </asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell>
            <msCaptcha:CaptchaControl ID="msCaptcha1" runat="server" CaptchaBackgroundNoise="Extreme" CaptchaFontWarping="Extreme" CaptchaLength="5" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="TextBoxCaptcha" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCaptcha" runat="server"
             ErrorMessage="*" ControlToValidate="TextBoxCaptcha"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow>
        <asp:TableCell>
            <asp:CompareValidator ID="CompareValidator1" runat="server"
            ErrorMessage="Passwords is a differ" ControlToValidate="TextBoxPassword"
            ControlToCompare="TextBoxRetypePassword"></asp:CompareValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
    ErrorMessage="Email is not a valid" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
    ControlToValidate="TextBoxEmail" Display="Dynamic"></asp:RegularExpressionValidator>
        </asp:TableCell>
    </asp:TableRow>
    
    <asp:TableRow BackColor="#E3EAEB">
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
            <asp:Button ID="ButtonSubmit" runat="server" Text="Register" 
            onclick="ButtonSubmit_Click" CausesValidation="true" ForeColor="#1C5E55" BorderWidth="1px"  />            
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>




