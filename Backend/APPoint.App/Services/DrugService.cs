using APPoint.App.Models.Data;
using APPoint.App.Models.Data.Repositories;

namespace APPoint.App.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugRepository.GetAll();
        }
    }
}
