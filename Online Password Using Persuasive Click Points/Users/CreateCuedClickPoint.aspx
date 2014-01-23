<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateCuedClickPoint.aspx.cs"
    Inherits="Users_CuedClickPoint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online Graphical Password</title>
    <link rel="Stylesheet" type="text/css" href="../App_Themes/Default/StyleSheet.css" />
    <link href="../Styles/jquery.Jcrop.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3/jquery.min.js"></script>--%>
    <script type="text/javascript" src="../Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.Jcrop.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery('#imgPicture').Jcrop({
                onSelect: storeCoords
            });
        });

        function storeCoords(c) {
            jQuery('#X').val(c.x);
            jQuery('#Y').val(c.y);
            jQuery('#W').val(c.w);
            jQuery('#H').val(c.h);
            jQuery('#tX').val(c.x);
            jQuery('#tY').val(c.y);
            jQuery('#tW').val(c.w);
            jQuery('#tH').val(c.h);
        };
 
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <center>
        <table cellspacing="0" width="900">
            <tr>
                <td class="TopHeader">
                    <table cellspacing="0" class="ContentTable">
                        <tr>
                            <td>
                                <marquee scrolldelay="1" scrollamount="1" style="font-family: Verdana; font-size: 10px; width: 800px">
                                This project is submitted by <span style="color: #FF9933; font-weight:bold; ">HAMID NARIMANI KENARI</span>, ISIM, University of Mysore, Mysore in the Year-2013
                                </marquee>
                            </td>
                            <td align="right">
                                <asp:LinkButton ID="btnLogout" runat="server" CssClass="LinkButton2" OnClick="lnkLogout_Click">Log out</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 200px;" class="MainHeader">
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <table cellspacing="0" class="ContentTable">
                            <tr>
                                <td class="HeaderTD">
                                    &nbsp; Create Image Password
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <center>
                                        <asp:Image ID="imgPicture" runat="server" /></center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblMessage" runat="server" Font-Names="Tahoma" Font-Size="12px" ForeColor="#009933"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlCrop" runat="server">
                                        <asp:HiddenField ID="X" runat="server" />
                                        <asp:HiddenField ID="Y" runat="server" />
                                        <asp:HiddenField ID="W" runat="server" />
                                        <asp:HiddenField ID="H" runat="server" />
                                        <asp:TextBox ID="tX" runat="server" ></asp:TextBox>
                                        <asp:TextBox ID="tY" runat="server" ></asp:TextBox>
                                        <asp:TextBox ID="tW" runat="server" ></asp:TextBox>
                                        <asp:TextBox ID="tH" runat="server" ></asp:TextBox>
                                        <asp:TextBox ID="txtNoCreatedPwd" runat="server" CssClass="HideColumn"></asp:TextBox>
                                        <br />
                                        <center>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="50px"
                                                CssClass="Button" /></center>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                    <asp:HiddenField ID="hdnImageID" runat="server" />
                                    <asp:HiddenField ID="hdnPasswordModeID" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="#660066">
                </td>
            </tr>
        </table>
    </center>
    </form>
</body>
</html>
