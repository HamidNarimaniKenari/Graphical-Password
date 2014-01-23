<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckPassPoint.aspx.cs" Inherits="Users_CheckPassPoint" %>

<%@ Register Src="Menu.ascx" TagName="Menu" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Graphical Password</title>
    <link rel="Stylesheet" type="text/css" href="../App_Themes/Default/StyleSheet.css" />
    <%-- <script type="text/javascript">
            function GetXanY()
            {
            var x = document.images.ImageButton1.offsetLeft;
            var y = document.images.ImageButton1.offsetTop;
            alert('X = ' + x +';  Y = ' + y);
            return true;
            }
    </script>--%>
    <%--<script type="text/javascript">
            $('#ImageButton1').click(function(e)
        {

            var offset_t = $(this).offset().top - $(window).scrollTop();
            var offset_l = $(this).offset().left - $(window).scrollLeft();

            var left = Math.round( (e.clientX - offset_l) );
            var top = Math.round( (e.clientY - offset_t) );

            alert("Left: " + left + " Top: " + top);

        });
    </script>--%>
    <%--  <script type="text/javascript">
    $(document).bind('click', function () {
        // Add a click-handler to the image.
        $('#ImageButton1').bind('click', function (ev) {
            var $img = $(ev.target);

            var offset = $img.offset(); // Offset from the corner of the page.
            var xMargin = ($div.outerWidth() - $div.width()) / 2;
            var yMargin = ($div.outerHeight() - $div.height()) / 2;
            // Note that the above calculations assume your left margin is 
            // equal to your right margin, top to bottom, etc. and the same 
            // for borders.

            var x = (ev.clientX + xMargin) - offset.left;
            var y = (ev.clientY + yMargin) - offset.top;

            alert('clicked at x: ' + x + ', y: ' + y);
        });
    });
    </script>--%>
    <%-- <script type="text/javascript">
    $(document).bind('click', function () {
        // Add a click-handler to the image.
        $('#ImageButton1').bind('click', function (ev) {
            var $img = $(ev.target);

            var offset = $img.offset();
            var x = ev.clientX - offset.left;
            var y = ev.clientY - offset.top;

            alert('clicked at x: ' + x + ', y: ' + y);
        });
    });
    </script>--%>
    <%-- <script type="text/javascript">
        function GetXY() {
            var img = document.getElementById("ImageButton1");
            document.getElementById("tooltip").innerHTML = '(X,Y) (' + event.x + ' , ' + event.y + ')';
            document.getElementById("tooltip").style.top = event.y;
            document.getElementById("tooltip").style.left = event.x;
        }
        function ClickGetXY() {
            var img = document.getElementById("ImageButton1");
            document.getElementById("tX").value = event.x;
            document.getElementById("tY").value = event.y;
            document.getElementById("tY").style.top = event.y;
            document.getElementById("tX").style.left = event.x;
        }
    </script>--%>
    <script type="text/javascript">
        function getMouseXY(e, obj) {
            var e = (!e) ? window.event : e;
            //find mouse coordinates
            if (e.pageX || e.pageY) {
                posX = e.pageX;
                posY = e.pageY;
            }
            else if (e.clientX || e.clientY) {
                if (document.body.scrollLeft || document.body.scrollTop) {
                    posX = e.clientX + document.body.scrollLeft;
                    posY = e.clientY + document.body.scrollTop;
                }
                else {
                    posX = e.clientX + document.documentElement.scrollLeft;
                    posY = e.clientY + document.documentElement.scrollTop;
                }
            }
            else {
                posX = 0;
                posY = 0;
            }
            //find image coordinates
            if (obj.offsetLeft || obj.offsetTop) {
                xOffset = obj.offsetLeft;
                yOffset = obj.offsetTop;
                parentObj = obj.offsetParent;
                while (parentObj != null) {
                    xOffset += parentObj.offsetLeft;
                    yOffset += parentObj.offsetTop;
                    parentObj = parentObj.offsetParent;
                }
            }
            else if (obj.x || obj.y) {
                xOffset = obj.x;
                yOffset = obj.y;
            }
            else {
                xOffset = 0;
                yOffset = 0;
            }
            document.getElementById("tX").value = (posX - xOffset - 2);
            document.getElementById("tY").value = (posY - yOffset - 2);
            //alert("Relative to window\n\nx: " + posX + "\ny: " + posY + "\n\nRelative to Image\n\nx: " + (posX - xOffset - 2) + "\ny: " + (posY - yOffset - 2));
        }
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table cellspacing="0" class="ContentTable">
                                    <tr>
                                        <td class="HeaderTD">
                                           Image Password Selection
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--onmousemove="GetXY()"--%>
                                        <td>
                                           <center> <asp:ImageButton ID="ibtnPasswordImage" runat="server" OnClick="ibtnPasswordImage_Click"
                                                OnClientClick="getMouseXY(event, this)" /></center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tX" runat="server" CssClass="HideColumn"></asp:TextBox>
                                            <asp:TextBox ID="tY" runat="server" CssClass="HideColumn"></asp:TextBox>
                                            <asp:TextBox ID="txtCount" runat="server" CssClass="HideColumn">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ListBox ID="lstX" runat="server"  Height="150px"></asp:ListBox>
                                            <asp:ListBox ID="lstY" runat="server"  Height="150px"></asp:ListBox>
                                            <asp:ListBox ID="lstImages" runat="server" CssClass="HideColumn" Height="150px">
                                            </asp:ListBox>
                                            <asp:HiddenField ID="hdnImageID" runat="server" />
                                            <asp:HiddenField ID="hdnUserID" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
