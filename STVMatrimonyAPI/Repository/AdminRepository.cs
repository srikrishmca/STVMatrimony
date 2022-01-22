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
    public class AdminRepository : IAdminRepository
    {
        DatawarehouseContext _dbContext;
        public AdminRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> InsertUpdateAdmin(Admin request)
        {
            try
            {
                if (request.Id > 0)
                {
                    _ = _dbContext.Admin.Update(request);
                    int result = await _dbContext.SaveChangesAsync();
                    return (result == 1) ? request.Id : 0;
                }
                else
                {
                    _ = _dbContext.Admin.Add(request);
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
            IQueryable<Admin> query = _dbContext.Admin.AsNoTracking().Where(i => i.Username.Equals(request.UserName) && i.Password.Equals(request.Password));
            Admin user = await query.FirstOrDefaultAsync();
            return user != null ? "Success" : "Invalid username or password";
        }
    }
}
