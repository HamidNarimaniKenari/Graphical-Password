<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Users_Menu" %>
<asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" DynamicHorizontalOffset="2"
    Font-Bold="True" Font-Names="Tahoma" Font-Size="12px" ForeColor="#7C6F57" Orientation="Horizontal"
    StaticSubMenuIndent="10px">
    <StaticSelectedStyle BackColor="#5D7B9D" />
    <StaticMenuItemStyle BorderColor="#CCFF99" BorderStyle="Solid" BorderWidth="1px"
        HorizontalPadding="5px" VerticalPadding="2px" Width="100px" Height="25px" BackColor="#CC0066"
        ForeColor="White" />
    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
    <DynamicMenuStyle BackColor="#F7F6F3" />
    <DynamicSelectedStyle BackColor="#5D7B9D" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
    <Items>
        <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Users/HomePage.aspx"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Users/FilesUpload.aspx" Text="Upload Files" 
            Value="Upload Files"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Users/SendSMS.aspx" Text="Send SMS" 
            Value="Send SMS"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Users/FileDownload.aspx" Text="File Download" 
            Value="File Download"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Users/PasswordReset.aspx" Text="Password Reset" 
            Value="Password Reset"></asp:MenuItem>
    </Items>
</asp:Menu>
