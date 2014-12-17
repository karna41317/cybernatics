<%@ Page Title="" Language="C#" MasterPageFile="~/Defense/DefenseMaster.Master" AutoEventWireup="true" CodeBehind="frmAcceptAgency.aspx.cs" Inherits="CyberneticsProtector.Defense.frmAcceptAgency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<center>
    <asp:GridView ID="gvAgency" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal" onrowcommand="gvAgency_RowCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
    <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("Name")%>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("EmailId")%>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("Address")%>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("ContactNo")%>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("DateOfBirth")%>
    </ItemTemplate>
    </asp:TemplateField>
      <asp:TemplateField HeaderText="Name">
    <ItemTemplate>
    <%#Eval("DateOfRegistration")%>
    </ItemTemplate>
    </asp:TemplateField>
     <asp:TemplateField HeaderText="Accept Here">
    <ItemTemplate>
        <asp:LinkButton ID="lnkAccept" CommandName="Accept" CommandArgument=' <%#Eval("UserId")%>' runat="server">Accept</asp:LinkButton>
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
