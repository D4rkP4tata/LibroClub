package pe.edu.pucp.LibroClubSoft.externo.dao;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;


public interface UsuarioDAO {
    int insertar(Usuario obj);
    ArrayList<Usuario> listar();
    ArrayList<Usuario> listarMembresia(int id);
    Usuario ObtenerDni(String dni);
    int eliminar(int id);
    int modificar(Usuario obj);
    ArrayList<Usuario> listarPorNombre(String cadena);
}
