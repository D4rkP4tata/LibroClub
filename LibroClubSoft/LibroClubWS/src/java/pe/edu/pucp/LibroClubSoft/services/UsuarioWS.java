/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.services;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.externo.dao.UsuarioDAO;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;
import pe.edu.pucp.LibroClubSoft.externo.mysql.UsuarioMySQL;

/**
 *
 * @author Bruno Monzén Sullón
 */
@WebService(serviceName = "UsuarioWS")
public class UsuarioWS {
    private UsuarioDAO daoUsuario;
    /**
     * This is a sample web service operation
     */
    
    @WebMethod(operationName = "insertarUsuario")
    public int insertar(@WebParam(name = "obj")Usuario obj){
        int resultado = 0;
        try{
            daoUsuario = new UsuarioMySQL();
            resultado = daoUsuario.insertar(obj);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarUsuario")
    public int eliminarUsuario(@WebParam(name = "id")int id){
        int resultado = 0;
        try{
            daoUsuario = new UsuarioMySQL();
            resultado = daoUsuario.eliminar(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarUsuario")
    public int modificarUsuario(@WebParam(name = "obj")Usuario obj){
        int resultado = 0;
        try{
            daoUsuario = new UsuarioMySQL();
            resultado = daoUsuario.modificar(obj);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarUsuario")
    public ArrayList listar(){
        ArrayList<Usuario> usuarios = new ArrayList<>();
        try{
            daoUsuario = new UsuarioMySQL();
            usuarios = daoUsuario.listar();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return usuarios;
    }
    
    @WebMethod(operationName = "listarUsuarioMembresia")
    public ArrayList listarUsuarioMembresia(@WebParam(name = "id")int id){
        ArrayList<Usuario> usuarios = new ArrayList<>();
        try{
            daoUsuario = new UsuarioMySQL();
            usuarios = daoUsuario.listarMembresia(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return usuarios;
    }
    
    @WebMethod(operationName = "ObtenerUsuarioDni")
    public Usuario ObtenerUsuarioDni(@WebParam(name = "dni")String dni){
        Usuario usuario = new Usuario();
        try{
            daoUsuario = new UsuarioMySQL();
            usuario = daoUsuario.ObtenerDni(dni);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return usuario;
    }
    
    @WebMethod(operationName = "listarPorNombreUsuario")
    public ArrayList<Usuario> listarPorNombreUsuario(String cadena){
        ArrayList<Usuario> usuarios= new ArrayList<>();
        
        try{
            daoUsuario= new UsuarioMySQL();
            usuarios = daoUsuario.listarPorNombre(cadena);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return usuarios;
    }
    
}
