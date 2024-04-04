using Sandbox.Network;
using TimeUntilBug.CoreLogic;

namespace TimeUntilBug.Core
{
	public class NetworkLogic : Component
	{
		public static TimerLogic TimerLogic
		{
			get
			{
				return Game.ActiveScene.Components.GetAll<TimerLogic>().FirstOrDefault();
			}
		}

		protected override void OnAwake()
		{
			//Log.Info( "NetworkLogic OnAwake - GameNetworkSystem.IsActive " + GameNetworkSystem.IsActive );

			if ( !GameNetworkSystem.IsActive )
			{
				GameNetworkSystem.CreateLobby();
			}
		}

		protected override async void OnStart()
		{
			//Log.Info( "NetworkLogic OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );

			if ( !Networking.IsHost ) { return; }

			var goTimerLogic = new GameObject();
			goTimerLogic.Components.Create<TimerLogic>();
			goTimerLogic.Parent = this.Scene;

			await GameTask.DelayRealtimeSeconds( 2 );

			var list = await Networking.QueryLobbies();
			Log.Info( "Amount Lobbies " + list.Count );
			foreach ( var server in list )
			{
				Log.Info( server.LobbyId.ToString() );
			}

		}

	}
}
