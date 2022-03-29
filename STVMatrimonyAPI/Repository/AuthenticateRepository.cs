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
    public class AuthenticateRepository : IAuthenticateRepository
    {
        DatawarehouseContext _dbContext;
        public AuthenticateRepository(DatawarehouseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {
            IQueryable<UserDetails> query = _dbContext.UserDetails.AsNoTracking().Where(i => i.Username.Equals(request.UserName) && i.Password.Equals(request.Password));
            UserDetails user = await query.FirstOrDefaultAsync();
            return user != null ? "Success" : "Invalid username or password";
        }
        public async Task<UserDetails> GetUserAdmin(AuthenticateUserDetailsRequest request)
        {
            IQueryable<UserDetails> query = _dbContext.UserDetails.AsNoTracking().Where(i => i.Username.Equals(request.UserName));
            UserDetails user = await query.FirstOrDefaultAsync();
            return user ?? null;
        }
        public async Task<bool> Verify(int UserId)
        {
            bool result = false;
            try
            {
                using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
                {

                    try
                    {
                        command.CommandText = "Update UserDetails set IsEmailVerified = 1,IsActive=1 where UserId = @ID";
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add(new SqlParameter("@ID", UserId));
                        _dbContext.Database.OpenConnection();
                        await command.ExecuteNonQueryAsync();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                    finally
                    {
                        _dbContext.Database.CloseConnection();
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
