<%@ Page Language="C#" MasterPageFile="~/VisitorMP.master" AutoEventWireup="true"
    CodeFile="AdministratorLogin.aspx.cs" Inherits="AdministratorLogin" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                &nbsp; Administrator Login
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <table cellspacing="0" class="LoginTable" width="300">
                    <tr>
                        <td class="LoginHeaderTD">
                            LOGIN
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <table cellspacing="0" class="DetailsTable">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLoginMessage" runat="server" CssClass="Errors" Font-Bold="True"
                                                Font-Size="10px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Login Name
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox2" Height="30px" Width="250px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Password
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="TextBox2" Height="30px"
                                                Width="250px" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="margin-left: 40px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="margin-left: 40px">
                                            <asp:Button ID="btnLogin" runat="server" CssClass="Button" OnClick="btnLogin_Click"
                                                Style="height: 26px" Text="Login" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="margin-left: 40px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
