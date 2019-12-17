<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfDrop.aspx.cs" Inherits="BITCollegeSiteTT.wfDrop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="dtvwfDrop" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="283px" OnPageIndexChanging="dtvwfDrop_PageIndexChanging" Width="387px" AutoGenerateRows="False">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="RegistrationNumber" HeaderText="Registration" />
            <asp:BoundField DataField="Student.FullName" HeaderText="Student" />
            <asp:BoundField DataField="Course.Title" HeaderText="Course" />
            <asp:BoundField DataField="RegistrationDate" DataFormatString="{0:d}" HeaderText="Date" />
            <asp:BoundField DataField="Grade" DataFormatString="{0:p}" HeaderText="Grade" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <asp:LinkButton ID="lbwfDropDropCourse" runat="server" Enabled="False" OnClick="lbwfDropDropCourse_Click">Drop Course</asp:LinkButton>
    <asp:LinkButton ID="lbwfDropReturnRegistrationListing" runat="server" OnClick="lbwfDropReturnRegistrationListing_Click">Return to Registration Listing</asp:LinkButton>
    <asp:Label ID="lblwfDropErrorMsg" runat="server" Text="[PlaceHolder Text]" Visible="False"></asp:Label>
</asp:Content>
