using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.PlanFeature.AddPlan
{
    public class AddPlanCommandHandler : ICommandHandler<AddPlanCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPlanCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddPlanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var plan = Plan.Create(request.name,request.duration,request.focus,request.sessions,request.price,UserId.Create(request.trainerId));

                await _unitOfWork.PlanRepository.Add(plan);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No changes");
                return Result.Success();
            }catch (Exception ex)
            {
                return Result.Error(ex.ToString());
            }
        }
    }
}
