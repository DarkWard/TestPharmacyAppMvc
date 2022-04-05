using Pharmacy.DataAccess.Data;
using Pharmacy.DataAccess.Repository.IRepository;
using Pharmacy.Models;

namespace Pharmacy.DataAccess.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly DataProcessor _dp;

        public PatientRepository(string connectionString) : base(connectionString)
        {
            _dp = new DataProcessor(connectionString);
        }

        public void Update(Patient obj)
        {
            _dp.Update(obj);
        }
    }
}