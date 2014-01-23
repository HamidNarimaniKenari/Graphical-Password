<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="CreatePassPoint2.aspx.cs" Inherits="Users_CreatePassPoint2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script type="text/javascript">

        $(document).ready(function () {
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
 
    </script>--%>
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                &nbsp; Create Image Password
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgPicture" runat="server" />
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
                    <asp:TextBox ID="tX" runat="server" CssClass="HideColumn"></asp:TextBox>
                    <asp:TextBox ID="tY" runat="server" CssClass="HideColumn"></asp:TextBox>
                    <asp:TextBox ID="tW" runat="server" CssClass="HideColumn"></asp:TextBox>
                    <asp:TextBox ID="tH" runat="server" CssClass="HideColumn"></asp:TextBox>
                    <asp:TextBox ID="txtNoCreatedPwd" runat="server" CssClass="HideColumn"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="50px"
                        CssClass="Button" />
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
    <script src="../Scripts/Crop.js" type="text/javascript"></script>

</asp:Content>
