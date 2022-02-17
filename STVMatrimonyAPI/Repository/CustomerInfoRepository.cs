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
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        DatawarehouseContext _dbContext;
        public CustomerInfoRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> InsertUpdateCustomerPhotos(Photos request)
        {
            try
            {
                if (request.Id > 0)
                {

                    _dbContext.Photos.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                  
                    _ = _dbContext.Photos.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Photos> GetCustomerPhotosByCustomerId(int CustomerId)
        {
            var query = _dbContext.Photos.AsNoTracking().Where(i => i.CustomerId == CustomerId);
            return (query != null) ? await query.FirstOrDefaultAsync() : new Photos();
        }

        public async Task<int> InsertUpdateCustomerPreference(Preferences request)
        {
            try
            {
                if (request.Id > 0)
                {

                    _dbContext.Preferences.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {

                    _ = _dbContext.Preferences.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Preferences> GetCustomerPreferenceByCustomerId(int CustomerId)
        {
            var query = _dbContext.Preferences.AsNoTracking().Where(i => i.CustomerId == CustomerId);
            return (query != null) ? await query.FirstOrDefaultAsync() : new Preferences();
        }

    }
}
