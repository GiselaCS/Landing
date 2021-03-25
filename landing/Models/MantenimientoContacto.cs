using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace landing.Models
{
    public class MantenimientoContacto
    {
        private SqlConnection con;
        private void conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(Contacto conta)//Crea los elementos
        {
            conectar();
            // SqlCommand comando = new SqlCommand("insert into ESUsuarios (usu_documento, usu_tipodoc, usu_nombre, usu_celular, usu_email, usu_genero,usu_aprendiz,usu_egresado,usu_areaformacion,usu_fechaegresado,usu_direccion,usu_barrio,usu_ciudad,usu_departamento,usu_fecharegistro) values(@usu_documento,@usu_tipodoc,@usu_nombre,@usu_celular,@usu_email,@usu_genero,@usu_aprendiz,@usu_egresado,@usu_areaformacion,@usu_fechaegresado,@usu_direccion,@usu_barrio,@usu_ciudad,@usu_departamento,@usu_fecharegistro)", con);
            SqlCommand comando = new SqlCommand("insert into contacto (nombre, apellido, correo, comentario)values(@Nombre,@Apellido,@Correo,@Comentario)", con);

            //es para especificar que tipo de dato es.
           
           
            comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            
            comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@Correo", SqlDbType.VarChar);
            comando.Parameters.Add("@Comentario", SqlDbType.VarChar);
            

            //lee y modifica los datos.

            //comando.Parameters["@usu_id"].Value = usu.Id;
            comando.Parameters["@Nombre"].Value = conta.Nombre;
            comando.Parameters["@Apellido"].Value = conta.Apellido;
            comando.Parameters["@Correo"].Value = conta.Correo;
            comando.Parameters["@Comentario"].Value = conta.Comentario;
            

            con.Open();//abre la conexion
            int i = comando.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            con.Close();//cierra la conexion
            return i;//retorna cuantas filas se afectaron 

        }
        public List<Contacto> RecuperarTodos()//nos trae lo que estan en la base de datos.
        {
            conectar();//abre la conexion.
            List<Contacto> conta = new List<Contacto>();
            SqlCommand com = new SqlCommand("select nombre, apellido, correo, comentario  from contacto order by nombre asc", con);

            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())//muestra los registros por linea, uno por uno.
            {
                Contacto dat = new Contacto
                {
                    
                    Nombre = registros["nombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    Correo = registros["correo"].ToString(),
                    Comentario = registros["comentario"].ToString()

                };
                conta.Add(dat);


            }
            con.Close();
            return conta;
        }
        

    }
}