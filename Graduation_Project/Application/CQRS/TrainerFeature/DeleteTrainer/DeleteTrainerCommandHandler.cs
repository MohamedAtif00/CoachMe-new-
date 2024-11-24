using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.DoctorDomain;

namespace Graduation_Project.Application.CQRS.DoctorFeature.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : ICommandHandler<DeleteDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _unitOfWork.DoctorRepository.GetById(DoctorId.Create(request.id));

                if (doctor == null) return Result.Error("doctor is not exist");

                await _unitOfWork.DoctorRepository.Delete(doctor);

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
