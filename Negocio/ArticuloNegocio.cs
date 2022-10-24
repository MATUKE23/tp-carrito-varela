using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT a.Id as id, Codigo, Nombre, a.Descripcion dart, c.descripcion  categoria , m.descripcion  Marca, ImagenUrl, Precio, c.Id IdCategoria, m.Id IdMarca from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdCategoria = c.Id and a.IdMarca = m.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.descripcion = (string)lector["dart"];
                    aux.nombre = (string)lector["Nombre"];



                    if (!(lector["imagenUrl"] is DBNull))  // control de nulidad
                        aux.imagenUrl = (string)lector["imagenUrl"];
                    aux.precio = (decimal)lector["precio"];

                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)lector["IdCategoria"];
                    aux.categoria.descripcion = (string)lector["categoria"];

                    aux.marca = new Marca();
                    aux.marca.id = (int)lector["IdMarca"];
                    aux.marca.descripcion = (string)lector["Marca"];

                    lista.Add(aux);

                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Articulo> listado()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("SELECT a.Id as id, Codigo, Nombre, a.Descripcion dart, c.descripcion  categoria , m.descripcion  Marca, ImagenUrl, Precio " +
                    "from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdCategoria = c.Id and a.IdMarca = m.Id ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.descripcion = (string)datos.Lector["dart"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Articulo nuevo)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS ( Codigo, Nombre, Descripcion,ImagenUrl, precio, idMarca, idCategoria) values (" + nuevo.codigo + ",'" + nuevo.nombre + "','" + nuevo.descripcion + "','" + nuevo.imagenUrl + "','" + nuevo.precio + "', @idMarca, @idCategoria) ");
                datos.setearParametro("@idMarca", nuevo.marca.id);
                datos.setearParametro("@idCategoria", nuevo.categoria.id);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();

            }

        }

        public void Modificar(Articulo ArtChange)
        {
            AccesoaDatos datos = new AccesoaDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo,Nombre=@nombre,Descripcion=@descripcion, IdCategoria=@IdCat,IdMarca=@IdMarca,ImagenUrl=@ImagenUrl,Precio=@precio where id=@id");
                datos.setearParametro("@codigo", ArtChange.codigo);
                datos.setearParametro("@nombre", ArtChange.nombre);
                datos.setearParametro("@descripcion", ArtChange.descripcion);
                datos.setearParametro("@IdCat", ArtChange.categoria.id);
                datos.setearParametro("IdMarca", ArtChange.marca.id);
                datos.setearParametro("@ImagenUrl", ArtChange.imagenUrl);
                datos.setearParametro("@precio", ArtChange.precio);
                datos.setearParametro("@id", ArtChange.id);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();

            }

        }


        public void eliminar(int id)
        {
            try
            {
                AccesoaDatos datos = new AccesoaDatos();
                datos.setearConsulta("delete from ARTICULOS where id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }

        }
        public Articulo buscarArtCodigo(string codigo)// Si no encuentra la búsqueda, devuelve id = -1
        {
            Articulo aux = new Articulo();
            AccesoaDatos datos = new AccesoaDatos();
            try
            {
                datos.setearConsulta("SELECT a.Id as id, Codigo, Nombre, a.Descripcion dart, c.Id IdCategoria, c.descripcion  categoria ,m.Id IdMarca, m.descripcion  Marca, ImagenUrl, Precio " +
                    "from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdCategoria = c.Id and a.IdMarca = m.Id AND codigo =" + "'" + codigo + "'");
                /* datos.setearConsulta("select Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria c.descripcion, ImagenUrl, Precio " +
                 "FROM ARTICULOS where codigo = " + "'" + codigo + "'");*/

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["dart"];
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["categoria"];
                    aux.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                }
                else
                {
                    aux.id = -1;
                }

                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> buscarPorCriterio(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoaDatos datos = new AccesoaDatos();

            string consulta = "SELECT a.Id as id, Codigo, Nombre, a.Descripcion Dart, c.descripcion  Categoria , m.descripcion  Marca, ImagenUrl, Precio " +
                    "from ARTICULOS a, CATEGORIAS c, MARCAS m where a.IdCategoria = c.Id and a.IdMarca = m.Id AND ";
            try
            {
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " Precio > " + filtro;
                            break;

                        case "Menor a":
                            consulta += " Precio < " + filtro;
                            break;

                        case "Igual a":
                            consulta += " Precio = " + filtro;
                            break;

                    }


                }
                else if (campo == "Descripcion")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Descripcion like '" + filtro + "%'";
                            break;

                        case "Termina con":
                            consulta += "a.Descripcion like '%" + filtro + "'";
                            break;

                        case "Contiene":
                            consulta += "a.Descripcion like'%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += campo + " like '" + filtro + "%'";
                            break;

                        case "Termina con":
                            consulta += campo + " like '%" + filtro + "'";
                            break;

                        case "Contiene":
                            consulta += campo + " like '%" + filtro + "%'";
                            break;
                    }
                }


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.descripcion = (string)datos.Lector["Dart"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.imagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }


}

