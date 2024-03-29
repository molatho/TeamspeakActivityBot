﻿using TeamSpeak3QueryApi.Net.Specialized.Responses;

namespace TeamspeakActivityBot
{
    public static class ClientExtension
    {
        public static bool IsOutputMuted(this GetClientDetailedInfo clientInfo)
        {
            return clientInfo.OutputMuted || clientInfo.OutputOnlyMuted;
        }
    }
}
