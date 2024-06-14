/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.LibroClubSoft.services;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.GerenteDeLocalDAO;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.PersonalDAO;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.SedeDAO;
import pe.edu.pucp.LibroClubSoft.Organizacion.mysql.GerenteDeLocalMySQL;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;
import pe.edu.pucp.LibroClubSoft.Organizacion.mysql.PersonalMySQL;
import pe.edu.pucp.LibroClubSoft.Organizacion.mysql.SedeMySQL;
import pe.edu.pucp.LibroClubSoft.externo.dao.UsuarioDAO;
import pe.edu.pucp.LibroClubSoft.externo.model.TipoMembresia;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;
import pe.edu.pucp.LibroClubSoft.externo.mysql.UsuarioMySQL;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Empleado;
import pe.edu.pucp.LibroClubSoft.organizacion.model.GerenteDeLocal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;

/**
 *
 * @author Bruno Monzén Sullón
 */
@WebService(serviceName = "ServicioWS")
public class ServicioWS {
    private UsuarioDAO daoUsuario;
    private PersonalDAO daoPersonal;
    private GerenteDeLocalDAO daoGerente;
    private SedeDAO daoSede;
    
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
    
    @WebMethod(operationName = "listarPersonal")
    public ArrayList listarPersonal(){
        ArrayList<Personal> personales = new ArrayList<>();
        try{
            daoPersonal = new PersonalMySQL();
            personales = daoPersonal.listar();
            System.out.println(personales);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return personales;
    }
    
    @WebMethod(operationName = "insertarPersonal")
    public int insertarPersonal(@WebParam(name = "obj")Personal obj){
        int resultado = 0;
        try{
            daoPersonal = new PersonalMySQL();
            resultado = daoPersonal.insertar(obj);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "insertarGerente")
    public int insertarGerente(@WebParam(name = "obj")GerenteDeLocal obj){
        int resultado = 0;
        try{
            daoGerente = new GerenteDeLocalMySQL();
            resultado = daoGerente.insertar(obj);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarGerente")
    public ArrayList listarGerente(){
        ArrayList<GerenteDeLocal> gerentes = new ArrayList<>();
        try{
            daoGerente = new GerenteDeLocalMySQL();
            gerentes = daoGerente.listar();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return gerentes;
    }
    
    @WebMethod(operationName = "obtenerGerenteID")
    public GerenteDeLocal listarGerenteID(@WebParam(name = "fid_gerente")int fid_gerente){
        GerenteDeLocal gerente = new GerenteDeLocal();
        try{
            daoGerente = new GerenteDeLocalMySQL();
            gerente = daoGerente.Obtener_X_ID(fid_gerente);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return gerente;
    }
    
    @WebMethod(operationName = "listarSede")
    public ArrayList listarSede(){
        ArrayList<Sede> sedes = new ArrayList<>();
        try{
            daoSede = new SedeMySQL();
            sedes = daoSede.listar();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return sedes;
    }
    
    @WebMethod(operationName = "eliminarPersonal")
    public int eliminarPersonal(@WebParam(name = "id")int id){
        int resultado = 0;
        try{
            daoPersonal = new PersonalMySQL();
            resultado = daoPersonal.eliminar(id);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarPersonal")
    public int modificarPersonal(@WebParam(name = "personal")Personal personal){
        int resultado = 0;
        try{
            daoPersonal = new PersonalMySQL();
            resultado = daoPersonal.modificar(personal);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "ObtenerPersonalDNI")
    public Personal listarPersonalDNI(@WebParam(name = "dni")String dni){
        Personal personal = new Personal();
        try{
            daoPersonal = new PersonalMySQL();
            personal = daoPersonal.Obtener_X_DNI(dni);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return personal;
    }
    
    @WebMethod(operationName = "listarPersonalSede")
    public ArrayList listarPersonalSede(@WebParam(name = "sede")int sede){
        ArrayList<Personal> personales = new ArrayList<>();
        try{
            daoPersonal = new PersonalMySQL();
            personales = daoPersonal.listar_X_Sede(sede);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return personales;
    }
    
    @WebMethod(operationName = "ObtenerPersonalID")
    public Personal listarPersonalID(@WebParam(name = "fid_personal")int fid_personal){
        Personal personal = new Personal();
        try{
            daoPersonal = new PersonalMySQL();
            personal = daoPersonal.Obtener_X_ID(fid_personal);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return personal;
    }
    
    @WebMethod(operationName = "listarPersonalDni_Sede")
    public ArrayList listarPersonalDni_Sede(@WebParam(name = "dni")String dni, 
            @WebParam(name = "id_sede")int  id_sede){
        ArrayList<Personal> personales = new ArrayList<>();
        try{
            daoPersonal = new PersonalMySQL();
            personales = daoPersonal.listar_X_Dni_X_Sede(dni,id_sede);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return personales;
    }
}
