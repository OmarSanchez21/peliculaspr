﻿using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.LocacionesFilmaciones
{
    public class LocacionesFilmacionesUpdateDto
    {
        public int idlocacion { get; set; }
        public string? NombreLocacion { get; set; }
        public string? Direccion { get; set; }
    }
}
