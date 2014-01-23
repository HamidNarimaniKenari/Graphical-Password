<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InvalidPassword.aspx.cs"
    Inherits="Users_InvalidPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Graphical Password</title>
    <link rel="Stylesheet" type="text/css" href="../App_Themes/Default/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <img alt="" src="InvalidPassword.jpeg" />
            <br />
            <asp:Button ID="btnLogout" CssClass="Button" runat="server" Text="Log out" OnClick="btnLogout_Click" /></center>
    </div>
    </form>
</body>
</html>
