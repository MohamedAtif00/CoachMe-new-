using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Entity.PlanDomain
{
    public class Plan : Entity<planId>
    {
        public Plan(planId id, string name,int duration, string focus, int sessions, decimal price,UserId trainerId) : base(id)
        {
            Name = name;
            Duration = duration;
            Focus = focus;
            Sessions = sessions;
            Price = price;
            TrainerId = trainerId;
        }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Focus { get; set; }
        public int Sessions { get; set; }
        public decimal Price { get; set; }
        public UserId TrainerId { get; set; }


        public static Plan Create(string name,int duration, string focus, int sessions, decimal price,UserId trainerId)
        {
            return new(planId.CreateUnique(),name,duration,focus,sessions,price,trainerId);
        }
    }
}
