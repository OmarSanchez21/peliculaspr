﻿using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.MiembroProduccion
{
    public class MiembroProduccionUpdateDto
    {
        public int idmiembro { get; set; }
        public int id_peliculas { get; set; }
        public int id_equipo { get; set; }
    }
}
