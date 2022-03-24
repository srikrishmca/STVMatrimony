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

        public async Task<int> InsertUpdateCustomerPhotos(ProfilePic request)
        {
            try
            {
                if (request.Id > 0)
                {

                    _dbContext.ProfilePic.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                  
                    _ = _dbContext.ProfilePic.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProfilePic> GetCustomerPhotosByCustomerId(int ProfileId)
        {
            var query = _dbContext.ProfilePic.AsNoTracking().Where(i => i.ProfileId == ProfileId);
            return (query != null) ? await query.FirstOrDefaultAsync() : new ProfilePic();
        }

       
    }
}
