
namespace Sandbox
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

			if ( SimeSinceTick < 30f ) { return; }
			SimeSinceTick = 0f;

			Log.Info( "SimeSinceTick " + SimeSinceTick + " " + Networking.IsHost );
			Log.Info( "Recreating child. Next in 30s" );

			DynamicBaseComponent?.Destroy();
			GameObject.Components.Create<DynamicChildComponent>();
			GameObject.Network.Refresh();
		}

		public void OnBecameHost( Connection client )
		{
			Log.Info( "TimerLogic OnBecameHost " + client + " " + this + " Networking.IsHost " + Networking.IsHost );
			Log.Info( "TimerLogic SimeSinceTick " + SimeSinceTick );

		}
	}
}
