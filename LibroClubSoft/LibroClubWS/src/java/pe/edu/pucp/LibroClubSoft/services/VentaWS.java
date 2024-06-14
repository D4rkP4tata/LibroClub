/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.services;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.acciones.dao.VentaDAO;
import pe.edu.pucp.LibroClubSoft.acciones.model.Venta;
import pe.edu.pucp.LibroClubSoft.acciones.mysql.VentaMySQL;




/**
 *
 * @author danie
 */
@WebService(serviceName = "VentaWS")
public class VentaWS {

    private VentaDAO daoVenta;
    
    
    @WebMethod(operationName = "insertarVenta")
    public int insertarVenta(@WebParam(name = "obj")Venta obj){
        int resultado = 0;
        try{
            daoVenta = new VentaMySQL();
            resultado = daoVenta.insertarVentaBuscandoEjemplar(obj);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarVentas")
    public ArrayList<Venta> listarVentas(int id_sede){
        ArrayList<Venta> ventas = new ArrayList<>();
        try{
            daoVenta = new VentaMySQL();
            ventas = daoVenta.listar(id_sede);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return ventas;
        
    }
    
    @WebMethod(operationName = "buscarPorIDVenta")
    public Venta buscarPorIDVenta(int id){
        Venta venta= new Venta();
        try{
            daoVenta = new VentaMySQL();
            venta = daoVenta.buscarPorID(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return venta;
    }
    
    @WebMethod(operationName = "eliminarVenta")
    public int eliminarVenta(int id){
        int resultado =0;
        try{
            daoVenta = new VentaMySQL();
            resultado = daoVenta.eliminar(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarVentaIgualProducto")
    public int modificarVentaIgualProducto(Venta venta){
        int resultado=0;
        try{
            daoVenta = new VentaMySQL();
            resultado = daoVenta.modificarVentaIgualProducto(venta);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
        
    }
    
    @WebMethod(operationName = "modificarVentaDiferenteProducto")
    public int modificarVentaDiferenteProducto(Venta venta){
        int resultado=0;
        try{
            daoVenta = new VentaMySQL();
            resultado = daoVenta.modificarVentaDiferenteProducto(venta);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
        
    }
    
    @WebMethod(operationName = "listarVentasBusqueda")
    public ArrayList<Venta> listarVentasBusqueda(int id, String dni, String fecha_desde, String fecha_hasta){
        ArrayList<Venta> ventas = new ArrayList<>();
        try{
            daoVenta = new VentaMySQL();
            ventas = daoVenta.listarBusqueda(id, dni, fecha_desde, fecha_hasta);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return ventas;
        
    }
    
}
