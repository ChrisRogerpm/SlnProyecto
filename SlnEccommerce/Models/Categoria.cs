using SlnEccommerce.Funciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlnEccommerce.Models
{
    public class Categoria
    {
        string _conexion = string.Empty;
        public Categoria()
        {
            _conexion = ConfigurationManager.ConnectionStrings["ModeloDatos"].ConnectionString;
        }

        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }

        public Categoria CategoriaDetalle(int idCategoria)
        {
            Categoria obj = new Categoria();
            string consulta = @"SELECT [idCategoria]
                                  ,[nombre]
                                  ,[descripcion]
                                  ,[estado]
                              FROM [dbo].[tbl_categoria] where idCategoria = @p0";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarInteger(idCategoria));

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                obj.idCategoria = Utilitarios.ValidarInteger(dr["idCategoria"]);
                                obj.nombre = Utilitarios.ValidarStr(dr["nombre"]);
                                obj.descripcion = Utilitarios.ValidarStr(dr["descripcion"]);
                                obj.estado = Utilitarios.ValidarInteger(dr["estado"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return obj;
        }
        public List<Categoria> CategoriaListar()
        {
            List<Categoria> lista = new List<Categoria>();
            string consulta = @"SELECT [idCategoria]
                                  ,[nombre]
                                  ,[descripcion]
                                  ,[estado]
                              FROM [dbo].[tbl_categoria]";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var obj = new Categoria
                            {
                                idCategoria = Utilitarios.ValidarInteger(dr["idCategoria"]),
                                nombre = Utilitarios.ValidarStr(dr["nombre"]),
                                descripcion= Utilitarios.ValidarStr(dr["descripcion"]),
                                estado = Utilitarios.ValidarInteger(dr["estado"]),
                            };
                            lista.Add(obj);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return lista;
        }

        public bool CategoriaRegistrar(Categoria obj)
        {
            bool respuesta = false;

            string consulta = @"INSERT INTO [dbo].[tbl_categoria]
                                    ([nombre]
                                ,[descripcion]
                                ,[estado])
                            VALUES
                                (@p0,@p1,@p2)";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarStr(obj.nombre));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.descripcion));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarInteger(1));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }
            return respuesta;
        }

        public bool CategoriaEditar(Categoria obj)
        {
            bool respuesta = false;

            string consulta = @"UPDATE [dbo].[tbl_categoria]
                                   SET [nombre] = @p1
                                      ,[descripcion] = @p2
                                      ,[estado] = @p3
                                 WHERE idCategoria = @p0";
            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", Utilitarios.ValidarStr(obj.idCategoria));
                    query.Parameters.AddWithValue("@p1", Utilitarios.ValidarStr(obj.nombre));
                    query.Parameters.AddWithValue("@p2", Utilitarios.ValidarStr(obj.descripcion));
                    query.Parameters.AddWithValue("@p3", Utilitarios.ValidarInteger(obj.estado));
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
            }
            return respuesta;
        }
    }
}