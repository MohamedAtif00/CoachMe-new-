using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.GetAllRating
{
    public class GetAllRatingQueryHandler : IQueryHandler<GetAllRatingQuery, List<DoctorRating>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRatingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DoctorRating>>> Handle(GetAllRatingQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctors = await _unitOfWork.DoctorRatingRepository.GetAllRatingByDoctorId(DoctorId.Create(request.doctorId));

                return Result.Success(doctors);
                
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
