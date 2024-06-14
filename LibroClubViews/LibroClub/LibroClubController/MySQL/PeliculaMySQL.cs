using LibroClubController.DAO;
using LibroClubModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController.MySQL
{
    public class PeliculaMySQL : PeliculaDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public int insertar(Pelicula pelicula)
        {
            int resultado = 0;
            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PELICULA_INSERTAR";

                cmd.Parameters.Add("_id_producto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("_titulo", pelicula.Titulo);
                cmd.Parameters.AddWithValue("_precio", pelicula.Precio);
                cmd.Parameters.AddWithValue("_fid_clasificador", 0); //Solo prueba
                cmd.Parameters.AddWithValue("_duracion", pelicula.Duracion);
                cmd.Parameters.AddWithValue("_clasificacion", pelicula.Clasificacion);
                cmd.Parameters.AddWithValue("_IMBd_id", pelicula.IMBD);

                resultado = cmd.ExecuteNonQuery();

                pelicula.ID_Producto = Int32.Parse(cmd.Parameters["_id_producto"].Value.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try { conn.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
            }
            return resultado;
        }

        public List<Pelicula> lista()
        {
            List<Pelicula> list = new List<Pelicula>();

            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "PELICULA_LISTAR";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pelicula p = new Pelicula();
                    p.ID_Producto = reader.GetInt32("id_producto");
                    p.Titulo = reader.GetString("titulo");
                    p.Precio = reader.GetDouble("precio");
                    p.StockVenta = reader.GetInt32("stock_venta");
                    p.StockPrestamo = reader.GetInt32("stock_prestamo");
                    p.StockDisponiblePrestamo = reader.GetInt32("stock_disponible_prestamo");
                    p.Duracion = reader.GetInt32("duracion");
                    p.Clasificacion = reader.GetString("clasificacion");
                    p.IMBD = reader.GetString("IMBd_id");
                    list.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try { conn.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
            }
            return list;
        }

        public int eliminar(int id)
        {
            int resultado = 0;
            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PELICULA_ELIMINAR";

                cmd.Parameters.AddWithValue("_id_producto", id);

                resultado = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try { conn.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
            }
            return resultado;
        }

        public int modificar(int id, Pelicula pelicula)
        {
            throw new NotImplementedException();
        }
    }
}
