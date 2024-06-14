
package pe.edu.pucp.LibroClubSoft.organizacion.model;

import java.util.Date;


abstract public class Empleado extends Persona{
    private Date inicio_contrato;
    private Date fin_contrato;
    private EstadoEmpleado estado;
    private Sede sede;
    private String nombreSede;
    private int idSede;
    private String username;
    private String password;
    private boolean activo = true;

    public Empleado() {
    }

    public Empleado(Date inicio_contrato, Date fin_contrato, EstadoEmpleado estado, Sede sede, String username, String password, String dni, String nombre, Date fecha_nacimiento, char sexo, int telefono) {
        super(dni, nombre, fecha_nacimiento, sexo, telefono);
        this.inicio_contrato = inicio_contrato;
        this.fin_contrato = fin_contrato;
        this.estado = estado;
        this.sede = sede;
        this.username = username;
        this.password = password;
    }

    
    
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    

    public Date getInicio_contrato() {
        return inicio_contrato;
    }

    public void setInicio_contrato(Date inicio_contrato) {
        this.inicio_contrato = inicio_contrato;
    }

    public Date getFin_contrato() {
        return fin_contrato;
    }

    public void setFin_contrato(Date fin_contrato) {
        this.fin_contrato = fin_contrato;
    }

    public EstadoEmpleado getEstado() {
        return estado;
    }

    public void setEstado(EstadoEmpleado estado) {
        this.estado = estado;
    }

    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }
    
    //nuevo///////////////////////////////
    public String getNombreSede(){
        return nombreSede;
    }
    
    public void setNombreSede(String nombreSede){
        this.nombreSede = nombreSede;
    }
    
    public int getIdSede(){
        return idSede;
    }
    
    public void setIdSede(int idsede){
        this.idSede = idsede;
    }
    /////////////////////////////////////

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }
    
    
    
}
