using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        public Response<IEnumerable<User>> Consultar(string valor)
        {
            try
            {
                List<User> users = null;
                if (string.IsNullOrWhiteSpace(valor))
                    users = TeleperformanceContext?.Users?
                        .Include(nameof(User.IdentificationType))?
                        .Include(nameof(User.Contact))?.ToList();
                else
                    users = TeleperformanceContext?.Users?
                        .Include(nameof(User.IdentificationType))?
                        .Include(nameof(User.Contact))?
                        .Where(x => x.Id == valor || x.IdentificationNumber == valor)?.ToList();
                return new Response<IEnumerable<User>>()
                {
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                    Data = users
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<User>>()
                {
                    Data = new List<User>(),
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
        public Response<User> Insertar(User model)
        {
            try
            {
                if (TeleperformanceContext?.Users?.Any(x => x.Id == model.Id) == false)
                {
                    model.Id = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    TeleperformanceContext?.Users?.Add(model);
                    TeleperformanceContext?.SaveChanges();
                }
                return new Response<User>()
                {
                    Data = model
                };
            }
            catch (Exception ex)
            {
                return new Response<User>()
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
        public Response<bool> Editar(User model)
        {
            try
            {
                User first = TeleperformanceContext?.Users?.FirstOrDefault(x => x.Id == model.Id);
                if (first != null)
                {
                    first.IdentificationTypeId = model?.IdentificationTypeId;
                    first.IdentificationNumber = model?.IdentificationNumber;
                    first.CompanyName = model?.CompanyName;
                    first.FirstName = model?.FirstName;
                    first.SecondName = model?.SecondName;
                    first.FirstLastName = model?.FirstLastName;
                    first.SecondLastName = model?.SecondLastName;
                    first.Email = model?.Email;
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
        public Response<bool> Eliminar(User model)
        {
            try
            {
                User first = TeleperformanceContext?.Users?.FirstOrDefault(x => x.Id == model.Id);
                if (first != null)
                {
                    TeleperformanceContext?.Users?.Remove(first);
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