package pe.edu.pucp.LibroClubSoft.productos.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


public class EjemplarPrestamo extends Ejemplar{
    private int veces_prestado = 0;
    private EstadoPrestamo estado_prestamo = EstadoPrestamo.En_transito;
    private EstadoConservacion estado_conservacion;

    public EjemplarPrestamo(EstadoConservacion estado_conservacion, String codigoSerie, Date fecha_ingreso, ProductoMultimedia producto, Sede sede) {
        super(codigoSerie, fecha_ingreso, producto, sede);
        this.estado_conservacion = estado_conservacion;
    }

    public EstadoPrestamo getEstado_prestamo() {
        return estado_prestamo;
    }

    public void setEstado_prestamo(EstadoPrestamo estado_prestamo) {
        this.estado_prestamo = estado_prestamo;
    }

    public EstadoConservacion getEstado_conservacion() {
        return estado_conservacion;
    }

    public void setEstado_conservacion(EstadoConservacion estado_conservacion) {
        this.estado_conservacion = estado_conservacion;
    }

    


    public int getVeces_prestado() {
        return veces_prestado;
    }

    public void setVeces_prestado(int veces_prestado) {
        this.veces_prestado = veces_prestado;
    }

    
    
    
    
    
}
