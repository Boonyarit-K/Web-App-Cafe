<%@ Page Title="Add Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CafeAdd.aspx.cs" Inherits="WebApp.CafeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="panel panel-default">
                <div class="panel-heading">Menu Form</div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label Text="ชื่อเมนู" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtTitle" placeholder="ชื่อเมนู" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="ขนาด" Font-Bold="true" runat="server" />
                        <asp:DropDownList runat="server" ID="txtSize" CssClass="form-control">
                            <asp:ListItem Text="Size S" Value="S" />
                            <asp:ListItem Text="Size M" Value="M" />
                            <asp:ListItem Text="Size L" Value="L" />
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label Text="ราคา" Font-Bold="true" runat="server" />
                        <asp:TextBox runat="server" ID="txtPrice" placeholder="ราคา" CssClass="form-control" />
                    </div>
                    <asp:Button Text="Submit" runat="server" class="btn btn-primary" ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="return submitClick();" />
                </div>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>

</asp:Content>
