namespace APPoint.App.Models.Data.Repositories
{
    public class PatientInfoRepository : Repository<PatientInfo>, IPatientInfoRepository 
    {
        public PatientInfoRepository(DatabaseContext databaseContext) : base(databaseContext) { }
    }
}
