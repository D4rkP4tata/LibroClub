package pe.edu.pucp.LibroClubSoft.Organizacion.mysql;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;




import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.SedeDAO;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


public class SedeMySQL implements SedeDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public ArrayList<Sede> listar() {
        ArrayList<Sede> sedes = new ArrayList<>();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call SEDE_LISTAR()}");
            rs = cs.executeQuery();
            
            while(rs.next()){
                Sede sede = new Sede();
                sede.setId_sede(rs.getInt("id_sede"));
                sede.setDireccion(rs.getString("direccion"));
                
                sedes.add(sede);
            }
            
            cs.close();
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }
        
        return sedes;
    }

    @Override
    public int insertar(Sede sede) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call SEDE_INSERTAR(?,?)}");
            cs.registerOutParameter("_id_sede",java.sql.Types.INTEGER);
            cs.setString("_direccion",sede.getDireccion());
            
            resultado = cs.executeUpdate();
            sede.setId_sede(cs.getInt("_id_sede"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public int eliminar(int id_sede) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call SEDE_ELIMINAR(?)}");
            cs.setInt("_id_sede",id_sede);
            
            resultado = cs.executeUpdate();
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public int actualizar_direccion(int id_sede, String direccion) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call SEDE_ACTUALIZAR_DIRECCION(?,?)}");
            cs.setInt("_id_sede",id_sede);
            cs.setString("_direccion",direccion);
            
            resultado = cs.executeUpdate();
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

}
