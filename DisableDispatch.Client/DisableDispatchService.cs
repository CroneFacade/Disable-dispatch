using System;
using System.Linq;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CroneFacade.DisableDispatch.Client.Constants;
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
			API.EnableDispatchService(1, false); // PoliceAutomobile
			API.EnableDispatchService(2, false); // PoliceHelicopter
			API.EnableDispatchService(3, false); // FireDepartment
			API.EnableDispatchService(4, false); // SwatAutomobile
			API.EnableDispatchService(5, false); // AmbulanceDepartment
			API.EnableDispatchService(6, false); // PoliceRiders
			API.EnableDispatchService(7, false); // PoliceVehicleRequest
			API.EnableDispatchService(8, false); // PoliceRoadBlock
			API.EnableDispatchService(9, false); // PoliceAutomobileWaitPulledOver 
			API.EnableDispatchService(10, false); // PoliceAutomobileWaitCruising 
			API.EnableDispatchService(11, false); // Gangs 
			API.EnableDispatchService(12, false); // SwatHelicopter 
			API.EnableDispatchService(13, false); // PoliceBoat 
			API.EnableDispatchService(14, false); // ArmyVehicle 
			API.EnableDispatchService(15, false); // BikerBackup 
		}
	}
}
