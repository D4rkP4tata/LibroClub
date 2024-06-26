package pe.edu.pucp.LibroClubSoft.config;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBManager {
    private static DBManager dbManager;
    private Connection con;

    
    private String host = "testproyecto.cqxkdy1zpc6u.us-east-1.rds.amazonaws.com";
    private String port = "3306";
    private String db = "testproyecto";
    private String username = "admin";
    private String password = "20213707";
    
    private DBManager(){
        connectToDatabase();
    }
    
    private void connectToDatabase(){
        try{
            Class.forName("com.mysql.cj.jdbc.Driver");
            String url = "jdbc:mysql://"+host + ":" + port + "/" + db + "?useSSL=false"; 
            this.con = DriverManager.getConnection(url, username, password);    
            System.out.println("....conexion realizada...");
        }catch(ClassNotFoundException | SQLException ex){
            System.out.println(ex.getMessage());
        }
    }
    
    public Connection getConnection() throws SQLException{
        if(con == null || con.isClosed())
            connectToDatabase();
        return con;
    }
    
    public synchronized static DBManager getInstance(){
        if(dbManager == null){
             dbManager = new DBManager();
        }
        return dbManager;
    }   
}
