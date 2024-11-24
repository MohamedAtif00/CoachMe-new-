using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessaagesForTrainee
{
    public class GetAllMessagesForTraineeQueryHandler : IQueryHandler<GetAllMessagesForTraineeQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMessagesForTraineeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<User>>> Handle(GetAllMessagesForTraineeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _unitOfWork.ChatRepository.GetAllMessagesForTrainee(UserId.Create(request.userId));
                return Result.Success(users);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }

        }
    }
}
