using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Collections.Immutable;
using Transport.Business.Abstract;
using Transport.Business.Models.Customers;
using Transport.Business.Models.Shipments;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.ShipmentsDTOs;
using Transport.Entities.Shipments.DTOs;


namespace Transport.Business.Concrete
{
    public class ShipmentsService(IGenericRepository<Shipments> repository, IGenericRepository<Statuses> Statusrepository, IGenericRepository<Customers> customerRepository) : IShipmentsService
    {
        //ADMIN 
        public async Task<ICollection<ShipmentsTableAdminDTO>> GetAllShipments()
        {
            var shipments = await repository.GetAllAsync();
            return await repository.Query()
                    .Include(x => x.Customer)
                    .Include(x => x.Vehicle)
                    .Include(x => x.Driver)
                    .Include(x => x.Status)
                    .Select(x => new ShipmentsTableAdminDTO
                    {
                        id = x.id,
                        trackId = x.trackId,
                        AktifMi = x.AktifMi,
                        CreatedAt = x.CreatedAt,

                        CustomerFullName = x.Customer != null ? x.Customer.FullName : "—",
                        VehiclePlateNumber = x.Vehicle != null ? x.Vehicle.PlakaNumara : "—",
                        DriverFullName = x.Driver != null ? x.Driver.FullName : "—",

                        StatusCode = x.StatusCode,
                        StatusDurum = x.Status != null ? x.Status.Durum : "—",

                        Agirlik = x.Agirlik,
                        LoadAddress = x.LoadAddress,
                        DeliveryAddress = x.DeliveryAddress,
                        ShipmentDate = x.ShipmentDate,

                        Description = x.Description,
                        FeedbackDescription = x.FeedbackDescription,
                    })
                    .ToListAsync();
        }

        public async Task<ShipmentsList_ADMIN_DTO> GetAllAdmin()
        {
            try
            {
                var result = await repository.Query()
                             .Include(x => x.Customer)
                             .Include(x => x.Vehicle)
                             .Include(x => x.Driver)
                             .Include(x => x.Status)
                             .Select(x => new ShipmentsList_ADMIN_Item
                             {
                                 //SHIPMENT

                                 id = x.id,
                                 Agirlik = x.Agirlik,
                                 LoadAddress = x.LoadAddress,
                                 DeliveryAddress = x.DeliveryAddress,
                                 ShipmentDate = x.ShipmentDate,
                                 Description = x.Description,
                                 FeedbackDescription = x.FeedbackDescription,
                                 trackId = x.trackId,
                                 CreatedAt = x.CreatedAt,
                                 AktifMi = x.AktifMi,

                                 //CUSTOMER

                                 CustomerId = x.CustomerId ?? Guid.Empty,
                                 CustomerFullName = x.Customer != null ? x.Customer.FullName : null,
                                 CustomerEmailAddress = x.Customer != null ? x.Customer.Email : null,
                                 CustomerTelephoneNumber = x.Customer != null ? x.Customer.Telefon : null,

                                 //VEHICLE

                                 VehicleId = x.VehicleId,
                                 VehiclePlateNumber = x.Vehicle != null ? x.Vehicle.PlakaNumara : null,
                                 VehicleCarModel = x.Vehicle != null ? x.Vehicle.AracModel : null,
                                 VehicleCarCapacity = x.Vehicle != null ? x.Vehicle.AracKapasite : null,
                                 VehicleCarSize = x.Vehicle != null ? x.Vehicle.AracBoyut : null,

                                 //DRIVER

                                 DriverId = x.DriverId,
                                 DriverFullName = x.Driver != null ? x.Driver.FullName : null,
                                 DriverEmailAddress = x.Driver != null ? x.Driver.Email : null,
                                 DriverTelephoneNumber = x.Driver != null ? x.Driver.Telefon : null,

                                 //STATUS

                                 StatusId = x.StatusId,
                                 StatusCode = x.StatusCode,
                                 StatusDurum = x.Status != null ? x.Status.Durum : null,
                             }).ToListAsync();

                return new ShipmentsList_ADMIN_DTO
                {
                    IsSuccess = true,
                    data = result
                };
            }
            catch (Exception ex)
            {
                return new ShipmentsList_ADMIN_DTO
                {
                    IsSuccess = false,
                    Error = ex.Message,
                    Message = "Shipments listesi alınırken hata oluştu!"
                };
            }
        }

        public async Task<ShipmentsList_ADMIN_Item> GetById(Guid id)
        {
            try
            {
                var result = await repository.Query()
                    .Include(x => x.Customer)
                    .Include(x => x.Vehicle)
                    .Include(x => x.Driver)
                    .Include(x => x.Status)
                    .Where(x => x.id == id)
                    .Select(x => new ShipmentsList_ADMIN_Item
                    {
                        id = x.id,
                        Agirlik = x.Agirlik,
                        LoadAddress = x.LoadAddress,
                        DeliveryAddress = x.DeliveryAddress,
                        ShipmentDate = x.ShipmentDate,
                        Description = x.Description,
                        FeedbackDescription = x.FeedbackDescription,
                        trackId = x.trackId,
                        CreatedAt = x.CreatedAt,
                        AktifMi = x.AktifMi,

                        CustomerId = x.CustomerId ?? Guid.Empty,
                        CustomerFullName = x.Customer != null ? x.Customer.FullName : null,
                        CustomerEmailAddress = x.Customer != null ? x.Customer.Email : null,
                        CustomerTelephoneNumber = x.Customer != null ? x.Customer.Telefon : null,

                        VehicleId = x.VehicleId,
                        VehiclePlateNumber = x.Vehicle != null ? x.Vehicle.PlakaNumara : null,
                        VehicleCarModel = x.Vehicle != null ? x.Vehicle.AracModel : null,
                        VehicleCarCapacity = x.Vehicle != null ? x.Vehicle.AracKapasite : null,
                        VehicleCarSize = x.Vehicle != null ? x.Vehicle.AracBoyut : null,

                        DriverId = x.DriverId,
                        DriverFullName = x.Driver != null ? x.Driver.FullName : null,
                        DriverEmailAddress = x.Driver != null ? x.Driver.Email : null,
                        DriverTelephoneNumber = x.Driver != null ? x.Driver.Telefon : null,

                        StatusId = x.StatusId,
                        StatusCode = x.StatusCode,
                        StatusDurum = x.Status != null ? x.Status.Durum : null,
                    })
                    .FirstOrDefaultAsync();

                if (result == null)
                    throw new Exception($"ID: {id} bulunamadı");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("GetById hatası: " + ex.Message);
            }
        }
        public async Task<string> Add(ShipmentsCreateDTO req)
        {
            var trackingCode = "TR" + new Random().Next(100000000, 999999999).ToString();

            var shipment = new Shipments
            {
                LoadAddress = req.LoadAddress,
                DeliveryAddress = req.DeliveryAddress,
                Description = req.Description,
                CustomerId = req.CustomerId, 
                trackId = trackingCode,
                ShipmentDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                AktifMi = true,
                StatusCode = 100,
                StatusId = await Statusrepository.Query().Where(s => s.StatusCode == 100).Select(s => s.id).FirstOrDefaultAsync()
            };
            
            await repository.AddAsync(shipment);
            await repository.SaveAsync();

            return shipment.trackId;
        }
        public async Task Update(Guid id, ShipmentsUpdateDTO req)
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Belirtilen " + id + " ID numarasına sahip kargo bulunamadı!");

            var status = await Statusrepository.Query().FirstOrDefaultAsync(x => x.StatusCode == req.StatusCode);
            if (status == null) throw new Exception("Status not found!");

            existing.VehicleId = req.VehicleId;
            existing.DriverId = req.DriverId;
            existing.StatusCode = status.StatusCode;
            existing.StatusId = status.id;
            existing.Agirlik = req.Agirlik;
            existing.AktifMi = req.AktifMi;
            existing.FeedbackDescription = req.FeedbackDescription;

            await repository.Update(existing);
            await repository.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        public async Task<GetShipmentsByCustomerEmailResponse> GetByCustomerEmail(GetShipmentsByCustomerEmailRequest req)
        {
            var customer = await customerRepository.Query().FirstOrDefaultAsync(w => w.Email == req.CustomerEmail);
            if (customer == null) throw new Exception("Belirtilen " + req.CustomerEmail + " mail adresine sahip customer bulunamamıştır!");

            var shipments = await repository.Query()
                                                   .Include(x => x.Vehicle)
                                                   .Include(x => x.Driver)
                                                   .Include(x => x.Status)
                                                   .Where(x => x.CustomerId == customer.id)
                                                   .Select(x => new ShipmentsList_ADMIN_Item
                                                   {
                                                       id = x.id,
                                                       Agirlik = x.Agirlik,
                                                       LoadAddress = x.LoadAddress,
                                                       DeliveryAddress = x.DeliveryAddress,
                                                       ShipmentDate = x.ShipmentDate,
                                                       Description = x.Description,
                                                       FeedbackDescription = x.FeedbackDescription,
                                                       trackId = x.trackId,
                                                       CreatedAt = x.CreatedAt,
                                                       AktifMi = x.AktifMi,

                                                       CustomerId = x.CustomerId ?? Guid.Empty,
                                                       CustomerFullName = x.Customer != null ? x.Customer.FullName : null,
                                                       CustomerEmailAddress = x.Customer != null ? x.Customer.Email : null,
                                                       CustomerTelephoneNumber = x.Customer != null ? x.Customer.Telefon : null,

                                                       VehicleId = x.VehicleId,
                                                       VehiclePlateNumber = x.Vehicle != null ? x.Vehicle.PlakaNumara : null,
                                                       VehicleCarModel = x.Vehicle != null ? x.Vehicle.AracModel : null,
                                                       VehicleCarCapacity = x.Vehicle != null ? x.Vehicle.AracKapasite : null,
                                                       VehicleCarSize = x.Vehicle != null ? x.Vehicle.AracBoyut : null,

                                                       DriverId = x.DriverId,
                                                       DriverFullName = x.Driver != null ? x.Driver.FullName : null,
                                                       DriverEmailAddress = x.Driver != null ? x.Driver.Email : null,
                                                       DriverTelephoneNumber = x.Driver != null ? x.Driver.Telefon : null,

                                                       StatusId = x.StatusId,
                                                       StatusCode = x.StatusCode,
                                                       StatusDurum = x.Status != null ? x.Status.Durum : null,
                                                   })
                                                   .ToListAsync();

            return new GetShipmentsByCustomerEmailResponse
            {
                CustomerEmailAddress = customer.Email,
                CustomerName = customer.FullName,
                Shipments = shipments
            };

        }

        //USER

        public async Task<GetShipmentsByTrackIdResponse> GetByTrackId(GetShipmentsByTrackIdRequest req)
        {
            var result = await repository.Query()
                                         .Include(x => x.Driver)
                                         .FirstOrDefaultAsync(w => w.trackId == req.trackId);

            if (result == null) throw new Exception("Belirtilen takip numarasına sahip kargo bulunamadı!");

            return new GetShipmentsByTrackIdResponse
            {
                agirlik = result.Agirlik,
                driverFullName = result.Driver != null ? result.Driver.FullName : null,
                loadAddress = result.LoadAddress,
                deliveryAddress = result.DeliveryAddress,
                statusDurum = Statusrepository.Query().Where(s => s.StatusCode == result.StatusCode).Select(s => s.Durum).FirstOrDefault(),
                shipmentDate = result.ShipmentDate,
            };

        }
    }
}
