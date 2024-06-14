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
    public class CDMusicaMySQL : CDMusicaDAO
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public int insertar(CDMusica cd)
        {
            int resultado = 0;
            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CD_MUSICA_INSERTAR";

                cmd.Parameters.Add("_id_producto", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("_titulo", cd.Titulo);
                cmd.Parameters.AddWithValue("_precio", cd.Precio);
                cmd.Parameters.AddWithValue("_fid_clasificador", 0); //Solo prueba
                cmd.Parameters.AddWithValue("_duracion", cd.Duracion);
                cmd.Parameters.AddWithValue("_UPC", cd.UPC);

                resultado = cmd.ExecuteNonQuery();

                cd.ID_Producto = Int32.Parse(cmd.Parameters["_id_producto"].Value.ToString());

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

        public List<CDMusica> lista()
        {
            List<CDMusica> list = new List<CDMusica>();

            try
            {
                conn = DBManager.Instance.Connection;
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CD_MUSICA_LISTAR";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CDMusica cd = new CDMusica();
                    cd.ID_Producto = reader.GetInt32("id_producto");
                    cd.Titulo = reader.GetString("titulo");
                    cd.Precio = reader.GetDouble("precio");
                    cd.StockVenta = reader.GetInt32("stock_venta");
                    cd.StockPrestamo = reader.GetInt32("stock_prestamo");
                    cd.StockDisponiblePrestamo = reader.GetInt32("stock_disponible_prestamo");
                    cd.Duracion = reader.GetInt32("duracion");
                    cd.UPC = reader.GetString("UPC");
                    list.Add(cd);
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
                cmd.CommandText = "CD_MUSICA_ELIMINAR";

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

        public int modificar(int id, CDMusica cd)
        {
            throw new NotImplementedException();
        }
    }
}
