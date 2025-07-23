using System.Threading.Tasks;

namespace ValuationBackend.Services
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }
} 