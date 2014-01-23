<%@ Page Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="CreatePersuasiveCuedClick.aspx.cs" Inherits="Users_CreatePersuasiveCuedClick"
    Title="Online Graphical Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPointNo0" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="15px">Select point no. :</asp:Label>
                <asp:Label ID="lblPointNo" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <center>
                    <asp:DataList ID="DataList1" runat="server" BackColor="#999999" BorderStyle="None"
                        RepeatColumns="5" Height="80px" Width="80px">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%# Eval("PersuasiveImgID") %>'>
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Users/GetImagePart.ashx?ImagePartID=" + Eval("PersuasiveImgID") %>'
                                                Width="80px" Height="80px" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList></center>
                <asp:HiddenField ID="hdnImageID" runat="server" />
                <asp:Label ID="lblMessage" runat="server" CssClass="TextBox" Font-Bold="True" ForeColor="Green"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellspacing="0">
                    <tr>
                        <td>
                            <center>
                                <asp:Image ID="Image1" runat="server" Height="80px" Width="80px" Visible="False" /></center>
                            <asp:HiddenField ID="hdnImagePartID" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <center>
                                <asp:Button ID="btnSave" runat="server" CssClass="Button" OnClick="btnSave_Click"
                                    Text="Save" Visible="False" /></center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
