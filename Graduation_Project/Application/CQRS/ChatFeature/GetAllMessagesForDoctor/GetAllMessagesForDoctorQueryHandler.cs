using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesForDoctor
{
    public class GetAllMessagesForDoctorQueryHandler : IQueryHandler<GetAllMessagesForDoctorQuery, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMessagesForDoctorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<User>>> Handle(GetAllMessagesForDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _unitOfWork.ChatRepository.GetAllMessagesForDoctor(UserId.Create(request.doctorId));
                return Result.Success(users);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
