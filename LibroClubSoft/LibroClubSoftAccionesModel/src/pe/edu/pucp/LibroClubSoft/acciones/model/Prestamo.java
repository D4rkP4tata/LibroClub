package pe.edu.pucp.LibroClubSoft.acciones.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;
import pe.edu.pucp.LibroClubSoft.productos.model.EjemplarPrestamo;


public class Prestamo {
    private int id_prestamo;
    private Date fecha_recojo_establecida;
    private Date fecha_limite_devolucion;
    private Date fecha_recojo = null;
    private Date fecha_devolucion = null;
    private SolicitudPrestamo solicitud;
    private Sede sede;
    private Personal personal;
    private EjemplarPrestamo articulo;

    public Prestamo( SolicitudPrestamo solicitud, Sede sede, Personal personal, EjemplarPrestamo articulo) {
        this.solicitud = solicitud;
        this.sede = sede;
        this.personal = personal;
        this.articulo = articulo;
    }

    public int getId_prestamo() {
        return id_prestamo;
    }

    public void setId_prestamo(int id_prestamo) {
        this.id_prestamo = id_prestamo;
    }

    public Date getFecha_recojo_establecida() {
        return fecha_recojo_establecida;
    }

    public void setFecha_recojo_establecida(Date fecha_recojo_establecida) {
        this.fecha_recojo_establecida = fecha_recojo_establecida;
    }

    public Date getFecha_limite_devolucion() {
        return fecha_limite_devolucion;
    }

    public void setFecha_limite_devolucion(Date fecha_limite_devolucion) {
        this.fecha_limite_devolucion = fecha_limite_devolucion;
    }

    public Date getFecha_recojo() {
        return fecha_recojo;
    }

    public void setFecha_recojo(Date fecha_recojo) {
        this.fecha_recojo = fecha_recojo;
    }

    public Date getFecha_devolucion() {
        return fecha_devolucion;
    }

    public void setFecha_devolucion(Date fecha_devolucion) {
        this.fecha_devolucion = fecha_devolucion;
    }

    public SolicitudPrestamo getSolicitud() {
        return solicitud;
    }

    public void setSolicitud(SolicitudPrestamo solicitud) {
        this.solicitud = solicitud;
    }

    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }

    public Personal getPersonal() {
        return personal;
    }

    public void setPersonal(Personal personal) {
        this.personal = personal;
    }

    public EjemplarPrestamo getArticulo() {
        return articulo;
    }

    public void setArticulo(EjemplarPrestamo articulo) {
        this.articulo = articulo;
    }
    
    
}
