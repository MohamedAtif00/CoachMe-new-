using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.UpdateDoctor
{
    public class UpdateDoctorCommandHandler : ICommandHandler<UpdateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.id));

                if (doctor == null) return Result.Error("this doctor is not exist");

                byte[] file;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    request.image.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }

                doctor.Update(request.username, file, request.email);

                 await _unitOfWork.DoctorRepository.Update(doctor);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("There is no changes");
                return Result.Success();
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
