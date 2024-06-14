/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.productos.dao;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.productos.model.ProductoMultimedia;

/**
 *
 * @author danie
 */
public interface ProductoDAO {
    
    //public ArrayList<ProductoMultimedia> listarProductosNombre();
    public ProductoMultimedia buscarPorID(int id);
    ArrayList<ProductoMultimedia> listarPorNombre(String cadena);
    ArrayList<ProductoMultimedia> listarPorNombreYTipo(String cadena, String tipo);
    int existeEjemplarProductoSede(int id_prod, int id_sed);
}

