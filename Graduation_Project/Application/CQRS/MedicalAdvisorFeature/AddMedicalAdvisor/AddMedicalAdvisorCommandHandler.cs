using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using System;

namespace Graduation_Project.Application.CQRS.MedicalAdvisorFeature.AddMedicalAdvisor
{
    public class AddMedicalAdvisorCommandHandler : ICommandHandler<AddMedicalAdvisorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMedicalAdvisorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddMedicalAdvisorCommand request, CancellationToken cancellationToken)
        {
            try
            {

                byte[] file;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    request.image.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }

                var id = MedicalAdvisorId.Create(request.id);

                var AddMedicalAdvisor = MedicalAdvisor.Create(id,request.username, request.about, file, request.email);

                var result = await _unitOfWork.MedicalAdvisorRepository.Add(AddMedicalAdvisor);

                var saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("no change");

                return Result.Success();

            }
            catch (Exception ex) 
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
