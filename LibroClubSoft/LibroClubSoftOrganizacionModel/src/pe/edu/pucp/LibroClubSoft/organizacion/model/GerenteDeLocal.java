package pe.edu.pucp.LibroClubSoft.organizacion.model;

import java.util.Date;

public class GerenteDeLocal extends Empleado{
    private Date fecha_inicio_cargo;

    public GerenteDeLocal() {
    }

    public GerenteDeLocal(int idSede, String nombreSede, Date fecha_inicio_cargo, Date inicio_contrato, Date fin_contrato, EstadoEmpleado estado, Sede sede, String username, String password, String dni, String nombre, Date fecha_nacimiento, char sexo, int telefono) {
        super(inicio_contrato, fin_contrato, estado, sede, username, password, dni, nombre, fecha_nacimiento, sexo, telefono);
        this.fecha_inicio_cargo = fecha_inicio_cargo;
    }

    

    public Date getFecha_inicio_cargo() {
        return fecha_inicio_cargo;
    }

    public void setFecha_inicio_cargo(Date fecha_inicio_cargo) {
        this.fecha_inicio_cargo = fecha_inicio_cargo;
    }
}
