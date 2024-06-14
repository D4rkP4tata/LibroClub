package pe.edu.pucp.LibroClubSoft.Organizacion.mysql;

//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.PersonalDAO;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.organizacion.model.EstadoEmpleado;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Personal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Sede;


public class PersonalMySQL implements PersonalDAO{

    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public ArrayList<Personal> listar() {
        ArrayList<Personal> personales = new ArrayList<>();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PERSONAL_LISTAR()}");
            rs = cs.executeQuery();
            
            while(rs.next()){
                Personal personal = new Personal();
                personal.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                personal.setIdSede(rs.getInt("fid_sede"));
                personal.setSexo(rs.getString("genero").charAt(0));
                personal.setNombreSede(rs.getString("direccion"));
                personal.setUsername(rs.getString("usurname"));  
                personal.setPassword(rs.getString("password"));
                personal.setId_persona(rs.getInt("id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                personal.setDni(rs.getString("dni"));
                personal.setNombre(rs.getString("nombre"));
                //System.out.println(rs.getString("p.nombre"));
                personal.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                personal.setTelefono(rs.getInt("telefono"));
                personal.setInicio_contrato(rs.getDate("inicio_contrato"));
                personal.setFin_contrato(rs.getDate("fin_contrato"));
                personal.setCant_ejemplares_vendidos(rs.getInt("cant_ejemplares_vendidos"));
                personal.setCant_ejemplares_prestados(rs.getInt("cant_ejemplares_prestados"));
                
                personales.add(personal);
            } 
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return personales;
    }
    
    @Override
    public Personal Obtener_X_DNI(String dni) {
        Personal personal = new Personal();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PERSONAL_OBTENER_X_DNI(?)}");
            cs.setString("_dni",dni);
            rs = cs.executeQuery();
            
            if(rs.next()){
                personal.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                personal.setSexo(rs.getString("genero").charAt(0));
                personal.setNombreSede(rs.getString("direccion"));
                personal.setIdSede(rs.getInt("fid_sede"));
                personal.setUsername(rs.getString("usurname"));  
                personal.setPassword(rs.getString("password"));
                personal.setId_persona(rs.getInt("id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                personal.setDni(rs.getString("dni"));
                personal.setNombre(rs.getString("nombre"));
                //System.out.println(rs.getString("p.nombre"));
                personal.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                personal.setTelefono(rs.getInt("telefono"));
                personal.setInicio_contrato(rs.getDate("inicio_contrato"));
                personal.setFin_contrato(rs.getDate("fin_contrato"));
                personal.setCant_ejemplares_vendidos(rs.getInt("cant_ejemplares_vendidos"));
                personal.setCant_ejemplares_prestados(rs.getInt("cant_ejemplares_prestados"));
            } 
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return personal;
    }
    
    @Override
    public ArrayList<Personal> listar_X_Sede(int sede) {
        ArrayList<Personal> personales = new ArrayList<>();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PERSONAL_LISTAR_X_SEDE(?)}");
            cs.setInt("_id_sede",sede);
            rs = cs.executeQuery();
            
            while(rs.next()){
                Personal personal = new Personal();
                personal.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                personal.setSexo(rs.getString("genero").charAt(0));
                personal.setNombreSede(rs.getString("direccion"));
                personal.setUsername(rs.getString("usurname"));  
                personal.setPassword(rs.getString("password"));
                personal.setId_persona(rs.getInt("id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                personal.setDni(rs.getString("dni"));
                personal.setNombre(rs.getString("nombre"));
                //System.out.println(rs.getString("p.nombre"));
                personal.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                personal.setTelefono(rs.getInt("telefono"));
                personal.setInicio_contrato(rs.getDate("inicio_contrato"));
                personal.setFin_contrato(rs.getDate("fin_contrato"));
                personal.setCant_ejemplares_vendidos(rs.getInt("cant_ejemplares_vendidos"));
                personal.setCant_ejemplares_prestados(rs.getInt("cant_ejemplares_prestados"));
                
                personales.add(personal);
            } 
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return personales;
    }
    
    @Override
    public Personal Obtener_X_ID(int fid_personal) {
        Personal personal = new Personal();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PERSONAL_OBTENER_X_ID(?)}");
            cs.setInt("_fid_personal",fid_personal);
            rs = cs.executeQuery();
            
            if(rs.next()){
                personal.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                personal.setSexo(rs.getString("genero").charAt(0));
                personal.setIdSede(rs.getInt("fid_sede"));
                personal.setUsername(rs.getString("usurname"));  
                personal.setPassword(rs.getString("password"));
                personal.setId_persona(rs.getInt("id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                personal.setDni(rs.getString("dni"));
                personal.setNombre(rs.getString("nombre"));
                //System.out.println(rs.getString("p.nombre"));
                personal.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                personal.setTelefono(rs.getInt("telefono"));
                personal.setInicio_contrato(rs.getDate("inicio_contrato"));
                personal.setFin_contrato(rs.getDate("fin_contrato"));
                personal.setCant_ejemplares_vendidos(rs.getInt("cant_ejemplares_vendidos"));
                personal.setCant_ejemplares_prestados(rs.getInt("cant_ejemplares_prestados"));
            }

        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return personal;
    }
    
    @Override
    public ArrayList<Personal> listar_X_Dni_X_Sede(String dni, int id_sede){
        ArrayList<Personal> personales = new ArrayList<>();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call PERSONAL_LISTAR_X_SEDE_X_DNI(?,?)}");
            cs.setString("_dni",dni);
            cs.setInt("_id_sede", id_sede);
            rs = cs.executeQuery();
            
            while(rs.next()){
                Personal personal = new Personal();
                personal.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                personal.setSexo(rs.getString("genero").charAt(0));
                personal.setNombreSede(rs.getString("direccion"));
                personal.setUsername(rs.getString("usurname"));  
                personal.setPassword(rs.getString("password"));
                personal.setId_persona(rs.getInt("id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                personal.setDni(rs.getString("dni"));
                personal.setNombre(rs.getString("nombre"));
                //System.out.println(rs.getString("p.nombre"));
                personal.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                personal.setTelefono(rs.getInt("telefono"));
                personal.setInicio_contrato(rs.getDate("inicio_contrato"));
                personal.setFin_contrato(rs.getDate("fin_contrato"));
                personal.setCant_ejemplares_vendidos(rs.getInt("cant_ejemplares_vendidos"));
                personal.setCant_ejemplares_prestados(rs.getInt("cant_ejemplares_prestados"));
                
                personales.add(personal);
            } 
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return personales;
    }
            
           
    @Override
    public int insertar(Personal personal) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            
            cs = con.prepareCall("{call PERSONAL_INSERTAR(?,?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_persona",java.sql.Types.INTEGER);
            cs.setString("_dni",personal.getDni());
            cs.setString("_nombre", personal.getNombre());
            cs.setDate("_fecha_nacimiento", new java.sql.Date(personal.getFecha_nacimiento().getTime()));
            cs.setString("_genero", String.valueOf(personal.getSexo()));
            cs.setInt("_telefono", personal.getTelefono());
            cs.setDate("_fin_contrato", new java.sql.Date(personal.getFin_contrato().getTime()));
            String estado = personal.getEstado().toString();
            int id_estado;

            switch (estado) {
                case "Activo":
                    id_estado = 0;
                    break;
                case "Vacaciones":
                    id_estado = 1;
                    break;
                case "DescansoMedico":
                    id_estado = 2;
                    break;
                case "LicenciaMaternidadPaternidad":
                    id_estado = 3;
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_estado = -1;
                    break;
            }
            
            cs.setInt("_fid_estado_empleado", id_estado);
            cs.setInt("_fid_sede", personal.getIdSede());
            cs.setString("_usurname", personal.getUsername());
            cs.setString("_password", personal.getPassword());

            resultado = cs.executeUpdate();
            personal.setId_persona(cs.getInt("_id_persona"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public int eliminar(int id_personal) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call EMPLEADO_ELIMINAR(?)}");
            cs.setInt("_fid_empleado",id_personal);
            
            resultado = cs.executeUpdate();
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;    
    }
    
    @Override
    public int modificar(Personal personal){
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();

            cs = con.prepareCall("{call PERSONAL_MODIFICAR(?,?,?,?,?,?,?,?,?,?)}");
            cs.setInt("_id_persona", personal.getId_persona());
            cs.setDate("_fecha_nacimiento", new java.sql.Date(personal.getFecha_nacimiento().getTime()));
            cs.setString("_dni", personal.getDni());
            cs.setString("_nombre", personal.getNombre());
            cs.setString("_genero", String.valueOf(personal.getSexo()));
            cs.setInt("_telefono", personal.getTelefono());
            cs.setInt("_fid_sede", personal.getIdSede());
            cs.setString("_username", personal.getUsername());
            cs.setString("_password", personal.getPassword());
            String estado = personal.getEstado().toString();
            int id_estado;

            switch (estado) {
                case "Activo":
                    id_estado = 0;
                    break;
                case "Vacaciones":
                    id_estado = 1;
                    break;
                case "DescansoMedico":
                    id_estado = 2;
                    break;
                case "LicenciaMaternidadPaternidad":
                    id_estado = 3;
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_estado = -1;
                    break;
            }
            
            cs.setInt("_fid_estado_empleado", id_estado);
            
            resultado = cs.executeUpdate();
            cs.close();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

}
