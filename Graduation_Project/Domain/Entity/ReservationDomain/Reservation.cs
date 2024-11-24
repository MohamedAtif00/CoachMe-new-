using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.PlanDomain;
using Graduation_Project.Domain.Entity.DoctorDomain;
using Graduation_Project.Domain.Entity.UserDomain;
using System.Numerics;

namespace Graduation_Project.Domain.Entity.ReservationDomain
{
    public class Reservation : Entity<ReservationId>
    {
        public Reservation(ReservationId id, DoctorId doctorId, UserId patient, planId planId) : base(id)
        {
            DoctorId = doctorId;
            Patient = patient;
            PlanId = planId;
        }

        public DoctorId DoctorId { get; set; }
        public UserId Patient { get; set; }
        public planId PlanId { get; set; }
        public DateTime ReservedDate { get; init; }  = DateTime.Now;

        public static Reservation Create(DoctorId doctorId, UserId patient, planId planId)
        {
            return new(ReservationId.CreateUnique(), doctorId, patient, planId);
        }


    }
}
