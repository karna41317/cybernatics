<%@ Page Title="" Language="C#" MasterPageFile="~/Agency/AgencyMaster.Master" AutoEventWireup="true" CodeBehind="frmViewCaseDetails.aspx.cs" Inherits="CyberneticsProtector.Agency.frmViewCaseDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center></center>
<center></center>
<center>
    <asp:GridView ID="gvCaseFromDefense" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal" 
        onrowcommand="gvCaseFromDefense_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
    <asp:TemplateField HeaderText="Case Name">
    <ItemTemplate>
    <%#Eval("CaseName")%>
    </ItemTemplate>
    </asp:TemplateField>
       <asp:TemplateField HeaderText="Description">
    <ItemTemplate>
    <%#Eval("Description")%>
    </ItemTemplate>
    </asp:TemplateField>
       <asp:TemplateField HeaderText="Register Date">
    <ItemTemplate>
    <%#Eval("RegisterDate")%>
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="DownLoad Here">
    <ItemTemplate>
        <asp:LinkButton ID="lnkAccept" CommandName="Download" CommandArgument=' <%#Eval("CaseId")%>' runat="server">Download</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="Assign Here">
    <ItemTemplate>
        <asp:LinkButton ID="lnkAssign" CommandName="Assign" CommandArgument=' <%#Eval("CaseId")%>' runat="server">Assign</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
</center>
 <center>
        <table>
        <tr>
    <td width="77%" align="center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
     TargetControlID="btnShowPopUp" PopupControlID="pnlmessage1" ClientIDMode="Static" CancelControlID="btnCancel">
    </cc1:ModalPopupExtender>
               
               </td></tr>
               <tr>
               <td>
                <asp:Button ID="btnShowPopUp" ClientIDMode="Static" runat="server" style="display:none;"/>
               </td>
               </tr>
<tr><td width="77%">
    <asp:Panel ID="pnlmessage1" Visible="false" runat="server" ClientIDMode="Static" 
        GroupingText="Assign Case To Agent..." Width="400px" 
        Font-Bold="True" BackColor="White" Height="168px">
        <table style="border:#627AAD;background-color:#E4E8F1; width: 100%;">
        <tr><td></td></tr>
        <tr><td align="center">
            <asp:DropDownList ID="ddlAgent" ClientIDMode="Static" runat="server" AutoPostBack="True" 
                Height="20px" Width="168px">
            </asp:DropDownList>
            </td></tr>
        <tr><td align="center">
            <asp:RequiredFieldValidator ID="RequiredField" ClientIDMode="Static" runat="server" 
                ControlToValidate="ddlAgent" 
                ErrorMessage="Select" Font-Size="Small" ForeColor="Red"></asp:RequiredFieldValidator>
            </td></tr>
        <tr><td align="center">
            <asp:Button ID="btnSend" runat="server" ClientIDMode="Static" Font-Bold="True" 
                Height="22px" Text="Send" 
                Width="69px" onclick="btnSend_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" ClientIDMode="Static" 
                Font-Bold="True" Height="22px" 
                Text="Cancel" Width="71px" ValidationGroup="Cancel" 
                onclick="btnCancel_Click" />
            </td></tr>
        <tr><td align="center">
            <asp:Label ID="lblMessage" runat="server" Text="lblMessge" Visible="false"></asp:Label>
            </td>
            <tr>
                <td>
                </td>
            </tr>
            </tr>
        </table>
    </asp:Panel>
    </td></tr>
</table>
        </center>
</asp:Content>
