using LibroClubController.DAO;
using LibroClubModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Crud.Order.Types;

namespace LibroClubController.MySQL
{
    public class RevistaMySQL : RevistaDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        public int insertar(Revista rev)
        {
            int resultado = 0;
            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "REVISTA_INSERTAR";

                cmd.Parameters.Add("_id_producto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("_titulo", rev.Titulo);
                cmd.Parameters.AddWithValue("_precio", rev.Precio);
                cmd.Parameters.AddWithValue("_stock_venta", rev.StockVenta);
                cmd.Parameters.AddWithValue("_stock_prestamo", rev.StockPrestamo);
                cmd.Parameters.AddWithValue("_stock_disponible_prestamo", rev.StockDisponiblePrestamo);
                cmd.Parameters.AddWithValue("_editor", rev.Editor);
                cmd.Parameters.AddWithValue("_ISSN", rev.ISSN);

                resultado = cmd.ExecuteNonQuery();

                rev.ID_Producto = Int32.Parse(cmd.Parameters["_id_producto"].Value.ToString());

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                try { conn.Close(); } catch (Exception ex) { throw new Exception(ex.Message); }
            }
            return resultado;
        }

        public List<Revista> lista()
        {
            List<Revista> list = new List<Revista>();

            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "REVISTA_LISTAR";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Revista rev = new Revista();
                    rev.ID_Producto = reader.GetInt32("id_producto");
                    rev.Titulo = reader.GetString("titulo");
                    rev.Precio = reader.GetDouble("precio");
                    rev.StockVenta = reader.GetInt32("stock_venta");
                    rev.StockPrestamo = reader.GetInt32("stock_prestamo");
                    rev.StockDisponiblePrestamo = reader.GetInt32("stock_disponible_prestamo");
                    rev.Editor = reader.GetString("editor");
                    rev.ISSN = reader.GetString("ISSN");
                    list.Add(rev);
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
                cmd.CommandText = "REVISTA_ELIMINAR";

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

        public int modificar(int id, Revista rev)
        {
            throw new NotImplementedException();
        }
    }
}
