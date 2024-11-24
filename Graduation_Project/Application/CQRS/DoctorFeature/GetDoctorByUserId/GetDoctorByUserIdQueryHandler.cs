using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetDoctorByUserId
{
    public class GetDoctorByUserIdQueryHandler : IQueryHandler<GetDoctorByUserIdQuery, Doctor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Doctor>> Handle(GetDoctorByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.userId));

                if (doctor == null) return Result.Error("doctor is not exist");

                return Result.Success(doctor);
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
