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
                    _dbContext.Admin.Update(request);
                    await _dbContext.SaveChangesAsync();
                    return request.Id;
                }
                else
                {
                    _dbContext.Admin.Add(request);
                    await _dbContext.SaveChangesAsync();
                    return request.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string>AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {
            Admin user = await _dbContext.Admin.AsNoTracking()
                .Where(i => i.Username.Equals(request.UserName) && i.Password.Equals(request.Password)).FirstOrDefaultAsync();
            if (user != null)
            {
                return "Success";
            }
            else
            {
                return "Invalid username or password";
            }
        }
    }
}
