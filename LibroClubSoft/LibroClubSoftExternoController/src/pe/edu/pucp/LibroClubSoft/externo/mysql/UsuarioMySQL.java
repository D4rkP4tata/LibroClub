package pe.edu.pucp.LibroClubSoft.externo.mysql;

import pe.edu.pucp.LibroClubSoft.externo.dao.UsuarioDAO;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import pe.edu.pucp.LibroClubSoft.config.DBManager;
import pe.edu.pucp.LibroClubSoft.externo.model.TipoMembresia;
import pe.edu.pucp.LibroClubSoft.externo.model.Usuario;

public class UsuarioMySQL implements UsuarioDAO {

    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;

    @Override
    public int insertar(Usuario obj) {
        int resultado = 0;
        System.out.println(obj.getDni());
        System.out.println(obj.getNombre());
        System.out.println(obj.getFecha_nacimiento());
        System.out.println(obj.getSexo());
        System.out.println(obj.getTelefono());
        System.out.println(obj.getMembresia());
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_INSERTAR(?,?,?,?,?,?,?)}");

            cs.registerOutParameter("_id_persona", java.sql.Types.INTEGER);
            cs.setString("_dni", obj.getDni());
            cs.setString("_nombre", obj.getNombre());
            cs.setDate("_fecha_nacimiento", new java.sql.Date(obj.getFecha_nacimiento().getTime()));
            cs.setString("_genero", String.valueOf(obj.getSexo()));
            cs.setInt("_telefono", obj.getTelefono());

            String m = obj.getMembresia().toString();
            int id_membresia;

            switch (m) {
                case "Ninguna":
                    id_membresia = 0;
                    System.out.println("NINGUNA");
                    break;
                case "Plata":
                    id_membresia = 1;
                    System.out.println("PLATA");
                    break;
                case "Oro":
                    id_membresia = 2;
                    System.out.println("ORO");
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_membresia = -1;
                    break;
            }
            cs.setInt("_fid_tipo_membresia", id_membresia);

            cs.executeUpdate();
            obj.setId_persona(cs.getInt("_id_persona"));
            resultado = obj.getId_persona();
            con.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public ArrayList<Usuario> listar() {
        ArrayList<Usuario> usuarios = new ArrayList<>();

        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_LISTAR()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                Usuario usuario = new Usuario();
                usuario.setId_persona(rs.getInt("id_usuario"));
                usuario.setDni(rs.getString("dni"));
                usuario.setNombre(rs.getString("nombre"));
                usuario.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                usuario.setSexo(rs.getString("genero").charAt(0));
                usuario.setTelefono(rs.getInt("telefono"));
                System.out.println(rs.getString("tipo_membresia"));
                usuario.setMembresia(TipoMembresia.valueOf(rs.getString("tipo_membresia")));

                usuarios.add(usuario);
            }
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (SQLException ex) {
                System.out.println(ex.getMessage());
            }
        }
        return usuarios;
    }
    
    @Override
    public ArrayList<Usuario> listarMembresia(int id) {
        ArrayList<Usuario> usuarios = new ArrayList<>();

        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_LISTAR_X_MEMBRESIA(?)}");
            cs.setInt("_id_tipo_membresia", id);
            rs = cs.executeQuery();
            while (rs.next()) {
                Usuario usuario = new Usuario();
                usuario.setId_persona(rs.getInt("id_usuario"));
                usuario.setDni(rs.getString("dni"));
                usuario.setNombre(rs.getString("nombre"));
                usuario.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                usuario.setSexo(rs.getString("genero").charAt(0));
                usuario.setTelefono(rs.getInt("telefono"));
                usuario.setMembresia(TipoMembresia.valueOf(rs.getString("tipo_membresia")));

                usuarios.add(usuario);
            }
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (SQLException ex) {
                System.out.println(ex.getMessage());
            }
        }
        return usuarios;
    }
    
    @Override
    public Usuario ObtenerDni(String dni) {
        Usuario usuario = new Usuario();

        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_OBTENER_X_DNI(?)}");
            cs.setString("_dni", dni);
            rs = cs.executeQuery();
            if (rs.next()) {
                usuario.setId_persona(rs.getInt("id_usuario"));
                usuario.setDni(rs.getString("dni"));
                usuario.setNombre(rs.getString("nombre"));
                usuario.setFecha_nacimiento(rs.getDate("fecha_nacimiento"));
                usuario.setSexo(rs.getString("genero").charAt(0));
                usuario.setTelefono(rs.getInt("telefono"));
                usuario.setMembresia(TipoMembresia.valueOf(rs.getString("tipo_membresia")));
            }
            cs.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (SQLException ex) {
                System.out.println(ex.getMessage());
            }
        }
        return usuario;
    }

    @Override
    public int eliminar(int id) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_ELIMINAR(?)}");
            cs.setInt("_id_persona", id);

            resultado = cs.executeUpdate();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (SQLException ex) {
                System.out.println(ex.getMessage());
            }
        }
        return resultado;
    }

    @Override
    public int modificar(Usuario obj) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();

            cs = con.prepareCall("{call USUARIO_MODIFICAR(?,?,?,?,?,?,?)}");
            cs.setInt("_id_persona", obj.getId_persona());
            cs.setDate("_fecha_nacimiento", new java.sql.Date(obj.getFecha_nacimiento().getTime()));
            cs.setString("_dni", obj.getDni());
            cs.setString("_nombre", obj.getNombre());
            cs.setString("_genero", String.valueOf(obj.getSexo()));
            cs.setInt("_telefono", obj.getTelefono());
//            cs.setDate("_fecha_afiliacion", new java.sql.Date(obj.getFecha_afiliacion().getTime()));

            String m = obj.getMembresia().toString();
            int id_membresia;

            switch (m) {
                case "Ninguna":
                    id_membresia = 0;
                    System.out.println("NINGUNA ");
                    break;
                case "Plata":
                    id_membresia = 1;
                    System.out.println("PLARTA ");
                    break;
                case "Oro":
                    id_membresia = 2;
                    System.out.println("ORO ");
                    break;
                default:
                    // En caso de que el estado no coincida con ninguno de los casos anteriores
                    // Se podría lanzar una excepción, asignar un valor por defecto, o manejarlo de acuerdo a tu lógica de negocio
                    // Aquí simplemente se asigna un valor negativo para indicar un estado no reconocido
                    id_membresia = -1;
                    break;
            }

            cs.setInt("_fid_tipo_membresia", id_membresia);

            resultado = cs.executeUpdate();
            cs.close();
        } catch (SQLException ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @Override
    public ArrayList<Usuario> listarPorNombre(String cadena){
        ArrayList<Usuario> usuarios =  new ArrayList<>();
        try{
            
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call USUARIO_LISTAR_NOMBRE(?)}");
            cs.setString("_nombre",cadena);
            rs = cs.executeQuery();
            while(rs.next()){
                Usuario usuario = new Usuario();
                usuario.setId_persona(rs.getInt("fid_usuario"));
                usuario.setNombre(rs.getString("nombre"));
                usuario.setDni(rs.getString("dni"));
                usuario.setMembresia(TipoMembresia.valueOf(rs.getString("tipo_membresia")));
                
                
                usuarios.add(usuario);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(SQLException ex){System.out.println(ex.getMessage());}
        }
        return usuarios;
    }
}
