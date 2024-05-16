<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="libreria_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor1" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenPortada") %>" class="card-img-top" height="500px" />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Titulo") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="#">Ver detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
