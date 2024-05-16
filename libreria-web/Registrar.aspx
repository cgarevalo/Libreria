<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="libreria_web.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <h2>Registro</h2>
                <label for="txtEmailUser" class="form-label">Email o usuario</label>
                <asp:TextBox ID="txtEmailUser" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
            <a href="Default.aspx" class="btn btn-secondary" >Cancelar</a>
        </div>
    </div>
</asp:Content>
