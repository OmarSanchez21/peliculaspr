﻿using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Actor
{
    public class ActorUpdateDto
    {
        public int idactor { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha_de_Nacimiento { get; set; }
        public string? Nacionalidad { get; set; }
    }
}
