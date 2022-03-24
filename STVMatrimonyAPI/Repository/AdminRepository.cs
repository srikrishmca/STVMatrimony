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
    public class AdminRepository : IAdminRepository
    {
        
        DatawarehouseContext _dbContext;
        public AdminRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> InsertUserDetails(UserDetails request)
        {
            try
            {
                return await InsertUpdateUserDetails(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<int> InsertUpdateUserDetails(UserDetails request)
        {
            try
            {
                if (request.UserId > 0)
                {
                    _ = _dbContext.UserDetails.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.UserId : 0;
                }
                else
                {
                    // for first register set email verified to false and send a email verification link to user
                    request.IsEmailVerified = false;
                    request.IsActive = false;
                    _ = _dbContext.UserDetails.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.UserId : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public async Task<IEnumerable<UserDetails>> GetAllUserDetailss()
        {
            IQueryable<UserDetails> query = _dbContext.UserDetails.AsNoTracking();
            return await query.ToListAsync();
        }

      
        public async Task<bool> CheckEmailExists(string EmailId)
        {
            bool result = false;
            try
            {
                var _email = await _dbContext.UserDetails.AsNoTracking().Where(i => i.Email == EmailId).FirstOrDefaultAsync();
                result = _email != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public async Task<bool> CheckUserNameExists(string UserName)
        {
            bool result = false;
            try
            {
                var _email = await _dbContext.UserDetails.AsNoTracking().Where(i => i.Username == UserName).FirstOrDefaultAsync();
                result = _email != null;
            }
            catch
            {
                result = false;
            }
            return result;
        }

    }
}
