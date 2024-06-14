package pe.edu.pucp.LibroClubSoft.acciones.mysql;

import pe.edu.pucp.LibroClubSoft.acciones.dao.VentaDAO;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.sql.Date;
import pe.edu.pucp.LibroClubSoft.acciones.model.Venta;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;
import pe.edu.pucp.LibroClubSoft.productos.model.EjemplarVenta;
import pe.edu.pucp.LibroClubSoft.productos.model.ProductoMultimedia;

public class VentaMySQL implements VentaDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public int insertarVentaBuscandoEjemplar(Venta venta) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call VENTA_INSERTAR_BUSCA_EJEMPLAR(?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_venta",java.sql.Types.INTEGER);

            cs.setInt("_fid_usuario",venta.getCliente().getId_persona());
            cs.setInt("_fid_sede",venta.getSede().getId_sede());
            cs.setInt("_fid_personal",venta.getVendedor().getId_persona());
            cs.setDouble("_subtotal", venta.getSubtotal());
            cs.setDouble("_total", venta.getTotal());
            cs.setDouble("_descuento", venta.getDescuento());
            int id= venta.getArticulo().getProducto().getId_producto();
            cs.setInt("_fid_producto", venta.getArticulo().getProducto().getId_producto());
            
            resultado = cs.executeUpdate();
            venta.setId_venta(cs.getInt("_id_venta"));
            resultado=1;
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @Override
    public ArrayList<Venta> listar(int id) {
        ArrayList<Venta> ventas =  new ArrayList<>();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VENTA_LISTAR(?)}");
            cs.setInt("_id_sede",id);
            rs = cs.executeQuery();
            while(rs.next()){
                Venta venta = new Venta();
                venta.setId_venta(rs.getInt("id_venta"));
                venta.setSubtotal(rs.getDouble("subtotal"));
                venta.setDescuento(rs.getDouble("descuento_membresia"));
                venta.setTotal(rs.getDouble("total"));
                venta.setFecha(rs.getDate("fecha"));
                venta.setCliente(new Usuario());
                venta.getCliente().setId_persona(rs.getInt("fid_usuario"));
                venta.getCliente().setNombre(rs.getString("nombre_usuario"));
                venta.getCliente().setDni(rs.getString("dni"));
                
                venta.setArticulo(new EjemplarVenta() );
                venta.getArticulo().setId_ejemplar(rs.getInt("fid_ejemplar_venta"));
                venta.getArticulo().setCodigoSerie(rs.getString("codigo_serie"));
                
                venta.getArticulo().setProducto(new ProductoMultimedia());
                venta.getArticulo().getProducto().setNombre(rs.getString("nombre_producto"));
                
                Sede sede = new Sede();
                sede.setId_sede(rs.getInt("fid_sede"));
                sede.setDireccion(rs.getString("nombre_sede"));
                venta.setSede(sede);

                Personal vendedor = new Personal();
                vendedor.setId_persona(rs.getInt("fid_personal"));
                vendedor.setNombre(rs.getString("nombre_personal"));
                venta.setVendedor(vendedor);
                ventas.add(venta);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return ventas;
    }
    
    
    @Override
    public Venta buscarPorID(int id){
        Venta venta= new Venta();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VENTA_BUSCAR_ID(?)}");
            cs.setInt("_id_venta",id);
            rs = cs.executeQuery();
            
            while(rs.next()){
                venta.setSubtotal(rs.getDouble("subtotal"));
                venta.setDescuento(rs.getDouble("descuento_membresia"));
                venta.setTotal(rs.getDouble("total"));
                venta.setFecha(rs.getDate("fecha"));
                venta.setCliente(new Usuario());
                venta.getCliente().setId_persona(rs.getInt("fid_usuario"));
                venta.getCliente().setNombre(rs.getString("nombre_usuario"));
                venta.getCliente().setDni(rs.getString("dni"));

                venta.setArticulo(new EjemplarVenta() );
                venta.getArticulo().setId_ejemplar(rs.getInt("fid_ejemplar_venta"));
                venta.getArticulo().setCodigoSerie(rs.getString("codigo_serie"));

                venta.getArticulo().setProducto(new ProductoMultimedia());
                venta.getArticulo().getProducto().setId_producto(rs.getInt("id_producto"));
                venta.getArticulo().getProducto().setNombre(rs.getString("nombre_producto"));

                Sede sede = new Sede();
                sede.setId_sede(rs.getInt("fid_sede"));
                sede.setDireccion(rs.getString("nombre_sede"));
                venta.setSede(sede);

                Personal vendedor = new Personal();
                vendedor.setId_persona(rs.getInt("fid_personal"));
                vendedor.setNombre(rs.getString("nombre_personal"));
                venta.setVendedor(vendedor);
            }    
            
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return venta;
    }
    public int eliminar(int id){
        int resultado=0;
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VENTA_ELIMINAR(?)}");
            cs.setInt("_id_venta",id);
            resultado = cs.executeUpdate();
            
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    
    @Override
    public int modificarVentaIgualProducto(Venta venta){
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call VENTA_MODIFICAR_IGUAL_PRODUCTO(?,?,?,?,?,?)}");
            cs.setInt("_id_venta", venta.getId_venta());
            cs.setInt("_fid_usuario",venta.getCliente().getId_persona());
            cs.setInt("_fid_sede",venta.getSede().getId_sede());
            cs.setDouble("_total", venta.getTotal());
            cs.setDouble("_subtotal", venta.getSubtotal());
            cs.setDouble("_descuento", venta.getDescuento());
            resultado = cs.executeUpdate();
            cs.close();
            resultado=1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @Override
    public int modificarVentaDiferenteProducto(Venta venta){
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call VENTA_MODIFICAR_DIFERENTE_PRODUCTO(?,?,?,?,?,?,?)}");
            
            cs.setInt("_id_venta", venta.getId_venta());
            cs.setInt("_fid_usuario",venta.getCliente().getId_persona());
            cs.setInt("_fid_sede",venta.getSede().getId_sede());
            cs.setDouble("_subtotal", venta.getSubtotal());
            cs.setDouble("_total", venta.getTotal());
            cs.setDouble("_descuento", venta.getDescuento());
            int id= venta.getArticulo().getProducto().getId_producto();
            cs.setInt("_fid_producto", venta.getArticulo().getProducto().getId_producto());
            
            resultado = cs.executeUpdate();
            resultado=1;
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    
    public ArrayList<Venta> listarBusqueda(int id_sede, String dni, String fecha_desde, String fecha_hasta){
        ArrayList<Venta> ventas =  new ArrayList<>();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VENTA_LISTAR_BUSCAR(?,?,?,?)}");
            cs.setInt("_id_sede",id_sede);
            cs.setString("_dni",dni);
            
            if(fecha_desde.length()==0 && fecha_hasta.length()==0){
                cs.setNull("_fecha_desde",java.sql.Types.DATE );
                cs.setNull("_fecha_hasta",java.sql.Types.DATE );
            }
            else{
                cs.setDate("_fecha_desde", Date.valueOf(fecha_desde));
                cs.setDate("_fecha_hasta", Date.valueOf(fecha_hasta));
            }
            rs = cs.executeQuery();
            while(rs.next()){
                Venta venta = new Venta();
                venta.setId_venta(rs.getInt("id_venta"));
                venta.setSubtotal(rs.getDouble("subtotal"));
                venta.setDescuento(rs.getDouble("descuento_membresia"));
                venta.setTotal(rs.getDouble("total"));
                venta.setFecha(rs.getDate("fecha"));
                venta.setCliente(new Usuario());
                venta.getCliente().setId_persona(rs.getInt("fid_usuario"));
                venta.getCliente().setNombre(rs.getString("nombre_usuario"));
                venta.getCliente().setDni(rs.getString("dni"));
                
                venta.setArticulo(new EjemplarVenta() );
                venta.getArticulo().setId_ejemplar(rs.getInt("fid_ejemplar_venta"));
                venta.getArticulo().setCodigoSerie(rs.getString("codigo_serie"));
                
                venta.getArticulo().setProducto(new ProductoMultimedia());
                venta.getArticulo().getProducto().setNombre(rs.getString("nombre_producto"));
                
                Sede sede = new Sede();
                sede.setId_sede(rs.getInt("fid_sede"));
                sede.setDireccion(rs.getString("nombre_sede"));
                venta.setSede(sede);

                Personal vendedor = new Personal();
                vendedor.setId_persona(rs.getInt("fid_personal"));
                vendedor.setNombre(rs.getString("nombre_personal"));
                venta.setVendedor(vendedor);
                ventas.add(venta);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return ventas;
    }
}



