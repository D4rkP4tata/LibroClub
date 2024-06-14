
package pe.edu.pucp.LibroClubSoft.organizacion.model;


public class Sede {
    private int id_sede;
    private String direccion;
    private boolean activo;

    public Sede() {
        activo = true;
    }

    public Sede(String direccion) {
        this.direccion = direccion;
        this.activo = true;
    }

    public int getId_sede() {
        return id_sede;
    }

    public void setId_sede(int id_sede) {
        this.id_sede = id_sede;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }
    
    
}
