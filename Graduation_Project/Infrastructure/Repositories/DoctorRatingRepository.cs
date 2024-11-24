using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Repsitory.DoctorRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class DoctorRatingRepository : GenericRepository<DoctorRating, DoctorRatingId>,IDoctorRatingRepository
    {
        public DoctorRatingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<DoctorRating>> GetAllRatingByDoctorId(DoctorId id)
        {
            return await _context.doctorRatings.Where(x => x.DoctorId == id).ToListAsync();
        }
    }
}
