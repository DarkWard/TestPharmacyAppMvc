using Pharmacy.Models;

namespace Pharmacy.DataAccess.Repository.IRepository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient obj);
    }
}