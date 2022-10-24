using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Varela
{
    public partial class DetalleProductos : System.Web.UI.Page
    {

        public Articulo articulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id_articulo = int.Parse(Request.QueryString["id"].ToString());
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
            foreach (Articulo art in lista)
            {
                if (art.id == id_articulo)
                {
                    articulo = art;
                }
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Articulo> carrito = (List<Articulo>)Session["carritoCompra"];
            Articulo aux = new Articulo();
            aux = articulo;
            bool nuevo = true;
            foreach (Articulo art in carrito)
            {
                if (art.codigo == articulo.codigo)
                {
                    art.cantidad += int.Parse(txtCantidad.Text);
                    nuevo = false;
                    break;
                }
            }
            if (nuevo)
            {
                aux.cantidad = int.Parse(txtCantidad.Text);
                carrito.Add(aux);
            }

            Session.Add("carritoCompra", carrito);

        }
    }
}