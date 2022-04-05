namespace Pharmacy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get; }
        IPharmaciesRepository Pharmacy { get; }
    }
}