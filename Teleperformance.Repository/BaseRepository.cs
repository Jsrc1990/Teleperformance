using Teleperformance.Model;

namespace Teleperformance.Repository
{
    /// <summary>
    /// Define la clase base de las lógicas
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Define el contexto de la base de datos
        /// </summary>
        protected readonly TeleperformanceContext TeleperformanceContext;

        /// <summary>
        /// Define el constructor
        /// </summary>
        public BaseRepository()
        {
            TeleperformanceContext = new TeleperformanceContext();
        }
    }
}