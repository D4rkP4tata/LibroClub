/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.main;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.acciones.dao.VentaDAO;
import pe.edu.pucp.LibroClubSoft.acciones.model.Venta;
import pe.edu.pucp.LibroClubSoft.acciones.mysql.VentaMySQL;

/**
 *
 * @author danie
 */
public class LibroClubSoft {
     public static void main(String[] args) {
        
         
        VentaDAO ventaDao = new VentaMySQL();
        ArrayList<Venta> ventas = ventaDao.listar();

        for (Venta venta : ventas) {
            System.out.println("ID Venta: " + venta.getId_venta());
            System.out.println("Subtotal: " + venta.getSubtotal());
            System.out.println("Descuento: " + venta.getDescuento());
            System.out.println("Total: " + venta.getTotal());
            System.out.println("Fecha: " + venta.getFecha());
            System.out.println("Cliente: " + venta.getCliente().getNombre());
            System.out.println("Artículo: " + venta.getArticulo().getCodigoSerie());
            System.out.println("Producto: " + venta.getArticulo().getProducto().getNombre());
            System.out.println("Sede: " + venta.getSede().getDireccion());
            System.out.println("Vendedor: " + venta.getVendedor().getNombre());
            System.out.println("-----------");
        }
         
         
    }
}
