using Teleperformance.Model;

namespace Teleperformance.Business
{
    /// <summary>
    /// Define la clase base de las lógicas
    /// </summary>
    public abstract class BaseBusiness
    {
        /// <summary>
        /// Define el contexto de la base de datos
        /// </summary>
        private readonly TeleperformanceContext TeleperformanceContext;

        /// <summary>
        /// Define el constructor
        /// </summary>
        public BaseBusiness()
        {
            TeleperformanceContext = new TeleperformanceContext();
        }
    }
}