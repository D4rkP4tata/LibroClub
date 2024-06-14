/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.productos.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.productos.dao.ProductoDAO;
import pe.edu.pucp.LibroClubSoft.productos.model.ProductoMultimedia;
import pe.edu.pucp.LibroClubSoft.productos.model.TipoProducto;

/**
 *
 * @author danie
 */
public class ProductoMySQL implements ProductoDAO{
    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    
    @Override
    public ProductoMultimedia buscarPorID(int id){
        ProductoMultimedia producto= new ProductoMultimedia();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PRODUCTO_BUSCAR_ID_DANIEL(?)}");
            cs.setInt("_id_producto",id);
            rs = cs.executeQuery();
            
            while(rs.next()){
                producto.setId_producto(rs.getInt("id_producto"));
                producto.setNombre(rs.getString("titulo"));
                producto.setPrecio(rs.getDouble("precio"));
                producto.setClasificador(rs.getString("clasificador"));
                producto.setTipoProducto(TipoProducto.valueOf(rs.getString("tipo_producto")));
            }    
            
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return producto;
    }
    
    
    @Override
    public ArrayList<ProductoMultimedia> listarPorNombre(String cadena){
        ArrayList<ProductoMultimedia> productos =  new ArrayList<>();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PRODUCTO_LISTAR_NOMBRE(?)}");
            cs.setString("_titulo",cadena);
            rs = cs.executeQuery();
            while(rs.next()){
                ProductoMultimedia producto = new ProductoMultimedia();
                producto.setId_producto(rs.getInt("id_producto"));
                producto.setNombre(rs.getString("titulo"));
                producto.setPrecio(rs.getDouble("precio"));
                producto.setTipoProducto(TipoProducto.valueOf(rs.getString("tipo_producto")));
                producto.setClasificador(rs.getString("clasificador"));
                productos.add(producto);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return productos;
    }
    
    @Override
    public int existeEjemplarProductoSede(int id_prod, int id_sed){
        int resultado = 0;
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call BUSCAR_EJEMPLAR_NO_VENDIDO(?, ?, ?)}");
            cs.registerOutParameter("_existe", java.sql.Types.INTEGER);
            cs.setInt("_id_producto",id_prod);
            cs.setInt("_id_sede",id_sed);
            rs = cs.executeQuery();
            resultado = cs.getInt("_existe");
            
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }
    
    @Override
    public ArrayList<ProductoMultimedia> listarPorNombreYTipo(String cadena, String tipo){
        ArrayList<ProductoMultimedia> productos =  new ArrayList<>();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PRODUCTO_LISTAR_NOMBRE_TIPO(?, ?)}");
            cs.setString("_titulo",cadena);
            cs.setString("_tipo_producto",tipo);
            rs = cs.executeQuery();
            while(rs.next()){
                ProductoMultimedia producto = new ProductoMultimedia();
                producto.setId_producto(rs.getInt("id_producto"));
                producto.setNombre(rs.getString("titulo"));
                producto.setPrecio(rs.getDouble("precio"));
                producto.setTipoProducto(TipoProducto.valueOf(rs.getString("tipo_producto")));
                producto.setClasificador(rs.getString("clasificador"));
                productos.add(producto);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return productos;
    }
}

