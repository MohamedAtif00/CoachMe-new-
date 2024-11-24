using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.PlanFeature.GetPlanByUserId
{
    public class GetPlanByUserIdQueryHandler : IQueryHandler<GetPlanByUserIdQuery, List<Plan>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlanByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Plan>>> Handle(GetPlanByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.userId));

                if (doctor == null) return Result.Error("doctor is not exist");

                var plans = await _unitOfWork.PlanRepository.GetAllPlanForDoctor(UserId.Create( doctor.Id.value));

                return Result.Success(plans);

            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
