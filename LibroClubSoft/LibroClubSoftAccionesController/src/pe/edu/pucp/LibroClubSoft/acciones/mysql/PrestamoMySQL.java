package pe.edu.pucp.LibroClubSoft.acciones.mysql;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import pe.edu.pucp.LibroClubSoft.acciones.dao.PrestamoDAO;
import pe.edu.pucp.LibroClubSoft.acciones.model.Prestamo;
import pe.edu.pucp.LibroClubSoft.acciones.model.Venta;
import pe.edu.pucp.LibroClubSoft.config.DBManager;

public class PrestamoMySQL implements PrestamoDAO{
private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertar(Prestamo obj) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call PRESTAMO_INSERTAR(?,?,?,?,?)}");
            cs.registerOutParameter("_id_prestamo",java.sql.Types.INTEGER);

            cs.setInt("_fid_ejemplar_prestamo",obj.getArticulo().getId_ejemplar());
            cs.setInt("_fid_solicitud",obj.getSolicitud().getId_solicitud());
            cs.setInt("_fid_sede",obj.getSede().getId_sede());
            cs.setInt("_fid_personal",obj.getPersonal().getId_persona());
            
            resultado = cs.executeUpdate();
            obj.setId_prestamo(cs.getInt("_id_prestamo"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
