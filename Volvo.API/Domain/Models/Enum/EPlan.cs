using System.ComponentModel;

namespace Volvo.API.Domain.Models.Enum
{
    public enum EPlan
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Brasil")]
        Brazil = 1,
        [Description("Suécia")]
        Sweden = 2,
        [Description("Estados Unidos")]
        UnitedStates = 3,
        [Description("França")]
        France = 4,
    }
}
