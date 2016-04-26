<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTours.aspx.cs" Inherits="ManageTours" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownListTours" runat="server" onclick="DropDownListTours_Click">
        </asp:DropDownList>
        <asp:Button ID="Delete" runat="server" Text="delete tour" OnClick="AdminDeleteTour_Click" />
    </div>
    <div class="updateorinserttours">
        <asp:Label ID="LabelName" runat="server" Text="name"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:FileUpload ID="FileUpload1" runat="server"  />

        <asp:Button ID="Add" runat="server" Text="Add New tour" onclick="AdminAddTour_Click"/>

        </div>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
