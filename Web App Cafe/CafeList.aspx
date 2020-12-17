<%@ Page Title="Menu List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CafeList.aspx.cs" Inherits="WebApp.CafeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <div class="col" style="padding-top:20px">
                <asp:GridView ID="gvCafe" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="รหัสเมนู" />
                        <asp:BoundField DataField="Menu" HeaderText="ชื่อเมนู" />
                        <asp:BoundField DataField="Size" HeaderText="ขนาด(S-M-L)" />
                        <asp:BoundField DataField="Price" HeaderText="ราคา" />
                        <asp:TemplateField HeaderText="แก้ไข">
                            <ItemTemplate>
                                <asp:Button
                                    CssClass="btn btn-primary"
                                    OnClick="btnEdit_Click"
                                    Text="Edit"
                                    ID="btnEdit"
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ลบ">
                            <ItemTemplate>
                                <asp:Button
                                    CssClass="btn btn-danger"
                                    OnClientClick="return confirm('คุณต้องการลบข้อมูลนี้ในรายการจริงหรือไม่?');"
                                    OnClick="btnDelete_Click"
                                    Text="Delete"
                                    ID="btnDelete"
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
