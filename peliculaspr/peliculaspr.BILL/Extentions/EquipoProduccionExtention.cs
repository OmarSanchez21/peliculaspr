using peliculaspr.BILL.Dtos.EquipoProduccion;
using peliculaspr.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace peliculaspr.BILL.Extentions
{
    public static class EquipoProduccionExtention
    {
        public static MEquipoProduccion EquipoProduccionFromDtoSave(this EquipoProduccionAddDto addDto)
        {
            MEquipoProduccion mEquipo = new MEquipoProduccion()
            {
                NombreMiembro = addDto.NombreMiembro,
                Rol = addDto.Rol
            };
            return mEquipo;
        }
    }
}