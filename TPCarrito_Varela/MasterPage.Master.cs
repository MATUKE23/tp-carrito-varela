using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Varela
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        public List<Articulo> ListaArticulos { get; set; }
        public List<Articulo> carrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            carrito = (List<Articulo>)Session["carritoCompra"];

            if (carrito == null)
            {
                carrito = new List<Articulo>();
                Session.Add("carritoCompra", carrito);
            }


        }
    }
}