package pe.edu.pucp.LibroClubSoft.acciones.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.productos.model.ProductoMultimedia;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;


public class SolicitudPrestamo {
    private int id_solicitud;
    private Date fecha;
    private Usuario cliente;
    private ProductoMultimedia producto;

    public SolicitudPrestamo( Usuario cliente, ProductoMultimedia producto) {
        this.cliente = cliente;
        this.producto = producto;
    }

    
    public int getId_solicitud() {
        return id_solicitud;
    }

    public void setId_solicitud(int id_solicitud) {
        this.id_solicitud = id_solicitud;
    }

    public Date getFecha() {
        return fecha;
    }

    public void setFecha(Date fecha) {
        this.fecha = fecha;
    }

    public Usuario getCliente() {
        return cliente;
    }

    public void setCliente(Usuario cliente) {
        this.cliente = cliente;
    }

    public ProductoMultimedia getProducto() {
        return producto;
    }

    public void setProducto(ProductoMultimedia producto) {
        this.producto = producto;
    }
    
    
}
