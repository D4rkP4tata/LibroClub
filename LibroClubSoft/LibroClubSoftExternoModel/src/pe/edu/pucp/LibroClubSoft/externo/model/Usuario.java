package pe.edu.pucp.LibroClubSoft.externo.model;

import java.util.Date;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Persona;


public class Usuario extends Persona{
    private Date fecha_afiliacion;
    private TipoMembresia membresia;
    
    public Usuario(){
        
    }
    public Usuario(Date fecha_afiliacion, TipoMembresia membresia, 
            String dni, String nombre, Date fecha_nacimiento,
            char sexo, int telefono) {
        
        super(dni, nombre, fecha_nacimiento, sexo, telefono);
        this.fecha_afiliacion = fecha_afiliacion;
        this.membresia = membresia;
    }

    public Date getFecha_afiliacion() {
        return fecha_afiliacion;
    }

    public void setFecha_afiliacion(Date fecha_afiliacion) {
        this.fecha_afiliacion = fecha_afiliacion;
    }

    public TipoMembresia getMembresia() {
        return membresia;
    }

    public void setMembresia(TipoMembresia membresia) {
        this.membresia = membresia;
    }
    
    
    
}
