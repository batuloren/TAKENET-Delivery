using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Models.Vehicles;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.VehiclesDTOs;

namespace Transport.Business.Abstract
{
    public interface IVehiclesService
    {
        Task<VehiclesListDTO> GetAll();
        Task<GetVehiclesByIdResponse> GetById(GetVehiclesByIdRequest req);
        Task Add(VehiclesCreateDTO req);
        Task Update(VehiclesUpdateDTO req);
        Task DeleteAsync(Guid id);
        Task<List<GetVehiclesByCarModelResponse>> GetByCarModel(GetVehiclesByCarModelRequest req);
        Task<GetVehiclesByPlateNumberResponse> GetByPlateNumber(GetVehiclesByPlateNumberRequest req);
    }
}
