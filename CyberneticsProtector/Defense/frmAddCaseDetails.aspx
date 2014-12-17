<%@ Page Title="" Language="C#" MasterPageFile="~/Defense/DefenseMaster.Master" AutoEventWireup="true" CodeBehind="frmAddCaseDetails.aspx.cs" Inherits="CyberneticsProtector.Defense.frmAddCaseDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
<style type="text/css">
 .style8
        {
           
	        font-weight:bold;
	        color:#2D3A48;
	        font-size:12px;
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	       
        }
</style>
<center>
<asp:Panel id="pnl" CssClass="style8" GroupingText="Add Case Details" 
        runat ="server" Width="395px">

<table>
<tr><td colspan="3">
    &nbsp;</td></tr>               
<tr><td>Case Name</td>
    <td align="left">
        <asp:TextBox ID="txtCaseName" runat="server" Height="22px" Width="144px"></asp:TextBox>
          </td><td></td></tr>
    <tr><td>Description</td>
    <td>
        <asp:TextBox ID="txtDescription" runat="server" Height="111px" 
            TextMode="MultiLine" Width="147px"></asp:TextBox>
    </td><td></td></tr>
    <tr><td colspan="3">Upload Case Details Here
        </td>
    </tr>
    <tr><td colspan="3">
        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="76" />
        </td>
    </tr>
<tr><td colspan="3">
    &nbsp; 
    <asp:Button ID="btnInsert" runat="server" Text="Insert" Height="27px" 
        Width="71px" onclick="btnInsert_Click"/>
</td></tr>
<tr><td colspan="3">
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </td></tr>
<tr><td colspan="3">
    &nbsp;</td></tr>
</table>
 <br />  
</asp:Panel>
<br />
</center>
 <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
        BorderColor="Black" Radius="15" Corners="All" TargetControlID="pnl">
    </cc1:RoundedCornersExtender>


</asp:Content>
