using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.TrainerDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Domain.Repsitory.TrainerRepo
{
    public interface ITrainerRepository : IGenericRepository<Trainer, TrainerId>
    {
    }
}
