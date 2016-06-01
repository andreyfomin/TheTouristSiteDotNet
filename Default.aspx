<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" href="StyleSheet.css" />
    <title>ROMANIA</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rt-head">
        <div class="rt-logo" style="position: absolute">
            <h1>
                ROMANIA</h1>
                 
                        <asp:Panel ID="MyFavoritPanel" CssClass="rt-ruler-sm" runat="server" Style="position: relative"
            OnDataBinding="MyFavoritPanel_DataBinding" Visible="False">
            <asp:BulletedList ID="MyFavoritBulletedList" runat="server" Style="position: absolute"
                DisplayMode="LinkButton"> 
            </asp:BulletedList> </asp:Panel>
        </div>
        <div class="flag" style="margin-left: 200px">
            <img src="flag.gif" style="width: 100px" /></div>
    </div>
    <div class="rt-ruler" style="width: 1407px">
        <ul>
            <li><a href="Default.aspx">My Favorites</a></li>
            <li><a href="About.aspx">About</a></li>
            <li><a href="Recipes.aspx">Recipes</a></li>
            <li><a href="Technology.aspx">Technology</a></li>
            <li><a href="Symbols.aspx">Symbols</a></li>
           <li>
                <asp:LinkButton ID="LogInOutLinkButton" runat="server" OnClick="LogInOutLinkButton_Click">Log in</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="SignUpOutLinkButton" runat="server" OnClick="SignUpOutLinkButton_Click">Sign Up</asp:LinkButton>
            </li>
            <li>
                <asp:HyperLink ID="LogdeinUserInfoHyperLink" runat="server"></asp:HyperLink>
            </li>
            <li>
                <asp:LinkButton ID="ManageToursLinkButton" runat="server" OnClick="ManageToursLinkButton_Click">Manage tours</asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="ManageUsersLinkButton" runat="server" OnClick="UsersManagerLinkButton_Click">Manage users</asp:LinkButton>
            </li>
        </ul>
    </div>
    <div class="rt-container">
        <div class="rt-nav" style="position: absolute; background-color: White; width: 200px;
            height: 1128px; margin-top: 30px;">
            <asp:BulletedList ID="BulletedListTours" runat="server" OnClick="BulletedListTours_Click"
                DisplayMode="LinkButton">
            </asp:BulletedList>
             <div class="rt-button">
                 <asp:Button ID="AddRemoveTourButton" runat="server" Text="Add Tour" OnClick="AddRemoveTourButton_Click" />
            </div>
        </div>
        <div class="rt-img&info" style="height:500px">
          
            <div class="rt-img">
                <asp:Image ID="ImageRomania" runat="server" Height="200px" style="margin-left:200px;margin-bottom:0px;margin-top:0px;" />
            </div>
            <asp:Panel ID="TourDescriptionPanel" runat="server" style="margin-left:200px;margin-top:0px;background-color:lime;height:300px;width:1207px">
            </asp:Panel>
            <!--
            <div class="info" style="margin-left:200px;height:500px;background-color:Lime;width:1207px">
            ffgd
            </div>
            -->
        </div>
    </div>
    </form>
</body>
</html>
