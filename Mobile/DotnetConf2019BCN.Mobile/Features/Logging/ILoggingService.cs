using System;

namespace DotnetConf2019BCN.Mobile.Features.Logging
{
    public interface ILoggingService
    {
        void Debug(string message);

        void Warning(string message);

        void Error(Exception exception);
    }
}