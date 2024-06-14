using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroClubController.DAO;
using LibroClubModels;
using static Mysqlx.Crud.Order.Types;

namespace LibroClubController.MySQL
{
	public class UsuarioMySQL: UsuarioDAO
	{
		private MySqlConnection con;
		private MySqlCommand comando;
		private MySqlDataReader lector;
		public int insertar(Usuario usuario)
		{
			int resultado = 0;

			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = "USUARIO_INSERTAR";

				comando.Parameters.Add("_id_persona", MySqlDbType.Int32).Direction = ParameterDirection.Output;
				//aqui se especifica que "_id_pelicula" va ser un Int32, para luego asignarlo como un output en el SQL

				comando.Parameters.AddWithValue("_dni", usuario.DNI);
				comando.Parameters.AddWithValue("_nombre", usuario.Nombre);
				comando.Parameters.AddWithValue("_fecha_nacimiento", usuario.Fecha_Nacimiento);
				comando.Parameters.AddWithValue("_genero", usuario.Genero);
				comando.Parameters.AddWithValue("_telefono", usuario.Telefono);
				comando.Parameters.AddWithValue("_fid_tipo_membresia", usuario.Id_Membresia);

				resultado = comando.ExecuteNonQuery();

				usuario.ID_Usuario = Int32.Parse(comando.Parameters["_id_persona"].Value.ToString());

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				try { con.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
			}
			return resultado;
		}

		public List<Usuario> listar()
		{
			List<Usuario> usuarios = new List<Usuario>();

			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = System.Data.CommandType.StoredProcedure;
				comando.CommandText = "USUARIO_LISTAR";//name in Script SQL
				lector = comando.ExecuteReader();
				while (lector.Read())
				{
					Usuario usuario = new Usuario();
					usuario.ID_Usuario = lector.GetInt32("id_usuario");

					usuario.Persona = new Persona();
					usuario.Persona.DNI = lector.GetString("dni");
					usuario.Persona.Nombre = lector.GetString("nombre");
					usuario.Persona.Fecha_Nacimiento = lector.GetDateTime("fecha_nacimiento");
					usuario.Persona.Genero = lector.GetChar("genero");
					usuario.Persona.Telefono = lector.GetInt32("telefono");
					
					usuario.TipoMembresia = new TipoMembresia();
					usuario.TipoMembresia.Nombre = lector.GetString("tipo_membresia");

					usuarios.Add(usuario);
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				try { con.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
			}
			return usuarios;
		}

		public int eliminar(int id)
		{
			int resultado = 0;
			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = "USUARIO_ELIMINAR";

				comando.Parameters.AddWithValue("_id_persona", id);

				resultado = comando.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				try { con.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
			}
			return resultado;
		}

		public int modificar(int id, String dni, String nombre, DateTime fecha_nacimiento,
			char genero, int telefono, int tipo_membresia)
		{
			int resultado = 0;
			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = "USUARIO_MODIFICAR";

				comando.Parameters.AddWithValue("_id_persona", id);
				comando.Parameters.AddWithValue("_dni", dni);
				comando.Parameters.AddWithValue("_nombre", nombre);
				comando.Parameters.AddWithValue("_fecha_nacimiento", fecha_nacimiento);
				comando.Parameters.AddWithValue("_genero", genero);
				comando.Parameters.AddWithValue("_telefono", telefono);
				comando.Parameters.AddWithValue("_fid_tipo_membresia", tipo_membresia);

				resultado = comando.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				try { con.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
			}
			return resultado;
		}
	}
}
