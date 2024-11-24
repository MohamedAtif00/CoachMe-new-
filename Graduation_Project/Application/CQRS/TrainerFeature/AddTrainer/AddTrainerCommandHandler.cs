using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.AddDoctor
{
    public class AddDoctorCommandHandler : ICommandHandler<AddDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                byte[] file;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    request.image.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }


                var result = await _unitOfWork.DoctorRepository.Add(Doctor.Create(request.userId,request.username,file,request.email,request.about)); 

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no changes");

                return Result.Success();
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
