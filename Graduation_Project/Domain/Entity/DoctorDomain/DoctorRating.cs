using Graduation_Project.Domain.Abstraction;
using System.Text.Json.Serialization;

namespace Graduation_Project.Domain.Entity.DoctorDomain
{
    public class DoctorRating : Entity<DoctorRatingId>
    {
        public DoctorRating(DoctorRatingId id, DoctorId doctorId, Rating rating, string username) : base(id)
        {
            this.DoctorId = doctorId;
            this.rating = rating;
            this.username = username;
        }

        public DoctorId DoctorId { get;private set; }

        public Rating rating { get; private set; }
        public string username { get; private set; }

        public static DoctorRating Create(DoctorId doctorId, Rating rating,string username)
        {
            return new(DoctorRatingId.CreateUnique(),doctorId,rating,username);
        }

        
        



    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rating {
        zero,
        one,
        two,
        three,
        four,
        five
    }
    
}
