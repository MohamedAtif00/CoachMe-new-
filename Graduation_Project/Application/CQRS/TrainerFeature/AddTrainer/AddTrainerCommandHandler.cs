using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using Graduation_Project.Migrations;

namespace Graduation_Project.Application.CQRS.TrainerFeature.AddTrainer
{
    public class AddTrainerCommandHandler : ICommandHandler<AddTrainerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTrainerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddTrainerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                byte[] file;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    request.image.CopyTo(memoryStream);
                    file = memoryStream.ToArray();
                }


                var result = await _unitOfWork.TrainerRepository.Add(Trainer.Create(request.userId,request.username,file,request.email,request.about)); 

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
