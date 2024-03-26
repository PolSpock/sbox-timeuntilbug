
namespace Sandbox
{
	public class TimerLogic : Component
	{
		[Sync] public TimeUntil MyTimeUntil { get; set; }
		[Sync] public RealTimeUntil MyRealTimeUntil { get; set; }

		[HostSync] public TimeUntil HostTimeUntil { get; set; }
		[HostSync] public RealTimeUntil HostRealTimeUntil { get; set; }
		public TimeSince SimeSinceTick { get; set; }


		public DynamicChildComponent DynamicChildComponent
		{
			get
			{
				return Game.ActiveScene.Components.GetAll<DynamicChildComponent>().FirstOrDefault();
			}
		}


		protected override void OnStart()
		{
			Log.Info( "TimerLogic OnStart - IsProxy " + IsProxy + " IsHost " + Networking.IsHost );
			if ( !Networking.IsHost ) { return; }
			if ( IsProxy ) { return; }

			MyTimeUntil = 60f;
			MyRealTimeUntil = 60f;
			HostTimeUntil = 60f;
			HostRealTimeUntil = 60f;

			DynamicChildComponent?.Destroy();
			GameObject.Components.Create<DynamicChildComponent>();
			GameObject.Network.Refresh();
		}

		protected override void OnFixedUpdate()
		{
			base.OnFixedUpdate();

			if ( SimeSinceTick < 1f ) { return; }
			SimeSinceTick = 0f;

			Log.Info( "--------" );
			Log.Info( "MyTimeUntil " + MyTimeUntil );
			Log.Info( "MyRealTimeUntil " + MyRealTimeUntil );
			Log.Info( "HostTimeUntil " + HostTimeUntil );
			Log.Info( "HostRealTimeUntil " + HostRealTimeUntil );

			DynamicChildComponent?.Destroy();
			GameObject.Components.Create<DynamicChildComponent>();
			GameObject.Network.Refresh();
		}

	}
}
