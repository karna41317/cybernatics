<%@ Page Title="" Language="C#" MasterPageFile="~/Agency/AgencyMaster.Master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="CyberneticsProtector.Agency.frmChangePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
<center>&nbsp;</center>
 <%--<style type="text/css">
         body
        {
            font-size: 11px;
            font-family: Arial;
        }
        .ErrorIcon
        {
            list-style-image: url('i/ErrorIcon.gif' );
            padding-top: 3px;
            padding-bottom: 3px;
            padding-right: 15px;
            width: 300px;
            white-space: nowrap;
        }
        .ErrorMsg
        {
            color: #fff;
            font-family: Arial;
            text-decoration: blink;
            font-size: small;
            padding-top: 2px;
            padding-bottom: 2px;
            padding-left: 15px;
            padding-right: 15px;
            cursor: pointer;
            width: 300px;
            background-color: rgb(255,117,117);
            margin-bottom: 5px;
            white-space: nowrap;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("button").click(function () {
                $("p").hide();
            });
        });
</script>
      <script language="javascript" type="text/javascript" src="../JS/jquery.js"></script>
      <script language="javascript" type="text/javascript" src="../JS/corner.js"></script>
      <script language="javascript" type="text/javascript">
          $('#btnSave').click(function () {
              $('#dvErrors').html('');
              $('#txtOldPassword').css('border-color', '');
              $('#txtNewPassword').css('border-color', '');
              $('#txtConfirmPassword').css('border-color', '');
              if ($.trim($('#txtOldPassword').val()) == '') {
                  showErrors('txtOldPassword', 'Old Password should not be Empty');
                  return;
              }
              if ($.trim($('#txtNewPassword').val()) == '') {
                  showErrors('txtNewPassword', 'New Password should not be Empty');
                  return;
              }
              if ($.trim($('#txtNewPassword').val()) != $.trim($('#txtConfirmPassword').val())) {
                  showErrors('txtConfirmPassword', 'Password Mismatch');
                  return;
              }
              $.ajax(
      {
          mtype: 'POST',
          url: 'Handler/RequestForm.ashx?action=CHANGEPASSWORD&New=' + $('#txtNewPassword').val() + '&Old=' + $('#txtOldPassword').val() + '&date=' + new Date(),
          dataType: 'text',
          error: function (status, test) {
              alert("Unable to Process Your Request");
          },
          success: function (obj) {
              alert(obj);
          }
      }
      );
          }
    );
          function showErrors(objId, message) {
              $('#' + objId).css('border-color', 'red');
              $('#dvErrors').append('<li class="ErrorIcon" onclick=setFocus("' + objId + '")><label class="ErrorMsg">' + message + '</label></li>');
          }
    </script>--%>

<center>
<h3 style="text-decoration: underline" class="style9">Change Password</h3>
<center>&nbsp;</center>
<asp:Panel ID="pnl" runat="server" Width="383px" Height="246px">
<center>&nbsp;</center>
<center>&nbsp;</center>
<table>
<tr>
<td class="style9">UserName</td><td class="style9"><asp:TextBox ID="txtUserName" ClientIDMode="Static" runat ="server" ></asp:TextBox></td>
    <td class="style9"><asp:RequiredFieldValidator ID="RFVUserName" runat ="server" ControlToValidate="txtUserName" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td class="style9">Old Password</td><td class="style9"><asp:TextBox ID="txtOldPassword" ClientIDMode="Static" runat ="server" MaxLength="8" TextMode="Password" ></asp:TextBox></td>
    <td class="style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat ="server" ControlToValidate="txtOldPassword" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td class="style9">New Password</td><td class="style9"><asp:TextBox ID="txtNewPassword" ClientIDMode="Static" runat ="server" 
        MaxLength="8" TextMode="Password" ></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat ="server" ControlToValidate="txtNewPassword" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td class="style9">Confirm Password</td><td class="style9"><asp:TextBox ID="txtConfirmPassword" ClientIDMode="Static" runat ="server" 
        MaxLength="8" TextMode="Password" ></asp:TextBox></td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat ="server" ControlToValidate="txtConfirmPassword" ErrorMessage ="*"></asp:RequiredFieldValidator></td>
</tr>
<tr>
<td colspan="3"><asp:Button ID="btnSubmit" runat ="server" Text="Submit" 
        onclick="btnSubmit_Click" OnClientClick="return confirm('Do u Want Update Your Password!')" />
      <%--  <input type="button" id="btnSave" value="Save" />--%>
    <asp:Button ID="btnClear" runat ="server" Text="Clear" CausesValidation="false" 
        onclick="btnClear_Click" /></td>
</tr>
<tr>
<td colspan="3"><asp:Label ID="lblMsg" runat ="server" Visible ="false" 
        style="font-family: Verdana" ></asp:Label>
    <div ID="dvErrors">
    </div>
    </td>
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
