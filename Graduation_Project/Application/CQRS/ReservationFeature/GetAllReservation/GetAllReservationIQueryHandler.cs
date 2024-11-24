using Ardalis.Result;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Domain.Abstraction;
using Graduation_Project.Domain.Entity.ReservationDomain;

namespace Graduation_Project.Application.CQRS.ReservationFeature.GetAllReservation
{
    public class GetAllReservationIQueryHandler : IQueryHandler<GetAllReservationIQuery, List<Reservation>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReservationIQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Reservation>>> Handle(GetAllReservationIQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _unitOfWork.ReservationRepository.GetAll();

                return Result.Success(result);
            }catch (Exception ex)
            {
                return Result.Error("System Error");
            }
        }
    }
}
