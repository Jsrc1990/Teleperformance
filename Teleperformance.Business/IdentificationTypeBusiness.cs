using System.Collections.Generic;
using Teleperformance.Business.Interfaces;
using Teleperformance.Model;
using Teleperformance.Repository;
using TransversalLibrary;

namespace Teleperformance.Business
{
    /// <summary>
    /// Define la lógica
    /// </summary>
    public class IdentificationTypeBusiness : BaseBusiness, IIdentificationTypeBusiness
    {
        /// <summary>
        /// Define el repositorio
        /// </summary>
        private readonly IdentificationTypeRepository IdentificationTypeRepository;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public IdentificationTypeBusiness()
        {
            IdentificationTypeRepository = new IdentificationTypeRepository();
        }

        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        public Response<IEnumerable<IdentificationType>> Consultar(string valor)
        {
            return IdentificationTypeRepository?.Consultar(valor);
        }

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        public Response<IdentificationType> Insertar(IdentificationType model)
        {
            return IdentificationTypeRepository?.Insertar(model);
        }

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad editada</returns>
        public Response<bool> Editar(IdentificationType model)
        {
            return IdentificationTypeRepository?.Editar(model);
        }

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        public Response<bool> Eliminar(IdentificationType model)
        {
            return IdentificationTypeRepository?.Eliminar(model);
        }
    }
}