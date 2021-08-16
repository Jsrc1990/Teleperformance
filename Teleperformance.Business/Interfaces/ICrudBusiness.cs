using System.Collections.Generic;
using TransversalLibrary;

namespace Teleperformance.Business.Interfaces
{
    /// <summary>
    /// Define la interfaz
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudBusiness<T>
    {
        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        public Response<IEnumerable<T>> Consultar(string valor);

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        public Response<T> Insertar(T model);

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad editada</returns>
        public Response<bool> Editar(T model);

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        public Response<bool> Eliminar(T model);
    }
}