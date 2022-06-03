using APPoint.App.Models.DTO;
using APPoint.App.Models.Data.Repositories;
using APPoint.App.Models.Data;

namespace APPoint.App.Services
{
    public class DrugService : IDrugService
    {
        private readonly IDrugRepository _drugRepository;

        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }

        public async Task<Drug> AddAsync(Drug drug) => await _drugRepository.AddAsync(drug);  

        public IEnumerable<Drug> GetAll() => _drugRepository.GetAll();
    }
}
