using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Dominio;
using Negocio;

namespace TPCarrito_Varela
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Articulo> ListaArticulos { get; set; } // creo una propiedad del tipo listaArticulos para la lectura dela base de datos de los articulos y mostrarlos

        //public Articulo articulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar(); //con esto listo los productos que estan en la base

             Session.Add("ListaArticulos", ListaArticulos);

        }
        /*
        protected void Button1_Click(object sender, EventArgs e)
        {
                    
            List<Articulo> ListaArticulos = (List<Articulo>)Session["CarritoCompra"];
            Articulo aux = new Articulo();
            aux = articulo;
            bool nuevo = true;
            ListaArticulos.Add(aux);

          
                       

            foreach (Articulo art in ListaArticulos)
            {
                if (art.codigo == articulo.codigo)
                {
                    art.cantidad++; //= int.Parse(txtCantidad.Text);
                    nuevo = false;
                    break;
                }
            }

       
            if (nuevo)
            {
                //aux.cantidad = int.Parse(txtCantidad.Text);
                ListaArticulos.Add(aux);
            }
           
            Session.Add("CarritoCompra", ListaArticulos);

            

        }*/

    }
}