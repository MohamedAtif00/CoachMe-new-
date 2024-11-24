using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.MedicalAdvisorDomain;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.ReservationDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ReservationFeature.AddMedicalAdvisorReservation
{
    public class AddMedicalAdvisorReservationCommandHandler : ICommandHandler<AddMedicalAdvisorReservationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMedicalAdvisorReservationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddMedicalAdvisorReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var reservation = await _unitOfWork.ReservationRepository.Add(Reservation.Create(
                                                                                                TrainerId.Create(request.trainerId),
                                                                                                UserId.Create(request.trainee),
                                                                                                planId.Create(request.planId)
                                                                                                )
                                                                                );


                // Send Message with plan name to the trainer
                var plan = await _unitOfWork.PlanRepository.GetById(planId.Create(request.planId));

                var medical = await _unitOfWork.MedicalAdvisorRepository.GetById(MedicalAdvisorId.Create(request.trainerId));

                var chat = Chat.Create(UserId.Create(request.trainee),
                                       UserId.Create(request.trainerId),
                                       $"Hi Doctor {medical.Username} I wanna Participate in {plan.Name} Plan");


                var message = await _unitOfWork.ChatRepository.Add(chat);


                int saving = await _unitOfWork.save();
                if (saving == 0) { return Result.Error("No changes"); }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
