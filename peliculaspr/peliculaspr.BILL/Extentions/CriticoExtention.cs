using peliculaspr.BILL.Dtos.Critico;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class CriticoExtention
    {
        public static MCritico GetCriticoFromDtoSave(this CriticoAddDto addDto) 
        {
            MCritico critico = new MCritico()
            {
                idcritico = addDto.idcritico,
                Nombre = addDto.Nombre,
                MedioComuncacion = addDto.MedioComuncacion
            };
            return critico;
        }
    }
}
