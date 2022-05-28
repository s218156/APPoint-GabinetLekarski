using APPoint.App.Models.DTO;
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

        public IEnumerable<DrugDTO> GetAll()
        {
            return _drugRepository
                .GetAll()
                .Select(d => new DrugDTO() 
                {
                    Id = d.Id,
                    Name = d.Name
                });
        }
    }
}
