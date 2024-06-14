package pe.edu.pucp.LibroClubSoft.acciones.mysql;

import pe.edu.pucp.LibroClubSoft.acciones.dao.SancionDAO;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import pe.edu.pucp.LibroClubSoft.acciones.model.Prestamo;
import pe.edu.pucp.LibroClubSoft.acciones.model.Sancion;
import pe.edu.pucp.LibroClubSoft.config.DBManager;

public class SancionMySQL implements SancionDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertar(Sancion obj) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call SANCION_INSERTAR(?,?,?,?)}");
            cs.registerOutParameter("_id_sancion",java.sql.Types.INTEGER);

            cs.setString("_descripcion",obj.getDescripcion());
            cs.setInt("_fid_usuario",obj.getCliente().getId_persona());
            cs.setInt("_fid_prestamo",obj.getPrestamo().getId_prestamo());
            
            resultado = cs.executeUpdate();
            obj.setId_sancion(cs.getInt("_id_sancion"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
