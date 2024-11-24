using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Domain.Repsitory.DoctorRepo
{
    public interface IDoctorRatingRepository : IGenericRepository<DoctorRating, DoctorRatingId>
    {
        Task<List<DoctorRating>> GetAllRatingByDoctorId(DoctorId id);
    }
}
