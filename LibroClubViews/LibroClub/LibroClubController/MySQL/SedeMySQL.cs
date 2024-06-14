using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroClubController.DAO;
using LibroClubModels;

namespace LibroClubController.MySQL
{
	public class SedeMySQL: SedeDAO
	{
		private MySqlConnection con;
		private MySqlCommand comando;
		private MySqlDataReader lector;

		public int insertar(Sede sede)
		{
			int resultado = 0;

			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = "SEDE_INSERTAR";

				comando.Parameters.Add("_id_sede", MySqlDbType.Int32).Direction = ParameterDirection.Output;
				//aqui se especifica que "_id_pelicula" va ser un Int32, para luego asignarlo como un output en el SQL

				comando.Parameters.AddWithValue("_direccion", sede.Direccion);

				resultado = comando.ExecuteNonQuery();

				sede.ID = Int32.Parse(comando.Parameters["_id_sede"].Value.ToString());

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

		public List<Sede> lista()
		{
			List<Sede> sedes = new List<Sede>();

			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = System.Data.CommandType.StoredProcedure;
				comando.CommandText = "SEDE_LISTAR";//name in Script SQL
				lector = comando.ExecuteReader();
				while (lector.Read())
				{
					Sede sede = new Sede();
					sede.ID = lector.GetInt32("id_sede");
					sede.Direccion = lector.GetString("direccion");
					sedes.Add(sede);
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
			return sedes;
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
				comando.CommandText = "SEDE_ELIMINAR";

				comando.Parameters.AddWithValue("_id_sede", id);

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

		public int modificar(int id, String direccion)
		{
			int resultado = 0;
			try
			{
				con = DBManager.Instance.Connection;
				//con.Open();
				comando = new MySqlCommand();
				comando.Connection = con;
				comando.CommandType = CommandType.StoredProcedure;
				comando.CommandText = "SEDE_ACTUALIZAR_DIRECCION";

				comando.Parameters.AddWithValue("_id_sede", id);
				comando.Parameters.AddWithValue("_direccion", direccion);

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

	

