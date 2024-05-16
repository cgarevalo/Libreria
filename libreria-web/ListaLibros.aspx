<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ListaLibros.aspx.cs" Inherits="libreria_web.ListaLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h3>Libros</h3>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvLibros" CssClass="table table-dark table-bordered" runat="server"
                AutoGenerateColumns="false" DataKeyNames="ID"
                OnSelectedIndexChanged="dgvLibros_SelectedIndexChanged"
                OnPageIndexChanging="dgvLibros_PageIndexChanging" AllowPaging="true" PageSize="10" >
                <Columns>
                    <asp:BoundField HeaderText="Título" DataField="Titulo" />
                    <asp:BoundField HeaderText="Autor" DataField="Autor" />
                    <asp:BoundField HeaderText="LSBN" DataField="Lsbn" />
                    <asp:BoundField HeaderText="Género" DataField="Genero" />
                    <asp:BoundField HeaderText="Idioma" DataField="Idioma" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍" HeaderText="Seleccionar" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <a href="FormularioAgregarLibro.aspx" class="btn btn-primary">Agregar libro</a>
</asp:Content>
