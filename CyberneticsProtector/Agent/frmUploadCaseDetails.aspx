<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMaster.Master" AutoEventWireup="true" CodeBehind="frmUploadCaseDetails.aspx.cs" Inherits="CyberneticsProtector.Agent.frmUploadCaseDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center></center>
<center></center>
<center>
    <asp:GridView ID="gvCaseFromAgency" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal" onrowcommand="gvCaseFromAgency_RowCommand" 
        >
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
</asp:Content>
