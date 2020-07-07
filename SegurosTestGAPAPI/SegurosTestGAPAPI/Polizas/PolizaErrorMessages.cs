using Microsoft.Extensions.Localization;

namespace SegurosTestGAPAPI.Polizas
{
    public class PolizaErrorMessages
    {
        private readonly IStringLocalizer<PolizaErrorMessages> _localizer;

        public string EntityDoesNotExist => GetString(nameof(EntityDoesNotExist));

        public string PolizaAlreadyExists => GetString(nameof(PolizaAlreadyExists));

        public string PolizaDoesNotExist => GetString(nameof(PolizaDoesNotExist));

        public PolizaErrorMessages(IStringLocalizer<PolizaErrorMessages> localizer) => _localizer = localizer;

        private string GetString(string name) => _localizer[name];
    }
}
