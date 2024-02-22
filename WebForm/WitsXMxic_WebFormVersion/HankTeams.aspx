<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HankTeams.aspx.cs" Inherits="WitsXMxic_WebFormVersion.HankTeams" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>團員列表</h1>
        <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ControlStyle-CssClass="align-middle" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="姓名" ControlStyle-CssClass="align-middle" />
                <asp:BoundField DataField="Age" HeaderText="年齡" ControlStyle-CssClass="align-middle" />
                <asp:BoundField DataField="Birth" HeaderText="生日" ControlStyle-CssClass="align-middle" />
                <asp:TemplateField HeaderText="動作">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="編輯" CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                        <asp:Button ID="btnDelete" runat="server" Text="刪除" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
