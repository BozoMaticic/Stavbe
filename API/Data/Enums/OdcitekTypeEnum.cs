using System;

namespace API.Data.Enums;

public enum OdcitekTypeEnum
{
    ELEKTRIKA = 1,
    OGREVANJE = 2,
    KOMUNALA = 3,        // voda + kanal
    KANAL = 4,
    SMETI = 5,
    VODA = 6,
    Other
}
