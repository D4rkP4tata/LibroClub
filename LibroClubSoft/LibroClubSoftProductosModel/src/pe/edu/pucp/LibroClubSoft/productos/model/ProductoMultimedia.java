/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.productos.model;




public class ProductoMultimedia {
    private int id_producto;
    private String nombre;
    private String clasificador;
    private TipoProducto tipoProducto;
    private int stock_venta = 0;
    private int stock_prestamo = 0;
    private int stock_prestamo_disponible = 0;
    private double precio;
    private boolean activo = true;


    public ProductoMultimedia() {
        
    }

    public ProductoMultimedia(String nombre, double precio) {
        this.nombre = nombre;
        this.precio = precio;
    }


    public int getId_producto() {
        return id_producto;
    }

    public void setId_producto(int id_producto) {
        this.id_producto = id_producto;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getStock_venta() {
        return stock_venta;
    }

    public void setStock_venta(int stock_venta) {
        this.stock_venta = stock_venta;
    }

    public int getStock_prestamo() {
        return stock_prestamo;
    }

    public void setStock_prestamo(int stock_prestamo) {
        this.stock_prestamo = stock_prestamo;
    }

    public int getStock_prestamo_disponible() {
        return stock_prestamo_disponible;
    }

    public void setStock_prestamo_disponible(int stock_prestamo_disponible) {
        this.stock_prestamo_disponible = stock_prestamo_disponible;
    }

    public double getPrecio() {
        return precio;
    }

    public void setPrecio(double precio) {
        this.precio = precio;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public String getClasificador() {
        return clasificador;
    }

    public void setClasificador(String clasificador) {
        this.clasificador = clasificador;
    }

    public TipoProducto getTipoProducto() {
        return tipoProducto;
    }

    public void setTipoProducto(TipoProducto tipoProducto) {
        this.tipoProducto = tipoProducto;
    }


    
}
