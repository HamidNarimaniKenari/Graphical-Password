<%@ Page Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="InvalidPassword2.aspx.cs" Inherits="Users_InvalidPassword" Title="Online Graphical Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <img alt="" src="InvalidPassword.jpeg" />
    <br />
    <asp:Button ID="btnLogout" CssClass="Button" runat="server" Text="Log out" OnClick="btnLogout_Click" />
</asp:Content>
