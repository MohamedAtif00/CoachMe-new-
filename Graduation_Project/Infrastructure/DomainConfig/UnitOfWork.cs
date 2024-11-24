using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Repsitory.AddMedicalAdvisorRepo;
using Graduation_Project.Domain.Repsitory.ChatRepo;
using Graduation_Project.Domain.Repsitory.PlanRepo;
using Graduation_Project.Domain.Repsitory.RefreshTokenRepo;
using Graduation_Project.Domain.Repsitory.ReservationRepo;
using Graduation_Project.Domain.Repsitory.TrainerRepo;
using Graduation_Project.Domain.Repsitory.UserRepo;
using Graduation_Project.Infrastructure.Data;

namespace Graduation_Project.Infrastructure.DomainConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext, IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, ITrainerRepository trainerRepository, ITrainerRatingRepository trainerRatingRepository, IReservationRepository reservationRepository, IPlanRepository PlanRepository, IChatRepository chatRepository, IMedicalAdvisorRepository medicalAdvisorRepository)
        {
            _applicationDbContext = applicationDbContext;

            RefreshTokenRepository = refreshTokenRepository;
            UserRepository = userRepository;
            TrainerRepository = trainerRepository;
            TrainerRatingRepository = trainerRatingRepository;
            ReservationRepository = reservationRepository;
            this.PlanRepository = PlanRepository;
            ChatRepository = chatRepository;
            MedicalAdvisorRepository = medicalAdvisorRepository;
        }



        public IRefreshTokenRepository RefreshTokenRepository { get; }
        public IUserRepository UserRepository { get; }
        public ITrainerRepository TrainerRepository { get; }
        public ITrainerRatingRepository TrainerRatingRepository { get; }
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
