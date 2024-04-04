
using TimeUntilBug.BaseComponent;
using TimeUntilBug.Two.ChildComponent;

namespace TimeUntilBug.CoreLogic
{
	public class TimerLogic : Component, Component.INetworkListener
	{
		[HostSync] public TimeSince SimeSinceTick { get; set; }

		public DynamicBaseComponent DynamicBaseComponent
		{
			get
			{
				return Game.ActiveScene.Components.GetAll<DynamicBaseComponent>().FirstOrDefault();
			}
		}

		protected override void OnAwake()
		{
			if ( !Networking.IsHost ) { return; }
			GameObject.Name = GetType().Name;
			GameObject.Network.SetOrphanedMode( NetworkOrphaned.Host );
			GameObject.NetworkSpawn();

			Log.Info( "TimerLogic OnAwake" );
		}


		protected override void OnDestroy()
		{
			if ( !Networking.IsHost ) { return; }

			Log.Info( "TimerLogic OnDestroy" );
		}

		protected override void OnStart()
		{
			Log.Info( "TimerLogic OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
			if ( !Networking.IsHost ) { return; }

			Transform.Position = Vector3.Random * 100f;

			DynamicBaseComponent?.Destroy();
			Components.Create<DynamicChildComponent>();

		}

		protected override void OnFixedUpdate()
		{
			if ( !Networking.IsHost ) { return; }

			if ( SimeSinceTick < 60f ) { return; }
			SimeSinceTick = 0f;

			Log.Info( "SimeSinceTick " + SimeSinceTick + " " + Networking.IsHost );
			Log.Info( "Recreating child. Next in 60f" );

			DynamicBaseComponent?.Destroy();
			GameObject.Components.Create<DynamicChildComponent>();
		}

		public void OnBecameHost( Connection client )
		{
			Log.Info( "TimerLogic OnBecameHost " + client + " " + this + " Networking.IsHost " + Networking.IsHost );
			Log.Info( "TimerLogic SimeSinceTick " + SimeSinceTick );
		}

	}
}
