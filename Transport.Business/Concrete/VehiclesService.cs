using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Models.Vehicles;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.VehiclesDTOs;

namespace Transport.Business.Concrete
{
    public class VehiclesService(IGenericRepository<Vehicles> repository) : IVehiclesService
    {
        public async Task<VehiclesListDTO> GetAll()
        {
            try
            {
                var result = await repository.GetAllAsync();

                return new VehiclesListDTO()
                {
                    IsSuccess = true,
                    data = [.. result.Select(s => new VehiclesListItem { Id = s.id,
                                                                         PlakaNumara = s.PlakaNumara,
                                                                         AracModel = s.AracModel,
                                                                         AracBoyut = s.AracBoyut,
                                                                         AracKapasite = s.AracKapasite,
                                                                         AktifMi = s.AktifMi })]
                };
            }
            catch (Exception ex)
            {

                return new VehiclesListDTO { IsSuccess = false, Message = ex.Message };
            }
        }

     public async Task<GetVehiclesByIdResponse> GetById(GetVehiclesByIdRequest req)
        {
            if (req?.Id is null || req.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(req.Id));

            var result = await repository.GetByIdAsync(req.Id.Value);

            if (result == null) throw new Exception("Sürücü bulunamadı!");

            return new GetVehiclesByIdResponse
            {
                PlakaNumara = result.PlakaNumara,
                AracModel = result.AracModel,
                AracBoyut = result.AracBoyut,
                AracKapasite = result.AracKapasite,
                AktifMi = result.AktifMi
            };
        }

     public async Task Add(VehiclesCreateDTO req)
        {
            var vehicle = new Vehicles
            {
                id = Guid.NewGuid(),
                PlakaNumara = req.PlakaNumara,
                AracModel = req.AracModel,
                AracBoyut = req.AracBoyut,
                AracKapasite = req.AracKapasite,
                AktifMi = req.AktifMi

            };

            await repository.AddAsync(vehicle);
            await repository.SaveAsync();

        }

     public async Task Update(VehiclesUpdateDTO req)
        {
            var existing = await repository.GetByIdAsync(req.Id);
            if (existing == null) throw new Exception(nameof(req.Id));

            existing.PlakaNumara = req.PlakaNumara;
            existing.AracModel = req.AracModel;
            existing.AracBoyut = req.AracBoyut;
            existing.AracKapasite = req.AracKapasite;
            existing.AktifMi = req.AktifMi;

            await repository.Update(existing);
            await repository.SaveAsync();
        }

     public async Task DeleteAsync(Guid id)
        {
            var result = await repository.GetByIdAsync(id);
            if (result == null) throw new Exception("Araç bulunamadı!");
            await repository.DeleteAsync(id);
        }

     public async Task<List<GetVehiclesByCarModelResponse>> GetByCarModel(GetVehiclesByCarModelRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.AracModel))
                return new List<GetVehiclesByCarModelResponse>();

            var result = await repository.GetWhereAsync(w => w.AracModel == req.AracModel);

            if (result == null || !result.Any())
                return new List<GetVehiclesByCarModelResponse>();

            return result
                .Select(s => new GetVehiclesByCarModelResponse
                {
                    PlakaNumara = s.PlakaNumara,
                    AracKapasite = s.AracKapasite,
                    AracBoyut = s.AracBoyut,
                    AktifMi = s.AktifMi
                })
                .ToList();
        }

     public async Task<GetVehiclesByPlateNumberResponse> GetByPlateNumber(GetVehiclesByPlateNumberRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.PlakaNumara))
                return new GetVehiclesByPlateNumberResponse();

            var result = await repository.GetWhereAsync(w => w.PlakaNumara == req.PlakaNumara);

            var vehicle = result.FirstOrDefault();

            if (vehicle == null)
                return new GetVehiclesByPlateNumberResponse();

            return new GetVehiclesByPlateNumberResponse
            {
                AracModel = vehicle.AracModel,
                AracKapasite = vehicle.AracKapasite,
                AracBoyut = vehicle.AracBoyut,
                AktifMi = vehicle.AktifMi
            };
        }
    }
}
