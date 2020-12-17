<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Web Application Cafe</h1>
        <p class="lead">Welcome to website application cafe.</p>
        <a  href="~/cafeadd" runat="server"> Click here to add menu!! </a>
        <a  href="~/cafelist" runat="server"> Show menu list</a>
    </div>
    
</asp:Content>
