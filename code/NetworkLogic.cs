using Sandbox.Network;

public class NetworkLogic : Component
{

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

		var go = new GameObject();
		go.Network.SetOrphanedMode(NetworkOrphaned.Host);
		go.Components.Create<TimerLogic>();
		go.NetworkSpawn();

		await GameTask.DelayRealtimeSeconds( 2 );

		var list = await Networking.QueryLobbies();
		Log.Info( "Amount Lobbies " + list.Count );
		foreach ( var server in list )
		{
			Log.Info( server.LobbyId.ToString() );
		}

	}

}
