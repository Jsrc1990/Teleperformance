using Microsoft.AspNetCore.Cors;
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
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Define la lógica
        /// </summary>
        private readonly IUserBusiness UserBusiness;

        /// <summary>
        /// Inicializa las propiedades de esta clase
        /// </summary>
        /// <param name="userBusiness"></param>
        public UserController(IUserBusiness userBusiness)
        {
            UserBusiness = userBusiness;
        }

        /// <summary>
        /// Consulta las entidades
        /// </summary>
        /// <param name="valor"></param>
        /// <returns>Las entidades</returns>
        //[EnableCors("CorsPolicy")]
        [HttpGet]
        [Route("api/User/Consultar")]
        public Response<IEnumerable<User>> Consultar(string valor = "")
        {
            Response<IEnumerable<User>> response = UserBusiness?.Consultar(valor);
            return response;
        }

        /// <summary>
        /// Inserta la entidad
        /// </summary>
        /// <param name="User">La entidad</param>
        /// <returns>La entidad insertada con su nuevo Id</returns>
        [HttpPost]
        [Route("api/User/Insertar")]
        public Response<User> Insertar([FromBody] User User)
        {
            Response<User> response = UserBusiness?.Insertar(User);
            return response;
        }

        /// <summary>
        /// Edita la entidad
        /// </summary>
        /// <param name="User">La entidad</param>
        /// <returns>La entidad editada</returns>
        [HttpPost]
        [Route("api/User/Editar")]
        public Response<bool> Put([FromBody] User User)
        {
            Response<bool> response = UserBusiness?.Editar(User);
            return response;
        }

        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="id">La entidad</param>
        /// <returns>La entidad eliminada</returns>
        [HttpPost]
        [Route("api/User/Eliminar")]
        public Response<bool> Delete(string id)
        {
            Response<bool> response = UserBusiness?.Eliminar(new User()
            {
                Id = id
            });
            return response;
        }
    }
}
