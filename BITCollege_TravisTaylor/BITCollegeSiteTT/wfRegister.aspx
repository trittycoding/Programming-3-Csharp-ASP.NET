<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BITCollegeSiteTT.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblwfRegisterName" runat="server" Text="Student Name"></asp:Label>
    <fieldset>
        <ul>
            <li><asp:Label ID="lblwfRegisterCourseSelector" runat="server" Text="Course Selector:"></asp:Label></li>
            <li style="height: 56px"><asp:DropDownList runat="server" Height="120px" Width="257px" ID="ddlwfRegisterCourses" AutoPostBack="True"></asp:DropDownList></li>
            <li><asp:Label ID="lblwfRegisterRegistrationNotes" runat="server" Text="Registration Notes:"></asp:Label></li>
            <li style="height: 82px">
                <asp:RequiredFieldValidator ID="rfvwfRegisterNotesRequired" runat="server" ControlToValidate="txtwfRegisterTextbox" ErrorMessage="Notes are a required field for registrations"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtwfRegisterTextbox" runat="server"></asp:TextBox></li>
        </ul>
    </fieldset>
    
    <fieldset>
        <ul>
            <li><asp:LinkButton ID="lbwfRegisterRegisterButton" runat="server" OnClick="lbwfRegisterRegisterButton_Click">Register</asp:LinkButton></li>
            <li><asp:LinkButton ID="lbwfRegisterReturnToListing" runat="server" OnClick="lbwfRegisterReturnToListing_Click" CausesValidation="False" ValidateRequestMode="Disabled">Return To Registration Listing</asp:LinkButton></li>
        </ul>
    </fieldset>
 
    <asp:Label ID="lblwfRegisterErrorMsg" runat="server" Text="Error Message"></asp:Label>
</asp:Content>
