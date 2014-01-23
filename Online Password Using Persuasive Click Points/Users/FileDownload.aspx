<%@ Page Title="" Language="C#" MasterPageFile="~/Users/UsersMP.master" AutoEventWireup="true"
    CodeFile="FileDownload.aspx.cs" Inherits="Users_FileDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellspacing="0" class="ContentTable">
        <tr>
            <td class="HeaderTD">
                &nbsp; File Upload
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gridFilesDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="GridViewFont" DataKeyNames="FileID" ForeColor="#333333" Width="80%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="FileID" HeaderText="FileID" SortExpression="FileID">
                            <HeaderStyle CssClass="HideColumn" />
                            <ItemStyle CssClass="HideColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID">
                            <HeaderStyle CssClass="HideColumn" />
                            <ItemStyle CssClass="HideColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FileTitle" HeaderText="FileTitle" SortExpression="FileTitle" />
                        <asp:BoundField DataField="FileName" HeaderText="FileName" SortExpression="FileName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="DoFileUpload" DataFormatString="{0:dd-MMM-yyyy hh:mm tt}"
                            HeaderText="File Uploaded Date" SortExpression="DoFileUpload" />
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnDownload" runat="server" CausesValidation="false" CommandName="Download"
                                    CssClass="GridLinkButton1" OnClick="lbtnDownload_Click" Text="Download"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
