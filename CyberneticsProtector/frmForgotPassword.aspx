<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="frmForgotPassword.aspx.cs" Inherits="CyberneticsProtector.frmForgotPassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
        .style9
        {
            font-family: Verdana;
        }
    </style>
    <center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>


<center>
<h3 style="text-decoration: underline" class="style9">Forgot Password</h3>
<center>&nbsp;</center>
<asp:Panel ID="pnl" runat="server" Width="320px" Height="185px">
<center>&nbsp;</center>
<center>&nbsp;</center>
<table>
<tr>
<td align="left" class="style9">UserName</td><td align="left"><asp:TextBox ID="txtUserName" runat ="server" ></asp:TextBox><asp:RequiredFieldValidator ID="RFVUserName" runat ="server" ControlToValidate="txtUserName" ForeColor="Red" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td align="left" class="style9">Hint Question</td><td align="left">
                        <asp:DropDownList ID="ddlHintQuestion" runat="server" Height="17px" 
                            Width="127px">
                            <asp:ListItem>Select HintQuestion</asp:ListItem>
                            <asp:ListItem>Your Favourate Crickter</asp:ListItem>
                            <asp:ListItem>Your PetName?</asp:ListItem>
                            <asp:ListItem>Favourate Color?</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" ForeColor="Red" runat="server" ControlToValidate="ddlHintQuestion"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
</tr>
<tr>
<td align="left" class="style9">Answer</td><td align="left"><asp:TextBox ID="txtAnswer" runat ="server" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ControlToValidate="txtAnswer" ForeColor="Red" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td></td><td></td>
</tr>
<tr>
<td colspan="2"><asp:Button ID="btnSubmit" runat ="server" Text="Get Password" 
        onclick="btnSubmit_Click" 
        OnClientClick="return confirm('are you sure Hint Answer is Correct!')" />
    <asp:Button ID="btnClear" runat ="server" Text="Clear" CausesValidation="false" 
        onclick="btnClear_Click" /></td>
</tr>
<tr>
<td colspan="2"><asp:Label ID="lblMsg" runat ="server" Visible ="false" 
        style="font-family: Verdana" ></asp:Label></td>
</tr>
</table>
<center>&nbsp;</center>
</asp:Panel>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</center>
<cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
        BorderColor="Black" Radius="15" Corners="All" TargetControlID="pnl">
    </cc1:RoundedCornersExtender>
</asp:Content>

