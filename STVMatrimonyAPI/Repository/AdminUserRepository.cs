using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using STVMatrimony.Models.APIRequest;
using Microsoft.EntityFrameworkCore;
using STVMatrimony.Utility;
namespace STVMatrimonyAPI.Repository
{
    public class AdminUserRepository : IAdminUserRepository
    {
        DatawarehouseContext _dbContext;
        public AdminUserRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> InsertUpdateAdminUser(AdminUser request)
        {
            try
            {
                if (request.Id > 0)
                {
                    _ = _dbContext.AdminUser.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                    _ = _dbContext.AdminUser.Add(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string>AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {
            IQueryable<AdminUser> query = _dbContext.AdminUser.AsNoTracking().Where(i => i.Username.Equals(request.UserName) && i.Password.Equals(request.Password));
            AdminUser user = await query.FirstOrDefaultAsync();
            return user != null ? "Success" : "Invalid username or password";
        }
        public async Task<AdminUser> GetUserAdmin(AuthenticateUserDetailsRequest request)
        {
            IQueryable<AdminUser> query = _dbContext.AdminUser.AsNoTracking().Where(i => i.Username.Equals(request.UserName));
            AdminUser user = await query.FirstOrDefaultAsync();
            return user ?? null;
        }
        public async Task<IEnumerable<AdminUser>> GetAllAdminUsers()
        {
            IQueryable<AdminUser> query = _dbContext.AdminUser.AsNoTracking();
            return await query.ToListAsync();
        }

        
    }
}
