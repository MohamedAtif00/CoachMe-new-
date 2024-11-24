using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.AddRating
{
    public class AddRatingCommandHandler : ICommandHandler<AddRatingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRatingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddRatingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var rating = await _unitOfWork.DoctorRatingRepository.Add(DoctorRating.Create(DoctorId.Create(request.doctorId),request.Rating,request.username));

                int saving1 = await _unitOfWork.save();

                if (saving1 == 0) return Result.Error("no Change");

                var ratings = await _unitOfWork.DoctorRatingRepository.GetAllRatingByDoctorId(DoctorId.Create(request.doctorId));
                var arrayRatings = ratings.ToArray();

                double avg = 0;
                for (int i = 0; i < arrayRatings.Length; i++) // arr.Length should be the same as MaxRate
                {
                    avg += Convert.ToInt32( arrayRatings[i].rating) * (i + 1);
                }
                avg /= arrayRatings.Length;

                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.doctorId));

                doctor.ModifyAvgRating(avg);

                await _unitOfWork.DoctorRepository.Update(doctor);

                int saving2 = await _unitOfWork.save();

                if (saving2 == 0) return Result.Error("no Change");

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.Error("System error");
            }
        }
    }
}
