using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using System.Numerics;

namespace Graduation_Project.Domain.Entity.ReservationDomain
{
    public class Reservation : Entity<ReservationId>
    {
        public Reservation(ReservationId id, TrainerId trainerId, UserId trainee, planId planId) : base(id)
        {
            TrainerId = trainerId;
            Trainee = trainee;
            PlanId = planId;
        }

        public TrainerId TrainerId { get; set; }
        public UserId Trainee { get; set; }
        public planId PlanId { get; set; }
        public DateTime ReservedDate { get; init; }  = DateTime.Now;

        public static Reservation Create(TrainerId trainerId, UserId trainee, planId planId)
        {
            return new(ReservationId.CreateUnique(), trainerId, trainee, planId);
        }


    }
}
