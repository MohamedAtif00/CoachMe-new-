using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesWithTrainee
{
    public class GetAllMessagesWithPatientQueryHandler : IQueryHandler<GetAllMessagesWithPatientQuery, List<Chat>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMessagesWithPatientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Chat>>> Handle(GetAllMessagesWithPatientQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var chats = await _unitOfWork.ChatRepository.GetAllMessagesBetweenDoctorAndTrainee(UserId.Create(request.sendId), UserId.Create(request.receiverId));

                return Result.Success(chats);

            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
