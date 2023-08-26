using peliculaspr.BILL.Core;
using peliculaspr.BILL.Dtos.Personaje;
using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Contract
{
    public interface IPersonajeService : IBaseService
    {
        ServiceResult AddPersonaje(PersonajeAddDto personajeAddDto);
        ServiceResult UpdatePersonaje(PersonajeUpdateDto personajeUpdateDto);
        ServiceResult RemovePersonaje(PersonajeRemoveDto personajeRemoveDto);
    }
}
