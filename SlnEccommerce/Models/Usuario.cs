using SlnEccommerce.Funciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlnEccommerce.Models
{
    public class Usuario
    {
        string _conexion = string.Empty;

        public Usuario()
        {
            _conexion = ConfigurationManager.ConnectionStrings["ModeloDatos"].ConnectionString;
        }

        public int idUsuario { get; set; }
        public string idTipoUsuario { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int estado { get; set; }

        public Usuario UsuarioDetalle(Usuario obj)
        {
            Usuario objUsuario = new Usuario();

            string consulta = @"SELECT [idUsuario]
                                  ,[idTipoUsuario]
                                  ,[email]
                                  ,[password]
                                  ,[estado]
                              FROM [dbo].[tbl_usuario] where email = @p0 and password = @p1";

            try
            {
                using (var con = new SqlConnection(_conexion))
                {
                    con.Open();
                    var query = new SqlCommand(consulta, con);
                    query.Parameters.AddWithValue("@p0", obj.email);
                    query.Parameters.AddWithValue("@p1", obj.password);

                    using (var dr = query.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                objUsuario.idUsuario = Utilitarios.ValidarInteger(dr["idUsuario"]);
                                objUsuario.email = Utilitarios.ValidarStr(dr["email"]);
                                objUsuario.password = Utilitarios.ValidarStr(dr["password"]);
                                objUsuario.estado = Utilitarios.ValidarInteger(dr["estado"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return objUsuario;
        }
    }
}