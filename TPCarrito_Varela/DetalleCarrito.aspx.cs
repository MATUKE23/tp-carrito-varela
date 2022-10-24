using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCarrito_Varela
{
    public partial class DetalleCarrito : System.Web.UI.Page
    {

        public List<Articulo> carrito { get; set; }
        
        //public Articulo articulo { get; set; }
        
        public decimal total { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<Articulo>)Session["carritoCompra"];
            EjecutarAccion();

            total = 0;
            foreach (Articulo aux in carrito)
            {
                total += (aux.cantidad * aux.precio);
            }




            /*int id_articulo = int.Parse(Request.QueryString["id"].ToString());
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
            foreach (Articulo art in lista)
            {
                if (art.id == id_articulo)
                {
                    articulo = art;
                }
            }


                          

                carrito = (List<Articulo>)Session["CarritoCompra"];
                EjecutarAccion();

                total = 0;
                foreach (Articulo aux in carrito)
                {
                    total += (aux.cantidad * aux.precio);
                }
            */



        }

        private void EjecutarAccion()
        {


            int cont;
            string accion;
            if (Request.QueryString["contador"] != null)
            {
                cont = int.Parse(Request.QueryString["contador"].ToString());
                accion = Request.QueryString["accion"].ToString();

                switch (accion)
                {
                    case "agregar":
                        carrito[cont].cantidad++;
                        break;

                    case "quitar":
                        if (carrito[cont].cantidad > 1)
                        {
                            carrito[cont].cantidad--;
                        }
                        else
                        {
                            carrito.RemoveAt(cont);
                        }
                        break;
                    case "quitarTodo":
                        carrito.RemoveAt(cont);
                        break;
                }

                Session.Add("CarritoCompra", carrito);
                Response.Redirect("DetalleCarrito.aspx");
            }
        }

        protected void VaciarCarrito(object sender, EventArgs e)
        {
            carrito.Clear();
            Session.Add("carritoCompra", carrito);
            Response.Redirect("DetalleCarrito.aspx");
        }

      
    }
}