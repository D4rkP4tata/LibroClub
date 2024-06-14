﻿using LibroClubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController.DAO
{
    public interface PeliculaDAO
    {
        int insertar(Pelicula pelicula);

        List<Pelicula> lista();

        int eliminar(int id);

        int modificar(int id, Pelicula pelicula);
    }
}
