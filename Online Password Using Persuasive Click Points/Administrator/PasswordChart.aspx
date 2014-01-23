<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/AdministratorMP.master"
    AutoEventWireup="true" CodeFile="PasswordChart.aspx.cs" Inherits="Administrator_PasswordChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                PASSWORD CHART
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Chart ID="Chart1" runat="server" Height="500px" Width="400px">
                    <Series>
                        <asp:Series Name="PasswordChart" Label="#VAL{N0}" LegendText="Password Modes">
                            <SmartLabelStyle CalloutLineAnchorCapStyle="Diamond" CalloutStyle="Box" />
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
    </table>
</asp:Content>
