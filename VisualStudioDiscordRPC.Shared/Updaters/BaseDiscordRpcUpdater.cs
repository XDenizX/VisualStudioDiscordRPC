﻿using DiscordRPC;

namespace VisualStudioDiscordRPC.Shared.Updaters
{
    internal abstract class BaseDiscordRpcUpdater : BaseUpdater
    {
        protected DiscordRpcClient DiscordRpcClient;

        protected BaseDiscordRpcUpdater(DiscordRpcClient client)
        {
            DiscordRpcClient = client;
        }
    }
}
