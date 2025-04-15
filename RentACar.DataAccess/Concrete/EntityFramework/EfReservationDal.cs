using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Entities.Enums;
using RentACar.Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfReservationDal : EfEntityRepositoryBase<Reservation, RentACarDbContext>, IReservationDal
    {
        public EfReservationDal(RentACarDbContext context) : base(context)
        {
        }

        // Returns all reservations made by a specific customer based on their customer ID.
        public IQueryable<ReservationDetailDto> GetByCustomerId(int customerId)
        {
            return _context.Reservations
                    .AsNoTracking()
                    .Where(r => r.CustomerId == customerId)
                    .Select(r => new ReservationDetailDto
                    {
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        BrandName = r.Car.Brand.Name,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        DailyPrice = r.Car.DailyPrice,
                        ReservationStatus = r.ReservationStatus,

                    });
        }

        // Returns all reservations that match a specific reservation status (e.g. Pending, Confirmed, Canceled).
        public IQueryable<ReservationDetailDto> GetByStatus(ReservationStatus status)
        {
            return _context.Reservations
                    .AsNoTracking()
                    .Where(r => r.ReservationStatus == status)
                    .Select(r => new ReservationDetailDto
                    {
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        Notes = r.Notes,
                        ReservationStatus = r.ReservationStatus,
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PhoneNumber = r.Customer.PhoneNumber,
                        BrandName = r.Car.Brand.Name,
                        DailyPrice = r.Car.DailyPrice,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    });
        }


        // Returns all reservations that completely fall within the given date range.
        // Only reservations where PickUpDate is on or after startDate AND DropOffDate is on or before endDate will be included.
        public IQueryable<ReservationDetailDto> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Reservations
                    .AsNoTracking()
                    .Where(r => r.PickUpDate >= startDate && r.DropOffDate <= endDate)
                    .Select(r => new ReservationDetailDto
                    {
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        Notes = r.Notes,
                        ReservationStatus = r.ReservationStatus,
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PhoneNumber = r.Customer.PhoneNumber,
                        BrandName = r.Car.Brand.Name,
                        DailyPrice = r.Car.DailyPrice,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    });
        }


        // Returns reservations that are currently active on the given date.
        // An active reservation means the current date falls between PickUpDate and DropOffDate (inclusive).
        public IQueryable<ReservationDetailDto> GetActiveReservations(DateTime currentDate)
        {
            return _context.Reservations
                    .AsNoTracking()
                    .Where(r => r.PickUpDate <= currentDate && r.DropOffDate >= currentDate)
                    .Select(r => new ReservationDetailDto
                    {
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        Notes = r.Notes,
                        ReservationStatus = r.ReservationStatus,
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PhoneNumber = r.Customer.PhoneNumber,
                        BrandName = r.Car.Brand.Name,
                        DailyPrice = r.Car.DailyPrice,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    });
        }

        // Retrieves the details of a single reservation based on the given reservationId. 
        // If the reservation is not found, returns null.
        public async Task<ReservationDetailDto> GetReservationDetailsAsync(int reservationId)
        {
            var reservationDetail = await _context.Reservations
                    .AsNoTracking()
                    .Where(r => r.Id == reservationId)
                    .Select(r => new ReservationDetailDto
                    {
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        Notes = r.Notes,
                        ReservationStatus = r.ReservationStatus,
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PhoneNumber = r.Customer.PhoneNumber,
                        BrandName = r.Car.Brand.Name,
                        DailyPrice = r.Car.DailyPrice,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    }).FirstOrDefaultAsync();


            if (reservationDetail == null)
                return null;

            return reservationDetail;
        }

        // Retrieves all reservations with their details, returning a collection of ReservationDetailDto.
        // This method does not track entities, making it more efficient for read-only operations.
        public IQueryable<ReservationDetailDto> GetAllWithDetails()
        {
            return _context.Reservations
                    .AsNoTracking()
                    .Select(r => new ReservationDetailDto
                    {
                        PickUpDate = r.PickUpDate,
                        DropOffDate = r.DropOffDate,
                        TotalPrice = r.TotalPrice,
                        Notes = r.Notes,
                        ReservationStatus = r.ReservationStatus,
                        FullName = r.Customer.FirstName + " " + r.Customer.LastName,
                        Email = r.Customer.Email,
                        PhoneNumber = r.Customer.PhoneNumber,
                        BrandName = r.Car.Brand.Name,
                        DailyPrice = r.Car.DailyPrice,
                        Model = r.Car.Model,
                        Plate = r.Car.Plate,
                        CreatedDate = r.CreatedDate,
                        UpdatedDate = r.UpdatedDate
                    });
        }


        public async Task<bool> CreateReservationAsync(CreateReservationDto createReservation)
        {

            var reservation = new Reservation
            {
                CarId = createReservation.CarId,
                CustomerId = createReservation.CustomerId,
                PickUpDate = createReservation.PickUpDate,
                DropOffDate = createReservation.DropOffDate,
                ReservationStatus = createReservation.Status
            };

            //Total price calculation will be done in the business layer

            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();

            return true;

        }
        public IQueryable<ReservationDetailDto> CheckAvailableCars(DateTime startDate, DateTime endDate)
        {
            return _context.Cars
                    .AsNoTracking()
                       .Where(c => !_context.Reservations
                            .Any(r => r.CarId == c.Id && !(r.DropOffDate < startDate || r.PickUpDate > endDate)))
                               .Select(c => new ReservationDetailDto
                               {
                                   BrandName = c.Brand.Name,
                                   DailyPrice = c.DailyPrice,
                                   Model = c.Model,
                                   Plate = c.Plate,
                                   Year = c.Year,
                                   Mileage = c.Mileage

                               }).AsQueryable();
        }
        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            //Find the reservation by ID
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);

            //If reservation not found, return false
            if (reservation == null)
                return false;

            //Set the reservation status to cancelled
            reservation.ReservationStatus = ReservationStatus.Cancelled;
            reservation.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateReservationStatusAsync(int reservationId, ReservationStatus status)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == reservationId);

            if (reservation == null)
                return false;


            switch (status)
            {
                case ReservationStatus.Pending:
                    reservation.ReservationStatus = ReservationStatus.Pending;
                    reservation.UpdatedDate = DateTime.UtcNow;
                    break;

                case ReservationStatus.Confirmed:
                    reservation.ReservationStatus = ReservationStatus.Confirmed;
                    reservation.UpdatedDate = DateTime.UtcNow;
                    break;

                case ReservationStatus.Cancelled:
                    reservation.ReservationStatus = ReservationStatus.Cancelled;
                    reservation.UpdatedDate = DateTime.UtcNow;
                    break;

                case ReservationStatus.Completed:
                    reservation.ReservationStatus = ReservationStatus.Completed;
                    reservation.UpdatedDate = DateTime.UtcNow;
                    break;

                default:
                    reservation.ReservationStatus = ReservationStatus.Pending;
                    reservation.UpdatedDate = DateTime.UtcNow;
                    break;
            }

            return await _context.SaveChangesAsync() > 0;

        }


    }

}

