using System.ComponentModel;

namespace Volvo.API.Domain.Models.Enum
{
    public enum EModelType
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Frontal Alta")]
        FH = 1,
        [Description("Frontal Media")]
        FM = 2,
        [Description("Volvo Medio")]
        VM = 3,
    }
}
