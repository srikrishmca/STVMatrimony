using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using STVMatrimony.Models.APIRequest;
using Microsoft.EntityFrameworkCore;

namespace STVMatrimonyAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        DatawarehouseContext _dbContext;
        public CustomerRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> InsertUpdateCustomer(Customer request)
        {
            try
            {
                if (request.Id > 0)
                {

                    _ = _dbContext.Customer.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                    request.IsActive = true;
                    _ = _dbContext.Customer.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
