<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PruebaDesarrollo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Personas</h1>
    </div>


    <div>
        <asp:Button Text="Crear Persona" runat="server" ID="button_crearPersona" CssClass="btn btn-link" OnClick="button_crearPersona_Click"/>
    </div>

    <div class="row">
        <asp:GridView runat="server" ID="gridView_Personas" DataKeyNames="Id" CssClass="table" OnSelectedIndexChanged="gridView_Personas_SelectedIndexChanged" AutoGenerateColumns="false">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                
                <asp:BoundField DataField="TipoIdentificacion" HeaderText="Tipo Identificacion" />
                
                <asp:BoundField DataField="NumeroIdentificacion" HeaderText="Numero Identificacion" />

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>        
    </div>

</asp:Content>
