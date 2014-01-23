<%@ Page Title="" Language="C#" MasterPageFile="~/VisitorMP.master" AutoEventWireup="true"
    CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

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
                <asp:Panel ID="Panel1" runat="server">
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
                                New Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="TextBox" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="TextBox" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                                    ControlToValidate="txtConfirmPassword" CssClass="Errors" ErrorMessage="Password not matching"
                                    SetFocusOnError="True"></asp:CompareValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblLoginMessage" runat="server" ForeColor="Red" CssClass="Errors"
                                    Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                            </td>
                            <td align="center">
                                <asp:Button ID="btnResetPassword" runat="server" CssClass="Button" OnClick="btnResetPassword_Click"
                                    Text="Reset Password" Width="120px" />
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
