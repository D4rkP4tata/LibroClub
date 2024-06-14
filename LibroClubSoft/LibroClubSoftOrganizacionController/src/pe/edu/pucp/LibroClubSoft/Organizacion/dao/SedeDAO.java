package pe.edu.pucp.LibroClubSoft.Organizacion.dao;


import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


public interface SedeDAO {
    public ArrayList<Sede> listar();
    public int insertar(Sede sede);
    public int eliminar(int id_sede);
    public int actualizar_direccion(int id_sede,String direccion);
}
