using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ChatDomain;
using Graduation_Project.Domain.Entity.UserDomain;

namespace Graduation_Project.Application.CQRS.ChatFeature.AddChat
{
    public class AddChatCommandHandler : ICommandHandler<AddChatCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddChatCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chat = Chat.Create(UserId.Create(request.sender), UserId.Create(request.receiver), request.message);

                await _unitOfWork.ChatRepository.Add(chat);

                int saving = await _unitOfWork.save();

                if (saving == 0) return Result.Error("No changes");

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
