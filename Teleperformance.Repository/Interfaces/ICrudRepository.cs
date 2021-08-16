using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransversalLibrary;

namespace Teleperformance.Repository.Interfaces
{
    public interface ICrudRepository<T>
    {
        public Response<IEnumerable<T>> Consultar(string valor);

        public Response<T> Insertar(T model);

        public Response<bool> Editar(T model);

        public Response<bool> Eliminar(T model);
    }
}