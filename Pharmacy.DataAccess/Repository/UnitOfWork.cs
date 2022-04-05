using Pharmacy.DataAccess.Repository.IRepository;

namespace Pharmacy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private const string _connectionString = "Server=localhost\\MSSQLSERVER01;Database=TestPharmacy;Trusted_Connection=True;";

        public UnitOfWork()
        {
            Patients = new PatientRepository(_connectionString);
            Pharmacy = new PharmaciesRepository(_connectionString);
        }

        public IPatientRepository Patients { get; private set; }
        public IPharmaciesRepository Pharmacy { get; private set; }
    }
}