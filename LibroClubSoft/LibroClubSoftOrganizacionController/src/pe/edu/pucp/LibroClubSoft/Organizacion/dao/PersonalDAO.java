package pe.edu.pucp.LibroClubSoft.Organizacion.dao;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;


public interface PersonalDAO {
    public ArrayList<Personal> listar();
    public int insertar(Personal personal);
    public int eliminar(int id_personal);
    public int modificar(Personal personal);
    public Personal Obtener_X_DNI(String dni);
    public ArrayList<Personal> listar_X_Sede(int id_sede);
    public Personal Obtener_X_ID(int fid_personal);
    public ArrayList<Personal> listar_X_Dni_X_Sede(String dni, int id_sede);
}
