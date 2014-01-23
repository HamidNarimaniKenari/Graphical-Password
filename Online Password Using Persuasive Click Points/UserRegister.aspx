<%@ Page Language="C#" MasterPageFile="~/VisitorMP.master" AutoEventWireup="true"
    CodeFile="UserRegister.aspx.cs" Inherits="UserRegister" Title="Online Password Using Persuasive Click Points" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                User Registration
            </td>
        </tr>
        <tr>
            <td align="center">
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
                            First Name</td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="TextBox" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            E-Mail ID</td>
                        <td>
                            <asp:TextBox ID="txtEMailID" runat="server" CssClass="TextBox" 
                                Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtEMailID" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtEMailID" CssClass="Errors" 
                                ErrorMessage="RegularExpressionValidator" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid 
                            email</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mobile No.</td>
                        <td>
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="TextBox" 
                                Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtMobileNo" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtMobileNo" CssClass="Errors" 
                                ErrorMessage="Invalid Mobile No." ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Login Name</td>
                        <td>
                            <asp:TextBox ID="txtLoginName" runat="server" CssClass="TextBox" 
                                Width="200px" AutoPostBack="True" ontextchanged="txtLoginName_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtLoginName" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Label ID="lblAvailable" runat="server" Font-Bold="True" Font-Size="10px" 
                                ForeColor="#009933"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" 
                                Width="200px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Confirm Password</td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="TextBox" 
                                Width="200px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtConfirmPassword" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                                CssClass="Errors" ErrorMessage="CompareValidator">Password not matching</asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="#009933"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="Button" OnClick="btnSubmit_Click"
                                Text="Submit" Width="60px" />
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        </table>
</asp:Content>
