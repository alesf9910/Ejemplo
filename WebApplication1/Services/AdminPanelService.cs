using Microsoft.Extensions.Options;
using ServiceInjection;
using System.Diagnostics;
using WebApplication1.Data;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    [Service(ServiceType.Singleton, nameof(IAdminPanelService))]
    public class AdminPanelService : IAdminPanelService
    {
        private readonly AdministratorOperationsToBlock administratorOperationsToBlock;
        private readonly List<string> Urls;
        public AdminPanelService(IOptions<AdministratorOperationsToBlock> configureOptions) {
            administratorOperationsToBlock = configureOptions.Value;
            Urls = new List<string>();
        }

        public bool CheckUrl(string url)
        {
            foreach (var x in administratorOperationsToBlock.Create ?? [])
            {
                if (url.Contains("Create") && url.Contains(x)) return false;
            }
            foreach (var x in administratorOperationsToBlock.Update ?? [])
            {
                if (url.Contains("EditEntity") && url.Contains(x)) return false;
            }
            foreach (var x in administratorOperationsToBlock.Delete ?? [])
            {
                if (url.Contains("DeleteEntity") && url.Contains(x)) return false;
            }
            return true;
        }
    }
}
