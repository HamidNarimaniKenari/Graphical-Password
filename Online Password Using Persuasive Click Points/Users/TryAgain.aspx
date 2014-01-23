<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryAgain.aspx.cs" Inherits="Users_TryAgain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 600px; vertical-align: middle;">
        <center>
            <asp:ImageButton ID="imgTryAgain" runat="server" 
                ImageUrl="~/Images/TryAgain.jpg" onclick="imgTryAgain_Click" Width="500px" /></center>
    </div>
    </form>
</body>
</html>
