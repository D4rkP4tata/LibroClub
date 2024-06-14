package pe.edu.pucp.LibroClubSoft.organizacion.model;

import java.util.Date;


public class Personal extends Empleado{
    private int cant_ejemplares_vendidos  = 0;
    private int cant_ejemplares_prestados = 0;

    public Personal() {
    }

    public Personal(int idSede, String nombreSede, Date inicio_contrato, Date fin_contrato, EstadoEmpleado estado, Sede sede, String username, String password, String dni, String nombre, Date fecha_nacimiento, char sexo, int telefono) {
        super(inicio_contrato, fin_contrato, estado, sede, username, password, dni, nombre, fecha_nacimiento, sexo, telefono);
    }


    public int getCant_ejemplares_vendidos() {
        return cant_ejemplares_vendidos;
    }

    public void setCant_ejemplares_vendidos(int cant_ejemplares_vendidos) {
        this.cant_ejemplares_vendidos = cant_ejemplares_vendidos;
    }

    public int getCant_ejemplares_prestados() {
        return cant_ejemplares_prestados;
    }

    public void setCant_ejemplares_prestados(int cant_ejemplares_prestados) {
        this.cant_ejemplares_prestados = cant_ejemplares_prestados;
    }
    
    
}
