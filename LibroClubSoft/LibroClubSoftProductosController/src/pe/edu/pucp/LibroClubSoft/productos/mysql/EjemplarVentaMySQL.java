package pe.edu.pucp.LibroClubSoft.productos.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.productos.dao.EjemplarVentaDAO;
import pe.edu.pucp.LibroClubSoft.productos.model.EjemplarVenta;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;



public class EjemplarVentaMySQL implements EjemplarVentaDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertar(EjemplarVenta obj) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call EJEMPLAR_VENTA_INSERTAR(?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_ejemplar",java.sql.Types.INTEGER);
            cs.setDate("_fecha_ingreso",new java.sql.Date(obj.getFecha_ingreso().getTime()));
            cs.setString("_codigo_serie", obj.getCodigoSerie());
            cs.setInt("_fid_producto", obj.getProducto().getId_producto());
            cs.setInt("_fid_sede",obj.getSede().getId_sede());
            cs.setString("_observacion",obj.getObservacion() );

            resultado = cs.executeUpdate();
            obj.setId_ejemplar(cs.getInt("_id_ejemplar"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
