package pe.edu.pucp.LibroClubSoft.productos.mysql;
//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.productos.dao.EjemplarPrestamoDAO;
import pe.edu.pucp.LibroClubSoft.productos.model.EjemplarPrestamo;


public class EjemplarPrestamoMySQL implements EjemplarPrestamoDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertar(EjemplarPrestamo obj) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call EJEMPLAR_PRESTAMO_INSERTAR(?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_ejemplar",java.sql.Types.INTEGER);
            cs.setDate("_fecha_ingreso",new java.sql.Date(obj.getFecha_ingreso().getTime()));
            cs.setString("_codigo_serie", obj.getCodigoSerie());
            cs.setInt("_fid_producto", obj.getProducto().getId_producto());
            cs.setInt("_fid_sede",obj.getSede().getId_sede());
            
            String estado_prestamo = obj.getEstado_prestamo().toString();
            int id_estado_prestamo;

            switch (estado_prestamo) {
                case "Disponible":
                    id_estado_prestamo = 0;
                    break;
                case "Prestado":
                    id_estado_prestamo = 1;
                    break;
                case "En_transito":
                    id_estado_prestamo = 2;
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_estado_prestamo = -1;
                    break;
            }
            
            String estado_conser = obj.getEstado_conservacion().toString();
            int id_estado_conser;

            switch (estado_conser) {
                case "Nuevo":
                    id_estado_conser = 0;
                    break;
                case "Bueno":
                    id_estado_conser = 1;
                    break;
                case "Desgastado":
                    id_estado_conser = 2;
                    break;
                case "Dañado":
                    id_estado_conser = 3;
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_estado_conser = -1;
                    break;
            }
            
            cs.setInt("_fid_estado_prestamo",id_estado_conser );
            cs.setInt("_fid_estado_conservacion", id_estado_conser);
      
            
            resultado = cs.executeUpdate();
            obj.setId_ejemplar(cs.getInt("_id_ejemplar"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
