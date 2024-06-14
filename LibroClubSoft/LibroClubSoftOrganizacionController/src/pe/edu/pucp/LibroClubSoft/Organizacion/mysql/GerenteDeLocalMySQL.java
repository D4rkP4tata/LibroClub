package pe.edu.pucp.LibroClubSoft.Organizacion.mysql;
//Librerias SQL
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.Organizacion.dao.GerenteDeLocalDAO;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.organizacion.model.GerenteDeLocal;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Persona;
import pe.edu.pucp.LibroClubSoft.organizacion.model.Empleado;
import pe.edu.pucp.LibroClubSoft.organizacion.model.EstadoEmpleado;


public class GerenteDeLocalMySQL implements GerenteDeLocalDAO{

    private Connection con;
    private PreparedStatement ps;
    private ResultSet rs;
    private String sql;
    private CallableStatement cs;
    
    @Override
    public ArrayList<GerenteDeLocal> listar() {
        ArrayList<GerenteDeLocal> gerentes = new ArrayList<>();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call GERENTE_DE_LOCAL_LISTAR()}");
            rs = cs.executeQuery();
            
            while(rs.next()){
                GerenteDeLocal gerente = new GerenteDeLocal();
                gerente.setSexo(rs.getString("genero").charAt(0));
                gerente.setIdSede(rs.getInt("fid_sede"));
                gerente.setUsername(rs.getString("usurname"));
                gerente.setPassword(rs.getString("password"));
                gerente.setId_persona(rs.getInt("p.id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                gerente.setDni(rs.getString("p.dni"));
                gerente.setNombre(rs.getString("p.nombre"));
                //System.out.println(rs.getString("p.nombre"));
                gerente.setFecha_nacimiento(rs.getDate("p.fecha_nacimiento"));
                gerente.setTelefono(rs.getInt("p.telefono"));
                gerente.setInicio_contrato(rs.getDate("e.inicio_contrato"));
                gerente.setFin_contrato(rs.getDate("e.fin_contrato"));
                gerente.setFecha_inicio_cargo(rs.getDate("gl.inicio_cargo"));
                    
                gerentes.add(gerente);
            }
            cs.close();
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }
        
        return gerentes;
    }
    
    @Override
    public GerenteDeLocal Obtener_X_ID(int fid_gerente) {
        GerenteDeLocal gerente = new GerenteDeLocal();
        
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call GERENTE_DE_LOCAL_OBTENER_X_ID(?)}");
            cs.setInt("_fid_gerente",fid_gerente);
            rs = cs.executeQuery();
            
            if(rs.next()){
                gerente.setSexo(rs.getString("genero").charAt(0));
                gerente.setEstado(EstadoEmpleado.valueOf(rs.getString("estado")));
                gerente.setIdSede(rs.getInt("fid_sede"));
                gerente.setUsername(rs.getString("usurname"));
                gerente.setPassword(rs.getString("password"));
                gerente.setId_persona(rs.getInt("p.id_persona"));
                //System.out.println(rs.getInt("p.id_persona"));
                gerente.setDni(rs.getString("p.dni"));
                gerente.setNombre(rs.getString("p.nombre"));
                //System.out.println(rs.getString("p.nombre"));
                gerente.setFecha_nacimiento(rs.getDate("p.fecha_nacimiento"));
                gerente.setTelefono(rs.getInt("p.telefono"));
                gerente.setInicio_contrato(rs.getDate("e.inicio_contrato"));
                gerente.setFin_contrato(rs.getDate("e.fin_contrato"));
                gerente.setFecha_inicio_cargo(rs.getDate("gl.inicio_cargo"));
            }
            cs.close();
        }catch(Exception ex){
           System.out.println(ex.getMessage()); 
        }
        
        return gerente;
    }

    @Override
    public int insertar(GerenteDeLocal gerente) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call GERENTE_DE_LOCAL_INSERTAR(?,?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_persona",java.sql.Types.INTEGER);
            cs.setString("_dni", gerente.getDni());
            cs.setString("_nombre", gerente.getNombre());
            cs.setDate("_fecha_nacimiento", new java.sql.Date(gerente.getFecha_nacimiento().getTime()));
            cs.setString("_genero", String.valueOf(gerente.getSexo()));
            cs.setInt("_telefono", gerente.getTelefono());
            cs.setDate("_inicio_contrato", new java.sql.Date(gerente.getInicio_contrato().getTime()));
            cs.setDate("_fin_contrato", new java.sql.Date(gerente.getFin_contrato().getTime()));
            String estado = gerente.getEstado().toString();
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
            cs.setInt("_fid_sede", gerente.getSede().getId_sede());
            cs.setString("_usurname", gerente.getUsername());
            cs.setString("_password", gerente.getPassword());
            cs.setDate("_inicio_cargo", new java.sql.Date(gerente.getFecha_inicio_cargo().getTime()));

            resultado = cs.executeUpdate();
            gerente.setId_persona(cs.getInt("_id_persona"));
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public int eliminar(int id_gerente) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call EMPLEADO_ELIMINAR(?)}");
            cs.setInt("_fid_empleado",id_gerente);
            
            resultado = cs.executeUpdate();
            
            cs.close();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

}
