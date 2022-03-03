using STVMatrimonyAPI.Model;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
