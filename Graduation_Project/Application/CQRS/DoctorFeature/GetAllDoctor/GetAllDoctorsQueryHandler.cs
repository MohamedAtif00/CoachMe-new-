using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetAllDoctors
{
    public class GetAllDoctorsQueryHandler : IQueryHandler<GetAllDoctorsQuery, List<Doctor>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDoctorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctors = await _unitOfWork.DoctorRepository.GetAll();

                return Result.Success(doctors);
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
