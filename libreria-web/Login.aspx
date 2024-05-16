<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="libreria_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fuentePropia{
            color: red;
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <h2>Inicio de sesión</h2>
                <label for="txtEmailUser" class="form-label">Email o usuario</label>
                <asp:TextBox ID="txtEmailUser" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido" CssClass="fuentePropia" ControlToValidate="txtEmailUser" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido" CssClass="fuentePropia" ControlToValidate="txtEmailUser" runat="server" />
            </div>
            <asp:Button ID="btnIngresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" Text="Ingresar" />
            <a href="Default.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>
