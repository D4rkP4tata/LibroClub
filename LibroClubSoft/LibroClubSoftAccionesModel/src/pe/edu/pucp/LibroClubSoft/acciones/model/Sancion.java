package pe.edu.pucp.LibroClubSoft.acciones.model;

import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;


public class Sancion {
    private int id_sancion;
    private String descripcion;
    private Usuario cliente;
    private Prestamo prestamo;

    public Sancion(String descripcion, Usuario cliente, Prestamo prestamo) {
        this.descripcion = descripcion;
        this.cliente = cliente;
        this.prestamo = prestamo;
    }

    public int getId_sancion() {
        return id_sancion;
    }

    public void setId_sancion(int id_sancion) {
        this.id_sancion = id_sancion;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public Usuario getCliente() {
        return cliente;
    }

    public void setCliente(Usuario cliente) {
        this.cliente = cliente;
    }

    public Prestamo getPrestamo() {
        return prestamo;
    }

    public void setPrestamo(Prestamo prestamo) {
        this.prestamo = prestamo;
    }
    
    
}
