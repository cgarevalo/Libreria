<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="libreria_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Correo</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary mt-3" OnClick="btnAceptar_Click" runat="server" Text="Guardar" />
            </div>
        </div>

        <div class="col-4">
            <div class="mb-3">
                <label for="fuImagenPerfil">Foto de perfíl</label>
                <asp:FileUpload ID="fuImagenPerfil" CssClass="form-control" runat="server" />
            </div>
            <asp:Image ID="imgPerfil" ImageUrl="https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg" CssClass="img-fluid m-3" runat="server" />
            <asp:Button ID="btnVer" CssClass="btn btn-secondary" runat="server" Text="Ver foto" />
        </div>


    </div>

</asp:Content>
