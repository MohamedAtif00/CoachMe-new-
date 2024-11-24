using Graduation_Project.Domain.Repsitory.AddMedicalAdvisorRepo;
using Graduation_Project.Domain.Repsitory.ChatRepo;
using Graduation_Project.Domain.Repsitory.PlanRepo;
using Graduation_Project.Domain.Repsitory.RefreshTokenRepo;
using Graduation_Project.Domain.Repsitory.ReservationRepo;
using Graduation_Project.Domain.Repsitory.TrainerRepo;
using Graduation_Project.Domain.Repsitory.UserRepo;

namespace Graduation_Project.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        IRefreshTokenRepository RefreshTokenRepository { get; }
        IUserRepository UserRepository { get; }
        ITrainerRepository TrainerRepository { get; }
        ITrainerRatingRepository TrainerRatingRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IPlanRepository PlanRepository { get; }
        IChatRepository ChatRepository { get; }
        IMedicalAdvisorRepository MedicalAdvisorRepository { get; }

        //IRefreshTokenRepository RefreshTokenRepository { get; }

        Task<int> save();
    }
}
