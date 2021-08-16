using System;
using System.Collections.Generic;
using System.Linq;
using Teleperformance.Model;
using Teleperformance.Repository.Interfaces;
using TransversalLibrary;

namespace Teleperformance.Repository
{
    /// <summary>
    /// Define el repositorio
    /// </summary>
    public class IdentificationTypeRepository : BaseRepository, IIdentificationTypeRepository
    {
        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        public Response<IEnumerable<IdentificationType>> Consultar(string valor)
        {
            try
            {
                List<IdentificationType> IdentificationTypes = null;
                if (string.IsNullOrWhiteSpace(valor))
                    IdentificationTypes = TeleperformanceContext?.IdentificationTypes?.ToList();
                else
                    IdentificationTypes = TeleperformanceContext?.IdentificationTypes?.Where(x => x.Id == valor)?.ToList();
                return new Response<IEnumerable<IdentificationType>>()
                {
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Data = IdentificationTypes
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<IdentificationType>>()
                {
                    Data = new List<IdentificationType>(),
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        public Response<IdentificationType> Insertar(IdentificationType model)
        {
            try
            {
                if (TeleperformanceContext?.IdentificationTypes?.Any(x => x.Id == model.Id) == false)
                {
                    model.Id = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    TeleperformanceContext?.IdentificationTypes?.Add(model);
                    TeleperformanceContext?.SaveChanges();
                }
                return new Response<IdentificationType>()
                {
                    Data = model
                };
            }
            catch (Exception ex)
            {
                return new Response<IdentificationType>()
                {
                    Data = null,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad editada</returns>
        public Response<bool> Editar(IdentificationType model)
        {
            try
            {
                IdentificationType first = TeleperformanceContext?.IdentificationTypes?.FirstOrDefault(x => x.Id == model.Id);
                if (first != null)
                {
                    first.Name = model?.Name;
                    first.Description = model?.Description;
                    TeleperformanceContext?.SaveChanges();
                }
                return new Response<bool>()
                {
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Data = false,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="model">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        public Response<bool> Eliminar(IdentificationType model)
        {
            try
            {
                IdentificationType first = TeleperformanceContext?.IdentificationTypes?.FirstOrDefault(x => x.Id == model.Id);
                if (first != null)
                {
                    TeleperformanceContext?.IdentificationTypes?.Remove(first);
                    TeleperformanceContext?.SaveChanges();
                }
                return new Response<bool>()
                {
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Data = false,
                    Exception = ex,
                    HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}