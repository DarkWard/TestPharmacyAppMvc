using Pharmacy.Models;

namespace Pharmacy.DataAccess.Repository.IRepository
{
    public interface IPharmaciesRepository : IRepository<Pharmacies>
    {
        void Update(Pharmacies obj);
    }
}