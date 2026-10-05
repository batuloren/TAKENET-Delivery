using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Models.Customers;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs.CustomersDTOs;

namespace Transport.Business.Abstract
{
    public interface ICustomersService
    {
        Task<CustomersListDTO> GetAll();
        Task<GetCustomersByIdResponse> GetById(GetCustomersByIdRequest req);
        Task<Guid> Add(CustomersCreateDTO req);
        Task Update(Guid id, CustomersUpdateDTO req);
        Task DeleteAsync(Guid id);

        Task<GetCustomersByEmailResponse> GetByEmail(GetCustomersByEmailRequest req);
        Task<List<GetCustomersByFullNameResponse>> GetByFullName(GetCustomersByFullNameRequest req);
        Task<GetCustomersByPhoneResponse> GetByPhone(GetCustomersByPhoneRequest req);
    }
}
