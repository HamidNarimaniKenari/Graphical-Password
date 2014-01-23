<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorMP.master" AutoEventWireup="true"
    CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                Password Reset
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnVerification" runat="server" />
                <asp:HiddenField ID="hdnMobileNo" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel2" runat="server">
                    <table align="center" cellspacing="0" class="DetailsTable">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                User Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblLoginMessage0" runat="server" CssClass="Errors" Font-Bold="True"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSendCode" runat="server" CssClass="Button" OnClick="btnSendCode_Click"
                                    Text="Send Verification Code" Width="150px" />
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel3" runat="server" Visible="False">
                    <table align="center" cellspacing="0" class="DetailsTable">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Verification Code
                            </td>
                            <td>
                                <asp:TextBox ID="txtVerificationCode" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblLoginMessage1" runat="server" CssClass="Errors" Font-Bold="True"
                                    ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="btnReset" runat="server" CssClass="Button" OnClick="btnReset_Click"
                                    Text="Reset" Width="60px" />
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
