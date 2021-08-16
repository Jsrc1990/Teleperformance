using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Teleperformance.Business.Interfaces;
using Teleperformance.Model;
using TransversalLibrary;

namespace Teleperformance.WebAPI.Controllers
{
    /// <summary>
    /// Define el controlador
    /// </summary>
    [Route("api/[controller]")]
    [ApiController] 
    public class IdentificationTypeController : ControllerBase
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly IIdentificationTypeBusiness IdentificationTypeBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="identificationTypeBusiness"></param>
        public IdentificationTypeController(IIdentificationTypeBusiness identificationTypeBusiness)
        {
            IdentificationTypeBusiness = identificationTypeBusiness;
        }

        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        [HttpGet]
        [Route("api/IdentificationType/Consultar")]
        public Response<IEnumerable<IdentificationType>> Consultar(string valor = "")
        {
            Response<IEnumerable<IdentificationType>> response = IdentificationTypeBusiness?.Consultar(valor);
            return response;
        }

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="IdentificationType">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        [HttpPost]
        [Route("api/IdentificationType/Insertar")]
        public Response<IdentificationType> Insertar([FromBody] IdentificationType IdentificationType)
        {
            Response<IdentificationType> response = IdentificationTypeBusiness?.Insertar(IdentificationType);
            return response;
        }

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="IdentificationType">La entidad</param>
        /// <returns>La entidad editada</returns>
        [HttpPost]
        [Route("api/IdentificationType/Editar")]
        public Response<bool> Put([FromBody] IdentificationType IdentificationType)
        {
            Response<bool> response = IdentificationTypeBusiness?.Editar(IdentificationType);
            return response;
        }

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="id">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        [HttpPost]
        [Route("api/IdentificationType/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = IdentificationTypeBusiness?.Eliminar(new IdentificationType()
            {
                Id = id
            });
            return response;
        }
    }
}
