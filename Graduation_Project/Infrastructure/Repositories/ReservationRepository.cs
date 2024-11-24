using Graduation_Project.Domain.Entity.ReservationDomain;
using Graduation_Project.Domain.Repsitory.ReservationRepo;
using Graduation_Project.Infrastructure.Data;
using Graduation_Project.Infrastructure.DomainConfig;

namespace Graduation_Project.Infrastructure.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation, ReservationId>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
