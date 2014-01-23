<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="PasswordReset.aspx.cs" Inherits="Users_PasswordReset" %>

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
                <asp:RadioButtonList ID="rblOptions" runat="server" AutoPostBack="True" CssClass="TextBox"
                    OnSelectedIndexChanged="rblOptions_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Text Password</asp:ListItem>
                    <asp:ListItem>Graphical Password</asp:ListItem>
                </asp:RadioButtonList>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnVerification" runat="server" />
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
                                User Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox" Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Current Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="TextBox" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPassword"
                                    ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
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
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:Button ID="btnChangePassword" runat="server" CssClass="Button" OnClick="btnChangePassword_Click"
                                    Text="Change Password" Width="120px" />
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
                <asp:Panel ID="Panel2" runat="server" Visible="False">
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
                                <asp:TextBox ID="txtUserName0" runat="server" CssClass="TextBox" Width="200px" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Password
                            </td>
                            <td>
                                <asp:TextBox ID="txtCurrentPassword0" runat="server" CssClass="TextBox" Width="200px"
                                    TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Mobile No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="TextBox" Width="200px" Enabled="False"></asp:TextBox>
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
                                    Text="Reset" />
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
