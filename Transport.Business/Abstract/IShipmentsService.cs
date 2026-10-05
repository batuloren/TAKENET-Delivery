using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Models.Shipments;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.ShipmentsDTOs;
using Transport.Entities.Shipments.DTOs;

namespace Transport.Business.Abstract
{
    public interface IShipmentsService
    {
        //ADMIN
        
        Task<ICollection<ShipmentsTableAdminDTO>> GetAllShipments();
        Task<ShipmentsList_ADMIN_DTO> GetAllAdmin();
        Task<ShipmentsList_ADMIN_Item> GetById(Guid id);
        Task<string> Add(ShipmentsCreateDTO req);
        Task Update(Guid id, ShipmentsUpdateDTO req);
        Task Delete(Guid id);
        Task<GetShipmentsByCustomerEmailResponse> GetByCustomerEmail(GetShipmentsByCustomerEmailRequest req);

        //USER

        Task<GetShipmentsByTrackIdResponse> GetByTrackId(GetShipmentsByTrackIdRequest req);

    }
}
