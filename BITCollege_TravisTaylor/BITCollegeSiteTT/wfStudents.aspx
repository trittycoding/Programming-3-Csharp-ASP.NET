<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfStudents.aspx.cs" Inherits="BITCollegeSiteTT.wfStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblwfStudentsStudentName" runat="server" Text="[Placeholder Student]"></asp:Label>
<asp:GridView ID="dgvwfStudents" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" Height="303px" Width="754px" OnSelectedIndexChanged="dgvwfStudents_SelectedIndexChanged" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
        <asp:BoundField DataField="Course.CourseNumber" HeaderText="Course" >
        <ItemStyle Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="Course.Title" HeaderText="Title" >
        <ItemStyle Width="300px" />
        </asp:BoundField>
        <asp:BoundField DataField="Course.CreditHours" HeaderText="Credit Hours" >
        <ItemStyle HorizontalAlign="Center" Width="50px" />
        </asp:BoundField>
        <asp:BoundField DataField="Course.CourseType" HeaderText="Course Type" >
        <ItemStyle Width="100px" />
        </asp:BoundField>
        <asp:BoundField DataField="Course.TuitionAmount" HeaderText="Tuition" DataFormatString="{0:C}" >
        <ItemStyle HorizontalAlign="Right" Width="100px" />
        </asp:BoundField>
    </Columns>
    <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#808080" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>
<asp:LinkButton ID="lbwfStudentsRegisterCourse" runat="server" OnClick="lbwfStudentsRegisterCourse_Click">Click Here to Register For a Course</asp:LinkButton>
<asp:Label ID="lblwfStudentsErrorMsg" runat="server" Text="Error!" Visible="False"></asp:Label>
</asp:Content>
