package pe.edu.pucp.LibroClubSoft.acciones.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;
import pe.edu.pucp.LibroClubSoft.productos.model.EjemplarVenta;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;


public class Venta {
    private int id_venta;
    private double subtotal;
    private double descuento = 0;
    private double total;
    private Date fecha;
    private Usuario cliente;
    private EjemplarVenta articulo;
    private Sede sede;
    private Personal vendedor;
    
    public Venta(){
        
    }
    
    public Venta(double subtotal, Usuario cliente, EjemplarVenta articulo, Sede sede, Personal vendedor, Date fecha) {
        this.subtotal = subtotal;
        this.cliente = cliente;
        this.articulo = articulo;
        this.sede = sede;
        this.vendedor = vendedor;
        this.fecha = fecha;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    
    
    public int getId_venta() {
        return id_venta;
    }

    public void setId_venta(int id_venta) {
        this.id_venta = id_venta;
    }

    public double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(double subtotal) {
        this.subtotal = subtotal;
    }

    public double getDescuento() {
        return descuento;
    }

    public void setDescuento(double descuento) {
        this.descuento = descuento;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public Usuario getCliente() {
        return cliente;
    }

    public void setCliente(Usuario cliente) {
        this.cliente = cliente;
    }


    public EjemplarVenta getArticulo() {
        return articulo;
    }

    public void setArticulo(EjemplarVenta articulo) {
        this.articulo = articulo;
    }

    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }

    public Personal getVendedor() {
        return vendedor;
    }

    public void setVendedor(Personal vendedor) {
        this.vendedor = vendedor;
    }
    
    
    
}

