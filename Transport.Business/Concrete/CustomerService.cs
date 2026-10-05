using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Transport.Business.Abstract;
using Transport.Business.Models.Customers;
using Transport.Business.Models.Vehicles;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs;
using Transport.Entities.DTOs.CustomersDTOs;

namespace Transport.Business.Concrete
{
    public class CustomersService(IGenericRepository<Customers> repository) : ICustomersService
    {
        public async Task<CustomersListDTO> GetAll()
        {
            try
            {
                var result = await repository.GetAllAsync();

                return new CustomersListDTO
                {
                    IsSuccess = true,

                    data = [.. result.Select(s => new CustomersListItem { Id = s.id ,FullName = s.FullName, Telefon = s.Telefon, Email = s.Email , AktifMi = s.AktifMi })]
                };
            }
            catch(Exception ex){

                return new CustomersListDTO { IsSuccess = false, Message = ex.Message };
            }
        }

    public async Task<GetCustomersByIdResponse> GetById(GetCustomersByIdRequest req)
        {
            if (req.Id == null || req.Id == Guid.Empty) throw new Exception("Eşleşen ID Bulunamadı!");
            var result = await repository.GetByIdAsync(req.Id.Value);
            if (result == null) throw new Exception("Müşteri Bulunamadı!");

            return new GetCustomersByIdResponse
            {
                Ad = result.Ad,
                Soyad = result.Soyad,
                Email = result.Email,
                Telefon = result.Telefon,
                AktifMi = result.AktifMi,

            };    
        }

    public async Task<Guid> Add(CustomersCreateDTO req)
        {
            var existingCustomer = await repository.GetWhereAsync(x => x.Email == req.Email);

            if (existingCustomer.Any())
            {
                throw new Exception("Bu email adresi zaten kayıtlı!");
            }
            
            var customer = new Customers
            {
                id = Guid.NewGuid(),
                Ad = req.Ad,
                Soyad = req.Soyad,
                Email = req.Email,
                Telefon = req.Telefon,
                AktifMi = true
            };

            await repository.AddAsync(customer);
            await repository.SaveAsync();

            return customer.id;
        }

    public async Task Update(Guid id,CustomersUpdateDTO req)
        {
            var existing = await repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Belirtilen" + id + " ID numarasına sahip müşteri bulunamadı!");

            existing.Ad = req.Ad;
            existing.Soyad = req.Soyad;
            existing.Email = req.Email;
            existing.Telefon = req.Telefon;

           await repository.Update(existing);
           await repository.SaveAsync();
          
        }

    public async Task DeleteAsync(Guid id)
        {
            var result = await repository.GetByIdAsync(id);
            if (result == null) throw new Exception("Belirtilen" + id + " ID numarasına sahip müşteri bulunamadı!");
            await repository.DeleteAsync(id);
        }

    public async Task<GetCustomersByEmailResponse> GetByEmail(GetCustomersByEmailRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email))
                return new GetCustomersByEmailResponse();

            var result = await repository.GetWhereAsync(w => w.Email == req.Email);

            var customer = result.FirstOrDefault();

            if (customer == null)
                return new GetCustomersByEmailResponse();

            return new GetCustomersByEmailResponse
            {
                Ad = customer.Ad,
                Soyad = customer.Soyad,
                Telefon = customer.Telefon,
            };
        }

    public async Task<List<GetCustomersByFullNameResponse>> GetByFullName(GetCustomersByFullNameRequest req)
        {

            if (string.IsNullOrWhiteSpace(req.FullName))
                return new List<GetCustomersByFullNameResponse>();

            var result = await repository.GetWhereAsync(
                w => (w.Ad + " " + w.Soyad) == (req.FullName)
            );

            return result?
                .Select(s => new GetCustomersByFullNameResponse
                {
                    Telefon = s.Telefon,
                    Email = s.Email
                })
                .ToList()
                ?? new List<GetCustomersByFullNameResponse>();
        }

    public async Task<GetCustomersByPhoneResponse> GetByPhone(GetCustomersByPhoneRequest req)
        {
            if(string.IsNullOrWhiteSpace(req.Telefon))
        return new GetCustomersByPhoneResponse();

            var result = await repository.GetWhereAsync(w => w.Telefon == req.Telefon);

            var customer = result.FirstOrDefault();

            if (customer == null)
                return new GetCustomersByPhoneResponse();

            return new GetCustomersByPhoneResponse
            {
                Ad = customer.Ad,
                Soyad = customer.Soyad,
            };
        }
    }
}
