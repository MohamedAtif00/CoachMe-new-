using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;

namespace Graduation_Project.Application.CQRS.MedicalAdvisorFeature.GetAllMedicalAdvisor
{
    public class GetAllMeicalAdvisorQueryHandler : IQueryHandler<GetAllMeicalAdvisorQuery, List<MedicalAdvisor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMeicalAdvisorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<MedicalAdvisor>>> Handle(GetAllMeicalAdvisorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var all = await _unitOfWork.MedicalAdvisorRepository.GetAll();

                return Result.Success(all);
            }
            catch (Exception ex) 
            {
                return Result.Error("System Error");
            } 
        }
    }
}
