<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPersona.aspx.cs" Inherits="PruebaDesarrollo.CrearPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Crear Persona</h1>
    </div>

    <div class="row">

        <div class="form-group">
          <label class="control-label col-sm-2" for="textbox_nombre">Nombre</label>
          <div class="col-sm-10">
              <asp:TextBox runat="server" ID="textbox_nombre" CssClass="form-control"/>            
          </div>
        </div>
        <div class="form-group">
          <label class="control-label col-sm-2" for="pwd">Tipo de Idenficacion</label>
          <div class="col-sm-10">       
              <asp:DropDownList runat="server" ID="dropDownList_tipoIdentificacion"  CssClass="form-control">
              </asp:DropDownList>            
          </div>
        </div>
        <div class="form-group">
          <label class="control-label col-sm-2" for="textbox_numeroIdentificacion">Numero Identificacion</label>
          <div class="col-sm-10">
              <asp:TextBox runat="server" ID="textbox_numeroIdentificacion"  CssClass="form-control"/>            
          </div>
        </div>
        <div class="form-group">
          <label class="control-label col-sm-2" for="textbox_nombre">Estado:</label>
          <div class="col-sm-10">
              <asp:CheckBox ID="CheckBox_estado" runat="server"  CssClass="form-check-input"/>  
          </div>
        </div>
        <div class="form-group">        
          <div class="col-sm-offset-2 col-sm-10">
              <asp:Button Text="Crear Persona" runat="server" ID="button_CrearPersona" OnClick="button_CrearPersona_Click" CssClass=".btn-success" />
          </div>
        </div>
        <div class="form-group">        
          <div class="col-sm-offset-2 col-sm-10">
              <asp:Button Text="Cancelar" runat="server" ID="button_Cancelar" OnClick="button_Cancelar_Click"/>
          </div>
        </div>
        <asp:Label Text="" ID="label_mensaje" ForeColor="Red" runat="server" class="control-label col-sm-10"/>
    </div>
</asp:Content>
