using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Repsitory.DoctorRepo
{
    public interface IDoctorRepository : IGenericRepository<Doctor, DoctorId>
    {
    }
}
