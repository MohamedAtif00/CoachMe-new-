using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Repsitory.AddMedicalAdvisorRepo;
using Graduation_Project.Domain.Repsitory.ChatRepo;
using Graduation_Project.Domain.Repsitory.DoctorRepo;
using Graduation_Project.Domain.Repsitory.PlanRepo;
using Graduation_Project.Domain.Repsitory.RefreshTokenRepo;
using Graduation_Project.Domain.Repsitory.ReservationRepo;
using Graduation_Project.Domain.Repsitory.UserRepo;
using Graduation_Project.Infrastructure.Data;

namespace Graduation_Project.Infrastructure.DomainConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, IDoctorRepository doctorRepository, IDoctorRatingRepository doctorRatingRepository, IReservationRepository reservationRepository, IPlanRepository PlanRepository, IChatRepository chatRepository, IMedicalAdvisorRepository medicalAdvisorRepository)
        {
            _applicationDbContext = applicationDbContext;

            RefreshTokenRepository = refreshTokenRepository;
            UserRepository = userRepository;
            DoctorRepository = doctorRepository;
            DoctorRatingRepository = doctorRatingRepository;
            ReservationRepository = reservationRepository;
            this.PlanRepository = PlanRepository;
            ChatRepository = chatRepository;
            MedicalAdvisorRepository = medicalAdvisorRepository;
        }



        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IUserRepository UserRepository { get; }
        public IDoctorRepository DoctorRepository { get; }
        public IDoctorRatingRepository DoctorRatingRepository { get; }
        public IReservationRepository ReservationRepository { get; }
        public IMedicalAdvisorRepository MedicalAdvisorRepository { get; }
        public IPlanRepository PlanRepository { get; }
        public IChatRepository ChatRepository { get; }

        public async Task<int> save()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }
    }

}
