namespace ComunLayer.Enum
{
    using System;
    [Serializable]
    public enum TipoLog : int
    {
        FLogAlternativo = 0,
        FLogEnvioData = 1,
        FLogErrorFlash = 2,
        FLogActualizacionRipleymatico = 3,
        FLogBiometrico = 4,
        WSLog = 5,
        WSLogRMIL = 6,
        WSILog = 7,
        WSICard = 8
    }
}
