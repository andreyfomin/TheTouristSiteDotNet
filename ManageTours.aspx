<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTours.aspx.cs" Inherits="ManageTours" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="Stylesheet" href="StyleSheet2.css" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
    <div>
        
        <h1 style="Text-align:center;position:absolute;top:0px;left:50px">Tours Manager</h1>
        <img src="Images/romanage.jpg" alt="logo" width="100%" height="350" top="0">
        <div class="rt-delete" style="position:absolute;width=700px;margin-left:400px">
        <h2>Delete tour</h2>
        <asp:DropDownList ID="DropDownListTours" runat="server" >
        </asp:DropDownList>
        <asp:Button ID="Delete" runat="server" Text="delete tour" OnClick="AdminDeleteTour_Click" />
        </div>
   
    <div class="updateorinserttours" style="margin-left:700px">
    <h3>Add new tour</h3>
        <asp:Label ID="LabelName" runat="server" style="font-weight:bold">Tour Name</asp:Label>
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />
       <asp:Label ID="LabelDescription" runat="server" style="font-weight:bold">Description</asp:Label>
       <textarea id="TextArea1" runat="server" cols="90" rows="14"></textarea>
      <br /><br />
        <asp:Label ID="LabelImage" runat="server" style="font-weight:bold">Upload image</asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server"  />
       

        <asp:Button ID="Add" runat="server" Text="Add New tour" onclick="AdminAddTour_Click"/>

        </div>
        <asp:LinkButton ID="LinkButtonMain" runat="server" OnClick="LinkButtonMain_Click" CssClass="buttonClass" >Return to main page</asp:LinkButton>
      </div>
   </form>
</body>
</html>
