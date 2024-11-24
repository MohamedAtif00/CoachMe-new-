using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Application.CQRS.UserFeature.ValidateUser
{
    public class ValidateUserQueryHandler : IQueryHandler<ValidateUserQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValidateUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(ValidateUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAll();

                foreach (var user in users)
                {

                }

                return Result.Success(true);
            }catch (Exception ex)
            {
                return Result.Error(ex.Message);    
            }
        }
    }
}
