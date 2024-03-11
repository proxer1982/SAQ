using SAQ.Application.Interfaces;
using SAQ.Infrastructure.Persistence.Interfaces;

namespace SAQ.Application.Services
{
    public class DbApplication : IDbApplication
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreatedDB()
        {
            var respuesta = this._unitOfWork.EnsureCreated();
            return respuesta;
        }
    }
}
