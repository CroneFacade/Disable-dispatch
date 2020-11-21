using System;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;

namespace CroneFacade.DisableDispatch.Client
{
	[PublicAPI]
	public class DisableDispatchService : Service
	{
		public DisableDispatchService(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user)
		{
		}

		public override async Task Started()
		{
			Game.Player.DispatchsCops = false;
			Game.Player.IgnoredByPolice = true;
			Game.MaxWantedLevel = 0;
			API.SetCreateRandomCops(false);
			API.SetCreateRandomCopsNotOnScenarios(false);
			API.SetCreateRandomCopsOnScenarios(false);
			for (int service = 1; service < 16; service++) {
				API.EnableDispatchService(service, false);
			}
		}
	}
}
