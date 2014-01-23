<%@ Page Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="CreatePassword.aspx.cs" Inherits="Users_CreatePassword" Title="Online Graphical Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                Create Password
            </td>
        </tr>
        <tr>
            <td align="center">
                <center>
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
                                <asp:DropDownList ID="ddlPasswordMode" runat="server" CssClass="TextBox" Width="205px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPasswordMode_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                No. of Points
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNoPoints" runat="server" CssClass="TextBox">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="center">
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                            </td>
                            <td align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" BorderColor="White"
                        BorderStyle="Solid" BorderWidth="2px" RepeatColumns="6">
                        <ItemTemplate>
                            <table cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkImage" runat="server" CommandArgument='<%# Eval("ImageID") %>'
                                            OnClick="lnkImage_Click">
                                            <asp:Image ID="Image2" runat="server" Height="100" ImageUrl='<%# "~/Users/GetImages.ashx?ImageID=" + Eval("ImageID") %>'
                                                Width="100" />
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblImageName" runat="server" CssClass="TextBox" Font-Size="11px" ForeColor="#FF3399"
                                            Text='<%# Eval("ImageName") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            </a>
                        </ItemTemplate>
                        <ItemStyle BackColor="#E6E6E6" BorderColor="White" BorderStyle="Solid" BorderWidth="2px"
                            Width="120px" />
                    </asp:DataList></center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
