package pe.edu.pucp.LibroClubSoft.productos.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


public class EjemplarVenta extends Ejemplar{
    private String observacion;
    private Date fecha_venta;

    
    public EjemplarVenta() {
        
    }
    
    public EjemplarVenta(String observacion, String codigoSerie,
            Date fecha_ingreso, ProductoMultimedia producto,
            Sede sede) {
        super(codigoSerie, fecha_ingreso, producto, sede);
        this.observacion = observacion;
    }

    
    public String getObservacion() {
        return observacion;
    }

    public void setObservacion(String observacion) {
        this.observacion = observacion;
    }

    public Date getFecha_venta() {
        return fecha_venta;
    }

    public void setFecha_venta(Date fecha_venta) {
        this.fecha_venta = fecha_venta;
    }


    
    
}
