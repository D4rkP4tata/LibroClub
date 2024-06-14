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
    public class LibroMySQL : LibroDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        public int insertar(Libro libro)
        {
            int resultado = 0;
            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LIBRO_INSERTAR";

                cmd.Parameters.Add("_id_producto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("_titulo", libro.Titulo);
                cmd.Parameters.AddWithValue("_precio", libro.Precio);
                cmd.Parameters.AddWithValue("_fid_clasificador", 0); //Solo prueba
                cmd.Parameters.AddWithValue("_autor", libro.Autor);
                cmd.Parameters.AddWithValue("_ISBN", libro.ISBN);
                cmd.Parameters.AddWithValue("_editorial", libro.Editorial);

                resultado = cmd.ExecuteNonQuery();

                libro.ID_Producto = Int32.Parse(cmd.Parameters["_id_producto"].Value.ToString());

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

        public List<Libro> lista()
        {
            List<Libro> list = new List<Libro>();

            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LIBRO_LISTAR";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.ID_Producto = reader.GetInt32("id_producto");
                    libro.Titulo = reader.GetString("titulo");
                    libro.Precio = reader.GetDouble("precio");
                    libro.StockVenta = reader.GetInt32("stock_venta");
                    libro.StockPrestamo = reader.GetInt32("stock_prestamo");
                    libro.StockDisponiblePrestamo = reader.GetInt32("stock_disponible_prestamo");
                    libro.Autor = reader.GetString("autor");
                    libro.ISBN = reader.GetString("ISBN");
                    libro.Editorial = reader.GetString("editorial");
                    list.Add(libro);
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
                cmd.CommandText = "LIBRO_ELIMINAR";

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

        public int modificar(int id, Libro libro)
        {
            throw new NotImplementedException();
        }
    }
}
