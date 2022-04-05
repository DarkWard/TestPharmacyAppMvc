using Pharmacy.DataAccess.Data;
using Pharmacy.DataAccess.Repository.IRepository;
using Pharmacy.Models;

namespace Pharmacy.DataAccess.Repository
{
    public class PharmaciesRepository : Repository<Pharmacies>, IPharmaciesRepository
    {
        private readonly DataProcessor _dp;

        public PharmaciesRepository(string connectionString) : base(connectionString)
        {
            _dp = new DataProcessor(connectionString);
        }

        public void Update(Pharmacies obj)
        {
            _dp.Update(obj);
        }
    }
}