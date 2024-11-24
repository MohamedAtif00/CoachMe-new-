using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.TrainerFeature.GetTrainerByUserId
{
    public class GetTrainerByUserIdQueryHandler : IQueryHandler<GetTrainerByUserIdQuery, Trainer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrainerByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Trainer>> Handle(GetTrainerByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var trainer = await _unitOfWork.TrainerRepository.GetById(TrainerId.Create(request.userId));

                if (trainer == null) return Result.Error("trainer is not exist");

                return Result.Success(trainer);
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
