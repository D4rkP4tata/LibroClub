package pe.edu.pucp.LibroClubSoft.organizacion.model;

import java.util.Date;

public abstract class Persona {
    private int id_persona;
    private String dni;
    private String nombre;
    private Date fecha_nacimiento;
    private char sexo;
    private int telefono;

    public Persona(){
    }

    public Persona(String dni, String nombre, Date fecha_nacimiento, char sexo, int telefono) {
        this.dni = dni;
        this.nombre = nombre;
        this.fecha_nacimiento = fecha_nacimiento;
        this.sexo = sexo;
        this.telefono = telefono;
    }
    
    public int getId_persona() {
        return id_persona;
    }

    public void setId_persona(int id_persona) {
        this.id_persona = id_persona;
    }

    public String getDni() {
        return dni;
    }

    public void setDni(String dni) {
        this.dni = dni;
    }



    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Date getFecha_nacimiento() {
        return fecha_nacimiento;
    }

    public void setFecha_nacimiento(Date fecha_nacimiento) {
        this.fecha_nacimiento = fecha_nacimiento;
    }

    public char getSexo() {
        return sexo;
    }

    public void setSexo(char sexo) {
        this.sexo = sexo;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }


    
    
}
