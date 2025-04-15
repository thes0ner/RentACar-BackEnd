using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTO;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface IReservationDal : IEntityRepository<Reservation>
    {

        IQueryable<ReservationDetailDto> GetByCustomerId(int customerId);
        IQueryable<ReservationDetailDto> GetByStatus(ReservationStatus status);
        IQueryable<ReservationDetailDto> GetByDateRange(DateTime startDate, DateTime endDate);
        IQueryable<ReservationDetailDto> GetActiveReservations(DateTime currentDate);
        Task<ReservationDetailDto> GetReservationDetailsAsync(int reservationId);
        IQueryable<ReservationDetailDto> GetAllWithDetails();
        IQueryable<ReservationDetailDto> CheckAvailableCars(DateTime startDate, DateTime endDate);
        Task<bool> CreateReservationAsync(CreateReservationDto createReservation);
        Task<bool> CancelReservationAsync(int reservationId);
        Task<bool> UpdateReservationStatusAsync(int reservationId, ReservationStatus status);
    }
}
