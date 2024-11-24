using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace Graduation_Project.Domain.Entity.UserDomain
{
    public class User : Entity<UserId>
    {
        public User() : base(UserId.CreateUnique())
        {
            
        }
        public User(UserId id,string firstName,string secondName  , byte[] image ,Gender gender) : base(id)
        {
            FirstName = firstName;
            SecondName = secondName;
            Image = image;
            Gender = gender;
        }
        public string FirstName { get;private set; }
        public string SecondName { get;private set; }
        public byte[] Image { get; private set; }
        public Gender Gender { get; private set; }
        public TrainerId? TrainerId { get; private set; }

        public static User Create(Guid userId,string firstName,string secondName, byte[] image,Gender gender)
        {
            return new(UserId.Create(userId),firstName,secondName, image,gender);
        }

        public void AddTrainerAndCourt(TrainerId trainerId)
        {
            TrainerId = trainerId;
        }





    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender 
    { 
        male,
        female,
        other
    }
   
}
