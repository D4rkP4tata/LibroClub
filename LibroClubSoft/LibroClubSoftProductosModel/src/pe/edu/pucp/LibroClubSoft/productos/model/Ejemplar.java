package pe.edu.pucp.LibroClubSoft.productos.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


abstract public class Ejemplar {
    private int id_ejemplar;
    private String codigoSerie;
    private Date fecha_ingreso;
    private ProductoMultimedia producto;
    private Sede sede;

    public Ejemplar(String codigoSerie, Date fecha_ingreso, ProductoMultimedia producto, Sede sede) {
        this.codigoSerie = codigoSerie;
        this.fecha_ingreso = fecha_ingreso;
        this.producto = producto;
        this.sede = sede;
    }
    
    
    public Ejemplar() {
    }

    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }

    
    
    public int getId_ejemplar() {
        return id_ejemplar;
    }

    public void setId_ejemplar(int id_ejemplar) {
        this.id_ejemplar = id_ejemplar;
    }

    public String getCodigoSerie() {
        return codigoSerie;
    }

    public void setCodigoSerie(String codigoSerie) {
        this.codigoSerie = codigoSerie;
    }

    public Date getFecha_ingreso() {
        return fecha_ingreso;
    }

    public void setFecha_ingreso(Date fecha_ingreso) {
        this.fecha_ingreso = fecha_ingreso;
    }

    public ProductoMultimedia getProducto() {
        return producto;
    }

    public void setProducto(ProductoMultimedia producto) {
        this.producto = producto;
    }

    
    
    
}
