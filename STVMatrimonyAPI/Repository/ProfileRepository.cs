using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using STVMatrimony.Models.APIRequest;
using Microsoft.EntityFrameworkCore;
using STVMatrimony.Utility;
using System.Data;
using Microsoft.Data.SqlClient;

namespace STVMatrimonyAPI.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        DatawarehouseContext _dbContext;
        public ProfileRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region ProfileDetails codes start here 
        public async Task<int> InsertUpdateProfileDetails (ProfileDetails request)
        {
            try
            {
                if (request.ProfileId > 0)
                {
                    _dbContext.ProfileDetails.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.ProfileId : 0;
                }
                else
                {
                    _dbContext.ProfileDetails.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.ProfileId : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> InsertUpdateProfilePicture(ProfilePic request)
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
                    _dbContext.ProfilePic.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProfileDetails>> GetAllProfiles()
        {
            return await _dbContext.ProfileDetails.AsNoTracking().ToListAsync();
        }
       

        public async Task<IEnumerable<VwBasicProfileDetailsInfo>> GetAllBasicProfiles()
        {
            return await _dbContext.VwBasicProfileDetailsInfo.AsNoTracking().ToListAsync();
        }
        public async Task<VwDetailProfileInfo> GetDetailProfileViewbyId(int ProfileId, int UserId)
        {
            var AllowedProfileCount = await _dbContext.ProfileLogCount.Where(i => i.UserId == UserId).Select(i => i.ProfileCount).FirstOrDefaultAsync();
            if (AllowedProfileCount > 0)
            {
               // ToDo log the userid and profile Id values in user profile logs table. 
                // Retrive the profile 
                return await _dbContext.VwDetailProfileInfo.AsNoTracking().Where(i => i.ProfileId == ProfileId).FirstOrDefaultAsync();
            }
            else
            {
                return new VwDetailProfileInfo();
            }
        }

        #endregion

        #region Profile Pic logs
        public async Task<int> InsertUpdateProfileLogCount(ProfileLogCount request)
        {
            try
            {
                if (request.Id > 0)
                {
                    _dbContext.ProfileLogCount.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                    _dbContext.ProfileLogCount.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
