<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="LabelFName" runat="server" Text="Label">First Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelLName" runat="server" Text="Label">Last Name</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxLName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelGender" runat="server" Text="Label">Gender</asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonMale" runat="server" />Male
                    <asp:RadioButton ID="RadioButtonFemale" runat="server" />Female
                    <asp:RadioButton ID="RadioButtonOther" runat="server" />Other
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelUser" runat="server" Text="Label">Username</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelPassword" runat="server" Text="Label">Password</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelEmail" runat="server" Text="Label">Email</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelPhone" runat="server" Text="Label">Phone number</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <asp:LinkButton ID="ConnectLinkButton" runat="server" OnClick="ConnectLinkButton_Click">Welcome!</asp:LinkButton>
            </tr>
        </table>
        <asp:Button ID="SignUpButton" runat="server" Text="Sign up" OnClick="SubmitButton_Click" />
    </div>
    </form>
</body>
</html>
