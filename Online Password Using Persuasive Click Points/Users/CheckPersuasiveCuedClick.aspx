<%@ Page Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="CheckPersuasiveCuedClick.aspx.cs" Inherits="Users_PersuasiveCuedClick"
    Title="Online Graphical Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
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
                                Height="80px" RepeatColumns="5" Width="80px">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("PersuasiveImgID") %>'
                                                    OnClick="LinkButton1_Click">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/Users/GetImagePart.ashx?ImagePartID=" + Eval("PersuasiveImgID") %>'
                                                        Width="80px" Height="80px" />
                                                </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></center>
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:ListBox ID="ListBox1" runat="server"  Height="117px" Width="119px">
                        </asp:ListBox>
                        <asp:ListBox ID="ListBox2" runat="server"  Height="115px" Width="125px">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
