using Graduation_Project.Domain.Abstraction;

namespace Graduation_Project.Domain.Entity.MedicalAdvisorDomain
{
    public class MedicalAdvisor : Entity<MedicalAdvisorId>
    {
        public MedicalAdvisor(MedicalAdvisorId id, string username, string about, byte[] image, string email) : base(id)
        {
            Username = username;
            About = about;
            this.image = image;
            Email = email;
        }

        public string Username { get; private set; }
        public string About { get; private set; }
        public byte[] image { get; private set; }
        public double? AvgRating { get; private set; }
        public string Email { get; private set; }

        public static MedicalAdvisor Create(MedicalAdvisorId id,string username, string about, byte[] image, string email)
        {
            return new(id, username, about, image, email);
        }


    }
}
