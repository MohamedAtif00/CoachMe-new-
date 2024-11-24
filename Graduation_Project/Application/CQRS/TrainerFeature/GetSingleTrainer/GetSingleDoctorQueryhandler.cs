using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetSingleDoctor
{
    public class GetSingleDoctorQueryhandler : IQueryHandler<GetSingleDoctorQuery, Doctor>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSingleDoctorQueryhandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Doctor>> Handle(GetSingleDoctorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.doctorId));

                if (doctor == null) return Result.Error("Doctor is not exist");

                return Result.Success(doctor);

            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
