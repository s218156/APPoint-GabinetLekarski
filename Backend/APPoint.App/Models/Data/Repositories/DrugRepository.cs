namespace APPoint.App.Models.Data.Repositories
{
    public class DrugRepository : Repository<Drug>, IDrugRepository
    {
        public DrugRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
