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
    public class UserBusiness : BaseBusiness, IUserBusiness
    {
        /// <summary>
        /// Define el repositorio
        /// </summary>
        private readonly UserRepository UserRepository;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        public UserBusiness()
        {
            UserRepository = new UserRepository();
        }

        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        public Response<IEnumerable<User>> Consultar(string valor)
        {
            return UserRepository?.Consultar(valor);
        }

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        public Response<User> Insertar(User model)
        {
            return UserRepository?.Insertar(model);
        }

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad editada</returns>
        public Response<bool> Editar(User model)
        {
            return UserRepository?.Editar(model);
        }

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        public Response<bool> Eliminar(User model)
        {
            return UserRepository?.Eliminar(model);
        }
    }
}