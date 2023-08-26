using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Dtos.Critico
{
    public class CriticoRemoveDto
    {
        public int idcritico { get; set; }
        public string? Nombre { get; set; }
        public string? MedioComuncacion { get; set; }
    }
}
