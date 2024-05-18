<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioAgregarLibro.aspx.cs" Inherits="libreria_web.FormularioAgregarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <label for="txtTitulo" class="form-label">Título</label>
                <asp:TextBox ID="txtTitulo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Título requerido" ControlToValidate="txtTitulo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtAutor" class="form-label">Autor</label>
                <asp:TextBox ID="txtAutor" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Descripción requerida" ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtFechaPublicacion" class="form-label">Fecha de publicación</label>
                <asp:TextBox ID="txtFechaPublicacion" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtGenero" class="form-label">Género</label>
                <asp:DropDownList ID="ddlGenero" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtIdioma" class="form-label">Idioma</label>
                <asp:DropDownList ID="ddlIdioma" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtNumeroPaginas" class="form-label">Número de páginas</label>
                <asp:TextBox ID="txtNumeroPaginas" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revNumeroPaginas" ControlToValidate="txtNumeroPaginas" ValidationExpression="[0-9]+" ErrorMessage="El número de páginas debe ser un número entero." runat="server" />

            </div>
            <div class="mb-3">
                <label for="txtEditorial" class="form-label">Editorial</label>
                <asp:TextBox ID="txtEditorial" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="col-5">

            <div class="mb-3">
                <label for="txtLsbn" class="form-label">Código lsbn</label>
                <asp:TextBox ID="txtLsbn" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:CheckBox ID="chkOrigen" Text="Imagen con url" CssClass="form-check" OnCheckedChanged="chkOrigen_CheckedChanged" AutoPostBack="true" runat="server" />
                    </div>
                    <%if (OrigenImagen)
                        { %>
                    <div id="divUrl" class="mb-3" runat="server">
                        <label for="txtUrlImagen" class="form-label">Pegue la url de la imagen</label>
                        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                    </div>
                    <%  }
                        else
                        { %>
                    <div id="divLocal" class="mb-3" runat="server">
                        <label for="fuImagenPortada" class="form-label">Seleccione la portada</label>
                        <%--<input type="file" id="imgPortada" class="form-control" runat="server" />--%>
                        <asp:FileUpload ID="fuImagenPortada" OnChange="previewImage()" CssClass="form-control" runat="server" />
                    </div>
                    <% }  %>

                    <%--<asp:Image ID="imgCargarPortada" runat="server" Height="450px" Width="350" CssClass="img-fluid mb-3" />--%>
                    <img id="imgPortada" class="img-fluid mb-3" src="#" height="450" width="350" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
            <a href="ListaLibros.aspx" class="btn btn-secondary">Cancelar</a>
            <asp:Button ID="btnDesactivar" CssClass="btn btn-warning" runat="server" Text="Desactivar" OnClick="btnDesactivar_Click" />
        </div>
    </div>

    <%--Javascript--%>
    <script>
        // Función para previsualizar la imagen seleccionada en el control FileUpload antes de cargarla en el servidor
        function previewImage() {
            // Obtiene el control FileUpload y el control Image por sus IDs
            var fileUpload = document.getElementById('<%= fuImagenPortada.ClientID %>');
            var imgPerfil = document.getElementById('<%= imgPortada.ClientID %>');

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
    <%--Jabascript--%>
</asp:Content>
