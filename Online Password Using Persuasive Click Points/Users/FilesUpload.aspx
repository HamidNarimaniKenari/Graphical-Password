<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="FilesUpload.aspx.cs" Inherits="Users_FilesUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                &nbsp; File Upload</td>
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
                            File Title</td>
                        <td>
                            <asp:TextBox ID="txtFileName" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtFileName" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            File Description</td>
                        <td>
                            <asp:TextBox ID="txtFileDesciption" runat="server" CssClass="TextBox" 
                                Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            File Upload</td>
                        <td>
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="TextBox" 
                                Width="200px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="fileUpload" ErrorMessage="RequiredFieldValidator" 
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="#009933"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
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
