using Microsoft.Extensions.Localization;

namespace SegurosTestGAPAPI.Clientes
{
    public class ClienteErrorMessages
    {
        private readonly IStringLocalizer<ClienteErrorMessages> _localizer;

        public string EntityDoesNotExist => GetString(nameof(EntityDoesNotExist));

        public string ClienteAlreadyExists => GetString(nameof(ClienteAlreadyExists));

        public string ClienteDoesNotExist => GetString(nameof(ClienteDoesNotExist));

        public ClienteErrorMessages(IStringLocalizer<ClienteErrorMessages> localizer) => _localizer = localizer;

        private string GetString(string name) => _localizer[name];
    }
}
