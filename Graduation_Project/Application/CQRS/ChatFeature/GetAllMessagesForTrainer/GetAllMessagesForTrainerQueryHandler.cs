using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesForTrainer
{
    public class GetAllMessagesForTrainerQueryHandler : IQueryHandler<GetAllMessagesForTrainerQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMessagesForTrainerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<User>>> Handle(GetAllMessagesForTrainerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _unitOfWork.ChatRepository.GetAllMessagesForTrainer(UserId.Create(request.trainerId));
                return Result.Success(users);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
