package pe.edu.pucp.LibroClubSoft.acciones.dao;

import pe.edu.pucp.LibroClubSoft.acciones.model.Venta;
import java.util.ArrayList;
import java.sql.Date;


public interface VentaDAO {
    public int insertarVentaBuscandoEjemplar(Venta obj);
    public ArrayList<Venta> listar(int id);
    public ArrayList<Venta> listarBusqueda(int sede, String dni, String fecha_desde, String fecha_hasta);
    public Venta buscarPorID(int id);
    public int eliminar(int id);
    int modificarVentaIgualProducto(Venta venta);
    int modificarVentaDiferenteProducto(Venta venta);
}


