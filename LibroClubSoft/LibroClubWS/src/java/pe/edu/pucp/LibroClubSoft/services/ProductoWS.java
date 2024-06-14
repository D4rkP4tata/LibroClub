/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.services;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.productos.dao.ProductoDAO;
import pe.edu.pucp.LibroClubSoft.productos.model.ProductoMultimedia;
import pe.edu.pucp.LibroClubSoft.productos.mysql.ProductoMySQL;

/**
 *
 * @author danie
 */
@WebService(serviceName = "ProductoWS")
public class ProductoWS {

    private ProductoDAO daoProducto;
    
    @WebMethod(operationName = "buscarPorIDProducto")
    public ProductoMultimedia buscarPorIDProducto(int id){
        ProductoMultimedia producto= new ProductoMultimedia();
        
        try{
            daoProducto= new ProductoMySQL();
            producto = daoProducto.buscarPorID(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return producto;
    }
    
    @WebMethod(operationName = "listarPorNombreProducto")
    public ArrayList<ProductoMultimedia> listarPorNombreProducto(String cadena){
        ArrayList<ProductoMultimedia> productos= new ArrayList<>();
        
        try{
            daoProducto= new ProductoMySQL();
            productos = daoProducto.listarPorNombre(cadena);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return productos;
    }
    
    @WebMethod(operationName = "listarPorNombreYTipoProducto")
    public ArrayList<ProductoMultimedia> listarPorNombreYTipoProducto(String cadena, String tipo){
        ArrayList<ProductoMultimedia> productos= new ArrayList<>();
        
        try{
            daoProducto= new ProductoMySQL();
            productos = daoProducto.listarPorNombreYTipo(cadena, tipo);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return productos;
    }
    
    @WebMethod(operationName = "existeEjemplarProductoSede")
    public int existeEjemplarProductoSede(int id_prod, int id_sed){
        int resultado = 0;
        
        try{
            daoProducto= new ProductoMySQL();
            resultado = daoProducto.existeEjemplarProductoSede(id_prod,id_sed );
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    
}
