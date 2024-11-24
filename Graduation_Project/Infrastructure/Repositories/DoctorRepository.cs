using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Graduation_Project.Domain.Repsitory.DoctorRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor, DoctorId>,IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }



    }
}
