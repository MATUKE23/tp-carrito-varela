using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Código")]
        public string codigo { get; set; }

        [DisplayNameAttribute("Nombre")]
        public string nombre { get; set; }

        [DisplayNameAttribute("Descripción")]
        public string descripcion { get; set; }

        [DisplayNameAttribute("Marca")]
        public Marca marca { get; set; }

        [DisplayNameAttribute("Categoría")]
        public Categoria categoria { get; set; }

        [DisplayNameAttribute("Imagen Obtenida de URL")]

        public string imagenUrl { get; set; }

        [DisplayNameAttribute("Precio")]
        public decimal precio { get; set; }

        [DisplayNameAttribute("CANTIDAD")]
        public int cantidad { get; set; }

        public Articulo()
        {
            marca = new Marca();
            categoria = new Categoria();
        }

    }

    /*
    public class ArticuloNegocio
    {
        public List<Articulo> listar() 
        {
            List<Articulo> lista = new List<Articulo>();
            lista.Add(new Articulo()); //agrego dos instancia de articulo
            lista.Add(new Articulo());

            lista[0].id = 1;
            lista[0].codigo = "11111";
            lista[0].nombre = "Xiami Redmi Note 11";
            lista[0].descripcion = "Xiaomi Redmi Note 11 Pro 5G (Snapdragon) Dual SIM 128 GB gris grafito 6 GB RAM $118.100 zzz";
            lista[0].marca.descripcion = "Xiaomi";
            //lista[0].categoria = true;
            lista[0].imagenUrl = "data:image/jpeg;base64,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\" class=\"card-img-top\" alt=\"No Disponible";

            lista[1].id = 2;
            lista[1].codigo = "22222";
            lista[1].nombre = "Xiaomi Redmi Note 10 Pro";
            lista[1].descripcion = "Xiaomi Redmi Note 10 Pro Dual SIM 128 GB wave blue 8 GB RAM $138.100";
            lista[1].marca.descripcion = "Xiaomi";
            //lista[0].categoria = true;
            lista[1].imagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0ztbs3SgdwNMcCjjTGkTmwXrpuB0JOnerrg&usqp=CAU";

            return lista;

        }


    }
    */

}
