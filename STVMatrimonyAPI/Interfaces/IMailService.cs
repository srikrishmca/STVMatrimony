using STVMatrimonyAPI.Model;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmailAsync(MailRequest mailRequest);
        Task<bool> SendRegisterEmailAsync(MailRequest mailRequest);
    }
}
