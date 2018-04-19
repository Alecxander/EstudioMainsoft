<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginWebService.aspx.cs" Inherits="WebFormWithSomee.LoginWebService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <input type="text" id="usuario" class="form-control" placeholder="Usuario WebService" name="name" value="" runat="server" />
        <input type="password" id="password" class="form-control" placeholder="Password WebService" name="name" value="" runat="server" />
        <asp:Label Text="" ID="mensaje_label" runat="server" /><br/>
        <asp:Button Text="Login"  runat="server" ID="login_button" OnClick="login_button_Click" />
    </div>
    <div class="form-group">
        <input type="text" id="token_input" class="form-control" placeholder="Token WebService" name="name" value="" runat="server" />
        <asp:Label Text="" ID="mensaje_token_label" runat="server" /><br/>
        <asp:Button Text="Validar Token"  runat="server" ID="token_button" OnClick="token_button_Click" />
    </div>
</asp:Content>
