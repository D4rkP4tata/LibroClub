package pe.edu.pucp.LibroClubSoft.acciones.mysql;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import pe.edu.pucp.LibroClubSoft.acciones.dao.SolicitudPrestamoDAO;
import pe.edu.pucp.LibroClubSoft.acciones.model.SolicitudPrestamo;
import pe.edu.pucp.LibroClubSoft.config.DBManager;

public class SolicitudPrestamoMySQL implements SolicitudPrestamoDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertar(SolicitudPrestamo obj) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call SOLICITUD_PRESTAMO_INSERTARv2(?,?,?)}");
            cs.registerOutParameter("_id_solicitud",java.sql.Types.INTEGER);

            cs.setInt("_fid_usuario",obj.getCliente().getId_persona());
            cs.setInt("_fid_producto",obj.getProducto().getId_producto());

            resultado = cs.executeUpdate();
            obj.setId_solicitud(cs.getInt("_id_solicitud"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
