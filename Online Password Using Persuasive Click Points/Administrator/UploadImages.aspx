<%@ Page Language="C#" MasterPageFile="~/Administrator/AdministratorMP.master" AutoEventWireup="true"
    CodeFile="UploadImages.aspx.cs" Inherits="Administrator_UploadImages" Title="Online Graphical Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                IMAGE UPLOAD
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
                            Password Type
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPasswordMode" runat="server" CssClass="TextBox" Width="205px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPasswordMode"
                                ErrorMessage="RequiredFieldValidator" InitialValue="0" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Image Title
                        </td>
                        <td>
                            <asp:TextBox ID="txtImageTitle" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtImageTitle"
                                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Upload Image
                        </td>
                        <td>
                            <asp:FileUpload ID="fileImages" runat="server" CssClass="TextBox" Width="200px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fileImages"
                                ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
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
        <tr>
            <td>
                <center>
                    <asp:DataList ID="DataList1" runat="server" BorderStyle="Double" RepeatColumns="5"
                        Height="80px" BorderColor="#CC3399" BorderWidth="1px" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Administrator/GetImages.ashx?ImageID=" + Eval("ImageID") %>'
                                            Width="100px" Height="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblImageName" runat="server" CssClass="TextBox" ForeColor="#FF3399"
                                            Text='<%# Eval("ImageName") %>' Font-Size="11px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPasswordModeName" runat="server" CssClass="TextBox" Font-Size="9px"
                                            ForeColor="#999999" Text='<%# Eval("PasswordModeName") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <ItemStyle BorderColor="#CC3399" BorderStyle="Solid" BorderWidth="1px" VerticalAlign="Top"
                            Width="140px" />
                    </asp:DataList></center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
