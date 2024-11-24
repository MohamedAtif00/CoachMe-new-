using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.PlanFeature.GetAllPlan
{
    public class GetAllPlanQueryHandler : IQueryHandler<GetAllPlanQuery, List<Plan>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPlanQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Plan>>> Handle(GetAllPlanQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var id = UserId.Create(request.id);
                var plans = await _unitOfWork.PlanRepository.GetAllPlanForTrainer(id);



                //trainer.
                return Result.Success(plans);
            }
            catch (Exception ex) {
                return Result.Error("System Error");
            }
        }
    }
}
