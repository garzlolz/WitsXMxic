<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrUpdateUser.aspx.cs" Inherits="WitsXMxic_WebFormVersion.CreateOrUpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.13.1/jquery-ui.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">


    <div>
        <h3>
            <asp:Label ID="lblTitle" runat="server"></asp:Label></h3>

        <asp:Label ID="lblId" runat="server"></asp:Label>

        <div>
            <asp:Label ID="lblName" runat="server" Text="姓名:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server"
                ControlToValidate="txtName"
                ErrorMessage="姓名為必填欄位"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblAge" runat="server" Text="年齡:"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="txtAge"
                ErrorMessage="年齡為必填欄位"
                Display="Dynamic">
            </asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="lblBirth" runat="server" Text="生日:"></asp:Label>
            <asp:TextBox ID="txtBirth" runat="server" CssClass="datepicker"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                ControlToValidate="txtBirth"
                ErrorMessage="生日為為必填欄位"
                Display="Dynamic">
            </asp:RequiredFieldValidator>

        </div>
        <div>
            <button class="btn btn-secondary"><a class="nav-link" runat="server" href="~/HankTeams">返回</a></button>
            <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-success" OnClick="btnSave_Click" />
        </div>
    </div>
    <script>
        $(function () {
            $(".datepicker").datepicker({
                dateFormat: 'yy/mm/dd'
            });
        });
    </script>
</asp:Content>

