<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Varela.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-2 g-4">

        <%
            foreach (var art in ListaArticulos)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="<%: art.imagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:art.nombre%></h5>
                    <p class="card-text"><%: art.descripcion %></p>
                    <h5 class="card-title"><%:((int)art.precio)%></h5>
                     <a href="DetalleProductos.aspx?id=<%:art.id %>" class="btn btn-success">Ver mas</a>
                    <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Agregar al Carrito" OnClick="Button1_Click" />--%>
                </div>
            </div>
        </div>

        <% }%>
    </div>


</asp:Content>

