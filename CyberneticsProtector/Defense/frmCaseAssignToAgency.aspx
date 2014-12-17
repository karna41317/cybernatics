<%@ Page Title="" Language="C#" MasterPageFile="~/Defense/DefenseMaster.Master" AutoEventWireup="true" CodeBehind="frmCaseAssignToAgency.aspx.cs" Inherits="CyberneticsProtector.Defense.frmCaseAssignToAgency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<br />
<br />
<br />
<center>
<table bgcolor="#f0f0f0" style="width: 41%">
        <tr>
            <td align="center" colspan="3" style="height: 46px">
                <table width="100%">
                    <tr>
                        <td align="center" colspan="3" style="font-weight: bold; font-size: 14pt; color: #ffffff;
                            background-color: #909152; height: 24px;">
                            Assign Cases</td>
                    </tr>
                </table>
                </td>
        </tr>
         <tr>
            <td align="right" style="color: #000000; width: 2041px; height: 24px;">
                Select
                Case:</td>
            <td align="left" style="height: 24px; width: 216px;">
                <asp:DropDownList ID="ddlCase" runat="server" Height="25px" Width="125px" onselectedindexchanged="ddlCase_SelectedIndexChanged" 
                    >
                </asp:DropDownList>
                                </td>
            <td align="left" style="width: 279px; height: 24px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="color: #000000; width: 2041px; height: 24px;">
                Select
                Agency:</td>
            <td align="left" style="height: 24px; width: 216px;">
                <asp:DropDownList ID="ddlAgency" runat="server" Height="25px" Width="125px" 
                    >
                </asp:DropDownList>
                                </td>
            <td align="left" style="width: 279px; height: 24px;">
            </td>
        </tr>
           
       
        <tr>
            <td align="right" colspan="2">
            <asp:Button ID="BtnCase" runat="server" Text="Assign" Width="86px" onclick="BtnCase_Click" 
                    />&nbsp;
                <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" Width="86px" />
                </td>
                <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblMessage" runat="server" Width="320px" Font-Bold="True" ForeColor="Black"></asp:Label></td>
        </tr>
    </table>
</center>
</asp:Content>
