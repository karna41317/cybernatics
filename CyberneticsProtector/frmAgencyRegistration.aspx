﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="frmAgencyRegistration.aspx.cs" Inherits="CyberneticsProtector.frmAgencyRegistration" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
<style type="text/css">
.watermarked
  {
 
  color:Red;
  background-color:ThreeDHighlight;
  }
    .barIndicatorBorder 
    {
    	border:solid 1px #c0c0c0;width:200px;
    	height:100px
    }
     
    .barIndicator_poor { background-color:Red; }
    .barIndicator_weak { background-color:Red; }
    .barIndicator_good { background-color:Blue; }
    .barIndicator_strong { background-color:Blue; }
    .barIndicator_excellent { background-color:green;  }
    .textbox { border: solid 2px #cccccc;border-top: solid 2px #a0a0a0; }
      .style8
        {
           
	        font-weight:bold;
	        color:#2D3A48;
	        font-size:12px;
	        font-family: Verdana, Arial, Helvetica, sans-serif;
	       
        }
    .style10
    {
        font-family: Verdana;
        font-size: small;
        text-decoration: underline;
        font-weight: bold;
    }
    .style11
    {
        font-family: Verdana;
        font-weight: bold;
        font-size: small;
    }
    .style12
    {
        font-family: Verdana;
    }
    .style13
    {
        font-size: small;
        font-weight: bold;
    }
    .style14
    {
        font-size: small;
    }
    .style15
    {
        font-weight: bold;
        color: #2D3A48;
        font-size: 11px;
        font-family: Verdana, Arial, Helvetica, sans-serif;
        height: 25px;
    }
    .style16
    {
        height: 25px;
    }
    .style17
    {
        font-weight: bold;
        color: #2D3A48;
        font-size: 11px;
        font-family: Verdana, Arial, Helvetica, sans-serif;
        width: 138px;
    }
    .style18
    {
        font-weight: bold;
        color: #2D3A48;
        font-size: 11px;
        font-family: Verdana, Arial, Helvetica, sans-serif;
        height: 25px;
        width: 138px;
    }
    .style19
    {
        width: 127px;
    }
    .style20
    {
        height: 25px;
        width: 127px;
    }
    .style21
    {
        color: #FF3300;
    }
    .style22
    {
        color: #FF0000;
    }
</style>

<center>&nbsp;</center>
        <h4 style="text-align: center; text-decoration: underline;" class="style12">
            <span class="style14">&nbsp;</span><span class="style13">Registration Form</span></h4>
         <center>&nbsp;</center>
           <asp:Panel ID="Regiter" class="style8" runat="server"><table width="600px">
   <tr>
   <td>
        <fieldset id="Fieldset1"  runat ="server" style="border-style: groove; width: 600px; margin-left: 23px; margin-top: 0px;">
           
            <p class="style11" style="text-decoration:underline">
                Login Information</p>
        <center>
        <table>
        <tr><td class="style17"><asp:Label ID="lblVoterId" runat="server">Enter Login Id</asp:Label>  </td>
            <td align="left" class="style19">
            <asp:TextBox ID="txtLoginId" runat ="server" EnableTheming="True" 
                MaxLength="10" ValidationGroup="vg1" 
                ontextchanged="txtLoginIdChanged" AutoPostBack="True" Height="21px" 
                    Width="127px" ></asp:TextBox></td>
        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginId"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style21" ></asp:RequiredFieldValidator></td><td align="left"><span class="style8">
                Password</span></td><td align="left">
            <asp:TextBox ID="txtPassword" runat ="server" 
                TextMode="Password" MaxLength="8" BorderStyle="None" 
                ValidationGroup="vg1" ontextchanged="txtPassword_TextChanged"  ></asp:TextBox>
                                                    </td>
                                                       <td>
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                               ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="vg1" 
                                                               CssClass="style21"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr><td class="style17">Conform Password</td><td class="style19">
            <asp:TextBox ID="txtConfirmPassword" runat ="server" MaxLength="8" 
                TextMode="Password" ValidationGroup="vg1" Height="22px" Width="126px" ></asp:TextBox></td><td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style21"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comp1" runat="server" ControlToCompare="txtPassword" 
                    ControlToValidate="txtConfirmPassword" ErrorMessage="*" Operator="Equal" 
                    ValidationGroup="vg1" CssClass="style21"></asp:CompareValidator>
            </td><td class="style8">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        <td>
            &nbsp;</td>
               <td class="style21">
            &nbsp;</td>
        </tr>
        <tr><td class="style18">Hint Question</td><td class="style20">
            <asp:DropDownList ID="ddlHintQuestion" runat="server" Height="16px" 
                Width="121px">
                <asp:ListItem>Select HintQuestion</asp:ListItem>
                <asp:ListItem>Your Favourate Crickter</asp:ListItem>
                <asp:ListItem>Your PetName?</asp:ListItem>
                <asp:ListItem>Favourate Color?</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            </td><td class="style16">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirmPassword"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style21"></asp:RequiredFieldValidator>
            </td><td class="style15">
                Answer</td>
        <td class="style16">
            <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
            </td>
               <td class="style16">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                       ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="vg1" 
                       CssClass="style21"></asp:RequiredFieldValidator>
            </td>
        </tr>
        </table>
        </center>
        <br />
        <span class="style8">
            <asp:Label ID="lblId" runat="server" Text="lblId" Visible="false"></asp:Label></span>
            <br />
        </fieldset>
        </td></tr></table>
            <fieldset id="Field1" runat ="server" style="border-style: groove; width: 600px; margin-left: 23px" >
            <center>
        <table>
        <tr>
                <td colspan="6">
                    &nbsp;</td>
                </tr>
            <tr>
                <td class="style8">
                    FirstName
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFName" runat="server" MaxLength="20" ValidationGroup="vg1"></asp:TextBox>
                </td>
                <td>
                <asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="txtFname"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style22" ></asp:RequiredFieldValidator>
                </td>
                <td class="style8">
                    PhoneNo</td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server" ValidationGroup="vg1" Width="128px"></asp:TextBox>
                   </td><td> 
                    <asp:RegularExpressionValidator ID="re1" runat="server" 
                        ControlToValidate="txtPhoneNo" ErrorMessage="*" ValidationExpression="\d{10}" 
                        ValidationGroup="vg1" CssClass="style22"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    LastName
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLName" runat="server" ValidationGroup="vg1"></asp:TextBox>
                </td>
                <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLname"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style22" ></asp:RequiredFieldValidator>
                </td>
                <td class="style8">
                    DateOfBirth
                </td>
                <td>
                    <ew:CalendarPopup ID="txtDOB" runat="server">
                    </ew:CalendarPopup>
                   <%-- <asp:TextBox ID="txtDOB1" onfocusout="calage()" runat="server" 
                        ValidationGroup="vg1"></asp:TextBox>
                   
                    <cc1:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDOB">
                    </cc1:CalendarExtender>
                   </td> <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDOB"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style22" ></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cv2" runat="server" ControlToValidate="txtDOB" 
                        ErrorMessage="*" Operator="DataTypeCheck" Type="Date" 
                        ValidationGroup="vg1" CssClass="style22"></asp:CompareValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Email Id
                </td>
                <td align="left">
                    <asp:TextBox ID="txtEmailId" runat="server" ValidationGroup="vg1"></asp:TextBox>
                    </td>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmailId"
        ErrorMessage="*" ValidationGroup="vg1" CssClass="style22" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REg1" runat="server" 
                            ControlToValidate="txtEmailId" ErrorMessage="*" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="vg1" CssClass="style22"></asp:RegularExpressionValidator>
                </td><td class="style8">Address </td><td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtAddress" ErrorMessage="*" ValidationGroup="vg1" 
                            CssClass="style22"></asp:RequiredFieldValidator>
                                        </td>
                </tr>
               <tr>
                <td colspan="6">
                    &nbsp;</td>
                </tr>
        </table>
        </center>
        </fieldset>
        <fieldset id="Field2" runat ="server" 
            style="border-style: groove; width:600px; margin-left: 23px">
            <p>
                <span class="style10">Upload Your Photo Here</span></p>
        <table>
        <tr><td>
        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="76" />
            &nbsp;</td></tr>
         <tr>
        <td><asp:Button ID="btnSubmit" runat ="server" Text ="Submit" 
                onclick="btnSubmit_Click" ValidationGroup="vg1"/>
            <asp:Button ID="btnClear" runat ="server" 
                Text ="Clear" 
                CausesValidation="False" onclick="btnClear_Click"  /></td>
        </tr>
        </table>
        <center>&nbsp;</center>
         <center>&nbsp;</center>
        </fieldset>
   <table width="600px">
   <tr>
   <td>
        
        <asp:Label ID="lblMessage" runat="server" Text="lblMessage" Visible="false" 
            style="font-family: Verdana;"></asp:Label>
        
        </td></tr></table></asp:Panel>
    </center>
     <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
     TargetControlID="txtLoginId" 
      WatermarkText="Type Login Id"
       WatermarkCssClass="watermarked"
       runat="server">
    </cc1:TextBoxWatermarkExtender>
       <cc1:PasswordStrength ID="PasswordStrength2" runat="server"
     TargetControlID="txtPassword"
     PreferredPasswordLength="6"
     CalculationWeightings="25;25;15;35"
     RequiresUpperAndLowerCaseCharacters="true"
     TextStrengthDescriptions="Poor;Weak;Good;Strong;Excellent"
     HelpStatusLabelID="Label1"
     StrengthIndicatorType="BarIndicator"
     HelpHandlePosition="AboveLeft"
     BarBorderCssClass="barIndicatorBorder"
     StrengthStyles="barIndicator_poor; barIndicator_weak;barIndicator_good; barIndicator_strong; barIndicator_excellent">
    </cc1:PasswordStrength>
</asp:Content>
