<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjemploDePrueba._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:Label Text="Servicio saludar: " runat="server" /><br />
            <asp:TextBox ID="texBox_Saludo" runat="server" Width="851px" />
        </h1>
        <asp:Button ID="button_EjecutarServicio" Text="Ejecutar Servicio" runat="server" OnClick="button_EjecutarServicio_Click" />
        
        <asp:GridView ID="GridView1" runat="server" CssClass="table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hdn_Id" runat="server" />
        <asp:Label Text="Nombre" runat="server" />
        <asp:TextBox runat="server" ID="textBox_nombre" Height="31px"  CssClass="form-control"  />
        <asp:Label Text="Precio" runat="server" />
        <asp:TextBox runat="server" ID ="textBox_precio" Height="29px" CssClass="form-control"  />
        <asp:Button Text="Actualizar" runat="server" ID="button_Actualizar" OnClick="button_Actualizar_Click" />
        <asp:Button Text="Cancelar" runat="server" ID="button_Cancelar" OnClick="button_Cancelar_Click" />

        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <
</asp:Content>
