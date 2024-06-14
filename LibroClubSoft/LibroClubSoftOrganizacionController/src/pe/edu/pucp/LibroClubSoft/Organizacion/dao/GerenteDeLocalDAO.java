package pe.edu.pucp.LibroClubSoft.Organizacion.dao;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.organizacion.model.GerenteDeLocal;


public interface GerenteDeLocalDAO {
    public ArrayList<GerenteDeLocal> listar();
    public int insertar(GerenteDeLocal gerente);
    public int eliminar(int id_gerente);
    public GerenteDeLocal Obtener_X_ID(int fid_gerente);
}
