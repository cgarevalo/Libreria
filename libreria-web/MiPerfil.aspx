<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="libreria_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                <label for="inputImagen">Foto de perfíl</label>
                <%--<input id="inputImagen" class="form-control" type="file" onchange="previewImage(event, imgPerfil)" accept="image/*" />--%>
                <asp:FileUpload ID="fuImagenPerfil" OnChange="previewImage()" CssClass="form-control" runat="server" />
            </div>
            <img id="imgPerfil" class="img-fluid m-3" runat="server" src="https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg" alt="" />
            <%--<asp:Image ID="imgPerfil" ImageUrl="https://static.vecteezy.com/system/resources/previews/016/916/479/original/placeholder-icon-design-free-vector.jpg" CssClass="img-fluid m-3" runat="server" />--%>
            <%--<asp:Button ID="btnVer" CssClass="btn btn-secondary" OnClientClick="previewImage(event, #imgPerfil)" OnClick="btnVer_Click" runat="server" Text="Ver foto" />--%>


        </div>


    </div>

    <script>
        // Función para previsualizar la imagen seleccionada en el control FileUpload antes de cargarla en el servidor
        function previewImage() {
            // Obtiene el control FileUpload y el control Image por sus IDs
            var fileUpload = document.getElementById('<%= fuImagenPerfil.ClientID %>');
            var imgPerfil = document.getElementById('<%= imgPerfil.ClientID %>');

            // Verifica si se ha seleccionado un archivo
            if (fileUpload.files && fileUpload.files[0]) {

                // Crea un nuevo FileReader para leer el contenido del archivo
                var reader = new FileReader();

                // Define la función que se ejecuta cuando el archivo se ha leído completamente
                reader.onload = function (e) {

                    // Asigna el contenido leído (URL de la imagen) al control Image para previsualización
                    imgPerfil.src = e.target.result;
                };

                // Lee el contenido del archivo como una URL de datos
                reader.readAsDataURL(fileUpload.files[0]);
            }
        }
    </script>
</asp:Content>
